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

namespace DVLD.Tests
{
    public partial class ScheduleTestScreen : Form
    {



        private int _LocalDrivingLicenseApplicationID = -1;
        //private clsTestType.enTestType _TestTypeID = clsTestType.enTestType.VisionTest;
        private int _AppointmentID = -1;
        clsTestType.enTestType _TestType;
        public ScheduleTestScreen(int LocalDrivingLicenseApplication, clsTestType.enTestType TestType,int AppointmentID = -1)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplication;
            _TestType = TestType;
            _AppointmentID = AppointmentID;
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void ScheduleTestScreen_Load(object sender, EventArgs e)
        {
            ctrlScheduleTest1.LoadInfo(_LocalDrivingLicenseApplicationID, _TestType, _AppointmentID);
        }
    }
}
