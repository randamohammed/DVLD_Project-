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
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString);
            string Query = "SELECT * FROM LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID =@LocalDrivingLicenseApplicationID";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            bool ISFound = false;

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    ISFound = true;
                    ApplicationID = (int)reader["ApplicationID"];
                    LicenseClassID = (int)reader["LicenseClassID"];
                }
                else
                    ISFound = false;

                reader.Close();
            }
            catch (Exception ex)
            {
                ISFound |= false;
            }
            finally
            {
                connection.Close();
            }
            return ISFound;
        }

        public static bool GetLocalDrivingLicenseApplicationInfoByApplicationID(int LocalDrivingLicenseApplicationID, ref int ApplicationID, ref int LicenseClassID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString);
            string Query = "SELECT * FROM LocalDrivingLicenseApplications WHERE ApplicationID =@ApplicationID";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            bool ISFound = false;

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    ISFound = true;
                    LocalDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                    LicenseClassID = (int)reader["LicenseClassID"];
                }
                else
                    ISFound = false;

                reader.Close();
            }
            catch (Exception ex)
            {
                ISFound |= false;
            }
            finally
            {
                connection.Close();
            }
            return ISFound;
        }

        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString);
            string Query = "SELECT  * FROM LocalDrivingLicenseApplications_View   order by ApplicationDate Desc";

            SqlCommand command = new SqlCommand(Query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
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

        public static int AddNewLocalDrivingLicenseApplication(int ApplicationID, int LicenseClassID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString);
            string Query = @"INSERT INTO LocalDrivingLicenseApplications (ApplicationID,LicenseClassID)
                              Values (@ApplicationID,@LicenseClassID) 
                              Select SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(Query, connection);

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

            }
            finally
            {
                connection.Close();
            }
            return LocalDrivingLicenseApplications;
        }

        public static bool UpdateLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID, int ApplicationID, int LicenseClassID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString);
            string Query = @"Update LocalDrivingLicenseApplications set LicenseClassID =@LicenseClassID ,ApplicationID = @ApplicationID
                            WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            SqlCommand command = new SqlCommand(Query, connection);
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

            }
            finally
            {
                connection.Close();
            }
            return RowAffected > 0;
        }

        public static bool DeleteLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString);
            string Query = @"DELETE LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

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

        public static bool DoesPassTestType(int LocalDrivingLicenseApplicationID, int TestType)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString);
            string Query = @"SELECT  Reslut =1 FROM    LocalDrivingLicenseApplications INNER JOIN
                             TestAppointments AS TestAppointments ON
                             LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID INNER JOIN
                             Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID Where 
                              TestAppointments.TestTypeID =@TestType and LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID =@LocalDrivingLicenseApplicationID and Tests.TestResult =1;";

            SqlCommand command = new SqlCommand(Query, connection);
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

            }
            finally
            {
                connection.Close();
            }
            return PassTestType > 0;
        }

        public static byte TotalTrialsPerTest(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString);
            string Qurey = @"SELECT  TotalTrialsPerTest = count(TestID) 
                             FROM    LocalDrivingLicenseApplications INNER JOIN
                             TestAppointments ON
                             LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID INNER JOIN
                             Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID 
                              Where (TestAppointments.TestTypeID =@TestTypeID)
                              AND (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID =@LocalDrivingLicenseApplicationID)";

            SqlCommand command = new SqlCommand(Qurey, connection);

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

            }
            finally
            {
                connection.Close();
            }

            return TotalTrialsPerTest;
        }

        public static bool IsThereAnActiveScheduledTest(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString);
            string Query = @"SELECT top 1 Found = 1 FROM  LocalDrivingLicenseApplications INNER JOIN
                           TestAppointments ON
                           LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID 
                           WHERE( TestAppointments.TestTypeID = @TestTypeID)
                           AND(LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID =@LocalDrivingLicenseApplicationID)
                          AND(TestAppointments.IsLocked = 0) order by  TestAppointments.TestAppointmentID desc";


            SqlCommand command = new SqlCommand(Query, connection);
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

            }
            finally
            {
                connection.Close();
            }
            return Result;
        }


        public static bool DoesAttendTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)

        {


            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString);

            string query = @" SELECT top 1 Found=1
                            FROM LocalDrivingLicenseApplications INNER JOIN
                                 TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID INNER JOIN
                                 Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                            WHERE
                            (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID) 
                            AND(TestAppointments.TestTypeID = @TestTypeID)
                            ORDER BY TestAppointments.TestAppointmentID desc";

            SqlCommand command = new SqlCommand(query, connection);

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
                //Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }

            return IsFound;

        }
    


    }
}
