using SLDVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLDVLD_Buisness
{
    public class clsPerson
    {
        public int PersonID { get; set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get { return FirstName + ' ' + SecondName + ' ' + ThirdName + ' ' + LastName; }
        }
        public DateTime DateOfBirth { get; set; }
        public short Gendor { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int NationalityCountryID { get; set; }
        string _ImagePath = "";

        public clsCountry CountryInfo;

       public enum _Mode { Addnewperson=0,UpdatePreson =1};
       public _Mode Mode  = _Mode.Addnewperson;

        public string ImagePath
        {
          
            get{return _ImagePath;  }
            set { _ImagePath = value; }
        }

    
        public clsPerson()
        {
            PersonID = 0;
            NationalNo = "";
            FirstName = "";
            SecondName = "";
            ThirdName = "";
            LastName = "";
            DateOfBirth = DateTime.Now;
            Gendor = 0;
            Address = "";
            Phone = "";
            Email = "";
            ImagePath = "";
            NationalityCountryID = 0;
            Mode = _Mode.Addnewperson;
        }
        public clsPerson(int PersonID, string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName,
            DateTime DDateOfBirth, short Gendor, string Address, string Phone, string Email, int NationalityCountryID, string ImagePath)
        {
            this.DateOfBirth = DDateOfBirth;
          this.PersonID = PersonID;
          this.NationalNo = NationalNo;
          this.FirstName =FirstName;
          this.SecondName = SecondName;
          this.ThirdName = ThirdName;
          this.LastName = LastName;
          this.DateOfBirth = DateOfBirth;
          this.Gendor =Gendor;
          this.Address =Address;
          this.Phone = Phone;
          this.Email =Email;
          this.NationalityCountryID = NationalityCountryID;
          this.ImagePath = ImagePath;
          this.CountryInfo  =clsCountry.Find(NationalityCountryID);
            Mode = _Mode.UpdatePreson;
        }

        private bool _AddNewPerson()
        {
            this.PersonID = clsPersonData.AddNewPerson(this.NationalNo, this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.DateOfBirth,
                this.ImagePath, this.Email, this.Address, this.Phone, this.NationalityCountryID,this.Gendor);

            return this.PersonID != -1;
        }

        private bool _UpdatePerson()
        {
            return clsPersonData.Update(this.PersonID, this.NationalNo, this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.DateOfBirth,
                this.ImagePath, this.Email, this.Address, this.Phone, this.NationalityCountryID, this.Gendor);
        }

        public static clsPerson Find(int PersonID)
        {
            string NationalNo = "", ImagePath = "", FirstName = " ", SecondName = "", ThirdName ="", LastName ="",
               Address = " ", Phone = "", Email = "";
            short Gendor = 0;
            int NationalityCountryID =0;
            DateTime DDateOfBirth =DateTime.Now;

            if (clsPersonData.FindPersonByID(PersonID, ref NationalNo, ref FirstName, ref SecondName, ref ThirdName, ref LastName,
            ref DDateOfBirth, ref ImagePath, ref Email,ref Address , ref Phone,ref NationalityCountryID, ref Gendor))
            {
                return new clsPerson(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName,
             DDateOfBirth, Gendor, Address, Phone, Email, NationalityCountryID, ImagePath);
            }
            else
                return null;

        }

        public static clsPerson Find(string NationalNo)
        {
            string  ImagePath = "", FirstName = " ", SecondName = "", ThirdName = "", LastName = "",Address = " ", Phone = "", Email = "";
            short Gendor = 0;
            int NationalityCountryID = 0, PersonID =0;
            DateTime DateOfBirth = DateTime.Now;

            bool IsFound = clsPersonData.FindPersonByNationalNo(NationalNo, ref PersonID, ref FirstName, ref SecondName, ref ThirdName, ref LastName,
             ref DateOfBirth, ref ImagePath, ref Email, ref Address, ref Phone, ref NationalityCountryID, ref Gendor);

            if(IsFound)
            {
                return new clsPerson(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName,
             DateOfBirth, Gendor, Address, Phone, Email, NationalityCountryID, ImagePath);
            }
            else
                return null;

        }
        public static DataTable GetAllPerson()
        {
            return clsPersonData.GetAllPeople();
        }

        public static bool ISPeresonExist(int PersonID)
        {
            return clsPersonData.ISPersonExist(PersonID);
        }

        public static bool ISPeresonExist(string NationalNo)
        {
            return clsPersonData.IsPersonExist(NationalNo);
        }

        public static bool DeletePerson(int PersonID)
        {
            return clsPersonData.DeletePerson(PersonID);
        }
        public bool   Save()
        {
            switch(Mode)
            {
                case _Mode.Addnewperson:
                    {
                        if(_AddNewPerson())
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                case _Mode.UpdatePreson:
                    return _UpdatePerson();
            }
            return false;
        }

    }
}
