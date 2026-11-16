using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_DataAccess
{
    public class clsLicenseData
    {

        public static DataTable GetAllLicenses()
        {
            DataTable table = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessWithDB.DBconnnection);

            string query = @"SELECT * FROM Licenses";

            SqlCommand cmd = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if(reader.HasRows)
                {
                    table.Load(reader);
                }
            
            }
            catch (Exception e) { }
            finally { connection.Close(); }

            return table;
        }

        public static int AddNewLicense(int ApplicationID,int DriverID,int LicenseClassID , DateTime IssueDate
            ,DateTime ExpirationDate , string Notes, float PaidFees,bool IsActive,
            byte IssueReason,int CreatedByUserID)
        {
            int LicenseID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessWithDB.DBconnnection);

            string query = @"INSERT INTO Licenses
           (ApplicationID,DriverID,LicenseClass,IssueDate,ExpirationDate,
            Notes,PaidFees,IsActive,IssueReason,CreatedByUserID)
            VALUES
                 (@ApplicationID,@DriverID,@LicenseClass,@IssueDate,@ExpirationDate,
                  @Notes,@PaidFees,@IsActive,@IssueReason,@CreatedByUserID)
                 select SCOPE_IDENTITY();";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            cmd.Parameters.AddWithValue("@DriverID", DriverID);
            
            cmd.Parameters.AddWithValue("@LicenseClass", LicenseClassID);
            
            cmd.Parameters.AddWithValue("@IssueDate", IssueDate);
            
            cmd.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            
            if (Notes == string.Empty || Notes == null )
            {
                cmd.Parameters.AddWithValue("@Notes", System.DBNull.Value);
            }
            else 
            {
                cmd.Parameters.AddWithValue("@Notes", Notes);
            }
            
            cmd.Parameters.AddWithValue("@PaidFees", PaidFees);

            cmd.Parameters.AddWithValue("@IsActive", IsActive);
            
            cmd.Parameters.AddWithValue("@IssueReason", IssueReason);
            
            cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try 
            {
            connection.Open();

                object Reader = cmd.ExecuteScalar();
                
                if(Reader !=null && int.TryParse(Reader.ToString(),out int result))
                {
                    LicenseID = result; 
                }

            }
            catch (Exception e){ }
            finally { connection.Close(); }


            return LicenseID;



        }

        public static bool UpdateLicenseInfo(int LicenseID,int ApplicationID, int DriverID, int LicenseClassID, DateTime IssueDate
            , DateTime ExpirationDate, string Notes, float PaidFees, bool IsActive,
            byte IssueReason, int CreatedByUserID)
        {
            bool isUpdate=false;

            SqlConnection connection = new SqlConnection(clsDataAccessWithDB.DBconnnection);

            string query = @"UPDATE Licenses
                             SET ApplicationID = @ApplicationID
                                ,DriverID = @DriverID
                                ,LicenseClass = @LicenseClass
                                ,IssueDate = @IssueDate
                                ,ExpirationDate = @ExpirationDate
                                ,Notes = @Notes
                                ,PaidFees = @PaidFees
                                ,IsActive = @IsActive
                                ,IssueReason = @IssueReason
                                ,CreatedByUserID = @CreatedByUserID
                            WHERE LicenseID = @LicenseID";

            SqlCommand cmd = new SqlCommand(query, connection);

          

            cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            cmd.Parameters.AddWithValue("@DriverID", DriverID);

            cmd.Parameters.AddWithValue("@LicenseClass", LicenseClassID);

            cmd.Parameters.AddWithValue("@IssueDate", IssueDate);

            cmd.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);

            if (Notes != null)
            {
                cmd.Parameters.AddWithValue("@Notes", Notes);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Notes", DBNull.Value);
            }

            cmd.Parameters.AddWithValue("@PaidFees", PaidFees);

            cmd.Parameters.AddWithValue("@IsActive", IsActive);

            cmd.Parameters.AddWithValue("@IssueReason", IssueReason);

            cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            
            cmd.Parameters.AddWithValue("@LicenseID", LicenseID);

            try 
            {
            connection.Open();

                int rowAffected = cmd.ExecuteNonQuery();

                isUpdate = (rowAffected > 0);
            }
            catch (Exception e) { }
            finally { connection.Close(); } 


            return isUpdate;
        }


        public static bool FindByApplicationID(int ApplicationID,ref int LicenseID,ref int DriverID,ref int LicenseClassID,ref DateTime IssueDate
            ,ref DateTime ExpirationDate,ref string Notes,ref float PaidFees,ref bool IsActive,
          ref  byte IssueReason,ref int CreatedByUserID)
        {
            bool isFound=false;

            SqlConnection connection = new SqlConnection(clsDataAccessWithDB.DBconnnection);

            string query = @"select * from Licenses 
                             where ApplicationID = @ApplicationID ";

            SqlCommand cmd =new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try 
            {
            connection.Open ();
            
                SqlDataReader Reader = cmd.ExecuteReader();

                while (Reader.Read())
                {

                    LicenseID = (int)Reader["LicenseID"];

                    DriverID = (int)Reader["DriverID"];

                    LicenseClassID = (int)Reader["LicenseClass"];
                    
                    IssueDate = (DateTime)Reader["IssueDate"];
                    
                    ExpirationDate = (DateTime)Reader["ExpirationDate"];
                    
                    if(Reader["Notes"] !=DBNull.Value)
                    {
                    Notes = (string)Reader["Notes"];
                    }
                    else
                    {
                    Notes = string.Empty;
                    }

                    PaidFees = Convert.ToSingle(Reader["PaidFees"]);

                    IsActive = (bool)Reader["IsActive"];

                    IssueReason = (byte)Reader["IssueReason"];

                    CreatedByUserID = (int)Reader["CreatedByUserID"];

                    isFound = true; 

                }
            Reader.Close();
            }
            catch (Exception e) { }
            finally { connection.Close(); }



            return isFound;
        }

        public static bool FindByLicenseID(int LicenseID, ref int ApplicationID, ref int DriverID, ref int LicenseClassID, ref DateTime IssueDate
            , ref DateTime ExpirationDate, ref string Notes, ref float PaidFees, ref bool IsActive,
          ref byte IssueReason, ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessWithDB.DBconnnection);

            string query = @"select * from Licenses 
                             where LicenseID = @LicenseID ";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                connection.Open();

                SqlDataReader Reader = cmd.ExecuteReader();

                while (Reader.Read())
                {

                    ApplicationID = (int)Reader["ApplicationID"];

                    DriverID = (int)Reader["DriverID"];

                    LicenseClassID = (int)Reader["LicenseClass"];

                    IssueDate = (DateTime)Reader["IssueDate"];

                    ExpirationDate = (DateTime)Reader["ExpirationDate"];

                    if (Reader["Notes"] != DBNull.Value)
                    {
                        Notes = (string)Reader["Notes"];
                    }
                    else
                    {
                        Notes = string.Empty;
                    }

                    PaidFees = Convert.ToSingle(Reader["PaidFees"]);

                    IsActive = (bool)Reader["IsActive"];

                    IssueReason = (byte)Reader["IssueReason"];

                    CreatedByUserID = (int)Reader["CreatedByUserID"];

                    isFound = true;

                }
                Reader.Close();
            }
            catch (Exception e) { }
            finally { connection.Close(); }



            return isFound;
        }
        public static bool FindByDriverID(int DriverID, ref int ApplicationID, ref int LicenseID, ref int LicenseClassID, ref DateTime IssueDate
           , ref DateTime ExpirationDate, ref string Notes, ref float PaidFees, ref bool IsActive,
         ref byte IssueReason, ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessWithDB.DBconnnection);

            string query = @"select * from Licenses 
                             where DriverID = @DriverID ";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@DriverID", DriverID);

            try
            {
                connection.Open();

                SqlDataReader Reader = cmd.ExecuteReader();

                while (Reader.Read())
                {

                    ApplicationID = (int)Reader["ApplicationID"];

                    LicenseID = (int)Reader["LicenseID"];

                    LicenseClassID = (int)Reader["LicenseClass"];

                    IssueDate = (DateTime)Reader["IssueDate"];

                    ExpirationDate = (DateTime)Reader["ExpirationDate"];

                    if (Reader["Notes"] != DBNull.Value)
                    {
                        Notes = (string)Reader["Notes"];
                    }
                    else
                    {
                        Notes = string.Empty;
                    }

                    PaidFees = Convert.ToSingle(Reader["PaidFees"]);

                    IsActive = (bool)Reader["IsActive"];

                    IssueReason = (byte)Reader["IssueReason"];

                    CreatedByUserID = (int)Reader["CreatedByUserID"];

                    isFound = true;

                }
                Reader.Close();
            }
            catch (Exception e) { }
            finally { connection.Close(); }



            return isFound;
        }

        public static bool IsLicenseExistByLicenseID(int LicenseID)
        {
            bool isExist=false;

            SqlConnection connection = new SqlConnection(clsDataAccessWithDB.DBconnnection);

            string query = @"select found = 1 from Licenses 
                              where LicenseID = @LicenseID";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@LicenseID", LicenseID);

            try 
            {
                connection.Open();

                SqlDataReader reder = cmd.ExecuteReader();

                isExist = reder.HasRows;
            }
            catch (Exception e) { }
            finally { connection.Close(); }

            return isExist;
        }

        public static bool IsLicenseExistByPersonID(int PersonID, int LicenseClassID)
        {
            bool isExist = false;

            SqlConnection connection = new SqlConnection(clsDataAccessWithDB.DBconnnection);

            string query = @"  SELECT found = 1
                               FROM Licenses inner join Applications
                               on Licenses.ApplicationID = Applications.ApplicationID
                               where Applications.ApplicantPersonID = @PersonID 
                               and Licenses.LicenseClass = @LicenseClassID";


            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            cmd.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try { 
            connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                isExist = reader.HasRows;
            }
            catch (Exception e) { }
            finally { connection.Close(); }
            
            return isExist;
        }

        public static DataTable GetHistoryLicenseByPersonID(int PersonID)
        {
            DataTable Table = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessWithDB.DBconnnection);

            string query = @"   SELECT LicenseID
                               ,Licenses.ApplicationID
                               ,LicenseClasses.ClassName
                               ,IssueDate
                               ,ExpirationDate
                               ,IsActive
                           FROM Licenses inner join 
                           LicenseClasses on Licenses.LicenseClass = LicenseClasses.LicenseClassID
                           inner  join Applications on Licenses.ApplicationID = Applications .ApplicationID
                           inner join People on Applications.ApplicantPersonID = People.PersonID
                           where 
                           People.PersonID = @PersonID
                           order by IssueDate DESC ";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@PersonID", PersonID);

            try 
            {
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if(reader.HasRows)
                {
                    Table.Load(reader);
                }

            }
            catch (Exception e) { }
            finally { connection.Close(); }


            return Table;
        
        }



        public static bool DeactivateLicense(int LicenseID)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessWithDB.DBconnnection);

            string query = @"UPDATE Licenses
                           SET 
                              IsActive = 0
                             
                         WHERE LicenseID=@LicenseID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);


            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return false;
            }

            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }
    }
}
