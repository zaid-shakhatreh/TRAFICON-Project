using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsDriverData
    {

        public static DataTable GetAllDrivers()
        {
            DataTable table = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessWithDB.DBconnnection);

            string query = @"SELECT * FROM Drivers";

            SqlCommand cmd = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows) 
                {
                    table.Load(reader);
                }

            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return table;
        }

        public static int AddNewDriver(int PersonID, int CreatedByUserID, DateTime CreatedDate)
        {
            int DriverID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessWithDB.DBconnnection);

            string query = @"INSERT INTO Drivers (PersonID,CreatedByUserID,CreatedDate)
                              VALUES 
                              (@PersonID,@CreatedByUserID,@CreatedDate)
                              select SCOPE_IDENTITY();";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            cmd.Parameters.AddWithValue("@CreatedDate", CreatedDate);
            
            try 
            {
            connection.Open ();

                object obj = cmd.ExecuteScalar();

                if (obj != null && int.TryParse(obj.ToString(),out int result)) 
                {
                DriverID = result;
                }

            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return DriverID;

        }

        public static bool UpdateDriverinfo(int DriverID , int PersonID, int CreatedByUserID, DateTime CreatedDate)
        {
            bool isUpdate=false;

            SqlConnection connection = new SqlConnection(clsDataAccessWithDB.DBconnnection);

            string query = @"UPDATE Drivers
                                SET PersonID = @PersonID
                                   ,CreatedByUserID = @CreatedByUserID
                                   ,CreatedDate = @CreatedDate
                              WHERE DriverID =@DriverID";

            SqlCommand cmd = new SqlCommand (query, connection);

            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            cmd.Parameters.AddWithValue("@CreatedDate", CreatedDate);
            cmd.Parameters.AddWithValue("@DriverID", DriverID);

            try 
            {
            connection.Open (); 
               
                int RowAffected=cmd.ExecuteNonQuery();

                isUpdate = RowAffected > 0;

            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return isUpdate;
        }

        public static DataTable GetAllDriverInfo()
        {
            DataTable table = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessWithDB.DBconnnection);

            string query = @"SELECT * FROM Drivers_View";

            SqlCommand command = new SqlCommand (query, connection);

            try 
            {
            connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    table.Load (reader);
                }
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return table;
        }

        public static bool GetDriverInfoByDriverID(int DriverID,
          ref int PersonID, ref int CreatedByUserID, ref DateTime CreatedDate)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessWithDB.DBconnnection);

            string query = "SELECT * FROM Drivers WHERE DriverID = @DriverID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DriverID", DriverID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    PersonID = (int)reader["PersonID"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    CreatedDate = (DateTime)reader["CreatedDate"];


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
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static bool GetDriverInfoByPersonID(int PersonID, ref int DriverID,
            ref int CreatedByUserID, ref DateTime CreatedDate)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessWithDB.DBconnnection);

            string query = "SELECT * FROM Drivers WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    isFound = true;

                    DriverID = (int)reader["DriverID"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    CreatedDate = (DateTime)reader["CreatedDate"];

                }
                else
                {
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }
    }
}
