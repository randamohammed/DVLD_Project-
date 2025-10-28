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
        public static int AddNewPerson(string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName, DateTime DateOfBirth,
            string ImagePath, string Email, string Address, string Phone, int NationalityCountryID, short Gendor)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
            {


                using (SqlCommand command = new SqlCommand("SP_AddNewPerson", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
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
                    if (Email != "")
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

                        ErrorLogger.LogErrorToEventLog($"Error Feiled Added Person: {ex.Message}");
                    }

                    return PresonID;
                }
            }
        }

        public static bool Update(int PersonID, string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName, DateTime DateOfBirth,
            string ImagePath, string Email, string Address, string Phone, int NationalityCountryID, short Gendor)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
            {

                using (SqlCommand command = new SqlCommand("SP_UpdatePerson", connection))
                {

                    command.CommandType = CommandType.StoredProcedure;

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
                    catch (Exception ex)
                    {
                        ErrorLogger.LogErrorToEventLog($"Error update: {ex.Message}");
                    }

                    return rowffected > 0;
                }
            }
        }
        public static bool FindPersonByID(int PersonID, ref string NationalNo, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName, ref DateTime DateOfBirth,
          ref string ImagePath, ref string Email, ref string Address, ref string Phone, ref int NationalityCountryID, ref short Gendor)
        {

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
            {


                using (SqlCommand command = new SqlCommand("SP_FindPersonByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PersonID", PersonID);

                    bool ISFound = false;

                    try
                    {
                        connection.Open();


                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
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
                                Gendor =Convert.ToSByte( reader["Gendor"]);

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
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrorLogger.LogErrorToEventLog($"Error FindPersonByID: {ex.Message}");

                    }
                    return ISFound;
                }
            }
        }

        public static bool FindPersonByIDNamGander(int PersonID, ref string NationalNo, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName, ref DateTime DateOfBirth,
        ref string ImagePath, ref string Email, ref string Address, ref string Phone, ref int NationalityCountryID, ref string Gendor)
        {

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
            {


                using (SqlCommand command = new SqlCommand("SP_FindPersonByIDNamGander", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PersonID", PersonID);

                    bool ISFound = false;

                    try
                    {
                        connection.Open();


                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
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
                                Gendor = (string)reader["GendorCaption"];

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
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrorLogger.LogErrorToEventLog($"Error Get FindPerson ByID NamGander: {ex.Message}");

                    }
                    return ISFound;
                }
            }
        }

        public static bool FindPersonByNationalNo(string NationalNo, ref int PersonID, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName, ref DateTime DateOfBirth,
          ref string ImagePath, ref string Email, ref string Address, ref string Phone, ref int NationalityCountryID, ref short Gendor)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
            {

                using (SqlCommand command = new SqlCommand("SP_FindPersonByNationalNo", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@NationalNo", NationalNo);

                    bool ISFound = false;

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
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
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrorLogger.LogErrorToEventLog($"Error FindPersonBy NationalNo: {ex.Message}");
                    }

                    return ISFound;
                }
            }
        }
        public static bool ISPersonExist(int PersonID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
            {
                using (SqlCommand command = new SqlCommand("SP_IsPersonExistbyPersonID", connection))
                {  
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@PersonID", PersonID);

                    bool ISFound = false;

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            ISFound = reader.HasRows;

                        }
                    }
                    catch (Exception ex)
                    {
                        ISFound = false;

                        ErrorLogger.LogErrorToEventLog($"Error Get ISPersonExist: {ex.Message}");
                    }
                    
                    return ISFound;
                }
            }
        }


        public static bool IsPersonExist(string NationalNo)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
            {
                using (SqlCommand command = new SqlCommand("SP_IsPersonExistbyNationalNo", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@NationalNo", NationalNo);

                    bool ISFound = false;

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            ISFound = reader.HasRows;
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        ISFound = false;
                        ErrorLogger.LogErrorToEventLog($"Error Get Is PersonExist: {ex.Message}");

                    }
                  
                    return ISFound;
                }
            }
        }
        public static bool DeletePerson(int PersonID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
            {
                using (SqlCommand command = new SqlCommand("SP_deletePeople", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@PersonID", PersonID);

                    int reowAffected = 0;

                    try
                    {
                        connection.Open();
                        reowAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {

                        ErrorLogger.LogErrorToEventLog($"Error Feild in delete person: {ex.Message}");
                    }
                   
                    return reowAffected > 0;
                }
            }
        }

        public static async Task< DataTable> GetAllPeople()
        {
            return await Task.Run(() => {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
            {

                using (SqlCommand command = new SqlCommand("SP_GetAllPeople", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    DataTable dataTable = new DataTable();

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.HasRows)
                                dataTable.Load(reader);
                        }
                    }
                    catch (Exception ex)
                    {

                            ErrorLogger.LogErrorToEventLog($"Error Feild Get All People: {ex.Message}");
                        }

                    return dataTable;
                }
            }
            });
        }
    }
}
