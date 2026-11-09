using DVLD.Licenses.Detain_License;
using DVLD.Licenses.Local_Licenses;
using DVLD.People;
using DVLD_Buisness;
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
    public partial class ListDetainedLicensesScreen : Form
    {
        public ListDetainedLicensesScreen()
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


        DataTable TableForDetainLicense;

        private void _FillUserInfoInDataGridView()
        {
            ApplyOliveDarkTheme(DGVDetainedLicenses);

            TableForDetainLicense = clsDetaindLicnse.GetAllDetainedLicenses() ;
            
            DGVDetainedLicenses.DataSource = TableForDetainLicense;

            lblNumberOfColumn.Text = DGVDetainedLicenses.Rows.Count.ToString();

        }

        private void ListDetainedLicensesScreen_Load(object sender, EventArgs e)
        {
            _FillUserInfoInDataGridView();
            if (TableForDetainLicense.Rows.Count > 0)
            {

                DGVDetainedLicenses.Columns[0].HeaderText = "D.ID";
                DGVDetainedLicenses.Columns[0].Width = 90;

                DGVDetainedLicenses.Columns[1].HeaderText = "L.ID";
                DGVDetainedLicenses.Columns[1].Width = 90;

                DGVDetainedLicenses.Columns[2].HeaderText = "D.Date";
                DGVDetainedLicenses.Columns[2].Width = 150;


                DGVDetainedLicenses.Columns[3].HeaderText = "Is Released";
                DGVDetainedLicenses.Columns[3].Width = 90;

                DGVDetainedLicenses.Columns[4].HeaderText = "Fine Fees";
                DGVDetainedLicenses.Columns[4].Width = 90;

                DGVDetainedLicenses.Columns[5].HeaderText = "Release Date";
                DGVDetainedLicenses.Columns[5].Width = 90;

                DGVDetainedLicenses.Columns[6].HeaderText = "N.No";
                DGVDetainedLicenses.Columns[6].Width = 90;
               
                DGVDetainedLicenses.Columns[7].HeaderText = "Full Name";
                DGVDetainedLicenses.Columns[7].Width = 200;
            
                DGVDetainedLicenses.Columns[8].HeaderText = "Release App.ID";
                DGVDetainedLicenses.Columns[8].Width = 90;

            }
        }

        string FiltterColumn = "None";

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
        
            switch (cbFiltterBy.Text)
            {
                case "D.ID":
                    {
                        FiltterColumn = "DetainID";

                        break;
                    }
                case "Is Released":
                    {
                        FiltterColumn = "IsReleased";
                        break;
                    }
                case "N.No":
                    {
                        FiltterColumn = "NationalNo";
                        break;
                    }
                case "Full Name":
                    {
                        FiltterColumn = "FullName";
                        break;
                    }
                case "Release App.ID":
                    {
                        FiltterColumn = "ReleaseApplicationID";
                        break;
                    }
            }

            if (txtFilterValue.Text.Trim() == string.Empty || cbFiltterBy.Text == "None")
            {
                TableForDetainLicense.DefaultView.RowFilter = "";
                lblNumberOfColumn.Text = TableForDetainLicense.Rows.Count.ToString();
                return;
            }

            string FilterValue = txtFilterValue.Text.Trim();

            if (FiltterColumn == "DetainID" || FiltterColumn == "ReleaseApplicationID")
            {
                if (int.TryParse(FilterValue, out int id))
                {
                    TableForDetainLicense.DefaultView.RowFilter = string.Format("[{0}] = {1}", FiltterColumn, id);
                }
                else if(FiltterColumn == "FullName" || FiltterColumn == "NationalNo")
                {
                    TableForDetainLicense.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FiltterColumn, txtFilterValue.Text.Trim());
                }
                else
                {
                    TableForDetainLicense.DefaultView.RowFilter = "";
                }
            }


            lblNumberOfColumn.Text = TableForDetainLicense.Rows.Count.ToString();

        }


        private void cbFiltterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Visible = (cbFiltterBy.Text != "None" && cbFiltterBy.Text != "Is Released");
            cbIsReleased.Visible = (cbFiltterBy.Text == "Is Released");
            if (cbFiltterBy.Visible)
            {
                txtFilterValue.Text = string.Empty;
                txtFilterValue.Focus();
            }

            if (cbFiltterBy.Text == "None")
            {

                txtFilterValue.Visible = false;
                txtFilterValue.Clear();

                cbIsReleased.Visible = false;
                cbIsReleased.Text = "All";

                if (TableForDetainLicense != null)
                {
                    TableForDetainLicense.DefaultView.RowFilter = null;

                    lblNumberOfColumn.Text = DGVDetainedLicenses.Rows.Count.ToString();

                }

            }

        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFiltterBy.Text == "Release Application ID" || cbFiltterBy.Text == "Detain ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void cbIsReleased_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbIsReleased.Text == "Yes")
            {
                TableForDetainLicense.DefaultView.RowFilter = "[Is Released] = true";

            }
            else if (cbIsReleased.Text == "No")
            {
                TableForDetainLicense.DefaultView.RowFilter = "[Is Released] = false";

            }
            else
            {
                TableForDetainLicense.DefaultView.RowFilter = null;

            }
            lblNumberOfColumn.Text = DGVDetainedLicenses.Rows.Count.ToString();
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

        private void btnReleaseDetainedLicense_Click(object sender, EventArgs e)
        {
            ReleaseDetainedLicenseApplicationScreen Release = new ReleaseDetainedLicenseApplicationScreen();

            Release.ShowDialog();
        
            ListDetainedLicensesScreen_Load(null,null);


        }
        


        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string national = (string)DGVDetainedLicenses.CurrentRow.Cells[6].Value;
         
            ShowPersonInfo show = new ShowPersonInfo(clsPerson.Find(national).PersonID);
            
            show.ShowDialog();
            
            ListDetainedLicensesScreen_Load(null, null);

        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)DGVDetainedLicenses.CurrentRow.Cells[1].Value;

            ShowLicenseInfoScreen show = new ShowLicenseInfoScreen(LicenseID);
         
            show.ShowDialog();

            ListDetainedLicensesScreen_Load(null, null);

        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string national = (string)DGVDetainedLicenses.CurrentRow.Cells[6].Value;

            LicenseHistoryScreen History = new LicenseHistoryScreen(clsPerson.Find(national).PersonID);
        
            History.ShowDialog();
        
            ListDetainedLicensesScreen_Load(null, null);

        }

        private void btnDetainLicense_Click(object sender, EventArgs e)
        {
            DetainLicenseApplicationScreen Detain = new DetainLicenseApplicationScreen();

            Detain.ShowDialog();

            ListDetainedLicensesScreen_Load(null,null);
        }
    }
}
