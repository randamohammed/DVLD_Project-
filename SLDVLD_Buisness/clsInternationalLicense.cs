using SLDVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SLDVLD_Buisness.clsApplication;

namespace SLDVLD_Buisness
{
    public class clsInternationalLicense:clsApplication
    {

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public clsDriver DriverInfo;
        public int InternationalLicenseID { set; get; }
        public int DriverID { set; get; }
        public int IssuedUsingLocalLicenseID { set; get; }
        public DateTime IssueDate { set; get; }
        public DateTime ExpirationDate { set; get; }
        public bool IsActive { set; get; }

        
        public clsInternationalLicense()

        {
            //here we set the applicaiton type to New International License.
            this.ApplicationTypeID = (int)clsApplication.enApplicationType.NewInternationalLicense;

            this.InternationalLicenseID = -1;
            this.DriverID = -1;
            this.IssuedUsingLocalLicenseID = -1;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now;
            
            this.IsActive = true;


            Mode = enMode.AddNew;

        }

        public clsInternationalLicense(int ApplicationID, int ApplicantPersonID,
            DateTime ApplicationDate,
             enApplicationStatus ApplicationStatus, DateTime LastStatusDate,
             float PaidFees, int CreatedByUserID,
             int InternationalLicenseID, int DriverID, int IssuedUsingLocalLicenseID,
            DateTime IssueDate, DateTime ExpirationDate, bool IsActive)
        {
            base.ApplicantPersonID = ApplicantPersonID;
            base.ApplicationTypeID = (int)enApplicationType.NewInternationalLicense;
            base.ApplicationDate = ApplicationDate;
            base.ApplicationStatus = ApplicationStatus;
            base.LastStatusDate = LastStatusDate;
            base.PaidFees = PaidFees;
            base.CreatedByUserID = CreatedByUserID;
            base.ApplicationID = ApplicationID;


            this.ApplicationID = ApplicationID;
            this.InternationalLicenseID = InternationalLicenseID;
            this.DriverID = DriverID;
            this.IsActive=IsActive;
            this.IssuedUsingLocalLicenseID= IssuedUsingLocalLicenseID;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.CreatedByUserID = CreatedByUserID;

            DriverInfo = clsDriver.FindByID(DriverID);
            Mode = enMode.Update;
        }

        private bool _AddNewInternationalLicense()
        {
            this.InternationalLicenseID = clsInternationalLicenseData.AddNewInternationalLicense(this.ApplicationID,this.DriverID,
                this.IssuedUsingLocalLicenseID,this.IssueDate,this.ExpirationDate,this.IsActive,this.CreatedByUserID);

            return this.InternationalLicenseID != -1;
        }

        private bool _UpdateInternationalLicense()
        {
            return clsInternationalLicenseData.UpdateInternationalLicense(this.InternationalLicenseID,this.ApplicationID,this.DriverID,
                this.IssuedUsingLocalLicenseID,this.IssueDate,this.ExpirationDate,this.IsActive,this.CreatedByUserID);
        }

        public static DataTable GetAllInternationalLicenses()
        {
            return clsInternationalLicenseData.GetAllInternationalLicenses();
        }

        public static clsInternationalLicense Find(int InternationalLicenseID)
        {
            int ApplicationID = -1;
            int DriverID = -1; int IssuedUsingLocalLicenseID = -1;
            DateTime IssueDate = DateTime.Now; DateTime ExpirationDate = DateTime.Now;
            bool IsActive = true; int CreatedByUserID = 1;


            bool ISFound = clsInternationalLicenseData.GetInternationalLicenseInfoByID(InternationalLicenseID,ref ApplicationID,ref DriverID,
                ref IssuedUsingLocalLicenseID,ref IssueDate,ref ExpirationDate,ref IsActive,ref CreatedByUserID);

            clsApplication Application = clsApplication.FindBaseApplication(ApplicationID);

            if (ISFound)
            {
                return new clsInternationalLicense(ApplicationID, Application.ApplicantPersonID, Application.ApplicationDate,
                    Application.ApplicationStatus, Application.LastStatusDate, Application.PaidFees, CreatedByUserID,
                    InternationalLicenseID, DriverID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, IsActive);
            }
            else
                return null;
        }
       public bool Save()
            {

            base.Mode = (clsApplication.enMode)Mode;
            if (!base.Save())
                return false;

            switch (Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewInternationalLicense())
                        {
                            Mode = enMode.Update;
                            return true;
                        }
                        else
                            return false;
                    }
                    case enMode.Update:
                    {
                        return _UpdateInternationalLicense();
                    }
            }
            return false;
        }

        public static int GetActiveInternationalLicenseIDByDriverID(int DriverID)
        {
            return clsInternationalLicenseData.GetActiveInternationalLicenseIDByDriverID(DriverID);
        }
        public static DataTable GetDriverInternationalLicenses(int DriverID)
        {
            return clsInternationalLicenseData.GetDriverInternationalLicenses(DriverID);
        }
    }
}
