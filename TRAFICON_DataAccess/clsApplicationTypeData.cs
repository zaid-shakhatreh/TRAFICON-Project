using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsApplicationTypeData
    {

        public static DataTable GetAllApplicationType()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessWithDB.DBconnnection);

            string query =@"SELECT *  FROM ApplicationTypes";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)

                {
                    dt.Load(reader);
                }

                reader.Close();


            }

            catch (Exception ex)
            {
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;

        }

        public static bool GetApplicationTypeByApplicationTypeID(int ApplicationTypeID
      ,ref string ApplicationTypeTitle
      ,ref float ApplicationFees)

        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessWithDB.DBconnnection);

            string query = "SELECT * FROM ApplicationTypes WHERE ApplicationTypeID = @ApplicationTypeID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    ApplicationTypeTitle = (string)reader["ApplicationTypeTitle"];
                    ApplicationFees = Convert.ToSingle(reader["ApplicationFees"]);
                  
                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
        //        isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }


        public static int AddNewApplicationType(string Title, float Fees)

        {
            int AppID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessWithDB.DBconnnection);

            string query = @"INSERT INTO ApplicationTypes
                            (Title,Fees)
                              values (@Title,@Fees)
                              SELECT SCOPE_IDENTITY();";


            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@Title", Title);
            cmd.Parameters.AddWithValue("@Fees", Fees);
      
            try
            {
                connection.Open();

                object Reader = cmd.ExecuteScalar();

                if (Reader != null && int.TryParse(Reader.ToString(), out int result))
                {
                    AppID = result;
                }

            }
            catch (Exception ex) { }
            finally
            { connection.Close(); }



            return AppID;
        }



        public static bool UpdateApplicationType(int ApplicationTypeID, string Title, float Fees)
        {
            bool isUpdate = false;
            SqlConnection connection = new SqlConnection(clsDataAccessWithDB.DBconnnection);

            string query = @"Update ApplicationTypes 
                             set  
                             Title = @Title ,
                             Fees = @Fees  
                             where 
                               ApplicationTypeID = @ApplicationTypeID";
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@Fees", Fees);
            cmd.Parameters.AddWithValue("@Title", Title);
            cmd.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
           
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


    }
}
