using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsTestTypeData
    {


        public static DataTable GetAllTest()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessWithDB.DBconnnection);

            string query = @"SELECT * FROM TestTypes";

            SqlCommand cmd = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader Reader = cmd.ExecuteReader();

                if (Reader.HasRows)
                {
                    dt.Load(Reader);
                }

            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return dt;
        }


        public static bool FindByTestID(int TestID, ref string TestType,ref string Description,ref float Fees)
        {
            bool isFound=false;

            SqlConnection connection = new SqlConnection(clsDataAccessWithDB.DBconnnection);

            string query = @"Select * from TestTypes
                              where  TestTypeID = @TestID";


          
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@TestID",TestID);
            try
            {
                connection.Open();
                
                SqlDataReader Reader= cmd.ExecuteReader();

                if (Reader.Read())
                {
                    TestType =(string) Reader["TestTypeTitle"];
                    Description =(string) Reader["TestTypeDescription"];
                    Fees =Convert.ToSingle( Reader["TestTypeFees"]);
                    isFound=true;
                }
                Reader.Close();
            }
            
            catch (Exception ex) { }
            
            finally { connection.Close(); }
        
            return isFound;
        }

        public static int AddTest(string TestTypeTitle,string TestTypeDescription,float TestTypeFees)
        {
            int ID = -1;

            SqlConnection Connection = new SqlConnection(clsDataAccessWithDB.DBconnnection);

            string query = @"INSERT INTO TestTypes
                    (TestTypeTitle,TestTypeDescription,TestTypeFees)
                    VALUES 
                   (@TestTypeTitle,@TestTypeDescription,@TestTypeFees)
                     select Scope_Identity()";

            SqlCommand cmd = new SqlCommand(query ,Connection);

            cmd.Parameters.AddWithValue("@TestTypeTitle", TestTypeTitle);
            cmd.Parameters.AddWithValue("@TestTypeDescription", TestTypeDescription);
            cmd.Parameters.AddWithValue("@TestTypeFees", TestTypeFees);


            try
            {
            Connection.Open();

                object obj = cmd.ExecuteScalar();

                if(obj !=null && int.TryParse(obj.ToString(),out int Result))
                {
                    ID = Result;
                }

            }
            catch (Exception ex) { }
            finally { Connection.Close(); }




            return ID;
        }

        public static bool Update(int TestID,string TestType,string Description,double Fees)
        {
            bool isUpdae=false;

            SqlConnection connection=new SqlConnection(clsDataAccessWithDB.DBconnnection);
            /*
             UPDATE [dbo].[TestTypes]
   SET [TestTypeTitle] = <TestTypeTitle, nvarchar(100),>
      ,[TestTypeDescription] = <TestTypeDescription, nvarchar(500),>
      ,[TestTypeFees] = <TestTypeFees, smallmoney,>
 WHERE <Search Conditions,,>
             */
            string query = @"UPDATE TestTypes
                             SET TestTypeTitle = @TestType
                                 ,TestTypeDescription = @Description
                                 ,TestTypeFees = @Fees
                            WHERE TestTypeID = @TestID";

            SqlCommand cmd = new SqlCommand(query,connection);

            cmd.Parameters.AddWithValue("@TestType", TestType);
            cmd.Parameters.AddWithValue("@Description", Description);
            cmd.Parameters.AddWithValue("@Fees", Fees);
            cmd.Parameters.AddWithValue("@TestID", TestID);

            try 
            {
                connection.Open();

                int RowAffected=cmd.ExecuteNonQuery();
                isUpdae = RowAffected > 0; 
            }

            catch (Exception ex) { }

            finally { connection.Close(); }

            return isUpdae;
        }
    }
}
