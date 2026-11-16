using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsLicenseClass
    {
        private enum _enmode { AddNew = 1 ,Update = 2}

        private _enmode mode = _enmode.AddNew;

        public int      LicenseClassID           { get; set; }
        public string   ClassName             { get; set; }
        public string   ClassDescription      { get; set; }
        public byte     MinimumAllowedAge     { get; set; }
        public byte     DefaultValidityLength   { get; set; }
        public float    ClassFees                 { get; set; }

        public clsLicenseClass()
        {
            LicenseClassID = -1;
            ClassName = string.Empty;
            ClassDescription = string.Empty;
            MinimumAllowedAge = 0;
            DefaultValidityLength = 0;
            ClassFees = 0;

            mode = _enmode.AddNew;
        }

        public clsLicenseClass(int LicenseClassID, string ClassName,
            string ClassDescription,
            byte MinimumAllowedAge, byte DefaultValidityLength, float ClassFees)
        {
            this.LicenseClassID = LicenseClassID;
            this.ClassName = ClassName;
            this.ClassDescription = ClassDescription;
            this.MinimumAllowedAge = MinimumAllowedAge;
            this.DefaultValidityLength = DefaultValidityLength;
            this.ClassFees = ClassFees;

            mode = _enmode.Update;
        }

        public static clsLicenseClass GetLicenseClassInfoByID(int LicenseClassID)
        {
            string ClassName = string.Empty;
            string ClassDescription = string.Empty;
            byte DefaultValidityLength = 0;
            byte MinimumAllowedAge = 0;
            float ClassFees = 0;

            if (clsLicenseClassData.GetLicenseClassInfoByID(LicenseClassID,
          ref ClassName, ref ClassDescription, ref MinimumAllowedAge,
          ref DefaultValidityLength, ref ClassFees))
            {

                return new clsLicenseClass(LicenseClassID, ClassName,
            ClassDescription,
             MinimumAllowedAge, DefaultValidityLength, ClassFees);

            }
            else
            {
                return null;
            }

        }

        public static clsLicenseClass GetLicenseClassInfoByClassName(string ClassName)
        {
            int LicenseClassID = -1;
            string ClassDescription = string.Empty;
            byte DefaultValidityLength = 0;
            byte MinimumAllowedAge = 0;
            float ClassFees = 0;

            if (clsLicenseClassData.GetLicenseClassInfoByClassName(ClassName,
          ref LicenseClassID, ref ClassDescription, ref MinimumAllowedAge,
          ref DefaultValidityLength, ref ClassFees))
            {

                return new clsLicenseClass(LicenseClassID, ClassName,
            ClassDescription,
             MinimumAllowedAge, DefaultValidityLength, ClassFees);

            }
            else
            {
                return null;
            }

        }

         public static DataTable GetAllLicenseClasses() 
        {
        return clsLicenseClassData.GetAllLicenseClasses();
        }

        private bool AddNewLicenseClass()
        {
            this.LicenseClassID = clsLicenseClassData.AddNewLicenseClass
                (this.ClassName,this.ClassDescription,this.MinimumAllowedAge,
                this.DefaultValidityLength,this.ClassFees);

            return this.LicenseClassID != -1;
        }

        private  bool UpdateLicenseClass()
        {
            return clsLicenseClassData.UpdateLicenseClass(this.LicenseClassID,this.ClassName
                ,this.ClassDescription ,this.MinimumAllowedAge,this.DefaultValidityLength
                ,this.ClassFees);
        }

        public bool Save()
        {
            switch(mode)
            {
                case _enmode.AddNew:
                    {

                        if (AddNewLicenseClass())
                        {

                            mode = _enmode.Update;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    
                case _enmode.Update:
                    {
                        return UpdateLicenseClass();
                    }
                default: 
                    {
                        return false;
                    }
            }
        }


    }
}
