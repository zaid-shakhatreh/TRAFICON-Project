using DVLD.Generral_Classes;
using DVLD.Licenses.Local_Licenses;
using DVLD.Licenses.Local_Licenses.Control;
using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DVLD_Business.clsLicense;


namespace DVLD.Applications.Replace_Lost_Or_Damaged_License
{
    public partial class ReplaceLostOrDamagedLicenseApplicationScreen : Form
    {
        public ReplaceLostOrDamagedLicenseApplicationScreen()
        {
            InitializeComponent();
        }

      
        private int _NewLicenseID = -1;
        private int AppID= -1;

        private int _GetApplicationTypeID()
        {
        
            if (RBDamagedLicense.Checked)

                return (int)clsApplication.enApplicationType.ReplaceDamagedDrivingLicense;
            else
                return (int)clsApplication.enApplicationType.ReplaceLostDrivingLicense;
        }


        private enIssueReason _GetIssueReason()
        {
            //this will decide which reason to issue a replacement for

            if (RBDamagedLicense.Checked)

                return enIssueReason.DamagedReplacement;
            else
                return enIssueReason.LostReplacement;
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
    Color.FromArgb(107, 142, 107), 
    Color.FromArgb(70, 95, 70),    
    Color.FromArgb(35, 50, 35)     
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

        private void ReplaceLostOrDamagedLicenseApplicationScreen_Load(object sender, EventArgs e)
        {

            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
            lblCreatedBy.Text = clsGlobal.CurrenUser._Username;

            RBDamagedLicense.Checked = true;

        }

        private void RBLostLicense_CheckedChanged(object sender, EventArgs e)
        {
            lblTitle.Text = "Replacement for Lost License";
            this.Text = lblTitle.Text;
            lblApplicationFees.Text = clsApplicationType.Find(_GetApplicationTypeID()).Fees.ToString();

        }

        private void RBDamagedLicense_CheckedChanged(object sender, EventArgs e)
        {
            lblTitle.Text = "Replacement for Damaged License";
            this.Text = lblTitle.Text;
            lblApplicationFees.Text = clsApplicationType.Find(_GetApplicationTypeID()).Fees.ToString();
        
        }

        private void btnIssueReplacement_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Issue a Replacement for the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }


            clsLicense NewLicense =
               ctrlDriverLicenseInfoWithFiltter1.LicenseInfo.Replace(_GetIssueReason(),
               clsGlobal.CurrenUser._UserID);

            if (NewLicense == null)
            {
                MessageBox.Show("Faild to Issue a replacemnet for this  License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            lblApplicationID.Text = NewLicense.ApplicationID.ToString();
            AppID = NewLicense.ApplicationID;
            _NewLicenseID = NewLicense.LicenseID;

            lblReplacedLicenseID.Text = _NewLicenseID.ToString();
            MessageBox.Show("Licensed Replaced Successfully with ID=" + _NewLicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnIssueReplacement.Enabled = false;
            RBDamagedLicense.Enabled = false;
            RBLostLicense.Enabled = false;
            ctrlDriverLicenseInfoWithFiltter1.FilterEnabled = false;
            btnShowNewLicenseInfo.Enabled = true;

        }

        private void btnShowLicenseHistory_Click(object sender, EventArgs e)
        {
            LocalLicenseHistoryScreen History = new LocalLicenseHistoryScreen(ctrlDriverLicenseInfoWithFiltter1.LicenseInfo.DriverInfo.PersonInfo.PersonID);
            History.ShowDialog();
        }

        private void btnShowNewLicenseInfo_Click(object sender, EventArgs e)
        {

            ShowLicenseInfoScreen show = new ShowLicenseInfoScreen(ctrlDriverLicenseInfoWithFiltter1.LicenseInfo.LicenseID);
            show.ShowDialog();
            
        }

        private void ctrlDriverLicenseInfoWithFiltter1_OnLicenseSelected(int obj)
        {
            int SelectedLicenseID = obj;
            lblOldLicenseID.Text = SelectedLicenseID.ToString();
            btnShowLicenseHistory.Enabled = (SelectedLicenseID != -1) ;

            if (SelectedLicenseID == -1)
            {
                return;
            }

            //dont allow a replacement if is Active .
            if (!ctrlDriverLicenseInfoWithFiltter1.LicenseInfo.IsActive)
            {
                MessageBox.Show("Selected License is not Not Active, choose an active license."
                    , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnIssueReplacement.Enabled = false;
                return;
            }

            btnIssueReplacement.Enabled = true;

        }
    }
}
