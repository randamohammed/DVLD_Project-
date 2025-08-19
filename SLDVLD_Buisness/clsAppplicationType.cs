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
        
        public int ApplicationTypeIID {  get; set; }
        public string Title { get; set; }
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
        public static async Task< DataTable> GetAllApplicationnTypes()
        {
            return await clsApplicationTypeData.GetAllApplicationTypes();
        }

        public static async Task<List<clsAppplicationType>> GetAllApplicationnTypesInList()
        {
            DataTable table =await GetAllApplicationnTypes();

            List<clsAppplicationType> list = new List<clsAppplicationType>();
            foreach(DataRow row in table.Rows)
            {
                clsAppplicationType AppplicationType = clsAppplicationType.Find((int)row["ApplicationTypeID"]);

                if(AppplicationType != null )
                {
                    list.Add(AppplicationType);
                }
            }
            return  list;
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
