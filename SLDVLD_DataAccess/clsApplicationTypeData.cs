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
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
            {
                using (SqlCommand command = new SqlCommand("SP_GetApplicationTypeIInfoByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

                    bool ISFound = false;

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                ISFound = true;
                                ApplicationTypeTitle = (string)reader["ApplicationTypeTitle"];
                                ApplicationFees = Convert.ToSingle(reader["ApplicationFees"]);
                            }
                            else
                            {
                                ISFound = false;
                            }

                        }
                    }
                    catch (Exception ex)
                    {

                        ErrorLogger.LogErrorToEventLog($"Error Get Application TypeIInfo ByID {ex.Message}");
                    }
                    return ISFound;
                }
            }
        }

        public static async Task<DataTable> GetAllApplicationTypes()
        {
            DataTable dt = new DataTable();
            return await Task.Run(() =>
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
                {

                    using (SqlCommand command = new SqlCommand("SP_GetAllApplicationTypes", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        
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

                            ErrorLogger.LogErrorToEventLog($"Error Get All ApplicationTypes {ex.Message}");
                        }

                        
                    }
                }
                return dt;
            });
        }
        public static int AddNewApplicationType(string Title, float Fess)
        {
            using (SqlConnection connectio = new SqlConnection(clsDataAccessSettings.ConntaionString))
            {
                using (SqlCommand command = new SqlCommand("SP_AddNewApplicationType", connectio))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ApplicationFees", Fess);
                    command.Parameters.AddWithValue("@ApplicationTypeTitle", Title);

                    int Add = -1;
                    try
                    {
                        connectio.Open();
                        object Addrow = command.ExecuteScalar();

                        if (Addrow != null && int.TryParse(Addrow.ToString(), out int AddNew))
                        {
                            Add = AddNew;
                        }
                    }
                    catch (Exception ex)
                    {

                        ErrorLogger.LogErrorToEventLog($"Error Add New ApplicationType {ex.Message}");
                    }

                    return Add;
                }
            }
        }
        public static bool UpdateApplicationType(int ApplicationTypeID, string ApplicationTypeTitle, float ApplicationFees)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
            {

                using (SqlCommand command = new SqlCommand("SP_UpdateApplicationType", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
                    command.Parameters.AddWithValue("@ApplicationTypeTitle", ApplicationTypeTitle);
                    command.Parameters.AddWithValue("@ApplicationFees", ApplicationFees);

                    int RowAffected = 0;

                    try
                    {
                        connection.Open();

                        RowAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {

                        ErrorLogger.LogErrorToEventLog($"Error Update ApplicationType {ex.Message}");
                    }

                    return RowAffected > 0;
                }
            }
        }
    }
}
