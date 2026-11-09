using DVLD.Licenses.Local_Licenses;
using DVLD.People;
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

namespace DVLD.Applications.Local_Driving_License.Control
{
    public partial class ctrlDrivingLicenseApplicationInfo : UserControl
    {
        public ctrlDrivingLicenseApplicationInfo()
        {
            InitializeComponent();
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

        clsLocalDrivingLicenseApplication LDLA;

        private void _FillFillData()
        {
            lblDLAppID.Text = LDLA.LocalDrivingLicenseApplication.ToString();

            lblAppID.Text = LDLA.ApplicationID.ToString();

            lblStatus.Text = LDLA.StatusText;

            lblStatusDate.Text = LDLA.LastStatusDate.ToShortDateString();

            lblDate.Text = LDLA.ApplicationDate.ToShortDateString();

             lblType.Text =LDLA.ApplicationTypeText.ToString() ;

            

            lblPassedTest.Text = clsTest.GetPassedTestCount(LDLA.LocalDrivingLicenseApplication).ToString() + " /3";

            lblFees.Text = LDLA.PaidFees.ToString();

            lblCreatedBy.Text=LDLA.CreatedByUserInfo._Username.ToString();

            lblAppliedForLicense.Text = LDLA.licenseClassInfo.ClassName;

            lblApplicant.Text = LDLA.PersonInfo.FullName;

           
        }

        public void LoadData(int LDLApplicationID)
        {
            LDLA = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(LDLApplicationID);
           
            if (LDLA == null)
            {
                MessageBox.Show("No Local Driving License Application with ID = " + LDLApplicationID, "Local Driving License Application Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

           
            _FillFillData();
        }

        

        private void btnPersonInfo_Click(object sender, EventArgs e)
        {
            ShowPersonInfo info = new ShowPersonInfo(LDLA.PersonInfo.PersonID);
            info.ShowDialog();
        }

        private void btnEditLicenseInfo_Click(object sender, EventArgs e)
        {
            ShowLicenseInfoScreen Show = new ShowLicenseInfoScreen(LDLA.LocalDrivingLicenseApplication);
            Show.ShowDialog();
            
        }
    }
}
