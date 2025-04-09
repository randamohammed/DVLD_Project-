using SLDVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SLDVLD_Buisness.clsApplication;
using static System.Net.Mime.MediaTypeNames;

namespace SLDVLD_Buisness
{
    public class clsApplication
    {
        public int ApplicationID {  get; set; }

        public int CreatedByUserID {  get; set; }
        public clsUsers2 SelectUserInfo;
        public float PaidFees { get; set; }
        
        public int ApplicationTypeID { get; set; }
        public clsAppplicationType AppplicationType;
        public int ApplicantPersonID {  get; set; }
        public clsPerson PeersonInfo { get; set; }
        public string FullName { get { return clsPerson.Find(ApplicantPersonID).FullName; } }
        public DateTime LastStatusDate {  get; set; }
        public DateTime ApplicationDate {  get; set; }

        public enum enMode { AddNew =0,Update =1};
        public enum enApplicationStatus { New = 1, Cancelled = 2, Completed = 3 };
       public enApplicationStatus ApplicationStatus{get;set;}

    public    enMode Mode;

        public string Status
        {
            get
            {
                switch(ApplicationStatus)
                {
                    case enApplicationStatus.New:
                        {
                            return "Now";
                        }
                        case enApplicationStatus.Cancelled:
                        {
                            return "Cancelled";
                        }
                        case enApplicationStatus.Completed:
                        {
                            return "Copmleted";
                        }
                    default:
                        return "Unknown";


                }
               

            }
        }
        public enum enApplicationType
        {
            NewDrivingLicense = 1, RenewDrivingLicense = 2, ReplaceLostDrivingLicense = 3,
            ReplaceDamagedDrivingLicense = 4, ReleaseDetainedDrivingLicsense = 5, NewInternationalLicense = 6, RetakeTest = 7
        };
        public clsApplication()
        {
            ApplicantPersonID = 0;
            ApplicationID = 0;
            ApplicationDate = DateTime.Now;
            LastStatusDate = DateTime.Now;
            CreatedByUserID = 0;
            ApplicationTypeID = 0;
            PaidFees = 0;
            ApplicationStatus = enApplicationStatus.New;
            Mode = enMode.AddNew;
        }
        public clsApplication(int  ApplicationID, int ApplicantPersonID, DateTime ApplicationDate,
                int ApplicationTypeID, enApplicationStatus ApplicationStatus, DateTime LastStatusDate, float PaidFees, int CreatedByUserID)
        {
            this.ApplicationID = ApplicationID;
            this.ApplicantPersonID = ApplicantPersonID;
            PeersonInfo = clsPerson.Find(ApplicantPersonID);
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            AppplicationType = clsAppplicationType.Find(ApplicationTypeID);
            SelectUserInfo = clsUsers2.FindByUserID(CreatedByUserID);
            Mode = enMode.Update;

        }

        private bool _AddNewApplication()
        {
            this.ApplicationID = clsApplicationData.AddNewApplications(this.ApplicantPersonID, this.ApplicationDate,
                this.ApplicationTypeID,(short) this.ApplicationStatus, this.LastStatusDate, this.PaidFees, this.CreatedByUserID);

            return this.ApplicantPersonID != -1;
        }

        bool UpdateApplication()
        {
            return clsApplicationData.UpdateApplication(this.ApplicationID, this.ApplicantPersonID, this.ApplicationDate,
                this.ApplicationTypeID,(short) this.ApplicationStatus, this.LastStatusDate, this.PaidFees, this.CreatedByUserID);
        }

        public static clsApplication FindBaseApplication(int ApplicationID)
        {
            int  ApplicantPersonID = 0,
                 ApplicationTypeID  = 0, CreatedByUserID = 0;
            float PaidFees = 0;
            short ApplicationStatus = 1;
            DateTime LastStatusDate = DateTime.Now, ApplicationDate = DateTime.Now;

            if (clsApplicationData.GetApplicationInfoByID(ApplicationID, ref ApplicantPersonID, ref ApplicationDate, ref ApplicationTypeID,
                 ref ApplicationStatus, ref LastStatusDate, ref PaidFees, ref CreatedByUserID))
                return new clsApplication(ApplicationID, ApplicantPersonID, ApplicationDate, ApplicationTypeID,
                     (enApplicationStatus)ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID);
            else
                return null;

        }
        public  bool Cancel()
        {
            return clsApplicationData.UpdateStatus(this.ApplicationID, 2);
        }
        public bool SetComplete()
        {
            return clsApplicationData.UpdateStatus(this.ApplicationID, 3);

        }
         
        public bool Save()
        {
            switch(Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewApplication())
                        {
                            Mode = enMode.Update;
                            return true;
                        }
                        else
                            return false;
                    }
                case enMode.Update:
                    return UpdateApplication();
            }
            return false;
        }
    
         public bool Delete(int ApplicationID)
        {
            return clsApplicationData.DeleteApplication(ApplicationID);
        }
    
        public static bool IsApplicationExist(int AppliicationID)
        {
            return clsApplicationData.ISExsitApplicationExsit(AppliicationID);
        }

        public  bool DoesPersonHaveActiveApplication(int ApplicaionTypeID)
        {
            return clsApplicationData.DoesPersonHaveActiveApplication(this.ApplicantPersonID, ApplicaionTypeID);
        }

        public static int GetActiveApplicationID(int ApplicatontPersonID,enApplicationType ApplicationTypeID)
        {
            return clsApplicationData.GetActiveApplicationID(ApplicatontPersonID,(int)ApplicationTypeID);
        }
    
        public static int GetActiveApplicationIDForLicenseClass(int ApplicatontPersonID, int LicenesClassID,enApplicationType ApplicationTypeID)
        {
            return clsApplicationData.GetActiveApplicationIDForLicenseClass(ApplicatontPersonID, LicenesClassID, (int)ApplicationTypeID);
        }

        public  int GetActiveApplicationID(enApplicationType ApplicationTypeID)
        {
            return clsApplicationData.GetActiveApplicationID(this.ApplicantPersonID, (int)ApplicationTypeID);
        }

    }
}
