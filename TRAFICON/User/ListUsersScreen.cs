using DVLD_Buisness;
using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.User
{
    public partial class ListUsersScreen : Form
    {
        public ListUsersScreen()
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

        DataTable TableForUsers ;

        private void _FillUserInfoInDataGridView()
        {
            TableForUsers = clsUser.GetUserInfo();
            DGVUserInfo.DataSource = TableForUsers;

            lblNumberOfColumn.Text = DGVUserInfo.Rows.Count.ToString();

        }

        private void ManageUserScreen_Load(object sender, EventArgs e)
        {
            _FillUserInfoInDataGridView();

            if (TableForUsers.Rows.Count > 0)
            {

                DGVUserInfo.Columns[0].HeaderText = "User ID";
                DGVUserInfo.Columns[0].Width = 75;

                DGVUserInfo.Columns[1].HeaderText = "Person ID";
                DGVUserInfo.Columns[1].Width = 75;

                DGVUserInfo.Columns[2].HeaderText = "Full Name";
                DGVUserInfo.Columns[2].Width = 200;

                DGVUserInfo.Columns[3].HeaderText = "Active";
                DGVUserInfo.Columns[3].Width = 75;

            }
            lblTitle.Left = (this.ClientSize.Width - lblTitle.Width) / 2;


        }


        string FiltterColumn = "None";
        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {

            switch (cbFiltterBy.Text)
            {
                case "User ID":
                    {
                        FiltterColumn = "UserID";
                        
                        break;
                    }
                case "Person ID":
                    {
                        FiltterColumn = "PersonID";
                        break;
                    }
                case "Full Name":
                    {
                        FiltterColumn = "FullName";
                        break;
                    }
            }
            if (txtFilterValue.Text.Trim() == string.Empty || cbFiltterBy.Text == "None")
            {
                TableForUsers.DefaultView.RowFilter = null;
                lblNumberOfColumn.Text = DGVUserInfo.Rows.Count.ToString();
                return;
            }

            string FilterValue = txtFilterValue.Text.Trim();

            if (FiltterColumn == "PersonID" || FiltterColumn == "UserID")
            {
                if (int.TryParse(FilterValue, out int id))
                {
                    TableForUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FiltterColumn, txtFilterValue.Text.Trim(),id);
                }
                else
                {
                    TableForUsers.DefaultView.RowFilter= null;
                }
            }
            if (FiltterColumn == "FullName")
            {
                TableForUsers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FiltterColumn, txtFilterValue.Text.Trim());
            }
            
            lblNumberOfColumn.Text = DGVUserInfo.Rows.Count.ToString();

        }

        private void cbFiltterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Visible = (cbFiltterBy.Text != "None" && cbFiltterBy.Text != "Active");
            cbAcitvationUsers.Visible = (cbFiltterBy.Text == "Active");
            if(cbFiltterBy.Visible)
            {
                txtFilterValue.Text =string.Empty;
                txtFilterValue.Focus();
            }

            if(cbFiltterBy.Text=="None")
            {

                txtFilterValue.Visible=false;
                txtFilterValue.Clear();
 
                cbAcitvationUsers.Visible=false;
                cbAcitvationUsers.Text = "All";

                if(TableForUsers!=null)
                {
                    TableForUsers.DefaultView.RowFilter = null;

                    lblNumberOfColumn.Text=DGVUserInfo.Rows.Count.ToString();

                }

            }

        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFiltterBy.Text == "Person ID" || cbFiltterBy.Text == "User ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void cbAcitvationUsers_SelectedIndexChanged(object sender, EventArgs e)
        {

            string FilterColumn = "Active";
            string FilterValue = cbAcitvationUsers.Text;

            switch (FilterValue)
            {
                case "All":
                    break;
                case "Yes":
                    FilterValue = "1";
                    break;
                case "No":
                    FilterValue = "0";
                    break;
            }


            if (FilterValue == "All")
                TableForUsers.DefaultView.RowFilter = "";
            else
                //in this case we deal with numbers not string.
                TableForUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);

            lblNumberOfColumn.Text = DGVUserInfo.Rows.Count.ToString();
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            PersonalInfoScreen person   = new PersonalInfoScreen();
            person.ShowDialog();
            _FillUserInfoInDataGridView();

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsUser.DeleteUser((int)DGVUserInfo.CurrentRow.Cells[0].Value))
            { 
                MessageBox.Show("Data Delete Successfully");
         
            _FillUserInfoInDataGridView();
            }
            else
            {
                MessageBox.Show("Data Delete Faild");
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loginInfoScreen Edit = new loginInfoScreen((int)DGVUserInfo.CurrentRow.Cells[0].Value, (int)DGVUserInfo.CurrentRow.Cells[1].Value);
            Edit.Show();
            _FillUserInfoInDataGridView();


        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PersonalInfoScreen person = new PersonalInfoScreen();
            person.ShowDialog();
            _FillUserInfoInDataGridView();

        }

        private void chengePassordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheangePasswordScreen ch=new CheangePasswordScreen((int)DGVUserInfo.CurrentRow.Cells[0].Value);
            ch.ShowDialog();

        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserDetailsScreen Form = new ShowUserDetailsScreen((int)DGVUserInfo.CurrentRow.Cells[0].Value);
        
           Form.ShowDialog();
        
        }

    }
    }

