using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsApplicationType
    {

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;


        public int ID { set; get; }
        public string Title { set; get; }
        public float Fees { set; get; }

        public clsApplicationType()
        {
            Title = string.Empty;
            Fees = 0;
            Mode = enMode.AddNew;
        }
        public clsApplicationType(int ID, string Title, float Fees)
        {
            this.ID = ID;
            this.Title = Title;
            this.Fees = Fees;
            Mode = enMode.Update;
        }

        public static DataTable GetAllApplicationType()
        {
            return clsApplicationTypeData.GetAllApplicationType();
        }

        public static clsApplicationType Find(int ApplicationTypeID)
        {
            string ApplicationTypeTitle = "";
            float ApplicationFees = 0;

            if (clsApplicationTypeData.GetApplicationTypeByApplicationTypeID(ApplicationTypeID
     , ref ApplicationTypeTitle
     , ref ApplicationFees))

            {
                return new clsApplicationType(ApplicationTypeID, ApplicationTypeTitle, ApplicationFees);
            }
            else
            {
                return null;
            }
        }

        private bool AddNewApplicationType()
        {
            this.ID = clsApplicationTypeData.AddNewApplicationType(this.Title, this.Fees);
            return this.ID != -1;

        }

        private bool UpdateApplicationType()
        {
            return clsApplicationTypeData.UpdateApplicationType(this.ID, this.Title, this.Fees);
        }



        public bool Save()
        {

            switch (this.Mode)
            {

                case enMode.AddNew:
                    {
                        if (AddNewApplicationType())
                        {
                            this.Mode = enMode.Update;
                            return true;
                        }
                        else
                        {
                            return false;

                        }
                    }
                case enMode.Update:
                    {
                        return UpdateApplicationType();
                    }

                default:
                    {
                        return false;
                    }



            }

        }

    }
}