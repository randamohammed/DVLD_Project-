using SLDVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLDVLD_Buisness
{
    public class DriverViewModel
    {
        public int DriverID {  get; set; }
        public int PersonID {  get; set; }
        public string NationalNo {  get; set; }
        public string FullName {  get; set; } 
        public DateTime Date {  get; set; }
        public bool ActiveLicenses { get; set; }

        public DriverViewModel()
        {

        }

        public DriverViewModel(int DriverID,int PrsonId,string NationNo,string FullName,bool Active,DateTime Date)
        {
            this.DriverID = DriverID;
            this.PersonID = PrsonId;
            this.NationalNo = NationNo;
            this.FullName = FullName;
            this.ActiveLicenses = Active;
            this.Date = Date;

        }
        public static DriverViewModel FindByID(int DriverID)
        {
            int PersonID = -1, CreatedByUserId = -1;
            DateTime CreatedDate = DateTime.Now;
            bool ISActive = false;
            string NationalNo = "", FullName ="";
            bool Isfound = clsDriverData.FindDriverByIDforDriverView(DriverID, ref PersonID, ref  NationalNo, ref  FullName, ref  CreatedDate, ref  ISActive);

            if (Isfound)
            {
               return new DriverViewModel(DriverID, PersonID,NationalNo, FullName, ISActive, CreatedDate);
            }
            else
                return null;
               
        }

        public static async Task<List<DriverViewModel>> GetAdllDrivers()
        {
            DataTable data =await clsDriver.GetAdllDrivers();
            List<DriverViewModel> list = new List<DriverViewModel>();
            foreach (DataRow row in data.Rows)
            {
                DriverViewModel Driver = DriverViewModel.FindByID((int)row["DriverID"]);

                if (Driver != null) 
                list.Add(Driver);


            }
            return list;
        }


    }
}
