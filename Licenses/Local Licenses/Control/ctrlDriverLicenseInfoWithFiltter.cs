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

namespace DVLD.Licenses.Local_Licenses.Control
{
    public partial class ctrlDriverLicenseInfoWithFiltter : UserControl
    {

        public event Action<int> OnLicenseSelected;
        
        protected virtual void OnLicenseSelceted(int LicenseID)
        {
            Action<int> handler = OnLicenseSelected;
            if (handler != null)
            {
                handler(LicenseID);             }
        }

        private bool _FilterEnabled = true;

        public bool FilterEnabled
        {
            get
            {
                return _FilterEnabled;
            }
            set
            {
                _FilterEnabled = value;
                txtFilterValue.Enabled = _FilterEnabled;
                btnFindLicense.Enabled = _FilterEnabled;
            }
        }


      //  public clsLocalDrivingLicenseApplication LocalInfo;
       
        public clsLicense LicenseInfo;
        public ctrlDriverLicenseInfoWithFiltter()
        {
            InitializeComponent();
        }

        public void loadInfo(int LicenseID)
        {
            clsLicense License = clsLicense.FindByLicenseID(LicenseID);
            
            
            ctrlDriverLicenseInfo1.LoadInfo(LicenseID);
            if (OnLicenseSelected != null && FilterEnabled)
                OnLicenseSelected(LicenseID);

        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
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

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnFindLicense.PerformClick();
            }

            //this will allow only digits if person id is selected
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtFilterValue_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilterValue.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFilterValue, "This field is required!");
            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(txtFilterValue, null);
            }
        }

        private void btnFindLicense_Click(object sender, EventArgs e)
        {

            clsLicense License = clsLicense.FindByLicenseID(int.Parse(txtFilterValue.Text));

            if(clsLicense.isExistbyLicenseID(int.Parse(txtFilterValue.Text)))
            {
                clsLicense license = clsLicense.FindByLicenseID(int.Parse(txtFilterValue.Text));

               
                ctrlDriverLicenseInfo1.LoadInfo(license.LicenseID);
                
             
                LicenseInfo = ctrlDriverLicenseInfo1.LicenseInfo;
               OnLicenseSelected(License.LicenseID);
            }
            else 
            {
                MessageBox.Show("The License does not exist", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void ctrlDriverLicenseInfo1_Load(object sender, EventArgs e)
        {

        }
    }
}
