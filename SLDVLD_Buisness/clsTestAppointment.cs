using SLDVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLDVLD_Buisness
{
    public class clsTestAppointment
    {

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int TestAppointmentID { set; get; }
        public clsTestTypes.enTestType TestTypeID { set; get; }
        public int LocalDrivingLicenseApplicationID { set; get; }
        public DateTime AppointmentDate { set; get; }
        public float PaidFees { set; get; }
        public int CreatedByUserID { set; get; }
        public bool IsLocked { set; get; }
        public int RetakeTestApplicationID { set; get; }
        public clsApplication RetakeTestAppInfo { set; get; }
        public int TestID
        {
            get { return GetTestID(); }
        }
     
        public clsTestAppointment()
        {
            TestAppointmentID = -1;
            IsLocked = false;
            CreatedByUserID = -1;
            RetakeTestApplicationID = -1;
            TestTypeID = clsTestTypes.enTestType.VisionTes;
            PaidFees = 0;
            AppointmentDate = DateTime.Now;
            LocalDrivingLicenseApplicationID = 0;
            Mode = enMode.AddNew;
            
        }

        public clsTestAppointment(int TestAppointmentID, int LocalDrivingLicenseApplicationID,int CreatedByUserID,
            int RetakeTestApplicationID,clsTestTypes.enTestType TestTypeID,bool IsLocked,float PaidFees,DateTime AppointmentDate)
        {
           this.TestAppointmentID = TestAppointmentID;
           this.IsLocked = IsLocked;
           this.CreatedByUserID = CreatedByUserID;
           this.RetakeTestApplicationID = RetakeTestApplicationID;
           this.TestTypeID = TestTypeID;
           this.PaidFees = PaidFees;
           this.AppointmentDate = AppointmentDate;
           this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            RetakeTestAppInfo = clsApplication.FindBaseApplication(RetakeTestApplicationID);
            Mode = enMode.Update;
        }
   
        private bool _AddNewTestAppointment()
        {
            this.TestAppointmentID = clsTestAppointmentData.AddNewTestAppointment((int)this.TestTypeID, this.RetakeTestApplicationID, this.CreatedByUserID,
                this.LocalDrivingLicenseApplicationID, this.AppointmentDate, this.IsLocked, this.PaidFees);

            return this.TestAppointmentID != -1;
        }

        private bool _UpdateTestAppointment()
        {
            return clsTestAppointmentData.UpdateTestAppointment(this.TestAppointmentID,(int)this.TestTypeID, this.RetakeTestApplicationID, this.CreatedByUserID,
                this.LocalDrivingLicenseApplicationID, this.AppointmentDate, this.IsLocked, this.PaidFees);
        }
        private int GetTestID()
        {
            return clsTestAppointmentData.GetTestID(this.TestAppointmentID);
        }

        public static clsTestAppointment Find(int TestAppointmentID)
        {
            int CreatedByUserID = 0, LocalDrivingLicenseApplicationID = 0, RetakeTestApplicationID = 0, TestTypeID =0;
           ;
            float PaidFees = 0;
            DateTime AppointmentDate = DateTime.Now;
            bool IsLocked = false;

            bool ISfound = clsTestAppointmentData.GetTestAppointmentInfoByID(TestAppointmentID,ref CreatedByUserID, ref IsLocked,ref LocalDrivingLicenseApplicationID,
               ref RetakeTestApplicationID,ref TestTypeID,ref PaidFees,ref AppointmentDate);

            if (ISfound)
            {
                return new clsTestAppointment(TestAppointmentID, LocalDrivingLicenseApplicationID, CreatedByUserID,
                    RetakeTestApplicationID, (clsTestTypes.enTestType)TestTypeID, IsLocked, PaidFees, AppointmentDate);
            }
            else
                return null;
        }
    
        public static clsTestAppointment GetLastTestAppointment(int LocalDrivingLicenseApplicationID,clsTestTypes.enTestType TestTypeID)
        {
            int CreatedByUserID = 0, TestAppointmentID = 0, RetakeTestApplicationID = 0 ;
            ;
            float PaidFees = 0;
            DateTime AppointmentDate = DateTime.Now;
            bool IsLocked = false;

            bool ISfound = clsTestAppointmentData.GetLastTestAppointment(ref TestAppointmentID, ref CreatedByUserID, ref IsLocked,  LocalDrivingLicenseApplicationID,
               ref RetakeTestApplicationID,  (int)TestTypeID, ref PaidFees, ref AppointmentDate);

            if (ISfound)
            {
                return new clsTestAppointment(TestAppointmentID, LocalDrivingLicenseApplicationID, CreatedByUserID,
                    RetakeTestApplicationID, TestTypeID, IsLocked, PaidFees, AppointmentDate);
            }
            else
                return null;
        }
   
    
        public static DataTable GetAllTestAppointments()
        {
            return clsTestAppointment.GetAllTestAppointments();
        }

        public static DataTable GetApplicationTestAppointmentsPerTestType(int LocalDrivingLicenseApplicationID, clsTestTypes.enTestType TestTypeID)
        {
            return clsTestAppointmentData.GetApplicationTestAppointmentsPerTestType(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }
        
        public DataTable GetApplicationTestAppointmentsPerTestType(clsTestTypes.enTestType TestTypeID)
        {
            return clsTestAppointmentData.GetApplicationTestAppointmentsPerTestType(this.LocalDrivingLicenseApplicationID,(int)TestTypeID);
        }

        public bool Save()
        {
            switch(Mode)
            {
                case enMode.AddNew:
                    {
                        if(_AddNewTestAppointment())
                        {
                            Mode = enMode.Update;
                            return true;
                        }
                        else
                            return false;
                    }
                    case enMode.Update: 
                     return _UpdateTestAppointment();
            }
            return false;
        }
    }
}
