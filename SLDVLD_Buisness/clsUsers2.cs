using SLDVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLDVLD_Buisness
{
    public class clsUsers2
    {
        public int UserID { get; set; }
        public int PersonID { get; set; }
        public string UserName { get; set; }
        public bool IsActive { get; set; }
        public string Password { get; set; }
        enum _Mode { Add = 0, Update = 1 };
        _Mode Mode;

        clsPerson PersonInfo;


        public clsUsers2()
        {
            this.UserID = 0;
            this.PersonID = 0;
            this.UserName = "";
            this.Password = "";
            this.IsActive = true;
            this.Mode = _Mode.Add;
        }
        public clsUsers2(int UserID, int PersonID, string UserName, string Password, bool IsActive)
        {
            this.UserID = UserID;
            this.PersonID = PersonID;
            this.UserName = UserName;
            this.Password = Password;
            this.IsActive = IsActive;
            this.PersonInfo = clsPerson.Find(PersonID);
            this.Mode = _Mode.Update;
        }

        private bool AddUser()
        {
            this.UserID = clsUserDates.AddUser(this.PersonID, this.UserName, this.IsActive, this.Password);

            return (this.UserID != -1);
        }
        private bool UpdateUser()
        {
            return clsUserDates.Update(this.UserID, this.PersonID, this.UserName, this.IsActive, this.Password);
        }

        public static DataTable GetAllUsers()
        {
            return clsUserDates.GetAllUsers();
        }

        public static bool DeleteUser(int UserID)
        {
            return clsUserDates.DeleteUser(UserID);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case _Mode.Add:
                    {
                        if (AddUser())
                        {
                            Mode = _Mode.Update;
                            return true;
                        }
                        else
                            return false;
                    }
                case _Mode.Update:
                    return UpdateUser();
            }
            return false;
        }

        public static clsUsers2 FindByUserID(int UserID)
        {
            int PersonID = 0;
            string UserName = "", Password = "";
            bool IsActive = false;
            bool ISFound = false;

            ISFound = clsUserDates.GetUserInfoByUserID(UserID, ref PersonID, ref UserName, ref IsActive, ref Password);

            if (ISFound)
                return new clsUsers2(UserID, PersonID, UserName, Password, IsActive);

            else
                return null;
        }

        public static clsUsers2 FindByPersonID(int PersonID)
        {
            int UserID = 0;
            string UserName = "", Password = "";
            bool IsActive = false;
            bool ISFound = false;

            ISFound = clsUserDates.GetUserInfoByPersonID(ref UserID, PersonID, ref UserName, ref IsActive, ref Password);

            if (ISFound)
                return new clsUsers2(UserID, PersonID, UserName, Password, IsActive);

            else
                return null;
        }

        public static clsUsers2 FindByUsernameAndPassword(string Username, string Password)
        {
            int PersonID = 0, UserID = 0;
            bool IsActive = false;
            bool ISFound = false;

            ISFound = clsUserDates.GetUserInfoByUsernameAndPassword(ref UserID, ref PersonID, Username, ref IsActive, Password);

            if (ISFound)
                return new clsUsers2(UserID, PersonID, Username, Password, IsActive);

            else
                return null;
        }

        public static bool ISUserEXits(int UserID)
        {
            return clsUserDates.ISUserExist(UserID);
        }

        public static bool ISUserEXits(string UserName)
        {
            return clsUserDates.ISUserExist(UserName);
        }

        public static bool IsUserExistForPersonID(int UserID)
        {
            return clsUserDates.IsUserExistForPersonID(UserID);
        }

        public static bool ChanagePassword(int UserID,string Password)
        {
            return clsUserDates.ChanagePassword(UserID, Password);
        }

    }
}
