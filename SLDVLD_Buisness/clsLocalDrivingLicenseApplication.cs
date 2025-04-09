using SLDVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace SLDVLD_Buisness
{
    public class clsLocalDrivingLicenseApplication : clsApplication
    {
        public int LicenseClassID { get; set; }
      public  clsLicenseClass LicenseClass;
        public int LocalDrivingLicenseApplicationID { get; set; }

        enum eMode { AddNew = 0, Update = 1 }
        eMode Mode = eMode.AddNew;

        public string PersonFullName
        {
            get { return FullName; }
        }

        public clsLocalDrivingLicenseApplication()
        {
            LicenseClassID = 0;
            LocalDrivingLicenseApplicationID = 0;
            Mode = eMode.AddNew;
        }
        public clsLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID, int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate,
                int ApplicationTypeID, enApplicationStatus ApplicationStatus,
                DateTime LastStatusDate, float PaidFees, int CreatedByUserID, int LicenseClassID)

        {
            this.LicenseClassID = LicenseClassID;
            LicenseClass = clsLicenseClass.Find(LicenseClassID);
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.ApplicationID = ApplicationID;
            this.ApplicantPersonID = ApplicantPersonID;
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = (int)ApplicationTypeID;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            Mode = eMode.Update;

            // this.SelectUserInfo = clsUsers2.FindByUserID(CreatedByUserID);
            //this.AppplicationType = clsAppplicationType.Find(ApplicationTypeID);
            //this.PeersonInfo = clsPerson.Find(ApplicantPersonID);
        }

        private bool _AddLocalDrivingLicenseApplication()
        {

            this.LocalDrivingLicenseApplicationID = clsLocalDrivingLicenseApplicationData.AddNewLocalDrivingLicenseApplication
                (this.ApplicationID, this.LicenseClassID);

            return (this.LocalDrivingLicenseApplicationID != -1);

        }
        private bool _UdateLocalDrivingLicenseApplication()
        {
            return clsLocalDrivingLicenseApplicationData.UpdateLocalDrivingLicenseApplication(this.LocalDrivingLicenseApplicationID, this.ApplicationID, this.LicenseClassID);
        }

        public static clsLocalDrivingLicenseApplication FindLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID)
        {
            int LicenseClassID = 0, ApplicationID = 0;

            bool ISFound = clsLocalDrivingLicenseApplicationData.GetLocalDrivingLicenseApplicationInfoByID(LocalDrivingLicenseApplicationID, ref ApplicationID, ref LicenseClassID);

            if (ISFound)
            {
                clsApplication Application = clsApplication.FindBaseApplication(ApplicationID);

                return new clsLocalDrivingLicenseApplication(LocalDrivingLicenseApplicationID, Application.ApplicationID, Application.ApplicantPersonID,
                    Application.ApplicationDate, Application.ApplicationTypeID, (enApplicationStatus)Application.ApplicationStatus,
                    Application.LastStatusDate, Application.PaidFees, Application.CreatedByUserID, LicenseClassID);
            }
            else
                return null;
        }
        public static clsLocalDrivingLicenseApplication FindByApplicationID(int ApplicationID)
        {
            int LicenseClassID = 0, LocalDrivingLicenseApplicationID = 0;

            bool ISFound = clsLocalDrivingLicenseApplicationData.GetLocalDrivingLicenseApplicationInfoByApplicationID(LocalDrivingLicenseApplicationID, ref LicenseClassID, ref ApplicationID);

            if (ISFound)
            {
                clsApplication Application = clsApplication.FindBaseApplication(ApplicationID);

                return new clsLocalDrivingLicenseApplication(LocalDrivingLicenseApplicationID, ApplicationID, Application.ApplicantPersonID,
                    Application.ApplicationDate, Application.ApplicationTypeID, (enApplicationStatus)Application.ApplicationStatus,
                    Application.LastStatusDate, Application.PaidFees, Application.CreatedByUserID, LicenseClassID);
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
                case eMode.AddNew:
                    {
                        if (_AddLocalDrivingLicenseApplication())
                        {
                            Mode = eMode.Update;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                case eMode.Update:
                    return _UdateLocalDrivingLicenseApplication();
            }
            return false;
        }

        public  bool Delete()
        {
            return clsLocalDrivingLicenseApplicationData.DeleteLocalDrivingLicenseApplication(this.LocalDrivingLicenseApplicationID);
        }

        public static DataTable GetAllLocalDrivingLicenseApplication()
        {
            return clsLocalDrivingLicenseApplicationData.GetAllLocalDrivingLicenseApplications();
        }
        public bool DoesPassTestType(clsTestTypes.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.DoesPassTestType(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public static bool DoesPassTestType(int LocalDrivingLicenseApplicationID, clsTestTypes.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.DoesPassTestType(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public bool DoesAttendTestType(clsTestTypes.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.DoesAttendTestType(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public bool DoesPassPreviousTest(int LocalDrivingLicenseApplicationID, clsTestTypes.enTestType TestTypeID)
        {
            return true;
        }
        public byte TotalTrialsPerTest(clsTestTypes.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.TotalTrialsPerTest(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }
        public static bool TotalTrialsPerTest(int LocalDrivingLicenseApplicationID, clsTestTypes.enTestType TestTypeID)
            {
                        return clsLocalDrivingLicenseApplicationData.TotalTrialsPerTest(LocalDrivingLicenseApplicationID, (int)TestTypeID) >0;  
            }
       public static bool AttendedTest(int LocalDrivingLicenseApplicationID, clsTestTypes.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.DoesAttendTestType(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }
        public  bool AttendedTest(clsTestTypes.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.DoesAttendTestType(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }
        public static bool IsThereAnActiveScheduledTest(int LocalDrivingLicenseApplicationID, clsTestTypes.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.IsThereAnActiveScheduledTest(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }
        public  bool IsThereAnActiveScheduledTest(clsTestTypes.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.IsThereAnActiveScheduledTest(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }
        public clsTests GetLastTestPerTestType(clsTestTypes.enTestType TestTypeID)
        {
            return clsTests.FindLastTestPerPersonAndLicenseClass(this.ApplicantPersonID,LicenseClassID,TestTypeID);
        }

        public byte GetPassedTestCount()
        {
            return clsTests.GetPassedTestCount(this.LocalDrivingLicenseApplicationID);
        }
        public static byte GetPassedTestCount(int LocalDrivingLicenseApplicationID)
        {
            return clsTests.GetPassedTestCount(LocalDrivingLicenseApplicationID);
        }
        public bool PassedAllTests()
        {
            return clsTests.PassedAllTests(this.LocalDrivingLicenseApplicationID);
        }

        public static bool PassedAllTests(int LocalDrivingLicenseApplicationID)
        {
            return clsTests.PassedAllTests(LocalDrivingLicenseApplicationID);
        }
        public int IssueLicenseForTheFirtTime(string Notes, int CreatedByUserID)
        {
            int DrvirID = 0;

            clsDriver driver = clsDriver.FindByPersonID(this.ApplicantPersonID);

            if(driver == null)
            {
                driver = new clsDriver();
                driver.PresonID = ApplicantPersonID;
                driver.CreatedByUserID = CreatedByUserID;
              if(driver.Save())
                {
                    DrvirID = driver.DriverID;
                }
                else
                {
                    DrvirID = -1;
                }
            }
            else
            {
                DrvirID = driver.DriverID;
            }

            clsLicenes licenes = new clsLicenes();

            licenes.DriverID = DrvirID;
            licenes.IssueDate = DateTime.Now;
            licenes.Notes = Notes;
            licenes.ApplicationID = this.ApplicationID;
            licenes.CreatedByUserID = this.CreatedByUserID ;
            licenes.ExpirationDate = DateTime.Now.AddDays(this.LicenseClass.DefaultValidityLength);
            licenes.LicenseClass = this.LicenseClass.LicenseClassID;
            licenes.IsActive = true;
            licenes.PaidFees = this.PaidFees;
            licenes.IssueReason = clsLicenes.enIssueReason.FirstTime;

            if(licenes.Save())
            {
                this.SetComplete();
                return licenes.LicenseID;
            }
            else
             { 
                return -1; 
            }

        }
        public bool IsLicenseIssued()
        {
          return (GetActiveLicenseID() != -1);
        }
        public int GetActiveLicenseID()
        {
            return clsLicenes.GetActiveLicenseIDByPersonID(this.ApplicantPersonID,this.LicenseClassID);
        }
    }
}
