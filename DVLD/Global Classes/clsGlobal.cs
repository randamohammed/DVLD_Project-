using SLDVLD_Buisness;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDSluotion
{
    public class clsGlobal
    {
        public static clsUsers2 CurrentUser;

        public static bool RememberUsernameAndPassword(string UserName,string Password)
        {
           try
           {
                string CurrentDirectory =System.IO. Directory.GetCurrentDirectory();
                string filePath = CurrentDirectory + "\\date.txt";

                if(UserName ==""&& File.Exists(filePath))
                {
                    File.Delete(filePath);
                    return true;
                }

                string DateSave = UserName + "#//#" + Password;

                using(StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine(DateSave);
                    return true;
                }
           }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }
        }

        public static bool GetStoredCredentil(ref string UserName, ref string Password)
        {

            string CurrentDirectory =System.IO.Directory.GetCurrentDirectory();
            string Pathfil = CurrentDirectory + "\\date.txt";

            try
            {
                if (File.Exists(Pathfil))
                {
                    using (StreamReader reader = new StreamReader(Pathfil))
                    {
                        string Line;

                        while ((Line = reader.ReadLine()) != null)
                        {

                            Console.WriteLine(Line);

                            string[] result = Line.Split(new string[] { "#//#" }, StringSplitOptions.None);
                            UserName = result[0];
                            Password = result[1];
                           
                        }
                        return true;
                    }
                }
            }
            catch (Exception ex)
            { 
                MessageBox.Show($"An error occurred: {ex.Message}");
            return false;

            }
            return false;
        }
    }
}
