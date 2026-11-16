using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsLicenseClassData
    {
        public static bool GetLicenseClassInfoByID(int LicenseClassID,
          ref string ClassName, ref string ClassDescription, ref byte MinimumAllowedAge,
          ref byte DefaultValidityLength, ref float ClassFees)
        {
           bool isFound=false;

            SqlConnection connection = new SqlConnection(clsDataAccessWithDB.DBconnnection);

            string query = @"SELECT *
                            FROM LicenseClasses
                              where LicenseClassID = @LicenseClassID ";

            SqlCommand cmd=new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try 
            {
            connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    ClassName = (string)reader["ClassName"]; 
                    ClassDescription = (string)reader["ClassDescription"];
                    MinimumAllowedAge = (byte)reader["MinimumAllowedAge"];
                    DefaultValidityLength =Convert.ToByte(reader["DefaultValidityLength"]);
                    ClassFees = Convert.ToSingle(reader["ClassFees"]);

                    isFound= true;
                }

            }
            catch (Exception ex){ }
            finally { connection.Close(); }
        
        return isFound;
        
        }


        public static bool GetLicenseClassInfoByClassName(string ClassName, ref int LicenseClassID,
            ref string ClassDescription, ref byte MinimumAllowedAge,
           ref byte DefaultValidityLength, ref float ClassFees)

        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessWithDB.DBconnnection);

            string query = @"SELECT *
                            FROM LicenseClasses
                              where ClassName = @ClassName ";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@ClassName", ClassName);

            try
            {
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    LicenseClassID = (int)reader["LicenseClassID"];
                    ClassDescription = (string)reader["ClassDescription"];
                    MinimumAllowedAge = (byte)reader["MinimumAllowedAge"];
                    DefaultValidityLength = (byte)reader["DefaultValidityLength"];
                    ClassFees = Convert.ToSingle (reader["ClassFees"]);

                    isFound = true;
                }

            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return isFound;

        }

        public static DataTable GetAllLicenseClasses() 
        {
            DataTable table=new DataTable();
        
            SqlConnection connection=new SqlConnection(clsDataAccessWithDB.DBconnnection);

            string query = @"select * from LicenseClasses";

            SqlCommand cmd = new SqlCommand(query, connection);

            try 
            {
                connection.Open();

                SqlDataReader Reader=cmd.ExecuteReader();

                if (Reader.HasRows) 
                {
                table.Load(Reader);
                }
            

            }
            catch (Exception ex) { }
            finally { connection.Close(); }

          return table;
        }

        public static int AddNewLicenseClass(string ClassName, string ClassDescription,
            byte MinimumAllowedAge, byte DefaultValidityLength, float ClassFees)
        {
            int LicenseClassID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessWithDB.DBconnnection);

            string query = @"INSERT INTO LicenseClasses
           (ClassName
           ,ClassDescription
           ,MinimumAllowedAge
           ,DefaultValidityLength
           ,ClassFees)
     VALUES  (@ClassName
             ,@ClassDescription
             ,@MinimumAllowedAge
             ,@DefaultValidityLength
             ,@ClassFees) 
            SELECT SCOPE_IDENTITY();";


            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@ClassName", ClassName);
            cmd.Parameters.AddWithValue("@ClassDescription", ClassDescription);
            cmd.Parameters.AddWithValue("@MinimumAllowedAge", MinimumAllowedAge);
            cmd.Parameters.AddWithValue("@DefaultValidityLength", DefaultValidityLength);
            cmd.Parameters.AddWithValue("@ClassFees", ClassFees);

            try 
            {
                connection.Open();
            
                object reader = cmd.ExecuteScalar();

                if (reader != null && int.TryParse(reader.ToString(),out int Result)) 
                {
                    LicenseClassID=Result;
                }

            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return LicenseClassID;
        }


        public static bool UpdateLicenseClass(int LicenseClassID, string ClassName, 
            string ClassDescription,
            byte MinimumAllowedAge, byte DefaultValidityLength, float ClassFees)
        {
           bool isUpdate=false;
            
            SqlConnection connection=new SqlConnection(clsDataAccessWithDB.DBconnnection);

            string query = @"UPDATE LicenseClasses
                             SET ClassName = ClassName
                                ,ClassDescription =@ ClassDescription
                                ,MinimumAllowedAge = @MinimumAllowedAge
                                ,DefaultValidityLength =@ DefaultValidityLength
                                ,ClassFees = @ClassFees 
                                WHERE  LicenseClassID =@LicenseClassID";
           

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@ClassName", ClassName);
            cmd.Parameters.AddWithValue("@ClassDescription", ClassDescription);
            cmd.Parameters.AddWithValue("@MinimumAllowedAge", MinimumAllowedAge);
            cmd.Parameters.AddWithValue("@DefaultValidityLength", DefaultValidityLength);
            cmd.Parameters.AddWithValue("@ClassFees", ClassFees);
            cmd.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try 
            {
            connection.Open() ;

                int rowAffected = cmd.ExecuteNonQuery();

                isUpdate=rowAffected > 0;


            }
            catch (Exception ex) { }
            finally{ connection.Close(); }


            return isUpdate;

        }

       
    }
}
