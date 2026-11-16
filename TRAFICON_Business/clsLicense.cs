using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DVLD_Business.clsApplication;

namespace DVLD_Business
{
    public class clsLicense
    {

        public enum enmode { AddNew = 1, Update = 2 }

        private enmode mode;

        public enum enIssueReason { FirstTime = 1, Renew = 2, DamagedReplacement = 3, LostReplacement = 4 };
        public int LicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int LicenseClassID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public float PaidFees { get; set; }
        public bool IsActive { get; set; }
        public byte IssueReason { get; set; }

        public clsDriver DriverInfo { set; get; }
        public clsApplication.enApplicationType ApplicationType { get; set; }

       public  clsDetaindLicnse DetainedInfo { set; get; }

        public  clsLicenseClass LicenseClassInfo { set; get; }

        public string IssueReasonString
        {
            get
            {
                switch (ApplicationType)
                {
                    case enApplicationType.NewDrivingLicense:
                        {
                            return "First Time";
                        }

                    case enApplicationType.ReplaceLostDrivingLicense:
                        {
                            return "Replace Lost License";
                        }
                    case enApplicationType.RenewDrivingLicense:
                        {
                            return "Renew ";
                        }
                    case enApplicationType.NewInternationalLicense:
                        {
                            return "New International License";
                        }
                    case enApplicationType.ReleaseDetainedDrivingLicsense:
                        {
                            return "Release Detained Licsense";
                        }
                    case enApplicationType.ReplaceDamagedDrivingLicense:
                        {
                            return "Release Damaged Licsense";
                        }
                    default:
                        {
                            return "Unkwoun";
                        }
                }

            }
        }


        public int CreatedByUserID { get; set; }

        public bool IsDetained
        {
            get { return clsDetaindLicnse.IsLicenseDetained(this.LicenseID); }
        }
        public clsLicense()
        {
            LicenseID = -1;
            ApplicationID = -1;
            DriverID = -1;
            LicenseClassID = -1;
            IssueDate = DateTime.Now;
            ExpirationDate = DateTime.Now;
            Notes = string.Empty;
            PaidFees = 0;
            IsActive = false;
            IssueReason = 0;
            CreatedByUserID = -1;
            mode = enmode.AddNew;
        }

        public clsLicense(int LicenseID, int ApplicationID, int DriverID, int LicenseClassID, DateTime IssueDate
            , DateTime ExpirationDate, string Notes, float PaidFees, bool IsActive,
            byte IssueReason, int CreatedByUserID)
        {
            this.LicenseID = LicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.LicenseClassID = LicenseClassID;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.Notes = Notes;
            this.PaidFees = PaidFees;
            this.IsActive = IsActive;
            this.IssueReason = IssueReason;
            this.CreatedByUserID = CreatedByUserID;
            mode = enmode.Update;


            this.DetainedInfo = clsDetaindLicnse.FindByLicesneID(this.LicenseID);
            DriverInfo = clsDriver.FindByDriverID(DriverID);
            LicenseClassInfo = clsLicenseClass.GetLicenseClassInfoByID(LicenseClassID);
            ApplicationType = (clsApplication.enApplicationType)IssueReason;

        }


        public static DataTable GetAllLicense()
        {
            return clsLicenseData.GetAllLicenses();
        }

        private bool AddNewLicense()
        {
            this.LicenseID = clsLicenseData.AddNewLicense(ApplicationID,
                DriverID, LicenseClassID, IssueDate, ExpirationDate
                , Notes, PaidFees, IsActive, IssueReason, CreatedByUserID);

            return LicenseID != -1;
        }

        private bool UpdateLicense()
        {
            return clsLicenseData.UpdateLicenseInfo(LicenseID, ApplicationID,
                DriverID, LicenseClassID, IssueDate, ExpirationDate
                , Notes, PaidFees, IsActive, IssueReason, CreatedByUserID);
        }


        public bool Save()
        {
            switch (mode)
            {
                case enmode.Update:
                    {
                        return UpdateLicense();
                    }
                case enmode.AddNew:
                    {
                        if (AddNewLicense())
                        {
                            mode = enmode.Update;
                            return true;
                        }
                        return false;
                    }
            }
            return false;

        }

