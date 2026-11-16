using DVLD_Buisness;
using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsLocalDrivingLicenseApplication : clsApplication
    {

        public enum _enMode { Addnew = 1, Update = 2 }

        public _enMode mode;

        public int LocalDrivingLicenseApplication { get; set; }
     
        public string PersonFullName {
            get
            {
                return base.ApplicantFullName;
            } }

        public int LicenseClassID { get; set; }
        public clsLicenseClass licenseClassInfo;

        public clsLocalDrivingLicenseApplication()
        {
            this.ApplicationID = -1;
            this.LicenseClassID = -1;


            mode = _enMode.Addnew;
        }


        private clsLocalDrivingLicenseApplication(int LocalDrivingLicenseApplication,
            int AppID,
            int LicenseClassID, int ApplicantPersonID,
            DateTime ApplicationDate, int ApplicationTypeID
           , enApplicationStatus ApplicationStatus,
            DateTime LastStatusDate, float PaidFees, int CreatedByUserID) : base(AppID, ApplicantPersonID, ApplicationDate, ApplicationTypeID,
           ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID)

        {
            mode = _enMode.Update;
            this.LocalDrivingLicenseApplication = LocalDrivingLicenseApplication;
            this.ApplicationID = AppID;
            this.LicenseClassID = LicenseClassID;


            licenseClassInfo = clsLicenseClass.GetLicenseClassInfoByID(LicenseClassID);

        }


        public static clsLocalDrivingLicenseApplication FindByLocalDrivingAppLicenseID
            (int LocalDrivingLicenseApplicationID)
        {
            int AppID = -1;
            int LiecinseClassID = -1;
            bool isFound = clsLocalDrivingLicenseApplicationData.GetLocalDrivingLicenseApplicationInfoByID
                 (LocalDrivingLicenseApplicationID, ref AppID, ref LiecinseClassID);

            if (isFound)
            {
                clsApplication App = clsApplication.FindBaseApplication(AppID);

                return new clsLocalDrivingLicenseApplication(LocalDrivingLicenseApplicationID,
             App.ApplicationID,
             LiecinseClassID, App.ApplicantPersonID,
             App.ApplicationDate, App.ApplicationTypeID
            , App.ApplicationStatus,
             App.LastStatusDate, App.PaidFees, App.CreatedByUserID);

            }
            else
            {
                return null;
            }
        }

        public static clsLocalDrivingLicenseApplication FindByLocalDrivingAppLicenseByApplicationID
            (int ApplicationID)
        { int LADAID = -1;
            int LiecinseClassID = -1;
            bool isFound = clsLocalDrivingLicenseApplicationData.GetLocalDrivingLicenseApplicationInfoByApplicationID
                (ApplicationID, ref LADAID, ref LiecinseClassID);

            if (isFound)
            {
                clsApplication App = clsApplication.FindBaseApplication(ApplicationID);

                return new clsLocalDrivingLicenseApplication(LADAID,
             App.ApplicationID,
             LiecinseClassID, App.ApplicantPersonID,
             App.ApplicationDate, App.ApplicationTypeID
            , App.ApplicationStatus,
             App.LastStatusDate, App.PaidFees, App.CreatedByUserID);

            }
            else
            {
                return null;
            }
        }

        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            return clsLocalDrivingLicenseApplicationData.GetAllLocalDrivingLicenseApplications();
        }




        private bool AddNewLocalDrivingLicenseApplication()
        {
            this.LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplicationData.
                    AddNewLocalDrivingLicenseApplication(this.ApplicationID, this.LicenseClassID);


            return this.LocalDrivingLicenseApplication != -1;
        }



        private bool UpdateLocalDrivingLicenseApplication()
        {

            return clsLocalDrivingLicenseApplicationData.UpdateLocalDrivingLicenseApplication
                (this.LocalDrivingLicenseApplication,
                this.ApplicationID,
                this.LicenseClassID);

        }


        public bool Save()
        {


            if (!base.Save())
            {
                return false;
            }



            switch (this.mode)
            {
                case _enMode.Addnew:
                    {
                        if (AddNewLocalDrivingLicenseApplication())
                        {
                            mode = _enMode.Update;
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                    }
                case _enMode.Update:
                    {
                        return UpdateLocalDrivingLicenseApplication();

                    }
                default:
                    {
                        return false;
                    }

            }

        }

        public static bool DeleteLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID)
        {
            return clsLocalDrivingLicenseApplicationData.DeleteLocalDrivingLicenseApplication
                (LocalDrivingLicenseApplicationID);
        }

        public  bool DoesAttendTestType(clsTestType.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.DoesAttendTestType(this.LocalDrivingLicenseApplication,(int)TestTypeID);
        }


        public  int TotalTrialsPerTest(clsTestType.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.ShowTrials(this.LocalDrivingLicenseApplication,(int) TestTypeID);
        }

        public static bool IsThereAnActiveScheduledTest(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)

        {

            return clsLocalDrivingLicenseApplicationData.IsThereAnActiveScheduledTest(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public bool IsThereAnActiveScheduledTest(clsTestType.enTestType TestTypeID)

        {

            return clsLocalDrivingLicenseApplicationData.IsThereAnActiveScheduledTest(this.ApplicationID, (int)TestTypeID);
        }

        public bool DoesPassTestType(clsTestType.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.DoesPassTestType(this.LocalDrivingLicenseApplication,(int) TestTypeID);
        }

        public bool IsLicenseIssued()
        {
            return clsLocalDrivingLicenseApplicationData.IsLicenseIssued(this.ApplicationID,this.licenseClassInfo.LicenseClassID);
        }
        public bool PassedAllTests()
        {
            return clsTest.GetPassedTestCount(this.ApplicationID) == 3;
        }

        public static bool PassedAllTests(int LocalDrivingLicenseApplicationID)
        {
            //if total passed test less than 3 it will return false otherwise will return true
            return clsTest.GetPassedTestCount(LocalDrivingLicenseApplicationID) == 3 ;
        }

        public clsTest GetLastTestPerTestType(clsTestType.enTestType TestTypeID)
        {
            int TestID = -1;
            int TestAppointmentID = -1;
            bool TestResult = false; string Notes = ""; int CreatedByUserID = -1;

            if (clsTestData.GetLastTestByPersonAndTestTypeAndLicenseClass
                (this.PersonInfo.PersonID,this.LicenseClassID, (int)TestTypeID, ref TestID,
            ref TestAppointmentID, ref TestResult,
            ref Notes, ref CreatedByUserID))

                return new clsTest(TestID,
                        TestAppointmentID, TestResult,
                        Notes, CreatedByUserID);
            else
                return null;

        }

        public int IssueLicenseForTheFirtTime(string Notes, int CreatedByUserID)
        {
            int DriverID = -1;

            clsDriver Driver = clsDriver.FindByPersonID(this.ApplicantPersonID);

            if (Driver == null)
            {
                //we check if the driver already there for this person.
                Driver = new clsDriver();

                Driver._PersonID = this.ApplicantPersonID;
                Driver._CreatedByUserID= CreatedByUserID;
                if (Driver.Save())
                {
                    DriverID = Driver._DriverID;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                DriverID = Driver._DriverID;
            }
            //now we diver is there, so we add new licesnse

            clsLicense License = new clsLicense();
            License.ApplicationID = this.ApplicationID;
            License.DriverID = DriverID;
            License.LicenseClassID= this.LicenseClassID;
            License.IssueDate = DateTime.Now;
            License.ExpirationDate = DateTime.Now.AddYears(this.licenseClassInfo.DefaultValidityLength);
            License.Notes = Notes;
            License.PaidFees = this.licenseClassInfo.ClassFees;
            License.IsActive = true;
            License.IssueReason = (byte) clsLicense.enIssueReason.FirstTime;
            License.CreatedByUserID = CreatedByUserID;

            if (License.Save())
            {
                //now we should set the application status to complete.
                this.setComplete();

                return License.LicenseID;
            }

            else
                return -1;
        }

    }
}
