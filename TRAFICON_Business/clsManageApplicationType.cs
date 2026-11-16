using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsManageApplicationType
    {

        public int _ID=-1;
        public int _Fees=-1;
        public string ApplicationType = string.Empty;


        public clsManageApplicationType(int ID,int Fees ,string ApplicationType) 
        { 
            this._ID= ID;
            this._Fees= Fees;
            this.ApplicationType = ApplicationType;
        }
        
        public static DataTable GetAllApplicationType()
        {
            return clsManageApplicationTypeData.GetAllApplicationType();
        }

        public static clsManageApplicationType FindByID(int ID)
        {
            int Fees = 0; string ApplicationType=string.Empty;

            if(clsManageApplicationTypeData.FindByID(ID, ref Fees, ref ApplicationType))
            {
            return new clsManageApplicationType (ID,Fees,ApplicationType);
            }
            else
            {
                return null;
            }
        }
        public  bool Update()
        {
            return clsManageApplicationTypeData.Update(this._ID ,this._Fees, this.ApplicationType);
        }

    }
}