        public static clsLicense FindByApplicationID(int ApplicationID)
        {
            int LicenseID = -1;
            int DriverID = -1;
            int LicenseClassID = -1;
            DateTime IssueDate = DateTime.Now;
            DateTime ExpirationDate = DateTime.Now;
            string Notes = "";
            float PaidFees = -1;
            bool IsActive = false;
            byte IssueReason = 0;
            int CreatedByUserID = -1;

            if (clsLicenseData.FindByApplicationID(ApplicationID, ref LicenseID, ref DriverID, ref LicenseClassID, ref IssueDate
            , ref ExpirationDate, ref Notes, ref PaidFees, ref IsActive,
          ref IssueReason, ref CreatedByUserID))
            {
                return new clsLicense(LicenseID, ApplicationID, DriverID, LicenseClassID, IssueDate
            , ExpirationDate, Notes, PaidFees, IsActive,
             IssueReason, CreatedByUserID);
            }
            else
            {
                return null;
            }

        }


        public static clsLicense FindByLicenseID(int LicenseID)
        {
            int ApplicationID = -1;
            int DriverID = -1;
            int LicenseClassID = -1;
            DateTime IssueDate = DateTime.Now;
            DateTime ExpirationDate = DateTime.Now;
            string Notes = "";
            float PaidFees = -1;
            bool IsActive = false;
            byte IssueReason = 0;
            int CreatedByUserID = -1;

            if (clsLicenseData.FindByLicenseID(LicenseID, ref ApplicationID, ref DriverID, ref LicenseClassID, ref IssueDate
            , ref ExpirationDate, ref Notes, ref PaidFees, ref IsActive,
          ref IssueReason, ref CreatedByUserID))
            {
                return new clsLicense(LicenseID, ApplicationID, DriverID, LicenseClassID, IssueDate
            , ExpirationDate, Notes, PaidFees, IsActive,
             IssueReason, CreatedByUserID);
            }
            else
            {
                return null;
            }
        }

        public static bool isExistbyLicenseID(int LicenseID)
        {
            return clsLicenseData.IsLicenseExistByLicenseID(LicenseID);
        }
        public static bool IsLicenseExistByPersonID(int PersonID, int LicenseClassID)

        {
            return clsLicenseData.IsLicenseExistByPersonID(PersonID, LicenseClassID);
        }

        public static DataTable GetHistoryLicenseByPersonID(int PersonID)
        {
            return clsLicenseData.GetHistoryLicenseByPersonID(PersonID);
        }

        public static clsLicense FindByDriverID(int DriverID)
        {
            int ApplicationID = -1, LicenseID = -1, LicenseClassID = -1, CreatedByUserID = -1;
            DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
            string Notes = "";
            float PaidFees = 0;
            bool IsActive = false;
            byte IssueReason = 0;
            if (clsLicenseData.FindByDriverID(DriverID, ref ApplicationID, ref LicenseID, ref LicenseClassID, ref IssueDate
           , ref ExpirationDate, ref Notes, ref PaidFees, ref IsActive,
         ref IssueReason, ref CreatedByUserID))
            {
                return new clsLicense(LicenseID, ApplicationID, DriverID, LicenseClassID, IssueDate
            , ExpirationDate, Notes, PaidFees, IsActive,
             IssueReason, CreatedByUserID);
            }
            else { return null; }

        }

        public Boolean IsLicenseExpired()
        {

            return (this.ExpirationDate < DateTime.Now);

        }
        public static string GetIssueReasonText(enIssueReason IssueReason)
        {

            switch (IssueReason)
            {
                case enIssueReason.FirstTime:
                    return "First Time";
                case enIssueReason.Renew:
                    return "Renew";
                case enIssueReason.DamagedReplacement:
                    return "Replacement for Damaged";
                case enIssueReason.LostReplacement:
                    return "Replacement for Lost";
                default:
                    return "First Time";
            }
        }


        public bool DeactivateCurrentLicense()
        {
            return (clsLicenseData.DeactivateLicense(this.LicenseID));
        }
        public int Detain(float FineFees, int CreatedByUserID)
        {
            clsDetaindLicnse detainedLicense = new clsDetaindLicnse();
            detainedLicense.LicenseID = this.LicenseID;
            detainedLicense.DetainDate = DateTime.Now;
            detainedLicense.FineFees = Convert.ToSingle(FineFees);
            detainedLicense.CreatedByUserID = CreatedByUserID;

            if (!detainedLicense.Save())
            {

                return -1;
            }

            return detainedLicense.DetainID;

        }

