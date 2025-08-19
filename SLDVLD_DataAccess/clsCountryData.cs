using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SLDVLD_DataAccess
{
    public class clsCountryData
    {
        public static async Task< DataTable> GetAllCountries()
        {
            return  await Task.Run(() =>
            {
                DataTable dt = new DataTable();

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_GetAllCountries", connection))
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

                        }

                        return dt;
                    }
                }
            });
        }
    


        public static bool FindCountryByID(int CountryID   ,ref string CountryName)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
            {
                using (SqlCommand command = new SqlCommand("SP_FindCountryByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CountryID", CountryID);

                    bool ISFound = false;

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                ISFound = true;
                                CountryName = (string)reader["CountryName"];
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
        public static bool FindCountryByNam(string CountryName, ref int CountryID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
            {
                using (SqlCommand command = new SqlCommand("SP_FindCountryByNam", connection))
                {
                    command.CommandType  = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CountryName", CountryName);

                    bool ISFound = false;

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                ISFound = true;
                                CountryID = (int)reader["CountryID"];
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
    }
}
