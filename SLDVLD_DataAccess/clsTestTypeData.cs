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
        public static bool GetTestTypeByID(int TestTypeID, ref int TestTypeFees, ref string TestTypeTitle, ref string TestTypeDescription)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
            {

                using (SqlCommand command = new SqlCommand("SP_GetTestTypeByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
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
                        Console.WriteLine(ex.ToString());
                    }
                   
                    return ISFound;
                }
            }
        }

        public async static Task<DataTable> GetallTestType()
        {
            return await Task.Run(() =>
              {
                  DataTable dt = new DataTable();

                  using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
                  {
                      using (SqlCommand command = new SqlCommand("SP_GetallTestType", connection))
                      {
                          command.CommandType = CommandType.StoredProcedure;
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
                              Console.WriteLine(ex.Message);
                          }

                          return dt;
                      }
                  }
              });
        }

        public static int AddNewtsetType(int TestTypeFees, string TestTypeDescription, string TestTypeTitle)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
            {

                using (SqlCommand command = new SqlCommand("SP_AddNewtsetType", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

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
                        Console.WriteLine("Error in AddNewtsetType: " + ex.Message);
                    }
                   
                    return AddRow;
                }
            }
        }
        public static bool UpdateTestType(int TestTypeID, string TestTypeDescription, string TestTypeIDTitle, int TestTypeFees)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
            {
                using (SqlCommand command = new SqlCommand("SP_UpdateTsetType", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
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
                        Console.WriteLine("Error in UpdateTestType: " + ex.Message);
                    }
                   
                    return RowAffected > 0;
                }
            }
        }
    }
}
