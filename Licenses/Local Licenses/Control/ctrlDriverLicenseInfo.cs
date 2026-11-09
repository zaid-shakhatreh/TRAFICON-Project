using DVLD.Properties;
using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Licenses.Control
{
    public partial class ctrlDriverLicenseInfo : UserControl
    {
     //  public  clsLocalDrivingLicenseApplication LocalInfo;
       public clsLicense LicenseInfo;
        public ctrlDriverLicenseInfo()
        {
            InitializeComponent();
        }
        private void _LoadPersonImage()
        {
            if (LicenseInfo.DriverInfo.PersonInfo.Gendor == 0)
                pbPicturePerson.Image = Resources.man_separate;
            else
                pbPicturePerson.Image = Resources.woman_separate__1_;

            string ImagePath = LicenseInfo.DriverInfo.PersonInfo.ImagePath;

            if (ImagePath != "")
                if (File.Exists(ImagePath))
                    pbPicturePerson.Load(ImagePath);
                else
                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        public void LoadInfo(int LicenseID)
        {

           
            LicenseInfo = clsLicense.FindByLicenseID(LicenseID);
            if (LicenseInfo == null)
            {
                MessageBox.Show("Could not find License ID = " + LicenseInfo.LicenseID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LicenseInfo.LicenseID = -1;
                return;
            }

            lblLicenseID.Text = LicenseInfo.LicenseID.ToString();
            lblActivation.Text = LicenseInfo.IsActive ? "Yes" : "No";
            lblStatusOfDetention.Text = LicenseInfo.IsDetained ? "Yes" : "No";
            lblClassName.Text = LicenseInfo.LicenseClassInfo.ClassName;
            lblFullName.Text = LicenseInfo.DriverInfo.PersonInfo.FullName;
            lblNationalNo.Text = LicenseInfo.DriverInfo.PersonInfo.NationalNo;
            lblGender.Text = LicenseInfo.DriverInfo.PersonInfo.Gendor == 0 ? "Male" : "Female";
            lblDateOfBirth.Text = LicenseInfo.DriverInfo.PersonInfo.DateOfBirth.ToShortDateString();

            lblDriverID.Text = LicenseInfo.DriverID.ToString();
            lblIssueDate.Text = (LicenseInfo.IssueDate).ToShortDateString();
            lblExpirationDate.Text = LicenseInfo.ExpirationDate.ToShortDateString();
            lblIssueReason.Text = LicenseInfo.IssueReasonString;
            lblNotes.Text = LicenseInfo.Notes == "" ? "No Notes" : LicenseInfo.Notes;
            _LoadPersonImage();


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

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
