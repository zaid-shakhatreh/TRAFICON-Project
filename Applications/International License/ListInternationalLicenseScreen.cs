using DVLD.Licenses.International_License;
using DVLD.Licenses.Local_Licenses;
using DVLD.People;
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

namespace DVLD.Applications.International_License
{
	public partial class ListInternationalLicenseScreen : Form
	{
		public ListInternationalLicenseScreen()
		{
			InitializeComponent();
		}

		DataTable _dtInternationalLicenseApplications;


        private void _FillTable()
        {
            _dtInternationalLicenseApplications = clsInternationalLicense.GetAllInternationalLicenses().DefaultView.ToTable
         (false, "InternationalLicenseID", "ApplicationID",
         "DriverID"
         , "IssuedUsingLocalLicenseID"
         , "IssueDate"
         , "ExpirationDate"
         , "IsActive");

            DGVShowInternationalLicense.DataSource = _dtInternationalLicenseApplications;

            lblNumberOfColumn.Text = DGVShowInternationalLicense.Rows.Count.ToString();


        }

        private void ListInternationalLicenseScreen_Load(object sender, EventArgs e)
        {
			_FillTable();
            _dtInternationalLicenseApplications = clsInternationalLicense.GetAllInternationalLicenses();
            cbFiltterBy.SelectedIndex = 0;

            DGVShowInternationalLicense.DataSource = _dtInternationalLicenseApplications;
          
			if (DGVShowInternationalLicense.Rows.Count > 0)
			{
				DGVShowInternationalLicense.Columns[0].HeaderText = "Int.License ID";
				DGVShowInternationalLicense.Columns[0].Width = 160;

				DGVShowInternationalLicense.Columns[1].HeaderText = "Application ID";
				DGVShowInternationalLicense.Columns[1].Width = 150;

				DGVShowInternationalLicense.Columns[2].HeaderText = "Driver ID";
				DGVShowInternationalLicense.Columns[2].Width = 130;

				DGVShowInternationalLicense.Columns[3].HeaderText = "L.License ID";
				DGVShowInternationalLicense.Columns[3].Width = 130;

				DGVShowInternationalLicense.Columns[4].HeaderText = "Issue Date";
				DGVShowInternationalLicense.Columns[4].Width = 180;

                DGVShowInternationalLicense.Columns[5].HeaderText = "Expiration Date";
				DGVShowInternationalLicense.Columns[5].Width = 180;

                DGVShowInternationalLicense.Columns[6].HeaderText = "Is Active";
				DGVShowInternationalLicense.Columns[6].Width = 120;
			}
				lblNumberOfColumn.Text = DGVShowInternationalLicense.Rows.Count.ToString();

        }

        string FiltterColumn = "None";

		private void txtFilterValue_TextChanged(object sender, EventArgs e)
		{
           
            switch (cbFiltterBy.Text)
			{
				case "Int.License ID":
					{
						FiltterColumn = "InternationalLicenseID";

						break;
					}
				case "Application ID":
					{
						FiltterColumn = "ApplicationID";
						break;
					}
				case "Driver ID":
					{
						FiltterColumn = "DriverID";
						break;
					}
                case "L.License ID":
                    {
                        FiltterColumn = "IssuedUsingLocalLicenseID";
                        break;
                    }
            }
           
            if (txtFilterValue.Text.Trim() == string.Empty || cbFiltterBy.Text == "None")
			{
				_dtInternationalLicenseApplications.DefaultView.RowFilter = "";
				lblNumberOfColumn.Text = DGVShowInternationalLicense.Rows.Count.ToString();
				return;
			}

			string FilterValue = txtFilterValue.Text.Trim();

			if (FiltterColumn == "InternationalLicenseID" || FiltterColumn == "ApplicationID"
                || FiltterColumn == "DriverID" || FiltterColumn == "IssuedUsingLocalLicenseID")
			{
				if (int.TryParse(FilterValue, out int id))
				{
					_dtInternationalLicenseApplications.DefaultView.RowFilter = string.Format("[{0}] = {1}", FiltterColumn, id);
                }
				else
				{
					_dtInternationalLicenseApplications.DefaultView.RowFilter = "";
                }
			}
			

			lblNumberOfColumn.Text = DGVShowInternationalLicense.Rows.Count.ToString();

		}

		private void cbFiltterBy_SelectedIndexChanged(object sender, EventArgs e)
		{
			txtFilterValue.Visible = (cbFiltterBy.Text != "None" && cbFiltterBy.Text != "Is Active");
			cbAcitvation.Visible = (cbFiltterBy.Text == "Is Active");
			if (cbFiltterBy.Visible)
			{
				txtFilterValue.Text = string.Empty;
				txtFilterValue.Focus();
			}

			if (cbFiltterBy.Text == "None")
			{

				txtFilterValue.Visible = false;
				txtFilterValue.Clear();

				cbAcitvation.Visible = false;
				cbAcitvation.Text = "All";

				if (_dtInternationalLicenseApplications != null)
				{
					_dtInternationalLicenseApplications.DefaultView.RowFilter = null;

					lblNumberOfColumn.Text = DGVShowInternationalLicense.Rows.Count.ToString();

				}

			}

		}

		private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (cbFiltterBy.Text == "Person ID" || cbFiltterBy.Text == "User ID")
				e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
		}
   
		private void cbAcitvation_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbAcitvation.Text == "Yes")
			{
				_dtInternationalLicenseApplications.DefaultView.RowFilter = "[IsActive] = true";

			}
			else if (cbAcitvation.Text == "No")
			{
				_dtInternationalLicenseApplications.DefaultView.RowFilter = "[IsActive] = false";
						
			}
			else
			{
				_dtInternationalLicenseApplications.DefaultView.RowFilter = null;

			}
			lblNumberOfColumn.Text = DGVShowInternationalLicense.Rows.Count.ToString();
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

        private void btnAddNewInternationalApplication_Click(object sender, EventArgs e)
        {
			AddNewInternationalLicenseApplicationScreen Add = new AddNewInternationalLicenseApplicationScreen();
			
			Add.Show();

            ListInternationalLicenseScreen_Load(null, null);
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
			int ApplicationID = (int)DGVShowInternationalLicense.CurrentRow.Cells[1].Value;
			clsApplication App = clsApplication.FindBaseApplication(ApplicationID);
			ShowPersonInfo show = new ShowPersonInfo(App.PersonInfo.PersonID);
			show.Show();
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int InternationalLicenseID = (int)DGVShowInternationalLicense.CurrentRow.Cells[0].Value;


            ShowInternationalLicenseInfoScreen show = new ShowInternationalLicenseInfoScreen
                (InternationalLicenseID);
			show.Show();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ApplicationID = (int)DGVShowInternationalLicense.CurrentRow.Cells[1].Value;
            clsApplication App = clsApplication.FindBaseApplication(ApplicationID);
            LicenseHistoryScreen show = new LicenseHistoryScreen(App.PersonInfo.PersonID);
			show.Show();
        }
    }
}
