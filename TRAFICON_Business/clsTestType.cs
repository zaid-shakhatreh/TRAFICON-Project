using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsTestType
    {
        enum _enmode { AddNew = 1 , Update=2}
        _enmode mode;

        public enum enTestType { VisionTest =1 , WrittenTest = 2 , StreetTest = 3 }

        enTestType Type;

        public int _ID { get; set; }
        public string _TestType { get; set; }
        public string _Description  { get; set; }
        public float _Fees  { get; set; }

        public clsTestType()
        {
            _ID = -1;
            _TestType = string.Empty;
            _Description = string.Empty;
            _Fees = 0;

            mode=_enmode.AddNew;
        }

        public clsTestType(int ID ,string TestType ,string Description , float Fees)
        {
            _ID=ID;
            _TestType=TestType;
            _Description=Description;
            _Fees=Fees;

            mode = _enmode.Update;

        }

        public static DataTable GetAllTest()
        {
            return clsTestTypeData.GetAllTest();
        }


        public static clsTestType FindByTestID(int TestID)
        {
                float Fees = 0;
               string TestType = string.Empty, Description = string.Empty;
           
           if(clsTestTypeData.FindByTestID(TestID,ref TestType,ref Description,ref Fees))
               {
                   return new clsTestType(TestID,TestType,Description,Fees);
               }
           else
               {
                   return null;
               }
        
        }

        public bool AddTest()
        {
            this._ID = clsTestTypeData.AddTest(this._TestType,this._Description,this._Fees);
    
        return this._ID!=-1;
        }
        public  bool UpdateTest()
        {
            return clsTestTypeData.Update(this._ID,this._TestType,this._Description,this._Fees);
        }

        public bool Save()
        {
            switch (mode)
            {
                case _enmode.AddNew:
                    {
                        if(AddTest())
                        {
                            mode = _enmode.Update;

                            return true;
                        }
                        return false;
                    }
                    case _enmode.Update:
                    {
                        return UpdateTest();
                    }
                default:
                    {
                        return false;
                    } 
            }
        }


    }
}
