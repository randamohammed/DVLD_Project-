using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLDVLD_DataAccess
{
    public class clsLicenesData
    {
        public static bool GetLicenseInfoByID(int LicenseID, ref int ApplicationID, ref int DriverID, ref int LicenseClass,
          ref int CreatedByUserID, ref string Notes, ref byte IssueReason, ref DateTime ExpirationDate,
            ref bool IsActive, ref float PaidFees, ref DateTime IssueDate)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
            {
                using (SqlCommand command = new SqlCommand("SP_GetLicenseInfoByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@LicenseID", LicenseID);

                    bool ISFound = false;
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                ISFound = true;
                                ApplicationID = (int)reader["ApplicationID"];
                                //LicenseID = (int)reader["LicenseID"];
                                DriverID = (int)reader["DriverID"];
                                LicenseClass = (int)reader["LicenseClass"];
                                CreatedByUserID = (int)reader["CreatedByUserID"];

                                if (reader["Notes"] == System.DBNull.Value)
                                    Notes = "";
                                else
                                    Notes = (string)reader["Notes"];

                                IssueReason = (byte)reader["IssueReason"];
                                ExpirationDate = Convert.ToDateTime(reader["ExpirationDate"]);
                                IssueDate = Convert.ToDateTime(reader["IssueDate"]);
                                IsActive = (bool)reader["IsActive"];
                                PaidFees = Convert.ToSingle(reader["PaidFees"]);



                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        ISFound = false;

                        ErrorLogger.LogErrorToEventLog($"Error Get LicenseInfoByID: {ex.Message}");
                    }

                    return ISFound;

                }
            }
        }

        public static async Task<DataTable> GetAllLicenses()
        {
            return await Task.Run(() =>
            {
                DataTable dt = new DataTable();

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_GetAllLicenses", connection))
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

                            ErrorLogger.LogErrorToEventLog($"Error Get All Licenses: {ex.Message}");
                        }


                        return dt;

                    }
                }
            });
        }

        public static async Task<DataTable> GetDriverLicenses(int DriverID)
        {
            return await Task.Run(() =>
            {
                DataTable dt = new DataTable();
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
                {

                    using (SqlCommand command = new SqlCommand("SP_GetDriverLicenses", connection))
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

                            ErrorLogger.LogErrorToEventLog($"Error Get Driver Licenses: {ex.Message}");
                        }

                        return dt;

                    }
                }
            });
        }

        public static int AddNewLicense(int ApplicationID, int DriverID, int LicenseClass,
              int CreatedByUserID, string Notes, byte IssueReason, DateTime ExpirationDate,
              bool IsActive, float PaidFees, DateTime IssueDate)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
            {

                using (SqlCommand command = new SqlCommand("SP_AddNewLicense", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    command.Parameters.AddWithValue("@DriverID", DriverID);
                    command.Parameters.AddWithValue("@LicenseClass", LicenseClass);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                    if (Notes == "")
                        command.Parameters.AddWithValue("@Notes", System.DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@Notes", Notes);
                    command.Parameters.AddWithValue("@PaidFees", PaidFees);
                    command.Parameters.AddWithValue("@IssueDate", IssueDate);
                    command.Parameters.AddWithValue("@IsActive", IsActive);
                    command.Parameters.AddWithValue("@IssueReason", IssueReason);
                    command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);

                    int LicenesID = -1;

                    try
                    {
                        connection.Open();
                        object Reslut = command.ExecuteScalar();

                        if (Reslut != null && int.TryParse(Reslut.ToString(), out int InsertId))
                        {
                            LicenesID = InsertId;
                        }

                    }
                    catch (Exception ex)
                    {

                        ErrorLogger.LogErrorToEventLog($"Error Add New License  :{ex.Message}");
                    }

                    return LicenesID;

                }
            }
        }

        public static bool UdateLicenes(int LicenseID, int ApplicationID, int DriverID, int LicenseClass,
              int CreatedByUserID, string Notes, byte IssueReason, DateTime ExpirationDate,
              bool IsActive, float PaidFees, DateTime IssueDate)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
            {
                using (SqlCommand command = new SqlCommand("SP_UdateLicenes", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@LicenseID", LicenseID);
                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    command.Parameters.AddWithValue("@DriverID", DriverID);
                    command.Parameters.AddWithValue("@LicenseClass", LicenseClass);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                    if (Notes == "")
                        command.Parameters.AddWithValue("@Notes", System.DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@Notes", Notes);
                    command.Parameters.AddWithValue("@PaidFees", PaidFees);
                    command.Parameters.AddWithValue("@IssueDate", IssueDate);
                    command.Parameters.AddWithValue("@IsActive", IsActive);
                    command.Parameters.AddWithValue("@IssueReason", IssueReason);
                    command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);

                    int RowAffect = 0;

                    try
                    {
                        connection.Open();
                        RowAffect = command.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {

                        ErrorLogger.LogErrorToEventLog($"Error Udate Licenes : {ex.Message}");
                    }

                    return RowAffect > 0;
                }
            }
        }
        public static int GetActiveLicenseIDByPersonID(int PersonID, int LicenseClassID)
        {

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
            {
                using (SqlCommand command = new SqlCommand("SP_GetActiveLicenseIDByPersonID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@LicenseClass", LicenseClassID);

                    int LicenseID = -1;
                    try
                    {
                        connection.Open();

                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            LicenseID = insertedID;
                        }
                    }

                    catch (Exception ex)
                    {
                        ErrorLogger.LogErrorToEventLog($"Error Get  Active LicenseID  By PersonID{ex.Message}");

                    }



                    return LicenseID;

                }
            }
        }

        public static bool DeactivateLicense(int LicenseID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
            {
      

                using (SqlCommand command = new SqlCommand("SP_DeactivateLicense", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@LicenseID", LicenseID);


                    int RowAffect = 0;

                    try
                    {
                        connection.Open();
                        RowAffect = command.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {

                        ErrorLogger.LogErrorToEventLog($"Error Do activate License{ex.Message}");
                    }
                    return RowAffect > 0;
                }
            }
        }
    }
}