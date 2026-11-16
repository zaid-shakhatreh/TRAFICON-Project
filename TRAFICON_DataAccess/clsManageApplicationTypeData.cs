using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsManageApplicationTypeData
    {

        public static DataTable GetAllApplicationType()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessWithDB.DBconnnection);


            string query = @"SELECT * FROM ApplicationTypes";

            SqlCommand cmd =new SqlCommand(query, connection);

            try 
            {
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


        public static bool Update(int ID, int Fees, string ApplicationType)
        {
            bool isUpdate = false;

            SqlConnection connection = new SqlConnection(clsDataAccessWithDB.DBconnnection);

            string query = @"UPDATE ApplicationTypes
                             SET 
                              ApplicationTypeTitle =@ApplicationType 
                             ,ApplicationFees = @Fees
                             WHERE  ApplicationTypeID = @ID";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@ApplicationType", ApplicationType);
            cmd.Parameters.AddWithValue("@Fees", Fees);
            cmd.Parameters.AddWithValue("@ID", ID);

            try 
            {
              connection.Open ();
              
                int rowAffected = cmd.ExecuteNonQuery();
                isUpdate = rowAffected > 0;
                
            }
            catch (Exception ex){ }
            finally { connection.Close(); }

            return isUpdate;
        }

        public static bool FindByID(int ID,ref int Fees,ref string ApplicationType)
        {
            bool isFind = false;

            SqlConnection connection = new SqlConnection(clsDataAccessWithDB.DBconnnection);

            string query = @"select * from ApplicationTypes 
                               where ApplicationTypeID = @ID";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@ID", ID);

            try 
            {
            connection.Open();
            
                SqlDataReader Reader = cmd.ExecuteReader();
                if (Reader.Read())
                {
                    Fees = Convert.ToInt32(Reader["ApplicationFees"]);
                    ApplicationType =Convert.ToString( Reader["ApplicationTypeTitle"]);
                    isFind=Reader.HasRows;
                }
                Reader.Close();
            }
            catch(Exception ex){ }
            finally { connection.Close(); }


            return isFind;
        }
    }
}
