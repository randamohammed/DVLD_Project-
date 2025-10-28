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
    public class clsLicenseClassesData
    {
        public static bool GetLicenseClassInfoByID(int LicenseClassID, ref byte DefaultValidityLength, ref byte MinimumAllowedAge,
            ref float ClassFees, ref string ClassName, ref string ClassDescription)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
            {

                using (SqlCommand command = new SqlCommand("SP_GetLicenseClassInfoByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

                    bool ISFound = false;

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                ISFound = true;
                                DefaultValidityLength = (byte)reader["DefaultValidityLength"];
                                MinimumAllowedAge = (byte)reader["MinimumAllowedAge"];
                                ClassDescription = (string)reader["ClassDescription"];
                                ClassFees = Convert.ToSingle(reader["ClassFees"]);
                                ClassName = (string)reader["ClassName"];

                            }
                            else
                                ISFound = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        ISFound = false;

                        ErrorLogger.LogErrorToEventLog($"Error Get License ClassInfoBy ID: {ex.Message}");
                    }

                    return ISFound;
                }
            }
        }
        public static bool GetLicenseClassInfoByClassName(ref int LicenseClassID, ref byte DefaultValidityLength, ref byte MinimumAllowedAge,
              ref float ClassFees, string ClassName, ref string ClassDescription)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
            {

                using (SqlCommand command = new SqlCommand("SP_GetLicenseClassInfoByClassName", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ClassName", ClassName);

                    bool ISFound = false;

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                ISFound = true;
                                DefaultValidityLength = (byte)reader["DefaultValidityLength"];
                                MinimumAllowedAge = (byte)reader["MinimumAllowedAge"];
                                ClassDescription = (string)reader["ClassDescription"];
                                ClassFees = Convert.ToSingle(reader["ClassFees"]);
                                LicenseClassID = (int)reader["LicenseClassID"];

                            }
                            else
                                ISFound = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        ISFound = false;

                        ErrorLogger.LogErrorToEventLog($"Error Get License ClassInfo By ClassName: {ex.Message}");
                    }

                    return ISFound;
                }
            }
        }
        public static async Task< DataTable> GetAllLicenseClasses()
        {
            return await Task.Run(() =>
            {
                DataTable table = new DataTable();
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_GetAllLicenseClasses", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        try
                        {
                            connection.Open();
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    table.Load(reader);
                                }
                            }
                        }
                        catch (Exception ex)
                        {

                            ErrorLogger.LogErrorToEventLog($"Error Get All LicenseClasses: {ex.Message}");
                        }

                        return table;

                    }
                }
            });
        }

        public static int AddNewLicenseClass(string ClassName, string ClassDescription,
                byte MinimumAllowedAge, byte DefaultValidityLength, float ClassFees)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
            {

                using (SqlCommand command = new SqlCommand("SP_AddNewLicenseClass", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ClassFees", ClassFees);
                    command.Parameters.AddWithValue("@DefaultValidityLength", DefaultValidityLength);
                    command.Parameters.AddWithValue("@MinimumAllowedAge", MinimumAllowedAge);
                    command.Parameters.AddWithValue("@ClassDescription", ClassDescription);
                    command.Parameters.AddWithValue("@ClassName", ClassName);

                    int AddLicenseClassID = -1;

                    try
                    {
                        connection.Open();
                        object Reslut = command.ExecuteScalar();

                        if (Reslut != null && int.TryParse(Reslut.ToString(), out int LicenseClassID))
                        {
                            AddLicenseClassID = LicenseClassID;
                        }
                    }
                    catch (Exception ex)
                    {

                        ErrorLogger.LogErrorToEventLog($"Error AddNew LicenseClass: {ex.Message}");
                    }

                    return AddLicenseClassID;
                }
            }
        }
        public static bool UpdateLicenseClass(int LicenseClassID, string ClassName, string ClassDescription,
           byte MinimumAllowedAge, byte DefaultValidityLength, float ClassFees)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
            {

                using (SqlCommand command = new SqlCommand("SP_UpdateLicenseClass", connection))

                {

                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ClassFees", ClassFees);
                    command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
                    command.Parameters.AddWithValue("@DefaultValidityLength", DefaultValidityLength);
                    command.Parameters.AddWithValue("@MinimumAllowedAge", MinimumAllowedAge);
                    command.Parameters.AddWithValue("@ClassDescription", ClassDescription);
                    command.Parameters.AddWithValue("@ClassName", ClassName);

                    int RowAffect = 0;

                    try
                    {
                        connection.Open();
                        RowAffect = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {

                        ErrorLogger.LogErrorToEventLog($"Error Update LicenseClass: {ex.Message}");
                    }
                    return RowAffect > 0;
                }
            }
        }

    }
}
