using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLDVLD_DataAccess
{
    public class clsInternationalLicenseData
    {
        public static bool GetInternationalLicenseInfoByID(int InternationalLicenseID,
           ref int ApplicationID,
           ref int DriverID, ref int IssuedUsingLocalLicenseID,
           ref DateTime IssueDate, ref DateTime ExpirationDate, ref bool IsActive, ref int CreatedByUserID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
            {
                using (SqlCommand command = new SqlCommand("SP_GetInternationalLicenseInfoByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);

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
                                DriverID = (int)reader["DriverID"];
                                IssuedUsingLocalLicenseID = (int)reader["IssuedUsingLocalLicenseID"];
                                IssueDate = (DateTime)reader["IssueDate"];
                                ExpirationDate = (DateTime)reader["ExpirationDate"];
                                IsActive = (bool)reader["IsActive"];
                                CreatedByUserID = (int)reader["CreatedByUserID"];

                            }
                            else
                                ISFound = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        ISFound = false;
                    }

                    return ISFound;
                }
            }
        }

        public static async Task< DataTable> GetAllInternationalLicenses()
        {
            return await Task.Run(() => {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
            {
                using (SqlCommand command = new SqlCommand("SP_GetAllInternationalLicenses", connection))
                {
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
       
        public static int AddNewInternationalLicense(int ApplicationID,
            int DriverID, int IssuedUsingLocalLicenseID,
            DateTime IssueDate, DateTime ExpirationDate, bool IsActive, int CreatedByUserID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
            {
                using (SqlCommand command = new SqlCommand("SP_AddedNewInternationalLicense", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    command.Parameters.AddWithValue("@DriverID", DriverID);
                    command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);
                    command.Parameters.AddWithValue("@IssueDate", IssueDate);
                    command.Parameters.AddWithValue("@IsActive", IsActive);
                    command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                    int InternationalLicenseID = -1;

                    try
                    {
                        connection.Open();
                        object Reslut = command.ExecuteScalar();

                        if (Reslut != null && int.TryParse(Reslut.ToString(), out int InsertID))
                        {
                            InternationalLicenseID = InsertID;
                        }

                    }
                    catch (Exception ex)
                    {

                    }

                    return InternationalLicenseID;
                }
            }
        }
        public static bool UpdateInternationalLicense(
            int InternationalLicenseID, int ApplicationID,
           int DriverID, int IssuedUsingLocalLicenseID,
           DateTime IssueDate, DateTime ExpirationDate, bool IsActive, int CreatedByUserID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
            {
                using (SqlCommand command = new SqlCommand("SP_UpdateInternationalLicense", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    command.Parameters.AddWithValue("@DriverID", DriverID);
                    command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);
                    command.Parameters.AddWithValue("@IssueDate", IssueDate);
                    command.Parameters.AddWithValue("@IsActive", IsActive);
                    command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                    command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);

                    int RowAffecteds = 0;

                    try
                    {
                        connection.Open();
                        RowAffecteds = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {

                    }

                    return RowAffecteds > 0;
                }
            }
        }
        public static int GetActiveInternationalLicenseIDByDriverID(int DriverID)
        {
            int InternationalLicenseID = -1;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
            {

                using (SqlCommand command = new SqlCommand("SP_GetActiveInternationalLicenseIDByDriverID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@DriverID", DriverID);

                    try
                    {
                        connection.Open();

                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            InternationalLicenseID = insertedID;
                        }
                    }

                    catch (Exception ex)
                    {

                    }



                    return InternationalLicenseID;
                }
            }
        }
    }
}
