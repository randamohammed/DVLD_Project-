using SLDVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLDVLD_Buisness
{
    public class clsDriver
    {
        public int DriverID {  get; set; }
        public int PresonID { get; set; }
        public  clsPerson SelectPersonInfo;

        public int CreatedByUserID { get; set; }
        public DateTime CreatedDate {  get; set; }

        enum enMode { AddNew=0, UpdateNew=1 }
        enMode Mode;

        public clsDriver()
        {
            DriverID = -1;
            PresonID = -1;
            CreatedByUserID = -1;
            CreatedDate = DateTime.Now;
            Mode = enMode.AddNew;
        }

        public clsDriver(int DriverID,int PresonID,int CreatedByUserID,DateTime CreatedDate)
        {
            this.DriverID = DriverID;
            this.PresonID = PresonID;
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedDate = DateTime.Now;
            SelectPersonInfo = clsPerson.Find(PresonID);
            Mode = enMode.UpdateNew;
        }
        
        public static clsDriver FindByID(int DriverID)
        {
            int PersonID = -1, CreatedByUserId = -1;
            DateTime CreatedDate = DateTime.Now;

            bool Isfound = clsDriverData.FinidDriverID(DriverID,ref PersonID,ref CreatedByUserId,ref CreatedDate);

            if (Isfound)
            {
                return new clsDriver(DriverID, PersonID, CreatedByUserId, CreatedDate);
            }
            else
                return null;
        }

        public static clsDriver FindByPersonID(int PresonID)
        {
            int DriverID = -1, CreatedByUserId = -1;
            DateTime CreatedDate = DateTime.Now;

            bool Isfound = clsDriverData.FnidDriverByPresonID(PresonID, ref DriverID, ref CreatedByUserId, ref CreatedDate);

            if (Isfound)
            {
                return new clsDriver(DriverID, PresonID, CreatedByUserId, CreatedDate);
            }
            else
                return null;
        }
        private bool _AddNewDriver()
        {
            this.DriverID = clsDriverData.AddNewDriver(this.CreatedByUserID, this.PresonID);

            return this.DriverID != -1;
        }
     
        private bool _UpdateDriver()
        {
            return clsDriverData.UpdateDriver(this.DriverID,this.PresonID,this.CreatedByUserID);
        }
        public static DataTable GetAdllDrivers()
        {
            return clsDriverData.GetAllDrivers();
        }
        public static DataTable GetLicenses(int DriverID)
        {
            return clsLicenes.GetDriverLicenses(DriverID);
        }
        public bool Save()
        {
            switch(Mode)
            {
                case enMode.AddNew:
                    {
                        if(_AddNewDriver())
                        {
                            Mode = enMode.UpdateNew;
                            return true;
                        }
                        else
                            return false;
                    }
                    case enMode.UpdateNew:
                    return _UpdateDriver();
            }
            return false;
        }

    
    }
}
