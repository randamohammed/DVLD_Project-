using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLDVLD_DataAccess
{
    public class clsLicenesData
    {
        public static bool GetLicenseInfoByID(int LicenseID,ref int ApplicationID,ref int DriverID,ref int LicenseClass,
          ref  int CreatedByUserID,ref string Notes,ref byte IssueReason,ref DateTime ExpirationDate,
            ref bool IsActive,ref float PaidFees,ref DateTime IssueDate)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString);
            string Query = @"Select * from Licenses WHERE LicenseID =@LicenseID";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            bool ISFound = false;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    ISFound = true;
                    ApplicationID = (int)reader["ApplicationID"];
                    //LicenseID = (int)reader["LicenseID"];
                    DriverID = (int)reader["DriverID"];
                    LicenseClass = (int)reader["LicenseClass"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];

                    if (reader["Notes"] == System.DBNull.Value)
                        Notes = "";
                    else
                        Notes = (string)reader["Notes"];

                    IssueReason = (byte)reader["IssueReason"];
                    ExpirationDate = Convert.ToDateTime(reader["ExpirationDate"]);
                    IssueDate = Convert.ToDateTime(reader["IssueDate"]);
                    IsActive = (bool)reader["IsActive"];
                    PaidFees = Convert.ToSingle(reader["PaidFees"]);



                }
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

        public static DataTable GetAllLicenses()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString);
            string Query = @"Select * from Licenses";

            SqlCommand command = new SqlCommand(Query, connection);

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
 
       public static DataTable GetDriverLicenses(int DriverID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString);
            string Query = @"SELECT  Licenses.LicenseID,
                           ApplicationID,
		                   LicenseClasses.ClassName, Licenses.IssueDate, 
		                   Licenses.ExpirationDate, Licenses.IsActive
                           FROM Licenses INNER JOIN
                                LicenseClasses ON Licenses.LicenseClass = LicenseClasses.LicenseClassID
                            where DriverID=@DriverID
                            Order By IsActive Desc, ExpirationDate Desc";

            SqlCommand command = new SqlCommand(Query,connection);
            command.Parameters.AddWithValue("@DriverID", DriverID);


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
  
      public static int AddNewLicense( int ApplicationID, int DriverID, int LicenseClass,
            int CreatedByUserID, string Notes, byte IssueReason, DateTime ExpirationDate,
            bool IsActive, float PaidFees, DateTime IssueDate)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString);
            string Query = @" INSERT INTO Licenses (ApplicationID,  DriverID,  LicenseClass,
             CreatedByUserID,  Notes, IssueReason,  ExpirationDate,
            IsActive,  PaidFees,  IssueDate)
             Values (@ApplicationID,@DriverID,@LicenseClass,
             @CreatedByUserID,  @Notes, @IssueReason, @ExpirationDate,
            @IsActive,  @PaidFees,  @IssueDate)  

              select SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@LicenseClass", LicenseClass);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            if(Notes  == "")
               command.Parameters.AddWithValue("@Notes", System.DBNull.Value);
            else   
            command.Parameters.AddWithValue("@Notes", Notes);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@IssueReason", IssueReason);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);

            int LicenesID = -1;

            try
            {
                connection.Open();
                object Reslut = command.ExecuteScalar();

                if (Reslut != null && int.TryParse(Reslut.ToString(), out int InsertId))
                {
                    LicenesID = InsertId;
                }

            }
            catch (Exception ex)
            {
            }
            finally
            {
                connection.Close();
            }
            return LicenesID;
        }


        public static bool UdateLicenes(int LicenseID, int ApplicationID, int DriverID, int LicenseClass,
              int CreatedByUserID, string Notes, byte IssueReason, DateTime ExpirationDate,
              bool IsActive, float PaidFees, DateTime IssueDate)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString);
            string Query = @" Update Licenses Set ApplicationID = @ApplicationID,  DriverID =@DriverID,  LicenseClass =@LicenseClass,
             CreatedByUserID = @CreatedByUserID,  Notes = @Notes, IssueReason = @IssueReason,  ExpirationDate =@ExpirationDate,
            IsActive = @IsActive,  PaidFees =@PaidFees,  IssueDate =@IssueDate
              WHERE LicenseID =@LicenseID";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@LicenseClass", LicenseClass);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            if (Notes == "")
                command.Parameters.AddWithValue("@Notes", System.DBNull.Value);
            else
                command.Parameters.AddWithValue("@Notes", Notes);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@IssueReason", IssueReason);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);

            int RowAffect = 0;

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
            return RowAffect >0;
        }

        public static int GetActiveLicenseIDByPersonID(int PersonID,int LicenseClassID)
        {
            SqlConnection connection =  new SqlConnection(clsDataAccessSettings.ConntaionString);
            string Query = @"SELECT   Licenses.LicenseID
                                FROM            Licenses INNER JOIN
                                                         Drivers ON Licenses.DriverID = Drivers.DriverID
                                WHERE        (Licenses.LicenseClass = @LicenseClass)
                                AND(Drivers.PersonID = @PersonID)
                                AND(IsActive = 1)"
            ;


            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@LicenseClass", LicenseClassID);

            int LicenseID = -1;
            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    LicenseID = insertedID;
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


            return LicenseID;

        }

        public static bool DeactivateLicense(int LicenseID)
        {
        SqlConnection connection =new SqlConnection(clsDataAccessSettings.ConntaionString);

            string Query = @"update Licenses 
                                 set IsActive = 0
                                 WHERE LicenseID = @LicenseID";

             SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);


            int RowAffect = 0;

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
    }
}