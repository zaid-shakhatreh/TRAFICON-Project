using DVLD_Buisness;
using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsDriver
    {
        public enum _enmode { AddNew=1 , Update=2 }

        _enmode mode;

        public int _DriverID { get; set; }
        public int _PersonID { get; set; }
        public DateTime _CreatedDate { get; set; }
        public int _CreatedByUserID { get; set; }

        public clsPerson PersonInfo;
        public clsDriver()
        {
            mode= _enmode.AddNew;
            _DriverID=-1;
            _PersonID = -1;
            _CreatedByUserID = -1;
            _CreatedDate = DateTime.Now;
        }
        public clsDriver(int DriverID, int PersonID, DateTime CreatedDate, int CreatedByUserID)
        {
            mode = _enmode.Update;
            _DriverID = DriverID;
            _PersonID = PersonID;
            _CreatedByUserID = CreatedByUserID;
            _CreatedDate = CreatedDate;

            PersonInfo = clsPerson.Find(PersonID);

        }

        public static DataTable GetAllDrivers()
        {
            return clsDriverData.GetAllDrivers();
        }

        public bool AddNewDrivers()
        {
            this._DriverID = clsDriverData.AddNewDriver(this._PersonID,this._CreatedByUserID,this._CreatedDate);

            return this._DriverID != -1;
        }

        public bool UpdateDrivers()
        {
         
            return clsDriverData.UpdateDriverinfo(this._DriverID,this._PersonID,this._CreatedByUserID,this._CreatedDate);
        }

        public bool Save()
        {

            switch (mode)
            {
                case _enmode.AddNew:
                    {
                        if(AddNewDrivers())
                        {
                            mode = _enmode.Update;
                            return true;
                        }
                            return false;
                    }            
            case _enmode.Update:
                    {
                        return UpdateDrivers();
                    }
            }

            return false;




        }

        public static DataTable GetAllDriverInfo()
        {
            return clsDriverData.GetAllDriverInfo();
        }

        public static clsDriver FindByDriverID(int DriverID)
        {

            int PersonID = -1; int CreatedByUserID = -1; DateTime CreatedDate = DateTime.Now;

            if (clsDriverData.GetDriverInfoByDriverID(DriverID, ref PersonID, ref CreatedByUserID, ref CreatedDate))

                return new clsDriver(DriverID, PersonID,CreatedDate, CreatedByUserID);
            else
                return null;

        }

        public static clsDriver FindByPersonID(int PersonID)
        {

            int DriverID = -1; int CreatedByUserID = -1; DateTime CreatedDate = DateTime.Now;

            if (clsDriverData.GetDriverInfoByPersonID(PersonID, ref DriverID, ref CreatedByUserID, ref CreatedDate))

                return new clsDriver(DriverID, PersonID, CreatedDate, CreatedByUserID);
            else
                return null;

        }


        public static DataTable GetInternationalLicenses(int DriverID)
        {
            return clsInternationalLicense.GetDriverInternationalLicenses(DriverID);
        }

    }
}
