using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SLDVLD_DataAccess
{
    public class clsLocalDrivingLicenseApplicationData 
    {
        public static bool GetLocalDrivingLicenseApplicationInfoByID(int LocalDrivingLicenseApplicationID, ref int ApplicationID, ref int LicenseClassID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
            {
                using (SqlCommand command = new SqlCommand("SP_GetLocalDrivingLicenseAppInfoByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

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
                                LicenseClassID = (int)reader["LicenseClassID"];
                            }
                            else
                                ISFound = false;

                        }
                    }
                    catch (Exception ex)
                    {
                        ISFound |= false;

                        ErrorLogger.LogErrorToEventLog($"Error Get local Driver: {ex.Message}");
                    }

                    return ISFound;
                }
            }
        }
        public static bool GetLocalDrivingLicenseApplicationInfoByApplicationID(int LocalDrivingLicenseApplicationID, ref int ApplicationID, ref int LicenseClassID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
            {
                using (SqlCommand command = new SqlCommand("SP_GetLocalDrLiceApplInfoByAppID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

                    bool ISFound = false;

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                ISFound = true;
                                LocalDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                                LicenseClassID = (int)reader["LicenseClassID"];
                            }
                            else
                                ISFound = false;

                        }
                    }
                    catch (Exception ex)
                    {
                        ISFound |= false;

                        ErrorLogger.LogErrorToEventLog($"Error Get LocalDriving  LicenseApplication: {ex.Message}");
                    }

                    return ISFound;
                }
            }
        }
        public static async Task<DataTable> GetAllLocalDrivingLicenseApplications()
        {
            return await Task.Run(() =>
            {
                DataTable dt = new DataTable();

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_GetAllLocalDrivingLicenseApplications", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        try
                        {
                            connection.Open();

                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    dt.Load(reader);
                                }
                            }
                        }
                        catch (Exception ex)
                        {

                            ErrorLogger.LogErrorToEventLog($"Error AddNew Local DrivingLicenseApplication: {ex.Message}");
                        }

                        return dt;

                    }
                }
            });
        }

        public static int AddNewLocalDrivingLicenseApplication(int ApplicationID, int LicenseClassID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
            {
                using (SqlCommand command = new SqlCommand("SP_AddNewLocalDrivingLicenseApp", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

                    int LocalDrivingLicenseApplications = -1;

                    try
                    {
                        connection.Open();

                        object Reslut = command.ExecuteScalar();
                        if (Reslut != null && int.TryParse(Reslut.ToString(), out int InsertID))
                        {
                            LocalDrivingLicenseApplications = InsertID;
                        }
                    }
                    catch (Exception ex)
                    {

                        ErrorLogger.LogErrorToEventLog($"Error : {ex.Message}");
                    }

                    return LocalDrivingLicenseApplications;
                }
            }
        }
        public static bool UpdateLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID, int ApplicationID, int LicenseClassID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
            {
                using (SqlCommand command = new SqlCommand("SP_UpdateLocalDrivingLicenseApp", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                    command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

                    int RowAffected = 0;

                    try
                    {
                        connection.Open();
                        RowAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {

                        ErrorLogger.LogErrorToEventLog($"Error Update LocalDriving  License Application: {ex.Message}");
                    }

                    return RowAffected > 0;
                }
            }
        }

        public static bool DeleteLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
            {
                using (SqlCommand command = new SqlCommand("SP_DeleteLocalDrivingLicenseApp", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

                    int RowAffected = 0;

                    try
                    {
                        connection.Open();

                        RowAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {

                        ErrorLogger.LogErrorToEventLog($"Error Delect: {ex.Message}");
                    }

                    return RowAffected > 0;
                }
            }
        }
        public static bool DoesPassTestType(int LocalDrivingLicenseApplicationID, int TestType)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
            {
                using (SqlCommand command = new SqlCommand("SP_DoesPassTestType", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                    command.Parameters.AddWithValue("@TestType", TestType);

                    int PassTestType = 0;

                    try
                    {
                        connection.Open();
                        object Reslut = command.ExecuteScalar();

                        if (Reslut != null && int.TryParse(Reslut.ToString(), out int CountPass))
                        {
                            PassTestType = CountPass;
                        }

                    }
                    catch (Exception ex)
                    {

                        ErrorLogger.LogErrorToEventLog($"Error to check Does Pass TestType: {ex.Message}");
                    }

                    return PassTestType > 0;
                }
            }
        }
        public static byte TotalTrialsPerTest(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
            {
                using (SqlCommand command = new SqlCommand("SP_TotalTrialsPerTest", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                    command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

                    byte TotalTrialsPerTest = 0;

                    try
                    {
                        connection.Open();
                        object Reslut = command.ExecuteScalar();

                        if (Reslut != null && byte.TryParse(Reslut.ToString(), out byte TotalTrialsPer))
                        {
                            TotalTrialsPerTest = TotalTrialsPer;
                        }
                    }
                    catch (Exception ex)
                    {

                        ErrorLogger.LogErrorToEventLog($"Error Get Total TrialsPerTest: {ex.Message}");
                    }

                    return TotalTrialsPerTest;
                }
            }
        }

        public static bool IsThereAnActiveScheduledTest(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
            {

                using (SqlCommand command = new SqlCommand("SP_IsThereAnActiveScheduledTest", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                    command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

                    bool Result = false;
                    try
                    {

                        connection.Open();
                        object result = command.ExecuteScalar();


                        if (result != null)
                        {
                            Result = true;
                        }

                    }
                    catch (Exception ex)
                    {

                        ErrorLogger.LogErrorToEventLog($"Error to check Is There AnActiveScheduledTest: {ex.Message}");
                    }

                    return Result;
                }
            }
            }
        public static bool DoesAttendTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)

        {


            bool IsFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
            {


                using (SqlCommand command = new SqlCommand("SP_DoesAttendTestType", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                    command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

                    try
                    {
                        connection.Open();

                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            IsFound = true;
                        }
                    }

                    catch (Exception ex)
                    {

                        ErrorLogger.LogErrorToEventLog($"Error Does At tend TestType: {ex.Message}");
                    }


                    return IsFound;

                }
            }
        }


    }
}
