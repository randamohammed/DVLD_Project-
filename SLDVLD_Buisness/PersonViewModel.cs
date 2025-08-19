using SLDVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace SLDVLD_Buisness
{
    public class PersonViewModel
    {
        public int PersonID { get; set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        
        public string GendorCaption { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string ImagePath { get; set; }
        public string CountryName { get; set; }

        public PersonViewModel()
        {
            PersonID = 0;
            ImagePath = string.Empty;
            CountryName = string.Empty;
            FirstName = string.Empty;
            SecondName = string.Empty;
            ThirdName = string.Empty;
            LastName = string.Empty;
            DateOfBirth = DateTime.MinValue;
            GendorCaption = "" ;
            Address = string.Empty;
            Phone = string.Empty;
            Email = string.Empty;

        }

        public PersonViewModel(int PersonID,string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName,
           DateTime  DDateOfBirth,string Gendor, string Address, string Phone, string Email,int NationalityCountryID, string ImagePath)
        {
           this.ImagePath = ImagePath;
           this.CountryName = CountryName;
           this.FirstName = FirstName;
           this.SecondName = SecondName;
           this.ThirdName =ThirdName;
           this.LastName = LastName;
           this.DateOfBirth = DDateOfBirth;
           this.GendorCaption = Gendor;
           this.Address =Address;
           this.Phone = Phone;
           this.Email = Email;
           this.PersonID = PersonID;
            this.NationalNo = NationalNo;
        }

        public static PersonViewModel Find(int PersonID)
        {
            string NationalNo = "", ImagePath = "", FirstName = " ", SecondName = "", ThirdName = "", LastName = "",
               Address = " ", Phone = "", Email = "";
            string Gendor = "";
            int NationalityCountryID = 0;
            DateTime DDateOfBirth = DateTime.Now;

            if (clsPersonData.FindPersonByIDNamGander(PersonID, ref NationalNo, ref FirstName, ref SecondName, ref ThirdName, ref LastName,
            ref DDateOfBirth, ref ImagePath, ref Email, ref Address, ref Phone, ref NationalityCountryID, ref Gendor))
            {
                return new PersonViewModel(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName,
             DDateOfBirth, Gendor, Address, Phone, Email, NationalityCountryID, ImagePath);
            }
            else
                return null;

        }

        public static async Task<List<PersonViewModel>> GetAllPersonInList()
        {

            DataTable  AllPerson =await clsPersonData.GetAllPeople();

            List<PersonViewModel> list = new List<PersonViewModel>();

            foreach (DataRow person in AllPerson.Rows)
            {
                if(person != null)
                {

                    PersonViewModel person1 = PersonViewModel.Find((int)person[0]);
                    list.Add(person1);
                }
            }
            return  list;
        }
    }
}
