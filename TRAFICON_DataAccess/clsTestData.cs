using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsTestData
    {

        public static DataTable GetAllTestAppointment()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessWithDB.DBconnnection);

            string query = @"SELECT * FROM Tests  order by TestID";

            SqlCommand cmd = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }

            }
            catch (Exception ex) { }
            finally
            {
                connection.Close();
            }


            return dt;
        }

        public static bool GetTestInfoByID(int TestID,
              ref int TestAppointmentID, ref bool TestResult,
              ref string Notes, ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessWithDB.DBconnnection);

            string query = @"SELECT * FROM Tests
                              where TestID =@TestID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestID", TestID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    TestAppointmentID = (int)reader["TestAppointmentID"];
                    TestResult = (bool)reader["TestResult"];
                    if (reader["Notes"] == DBNull.Value)

                        Notes = "";
                    else
                        Notes = (string)reader["Notes"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
          
                    isFound=true;
                }

                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return isFound;
        }

        public static bool GetLastTestByPersonAndTestTypeAndLicenseClass
            (int PersonID, int LicenseClassID, int TestTypeID, ref int TestID,
              ref int TestAppointmentID, ref bool TestResult,
              ref string Notes, ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessWithDB.DBconnnection);

            string query = @"SELECT  top 1 Tests.TestID, 
                Tests.TestAppointmentID, Tests.TestResult, 
			    Tests.Notes, Tests.CreatedByUserID, Applications.ApplicantPersonID
                FROM            LocalDrivingLicenseApplications INNER JOIN
                                         Tests INNER JOIN
                                         TestAppointments ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID INNER JOIN
                                         Applications ON LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID
                WHERE        (Applications.ApplicantPersonID = @PersonID) 
                        AND (LocalDrivingLicenseApplications.LicenseClassID = @LicenseClassID)
                        AND ( TestAppointments.TestTypeID=@TestTypeID)
                ORDER BY Tests.TestAppointmentID Desc";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    TestID = (int)reader["TestID"];
                    TestAppointmentID = (int)reader["TestAppointmentID"];
                    TestResult = (bool)reader["TestResult"];
                    if (reader["Notes"] == DBNull.Value)

                        Notes = "";
                    else
                        Notes = (string)reader["Notes"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];

                    isFound = true;
                }

                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return isFound;


        }


        public static int AddNewTest(int TestAppointmentID, bool TestResult,
            string Notes, int CreatedByUserID)
        {
            int ID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessWithDB.DBconnnection) ;


            string query = @"INSERT INTO Tests
           (TestAppointmentID,TestResult,Notes,CreatedByUserID)
           VALUES  (@TestAppointmentID,@TestResult,@Notes,@CreatedByUserID)
           select SCOPE_IDENTITY()";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            cmd.Parameters.AddWithValue("@TestResult", TestResult);
            if(Notes == string.Empty)
            {
                cmd.Parameters.AddWithValue("@Notes", DBNull.Value);
            }
            else 
            {
                cmd.Parameters.AddWithValue("@Notes", Notes);
            }
            cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();

                object Reader=cmd.ExecuteScalar();

                if( Reader != null && int.TryParse(Reader.ToString(),out int Result))
                {
                    ID=Result;
                }

            }
            catch (Exception ex) { }
            finally { connection.Close(); }



            return ID;  
        }

        public static bool UpdateTest(int TestID, int TestAppointmentID, bool TestResult,
            string Notes, int CreatedByUserID)
        {
            bool isUpdate=false;

            SqlConnection connection = new SqlConnection(clsDataAccessWithDB.DBconnnection);

            string query = @"UPDATE Tests
                            SET TestAppointmentID = @TestAppointmentID
                               ,TestResult = @TestResult
                               ,Notes = @Notes
                               ,CreatedByUserID = @CreatedByUserID
                            WHERE   TestID = @TestID";

            SqlCommand cmd = new SqlCommand (query, connection);

            cmd.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            cmd.Parameters.AddWithValue("@TestResult", TestResult);
            if(Notes=="")
            {
                cmd.Parameters.AddWithValue("@Notes", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Notes", Notes);
            }
            cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            cmd.Parameters.AddWithValue("@TestID", TestID);

            try 
            {
               connection.Open ();

                int rowAffected = cmd.ExecuteNonQuery();

                isUpdate = rowAffected >0;
            
            
            }
            catch (Exception ex) { }
            finally { connection.Close(); }


            return isUpdate;

        }



        public static byte GetPassedTestCount(int LocalDrivingLicenseApplicationID)
        {

            byte count = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessWithDB.DBconnnection);

            string query = @"SELECT PassedTestCount = count(TestTypeID)
                         FROM Tests INNER JOIN
                         TestAppointments ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID
						 where LocalDrivingLicenseApplicationID =@LocalDrivingLicenseApplicationID and TestResult=1";

            SqlCommand command = new SqlCommand (query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try 
            {
            
                connection.Open ();

                object o= command.ExecuteScalar();
            
                if(o!=null && byte.TryParse(o.ToString(),out byte result))
                {

                    count = result;
                }

            }
            catch (Exception ex) { }
            finally{ connection.Close(); }



            return count;
        }
        

    }
}
