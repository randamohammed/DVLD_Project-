using SLDVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SLDVLD_Buisness
{
    public class clsCountry
    {
        public string CountryName { get; set; }
        public int CountryID {  get; set; }

        public clsCountry()
        {
            CountryName = "";
            CountryID = 0;
        }

        public clsCountry(string CountryName, int CountryID)
        {
           this.CountryName = CountryName;
            this.CountryID = CountryID;
        }

        public static clsCountry Find(string CountryName)
        {
         int  CountryID =0;

            if(clsCountryData.FindCountryByNam(CountryName,ref CountryID))

                return new clsCountry(CountryName,CountryID);
            else
                return null;
        }

        public static clsCountry Find(int CountryID)
        {
            string CountryName = "";

            if (clsCountryData.FindCountryByID(CountryID,ref CountryName))

                return new clsCountry(CountryName, CountryID);
            else
                return null;
        }

        public static DataTable GetAllCountries()
        {
            return clsCountryData.GetAllCountries();
        }
    }
}
