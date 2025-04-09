using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLDVLD_DataAccess
{
    public class clsDriverData
    {
        public static bool FnidDriverByPresonID(int PresonId, ref int DriverID, ref int CreatedByUserID, ref DateTime CreatedDate)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString);
            string Qurey = "select * from  Drivers  Where PersonID = @PersonID";

            SqlCommand command = new SqlCommand(Qurey, connection);
            command.Parameters.AddWithValue("@PersonID", PresonId);
            bool ISFound = false;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    ISFound = true;
                    CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    DriverID = (int)reader["DriverID"];
                }
                reader.Close();
            }
            catch (Exception Ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return ISFound;
        }
        public static bool FinidDriverID( int DriverID,ref int PresonId, ref int CreatedByUserID, ref DateTime CreatedDate)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString);
            string Qurey = "select * from  Drivers  Where DriverID = @DriverID";

            SqlCommand command = new SqlCommand(Qurey, connection);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            bool ISFound = false;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    ISFound = true;
                    CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    PresonId = (int)reader["PersonID"];
                }
                reader.Close();
            }
            catch (Exception Ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return ISFound;
        }

        public static DataTable GetAllDrivers()
        {
            DataTable table = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString);

            string Query = @"select * from Drivers_View order by FullName";

            SqlCommand command = new SqlCommand(Query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                    table.Load(reader);

                reader.Close();
            }
            catch (Exception Ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return table;
        }
        public static bool UpdateDriver(int DriverID,int  PresonID,int CreatedByUserID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString);
            string Query = @"Update Drivers Set PresonID = @PresonID ,CreatedByUserID =@CreatedByUserID
                             WHERE DriverID = @DriverID";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@PresonID", PresonID);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            int RowAffeced = 0;

            try
            {
                connection.Open();
                RowAffeced = command.ExecuteNonQuery();
            }
            catch(Exception Ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return RowAffeced > 0;
        }
        public static int AddNewDriver( int CreatedByUserID, int PersonID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConntaionString);
            string Qurey = @"INSERT INTO Drivers (CreatedByUserID,CreatedDate,PersonID)  
                              VALUES (@CreatedByUserID,@CreatedDate,@PersonID)
                               select SCOPE_IDENTITY()";

            SqlCommand command = new SqlCommand(Qurey, connection);
            command.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            int DriverID = -1;
            try
            {
                connection.Open();
                object Reslut = command.ExecuteScalar();
                if (Reslut != null && int.TryParse(Reslut.ToString(), out int InsertId))
                {
                    DriverID = InsertId;
                }
            }
            catch (Exception Ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return DriverID;


        }
    }
}
