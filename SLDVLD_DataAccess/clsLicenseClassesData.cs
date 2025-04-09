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
    public class clsLicenseClassesData
    {
        public static bool GetLicenseClassInfoByID(int LicenseClassID, ref byte DefaultValidityLength, ref byte MinimumAllowedAge,
            ref float ClassFees, ref string ClassName, ref string ClassDescription)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString);
            string Query = "Select * from LicenseClasses WHERE LicenseClassID =@LicenseClassID";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            bool ISFound = false;

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    ISFound = true;
                    DefaultValidityLength = (byte)reader["DefaultValidityLength"];
                    MinimumAllowedAge = (byte)reader["MinimumAllowedAge"];
                    ClassDescription = (string)reader["ClassDescription"];
                    ClassFees = Convert.ToSingle(reader["ClassFees"]);
                    ClassName = (string)reader["ClassName"];

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
      public static bool GetLicenseClassInfoByClassName(ref int LicenseClassID, ref byte DefaultValidityLength, ref byte MinimumAllowedAge,
            ref float ClassFees,  string ClassName, ref string ClassDescription)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString);
            string Query = "Select * from LicenseClasses WHERE ClassName =@ClassName";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ClassName", ClassName);

            bool ISFound = false;

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    ISFound = true;
                    DefaultValidityLength = (byte)reader["DefaultValidityLength"];
                    MinimumAllowedAge = (byte)reader["MinimumAllowedAge"];
                    ClassDescription = (string)reader["ClassDescription"];
                    ClassFees = Convert.ToSingle(reader["ClassFees"]);
                    LicenseClassID = (int)reader["LicenseClassID"];

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
     public static DataTable GetAllLicenseClasses()
        {
            DataTable table = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString);
            string Qurey = "SELECT * FROM LicenseClasses";

            SqlCommand command = new SqlCommand(Qurey, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.HasRows)
                {
                    table.Load(reader);
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
            return table;

        }
   
    public static int AddNewLicenseClass(string ClassName, string ClassDescription,
            byte MinimumAllowedAge, byte DefaultValidityLength, float ClassFees)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString);
            string Qurey = @"INSERT INTO LicenseClasses 
              (ClassFees,DefaultValidityLength,MinimumAllowedAge,ClassDescription,ClassName) 
               Values (@ClassFees,@DefaultValidityLength,@MinimumAllowedAge,@ClassDescription,@ClassName)
               select SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(Qurey,connection);
            command.Parameters.AddWithValue("@ClassFees", ClassFees);
            command.Parameters.AddWithValue("@DefaultValidityLength", DefaultValidityLength);
            command.Parameters.AddWithValue("@MinimumAllowedAge", MinimumAllowedAge);
            command.Parameters.AddWithValue("@ClassDescription", ClassDescription);
            command.Parameters.AddWithValue("@ClassName", ClassName);

            int AddLicenseClassID = -1;

            try
            {
                connection.Open();
                object Reslut = command.ExecuteScalar();

                if (Reslut != null && int.TryParse(Reslut.ToString(), out int LicenseClassID))
                {
                    AddLicenseClassID = LicenseClassID;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return AddLicenseClassID;
        }

        public static bool UpdateLicenseClass(int LicenseClassID, string ClassName, string ClassDescription,
           byte MinimumAllowedAge, byte DefaultValidityLength, float ClassFees)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString);
            string Qurey = @"UPDATE LicenseClasses  SET 
              ClassFees = @ClassFees,DefaultValidityLength =@DefaultValidityLength,
               MinimumAllowedAge =@MinimumAllowedAge,ClassDescription = @ClassDescription,ClassName = @ClassName 
              WHERE LicenseClassID =@LicenseClassID ";

            SqlCommand command = new SqlCommand(Qurey, connection);

            command.Parameters.AddWithValue("@ClassFees", ClassFees);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            command.Parameters.AddWithValue("@DefaultValidityLength", DefaultValidityLength);
            command.Parameters.AddWithValue("@MinimumAllowedAge", MinimumAllowedAge);
            command.Parameters.AddWithValue("@ClassDescription", ClassDescription);
            command.Parameters.AddWithValue("@ClassName", ClassName);

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


    }
}
