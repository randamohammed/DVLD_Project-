using SLDVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace SLDVLD_Buisness
{
    public class DriverInternationalLicensesViewModel
    {
        public int IntLicenseID {  get; set; }
        public int ApplicationID {  get; set; }
        public int LocalLicenseID {  get; set; }
        public DateTime IssueDate {  get; set; }
        public DateTime ExpirationDate {  get; set; }
        public bool IsActive {  get; set; }

        public DriverInternationalLicensesViewModel(int IntLicenseID ,int ApplicationID,int LocalLicenseID,
            DateTime IssueDate,DateTime ExpirationDate,bool IsActive)
        {
            this.IntLicenseID = IntLicenseID;
            this.ApplicationID = ApplicationID;
            this.LocalLicenseID = LocalLicenseID;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.IsActive = IsActive;
        }

        public static DriverInternationalLicensesViewModel Find(int DriverID)
        {
            bool Isfound = false, IsActive = false;
            int IntLicenseID =0, ApplicationID =0, LocalLicenseID =0;
            DateTime IssueDate =DateTime.Now,ExpirationDate = DateTime.Now;

            Isfound = clsDriverInternationalLicensesViewModel.Find(DriverID,ref IntLicenseID,ref ApplicationID,ref LocalLicenseID,ref IssueDate,
                ref ExpirationDate,ref IsActive);

            if (Isfound)
                return new DriverInternationalLicensesViewModel(IntLicenseID, ApplicationID, LocalLicenseID,
             IssueDate, ExpirationDate, IsActive);
            else
                return null;
        }

        public static async Task<DataTable> GetDriverInternationalLicenses(int DriverID)
        {
            return await clsDriverInternationalLicensesViewModel.GetDriverInternationalLicenses(DriverID);
        }

        public static async Task<List<DriverInternationalLicensesViewModel>> GetDriverInternationalLicensesINList(int DriverID)
        {
            DataTable data =await DriverInternationalLicensesViewModel.GetDriverInternationalLicenses(DriverID);

            List<DriverInternationalLicensesViewModel> licensesViewModels = new List<DriverInternationalLicensesViewModel>();

            foreach(DataRow row in data.Rows)
            {
                DriverInternationalLicensesViewModel driver = DriverInternationalLicensesViewModel.Find(DriverID);

                if(driver != null) 
                    licensesViewModels.Add(driver);
            }

            return licensesViewModels;


        }



    }
}
