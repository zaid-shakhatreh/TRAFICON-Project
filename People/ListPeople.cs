using DVLD_Buisness;
using DVLD_Business;
using Guna.UI2.WinForms;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace DVLD.People
{
    public partial class ListPeople : Form
    {
        public ListPeople()
        {
            InitializeComponent();
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        DataTable dtSomeOfColumn;
        private void _FillPeopleInDGV()
        {
            DataTable dtAllPeople = clsPerson.GetAllPeople();
            dtSomeOfColumn = dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo", "FirstName", "SecondName", "ThirdName", "LastName", "GenderCaption", "DateOfBirth", "Nationality", "Phone", "Email");

            DGVShowPeopleInfo.DataSource = dtSomeOfColumn;
        }

     
        private void ShowPersonInfo_Load(object sender, EventArgs e)
        {
            ApplyOliveDarkTheme(DGVShowPeopleInfo);
            _FillPeopleInDGV();

            if (dtSomeOfColumn.Rows.Count > 0) 
            {
                DGVShowPeopleInfo.Columns[0].HeaderText = "Person ID";            
                DGVShowPeopleInfo.Columns[0].Width = 110;


                DGVShowPeopleInfo.Columns[1].HeaderText = "National No";
                DGVShowPeopleInfo.Columns[1].Width = 110;

                DGVShowPeopleInfo.Columns[2].HeaderText = "First Name";
                DGVShowPeopleInfo.Columns[2].Width = 110;

                DGVShowPeopleInfo.Columns[3].HeaderText ="Second Name";
                DGVShowPeopleInfo.Columns[3].Width = 110;

                DGVShowPeopleInfo.Columns[4].HeaderText = "Third Name";
                DGVShowPeopleInfo.Columns[4].Width = 110;

                DGVShowPeopleInfo.Columns[5].HeaderText = "Last Name";
                DGVShowPeopleInfo.Columns[5].Width = 110;

                DGVShowPeopleInfo.Columns[6].HeaderText = "Gender";
                DGVShowPeopleInfo.Columns[6].Width = 90;

                DGVShowPeopleInfo.Columns[7].HeaderText = "Date of Birth";
                DGVShowPeopleInfo.Columns[7].Width = 130 ;

                DGVShowPeopleInfo.Columns[8].HeaderText = "Nationalty";
                DGVShowPeopleInfo.Columns[8].Width = 110;


                DGVShowPeopleInfo.Columns[9].HeaderText = "Phone";
                DGVShowPeopleInfo.Columns[9].Width = 110;

                DGVShowPeopleInfo.Columns[10].HeaderText = "Email";
                DGVShowPeopleInfo.Columns[10].Width = 150;

            }

            lblNumberOfColumn.Text=DGVShowPeopleInfo.Rows.Count.ToString();
            lblTitle.Left = (this.ClientSize.Width - lblTitle.Width) / 2;

          

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
  
        private void guna2GradientPanel1_Paint_1(object sender, PaintEventArgs e)
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

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ShowPersonInfo_Resize(object sender, EventArgs e)
        {
            lblTitle.Left = (this.ClientSize.Width - lblTitle.Width) / 2;
        }
        
        string FiltterColumn = "None";

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            switch (cbFiltterBy.Text)
            {
                case "Person ID":
                 {
                        FiltterColumn = "PersonID";
                        break;
                 }
                case "Nationalty No":
                    {
                        FiltterColumn = "NationalNo";
                        break;
                    }
                case "First Name":
                    {
                        FiltterColumn = "FirstName";
                        break;
                    }
                case "Second Name":
                    {
                        FiltterColumn = "SecondName";
                        break;
                    }
                case "Third Name":
                    {
                        FiltterColumn = "ThirdName";
                        break;
                    }
                case "Last Name":
                    {
                        FiltterColumn = "LastName";
                        break;
                    }
                case "Nationality":
                    {
                        FiltterColumn = "Nationality";
                        break;
                    }
                case "GenderCaption":
                    {
                        FiltterColumn = "Gendor";
                        break;
                    }
                case "Phone":
                    {
                        FiltterColumn = "Phone";
                        break;
                    }
                case "Email":
                    {
                        FiltterColumn = "Email";
                        break;
                    }
               
                 
            }

        
         

             if(txtFilterValue.Text.Trim() == string.Empty || cbFiltterBy.Text == "None")
            {
                dtSomeOfColumn.DefaultView.RowFilter = string.Empty;
                lblNumberOfColumn.Text=dtSomeOfColumn.Rows.Count.ToString();
                return;
            }

            if (FiltterColumn == "PersonID")
            {
                dtSomeOfColumn.DefaultView.RowFilter = string.Format("[{0}] = {1}", FiltterColumn, txtFilterValue.Text.Trim());
            }
            else
            {
                dtSomeOfColumn.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FiltterColumn, txtFilterValue.Text.Trim());
            }
            lblNumberOfColumn.Text = DGVShowPeopleInfo.Rows.Count.ToString();



        }

        private void cbFiltterBy_SelectedIndexChanged(object sender, EventArgs e)
        {

            txtFilterValue.Visible = (cbFiltterBy.Text!="None");

            if(cbFiltterBy.Visible)
            {
                txtFilterValue.Text = string.Empty;
                txtFilterValue.Focus();
               
            }
            if (cbFiltterBy.Text == "None")
            {
                txtFilterValue.Visible = false;
                txtFilterValue.Clear();

                if (dtSomeOfColumn != null)
                {
                    dtSomeOfColumn.DefaultView.RowFilter = "";

                    lblNumberOfColumn.Text = DGVShowPeopleInfo.Rows.Count.ToString();
                }
            }
            else
            {
                txtFilterValue.Visible = true;
                txtFilterValue.Clear();
                txtFilterValue.Focus();
            }

        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFiltterBy.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void showDetailsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ShowPersonInfo frm = new ShowPersonInfo((int)DGVShowPeopleInfo.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            _FillPeopleInDGV();
        }

        private void editToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            AddEditPersonInfo frm = new AddEditPersonInfo((int)DGVShowPeopleInfo.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            _FillPeopleInDGV();
        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEditPersonInfo frm = new AddEditPersonInfo();
            frm.ShowDialog();

            _FillPeopleInDGV();
        }

        private void deleteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (clsPerson.DeletePerson((int)DGVShowPeopleInfo.CurrentRow.Cells[0].Value))
            {
                MessageBox.Show("Data Delete Successfully");
                _FillPeopleInDGV();
            }
            else
            {
                MessageBox.Show("Data Delete Faild");
            }
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            AddEditPersonInfo frm = new AddEditPersonInfo();
            frm.ShowDialog();

            _FillPeopleInDGV();
        }
    }
}
