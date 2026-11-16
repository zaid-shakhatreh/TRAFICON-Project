using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsCountryData
    {

        public int CountryID { get; set; }
        public string CountryName { get; set; }

        public clsCountryData()
        {
        CountryID = -1;
        CountryName = "";
        }
        public clsCountryData(int CountryID,string CountryName)
        {
        this.CountryID = CountryID;
            this.CountryName = CountryName;
        }


        public static DataTable GetAllCountries()
        {
            DataTable dataTable = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessWithDB.DBconnnection);

            string query = "SELECT * FROM Countries";

            SqlCommand cmd = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    dataTable.Load(reader);
                }

            }
            catch (Exception ex)
            {
               // Console.WriteLine("Error : "+ex.Message);
            }
            finally { connection.Close(); }


            return dataTable;
        }

        public static bool FindCountryByID(int CountryID,ref string CountryName)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessWithDB.DBconnnection);

            string query = "select * from Countries where" +
                " CountryID =@CountryID";
  
            SqlCommand cmd =new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@CountryID",CountryID);

            try {
            connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read()) {
               isFound = true;
                CountryName=(string)reader["CountryName"];
                }
            reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error :" + ex.Message);
            }
            finally { connection.Close(); }


            return isFound;
        }

        public static bool FindCountryByName(string CountryName, ref int CountryID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessWithDB.DBconnnection);

            string query = "SELECT *  FROM Countries " +
                " where CountryName =@CountryName";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@CountryName", CountryName);
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    CountryID = (int)reader["CountryID"];
                }
                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }


            return isFound;
        }
    }
}
