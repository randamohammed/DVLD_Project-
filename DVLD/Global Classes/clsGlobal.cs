using Microsoft.Win32;
using SLDVLD_Buisness;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace DVLDSluotion
{
    public class clsGlobal
    {
        public static clsUsers2 CurrentUser;

        public static string PasswordEncryption(string Password)
        {
            using(SHA256 shapassword =   SHA256.Create())
            {
                byte[] bytes = shapassword.ComputeHash(Encoding.UTF8.GetBytes(Password));

                return BitConverter.ToString(bytes).Replace("-","").ToLower();
            }
        }

        public static bool RememberUsernameAndPassword(string UserName,string Password)
        {
            try
            {
                string PathKey = @"HKEY_CURRENT_USER\SOFTWARE\UserDate";
                string filePath = "DVLuserData";

                if (UserName == "" && File.Exists(filePath))
                {
                    File.Delete(filePath);
                    return true;
                }

                string DateSave = UserName + "#//#" + Password;

                Registry.SetValue(PathKey, filePath, DateSave);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }
        }

        public static bool GetStoredCredentil(ref string UserName, ref string Password)
        {

            string PathKey = @"HKEY_CURRENT_USER\SOFTWARE\UserDate";
            string filePath = "DVLuserData";
            try
            {
              
                   string Line = Registry.GetValue(PathKey, filePath,null) as string;

                        if (Line  != null)
                        {

                            Console.WriteLine(Line);

                            string[] result = Line.Split(new string[] { "#//#" }, StringSplitOptions.None);
                            UserName = result[0];
                            Password = result[1];
                           
                        }
                        return true;
                   
            }
            catch (Exception ex)
            { 
                MessageBox.Show($"An error occurred: {ex.Message}");
            return false;

            }
        }
    }
}
