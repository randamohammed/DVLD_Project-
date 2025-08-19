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
    public class clsTestAppointmentData
    {
        public static bool GetTestAppointmentInfoByID(int TestAppointmentID, ref int CreatedByUserID, ref bool IsLocked, ref int LocalDrivingLicenseApplicationID,
            ref int RetakeTestApplicationID, ref int TestTypeID, ref float PaidFees, ref DateTime AppointmentDate)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
            {
                using (SqlCommand command = new SqlCommand("SP_GetTestAppointmentInfoByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
                    bool ISFound = false;
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                ISFound = true;
                                CreatedByUserID = (int)reader["CreatedByUserID"];
                                IsLocked = (bool)reader["IsLocked"];
                                LocalDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];

                                if (reader["RetakeTestApplicationID"] == System.DBNull.Value)
                                    RetakeTestApplicationID = 0;
                                else
                                    RetakeTestApplicationID = (int)reader["RetakeTestApplicationID"];
                                TestTypeID = (int)reader["TestTypeID"];
                                PaidFees = Convert.ToSingle(reader["PaidFees"]);
                            }
                            else
                                ISFound = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Feild to get Info " + ex.ToString());
                    }

                    return ISFound;
                }
            }
        }

        public static DataTable GetAllTestAppointments()
        {

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
            {
                using (SqlCommand command = new SqlCommand("SP_GetAllTestAppointments", connection))
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
                        Console.WriteLine("Error: " + ex.Message);
                    }

                    return dt;
                }
            }
        }
        public static async Task<DataTable> GetApplicationTestAppointmentsPerTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            return await Task.Run(() =>
            {
                DataTable dt = new DataTable();
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_GetAppTestAppointmentsPerTestType", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                        command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
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
                            Console.WriteLine($"Feiled get the Information  {ex.Message}");
                        }

                        return dt;
                    }

                }
            });
        }
        public static bool GetLastTestAppointment(ref int TestAppointmentID, ref int CreatedByUserID, ref bool IsLocked, int LocalDrivingLicenseApplicationID,
          ref int RetakeTestApplicationID, int TestTypeID, ref float PaidFees, ref DateTime AppointmentDate)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
            {
                using (SqlCommand command = new SqlCommand("SP_GetLastTestAppointment", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                    command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

                    bool ISFound = false;
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                ISFound = true;
                                CreatedByUserID = (int)reader["CreatedByUserID"];
                                TestAppointmentID = (int)reader["TestAppointmentID"];
                                IsLocked = (bool)reader["IsLocked"];
                                RetakeTestApplicationID = (int)reader["RetakeTestApplicationID"];
                                PaidFees = Convert.ToSingle(reader["PaidFees"]);
                            }
                            else
                                ISFound = false;
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                    return ISFound;
                }
            }
        }
        public static int AddNewTestAppointment(int TestTypeID, int RetakeTestApplicationID, int CreatedByUserID,
            int LocalDrivingLicenseApplicationID, DateTime AppointmentDate, bool IsLocked, float PaidFees)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
            {

                using (SqlCommand command = new SqlCommand("SP_AddNewTestAppointment", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

                    if (RetakeTestApplicationID == -1)
                        command.Parameters.AddWithValue("@RetakeTestApplicationID", System.DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                    command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
                    command.Parameters.AddWithValue("@IsLocked", IsLocked);
                    command.Parameters.AddWithValue("@PaidFees", PaidFees);

                    int TestAppointmentID = -1;
                    try
                    {
                        connection.Open();
                        object Result = command.ExecuteScalar();

                        if (Result != null && int.TryParse(Result.ToString(), out int AddTestAppointment))
                        {
                            TestAppointmentID = AddTestAppointment;
                        }

                    }
                    catch (Exception ex)
                    {

                    }

                    return TestAppointmentID;
                }
            }
        }

        public static bool UpdateTestAppointment(int TestAppointmentID, int TestTypeID, int RetakeTestApplicationID, int CreatedByUserID,
            int LocalDrivingLicenseApplicationID, DateTime AppointmentDate, bool IsLocked, float PaidFees)

        {
            int RowAffect = 0;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
            {


                using (SqlCommand command = new SqlCommand("SP_UpdateTestAppointment", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
                    command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

                    if (RetakeTestApplicationID == 0)
                        command.Parameters.AddWithValue("@RetakeTestApplicationID", System.DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                    command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
                    command.Parameters.AddWithValue("@IsLocked", IsLocked);
                    command.Parameters.AddWithValue("@PaidFees", PaidFees);



                    try
                    {
                        connection.Open();
                        RowAffect = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("feiled not update " + ex.ToString());
                    }
                    return RowAffect > 0;
                }
            }
        }

        public static int GetTestID(int TestAppointmentID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
            {
                using (SqlCommand commmed = new SqlCommand("SP_GetTestID", connection))
                {
                    commmed.CommandType = CommandType.StoredProcedure;
                    commmed.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

                    int TestID = -1;

                    try
                    {
                        connection.Open();
                        object Reslut = commmed.ExecuteScalar();

                        if (Reslut != null && int.TryParse(Reslut.ToString(), out int InsertTest))
                        {
                            TestID = InsertTest;
                        }

                    }
                    catch (Exception ex)
                    {
                    }

                    return TestID;
                }
            }
        }
    }
}
