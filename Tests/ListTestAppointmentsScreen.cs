using DVLD.Applications.Local_Driving_License.Control;
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
using static DVLD_Business.clsTestType;

namespace DVLD.Tests
{
    public partial class ListTestAppointmentsScreen : Form
    {

        private DataTable _dtLicenseTestAppointments;
        private int _LocalDrivingLicenseApplicationID;
        private clsTestType.enTestType _TestType;

      
        public ListTestAppointmentsScreen(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestType)
        {
           InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestType = TestType;
        }

        private void ApplyOliveDarkTheme(DataGridView dgv)
        {
            dgv.BackgroundColor = Color.FromArgb(45, 60, 45);
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = Color.FromArgb(60, 80, 60); // فواصل زيتية خافتة
            dgv.EnableHeadersVisualStyles = false;

            // رأس الأعمدة (Header)
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersHeight = 42;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 42, 30); // أغمق درجات الزيتي
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(227, 219, 168); // عاجي ناصع
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10.5f, FontStyle.Bold);

            // صفوف البيانات
            dgv.RowTemplate.Height = 36;
            dgv.DefaultCellStyle.BackColor = Color.FromArgb(45, 60, 45);
            dgv.DefaultCellStyle.ForeColor = Color.FromArgb(227, 219, 168);
            dgv.DefaultCellStyle.Font = new Font("Century Gothic", 9.5f, FontStyle.Regular);

            // تبادل الألوان (Zebra Striping)
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(52, 70, 52); // درجة تباين ناعمة
            dgv.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(227, 219, 168);

            // حالة التحديد (Selection)
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(107, 142, 107); // نفس لون بداية التدرج الفاتح
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(107, 142, 107);
            dgv.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.White;

            dgv.RowHeadersVisible = false;
        }

        private void _LoadTestTypeImageAndTitle()
        {
            switch (_TestType)
            {

                case clsTestType.enTestType.VisionTest:
                    {
                        lblTitle.Text = "Vision Test Appointments";
                        this.Text = lblTitle.Text;
                        break;
                    }

                case clsTestType.enTestType.WrittenTest:
                    {
                        lblTitle.Text = "Written Test Appointments";
                        this.Text = lblTitle.Text;
                        break;
                    }
                case clsTestType.enTestType.StreetTest:
                    {
                        lblTitle.Text = "Street Test Appointments";
                        this.Text = lblTitle.Text;
                        break;
                    }
            }
        }
     
        private void ListTestAppointmentsScreen_Load(object sender, EventArgs e)
        {
            ApplyOliveDarkTheme(DGVShowAppointmentInfo);
            _LoadTestTypeImageAndTitle();

            
            ctrlDrivingLicenseApplicationInfo2.LoadData(_LocalDrivingLicenseApplicationID);
            
            _dtLicenseTestAppointments = clsTestAppointment.GetApplicationTestAppointmentsPerTestType(_LocalDrivingLicenseApplicationID, _TestType);

            DGVShowAppointmentInfo.DataSource= _dtLicenseTestAppointments;
            lblNumberOfRecord.Text = DGVShowAppointmentInfo.Rows.Count.ToString();

            if (DGVShowAppointmentInfo.Rows.Count > 0)
            {
                DGVShowAppointmentInfo.Columns[0].HeaderText = "Appointment ID";
                DGVShowAppointmentInfo.Columns[0].Width = 150;

                DGVShowAppointmentInfo.Columns[1].HeaderText = "Appointment Date";
                DGVShowAppointmentInfo.Columns[1].Width = 200;

                DGVShowAppointmentInfo.Columns[2].HeaderText = "Paid Fees";
                DGVShowAppointmentInfo.Columns[2].Width = 150;

                DGVShowAppointmentInfo.Columns[3].HeaderText = "Is Locked";
                DGVShowAppointmentInfo.Columns[3].Width = 100;
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddAppointment_Click(object sender, EventArgs e)
        {
            // clsLocalDrivingLicenseApplication LD = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseApplicationID);
            clsLocalDrivingLicenseApplication localDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseApplicationID);


            if (localDrivingLicenseApplication.IsThereAnActiveScheduledTest(_TestType))
            {
                MessageBox.Show("Person Already have an active appointment for this test, You cannot add new appointment", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            //---GetLastTestPerTestType
            clsTest LastTest = localDrivingLicenseApplication.GetLastTestPerTestType(_TestType);

            if (LastTest == null)
            {
                ScheduleTestScreen frm1 = new ScheduleTestScreen(_LocalDrivingLicenseApplicationID, _TestType);
                frm1.ShowDialog();
                ListTestAppointmentsScreen_Load(null, null);
                return;
            }

            //if person already passed the test s/he cannot retak it.
            if (LastTest.TestResult == true)
            {
                MessageBox.Show("This person already passed this test before, you can only retake faild test", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            ScheduleTestScreen frm2 = new ScheduleTestScreen
                (LastTest.TestAppointmentInfo.LocalDrivingLicenseApplicationID, _TestType);
            frm2.ShowDialog();

            ListTestAppointmentsScreen_Load(null, null);

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
            int TestAppointmentID= (int)DGVShowAppointmentInfo.CurrentRow.Cells[0].Value;

            clsLocalDrivingLicenseApplication LD =
                clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID((clsTestAppointment.GetTestAppointmentInfoByID
                (TestAppointmentID).LocalDrivingLicenseApplicationID));
            
            //(int)DGVShowAppointmentInfo.CurrentRow.Cells[0].Value

            ScheduleTestScreen frm2 = new ScheduleTestScreen
               (LD.LocalDrivingLicenseApplication, _TestType, TestAppointmentID);
            frm2.ShowDialog();
            ListTestAppointmentsScreen_Load(null, null);
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int TestAppointmentID = (int)DGVShowAppointmentInfo.CurrentRow.Cells[0].Value;
            
            TakeTestScreen Test = new TakeTestScreen(TestAppointmentID, _TestType);

            Test.Show();

            ListTestAppointmentsScreen_Load(null,null );
        }
    }
}
