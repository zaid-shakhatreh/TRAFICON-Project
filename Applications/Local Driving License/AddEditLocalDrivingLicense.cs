using DVLD.Generral_Classes;
using DVLD_Buisness;
using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DVLD_Business.clsLocalDrivingLicenseApplication;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DVLD.Applications.Local_Driving_License
{
    public partial class AddEditLocalDrivingLicense : Form
    {
        enum _enmode { AddNew = 0, Update = 1 };

        _enmode mode;

        clsPerson Person ;

        
        clsLocalDrivingLicenseApplication LADA;
        public AddEditLocalDrivingLicense(string nationalNo)
        {
            InitializeComponent();
            Person = clsPerson.Find(nationalNo);
            mode = _enmode.AddNew;
            LADA =new clsLocalDrivingLicenseApplication();
            LADA.PersonInfo=Person;
            LADA.ApplicantPersonID = Person.PersonID;
        
        }


        public AddEditLocalDrivingLicense(int LADAID)
        {
            InitializeComponent();
            mode = _enmode.Update;
            LADA = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(LADAID);
        
        }
        DataTable Table;

        private void _fillLicenseClass()
        {
            Table = clsLicenseClass.GetAllLicenseClasses();

            foreach (DataRow dt in Table.Rows)
            {

                cbLicenseClass.Items.Add(dt["ClassName"]);
            }
            
        }


        private void _ResetDefaultData()
        {
            _fillLicenseClass();
            if (mode == _enmode.AddNew)
            {
                lblTitle.Text = "New Local Driving License Application";
                lblApplicationDate.Text = DateTime.Now.ToString();
                lblCreatedBy.Text = clsGlobal.CurrenUser._Username;
                cbLicenseClass.SelectedIndex = 2;
                lblApplicationFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationType.NewDrivingLicense).Fees.ToString();
            }
            else 
            {
                lblTitle.Text = "Update Local Driving License Application";
            }
        }

        private void _LoadData()
        {  
            
            lblApplicationDate.Text = LADA.ApplicationDate.ToString();
            lblCreatedBy.Text = LADA.CreatedByUserInfo._Username;
            lblDLApplicationID.Text = LADA.ApplicationID.ToString();
            lblApplicationFees.Text = LADA.PaidFees.ToString() ;
            cbLicenseClass.SelectedIndex = LADA.LicenseClassID -1;
        }


        private void AddEditLocalDrivingLicense_Load(object sender, EventArgs e)
        {
            _ResetDefaultData();
                if(mode ==_enmode.Update)
                 _LoadData();
        }


        private void PanelWindow_Paint(object sender, PaintEventArgs e)
        {
            using (System.Drawing.Drawing2D.LinearGradientBrush brush =
   new System.Drawing.Drawing2D.LinearGradientBrush(
       PanelWindow.ClientRectangle,
       Color.Black, Color.White, 0f))
            {
                System.Drawing.Drawing2D.ColorBlend cb = new System.Drawing.Drawing2D.ColorBlend();
                cb.Colors = new Color[] {
    Color.FromArgb(107, 142, 107), // يسار: زيتي فاتح واضح
    Color.FromArgb(70, 95, 70),    // وسط: زيتي معتدل
    Color.FromArgb(35, 50, 35)     // يمين: زيتي غامق كلاسيكي
};
                cb.Positions = new float[] { 0.0f, 0.5f, 1.0f };

                brush.InterpolationColors = cb;
                e.Graphics.FillRectangle(brush, PanelWindow.ClientRectangle);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {


            int LicenseClassID = clsLicenseClass.GetLicenseClassInfoByClassName(cbLicenseClass.Text).LicenseClassID;

            int ActiveApplicationID = clsApplication.GetActiveApplicationIDForLicenseClass(LADA.PersonInfo.PersonID,
                clsApplication.enApplicationType.NewDrivingLicense,LicenseClassID);

            if (ActiveApplicationID != -1) 
            {
                MessageBox.Show("Choose another License Class, the selected Person Already have an active application for the selected class with id=" + ActiveApplicationID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbLicenseClass.Focus();
                return;
            }
            

             if (clsLicense.IsLicenseExistByPersonID(LADA.PersonInfo.PersonID, LicenseClassID))
             {
            
                 MessageBox.Show("Person already have a license with the same applied driving class, Choose diffrent driving class", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 return;
             }

            LADA.ApplicationDate = DateTime.Now;
            LADA.ApplicationTypeID = 1;
            LADA.ApplicationStatus = clsApplication.enApplicationStatus.New;
            LADA.LastStatusDate = DateTime.Now;
            LADA.PaidFees = Convert.ToSingle(lblApplicationFees.Text);
            LADA.CreatedByUserID = clsGlobal.CurrenUser._UserID;
            LADA.LicenseClassID = LicenseClassID;

            


            if (LADA.Save())
            {

                mode = _enmode.Update;
                lblTitle.Text = "Update Local Driving License Application";
                lblDLApplicationID.Text = LADA.ApplicationID.ToString();

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }

    }
}
