using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SLDVLD_DataAccess
{
    public class clsPersonData
    {
        public static int AddNewPerson(string NationalNo,string FirstName,string SecondName,string ThirdName,string LastName,DateTime DateOfBirth,
            string ImagePath,string Email ,string Address,string Phone,int NationalityCountryID,short Gendor)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString);

            string Qurey = @"INSERT INTO People (NationalNo,FirstName, SecondName, ThirdName, LastName, DateOfBirth,
             ImagePath, Email , Address ,Phone, NationalityCountryID, Gendor)  

             VALUES (@NationalNo, @FirstName, @SecondName, @ThirdName, @LastName, @DateOfBirth,
             @ImagePath, @Email , @Address ,@Phone, @NationalityCountryID, @Gendor)

            select SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(Qurey, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
            command.Parameters.AddWithValue("@Gendor", Gendor);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);

            if (ThirdName != "")
                command.Parameters.AddWithValue("@ThirdName", ThirdName);
            else
                command.Parameters.AddWithValue("@ThirdName", System.DBNull.Value);

            if (ImagePath != "")
               command.Parameters.AddWithValue("@ImagePath", ImagePath);
            else
                command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);
            if(Email != "")
                command.Parameters.AddWithValue("@Email", Email);
            else
                command.Parameters.AddWithValue("@Email", System.DBNull.Value);

            int PresonID = -1;
            try
            {
                connection.Open();
                object Addeing = command.ExecuteScalar();

                if (Addeing != null && int.TryParse(Addeing.ToString(), out int Add))
                    PresonID = Add;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close(); 
            }
            return PresonID;
        }

        public static bool Update(int PersonID ,string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName, DateTime DateOfBirth,
            string ImagePath, string Email, string Address, string Phone, int NationalityCountryID, short Gendor)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString);
            string Quurey = @"Update People Set NationalNo =@NationalNo,FirstName=@FirstName,SecondName=@SecondName, ThirdName = @ThirdName,LastName = @LastName,
                            DateOfBirth =@DateOfBirth, ImagePath = @ImagePath, Email = @Email ,Address = @Address,
                            Phone = @Phone,NationalityCountryID = @NationalityCountryID,Gendor = @Gendor Where PersonID =@PersonID";
           
            SqlCommand command = new SqlCommand(Quurey,connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
            command.Parameters.AddWithValue("@Gendor", Gendor);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            if (LastName != "")
                command.Parameters.AddWithValue("@ThirdName", ThirdName);
            else
                command.Parameters.AddWithValue("@ThirdName", System.DBNull.Value);

            if (ImagePath != "")
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            else
                command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);
            if (Email != "")
                command.Parameters.AddWithValue("@Email", Email);
            else
                command.Parameters.AddWithValue("@Email", System.DBNull.Value);

            int rowffected = 0;
            try
            {
                connection.Open();

                 rowffected = command.ExecuteNonQuery(); 

            }
            catch(Exception ex) 
            {

            }
            finally
            { 
                connection.Close(); 
            }
            return rowffected > 0;
        }

        public static bool FindPersonByID(int PersonID,ref string NationalNo,ref string FirstName,ref string SecondName,ref string ThirdName,ref string LastName,ref DateTime DateOfBirth,
          ref  string ImagePath,ref string Email,ref string Address,ref string Phone,ref int NationalityCountryID,ref short Gendor)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString);
            string Qurey = "Select * from People Where PersonID =@PersonID";

            SqlCommand command = new SqlCommand(Qurey, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            bool ISFound = false;

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if(reader.Read())
                {
                    ISFound = true;
                    NationalNo = (string)reader["NationalNo"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];
                    Address = (string)reader["Address"];
                    LastName = (string)reader["LastName"];
                    Phone = (string)reader["Phone"];
                    DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                    NationalityCountryID = (int)reader["NationalityCountryID"];
                    Gendor = Convert.ToInt16(reader["Gendor"]);

                    if (reader["ImagePath"] != System.DBNull.Value)
                        ImagePath = (string)reader["ImagePath"];
                    else
                        ImagePath = "";


                    if (reader["Email"] != System.DBNull.Value)
                        Email = (string)reader["Email"];
                    else
                        Email = "";


                    if (reader["ThirdName"] != System.DBNull.Value)
                        ThirdName = (string)reader["ThirdName"];
                    else
                        ThirdName = "";
                }
                else
                {
                    ISFound = false;
                }
                reader.Close();
            }
            catch(Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return ISFound;
        }


        public static bool FindPersonByNationalNo(string NationalNo,ref int PersonID, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName, ref DateTime DateOfBirth,
          ref string ImagePath, ref string Email, ref string Address, ref string Phone, ref int NationalityCountryID, ref short Gendor)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString);
            string Qurey = "Select * from People Where NationalNo =@NationalNo";

            SqlCommand command = new SqlCommand(Qurey, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);

            bool ISFound = false;

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    ISFound = true;
                    PersonID = (int)reader["PersonID"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];
                    Address = (string)reader["Address"];
                    LastName = (string)reader["LastName"];
                    Phone = (string)reader["Phone"];
                    DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                    NationalityCountryID = (int)reader["NationalityCountryID"];
                    Gendor = Convert.ToInt16(reader["Gendor"]);

                    if (reader["ImagePath"] != System.DBNull.Value)
                        ImagePath = (string)reader["ImagePath"];
                    else
                        ImagePath = "";


                    if (reader["Email"] != System.DBNull.Value)
                        Email = (string)reader["Email"];
                    else
                        Email = "";


                    if (reader["ThirdName"] != System.DBNull.Value)
                        ThirdName = (string)reader["ThirdName"];
                    else
                        ThirdName = "";
                }
                else
                {
                    ISFound = false;
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
            return ISFound;
        }

        public static bool ISPersonExist(int PersonID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString);
            string Qurrey = "select Found =1 from Phone where PersonID = @PersonID";
            SqlCommand command = new SqlCommand(Qurrey, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            bool ISFound = false;

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                    ISFound = reader.HasRows;

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


        public static bool IsPersonExist(string NationalNo)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString);
            string Qurrey = "select Found =1 from Phone where NationalNo = @NationalNo";
            SqlCommand command = new SqlCommand(Qurrey, connection);

            command.Parameters.AddWithValue("@NationalNo", NationalNo);

            bool ISFound = false;

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                ISFound = reader.HasRows;

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

        public static bool DeletePerson(int PersonID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString);

            string Qurey = @"Delete People Where PersonID = @PersonID";

            SqlCommand command = new SqlCommand(Qurey, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            int reowAffected = 0;

            try
            {
                connection.Open();
                reowAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return reowAffected > 0;
        }

        public static DataTable GetAllPeople()
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString);

            string Qurey = "SELECT People.PersonID, People.NationalNo," +
                " People.FirstName, People.SecondName, People.ThirdName, People.LastName , People.DateOfBirth," +
                " case when  People.Gendor =1 then 'Female' " +
                " Else 'Male' End as GendorCaption," +
                " People.Address, People.Phone, People.Email,People.ImagePath, Countries.CountryName " +
                "FROM   Countries INNER JOIN People ON Countries.CountryID = People.NationalityCountryID";

            SqlCommand command = new SqlCommand(Qurey, connection);

            DataTable dataTable = new DataTable();

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                    dataTable.Load(reader);

                reader.Close();
            }
            catch(Exception ex) 
            {

            }
            finally
            { 
                connection.Close();
            }
            return dataTable;
        }
    }
}
