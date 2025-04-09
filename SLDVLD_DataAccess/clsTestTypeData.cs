using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLDVLD_DataAccess
{
    public class clsTestTypeData
    {
        public static bool GetTestTypeByID(int TestTypeID, ref int TestTypeFees, ref string TestTypeTitle,ref string TestTypeDescription)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString);
            string Qurey = "Select * from TestTypes Where TestTypeID =@TestTypeID";

            SqlCommand command = new SqlCommand(Qurey, connection);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            bool ISFound = false;

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    ISFound = true;
                    TestTypeFees = Convert.ToInt32(reader["TestTypeFees"]);
                    TestTypeDescription = (string)reader["TestTypeDescription"];
                    TestTypeTitle = (string)reader["TestTypeTitle"];
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

        public static DataTable GetallTestType()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString);
            string Query = "Select * from  TestTypes order by TestTypeID";

            SqlCommand command = new SqlCommand(Query, connection);

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

            }
            finally
            {
                connection.Close();
            }
            return dt;
        }

        public static int AddNewtsetType(int TestTypeFees, string TestTypeDescription, string TestTypeTitle)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString);
            string Qurey = @"Insert Into TestTypes (TestTypeFees,TestTypeDescription,TestTypeTitle)
                             Values  (@TestTypeFees,@TestTypeDescription,@TestTypeTitle)
                              ";

            SqlCommand command = new SqlCommand(Qurey, connection);
            command.Parameters.AddWithValue("@TestTypeFees", TestTypeFees);
            command.Parameters.AddWithValue("@TestTypeDescription", TestTypeDescription);
            command.Parameters.AddWithValue("@TestTypeTitle", TestTypeTitle);

            int AddRow = -1;

            try
            {
                connection.Open();

                object AddTestType = command.ExecuteScalar();

                if (AddTestType != null && int.TryParse(AddTestType.ToString(), out int CoutAdd))
                {
                    AddRow = CoutAdd;
                }

            }
            catch (Exception ex)
            {
            }
            finally
            {
                connection.Close();
            }
            return AddRow;
        }

        public static bool UpdateTestType(int TestTypeID, string TestTypeDescription, string TestTypeIDTitle, int TestTypeFees)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString);
            string Query = @"Update TestTypes Set TestTypeTitle =@TestTypeTitle,TestTypeDescription =@TestTypeDescription,TestTypeFees =@TestTypeFees
                           Where TestTypeID = @TestTypeID";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@TestTypeTitle", TestTypeIDTitle);
            command.Parameters.AddWithValue("@TestTypeDescription", TestTypeDescription);
            command.Parameters.AddWithValue("@TestTypeFees", TestTypeFees);
            int RowAffected = 0;

            try
            {
                connection.Open();

                RowAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
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
