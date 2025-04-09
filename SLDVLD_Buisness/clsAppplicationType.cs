using SLDVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLDVLD_Buisness
{
    public   class clsAppplicationType
    {
        public string Title {  get; set; }
        public int ApplicationTypeIID {  get; set; }
       public float Fees { get; set; }

        enum eMoode { AddNew =0,Update =1};
        eMoode Moode;

        public clsAppplicationType()
        {
            Title = "";
            Fees = 0;
            ApplicationTypeIID = 0;
            Moode = eMoode.AddNew;
        }

        public clsAppplicationType(int ApplicationTypeID,string Titlle, float Fees)
        {
            this.ApplicationTypeIID = ApplicationTypeID;
            this.Title = Titlle;
            this.Fees = Fees;
            Moode = eMoode.Update;
        }

        public static clsAppplicationType Find(int ApplicationTypeID)
        {
            string Tilte = "";
            float Fees = 0;

            bool ISFound = clsApplicationTypeData.GetApplicationTypeIInfoByID(ApplicationTypeID,ref Tilte,ref Fees);

            if (ISFound)
                return new clsAppplicationType(ApplicationTypeID, Tilte, Fees);
            else
                return null;

        }

        private bool _AddNewApplictionType()
        {
            this.ApplicationTypeIID = clsApplicationTypeData.AddNewApplicationType(this.Title, this.Fees);

            return (this.ApplicationTypeIID != -1);
        }

        private bool _UpdateApplicationType()
        {
            return clsApplicationTypeData.UpdateApplicationType(this.ApplicationTypeIID,this.Title,this.Fees);
        }
        public static DataTable GetAllApplicationnTypes()
        {
            return clsApplicationTypeData.GetAllApplicationTypes();
        }

        public bool Save()
        {
            switch(Moode)
            {
                case eMoode.AddNew:
                    {
                        if(_AddNewApplictionType())
                        {
                            Moode = eMoode.Update;
                            return true;
                        }
                        else
                            return false;
                    }
                    case eMoode.Update:
                    return _UpdateApplicationType();
            }
            return false;
        }
    }
}
