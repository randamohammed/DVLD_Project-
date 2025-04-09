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
            ref int RetakeTestApplicationID, ref int TestTypeID,ref float PaidFees,ref DateTime AppointmentDate)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString);
            string Query = "SELECT * FROM TestAppointments WHERE TestAppointmentID = @TestAppointmentID";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            bool ISFound = false;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
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
                reader.Close();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                connection.Close();
            }
            return ISFound;
        }
  
    
        public static DataTable GetAllTestAppointments()
            {

                DataTable dt = new DataTable();
                SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString);

                 string query = @"select * from TestAppointments_View
                                  order by AppointmentDate Desc";


                SqlCommand command = new SqlCommand(query, connection);

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
                    // Console.WriteLine("Error: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }

                return dt;

            }
        public static DataTable GetApplicationTestAppointmentsPerTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString);
            string Query = @"SELECT TestAppointmentID,AppointmentDate,PaidFees,IsLocked  from  TestAppointments
                           Where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                           AND(TestTypeID = @TestTypeID)";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if(reader.HasRows)
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
        public static bool GetLastTestAppointment( ref int TestAppointmentID, ref int CreatedByUserID, ref bool IsLocked,  int LocalDrivingLicenseApplicationID,
          ref  int RetakeTestApplicationID,  int TestTypeID,ref float PaidFees,ref DateTime AppointmentDate)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString);
            string Query = @"Select  top 1 *from  TestAppointments 
                            WhERE (LocalDrivingLicenseApplicationID= @LocalDrivingLicenseApplicationID ) 
                           AND( TestTypeID = @TestTypeID)
                           order by TestAppointmentID desc";


            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            bool ISFound = false;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
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
                reader.Close();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                connection.Close();
            }
            return ISFound;
        }
        public static int AddNewTestAppointment(int TestTypeID,int RetakeTestApplicationID,int CreatedByUserID,
            int LocalDrivingLicenseApplicationID,DateTime AppointmentDate,bool IsLocked,float PaidFees)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString);
            string Query = @"INSERT INTO TestAppointments (RetakeTestApplicationID,IsLocked,CreatedByUserID,PaidFees,
                                                          AppointmentDate,LocalDrivingLicenseApplicationID,TestTypeID) Values 
                 (@RetakeTestApplicationID,@IsLocked,@CreatedByUserID,@PaidFees,
                  @AppointmentDate,@LocalDrivingLicenseApplicationID,@TestTypeID)
                   select SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(Query,connection);
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

                if (Result != null && int.TryParse(Result.ToString(),out int AddTestAppointment))
                {
                    TestAppointmentID = AddTestAppointment;
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                    connection.Close();
            }
            return TestAppointmentID;
        }


        public static bool UpdateTestAppointment(int TestAppointmentID, int TestTypeID, int RetakeTestApplicationID, int CreatedByUserID,
            int LocalDrivingLicenseApplicationID, DateTime AppointmentDate, bool IsLocked, float PaidFees)

        {
            int RowAffect = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString);
            string Query = @"Update TestAppointments Set TestTypeID  = @TestTypeID,RetakeTestApplicationID = @RetakeTestApplicationID,CreatedByUserID = CreatedByUserID,
                              LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID,AppointmentDate = @AppointmentDate,
                              IsLocked = @IsLocked,PaidFees =@PaidFees
                              WHERE TestAppointmentID = @TestAppointmentID";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            if(RetakeTestApplicationID ==0)
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

            }
            finally
            {
                connection.Close();
            }
            return RowAffect > 0;
        }
      
    public static int GetTestID(int TestAppointmentID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString);
            string Query = "Select TestID From Tests WHERE TestAppointmentID = @TestAppointmentID";

            SqlCommand commmed = new SqlCommand(Query, connection);
            commmed.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

            int TestID = -1;

            try
            {
                connection.Open();
                object Reslut = commmed.ExecuteScalar();

                if (Reslut != null && int.TryParse(Reslut.ToString(), out  int InsertTest))
                {
                    TestID = InsertTest;
                }

            }
            catch (Exception ex)
            {
            }
            finally
            {
                connection.Close();
            }
            return TestID;
        }
    }
}
