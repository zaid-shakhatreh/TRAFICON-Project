using DVLD.Licenses.Local_Licenses;
using DVLD.Tests;
using DVLD_Buisness;
using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DVLD.Applications.Local_Driving_License
{
    public partial class ListLocalDrivingLicesnseApplicationsScreen : Form
    {
        public ListLocalDrivingLicesnseApplicationsScreen()
        {
            InitializeComponent();
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

        DataTable table; 
        private void _LoadDataInDGV()
        {
       
            ApplyOliveDarkTheme(DGVShowPeopleInfo);
            table = clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplications();
            DGVShowPeopleInfo.DataSource = table;
            lblNumberOfColumn.Text = DGVShowPeopleInfo.Rows.Count.ToString();
        }
        private void ListLocalDrivingLicesnseApplicationsScreen_Load(object sender, EventArgs e)
        {
            _LoadDataInDGV();

            if (DGVShowPeopleInfo.Rows.Count > 0)
            {
                DGVShowPeopleInfo.Columns[0].HeaderText = "L.D.L.Application";
                DGVShowPeopleInfo.Columns[0].Width = 100;

                DGVShowPeopleInfo.Columns[1].HeaderText = "Class Name";
                DGVShowPeopleInfo.Columns[1].Width = 220;

                DGVShowPeopleInfo.Columns[2].HeaderText = "National No";
                DGVShowPeopleInfo.Columns[2].Width = 100;
                
                DGVShowPeopleInfo.Columns[3].HeaderText = "Full Name";
                DGVShowPeopleInfo.Columns[3].Width = 210;
                
                
                DGVShowPeopleInfo.Columns[4].HeaderText = "Application Date";
                DGVShowPeopleInfo.Columns[4].Width = 100;

                DGVShowPeopleInfo.Columns[5].HeaderText = "Passed Tests";
                DGVShowPeopleInfo.Columns[5].Width = 100;

                DGVShowPeopleInfo.Columns[6].HeaderText = "Status";
                DGVShowPeopleInfo.Columns[6].Width = 100;

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

        private void btnAddNewApplication_Click(object sender, EventArgs e)
        {
            PersonalInfoForLocalDriverScreen info = new PersonalInfoForLocalDriverScreen();
            info.Show();
         
            _LoadDataInDGV();
        }

            string Filtter ="None";
        private void cbFiltterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
        
            
                   cbStatusFiltter.Visible = (cbFiltterBy.Text=="Status");
                    cbStatusFiltter.Text = "All";
                    
                    txtFilterValue.Visible =  (cbFiltterBy.Text != "Status" && cbFiltterBy.Text != "None");
                    txtFilterValue.Text = string.Empty;

            if(cbFiltterBy.Visible)
            {
                txtFilterValue.Text = string.Empty;
                txtFilterValue.Focus();
            }

            if (cbFiltterBy.Text == "None")
            {
                txtFilterValue.Visible = false;
                txtFilterValue.Clear();

                cbStatusFiltter.Visible = false;
                cbStatusFiltter.Text = "All";
                if (table != null)
                {
                    table.DefaultView.RowFilter = null;
                    lblNumberOfColumn.Text = DGVShowPeopleInfo.Rows.Count.ToString();
                }
            }

        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {

            switch (cbFiltterBy.Text)
            {
                case "L.D.L.Appliection":
                    {
                        Filtter = "LocalDrivingLicenseApplicationID";
                        break;
                    }
                case "Class Name":
                    {
                        Filtter = "ClassName";
                        break;
                    }
                case "Full Name":
                    {
                        Filtter = "FullName";
                        break;
                    }
                case "National No":
                    {
                        Filtter = "NationalNo";
                        break;
                    }
                case "Status":
                    {
                        Filtter = "Status";
                        break;
                    }
            }

            if (txtFilterValue.Text.Trim() == string.Empty && cbFiltterBy.Text == "None")
            {
                table.DefaultView.RowFilter = null;
                lblNumberOfColumn.Text = DGVShowPeopleInfo.Rows.Count.ToString();
                return;
            }


            string FilterValue = txtFilterValue.Text.Trim();

            if (Filtter == "LocalDrivingLicenseApplicationID")
            {
                if (int.TryParse(FilterValue, out int id))
                {
                    table.DefaultView.RowFilter = string.Format("[{0}] = {1}", Filtter, txtFilterValue.Text.Trim(), id);//
                }
                else
                {
                    table.DefaultView.RowFilter = null;
                }
            }
            if (Filtter == "FullName" || Filtter == "NationalNo" || Filtter == "ClassName")
            {
                table.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", Filtter, txtFilterValue.Text.Trim());
            }
            lblNumberOfColumn.Text = DGVShowPeopleInfo.Rows.Count.ToString();

        }

        private void cbStatusFiltter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbStatusFiltter.Text == "All")
            { 
               table.DefaultView.RowFilter = null;
               
            }
            else 
            {
               table.DefaultView.RowFilter = string.Format("[Status] = '{0}'", cbStatusFiltter.Text); ;
            }
            lblNumberOfColumn.Text = DGVShowPeopleInfo.Rows.Count.ToString();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFiltterBy.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void CancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsLocalDrivingLicenseApplication LA = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID
                ((int)DGVShowPeopleInfo.CurrentRow.Cells[0].Value);
           // MessageBox.Show(LA.ApplicationID.ToString());
            if (LA.Cancel())
            {
                MessageBox.Show("Data Cancel Successfully","Cancel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _LoadDataInDGV();
            }
            else
            {
                MessageBox.Show("Data Cancel Faild", "Cancel",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            ListLocalDrivingLicesnseApplicationsScreen_Load(null, null);

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsLocalDrivingLicenseApplication.DeleteLocalDrivingLicenseApplication((int)DGVShowPeopleInfo.CurrentRow.Cells[0].Value))
            {
                MessageBox.Show("Data Delete Successfully","Delete",MessageBoxButtons.OK,MessageBoxIcon.Information);
                _LoadDataInDGV();
            }
            else
            {
                MessageBox.Show("Data Delete Faild", "Delete",MessageBoxButtons.OK,MessageBoxIcon.Error);
                
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEditLocalDrivingLicense Edit = new AddEditLocalDrivingLicense((int)DGVShowPeopleInfo.CurrentRow.Cells[0].Value);
        
            Edit.ShowDialog();

            _LoadDataInDGV();
            ListLocalDrivingLicesnseApplicationsScreen_Load(null, null);

        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LocalDrivingLicenseInfoScreen info = new LocalDrivingLicenseInfoScreen((int)DGVShowPeopleInfo.CurrentRow.Cells[0].Value, (int)DGVShowPeopleInfo.CurrentRow.Cells[5].Value);
            info.ShowDialog();

            _LoadDataInDGV();
            ListLocalDrivingLicesnseApplicationsScreen_Load(null, null);

        }

        private void sechduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsLocalDrivingLicenseApplication L = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID((int)DGVShowPeopleInfo.CurrentRow.Cells[0].Value);

            ListTestAppointmentsScreen list = new ListTestAppointmentsScreen 
               (L.LocalDrivingLicenseApplication, clsTestType.enTestType.VisionTest);
            list.ShowDialog();

            _LoadDataInDGV();
            ListLocalDrivingLicesnseApplicationsScreen_Load(null, null);

        }

        private void sechduleWrittenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsLocalDrivingLicenseApplication L = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID((int)DGVShowPeopleInfo.CurrentRow.Cells[0].Value);

            ListTestAppointmentsScreen list = new ListTestAppointmentsScreen
            (L.LocalDrivingLicenseApplication, clsTestType.enTestType.WrittenTest);
            list.ShowDialog();

            _LoadDataInDGV();
            ListLocalDrivingLicesnseApplicationsScreen_Load(null, null);

        }

        private void sechduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsLocalDrivingLicenseApplication L = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID((int)DGVShowPeopleInfo.CurrentRow.Cells[0].Value);

            ListTestAppointmentsScreen list = new ListTestAppointmentsScreen
          (L.LocalDrivingLicenseApplication, clsTestType.enTestType.StreetTest);
            list.ShowDialog();

            _LoadDataInDGV();
            ListLocalDrivingLicesnseApplicationsScreen_Load(null, null);

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)DGVShowPeopleInfo.CurrentRow.Cells[0].Value;
            clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication =
                    clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID
                                                    (LocalDrivingLicenseApplicationID);

            int TotalPassedTests = (int)DGVShowPeopleInfo.CurrentRow.Cells[5].Value;

            bool LicenseExists = LocalDrivingLicenseApplication.IsLicenseIssued();

            //Enabled only if person passed all tests and Does not have license. 
            issuingADrivingLicenseFirstTimeToolStripMenuItem.Enabled = (TotalPassedTests == 3) && !LicenseExists;

            showLicenseToolStripMenuItem.Enabled = LicenseExists;
            editToolStripMenuItem.Enabled = !LicenseExists && (LocalDrivingLicenseApplication.ApplicationStatus == clsApplication.enApplicationStatus.New);
            sechduleTestToolStripMenuItem.Enabled = !LicenseExists;

            //Enable/Disable Cancel Menue Item
            //We only canel the applications with status=new.
            CancelApplicationToolStripMenuItem.Enabled = (LocalDrivingLicenseApplication.ApplicationStatus == clsApplication.enApplicationStatus.New);

            //Enable/Disable Delete Menue Item
            //We only allow delete incase the application status is new not complete or Cancelled.
            deleteToolStripMenuItem.Enabled =
                (LocalDrivingLicenseApplication.ApplicationStatus == clsApplication.enApplicationStatus.New);



            //Enable Disable Schedule menue and it's sub menue
            bool PassedVisionTest = LocalDrivingLicenseApplication.DoesPassTestType(clsTestType.enTestType.VisionTest); ;
            bool PassedWrittenTest = LocalDrivingLicenseApplication.DoesPassTestType(clsTestType.enTestType.WrittenTest);
            bool PassedStreetTest = LocalDrivingLicenseApplication.DoesPassTestType(clsTestType.enTestType.StreetTest);

            sechduleTestToolStripMenuItem.Enabled = (!PassedVisionTest || !PassedWrittenTest || !PassedStreetTest) && (LocalDrivingLicenseApplication.ApplicationStatus == clsApplication.enApplicationStatus.New);

            if (sechduleTestToolStripMenuItem.Enabled)
            {
                //To Allow Schdule vision test, Person must not passed the same test before.
                sechduleVisionTestToolStripMenuItem.Enabled = !PassedVisionTest;

                //To Allow Schdule written test, Person must pass the vision test and must not passed the same test before.
                sechduleWrittenTestToolStripMenuItem.Enabled = PassedVisionTest && !PassedWrittenTest;

                //To Allow Schdule steet test, Person must pass the vision * written tests, and must not passed the same test before.
                sechduleStreetTestToolStripMenuItem.Enabled = PassedVisionTest && PassedWrittenTest && !PassedStreetTest;

            }
        }

        private void issuingADrivingLicenseFirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)DGVShowPeopleInfo.CurrentRow.Cells[0].Value;
         
            IssueDriverLicenseFirstTimeScreen issue = new IssueDriverLicenseFirstTimeScreen(LocalDrivingLicenseApplicationID);
            
            issue.Show();

            _LoadDataInDGV();
            ListLocalDrivingLicesnseApplicationsScreen_Load(null,null);

        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string national = (string)DGVShowPeopleInfo.CurrentRow.Cells[2].Value;



          int li=clsLicense.FindByDriverID(clsDriver.FindByPersonID(clsPerson.Find(national).PersonID)._DriverID).LicenseID;
            ShowLicenseInfoScreen show = new ShowLicenseInfoScreen(li);
            show.Show();
            ListLocalDrivingLicesnseApplicationsScreen_Load(null, null);

        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = clsPerson.Find((string)DGVShowPeopleInfo.CurrentRow.Cells[2].Value).PersonID;

            LicenseHistoryScreen History = new LicenseHistoryScreen(PersonID);
            
            History.Show();
            ListLocalDrivingLicesnseApplicationsScreen_Load(null, null);

        }

    }
}
