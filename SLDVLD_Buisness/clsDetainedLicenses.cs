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
    public class clsDetainedLicenses
    {
        public int DetainID { get; set; }
        public int ReleaseApplicationID { get; set; }
        public int ReleasedByUserID { get; set; }
        clsUsers2 ReleasedByUserInfo;
        public DateTime ReleaseDate { get; set; }
        public bool IsReleased { get; set; }
        public int CreatedByUserID { get; set; }
        public clsUsers2 CreatedByUserInfo;
        public float FineFees { get; set; }
        public DateTime DetainDate { get; set; }
        public int LicenseID { get; set; }

        enum enMode { AddNew = 0, Update = 1 };
        enMode Mode = enMode.AddNew;

        public clsDetainedLicenses()
        {
            DetainID = -1;
            ReleaseApplicationID = 1;
            ReleaseDate = DateTime.Now;
            ReleasedByUserID = -1;
            IsReleased = false;
            CreatedByUserID = -1;
            FineFees = 0;
            DetainDate = DateTime.Now;
            LicenseID = -1;
            Mode = enMode.AddNew;

        }

        public clsDetainedLicenses(int DetainID,
            int LicenseID, DateTime DetainDate,
            float FineFees, int CreatedByUserID,
            bool IsReleased, DateTime ReleaseDate,
            int ReleasedByUserID, int ReleaseApplicationID)

        {
            this.DetainID = DetainID;
            this.ReleaseApplicationID = ReleaseApplicationID;
            this.ReleaseDate = ReleaseDate;
            this.ReleasedByUserID = ReleasedByUserID;
            ReleasedByUserInfo = clsUsers2.FindByUserID(ReleaseApplicationID);
            this.IsReleased = IsReleased;
            this.CreatedByUserID = CreatedByUserID;
            CreatedByUserInfo = clsUsers2.FindByUserID(CreatedByUserID);
            this.FineFees = FineFees;
            this.DetainDate = DetainDate;
            this.LicenseID = LicenseID;
            Mode = enMode.Update;

        }
      
        private bool _AddNewDetainedLicense()
        {
            this.DetainID = clsDetainedLicenseData.AddNewDetainedLicense(this.LicenseID, this.DetainDate, this.FineFees, this.CreatedByUserID);

            return this.DetainID != -1;
        }
        private bool _UpdateDetainedLicense()
        {
            return clsDetainedLicenseData.UpdateDetainedLicense(this.DetainID, this.LicenseID, this.DetainDate
                , this.FineFees, this.CreatedByUserID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewDetainedLicense())
                        {
                            Mode = enMode.Update;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                case enMode.Update:
                    return _UpdateDetainedLicense();
            }
            return false;


        }
    
        public static DataTable GetAllDetainedLicenses()
        {
            return clsDetainedLicenseData.GetAllDetainedLicenses();

        }

        public static clsDetainedLicenses Find(int DetainID)
        {
            int LicenseID = -1; DateTime DetainDate = DateTime.Now;
            float FineFees = 0; int CreatedByUserID = -1;
            bool IsReleased = false; DateTime ReleaseDate = DateTime.MaxValue;
            int ReleasedByUserID = -1; int ReleaseApplicationID = -1;

            bool IsFound = clsDetainedLicenseData.GetDetainedLicenseInfoByID(DetainID,ref LicenseID,ref DetainDate,ref FineFees,ref CreatedByUserID,
                ref IsReleased,ref ReleaseDate, ref ReleasedByUserID,ref ReleaseApplicationID);

            if (IsFound)
            {
                return new clsDetainedLicenses(DetainID, LicenseID, DetainDate, FineFees, CreatedByUserID,
              IsReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID);
            }
            else
                return null;
        }

        public static clsDetainedLicenses FindByLicenesID(int LicenseID)
        {
            int DetainID = -1; DateTime DetainDate = DateTime.Now;
            float FineFees = 0; int CreatedByUserID = -1;
            bool IsReleased = false; DateTime ReleaseDate = DateTime.MaxValue;
            int ReleasedByUserID = -1; int ReleaseApplicationID = -1;

            bool IsFound = clsDetainedLicenseData.GetDetainedLicenseInfoByLicenseID(LicenseID,ref DetainID, ref DetainDate, ref FineFees, ref CreatedByUserID,
                ref IsReleased, ref ReleaseDate, ref ReleasedByUserID, ref ReleaseApplicationID);

            if (IsFound)
            {
                return new clsDetainedLicenses(DetainID, LicenseID, DetainDate, FineFees, CreatedByUserID,
              IsReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID);
            }
            else
                return null;
        }
        public static bool IsLicenseDetained(int LicenseID)
        {
            return clsDetainedLicenseData.IsLicenseDetained(LicenseID);
        }

        public bool ReleaseDetainedLicense( int ReleaseApplicationID,int ReleasedByUserID)
        {
            return clsDetainedLicenseData.ReleaseDetainedLicense(this.DetainID, ReleasedByUserID, ReleaseApplicationID);
        }
    }
}
