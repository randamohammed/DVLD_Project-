using SLDVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLDVLD_Buisness
{
    public class clsLicenes
    {
        public int CreatedByUserID { get; set; }
        public bool IsActive { get; set; }
        public string Notes { get; set; }
        public float PaidFees { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public enIssueReason IssueReason { get; set; }
        public int LicenseClass { get; set; }
        public int DriverID { get; set; }
        public clsDriver SlelectDriverInfo;
        public int ApplicationID { get; set; }
        public int LicenseID { get; set; }

       public clsLicenseClass LicenseClassIfo;
   public clsDetainedLicenses DetainedInfo { set; get; }
        public enum enIssueReason { FirstTime = 1, Renew = 2, DamagedReplacement = 3, LostReplacement = 4 };
        enum enMode { AddNew = 0, Update = 1 }
        enMode Mode;
        public string IssueReasonText
        {
            get
            {
                return GetIssueReasonText(this.IssueReason);
            }
        }
        public clsLicenes()
        {
            LicenseID = -1;
            ApplicationID = -1;
            LicenseClass = -1;
            CreatedByUserID = -1;
            Notes = "";
            IssueReason = 0;
            ExpirationDate = DateTime.Now;
            IsActive = true;
            PaidFees = 0;
            IssueDate = DateTime.Now;
            Mode = enMode.AddNew;
        }


        public clsLicenes(int LicenseID, int ApplicationID, int DriverID, int LicenseClass,
              int CreatedByUserID, string Notes, enIssueReason IssueReason, DateTime ExpirationDate,
              bool IsActive, float PaidFees, DateTime IssueDate)
        {
            this.LicenseID = LicenseID;
            this.ApplicationID = ApplicationID;
            this.LicenseClass = LicenseClass;
            this.CreatedByUserID = CreatedByUserID;
            this.Notes = Notes;
            this.IssueReason = IssueReason;
            this.ExpirationDate = ExpirationDate;
            this.IsActive = IsActive;
            this.PaidFees = PaidFees;
            this.IssueDate = IssueDate;
            this.DriverID = DriverID;
            SlelectDriverInfo = clsDriver.FindByID(DriverID);
            LicenseClassIfo = clsLicenseClass.Find(LicenseClass);
            this.DetainedInfo = clsDetainedLicenses.FindByLicenesID(LicenseID);
            Mode = enMode.Update;
        }

        public static clsLicenes FindByID(int LicenesID)
        {
            int ApplicationID = 0, LicenseClass = 0, CreatedByUserID = 0, DriverID =0;
            string Notes = "";
            float PaidFees = 0;
            byte IssueReason =1;
            DateTime ExpirationDate = DateTime.Now, IssueDate = DateTime.Now;
            bool IsActive = false;

            bool ISFound = clsLicenesData.GetLicenseInfoByID(LicenesID, ref ApplicationID, ref DriverID, ref LicenseClass, ref CreatedByUserID, ref Notes,
              ref IssueReason, ref ExpirationDate, ref IsActive, ref PaidFees, ref IssueDate);


            if (ISFound)
            {
                return new clsLicenes(LicenesID, ApplicationID, DriverID, LicenseClass, CreatedByUserID, Notes,
                (enIssueReason )IssueReason, ExpirationDate, IsActive, PaidFees, IssueDate);
            }
            else
                return null;

        }

        private bool _AddNewLicenes()
        {
            this.LicenseID = clsLicenesData.AddNewLicense(this.ApplicationID, this.DriverID, this.LicenseClass, this.CreatedByUserID, this.Notes,
                (byte)this.IssueReason, this.ExpirationDate, this.IsActive, this.PaidFees, this.IssueDate);

            return this.LicenseID != -1;

        }

        private bool _UpdateLicenes()
        {
            return clsLicenesData.UdateLicenes(this.LicenseID, this.ApplicationID, this.DriverID, this.LicenseClass, this.CreatedByUserID, this.Notes,
                (byte)this.IssueReason, this.ExpirationDate, this.IsActive, this.PaidFees, this.IssueDate);
        }
        public static DataTable GetAllLicenes()
        {
            return clsLicenesData.GetAllLicenses();
        }
        public static bool IsLicenseExistByPersonID(int PersonID, int LicenseClassID)
        {
            return (GetActiveLicenseIDByPersonID(PersonID, LicenseClassID) != -1);
        }

        public static int GetActiveLicenseIDByPersonID(int PersonID, int LicenseClassID)
        {

            return clsLicenesData.GetActiveLicenseIDByPersonID(PersonID, LicenseClassID);

        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewLicenes())
                        {
                            Mode = enMode.Update;
                            return true;
                        }
                        else
                            return false;
                    }

                case enMode.Update:
                    return _UpdateLicenes();
            }
            return false;
        }

        public static DataTable GetDriverLicenses(int DriverID)
        {
            return clsLicenesData.GetDriverLicenses(DriverID);
        }
        public static string GetIssueReasonText(enIssueReason IssueReason)
        {

            switch (IssueReason)
            {
                case enIssueReason.FirstTime:
                    return "First Time";
                case enIssueReason.Renew:
                    return "Renew";
                case enIssueReason.DamagedReplacement:
                    return "Replacement for Damaged";
                case enIssueReason.LostReplacement:
                    return "Replacement for Lost";
                default:
                    return "First Time";
            }
        }


        public Boolean IsLicenseExpired()
        {

            return (this.ExpirationDate < DateTime.Now);

        }


        public bool DeactivateCurrentLicense()
        {
            return (clsLicenesData.DeactivateLicense(this.LicenseID));
        }
        public bool IsDetained
        {
            get { return clsDetainedLicenses.IsLicenseDetained(this.LicenseID); }
        }

        public int Detain(float FineFees, int CreatedByUserID)
        {
            clsDetainedLicenses detainedLicenses = new clsDetainedLicenses();

            detainedLicenses.LicenseID = this.LicenseID;
            detainedLicenses.CreatedByUserID = CreatedByUserID;
            detainedLicenses.FineFees =Convert.ToSingle( FineFees);
            detainedLicenses.DetainDate = DateTime.Now;

           if(!detainedLicenses.Save())
            {
                return -1;
            }
            return detainedLicenses.DetainID;

        }

        public bool ReleaseDetainedLicense( int ReleasedByUserID, ref int ApplicationID)
        {
            clsApplication Application = new clsApplication();

            Application.ApplicantPersonID = this.SlelectDriverInfo.SelectPersonInfo.PersonID; ;
            Application.ApplicationDate = DateTime.Now;
            Application.LastStatusDate = DateTime.Now;
            Application.ApplicationStatus = clsApplication.enApplicationStatus.Cancelled;
            Application.CreatedByUserID = ReleasedByUserID;
            Application.ApplicationTypeID =(int) clsApplication.enApplicationType.ReleaseDetainedDrivingLicsense;
            Application.PaidFees = clsAppplicationType.Find(Application.ApplicationTypeID).Fees;

            if(!Application.Save())
            {
                ApplicationID = -1;
                return false;
            }
            ApplicationID =Application.ApplicationID;
            return this.DetainedInfo.ReleaseDetainedLicense(Application.ApplicationID, ReleasedByUserID);
        }
            public clsLicenes RenewLicense(string  Notes,int CreatedByUser)
        {
            clsApplication Application = new clsApplication();
            Application.ApplicantPersonID = this.SlelectDriverInfo.SelectPersonInfo.PersonID;
            Application.PaidFees = clsAppplicationType.Find((int)clsApplication.enApplicationType.RenewDrivingLicense).Fees;
            Application.ApplicationDate = DateTime.Now;
            Application.LastStatusDate = DateTime.Now;
            Application.CreatedByUserID = CreatedByUser;
            Application.ApplicationStatus = clsApplication.enApplicationStatus.Cancelled;
            Application.ApplicationTypeID = clsAppplicationType.Find((int)clsApplication.enApplicationType.RenewDrivingLicense).ApplicationTypeIID;

            if(!Application.Save())
            {
             return    null;
            }
            
            clsLicenes NewLicense = new clsLicenes();

            int DefaultValidityLength = this.LicenseClassIfo.DefaultValidityLength;

            NewLicense.ApplicationID = Application.ApplicationID;
            NewLicense.CreatedByUserID = CreatedByUser;
            NewLicense.PaidFees = this.LicenseClassIfo.ClassFees;
            NewLicense.DriverID = this.DriverID;
            NewLicense.IssueReason = clsLicenes.enIssueReason.Renew;
            NewLicense.IssueDate = DateTime.Now;
            NewLicense.ExpirationDate  = DateTime.Now.AddDays(DefaultValidityLength);
            NewLicense.Notes = Notes;
            NewLicense.LicenseClass = this.LicenseClass;
            NewLicense.IsActive = true;

            if(!NewLicense.Save())
            {
                return null;
            }
            DeactivateCurrentLicense();
           return NewLicense;
        }

        public clsLicenes Replace(enIssueReason issueReason,int CreatedUuserId)
        {
            clsApplication Application = new clsApplication();



            Application.ApplicantPersonID = this.SlelectDriverInfo.PresonID;
            Application.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            Application.ApplicationDate = DateTime.Now;
            Application.CreatedByUserID = CreatedUuserId;
            Application.ApplicationTypeID = (enIssueReason.DamagedReplacement == issueReason) ? 
                (int)enIssueReason.DamagedReplacement : (int)enIssueReason.LostReplacement;

            Application.PaidFees = clsAppplicationType.Find(Application.ApplicationTypeID).Fees;
            Application.LastStatusDate = DateTime.Now;

            if(!Application.Save())
            {
                return null;
            }

            clsLicenes Replacement = new clsLicenes();

            Replacement.ApplicationID = Application.ApplicationID;
            Replacement.ExpirationDate = this.ExpirationDate;
            Replacement.IssueDate = DateTime.Now;
            Replacement.PaidFees = 0;
            Replacement.LicenseClass = this.LicenseClass;
            Replacement.IssueReason = issueReason;
            Replacement.CreatedByUserID = CreatedUuserId;
            Replacement.DriverID = this.DriverID;
            Replacement.IsActive = true;
            Replacement.Notes = this.Notes;

            if(!Replacement.Save())
            {
                return null;
            }
            this.DeactivateCurrentLicense();

            return Replacement;

        }
    }
}
