using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsDetaindLicnse
    {
        public enum enMode { AddNew = 1 , Update=2}

        enMode mode;

        public int DetainID { get; set; }
        public int LicenseID { get; set; }
       

          public DateTime DetainDate { get; set; }
        public float FineFees { get; set; }
        public int CreatedByUserID { get; set; }
        
        public clsUser UserInfo;
        public bool IsReleased { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int ReleasedByUserID { get; set; }

        public int ReleaseApplicationID{ get; set; }

        public clsDetaindLicnse(
            int DetainID
          , int LicenseID
          , DateTime DetainDate
          , float FineFees
          , int CreatedByUserID
          , bool IsReleased
          , DateTime ReleaseDate
          , int ReleasedByUserID
          , int ReleaseApplicationID)
        {
            this.DetainID = DetainID;
            this.LicenseID = LicenseID;
            this.DetainDate = DetainDate;
            this.FineFees = FineFees;
            this.CreatedByUserID = CreatedByUserID;
            this.IsReleased = IsReleased;
            this.ReleaseDate = ReleaseDate;
            this.ReleasedByUserID = ReleasedByUserID;
            this.ReleaseApplicationID = ReleaseApplicationID;

            UserInfo = clsUser.FindUserByUserID(CreatedByUserID);
        mode= enMode.Update;
        }

        public clsDetaindLicnse()
        {
            DetainID = -1;
            LicenseID = -1;
            DetainDate = DateTime.Now;
            FineFees = -1;
            CreatedByUserID = -1;
            IsReleased = false;
            ReleaseDate = DateTime.Now;
            ReleasedByUserID = -1;
            ReleaseApplicationID = -1;
        
            mode = enMode.AddNew;   
        }

        public static clsDetaindLicnse FindByDetainID(
           int DetainID)
        {
            int LicenseID = -1;
            DateTime DetainDate = DateTime.Now;
            float FineFees = 0;
            int CreatedByUserID =-1 ;
            bool IsReleased = false;
            DateTime ReleaseDate = DateTime.Now;
            int ReleasedByUserID = -1;
            int ReleaseApplicationID = -1 ;
            if(clsDetaindLicenseData.FindByDetainID(
             DetainID
          , ref  LicenseID
          , ref DetainDate
          , ref FineFees
          , ref CreatedByUserID
          , ref IsReleased
          , ref ReleaseDate
          , ref ReleasedByUserID
          , ref ReleaseApplicationID))
            {
                return new clsDetaindLicnse(
             DetainID
          , LicenseID
          , DetainDate
          , FineFees
          , CreatedByUserID
          , IsReleased
          , ReleaseDate
          , ReleasedByUserID
          , ReleaseApplicationID);
            }
            else
            {
                return null;
            }


        }


        public static clsDetaindLicnse FindByLicesneID(
                   int LicenseID)
        {
            int DetainID = -1;
            DateTime DetainDate = DateTime.Now;
            float FineFees = 0;
            int CreatedByUserID = -1;
            bool IsReleased = false;
            DateTime ReleaseDate = DateTime.Now;
            int ReleasedByUserID = -1;
            int ReleaseApplicationID = -1;
            if (clsDetaindLicenseData.FindByLicenseID(
           LicenseID
          , ref DetainID
          , ref DetainDate
          , ref FineFees
          , ref CreatedByUserID
          , ref IsReleased
          , ref ReleaseDate
          , ref ReleasedByUserID
          , ref ReleaseApplicationID))
            {
                return new clsDetaindLicnse(
             DetainID
          , LicenseID
          , DetainDate
          , FineFees
          , CreatedByUserID
          , IsReleased
          , ReleaseDate
          , ReleasedByUserID
          , ReleaseApplicationID);
            }
            else
            {
                return null;
            }


        }

        public static DataTable GetAllDetainedLicenses()
        {
            return clsDetaindLicenseData.GetAllDetainedLicenses();
        }

        private bool AddNewDetainLicense()
        {
            this.DetainID = clsDetaindLicenseData.AddNewDetainedLicense(this.LicenseID,this.DetainDate,
                this.FineFees,this.CreatedByUserID);

            return this.DetainID != -1;
        }

        private bool UpdateDetainLicense()
        {
            return clsDetaindLicenseData.UpdateDetainedLicense(this.DetainID,this.LicenseID,
                this.DetainDate,this.FineFees,this.CreatedByUserID);
          
        }

        public bool Save ()
        {
            switch (mode) 
            {

                case enMode.AddNew:
                    {
                        if(AddNewDetainLicense())
                        {
                            mode = enMode.Update;

                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                case enMode.Update:
                    {
                        return UpdateDetainLicense();
                    }

            }

            return false;   
        }

        public  bool ReleaseDetainedLicense(
               int ReleasedByUserID, int ReleaseApplicationID)
        {

            return clsDetaindLicenseData.ReleaseDetainedLicense(this.DetainID , ReleasedByUserID, ReleaseApplicationID);
        }

        public static bool IsLicenseDetained(int LicenseID) 
        {
        return clsDetaindLicenseData.IsLicenseDetained(LicenseID);
        }

    }
}
