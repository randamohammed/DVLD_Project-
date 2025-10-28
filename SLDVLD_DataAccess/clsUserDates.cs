using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace SLDVLD_DataAccess
{
    public class clsUserDates
    {
        public static int AddUser(int PersonID, string UserName, bool IsActive, string Password)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
            {


                using (SqlCommand command = new SqlCommand("SP_AddNewUser", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@Password", Password);
                    command.Parameters.AddWithValue("@UserName", UserName);
                    command.Parameters.AddWithValue("@IsActive", IsActive);

                    int AddRow = -1;
                    try
                    {
                        connection.Open();
                        object Add = command.ExecuteScalar();
                        if (Add != null && int.TryParse(Add.ToString(), out int AddUser))
                        {
                            AddRow = AddUser;
                        }
                    }
                    catch (Exception ex)
                    {

                        ErrorLogger.LogErrorToEventLog($"Error Add User: {ex.Message}");
                    }
                    return AddRow;

                }
            }
        }
        public static bool Update(int UserID, int PersonID, string UserName, bool IsActive, string Password)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
            {

                using (SqlCommand command = new SqlCommand("SP_UpdateUser", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", UserID);
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@Password", Password);
                    command.Parameters.AddWithValue("@UserName", UserName);
                    command.Parameters.AddWithValue("@IsActive", IsActive);

                    int RowAffcted = 0;

                    try
                    {
                        connection.Open();
                        RowAffcted = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {

                        ErrorLogger.LogErrorToEventLog($"Error Update user: {ex.Message}");
                    }

                    return RowAffcted > 0;
                }
            
            }
        }


        public static bool GetUserInfoByUserID(int UserID, ref int PersonID, ref string UserName, ref bool IsActive, ref string Password)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
            {

                using (SqlCommand command = new SqlCommand("SP_GetUserInfoByUserID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", UserID);

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
                                UserName = (string)reader["UserName"];
                                Password = (string)reader["Password"];
                                IsActive = (bool)reader["IsActive"];
                            }
                            else
                            {
                                ISFound = false;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        ISFound = false;

                        ErrorLogger.LogErrorToEventLog($"Error Get UserInfo By UserID: {ex.Message}");
                    }
                    return ISFound;
                }
            }
            }
        public static bool GetUserInfoByPersonID(ref int UserID, int PersonID, ref string UserName, ref bool IsActive, ref string Password)
        {
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
            {

                using (SqlCommand command = new SqlCommand("SP_GetUserInfoByPersonID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PersonID", PersonID);

                    bool ISFound = false;

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            ISFound = true;
                            UserID = (int)reader["UserID"];
                            UserName = (string)reader["UserName"];
                            Password = (string)reader["Password"];
                            IsActive = (bool)reader["IsActive"];
                        }
                        else
                        {
                            ISFound = false;
                        }
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        ISFound = false;

                        ErrorLogger.LogErrorToEventLog($"Error Get  UserInfo By PersonID: {ex.Message}");
                    }
                    return ISFound;
                }
            }
            }
        public static bool GetUserInfoByUsernameAndPassword(ref int UserID, ref int PersonID, string UserName, ref bool IsActive, string Password)
        {

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
            {

                using (SqlCommand command = new SqlCommand("SP_FindUserByUsernameAndPassword", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@UserName", UserName);
                    command.Parameters.AddWithValue("@Password", Password);

                    bool ISFound = false;

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            ISFound = true;
                            UserID = (int)reader["UserID"];
                            IsActive = (bool)reader["IsActive"];
                            PersonID = (int)reader["PersonID"];
                        }
                        else
                        {
                            ISFound = false;
                        }
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        ISFound = false;

                        ErrorLogger.LogErrorToEventLog($"Error Get UserInfo By Username And Password: {ex.Message}");
                    }
                    return ISFound;
                }
            }

        }
        public static bool ISUserExist(int UserID)
        {
            bool ISFound = false;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
            {

                using (SqlCommand command = new SqlCommand("SP_ISUserExistByUserID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", UserID);



                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                ISFound = true;
                            }
                            else
                            {
                                ISFound = false;
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                        ErrorLogger.LogErrorToEventLog($"Error User Exsit: {ex.Message}");

                    }
                }
            }
            return ISFound;
        }

        public static bool ISUserExist(string UserName)
        {
            bool ISFound = false;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
            {

                using (SqlCommand command = new SqlCommand("SP_ISUserExistByUserName", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserName", UserName);



                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                ISFound = true;
                            }
                            else
                            {
                                ISFound = false;
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                        ErrorLogger.LogErrorToEventLog($"Error Cheack is User Exist: {ex.Message}");
                    }
                }

                return ISFound;
            }
        }


        public static bool ChanagePassword(int UserID, string Password)
        {
            int RowAffcet = 0;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
            {
             

                using (SqlCommand command = new SqlCommand("SP_ChanagePassword", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", UserID);
                    command.Parameters.AddWithValue("@Password", Password);



                    try
                    {
                        RowAffcet = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {

                        ErrorLogger.LogErrorToEventLog($"Error Chanage Password: {ex.Message}");
                    }
                }
            }
            return RowAffcet > 0;

        }

        public static bool DeleteUser(int UserID)
        {
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
            {
          

                using (SqlCommand command = new SqlCommand("SP_DeleteUser", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", UserID);



                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {

                        ErrorLogger.LogErrorToEventLog($"Error Delete User: {ex.Message}");
                    }

                    return rowsAffected > 0;
                }
            }
        }

        public static bool IsUserExistForPersonID(int PersonID)
        {
            bool ISFound = false;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
            {

                using (SqlCommand command = new SqlCommand("SP_IsUserExistForPersonID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PersonID", PersonID);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            ISFound = true;
                        }
                        else
                        {
                            ISFound = false;
                        }
                        reader.Close();
                    }
                    catch (Exception ex)
                    {

                        ErrorLogger.LogErrorToEventLog($"Error IsUser Exist ForPersonID: {ex.Message}");
                    }
                    return ISFound;
                }
            }
        }
        public static bool DoesPersonHaveUser44(int PersonID)
        {
            bool ISFound = false;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
            {


                using (SqlCommand command = new SqlCommand("SP_DoesPersonHaveUser", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PersonID", PersonID);


                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        { 
                            if (reader.Read())
                            {
                                ISFound = true;
                            }
                            else
                            {
                                ISFound = false;
                            }
                         }
                    }
                    catch (Exception ex)
                    {

                        ErrorLogger.LogErrorToEventLog($"Error Does Person Have User: {ex.Message}");
                    }
                    return ISFound;
                }
            }
        }

        public static async Task<DataTable> GetAllUsers()
        {
            DataTable dt = new DataTable();

            return await Task.Run(() =>
            {



                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_GetAllUsers", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        try
                        {
                            connection.Open();
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    dt.Load(reader);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            // هذا مهم جداً لتشخيص أي أخطاء في المستقبل
                            Console.WriteLine("Data Access Error: " + ex.Message);

                            ErrorLogger.LogErrorToEventLog($"Error Get All user: {ex.Message}");
                        }
                    }

                }
                return dt;


            });
        }
    }


}
