using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_DataAccess
{
    public class clsLocalDrivingLicenseApplicationData
    {

        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessWithDB.DBconnnection);


            string query = @"SELECT * FROM LocalDrivingLicenseApplications_View
                           order by ApplicationDate Desc";
            // this view output of this query
            /*       
       SELECT LA.LocalDrivingLicenseApplicationID ,
       LC.ClassName,
       Pe.NationalNo,
        Pe.FirstName+' '+Pe.SecondName+' '+Pe.ThirdName+' '+Pe.LastName as FullName,
       app.ApplicationDate,
       (SELECT COUNT(TestAppointments.TestTypeID) AS PassedTestCount FROM Tests INNER JOIN TestAppointments ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID 
       WHERE (TestAppointments.LocalDrivingLicenseApplicationID = LA.LocalDrivingLicenseApplicationID) AND (Tests.TestResult = 1))as PassedTestCount
      ,case
       when app.ApplicationStatus = 1 then 'New'
       when app.ApplicationStatus = 2 then 'Canceled'
       when app.ApplicationStatus = 3 then 'Completed'
       end as Status 
       FROM LocalDrivingLicenseApplications as LA inner join Applications as app
       on LA.ApplicationID = app.ApplicationID
       inner join  LicenseClasses as LC on LA.LicenseClassID =LC.LicenseClassID
       inner join  People as Pe on app.ApplicantPersonID = Pe.PersonID 
             */

            SqlCommand cmd = new SqlCommand(query, connection);

            try
            {
                connection.Open();
            
                SqlDataReader reader = cmd.ExecuteReader();

                if(reader.HasRows)
                {
                    dt.Load(reader);
                }

            }
            catch (Exception ex)
            {
           
            }
            finally { connection.Close(); }


            return dt;
        }

        public static bool GetLocalDrivingLicenseApplicationInfoByID(
            int LocalDrivingLicenseApplicationID, ref int ApplicationID,
            ref int LicenseClassID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessWithDB.DBconnnection);

            string query = @"SELECT * FROM LocalDrivingLicenseApplications
                                where LocalDrivingLicenseApplicationID  = @LocalDrivingLicenseApplicationID";

            SqlCommand cmd = new SqlCommand(query,connection);

            cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);


            try 
            {
            connection.Open ();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read()) 
                {
                    ApplicationID =(int) reader["ApplicationID"];
                    LicenseClassID = (int) reader["LicenseClassID"];

                    isFound = true;
                }
                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return isFound;
        }

        public static bool GetLocalDrivingLicenseApplicationInfoByApplicationID(
         int ApplicationID, ref int LocalDrivingLicenseApplicationID,
         ref int LicenseClassID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessWithDB.DBconnnection);

            string query = @"SELECT *
                             FROM LocalDrivingLicenseApplications
                             where  ApplicationID =@ApplicationID";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);


            try
            {
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    LocalDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                    LicenseClassID = (int)reader["LicenseClassID"];

                    isFound = true;
                }
                reader.Close();

            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return isFound;
        }



        public static int AddNewLocalDrivingLicenseApplication(
            int ApplicationID, int LicenseClassID)
        {
            int LADA_ID =-1;

            SqlConnection connection = new SqlConnection(clsDataAccessWithDB.DBconnnection);

            string query = @"INSERT INTO LocalDrivingLicenseApplications (ApplicationID,LicenseClassID)
     VALUES (@ApplicationID,@LicenseClassID)
                              SELECT SCOPE_IDENTITY();";


            SqlCommand cmd = new SqlCommand(query,connection);

            cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            cmd.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try 
            {
                connection.Open();

                object obj = cmd.ExecuteScalar();

                if(obj !=null && int.TryParse(obj.ToString(),out int result))
                { 
                    LADA_ID=result;

                }

            }
            catch (Exception ex) { }
            finally { connection.Close(); }



            return LADA_ID;
        }

        public static bool UpdateLocalDrivingLicenseApplication(
           int LocalDrivingLicenseApplicationID, int ApplicationID, int LicenseClassID)
        {
            bool isUpdate = false;

            SqlConnection connection = new SqlConnection(clsDataAccessWithDB.DBconnnection);

            string query = @"Update  LocalDrivingLicenseApplications  
                            set ApplicationID = @ApplicationID,
                                LicenseClassID = @LicenseClassID
                            where LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID";

            SqlCommand cmd =new SqlCommand(query,connection);

            cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            cmd.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try 
            {
               connection.Open ();

                int rowAffected = cmd.ExecuteNonQuery();

                isUpdate=rowAffected > 0;

            }
            catch (Exception ex) { }
            finally { connection.Close(); }


            return isUpdate;
        }

        public static bool DeleteLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID)
        {
            bool isDelete = false;

            SqlConnection connection = new SqlConnection(clsDataAccessWithDB.DBconnnection);

            string query = @"DELETE FROM LocalDrivingLicenseApplications
                WHERE  LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID ";

            SqlCommand cmd =new SqlCommand (query,connection);

            cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try 
            {
            connection.Open();

                int rowAffected = cmd.ExecuteNonQuery();    

                isDelete=rowAffected > 0;

            }
            catch (Exception ex)
            {
            }
            finally { connection.Close(); }


            return isDelete;
        }

        public static bool  DoesAttendTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            bool isExist = false;

            SqlConnection connection = new SqlConnection(clsDataAccessWithDB.DBconnnection) ;

            string query = @"SELECT top 1 Found=1
                            FROM LocalDrivingLicenseApplications INNER JOIN
                                 TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID INNER JOIN
                                 Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                            WHERE
                            (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID) 
                            AND(TestAppointments.TestTypeID = @TestTypeID)
                            ORDER BY TestAppointments.TestAppointmentID desc";

            SqlCommand cmd = new SqlCommand(query,connection);

            cmd.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try 
            {
            connection .Open();

                object obj = cmd.ExecuteScalar();

                if(obj != null)
                {
                    isExist = true;
                }
            
            }
            catch (Exception ex) { }
            finally { connection.Close(); }


            return isExist;

        }


        public static int ShowTrials(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            int numberOfTrial = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessWithDB.DBconnnection);

            string query = @"SELECT TotalTrialsPerTest = count(TestID)
                            FROM LocalDrivingLicenseApplications INNER JOIN
                                 TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID INNER JOIN
                                 Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                            WHERE
                            (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID) 
                            AND (TestAppointments.TestTypeID = @TestTypeID)";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            cmd.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();

                object reader = cmd.ExecuteScalar();

                if (reader != null && int.TryParse(reader.ToString(), out int result))
                {
                    numberOfTrial = result;
                }

            }
            catch (Exception ex)
            { }
            finally { connection.Close(); }

            return numberOfTrial;
        }


        public static bool IsThereAnActiveScheduledTest(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {

            bool isExist = false;


            SqlConnection connection = new SqlConnection(clsDataAccessWithDB.DBconnnection);

            string query = @" SELECT top 1 Found=1
                            FROM LocalDrivingLicenseApplications INNER JOIN
                                 TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID 
                            WHERE
                            (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID)  
                            AND(TestAppointments.TestTypeID = @TestTypeID) and isLocked=0
                            ORDER BY TestAppointments.TestAppointmentID desc";

            SqlCommand cmd = new SqlCommand(query,connection);

            cmd.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);


            try {
                connection.Open(); 

                object reader = cmd.ExecuteScalar();

                if(reader!=null)
                {
                    isExist = true;
                }
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return isExist;

        }


        public static bool DoesPassTestType(int LocalDrivingLicenseApplicationID, int TestTypeID) 
        {
            bool isExist = false;


            SqlConnection connection = new SqlConnection(clsDataAccessWithDB.DBconnnection);

            string query = @" SELECT top 1 TestResult
                            FROM LocalDrivingLicenseApplications INNER JOIN
                                 TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID INNER JOIN
                                 Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                            WHERE
                            (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID) 
                            AND(TestAppointments.TestTypeID = @TestTypeID)
                            ORDER BY TestAppointments.TestAppointmentID desc";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);


            try
            {
                connection.Open();

                object reader = cmd.ExecuteScalar();

                if (reader != null)
                {
                    isExist = true;
                }
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return isExist;


        }


        public static bool  IsLicenseIssued(int ApplicationID , int LicenseClassID)
        {

            bool isExist = false;


            SqlConnection connection = new SqlConnection(clsDataAccessWithDB.DBconnnection);

            string query = @"select found=1 from Licenses 
                             where ApplicationID = @ApplicationID and LicenseClass = @LicenseClass";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            cmd.Parameters.AddWithValue("@LicenseClass", LicenseClassID);


            try
            {
                connection.Open();

                object reader = cmd.ExecuteScalar();

                if (reader != null)
                {
                    isExist = true;
                }
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return isExist;

        }


    }

}
