using SLDVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLDVLD_Buisness
{
    public class clsLicenseClass
    {
        public int LicenseClassID {  get; set; }
        public float ClassFees { get; set; }
        public string ClassName { get; set; }
        public string Description { get; set; }
        public byte MinimumAllowedAge { get; set; }
        public byte DefaultValidityLength { get; set; }

        enum enMode { AddNew =0,Update =1};
        enMode Mode = enMode.AddNew;
        public clsLicenseClass(int LicenseClassID,float ClassFees,string ClassName,string Description,byte MinimumAllowedAge,byte DefaultValidityLength)
        {
            this.LicenseClassID = LicenseClassID;
            this.ClassFees = ClassFees;
            this.ClassName = ClassName;
            this.Description = Description;
            this.MinimumAllowedAge = MinimumAllowedAge;
            this.DefaultValidityLength = DefaultValidityLength;
          Mode=  enMode.Update;
        }

        public clsLicenseClass()
        {
            this.LicenseClassID = 0;
            this.ClassFees = 0;
            this.ClassName = "";
            this.Description = "";
            this.MinimumAllowedAge = 0;
            this.DefaultValidityLength = 0;
            Mode = enMode.AddNew;
        }
   
         private bool _AddNewLicenesClass()
         {
            this.LicenseClassID = clsLicenseClassesData.AddNewLicenseClass(this.ClassName, this.Description,
                this.MinimumAllowedAge, this.DefaultValidityLength, this.ClassFees);

            return this.LicenseClassID != -1;
         }

        private bool _UpdateLicenesClass()
        {
            return clsLicenseClassesData.UpdateLicenseClass(this.LicenseClassID, this.ClassName,
                this.Description, this.MinimumAllowedAge, this.DefaultValidityLength, this.ClassFees);
        }   
        public static  DataTable GetAllLicenesClass()
        {
            return clsLicenseClassesData.GetAllLicenseClasses();
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewLicenesClass())
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
                    return _UpdateLicenesClass();
            }
            return false;
        }
    
        public static clsLicenseClass GetLicenseClassInfoByClassName(string ClassName)
        {
            int LicenseClassID = 0;
            float ClassFees = 0;
            string  Description = "";
            byte MinimumAllowedAge = 0, DefaultValidityLength = 0;

            bool ISfound  = clsLicenseClassesData.GetLicenseClassInfoByClassName(ref LicenseClassID,ref DefaultValidityLength,ref MinimumAllowedAge,ref ClassFees,
                 ClassName,ref Description);

            if (ISfound)
            {
                return new clsLicenseClass(LicenseClassID, ClassFees, ClassName, Description, MinimumAllowedAge, DefaultValidityLength);
            }
            else
                return null;
        }

        public static clsLicenseClass Find(int LicenseClassID)
        {
            float ClassFees = 0;
            string ClassName = "", Description = "";
            byte MinimumAllowedAge = 0, DefaultValidityLength = 0;

            bool ISfound = clsLicenseClassesData.GetLicenseClassInfoByID( LicenseClassID, ref DefaultValidityLength, ref MinimumAllowedAge, ref ClassFees,
                ref ClassName, ref Description);

            if (ISfound)
            {
                return new clsLicenseClass(LicenseClassID, ClassFees, ClassName, Description, MinimumAllowedAge, DefaultValidityLength);
            }
            else
                return null;
        }


    }
}
