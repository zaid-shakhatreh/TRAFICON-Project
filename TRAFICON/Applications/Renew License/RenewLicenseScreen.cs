using DVLD.Generral_Classes;
using DVLD.Licenses.International_License;
using DVLD.Licenses.Local_Licenses;
using DVLD.Licenses.Local_Licenses.Control;
using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Applications.Renew_License
{
    public partial class RenewLicenseScreen : Form
    {
        public RenewLicenseScreen()
        {
            InitializeComponent();
        }

        clsLicense Renew ; 

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

        private void btnShowLicenseHistory_Click(object sender, EventArgs e)
        {
            LocalLicenseHistoryScreen History = new LocalLicenseHistoryScreen(ctrlDriverLicenseInfoWithFiltter1.LicenseInfo.DriverInfo.PersonInfo.PersonID);
            History.Show();
        }

        private void btnShowLicenseInfo_Click(object sender, EventArgs e)
        {

          
   
            ShowLicenseInfoScreen show = new ShowLicenseInfoScreen(ctrlDriverLicenseInfoWithFiltter1.LicenseInfo.LicenseID);

            show.Show();
        }

        private void btnRenew_Click(object sender, EventArgs e)
        {



            if (MessageBox.Show("Are you sure you want to Renew the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }


            clsLicense NewLicense =
                ctrlDriverLicenseInfoWithFiltter1.LicenseInfo.RenewLicense(txtNotes.Text.Trim(),clsGlobal.CurrenUser._UserID);

            if (NewLicense == null)
            {
                MessageBox.Show("Faild to Renew the License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            lblRenewApplicationID.Text = NewLicense.ApplicationID.ToString();
          
            //  _NewLicenseID = NewLicense.LicenseID;
            
            lblRenewedLicenseID.Text = NewLicense.LicenseID.ToString();
            
            MessageBox.Show("Licensed Renewed Successfully with ID=" + NewLicense.LicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);


            btnRenew.Enabled = false;

            ctrlDriverLicenseInfoWithFiltter1.FilterEnabled = false;
            
            btnShowLicenseInfo.Enabled = true;
        }

        private void ctrlDriverLicenseInfoWithFiltter1_Load(object sender, EventArgs e)
        {

            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
            lblIssueDate.Text = lblApplicationDate.Text;

            lblExpirationDate.Text = "?";
            lblApplicationFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationType.RenewDrivingLicense).Fees.ToString();
            lblCreatedBy.Text = clsGlobal.CurrenUser._Username;
        }

        private void ctrlDriverLicenseInfoWithFiltter1_OnLicenseSelected(int obj)
        {

            int SelectedLicenseID = obj;

            lblOldLicenseID.Text = SelectedLicenseID.ToString();

            btnShowLicenseHistory.Enabled = (SelectedLicenseID != -1);

            if (SelectedLicenseID == -1)

            {
                return;
            }

            int DefaultValidityLength = ctrlDriverLicenseInfoWithFiltter1.LicenseInfo.LicenseClassInfo.DefaultValidityLength;
            lblExpirationDate.Text = (DateTime.Now.AddYears(DefaultValidityLength)).ToShortDateString();
            lblLicenseFees.Text = ctrlDriverLicenseInfoWithFiltter1.LicenseInfo.LicenseClassInfo.ClassFees.ToString();
            lblTotalFees.Text = (Convert.ToSingle(lblApplicationFees.Text) + Convert.ToSingle(lblLicenseFees.Text)).ToString();
            txtNotes.Text = ctrlDriverLicenseInfoWithFiltter1.LicenseInfo.Notes;


            if (!ctrlDriverLicenseInfoWithFiltter1.LicenseInfo.IsLicenseExpired())
            {
                MessageBox.Show("Selected License is not yet expiared, it will expire on: " + ctrlDriverLicenseInfoWithFiltter1.LicenseInfo.LicenseClassInfo.ClassFees.ToString()
                    , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRenew.Enabled = false;
                return;
            }

            if (!ctrlDriverLicenseInfoWithFiltter1.LicenseInfo.IsActive)
            {
                MessageBox.Show("Selected License is not Not Active, choose an active license."
                    , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRenew.Enabled = false;
                return;
            }



            btnRenew.Enabled = true;

        }
    }
}
