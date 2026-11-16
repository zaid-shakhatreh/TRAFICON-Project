using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsTest
    {
        enum _enmode { AddNew = 1, Update = 2 }

        _enmode mode;
        public int TestID { get; set; }
        public int TestAppointmentID { get; set; }

        public clsTestAppointment TestAppointmentInfo { get; set; }
        public bool TestResult { get; set; }
        public string Notes { get; set; }
        public int CreatedByUserID { get; set; }

        public clsTest()
        {
            TestID = -1;
            TestAppointmentID = -1;
            TestResult = false;
            Notes = string.Empty;
            CreatedByUserID = -1;

            mode = _enmode.AddNew;
        }

        public clsTest(int TestID, int TestAppointmentID, bool TestResult
            , string Notes, int CreatedByUserID)
        {
            this.TestID = TestID;
            this.TestAppointmentID = TestAppointmentID;
            this.TestResult = TestResult;
            this.Notes = Notes;
            this.CreatedByUserID = CreatedByUserID;
            TestAppointmentInfo = clsTestAppointment.GetTestAppointmentInfoByID(TestAppointmentID);
            mode = _enmode.Update;
        }

        public static DataTable GetAllTestAppointment()
        {
            return clsTestData.GetAllTestAppointment();
        }
        public static bool GetLastTestByPersonAndTestTypeAndLicenseClass
           (int PersonID, int LicenseClassID, int TestTypeID)
        {
            int TestID = -1,
             TestAppointmentID = -1, CreatedByUserID = -1;
            bool TestResult = false;
            string Notes = "";

            return clsTestData.GetLastTestByPersonAndTestTypeAndLicenseClass(PersonID, LicenseClassID, TestTypeID, ref TestID,
            ref TestAppointmentID, ref TestResult,
             ref Notes, ref CreatedByUserID);


        }

        private bool AddNewTest()
        {
            TestID = clsTestData.AddNewTest(TestAppointmentID, TestResult,
          Notes, CreatedByUserID);

            return TestID != -1;
        }
        private bool UpdateTest()
            {
            return clsTestData.UpdateTest(this.TestID,this.TestAppointmentID,this.TestResult,this.Notes,this.CreatedByUserID);
        }

        public bool Save()
        {
            switch (mode)
            {
                case _enmode.Update:
                    {
                        return UpdateTest();
                    }

                case _enmode.AddNew:
                    {
                        if (AddNewTest()) 
                        {
                        mode = _enmode.Update;
                            return true;
                        }
                            return false;
                    }

            }
                            return false;
        }

        public static byte GetPassedTestCount(int LocalDrivingLicenseApplicationID)
        {
            return clsTestData.GetPassedTestCount(LocalDrivingLicenseApplicationID);
        }
    }
}
