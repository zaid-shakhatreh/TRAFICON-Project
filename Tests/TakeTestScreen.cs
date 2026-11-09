using DVLD.Generral_Classes;
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
using static DVLD_Business.clsTestType;

namespace DVLD.Tests
{
    public partial class TakeTestScreen : Form
    {
        int _AppointmentID;
        clsTestType.enTestType _TestType;
        public TakeTestScreen(int AppointmentID, clsTestType.enTestType TestType)
        {
            InitializeComponent();
            _AppointmentID = AppointmentID;
            _TestType = TestType;
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
            if (MessageBox.Show("Are you sure you want to save? After that you cannot change the Pass/Fail results after you save?.",
                    "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No
           )
            {
                return;
            }

            clsTest CurrentTest =new clsTest();

            CurrentTest.CreatedByUserID = clsGlobal.CurrenUser._UserID;
            
            CurrentTest.Notes = txtNotes.Text;

            CurrentTest.TestResult = (rbPass.Checked) ?true : false;

            CurrentTest.TestAppointmentID = _AppointmentID;

            clsTestAppointment UpdateIsLocked = clsTestAppointment.GetTestAppointmentInfoByID(_AppointmentID);

            UpdateIsLocked.IsLocked=true;

            if(!UpdateIsLocked.Save())
            {
                return;
            }

            if (CurrentTest.Save())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;
            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void ctrlScheduledTest1_Load(object sender, EventArgs e)
        {
            ctrlScheduledTest1.LoadInfo(_AppointmentID,_TestType);
        }
    }
}
