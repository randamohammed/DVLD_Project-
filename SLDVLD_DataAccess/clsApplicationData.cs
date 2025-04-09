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
        public static bool GetApplicationInfoByID(int ApplicationID,ref int ApplicantPersonID,ref DateTime ApplicationDate,
            ref int ApplicationTypeID,ref short ApplicationStatus,ref DateTime LastStatusDate,ref float PaidFees,ref int CreatedByUserID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString);
            string Qurey = "SELECT * from Applications WHERE ApplicationID = @ApplicationID";

            SqlCommand command = new SqlCommand(Qurey, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            bool ISFound =false;

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

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

                reader.Close();
            }
            catch (Exception ex)
            {
                ISFound=false;
            }
            finally
            {
                connection.Close();
            }
            return ISFound;
        }

        public static DataTable GetAllpplications()
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString);
            string Qurey = "SELECT * from Applications order by ApplicationDate";

            SqlCommand command = new SqlCommand(Qurey, connection);

            DataTable dataTable = new DataTable();

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    dataTable.Load(reader);
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
            return dataTable;
        }

        public static int AddNewApplications(int ApplicantPersonID, DateTime ApplicationDate,
             int ApplicationTypeID,  short ApplicationStatus, DateTime LastStatusDate,  float PaidFees, int CreatedByUserID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString);
            string Qurey = @"INSERT INTO Applications (ApplicantPersonID,  ApplicationDate,
              ApplicationTypeID,  ApplicationStatus, LastStatusDate,  PaidFees, CreatedByUserID) 
             Values ( @ApplicantPersonID,  @ApplicationDate,@ApplicationTypeID,  @ApplicationStatus, @LastStatusDate,  @PaidFees, @CreatedByUserID) 
               select SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(Qurey, connection);
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

                if (Add != null && int.TryParse(Add.ToString(),out int CountAdd))
                    {
                    AddNewRow = CountAdd;
                }
            }
            catch(Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return AddNewRow;
        }
  
    
        public static bool UpdateApplication(int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate,
             int ApplicationTypeID, short ApplicationStatus,
             DateTime LastStatusDate, float PaidFees, int CreatedByUserID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString);

            string Qurey = @"Update Applications SET ApplicantPersonID  =@ApplicantPersonID,ApplicationDate =@ApplicationDate,
            ApplicationTypeID =@ApplicationTypeID,ApplicationStatus =@ApplicationStatus,
             LastStatusDate =@LastStatusDate,PaidFees =@PaidFees,CreatedByUserID =@CreatedByUserID
             WHERE ApplicationID =@ApplicationID";

            SqlCommand command = new SqlCommand(Qurey, connection);

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
            finally
            {
                connection.Close();
            }
            return RowAffcet > 0;
        }
   
    public static bool DeleteApplication(int ApplicationID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString);
            string Qurey = @"Delete Applications WHERE ApplicationID =@ApplicationID";

            SqlCommand command = new SqlCommand(Qurey, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            int RowAffcet = 0;

            try
            {
                connection.Open();
                RowAffcet = command.ExecuteNonQuery();
            }
            catch(Exception Ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return RowAffcet > 0;
        }

        public static bool ISExsitApplicationExsit(int ApplicationID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString);
            string Qurey = "SELECT Found =1 FROM Applications WHERE ApplicationID =  @ApplicationID";

            SqlCommand command = new SqlCommand(Qurey, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            bool ISFound = false;

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    ISFound = true;
                }
                else
                    ISFound = false;

                reader.Close();
            }
            catch(Exception Ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return ISFound;
        }
  
      public static   int GetActiveApplicationID(int ApplicantPersonID,int ApplicationTypeID)
      {
            int ActiveApplicationID = -1;
            SqlConnection connection = new SqlConnection( clsDataAccessSettings.ConntaionString);
            string Qurey = @"select ActiveApplicationID =  Applications.ApplicantPersonID from Applications
                               Where Applications.ApplicantPersonID = @ApplicantPersonID
                              and Applications.ApplicationTypeID =@ApplicationTypeID;
                               and Applications.ApplicationStatus = 1;";

            SqlCommand command = new SqlCommand(Qurey,connection);
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
            catch(Exception Ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return ActiveApplicationID;
      }

        public static bool DoesPersonHaveActiveApplication(int PersonID, int ApplicationTypeID)
        {
            return (GetActiveApplicationID(PersonID, ApplicationTypeID) != -1);
        }

        public static int GetActiveApplicationIDForLicenseClass(int PersonID,int LicenseClassID,int ApplicionTypeIID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString);
            string Qurey = @"SELECT  Applications.ApplicationID
                          FROM  Applications INNER JOIN
                         LocalDrivingLicenseApplications ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID
                         WHERE Applications.ApplicantPersonID = @ApplicantPersonID AND Applications.ApplicationTypeID = @ApplicationTypeID
                         AND Applications.ApplicationStatus = 1
                         LocalDrivingLicenseApplications.LicenseClassID = @LicenseClassID";

            SqlCommand command = new SqlCommand(Qurey, connection);
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
            finally
            {
                connection.Close();
            }
            return ActiveApplicationID;
        }
   
       public static bool UpdateStatus(int ApplicationID, short NewStatus)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString);

            string Qurey = @"Update Applications set ApplicationStatus = @ApplicationStatus
                             Where ApplicationID =@ApplicationID";

            SqlCommand command = new SqlCommand(Qurey,connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@ApplicationStatus", NewStatus);

            int RowAffect = 0;

            try
            {
                connection.Open();
                RowAffect = command.ExecuteNonQuery();
            }
            catch(Exception Ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return RowAffect >0;
        }
    }
}
