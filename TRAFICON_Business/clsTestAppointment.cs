using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public  class clsTestAppointment
    {

        enum _enTestMode { AddNew = 1, Update = 2 }

        _enTestMode mode = _enTestMode.AddNew;

        public  int TestAppointmentID {  get; set; }
        public  int      TestTypeID { get; set; }

        public clsTestType.enTestType TestType { get; set; }
        public  int      LocalDrivingLicenseApplicationID { get; set; }
        public  DateTime AppointmentDate { get; set; }
        public  float    PaidFees { get; set; }
        public  bool     IsLocked { get; set; }
        public  int      CreatedByUserID { get; set; }

        public  int      RetakeTestApplicationID { get; set; }

        public clsApplication RetakeTestApplicationInfo;



        public clsTestAppointment()
        {
            TestAppointmentID = -1;
            TestTypeID =-1;
            LocalDrivingLicenseApplicationID = -1;
            AppointmentDate = DateTime.Now;
            PaidFees = -1;
            IsLocked = false;
            CreatedByUserID = -1;
            RetakeTestApplicationID = -1;

            mode = _enTestMode.AddNew;
        }

        public clsTestAppointment(int TestAppointmentID,int TestTypeID,int LocalDrivingLicenseApplicationID,
            DateTime AppointmentDate,float PaidFees ,bool IsLocked,
            int CreatedByUserID,int RetakeTestApplicationID)
        {
            this.TestAppointmentID = TestAppointmentID;
            this.TestTypeID = TestTypeID;
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.AppointmentDate = AppointmentDate;
            this.PaidFees = PaidFees;
            this.IsLocked = IsLocked;
            this.CreatedByUserID = CreatedByUserID;
            this.RetakeTestApplicationID = RetakeTestApplicationID;

            RetakeTestApplicationInfo=clsApplication.FindBaseApplication(RetakeTestApplicationID);

            mode = _enTestMode.Update;
        }

        public static clsTestAppointment GetTestAppointmentInfoByID(int TestAppointmentID)
        {
            int LocalDrivingLicenseApplicationID = -1;
            int TestTypeID = -1;
            DateTime AppointmentDate = DateTime.Now;
            float PaidFees = 0;
            bool IsLocked = false;
            int CreatedByUserID = -1;
            int RetakeTestApplicationID = -1;

            if(clsTestAppointmentData.GetTestAppointmentInfoByID( TestAppointmentID,
            ref TestTypeID, ref LocalDrivingLicenseApplicationID,
            ref AppointmentDate, ref PaidFees, ref CreatedByUserID, ref IsLocked, ref RetakeTestApplicationID))
            {
                return new clsTestAppointment( TestAppointmentID, TestTypeID, LocalDrivingLicenseApplicationID,
            AppointmentDate, PaidFees, IsLocked,
            CreatedByUserID,RetakeTestApplicationID);
            }
            else
            {
                return null;
            }

        }

        public static DataTable GetApplicationTestAppointmentsPerTestType(int LocalDrivingLicenseApplicationID
            , clsTestType.enTestType TestTypeID)
        {
            return clsTestAppointmentData.GetApplicationTestAppointmentsPerTestType(LocalDrivingLicenseApplicationID, (int)TestTypeID);          
        }

        public static DataTable GetAllTestAppointments()
        {
            return clsTestAppointmentData.GetAllTestAppointments();

        }


        private bool AddNewTestAppointment()
        {

            this.TestAppointmentID = clsTestAppointmentData.AddNewTestAppointment(
              TestTypeID, LocalDrivingLicenseApplicationID,
             AppointmentDate, PaidFees,  CreatedByUserID, RetakeTestApplicationID);

            return this.TestAppointmentID != -1;

        }

        private bool UpdateTestAppointment()
        {

            return clsTestAppointmentData.UpdateTestAppointment( TestAppointmentID, TestTypeID, LocalDrivingLicenseApplicationID,
             AppointmentDate, PaidFees,
             CreatedByUserID, IsLocked, RetakeTestApplicationID);

        }

          public bool Save()
        {
            switch (mode)
            {
                case _enTestMode.AddNew:
                    {
                        if (AddNewTestAppointment()) 
                        {
                        mode = _enTestMode.Update;
                            return true;
                        }
                        else
                            { return false; }

                    }


                case _enTestMode.Update:
                    {
                            return UpdateTestAppointment();
                    }
                    default:
                    {
                        return false;
                    }


            }


        }


        public static int GetTestID(int TestAppointmentID)
        {
            return clsTestAppointmentData.GetTestID(TestAppointmentID);
        }
        


    }
    }

