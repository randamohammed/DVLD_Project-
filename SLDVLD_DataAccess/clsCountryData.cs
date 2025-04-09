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
        public static DataTable GetAllCountries()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString);
            string Qurey = "Select *from Countries order by CountryName";
            SqlCommand command = new SqlCommand(Qurey, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                    dt.Load(reader);

                reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return dt;  

        }

        public static bool FindCountryByID(int CountryID   ,ref string CountryName)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString);
            string Qurey = "select * from Countries Where CountryID =@CountryID";
            SqlCommand command = new SqlCommand(Qurey , connection);

            command.Parameters.AddWithValue("@CountryID", CountryID);

            bool ISFound =false;

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    ISFound = true;
                    CountryName = (string)reader["CountryName"];
                }
                else
                    ISFound = false;

                reader.Close();
            }
            catch(Exception ex) 
            {
                ISFound = false;

            }
            finally
            {
                connection.Close();
            }
            return ISFound;
        }

        public static bool FindCountryByNam(string CountryName,ref int CountryID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString);
            string Qurey = "select * from Countries Where CountryName =@CountryName";
            SqlCommand command = new SqlCommand(Qurey, connection);

            command.Parameters.AddWithValue("@CountryName", CountryName);

            bool ISFound = false;

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    ISFound = true;
                    CountryID = (int)reader["CountryID"];
                }
                else
                    ISFound = false;

                reader.Close();
            }
            catch (Exception ex)
            {
                ISFound = false;

            }
            finally
            {
                connection.Close();
            }
            return ISFound;
        }

    }
}
