using DVLD_Buisness;
using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsApplication
    {

        public enum enMode { AddNew = 0, Update = 1 };

        public enMode mode;
        public enum enApplicationStatus { New = 1, Cancelled = 2, Completed = 3 };
        public enum enApplicationType
        {
            NewDrivingLicense = 1, RenewDrivingLicense = 2, ReplaceLostDrivingLicense = 3,
            ReplaceDamagedDrivingLicense = 4, ReleaseDetainedDrivingLicsense = 5, NewInternationalLicense = 6, RetakeTest = 7
        };
        public int ApplicationID { set; get; }
        public int ApplicantPersonID { set; get; }

        public clsPerson PersonInfo { set; get; }
        public string ApplicantFullName
        {
            get { return clsPerson.Find(ApplicantPersonID).FullName; }
        }

        public DateTime ApplicationDate { set; get; }
        public enApplicationStatus ApplicationStatus { set; get; }


       

        public string StatusText
        {
            get
            {
                switch (ApplicationStatus)
                {
                    case enApplicationStatus.New:
                        return "New";

                    case enApplicationStatus.Cancelled:
                        return "Cancelled";

                    case enApplicationStatus.Completed:
                        return "Completed";
                    default:
                        return "Unknown";
                }

            }
        }
        public int ApplicationTypeID { set; get; }

        public clsTestType TestTypeInfo { set; get; }

        public string ApplicationTypeText;

        

        public DateTime LastStatusDate { set; get; }
        public float PaidFees { set; get; }
        public int CreatedByUserID { set; get; }

        public clsUser CreatedByUserInfo { set; get; }

        public clsApplication()
        {
            this.ApplicationID = -1;
            this.ApplicantPersonID = -1;
            this.ApplicationDate = DateTime.Now;
            this.ApplicationTypeID = -1;
            this.ApplicationStatus = enApplicationStatus.New;
            this.LastStatusDate = DateTime.Now;
            this.PaidFees = 0;
            this.CreatedByUserID = -1;

            mode = enMode.AddNew;

        }

        protected clsApplication(int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate, int ApplicationTypeID
           , enApplicationStatus ApplicationStatus, DateTime LastStatusDate, float PaidFees, int CreatedByUserID)
        {
            this.ApplicationID = ApplicationID;
            this.ApplicantPersonID = ApplicantPersonID;
            this.PaidFees = PaidFees;
            this.ApplicationDate = ApplicationDate;
            this.ApplicationStatus = ApplicationStatus;
            this.ApplicationTypeID = ApplicationTypeID;
            this.CreatedByUserID = CreatedByUserID;
            this.LastStatusDate = LastStatusDate;
            
            ApplicationTypeText = clsApplicationType.Find(ApplicationTypeID).Title;
            CreatedByUserInfo = clsUser.FindUserByUserID(CreatedByUserID);
            PersonInfo = clsPerson.Find(ApplicantPersonID);
            TestTypeInfo = clsTestType.FindByTestID(ApplicationTypeID);
                        
            mode = enMode.Update; 

        }

        private bool _AddNewApplication()
        {
            this.ApplicationID = clsApplicationData.AddNewApplication(ApplicantPersonID,ApplicationDate,ApplicationTypeID,
           ((byte)ApplicationStatus),LastStatusDate,
           PaidFees,CreatedByUserID) ;


            return (this.ApplicationID != -1);
        }

        private bool _UpdateApplication()
        {
    return clsApplicationData.UpdateApplication(this.ApplicationID,this.ApplicantPersonID,this.ApplicationDate
                ,this.ApplicationTypeID,(byte)this.ApplicationStatus,this.LastStatusDate,this.PaidFees,this.CreatedByUserID); 
        
        }


        public bool Save()
        {

            switch(mode)
            {
                case enMode.AddNew:
                    {
                        return _AddNewApplication();
                    }
                case enMode.Update:
                    {
                        return _UpdateApplication();
                    }
            }
            return false;
        }

        public static clsApplication FindBaseApplication(int ApplicationID)
        {

            int ApplicantPersonID = 0;
             DateTime ApplicationDate = DateTime.Now;
            int ApplicationTypeID = 0;
            byte  ApplicationStatus = (byte)enApplicationStatus.New;
             DateTime LastStatusDate = DateTime.Now;
            float PaidFees = 0;
            int CreatedByUserID = 0;
            if (clsApplicationData.GetApplicationByID(ApplicationID,
            ref ApplicantPersonID, ref ApplicationDate, ref  ApplicationTypeID,
            ref   ApplicationStatus, ref  LastStatusDate,
            ref  PaidFees, ref  CreatedByUserID))
            {
                return new clsApplication( ApplicationID, ApplicantPersonID, ApplicationDate, ApplicationTypeID
           ,(enApplicationStatus) ApplicationStatus,  LastStatusDate, PaidFees, CreatedByUserID);
            }
            else 
            {
                return null;
            }

        
        }

        public  bool Cancel()
        {
            return clsApplicationData.UpdateStatus(this.ApplicationID,2);
        }

        public bool setComplete()
        {
            return clsApplicationData.UpdateStatus(this.ApplicationID, 3);
        }

        public bool Delete()
        {
            return clsApplicationData.DeleteApplication(this.ApplicationID);
        }

        public static bool IsApplicationExist(int ApplicationID) 
        {
        return clsApplicationData.IsApplicationExist(ApplicationID);
        }
        public static bool DoesPersonHaveActiveApplication(int PersonID, int ApplicationTypeID)
        {
            return clsApplicationData.DoesPersonHaveActiveApplication(PersonID, ApplicationTypeID);
        }
      
        public bool DoesPersonHaveActiveApplication(int ApplicationTypeID)
        {
            return DoesPersonHaveActiveApplication(this.ApplicantPersonID, ApplicationTypeID);
        }

        public static int GetActiveApplicationID(int PersonID, clsApplication.enApplicationStatus ApplicationTypeID) 
        {
            return clsApplicationData.GetActiveApplicationID(PersonID,(byte) ApplicationTypeID);
        }

        public static int GetActiveApplicationIDForLicenseClass(int PersonID, clsApplication.enApplicationType ApplicationTypeID, int LicenseClassID)
        {
            return clsApplicationData.GetActiveApplicationIDForLicenseClass(PersonID,(int) ApplicationTypeID, LicenseClassID);
        }



    }

}
