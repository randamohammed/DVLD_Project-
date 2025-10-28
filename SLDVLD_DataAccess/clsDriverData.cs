using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLDVLD_DataAccess
{
    public class clsDriverData
    {
        public static bool FnidDriverByPresonID(int PresonId, ref int DriverID, ref int CreatedByUserID, ref DateTime CreatedDate)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
            {
                using (SqlCommand command = new SqlCommand("SP_FnidDriverByPresonID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@PersonID", PresonId);
                    bool ISFound = false;
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                ISFound = true;
                                CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                                CreatedByUserID = (int)reader["CreatedByUserID"];
                                DriverID = (int)reader["DriverID"];
                            }
                        }
                    }
                    catch (Exception Ex)
                    {

                        ErrorLogger.LogErrorToEventLog($"Error Fnid Driver By PresonID {Ex.Message}");
                    }

                    return ISFound;
                }
            }
        }
        public static bool FinidDriverID(int DriverID, ref int PresonId, ref int CreatedByUserID, ref DateTime CreatedDate)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
            {
                using (SqlCommand command = new SqlCommand("SP_FinidDriverID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@DriverID", DriverID);
                    bool ISFound = false;
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                ISFound = true;
                                CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                                CreatedByUserID = (int)reader["CreatedByUserID"];
                                PresonId = (int)reader["PersonID"];
                            }
                        }
                    }
                    catch (Exception Ex)
                    {

                        ErrorLogger.LogErrorToEventLog($"Error Finid DriverID {Ex.Message}");
                    }

                    return ISFound;
                }
            }
        }

        public static bool FindDriverByIDforDriverView(int DriverID, ref int PresonId, ref string NationalNo,ref  string FullName, ref DateTime CreatedDate , ref bool  ISActive )
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
            {
                using (SqlCommand command = new SqlCommand("SP_FindDriverByIDforDriverView", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@DriverID", DriverID);
                    bool ISFound = false;
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                ISFound = true;
                                CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                                NationalNo = (string)reader["NationalNo"];
                                FullName = (string)reader["FullName"];
                                PresonId = (int)reader["PersonID"];
                                ISActive = Convert.ToBoolean(reader["NumberOfActiveLicenses"]);
                            }
                        }
                    }
                    catch (Exception Ex)
                    {

                        ErrorLogger.LogErrorToEventLog($"Error Find Driver By ID forDriverView {Ex.Message}");
                    }

                    return ISFound;
                }
            }
        }
        public static async Task<DataTable> GetAllDrivers()
        {
           

            return await Task.Run(() =>
            {
                DataTable table = new DataTable();
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_GetAllDrivers", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        try
                        {
                            connection.Open();
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.HasRows)
                                    table.Load(reader);

                            }
                        }
                        catch (Exception Ex)
                        {

                            ErrorLogger.LogErrorToEventLog($"Error Get All Drivers {Ex.Message}");
                        }
                    }
                    return table;
                }
            });
        }


        public static bool UpdateDriver(int DriverID, int PresonID, int CreatedByUserID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
            {
                using (SqlCommand command = new SqlCommand("SP_UpdateDriver", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@DriverID", DriverID);
                    command.Parameters.AddWithValue("@PresonID", PresonID);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                    int RowAffeced = 0;

                    try
                    {
                        connection.Open();
                        RowAffeced = command.ExecuteNonQuery();
                    }
                    catch (Exception Ex)
                    {

                        ErrorLogger.LogErrorToEventLog($"Error Update Driver {Ex.Message}");
                    }

                    return RowAffeced > 0;

                }
            }
            }

        public static int AddNewDriver(int CreatedByUserID, int PersonID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
            {
                using (SqlCommand command = new SqlCommand("SP_AddNewDriver", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                    command.Parameters.AddWithValue("@PersonID", PersonID);

                    int DriverID = -1;
                    try
                    {
                        connection.Open();
                        object Reslut = command.ExecuteScalar();
                        if (Reslut != null && int.TryParse(Reslut.ToString(), out int InsertId))
                        {
                            DriverID = InsertId;
                        }
                    }
                    catch (Exception Ex)
                    {

                        ErrorLogger.LogErrorToEventLog($"Error Add New Driver {Ex.Message}");
                    }

                    return DriverID;

                }
            }
        }
    }
}
