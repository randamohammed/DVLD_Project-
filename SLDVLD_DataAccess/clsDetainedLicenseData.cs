
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace SLDVLD_DataAccess
{
    public class clsDetainedLicenseData
    {
        public static bool GetDetainedLicenseInfoByID(int DetainID,
    ref int LicenseID, ref DateTime DetainDate,
    ref float FineFees, ref int CreatedByUserID,
    ref bool IsReleased, ref DateTime ReleaseDate,
    ref int ReleasedByUserID, ref int ReleaseApplicationID)

        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
            {
                using (SqlCommand command = new SqlCommand("SP_GetDetainedLicenseInfoByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@DetainID", DetainID);

                    bool ISfound = false;

                    try
                    {

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                ISfound = true;
                                LicenseID = (int)reader["LicenseID"];
                                DetainDate = Convert.ToDateTime(reader["DetainDate"]);
                                FineFees = Convert.ToSingle(reader["FineFees"]);
                                CreatedByUserID = (int)reader["CreatedByUserID"];

                                if (reader["IsReleased"] != System.DBNull.Value)
                                    IsReleased = (bool)reader["IsReleased"];
                                else
                                    IsReleased = false;

                                if (reader["ReleaseDate"] != System.DBNull.Value)
                                    ReleaseDate = Convert.ToDateTime(reader["ReleaseDate"]);
                                else
                                    ReleaseDate = DateTime.MinValue;

                                if (reader["ReleasedByUserID"] != System.DBNull.Value)
                                    ReleasedByUserID = (int)reader["ReleasedByUserID"];
                                else
                                    ReleaseApplicationID = -1;
                            }
                            else
                            {
                                ISfound = false;
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        ISfound = false;

                        ErrorLogger.LogErrorToEventLog($"Error Get Detained LicenseInfo ByID {ex.Message}");
                    }

                    return ISfound;
                }
            }
        }

        public static bool GetDetainedLicenseInfoByLicenseID(int LicenseID,
            ref int DetainID, ref DateTime DetainDate,
            ref float FineFees, ref int CreatedByUserID,
            ref bool IsReleased, ref DateTime ReleaseDate,
            ref int ReleasedByUserID, ref int ReleaseApplicationID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
            {
                using (SqlCommand command = new SqlCommand("SP_GetDetainedLicenseInfoByLicenseID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@LicenseID", LicenseID);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {

                                isFound = true;

                                DetainID = (int)reader["DetainID"];
                                DetainDate = (DateTime)reader["DetainDate"];
                                FineFees = Convert.ToSingle(reader["FineFees"]);
                                CreatedByUserID = (int)reader["CreatedByUserID"];

                                IsReleased = (bool)reader["IsReleased"];

                                if (reader["ReleaseDate"] == DBNull.Value)

                                    ReleaseDate = DateTime.MaxValue;
                                else
                                    ReleaseDate = (DateTime)reader["ReleaseDate"];


                                if (reader["ReleasedByUserID"] == DBNull.Value)

                                    ReleasedByUserID = -1;
                                else
                                    ReleasedByUserID = (int)reader["ReleasedByUserID"];

                                if (reader["ReleaseApplicationID"] == DBNull.Value)

                                    ReleaseApplicationID = -1;
                                else
                                    ReleaseApplicationID = (int)reader["ReleaseApplicationID"];

                            }
                            else
                            {
                                isFound = false;
                            }

                        }


                    }
                    catch (Exception ex)
                    {
                        isFound = false;

                        ErrorLogger.LogErrorToEventLog($"Error Get Detained LicenseInfo By LicenseID {ex.Message}");
                    }

                    return isFound;
                }
            }
        }
        public static async Task<DataTable> GetAllDetainedLicenses()
        {
            return await Task.Run(() =>
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
                {

                    using (SqlCommand command = new SqlCommand("SP_GetAllDetainedLicenses", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        DataTable dt = new DataTable();

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

                            ErrorLogger.LogErrorToEventLog($"Error Get All Detained Licenses {ex.Message}");
                        }

                        return dt;
                    }
                }
            });
        }
        public static int AddNewDetainedLicense(
               int LicenseID, DateTime DetainDate,
               float FineFees, int CreatedByUserID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
            {


                using (SqlCommand command = new SqlCommand("SP_AddNewDetainedLicense", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@LicenseID", LicenseID);
                    command.Parameters.AddWithValue("@DetainDate", DetainDate);
                    command.Parameters.AddWithValue("@FineFees", FineFees);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                    int DetainID = -1;

                    try
                    {
                        connection.Open();

                        object Reslut = command.ExecuteScalar();

                        if (Reslut != null && int.TryParse(Reslut.ToString(), out int InsertID))
                        {
                            DetainID = InsertID;
                        }
                    }
                    catch (Exception ex)
                    {

                        ErrorLogger.LogErrorToEventLog($"Error Add New Detained License {ex.Message}");
                    }

                    return DetainID;
                }
            }
        }

        public static bool UpdateDetainedLicense(int DetainID,
                int LicenseID, DateTime DetainDate,
                float FineFees, int CreatedByUserID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
            {

                using (SqlCommand command = new SqlCommand("SP_UpdateDetainedLicense", connection))
                {
                    command.Parameters.AddWithValue("@DetainID", DetainID);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                    command.Parameters.AddWithValue("@FineFees", FineFees);
                    command.Parameters.AddWithValue("@DetainDate", DetainDate);
                    command.Parameters.AddWithValue("@LicenseID", LicenseID);

                    int RowAffected = 0;
                    try
                    {
                        connection.Open();
                        RowAffected = command.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {

                        ErrorLogger.LogErrorToEventLog($"Error Update Detained License {ex.Message}");
                    }

                    return RowAffected > 0;
                }
            }
        }

        public static bool ReleaseDetainedLicense(int DetainID,
                 int ReleasedByUserID, int ReleaseApplicationID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
            {

                using (SqlCommand command = new SqlCommand("SP_ISReleaseDetainedLicense", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@DetainID", DetainID);
                    command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);
                    command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);
                    command.Parameters.AddWithValue("@ReleaseDate", DateTime.Now);


                    int RowAffected = 0;
                    try
                    {
                        connection.Open();
                        RowAffected = command.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {

                        ErrorLogger.LogErrorToEventLog($"Error Release Detained License {ex.Message}");
                    }

                    return RowAffected > 0;
                }
            }
        }
        public static bool IsLicenseDetained(int LicenseID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
            {

                using (SqlCommand command = new SqlCommand("SP_IsLicenseDetained", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@LicenseID", LicenseID);

                    bool IsDetained = false;

                    try
                    {
                        connection.Open();

                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            IsDetained = Convert.ToBoolean(result);
                        }
                    }
                    catch (Exception ex)
                    {
                        IsDetained = false;

                        ErrorLogger.LogErrorToEventLog($"Error to check Is License Detained {ex.Message}");
                    }

                    return IsDetained;
                }
            }
        }
    }
}
