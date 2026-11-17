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

namespace DVLD.Tests.Control
{
    public partial class ctrlScheduledTest : UserControl
    {
        public ctrlScheduledTest()
        {
            InitializeComponent();
        }

      

            clsTestType.enTestType _TestType;

        
        public void LoadInfo(int AppointmentID,clsTestType.enTestType TestType)
        {
            clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
            clsTestAppointment _TestAppointment;

            _TestAppointment = clsTestAppointment.GetTestAppointmentInfoByID(AppointmentID);
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(_TestAppointment.LocalDrivingLicenseApplicationID);

            _TestType = TestType;
            lblTitle.Text = "Schedules Test";

            lblFullName.Text = _LocalDrivingLicenseApplication.PersonFullName;

            lblDrivingClass.Text = _LocalDrivingLicenseApplication.licenseClassInfo.ClassName;

            lblDate.Text = _TestAppointment.AppointmentDate.ToShortDateString();

            lblFees.Text = _TestAppointment.PaidFees.ToString();

            lblTrial.Text = _LocalDrivingLicenseApplication.TotalTrialsPerTest((clsTestType.enTestType)_TestAppointment.TestTypeID).ToString();

            lblLocalDrivingLicenseAppID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplication.ToString();


            //  lblTestID.Text;
        }







        private void ctrlScheduledTest_Load(object sender, EventArgs e)
        {
            //    lblTitle.Left = (this.ClientSize.Width - lblTitle.Width) / 2;
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
