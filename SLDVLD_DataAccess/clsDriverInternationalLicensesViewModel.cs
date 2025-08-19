using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLDVLD_DataAccess
{
    public class clsDriverInternationalLicensesViewModel
    {

        public static bool Find(int DriverID, ref int IntLicenseID, ref int ApplicationID, ref int LocalLicenseID,
            ref DateTime IssueDate, ref DateTime ExpirationDate,ref bool IsActive)
        {

            bool IsFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
            {

                using (SqlCommand command = new SqlCommand("SP_GetDriverInternationalLicenses", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@DriverID", DriverID);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                IsFound = true;
                                IntLicenseID = (int)reader["InternationalLicenseID"];
                                ApplicationID = (int)reader["ApplicationID"];
                                LocalLicenseID = (int)reader["IssuedUsingLocalLicenseID"];
                                IssueDate = Convert.ToDateTime(reader["IssueDate"]);
                                ExpirationDate = Convert.ToDateTime(reader["ExpirationDate"]);
                                IsActive = (bool)reader["IsActive"];

                            }

                        }
                    }
                    catch (Exception ex)
                    {

                    }


                }
            }
            return IsFound;
        }
        public static async Task<DataTable> GetDriverInternationalLicenses(int DriverID)
        {
            return await Task.Run(() =>
            {
                DataTable dt = new DataTable();

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
                {

                    using (SqlCommand command = new SqlCommand("SP_GetDriverInternationalLicenses", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@DriverID", DriverID);

                        try
                        {
                            connection.Open();
                            using (SqlDataReader reader = command.ExecuteReader())
                            {

                                if (reader.HasRows)
                                    dt.Load(reader);

                            }
                        }
                        catch (Exception ex)
                        {

                        }

                        return dt;
                    }
                }
            });
        }

    }
}
