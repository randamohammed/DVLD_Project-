using SLDVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLDVLD_Buisness
{
    public class clsTestTypes
    {
        public int Fees { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        enum _Mode { AddNew =0,Update =1}
        _Mode Mode;

        public enum enTestType { VisionTes =1, WrittenTest =2,StreetTest =3};
        public clsTestTypes.enTestType ID {  get; set; }

      public  clsTestTypes()
        {
            this.ID  = 0;
            Fees = 0;
            Title = "";
            Description = "";
            Mode = _Mode.AddNew;

        }

        public clsTestTypes(clsTestTypes.enTestType ID,int Fees, string Title,string Description)
        {
            this.ID = ID;
            this.Fees = Fees;
            this.Title = Title;
            this.Description = Description;
            Mode = _Mode.Update;
        
        }


        private bool _ADdNewTestType()
        {
            this.ID =(clsTestTypes.enTestType) clsTestTypeData.AddNewtsetType(this.Fees,this.Description,this.Title);

            return this.Title != "";
        }

        private bool _UpdateTestType()
        {
            return clsTestTypeData.UpdateTestType((int) this.ID, this.Description, this.Title, this.Fees);
        }
        public static clsTestTypes FindByID( clsTestTypes.enTestType ID)
        {
            int Fees = 0;
            string Title = "", Description = "";

            bool ISFound = clsTestTypeData.GetTestTypeByID((int)ID, ref Fees, ref Title, ref Description);

            if (ISFound)
            {
                return new clsTestTypes(ID, Fees, Title, Description);
            }
            else
                return null;
        }

        public static DataTable GetAllTestType()
        {
            return clsTestTypeData.GetallTestType();
        }
        public bool Save()
        {
            switch(Mode)
            {
                case _Mode.AddNew:
                    {
                        if(_ADdNewTestType())
                        {
                            Mode = _Mode.Update;
                            return true;
                        }
                        else
                            return false;
                    }
                   
                case _Mode.Update:
                    {
                        return _UpdateTestType();
                    }
            }
            return false;
        }
    }
}
