using SLDVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SLDVLD_Buisness.clsPerson;

namespace SLDVLD_Buisness
{
    public class UserViewModel
    {

        public int UserID { get; set; }
        public int PersonID { get; set; }
        public string fullName { get; set; }
        public string UserName { get; set; }
        public bool IsActive { get; set; }
      

        clsPerson PersonInfo;
        public UserViewModel(int UserID, int PersonID, string UserName, bool IsActive)
        {
            this.UserID = UserID;
            this.PersonID = PersonID;
            this.UserName = UserName;
            this.IsActive = IsActive;
            this.PersonInfo = clsPerson.Find(PersonID);
            fullName = PersonInfo.FullName;
          
        }

        public UserViewModel()
        {
            this.UserID = 0;
            this.PersonID = 0;
            this.UserName = "";
            this.IsActive = true;
           
           
        }

        public static DataTable GetAllUsers()
        {
            return clsUserDates.GetAllUsers();
        }
        ///
        public static List<UserViewModel> GetAllDataUserLst()
        {
            List<UserViewModel> listuser = new List<UserViewModel>();

            DataTable dtuser = GetAllUsers();

            foreach (DataRow row in dtuser.Rows)
            {
                UserViewModel selectuser = UserViewModel.FindByUserIDAndignorePassword((int)row[0]);

                if (selectuser != null)
                {
                    listuser.Add(selectuser);
                }
            }
            return listuser;
        }


        public static UserViewModel FindByUserIDAndignorePassword(int UserID)
        {
            int PersonID = 0;
            string UserName = "", Password = "";
            bool IsActive = false;
            bool ISFound = false;


            ISFound = clsUserDates.GetUserInfoByUserID(UserID, ref PersonID, ref UserName, ref IsActive, ref Password);

            if (ISFound)
                return new UserViewModel(UserID, PersonID, UserName, IsActive);

            else
                return null;
        }
    }
}
