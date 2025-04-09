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
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString);
            string Query = @"select top 1* from DetainedLicenses WHERE DetainID = @DetainID order by desc DetainID ";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@DetainID", DetainID);

            bool ISfound = false;

            try
            {

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

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
                reader.Close();

            }
            catch (Exception ex)
            {
                ISfound = false;
            }
            finally
            {
                connection.Close();
            }
            return ISfound;
        }

        public static bool GetDetainedLicenseInfoByLicenseID(int LicenseID,
            ref int DetainID, ref DateTime DetainDate,
            ref float FineFees, ref int CreatedByUserID,
            ref bool IsReleased, ref DateTime ReleaseDate,
            ref int ReleasedByUserID, ref int ReleaseApplicationID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString);

            string query = "SELECT top 1 * FROM DetainedLicenses WHERE LicenseID = @LicenseID order by DetainID desc";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

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

                reader.Close();


            }
            catch (Exception ex)
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static DataTable GetAllDetainedLicenses()
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString);
            string Query = "select * from DetainedLicenses_View";

            SqlCommand command = new SqlCommand(Query, connection);

            DataTable dt = new DataTable();

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

        public static int AddNewDetainedLicense(
               int LicenseID, DateTime DetainDate,
               float FineFees, int CreatedByUserID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString);

            string Query = @"Insert Into DetainedLicenses (LicenseID,DetainDate,FineFees,CreatedByUserID)
                            Values (@LicenseID,@DetainDate,@FineFees,@CreatedByUserID)
                            select SCOPE_IDENTITY()";

            SqlCommand command = new SqlCommand(Query, connection);
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

            }
            finally
            {
                connection.Close();
            }
            return DetainID;
        }

        public static bool UpdateDetainedLicense(int DetainID,
                int LicenseID, DateTime DetainDate,
                float FineFees, int CreatedByUserID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString);
                string Query = @"Update DetainedLicenses Set LicenseID =@LicenseID ,DetainDate = @DetainDate,
                                 FineFees = @FineFees ,CreatedByUserID = @CreatedByUserID 
                                  WHERE DetainID = @DetainID";

            SqlCommand command = new SqlCommand(Query, connection);

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

            }
            finally
            {
                connection.Close();
            }
            return RowAffected > 0;
        }

        public static bool ReleaseDetainedLicense(int DetainID,
                 int ReleasedByUserID, int ReleaseApplicationID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString);
            string Query = @"Update DetainedLicenses Set ReleaseApplicationID =@ReleaseApplicationID,ReleasedByUserID =@ReleasedByUserID,
                             IsReleased = 1,ReleaseDate = @ReleaseDate  
                             WHERE DetainID  =@DetainID";

            SqlCommand command = new SqlCommand(Query, connection);
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

            }
            finally
            {
                connection.Close();
            }
            return RowAffected > 0;
        }

        public static bool IsLicenseDetained(int LicenseID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString);
            string Query = @"select IsDetained = 1 from DetainedLicenses 
                 Where LicenseID  = @LicenseID And IsReleased =0";

            SqlCommand command = new SqlCommand(Query,connection);
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
            }
            finally
            {
                connection.Close();
            }
            return IsDetained;
        }
    }
}
