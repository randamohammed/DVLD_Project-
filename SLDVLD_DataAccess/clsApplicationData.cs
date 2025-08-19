using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace SLDVLD_DataAccess
{
    public class clsApplicationData
    {
        public static bool GetApplicationInfoByID(int ApplicationID, ref int ApplicantPersonID, ref DateTime ApplicationDate,
            ref int ApplicationTypeID, ref short ApplicationStatus, ref DateTime LastStatusDate, ref float PaidFees, ref int CreatedByUserID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
            {
                using (SqlCommand command = new SqlCommand("SP_GetApplicationInfoByID", connection))
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
                                ApplicantPersonID = (int)reader["ApplicantPersonID"];
                                PaidFees = Convert.ToInt32(reader["PaidFees"]);
                                CreatedByUserID = (int)reader["CreatedByUserID"];
                                ApplicationDate = Convert.ToDateTime(reader["ApplicationDate"]);
                                LastStatusDate = Convert.ToDateTime(reader["LastStatusDate"]);
                                ApplicationTypeID = (int)reader["ApplicationTypeID"];
                                ApplicationStatus = Convert.ToInt16(reader["ApplicationStatus"]);
                                PaidFees = Convert.ToSingle(reader["PaidFees"]);
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
        public static async Task<DataTable> GetAllpplications()
        {
            return await Task.Run(() =>
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_GetAllpplications", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        DataTable dataTable = new DataTable();
                        try
                        {
                            connection.Open();
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    dataTable.Load(reader);
                                }
                            }
                        }
                        catch (Exception ex)
                        {

                        }

                        return dataTable;
                    }
                }
            });
        }
        public static int AddNewApplications(int ApplicantPersonID, DateTime ApplicationDate,
             int ApplicationTypeID, short ApplicationStatus, DateTime LastStatusDate, float PaidFees, int CreatedByUserID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
            {

                using (SqlCommand command = new SqlCommand("SP_AddNewApplications", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
                    command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
                    command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
                    command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
                    command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
                    command.Parameters.AddWithValue("@PaidFees", PaidFees);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                    int AddNewRow = -1;

                    try
                    {
                        connection.Open();
                        object Add = command.ExecuteScalar();

                        if (Add != null && int.TryParse(Add.ToString(), out int CountAdd))
                        {
                            AddNewRow = CountAdd;
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    return AddNewRow;
                }
            }
        }
        public static bool UpdateApplication(int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate,
             int ApplicationTypeID, short ApplicationStatus,
             DateTime LastStatusDate, float PaidFees, int CreatedByUserID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
            {

                using (SqlCommand command = new SqlCommand("SP_UpdateApplication", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
                    command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
                    command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
                    command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
                    command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
                    command.Parameters.AddWithValue("@PaidFees", PaidFees);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                    int RowAffcet = 0;

                    try
                    {
                        connection.Open();

                        RowAffcet = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {

                    }

                    return RowAffcet > 0;
                }
            }
        }
        public static bool DeleteApplication(int ApplicationID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
            {
                using (SqlCommand command = new SqlCommand("SP_DeleteApplication", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

                    int RowAffcet = 0;

                    try
                    {
                        connection.Open();
                        RowAffcet = command.ExecuteNonQuery();
                    }
                    catch (Exception Ex)
                    {

                    }

                    return RowAffcet > 0;
                }
            }
        }
        public static bool ISExsitApplicationExsit(int ApplicationID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
            {
                using (SqlCommand command = new SqlCommand("SP_ISExsitApplicationExsit", connection))
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
                            }
                            else
                                ISFound = false;
                        }
                    }
                    catch (Exception Ex)
                    {

                    }

                    return ISFound;
                }
            }
        }
        public static int GetActiveApplicationID(int ApplicantPersonID, int ApplicationTypeID)
        {
            int ActiveApplicationID = -1;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
            {
                using (SqlCommand command = new SqlCommand("SP_GetActiveApplicationID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
                    command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

                    bool ISFound = false;

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();


                        if (result != null && int.TryParse(result.ToString(), out int AppID))
                        {
                            ActiveApplicationID = AppID;
                        }
                    }
                    catch (Exception Ex)
                    {

                    }
                    return ActiveApplicationID;
                }
            }
        }
        public static bool DoesPersonHaveActiveApplication(int PersonID, int ApplicationTypeID)
        {
            return (GetActiveApplicationID(PersonID, ApplicationTypeID) != -1);
        }

        public static int GetActiveApplicationIDForLicenseClass(int PersonID, int LicenseClassID, int ApplicionTypeIID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
            {
                using (SqlCommand command = new SqlCommand("SP_ISPersonHaveActiveApplication", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
                    command.Parameters.AddWithValue("@ApplicantPersonID", PersonID);
                    command.Parameters.AddWithValue("@ApplicationTypeID", ApplicionTypeIID);

                    int ActiveApplicationID = -1;

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();


                        if (result != null && int.TryParse(result.ToString(), out int AppID))
                        {
                            ActiveApplicationID = AppID;
                        }

                    }
                    catch (Exception Ex)
                    {

                    }
                    return ActiveApplicationID;
                }
            }
        }
        public static bool UpdateStatus(int ApplicationID, short NewStatus)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
            {

                using (SqlCommand command = new SqlCommand("SP_UpdateStatus", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    command.Parameters.AddWithValue("@ApplicationStatus", NewStatus);

                    int RowAffect = 0;

                    try
                    {
                        connection.Open();
                        RowAffect = command.ExecuteNonQuery();
                    }
                    catch (Exception Ex)
                    {

                    }
                    return RowAffect > 0;
                }
            }
        }
    }
}
