using DVLD.Properties;
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

namespace DVLD.Licenses.International_License.Control
{
    public partial class ctrlDriverInternationalLicenseInfo : UserControl
    {
        public ctrlDriverInternationalLicenseInfo()
        {
            InitializeComponent();
        }

       public void LoadInformation(int InternationalLicenseID)
        {

            clsInternationalLicense IntLicense = clsInternationalLicense.Find(InternationalLicenseID);

           
            //International
            string Active = (IntLicense.IsActive) ? "Active":"Not Active";

            lblActivation.Text = Active;
     
            lblApplicationID.Text = IntLicense.ApplicationID.ToString();
            
            lblDriverID.Text = IntLicense.DriverID.ToString();
            
            lblLicenseID.Text = IntLicense.IssuedUsingLocalLicenseID.ToString();
            
            lblIssueDate.Text = IntLicense.IssueDate.ToShortDateString();
            
            lblExpirationDate.Text = IntLicense.ExpirationDate.ToShortDateString();
            
            lblInternationlLicenseID.Text = IntLicense.InternationalLicenseID.ToString();

            lblName.Text = IntLicense.DriverInfo.PersonInfo.FullName;

            lblNationaNo.Text= IntLicense.DriverInfo.PersonInfo.NationalNo;
            
            string Gender = (IntLicense.DriverInfo.PersonInfo.Gendor == 0) ? "Male" : "Female";

            lblGender.Text = Gender;
            
            lblDateOfBirth.Text= IntLicense.DriverInfo.PersonInfo.DateOfBirth.ToShortDateString();
         
            if(IntLicense.DriverInfo.PersonInfo.ImagePath =="")
            {
                if(IntLicense.DriverInfo.PersonInfo.Gendor == 0)
                {
                pbPicturePerson.Image= Resources.man_separate;
                }
                else
                {
                pbPicturePerson.Image = Resources.woman_separate__1_;
                }
            }
            else
            {
                pbPicturePerson.ImageLocation = IntLicense.DriverInfo.PersonInfo.ImagePath;
            }


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


    }
    }
