using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsUser
    {
        private enum _enMode { AddNew=0,Update=1};

        _enMode _Mode;


        public int _UserID { get; set; }
        
        public int _PersonID { get; set; }
        
        public string _Username { get; set; }
        
        public string _Password { get; set; }
        
        public bool _IsActive { get; set; }

        public clsUser()
        {
            _UserID = -1;
            _PersonID = -1;
            _Username = string.Empty;
            _Password = string.Empty;
            _IsActive = false;
            _Mode=_enMode.AddNew;
        }

        public clsUser(int UserID,int PersonID,string UserName,string Password,bool IsActive)
        {
            this._UserID = UserID;
            this._PersonID = PersonID;
            this._Username = UserName;
            this._Password = Password;
            this._IsActive = IsActive;
            _Mode = _enMode.Update;
        }

      

        public static bool DeleteUser(int UserID)
        {
            return clsUsersData.DeleteUser(UserID);
        }

        public static bool IsUserExist(int UserID) 
        {
        return clsUsersData.IsUserExistByUserID(UserID);
        }

        public static bool IsUserExistByPersonID(int PersonID)
        {
            return clsUsersData.IsUserExistByPersonID(PersonID);
        }

        private bool AddNewUser()
        {
          this._UserID = clsUsersData.AddNewUser(this._PersonID,this._Username,this._Password,this._IsActive);

          return this._UserID != -1;
        }

        private bool UpdateUser()
        {
            return clsUsersData.UpdateUser(this._UserID, this._PersonID, this._Username, this._Password, this._IsActive);      
        }

        public bool Save()
        {

            switch(_Mode)
            {

                case _enMode.AddNew:
                    {
                        return AddNewUser();
                        
                    }
                case _enMode.Update:
                    {
                        return UpdateUser();
                    }
            }
            return false;
        }

        public static clsUser FindUserByUserID(int UserID)
        {
            string UserName = "", Password = "";
            int PersonID = -1;
            bool isActive = false;
             if(clsUsersData.FindUserByUserID(UserID, ref PersonID, ref UserName, ref Password, ref isActive))
            {
                return new clsUser(UserID,PersonID,UserName,Password,isActive);
            }
            else 
            {
                return null;
            }
        }
 
        public static clsUser FindUserByUserNameAndPassword(string UserName , string Password)
        {
            int UserID = -1, PersonID = -1;
            bool isActive = false;
            if (clsUsersData.FindUserByUserNameAndPassword( UserName, Password,ref UserID,ref PersonID,ref isActive))
            {
                return new clsUser(UserID, PersonID, UserName, Password, isActive);
            }
            else
            {
                return null;
            }
        }
        public static clsUser FindUserByPersonID(int PersonID)
        {
            string Password = "", UserName="";
            int UserID = -1;
            bool isActive = false;
            if (clsUsersData.FindUserByPersonID(PersonID,ref UserID,ref UserName, ref Password, ref isActive))
            {
                return new clsUser(UserID, PersonID, UserName, Password, isActive);
            }
            else
            {
                return null;
            }
        }

        public static DataTable GetUserInfo()
        {
            return clsUsersData.GetUserInfo();
        }
    }
}
