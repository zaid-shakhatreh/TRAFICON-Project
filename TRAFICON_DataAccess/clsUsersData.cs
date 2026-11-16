using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsUsersData
    {

        public static DataTable GetUserInfo()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessWithDB.DBconnnection);

            string query = @"select  Users.UserID ,
                             Users.PersonID,
                             People.FirstName+' '+People.SecondName+' '+ISNULL(People.ThirdName, ' ')+' '+People.LastName as FullName
                             ,Users.IsActive as Active
                             from Users inner join People 
                             on Users.PersonID = People.PersonID";

            SqlCommand cmd = new SqlCommand(query, connection);

            try  {
                connection.Open();
            
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                dt.Load(reader);
                }
            }
            catch (Exception ex){ }
            finally { connection.Close(); }
            return dt;
        }

        public static int AddNewUser(int PersonID, string UserName, string Password, bool IsActive)
        {
            int UserID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessWithDB.DBconnnection);

            string query = @"INSERT INTO Users
           (PersonID,UserName,Password,IsActive)
                              values (@PersonID,@UserName ,@Password , @IsActive )
                              SELECT SCOPE_IDENTITY();";


            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.Parameters.AddWithValue("@Password", Password);
                cmd.Parameters.AddWithValue("@IsActive", IsActive);
           // if (IsActive)
           // {
           // }
           // else
           // {
           //     cmd.Parameters.AddWithValue("@IsActive", 0);
           // }

            try
            {
                connection.Open();

                object Reader = cmd.ExecuteScalar();

                if (Reader != null && int.TryParse(Reader.ToString(), out int result))
                {
                    UserID = result;
                }

            }
            catch (Exception ex) { }
            finally
            { connection.Close(); }



            return UserID;
        }

        public static bool UpdateUser(int UserID,int PersonID,string UserName,
         string Password, bool IsActive)
        {
            bool isUpdate = false;
            SqlConnection connection = new SqlConnection(clsDataAccessWithDB.DBconnnection);

            string query = @"Update Users 
                             set  
                            PersonID = @PersonID ,
                             UserName = @UserName ,
                             Password = @Password ,
                             IsActive = @IsActive  
                             where 
                               UserID = @UserID";
            SqlCommand cmd = new SqlCommand(query,connection);

            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            cmd.Parameters.AddWithValue("@UserName",UserName);
            cmd.Parameters.AddWithValue("@Password", Password);
            cmd.Parameters.AddWithValue("@IsActive", IsActive);
            cmd.Parameters.AddWithValue("@UserID", UserID);

            try { 
            connection.Open();

                int rowAffected=cmd.ExecuteNonQuery();

                isUpdate=rowAffected > 0;                

            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return isUpdate;
        }

        public static bool DeleteUser(int UserID)
        {
            bool isDelete = false;

            SqlConnection connection = new SqlConnection(clsDataAccessWithDB.DBconnnection);

            string query = @"Delete from Users 
                              where  UserID = @UserID ";

            SqlCommand cmd = new SqlCommand(query,connection);

            cmd.Parameters.AddWithValue("@UserID", UserID);

            try {
            connection.Open();
            
                int rowAffected=cmd.ExecuteNonQuery();
                isDelete=rowAffected > 0;
            
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return isDelete;
        }


        public static bool IsUserExistByUserID(int UserID)
        {
            bool isExist = false;

            SqlConnection connection = new SqlConnection(clsDataAccessWithDB.DBconnnection);

            string query = @"select Found=1 from Users 
                             where UserID=@UserID";

            SqlCommand cmd=new SqlCommand(query,connection);

            cmd.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();

                SqlDataReader reader =cmd.ExecuteReader();

                isExist = reader.HasRows;
                 reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }


            return  isExist;
        }

        public static bool IsUserExistByPersonID(int PersonID)
        {
            bool isExist = false;

            SqlConnection connection = new SqlConnection(clsDataAccessWithDB.DBconnnection);

            string query = @"select Found=1 from Users 
                             where PersonID=@PersonID";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            try
            {
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                isExist = reader.HasRows;
                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }


            return isExist;
        }
      
        public static bool FindUserByUserID(int UserID,ref int PersonID,ref string UserName,ref string Password
           ,ref bool IsActive)
        {
            bool isFind = false;
            SqlConnection connection = new SqlConnection(clsDataAccessWithDB.DBconnnection);

            string query = @"select * from Users
                             where UserID=@UserID";
          SqlCommand cmd =new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@UserID", UserID);

            try 
            {
            connection.Open();
            
                SqlDataReader reader =cmd.ExecuteReader();

                if (reader.Read())
                {
                    isFind = true;
                    PersonID = (int)reader["PersonID"];
                    UserName = (string)reader["UserName"];
                    Password = (string)reader["Password"];
                    IsActive = (bool)reader["IsActive"];
                }
                reader.Close ();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return isFind;
        }

        public static bool FindUserByUserNameAndPassword(string UserName, string Password, ref int UserID,ref int PersonID
          , ref bool IsActive)
        {
            bool isFind = false;
            SqlConnection connection = new SqlConnection(clsDataAccessWithDB.DBconnnection);

            string query = @"select * from Users
                             where UserName = @UserName
                                   and Password = @Password ";
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.Parameters.AddWithValue("@Password", Password);

            try
            {
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    isFind = true;
                    PersonID = (int)reader["PersonID"];
                    UserID = (int)reader["UserID"];
                    IsActive = (bool)reader["IsActive"];
                }
                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return isFind;
        }

        public static bool FindUserByPersonID(int PersonID, ref int UserID, ref string UserName, ref string Password
        , ref bool IsActive)
        {
            bool isFind = false;
            SqlConnection connection = new SqlConnection(clsDataAccessWithDB.DBconnnection);

            string query = @"select * from Users
                             where PersonID=@PersonID";
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    isFind = true;
                    PersonID = (int)reader["PersonID"];
                    UserID = (int)reader["UserID"];
                    Password = (string)reader["Password"];
                    IsActive = (bool)reader["IsActive"];
                }
                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return isFind;
        }



    }
}