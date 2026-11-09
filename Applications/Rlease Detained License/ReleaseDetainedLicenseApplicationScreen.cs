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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Applications.Rlease_Detained_License
{
    public partial class ReleaseDetainedLicenseApplicationScreen : Form
    {
        
        private int _SelectedLicenseID = -1;
        public ReleaseDetainedLicenseApplicationScreen()
        {
            InitializeComponent();
        }
        public ReleaseDetainedLicenseApplicationScreen(int LicenseID)
        {
            InitializeComponent();
            _SelectedLicenseID = LicenseID;

            ctrlDriverLicenseInfoWithFiltter1.loadInfo(LicenseID);
            ctrlDriverLicenseInfoWithFiltter1.FilterEnabled = false;

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

        private void ReleaseDetainedLicenseApplicationScreen_Load(object sender, EventArgs e)
        {

             lblDetainDate.Text = DateTime.Now.ToShortDateString();

             lblCreatedByUser.Text = (clsGlobal.CurrenUser == null) ? "N/A" : clsGlobal.CurrenUser._Username;



        }

        private void btnIssueReplacement_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to release this detained  license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            int ApplicationID = -1;


            bool IsReleased = ctrlDriverLicenseInfoWithFiltter1.LicenseInfo.ReleaseDetainedLicense(clsGlobal.CurrenUser._UserID, ref ApplicationID); ;

            lblApplicationID.Text = ApplicationID.ToString();

            if (!IsReleased)
            {
                MessageBox.Show("Faild to to release the Detain License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Detained License released Successfully ", "Detained License Released", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnRelease.Enabled = false;
            ctrlDriverLicenseInfoWithFiltter1.FilterEnabled = false;
            btnShowNewLicenseInfo.Enabled = true;


        }

        private void ctrlDriverLicenseInfoWithFiltter1_OnLicenseSelected(int obj)
        {
            _SelectedLicenseID = obj;

            lblLicenseID.Text = _SelectedLicenseID.ToString();

            btnShowLicenseHistory.Enabled = (_SelectedLicenseID != -1);

            if (_SelectedLicenseID == -1)

            {
                return;
            }

            if (!ctrlDriverLicenseInfoWithFiltter1.LicenseInfo.IsDetained)
            {
                MessageBox.Show("Selected License  is not detained, choose another one.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
               btnRelease.Enabled=false;
                return;
            }

            lblApplicationFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationType.ReleaseDetainedDrivingLicsense).Fees.ToString();
            lblCreatedByUser.Text = clsGlobal.CurrenUser._Username;

            lblDetainID.Text =  ctrlDriverLicenseInfoWithFiltter1.LicenseInfo.DetainedInfo.DetainID.ToString();
            lblLicenseID.Text = ctrlDriverLicenseInfoWithFiltter1.LicenseInfo.LicenseID.ToString();

            lblCreatedByUser.Text = ctrlDriverLicenseInfoWithFiltter1.LicenseInfo.DetainedInfo.UserInfo._Username;
            lblDetainDate.Text = ctrlDriverLicenseInfoWithFiltter1.LicenseInfo.DetainedInfo.DetainDate.ToShortDateString();
            lblFineFees.Text = ctrlDriverLicenseInfoWithFiltter1.LicenseInfo.DetainedInfo.FineFees.ToString();
            lblTotalFees.Text = (Convert.ToSingle(lblApplicationFees.Text) + Convert.ToSingle(lblFineFees.Text)).ToString();

            btnRelease.Enabled = true;

        }

        private void btnShowLicenseHistory_Click(object sender, EventArgs e)
        {
            LicenseHistoryScreen History = new LicenseHistoryScreen(ctrlDriverLicenseInfoWithFiltter1.LicenseInfo.DriverInfo.PersonInfo.PersonID);
            History.Show();
        }

        private void btnShowNewLicenseInfo_Click(object sender, EventArgs e)
        {
            ShowLicenseInfoScreen Show = new ShowLicenseInfoScreen(ctrlDriverLicenseInfoWithFiltter1.LicenseInfo.LicenseID);
            Show.ShowDialog();
        }
    }
}
