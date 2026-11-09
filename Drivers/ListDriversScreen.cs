using DVLD_Buisness;
using DVLD_Business;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Drivers
{
    public partial class ListDriversScreen : Form
    {
        public ListDriversScreen()
        {
            InitializeComponent();
        }


        DataTable table= new DataTable();

        private void _FillTable()
        {
            
            DataTable dtAllDrivers= clsDriver.GetAllDriverInfo();
            table = dtAllDrivers.DefaultView.ToTable(false, "DriverID", "PersonID", "NationalNo", "FullName", "CreatedDate", "NumberOfActiveLicenses");


            DGVShowDriversInfo.DataSource = table;
        }



        private void ListDriversScreen_Load(object sender, EventArgs e)
        {
            _FillTable();

            if (DGVShowDriversInfo.Rows.Count > 0) 
            {
                DGVShowDriversInfo.Columns[0].HeaderText = "Driver ID";
                DGVShowDriversInfo.Columns[0].Width= 100;


                DGVShowDriversInfo.Columns[1].HeaderText = "Person ID";
                DGVShowDriversInfo.Columns[1].Width = 100;


                DGVShowDriversInfo.Columns[2].HeaderText = "National ID";
                DGVShowDriversInfo.Columns[2].Width = 100;


                DGVShowDriversInfo.Columns[3].HeaderText = "Full Name";
                DGVShowDriversInfo.Columns[3].Width = 210;


                DGVShowDriversInfo.Columns[4].HeaderText = "Date";
                DGVShowDriversInfo.Columns[4].Width = 150;


                DGVShowDriversInfo.Columns[5].HeaderText = "Active Licenses";
                DGVShowDriversInfo.Columns[5].Width = 100;
            }

            lblNumberOfColumn.Text = DGVShowDriversInfo.Columns.Count.ToString();
        }

        string FiltterColumn = "None";
        
        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            switch (cbFiltterBy.Text)
            {
                case "Driver ID":
                    {
                        FiltterColumn = "DriverID";
                        break;
                    }
                case "Person ID":
                    {
                        FiltterColumn = "PersonID";
                        break;
                    }
                case "National No":
                    {
                        FiltterColumn = "NationalNo";
                        break;
                    }
                case "Full Name":
                    {
                        FiltterColumn = "FullName";
                        break;
                    }
                case "Date":
                    {
                        FiltterColumn = "Date";
                        break;
                    }
                case "Active Licenses":
                    {
                        FiltterColumn = "ActiveLicenses";
                        break;
                    }
            }

            if (txtFilterValue.Text.Trim() == string.Empty && cbFiltterBy.Text == "None")
            {
                table.DefaultView.RowFilter = null;
                lblNumberOfColumn.Text = DGVShowDriversInfo.Rows.Count.ToString();
                return;
            }

            string FilterValue = txtFilterValue.Text.Trim();

            if (FiltterColumn == "PersonID" || FiltterColumn == "DriverID")
            {
                if (int.TryParse(FilterValue, out int id))
                {
                    table.DefaultView.RowFilter = string.Format("[{0}] = {1}", FiltterColumn, txtFilterValue.Text.Trim(), id);
                }
                else
                {
                    table.DefaultView.RowFilter = null;
                }
            }
            if (FiltterColumn == "FullName" || FiltterColumn == "NationalNo")
            {
                table.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FiltterColumn, txtFilterValue.Text.Trim());
            }

            lblNumberOfColumn.Text = DGVShowDriversInfo.Rows.Count.ToString();
        }

        private void cbFiltterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Visible = (cbFiltterBy.Text != "None");

            if (cbFiltterBy.Visible)
            {
                txtFilterValue.Text = string.Empty;
                txtFilterValue.Focus();

            }
            if (cbFiltterBy.Text == "None")
            {
                txtFilterValue.Visible = false;
                txtFilterValue.Clear();

                if (table != null)
                {
                    table.DefaultView.RowFilter = "";

                    lblNumberOfColumn.Text = DGVShowDriversInfo.Rows.Count.ToString();
                }
            }
            else
            {
                txtFilterValue.Visible = true;
                txtFilterValue.Clear();
                txtFilterValue.Focus();
            }


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFiltterBy.Text == "Driver ID" || cbFiltterBy.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
