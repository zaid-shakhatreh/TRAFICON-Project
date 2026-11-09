using DVLD.Generral_Classes;
using DVLD.Licenses.Local_Licenses;
using DVLD.Licenses.Local_Licenses.Control;
using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Licenses.Detain_License
{
    public partial class DetainLicenseApplicationScreen : Form
    {
        private int _DetainID = -1;
        private int _SelectedLicenseID = -1;

        public DetainLicenseApplicationScreen()
        {
            InitializeComponent();
        }
        clsDetaindLicnse DL;
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DetainLicenseApplicationScreen_Load(object sender, EventArgs e)
        {
            lblDetainDate.Text = DateTime.Now.ToShortDateString();
            lblCreatedByUser.Text = clsGlobal.CurrenUser._Username;
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to detain this license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }


            _DetainID = ctrlDriverLicenseInfoWithFiltter1.LicenseInfo.Detain(Convert.ToSingle(txtFineFees.Text), clsGlobal.CurrenUser._UserID);
            if (_DetainID == -1)
            {
                MessageBox.Show("Faild to Detain License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            lblDetainID.Text = _DetainID.ToString();
            MessageBox.Show("License Detained Successfully with ID=" + _DetainID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnDetain.Enabled = false;
            ctrlDriverLicenseInfoWithFiltter1.FilterEnabled = false;
            txtFineFees.Enabled = false;
            btnShowLicenseInfo.Enabled = true;

        }

        private void btnShowLicenseHistory_Click(object sender, EventArgs e)
        {
            LocalLicenseHistoryScreen History = new LocalLicenseHistoryScreen(ctrlDriverLicenseInfoWithFiltter1.LicenseInfo.DriverInfo.PersonInfo.PersonID);
            History.Show();
        }

        private void btnShowNewLicenseInfo_Click(object sender, EventArgs e)
        {

            ShowLicenseInfoScreen show = new ShowLicenseInfoScreen(ctrlDriverLicenseInfoWithFiltter1.LicenseInfo.LicenseID);

            show.Show();
        }

        private void txtFineFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFineFees.Text))
            {
                errorProvider1.SetError(txtFineFees, "Filling out this field is required");
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtFineFees, null);
                return;
            }
        }

        private void txtFineFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

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

        private void ctrlDriverLicenseInfoWithFiltter1_OnLicenseSelected(int obj)
        {
            _SelectedLicenseID = obj;

            lblLicenseID.Text = _SelectedLicenseID.ToString();

            btnShowLicenseHistory.Enabled = (_SelectedLicenseID != -1);

            if (_SelectedLicenseID == -1)

            {
                return;
            }

            //ToDo: make sure the license is not detained already.
            if (ctrlDriverLicenseInfoWithFiltter1.LicenseInfo.IsDetained)
            {
                MessageBox.Show("Selected License i already detained, choose another one.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            txtFineFees.Focus();
            btnDetain.Enabled = true;

        }
    }
}
