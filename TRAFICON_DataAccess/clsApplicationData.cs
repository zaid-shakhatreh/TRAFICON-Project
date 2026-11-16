using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsApplicationData
    {

        public static bool GetApplicationByID(int ApplicationID,
            ref int ApplicantPersonID, ref DateTime ApplicationDate, ref int ApplicationTypeID,
            ref byte ApplicationStatus, ref DateTime LastStatusDate,
            ref float PaidFees, ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessWithDB.DBconnnection);

            string query = @"select * From Applications 
                             where ApplicationID = @ApplicationID";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    ApplicantPersonID = (int)reader["ApplicantPersonID"];
                    ApplicationDate = (DateTime)reader["ApplicationDate"];
                    ApplicationTypeID = (int)reader["ApplicationTypeID"];
                    ApplicationStatus = (byte)reader["ApplicationStatus"];
                    LastStatusDate = (DateTime)reader["LastStatusDate"];
                    PaidFees = Convert.ToSingle (reader["PaidFees"]);
                    CreatedByUserID = (int)reader["CreatedByUserID"];

                    isFound = true;
                }

                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }


            return isFound;

        }

        public static DataTable GetAllApplications()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessWithDB.DBconnnection);

            string query = "select * from Applications";

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
            finally { connection.Close(); }




            return dt;
        }


        public static int AddNewApplication(int ApplicantPersonID, DateTime ApplicationDate, int ApplicationTypeID,
           byte ApplicationStatus, DateTime LastStatusDate,
           float PaidFees, int CreatedByUserID)
        {
            int ApplicationID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessWithDB.DBconnnection);

            //Add Application Query in DataBase 
            string query = @" INSERT INTO Applications
           (ApplicantPersonID
           ,ApplicationDate
           ,ApplicationTypeID
           ,ApplicationStatus
           ,LastStatusDate
           ,PaidFees
           ,CreatedByUserID)
     VALUES
           (@ApplicantPersonID
           ,@ApplicationDate
           ,@ApplicationTypeID
           ,@ApplicationStatus
           ,@LastStatusDate
           ,@PaidFees
           ,@CreatedByUserID    )        
            select SCOPE_IDENTITY();
            ";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
            cmd.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
            cmd.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            cmd.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            cmd.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
            cmd.Parameters.AddWithValue("@PaidFees", PaidFees);
            cmd.Parameters.AddWithValue("@CreatedByUserID  ", CreatedByUserID);


            try
            {
                connection.Open();

                object Reader = cmd.ExecuteScalar();

                if (Reader != null && int.TryParse(Reader.ToString(), out int Result))
                {
                    ApplicationID = Result;
                }
            }
            catch (Exception ex) { }
            finally { connection.Close(); }



            return ApplicationID;
        }

        public static bool UpdateApplication(int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate, int ApplicationTypeID,
             byte ApplicationStatus, DateTime LastStatusDate,
             float PaidFees, int CreatedByUserID)
        {
            bool isUpdate = false;

            SqlConnection connection = new SqlConnection(clsDataAccessWithDB.DBconnnection);

            string query = @"UPDATE Applications
                 SET ApplicantPersonID = @ApplicantPersonID
                 ,ApplicationDate = @ApplicationDate
                 ,ApplicationTypeID = @ApplicationTypeID
                 ,ApplicationStatus = @ApplicationStatus
                 ,LastStatusDate = @LastStatusDate
                 ,PaidFees = @PaidFees
                 ,CreatedByUserID = @CreatedByUserID
                  WHERE ApplicationID = @ApplicationID";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
            cmd.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
            cmd.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            cmd.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            cmd.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
            cmd.Parameters.AddWithValue("@PaidFees", PaidFees);
            cmd.Parameters.AddWithValue("@CreatedByUserID  ", CreatedByUserID);
            cmd.Parameters.AddWithValue("@ApplicationID  ", ApplicationID);

            try
            {
                connection.Open();

                int rowAffected = cmd.ExecuteNonQuery();

                isUpdate = rowAffected > 0;

            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return isUpdate;
        }

        public static bool DeleteApplication(int ApplicationID)
        {
            bool isDelete = false;

            SqlConnection connection = new SqlConnection(clsDataAccessWithDB.DBconnnection);

            string query = @"Delete from Applications 
                             Where ApplicationID =@ApplicationID";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                connection.Open();

                int rowAffected = cmd.ExecuteNonQuery();
                isDelete = rowAffected > 0;

            }
            catch (Exception ex) { }
            finally { connection.Close(); }


            return isDelete;
        }


        public static bool IsApplicationExist(int ApplicationID)
        {
            bool isExist = false;


            SqlConnection connection = new SqlConnection(clsDataAccessWithDB.DBconnnection);

            string query = @"select Exist = 1 from Applications 
                              where ApplicationID = @ApplicationID ";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            try
            {
                connection.Open();

                object Reader = cmd.ExecuteScalar();

                isExist = Reader != null;
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return isExist;
        }

        public static bool DoesPersonHaveActiveApplication(int PersonID, int ApplicationTypeID)
        {

            //incase the ActiveApplication ID !=-1 return true.
            return (GetActiveApplicationID(PersonID, ApplicationTypeID) != -1);
        }

        public static int GetActiveApplicationID(int PersonID, int ApplicationTypeID)
        {
            int ApplicationID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessWithDB.DBconnnection);

            string query = @"select ApplicationID from Applications
                             where  ApplicatPersonID =@PersonID  and
                                    ApplicationTypeID = @ApplicationTypeID  and
                                    ApplicationStatus = 1 ";


            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            cmd.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

            try
            {
                connection.Open();

                object Reader = cmd.ExecuteScalar();

                if (Reader != null && int.TryParse(Reader.ToString(), out int Result))
                {
                    ApplicationID = Result;
                }

            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return ApplicationID;

        }

        public static bool UpdateStatus(int ApplicationID, short NewStatus)
        {
            bool isUpdate = false;

            SqlConnection connection = new SqlConnection(clsDataAccessWithDB.DBconnnection);
          
            string query = @" UPDATE Applications
                SET ApplicationStatus = @NewStatus
                WHERE ApplicationID =@ApplicationID;";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@NewStatus", NewStatus);
            cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try 
            {
                connection.Open();

                int rowAffected = cmd.ExecuteNonQuery();

                isUpdate=rowAffected > 0;
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return isUpdate;

        }

        public static int GetActiveApplicationIDForLicenseClass(int PersonID, int ApplicationTypeID, int LicenseClassID)
        {
            int ActiveApplicationID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessWithDB.DBconnnection);

            string query = @"SELECT ActiveApplicationID=Applications.ApplicationID  
                            From
                            Applications INNER JOIN
                            LocalDrivingLicenseApplications ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID
                            WHERE ApplicantPersonID = @ApplicantPersonID 
                            and ApplicationTypeID=@ApplicationTypeID 
							and LocalDrivingLicenseApplications.LicenseClassID = @LicenseClassID
                            and ApplicationStatus=1";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicantPersonID", PersonID);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int AppID))
                {
                    ActiveApplicationID = AppID;
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return ActiveApplicationID;
            }
            finally
            {
                connection.Close();
            }

            return ActiveApplicationID;
        }



    }

}
