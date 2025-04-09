using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLDVLD_DataAccess
{
    public class clsApplicationTypeData
    {
        public static bool GetApplicationTypeIInfoByID(int ApplicationTypeID, ref string ApplicationTypeTitle, ref float ApplicationFees)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString);
            string Qurey = "Select * from ApplicationTypes Where ApplicationTypeID =@ApplicationTypeID";

            SqlCommand command = new SqlCommand(Qurey, connection);
           command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

            bool ISFound = false;

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    ISFound = true;
                    ApplicationTypeTitle = (string)reader["ApplicationTypeTitle"];
                    ApplicationFees = Convert.ToSingle( reader["ApplicationFees"]);
                }
                else
                {
                    ISFound = false;
                }
                reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return ISFound;
        }
       
        public static DataTable GetAllApplicationTypes()
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString);

            string Qurey = "Select * from ApplicationTypes order by ApplicationTypeTitle";

            SqlCommand command = new SqlCommand(Qurey,connection);

            DataTable dt = new DataTable();
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                    dt.Load(reader);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return dt;
        }
    
        public static int AddNewApplicationType(string Title,float Fess)
        {
            SqlConnection connectio = new SqlConnection(clsDataAccessSettings.ConntaionString);

            string Qury = @"Insert Into ApplicationTypes (ApplicationTypeTitle ,ApplicationFees)  
                Values (@ApplicationTypeTitle ,@ApplicationFees)            
                select SCOPE_IDENTITY();";

                SqlCommand command = new SqlCommand(Qury,connectio);
               
              command.Parameters.AddWithValue("@ApplicationFees",Fess);
              command.Parameters.AddWithValue("@ApplicationTypeTitle",Title);

            int Add = -1;
            try
            {
                connectio.Open();
                object Addrow = command.ExecuteScalar();

                if(Addrow != null && int.TryParse(Addrow.ToString(),out int AddNew))
                {
                    Add = AddNew; 
                }
            }
            catch(Exception  ex)
            {

            }
            finally
            {
                connectio.Close();
            }
            return Add;
        }

        public static bool  UpdateApplicationType(int ApplicationTypeID,string ApplicationTypeTitle,float ApplicationFees)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString);

            string Qurey = @"Update ApplicationTypes Set ApplicationTypeTitle =@ApplicationTypeTitle,ApplicationFees =@ApplicationFees
                              Where ApplicationTypeID =@ApplicationTypeID";

            SqlCommand command = new SqlCommand(Qurey,connection);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            command.Parameters.AddWithValue("@ApplicationTypeTitle", ApplicationTypeTitle);
            command.Parameters.AddWithValue("@ApplicationFees", ApplicationFees);

            int RowAffected = 0;

            try
            {
                connection.Open();

                RowAffected = command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return RowAffected > 0;
        }
    }
}