        public bool ReleaseDetainedLicense(int ReleasedByUserID, ref int ApplicationID)
        {

            //First Create Applicaiton 
            clsApplication Application = new clsApplication();

            Application.ApplicantPersonID = this.DriverInfo._PersonID;
            Application.ApplicationDate = DateTime.Now;
            Application.ApplicationTypeID = (int)clsApplication.enApplicationType.ReleaseDetainedDrivingLicsense;
            Application.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            Application.LastStatusDate = DateTime.Now;
            Application.PaidFees = clsApplicationType.Find((int)clsApplication.enApplicationType.ReleaseDetainedDrivingLicsense).Fees;
            Application.CreatedByUserID = ReleasedByUserID;

            if (!Application.Save())
            {
                ApplicationID = -1;
                return false;
            }

            ApplicationID = Application.ApplicationID;


            return this.DetainedInfo.ReleaseDetainedLicense(ReleasedByUserID, Application.ApplicationID);

        }

        public clsLicense RenewLicense(string Notes, int CreatedByUserID)
        {

            clsApplication Application = new clsApplication();

            Application.ApplicantPersonID = this.DriverInfo._PersonID;
            Application.ApplicationDate = DateTime.Now;
            Application.ApplicationTypeID = (int)clsApplication.enApplicationType.RenewDrivingLicense;
            Application.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            Application.LastStatusDate = DateTime.Now;
            Application.PaidFees = clsApplicationType.Find((int)clsApplication.enApplicationType.RenewDrivingLicense).Fees;
            Application.CreatedByUserID = CreatedByUserID;

            if (!Application.Save())
            {
                return null;
            }

            clsLicense NewLicense = new clsLicense();

            NewLicense.ApplicationID = Application.ApplicationID;
            NewLicense.DriverID = this.DriverID;
            NewLicense.LicenseClassID = this.LicenseClassID;
            NewLicense.IssueDate = DateTime.Now;

            int DefaultValidityLength = this.LicenseClassInfo.DefaultValidityLength;

            NewLicense.ExpirationDate = DateTime.Now.AddYears(DefaultValidityLength);
            NewLicense.Notes = Notes;
            NewLicense.PaidFees = this.LicenseClassInfo.ClassFees;
            NewLicense.IsActive = true;
            NewLicense.IssueReason = Convert.ToByte (clsLicense.enIssueReason.Renew);
            NewLicense.CreatedByUserID = CreatedByUserID;


            if (!NewLicense.Save())
            {
                return null;
            }

            DeactivateCurrentLicense();

            return NewLicense;
        }

        public clsLicense Replace(enIssueReason IssueReason, int CreatedByUserID)
        {


            //First Create Applicaiton 
            clsApplication Application = new clsApplication();

            Application.ApplicantPersonID = this.DriverInfo._PersonID;
            Application.ApplicationDate = DateTime.Now;

            Application.ApplicationTypeID = (IssueReason == enIssueReason.DamagedReplacement) ?
                (int)clsApplication.enApplicationType.ReplaceDamagedDrivingLicense :
                (int)clsApplication.enApplicationType.ReplaceLostDrivingLicense;

            Application.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            Application.LastStatusDate = DateTime.Now;
            Application.PaidFees = clsApplicationType.Find(Application.ApplicationTypeID).Fees;
            Application.CreatedByUserID = CreatedByUserID;

            if (!Application.Save())
            {
                return null;
            }

            clsLicense NewLicense = new clsLicense();

            NewLicense.ApplicationID = Application.ApplicationID;
            NewLicense.DriverID = this.DriverID;
            NewLicense.LicenseClassID = this.LicenseClassID;
            NewLicense.IssueDate = DateTime.Now;
            NewLicense.ExpirationDate = this.ExpirationDate;
            NewLicense.Notes = this.Notes;
            NewLicense.PaidFees = 0;
            NewLicense.IsActive = true;
            NewLicense.IssueReason = Convert.ToByte (IssueReason);
            NewLicense.CreatedByUserID = CreatedByUserID;



            if (!NewLicense.Save())
            {
                return null;
            }

            DeactivateCurrentLicense();

            return NewLicense;
        }

    }
}
