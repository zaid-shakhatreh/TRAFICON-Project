using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsDetaindLicenseData
    {

        public static bool FindByLicenseID(
        int LicenseID ,
       ref  int DetainID
      ,ref DateTime DetainDate
      ,ref float FineFees
      ,ref int CreatedByUserID
      ,ref bool IsReleased
      ,ref DateTime ReleaseDate
      ,ref int ReleasedByUserID
      ,ref int ReleaseApplicationID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessWithDB.DBconnnection);

            string query = @"select * from DetainedLicenses
                            where LicenseID = @LicenseID ";

            SqlCommand cmd = new SqlCommand(query,connection);

            cmd.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while(reader.Read())
                {

                    DetainID = (int)reader["DetainID"];

                    DetainDate = (DateTime)reader["DetainDate"];

                    FineFees = Convert.ToSingle(reader["FineFees"]);

                    CreatedByUserID = (int)reader["CreatedByUserID"];

                    IsReleased = (bool)reader["IsReleased"];

                    if(reader["ReleaseDate"] == System.DBNull.Value)
                    {
                        ReleaseDate = DateTime.Now;
                    }
                    else
                    {
                        ReleaseDate = (DateTime)reader["ReleaseDate"];
                    }

                    if (reader["ReleasedByUserID"] == System.DBNull.Value)
                    {
                    ReleasedByUserID = -1;
                    }
                    else
                    {
                    ReleasedByUserID = (int)reader["ReleasedByUserID"];
                    }

                    if (reader["ReleaseApplicationID"] == System.DBNull.Value)
                    {
                        ReleaseApplicationID = -1;
                    }
                    else
                    {
                    ReleaseApplicationID = (int)reader["ReleaseApplicationID"];
                    }

                    isFound = true;
                }

            }
            catch (Exception ex) { }
            finally { connection.Close(); }


            return isFound;
        }


                public static bool FindByDetainID(
            int DetainID
           ,ref int LicenseID
          , ref DateTime DetainDate
          , ref float FineFees
          , ref int CreatedByUserID
          , ref bool IsReleased
          , ref DateTime ReleaseDate
          , ref int ReleasedByUserID
          , ref int ReleaseApplicationID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessWithDB.DBconnnection);

            string query = @"select * from DetainedLicenses
                            where DetainID = @DetainID ";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@DetainID", DetainID);

            try
            {
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    LicenseID = (int)reader["LicenseID"];

                    DetainDate = (DateTime)reader["DetainDate"];

                    FineFees = Convert.ToSingle(reader["FineFees"]);

                    CreatedByUserID = (int)reader["CreatedByUserID"];

                    IsReleased = (bool)reader["IsReleased"];

                    ReleaseDate = (DateTime)reader["ReleaseDate"];

                    ReleasedByUserID = (int)reader["ReleasedByUserID"];

                    ReleaseApplicationID = (int)reader["ReleaseApplicationID"];

                    isFound = true;
                }

            }
            catch (Exception ex) { }
            finally { connection.Close(); }


            return isFound;
        }

        public static DataTable GetAllDetainedLicenses()
        {
            DataTable table = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessWithDB.DBconnnection);

            string query = @"SELECT * FROM DetainedLicenses_View ";

            SqlCommand cmd = new SqlCommand(query, connection);

            try 
            {
               connection.Open ();

                SqlDataReader reader = cmd.ExecuteReader();

                if(reader.HasRows) 
                {
                    table.Load (reader);
                }

            
            }
            catch (Exception ex) { }
            finally { connection.Close(); }



            return table;
        }

        public static int AddNewDetainedLicense(
           int LicenseID, DateTime DetainDate,
           float FineFees, int CreatedByUserID)
        {
            int DetainID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessWithDB.DBconnnection);

            string query = @"INSERT INTO DetainedLicenses
           (LicenseID,DetainDate,FineFees,CreatedByUserID
             ,IsReleased,ReleaseDate,ReleasedByUserID,ReleaseApplicationID)
     VALUES 
            (@LicenseID,@DetainDate,@FineFees,@CreatedByUserID
             ,@IsReleased,@ReleaseDate,@ReleasedByUserID,@ReleaseApplicationID)
              select SCOPE_IDENTITY();";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@LicenseID", LicenseID);
            
            cmd.Parameters.AddWithValue("@DetainDate", DetainDate);
            
            cmd.Parameters.AddWithValue("@FineFees", FineFees);
            
            cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            
            cmd.Parameters.AddWithValue("@IsReleased",false);
            
            cmd.Parameters.AddWithValue("@ReleaseDate", System.DBNull.Value);
            
            cmd.Parameters.AddWithValue("@ReleasedByUserID", System.DBNull.Value);
            
            cmd.Parameters.AddWithValue("@ReleaseApplicationID", System.DBNull.Value);


            try
            {
                connection.Open();
              
              object o = cmd.ExecuteScalar();

                if (o != null && int.TryParse(o.ToString(),out int result))
                {
                DetainID=result;
                }


            }
            catch (Exception ex) { }
            finally { connection.Close(); }


            return DetainID;
        }

        public static bool UpdateDetainedLicense(int DetainID,
            int LicenseID, DateTime DetainDate,
            float FineFees, int CreatedByUserID)
        {

            bool isFind = false;

            SqlConnection connection = new SqlConnection(clsDataAccessWithDB.DBconnnection);

            string query = @"UPDATE DetainedLicenses
                              SET LicenseID = @LicenseID
                                 ,DetainDate = @DetainDate
                                 ,FineFees = @FineFees
                                 ,CreatedByUserID = @CreatedByUserID
                                 ,IsReleased = @IsReleased
                                     WHERE DetainID = @DetainID  ";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@LicenseID", LicenseID);

            cmd.Parameters.AddWithValue("@DetainDate", DetainDate);

            cmd.Parameters.AddWithValue("@FineFees", FineFees);

            cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            cmd.Parameters.AddWithValue("@DetainID", DetainID);

            try
            {
                connection.Open();

                int rowAffected = cmd.ExecuteNonQuery();

                isFind = rowAffected > 0;
            
            }
            catch (Exception ex) { }
            finally { connection.Close(); }


            return isFind;

        }

        public static bool ReleaseDetainedLicense(int DetainID,
                int ReleasedByUserID, int ReleaseApplicationID)
        {
            bool IsRelease = false;

            SqlConnection connection = new SqlConnection(clsDataAccessWithDB.DBconnnection);

            string query = @"UPDATE dbo.DetainedLicenses
                              SET IsReleased = 1, 
                              ReleaseDate = @ReleaseDate, 
                              ReleasedByUserID = @ReleasedByUserID, 
                              ReleaseApplicationID = @ReleaseApplicationID   
                              WHERE DetainID=@DetainID;";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);

            cmd.Parameters.AddWithValue("@ReleaseDate", DateTime.Now);

            cmd.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);

            cmd.Parameters.AddWithValue("@DetainID", DetainID);

            try
            {
                connection.Open();

                int rowAffected = cmd.ExecuteNonQuery();

                IsRelease = rowAffected > 0;

            }
            catch (Exception ex) { }
            finally { connection.Close(); }


            return IsRelease;

        }

        public static bool IsLicenseDetained(int LicenseID)
        {
            bool isDetain = false;

            SqlConnection connection = new SqlConnection(clsDataAccessWithDB.DBconnnection);

            string query = @"SELECT Found = 1 FROM DetainedLicenses_View 
                                    WHERE LicenseID = @LicenseID and IsReleased = 0";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@LicenseID", LicenseID);

          
            try
            {
                connection.Open();

                SqlDataReader Data = cmd.ExecuteReader();

                isDetain = Data.HasRows;

            }
            catch (Exception ex) { }
            finally { connection.Close(); }


            return isDetain;



        }

    }
}
