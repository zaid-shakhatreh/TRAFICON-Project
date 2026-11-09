using DVLD.Generral_Classes;
using DVLD.People.Control_For_People;
using DVLD.User.Controls;
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
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace DVLD.User
{
    public partial class CheangePasswordScreen : Form
    {

        clsUser user;


        private void FunctionForSomeButton()
        {
            this.AcceptButton = btnSave;
            this.CancelButton = btnClose;
        }

        private void LoadData(clsUser subUser)
        {
            FunctionForSomeButton();
            user = clsUser.FindUserByUserID(subUser._UserID);
            ctrlUserDetail1._LoadData(subUser._UserID);
        }

        public CheangePasswordScreen(int UserID)
        {
            InitializeComponent();
            LoadData(clsUser.FindUserByUserID(UserID));
        }

        public CheangePasswordScreen()
        {
            InitializeComponent();
            LoadData(clsGlobal.CurrenUser);
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

     
        private void textValidationForCurrentPassword(object sender, CancelEventArgs e)
        {
            Guna2TextBox Temp = (Guna2TextBox)sender;
            if (string.IsNullOrEmpty(Temp.Text))
            {

                errorProvider1.SetError(Temp, "Filling out this field is required");
                e.Cancel = true;


            }
            else
            {
                if (txtCurrentPassword.Text == user._Password.ToString())
                {
                    e.Cancel = false;
                    errorProvider1.SetError(Temp, null);
                    return;
                }
                else
                {
                    errorProvider1.SetError(Temp, "Current Password is wrong");
                    e.Cancel = true;
                }
            }



        }

        private void textValidationForNewPassword(object sender, CancelEventArgs e)
        {
            Guna2TextBox Temp = (Guna2TextBox)sender;
            if (string.IsNullOrEmpty(Temp.Text))
            {
                errorProvider1.SetError(Temp, "Filling out this field is required");
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(Temp, null);
                return;
            }



        }
        private void textConfirmPasswordValidation(object sender, CancelEventArgs e)
        {
            Guna2TextBox Temp = (Guna2TextBox)sender;
            if (string.IsNullOrEmpty(Temp.Text))
            {
                errorProvider1.SetError(Temp, "Filling out this field is required");
                e.Cancel = true;
            }
            else
            {

                if (txtConfirmPassword.Text != txtNewPassword.Text)
                {

                    errorProvider1.SetError(Temp, "Password Confirmation does not match Password");
                    e.Cancel = true;
                }
                else
                {
                    e.Cancel = false;
                    errorProvider1.SetError(Temp, null);
                    return;
                }
            }

        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2GradientPanel1_Paint_1(object sender, PaintEventArgs e)
        {
            using (System.Drawing.Drawing2D.LinearGradientBrush brush =
        new System.Drawing.Drawing2D.LinearGradientBrush(
          guna2GradientPanel1.ClientRectangle,
          Color.Black, Color.White, 0f))
            {
                System.Drawing.Drawing2D.ColorBlend cb = new System.Drawing.Drawing2D.ColorBlend();
                cb.Colors = new Color[] {
  Color.FromArgb(107, 142, 107), // يسار: زيتي فاتح واضح
    Color.FromArgb(70, 95, 70),    // وسط: زيتي معتدل
    Color.FromArgb(35, 50, 35)     // يمين: زيتي غامق كلاسيكي
};
                cb.Positions = new float[] { 0.0f, 0.5f, 1.0f };

                brush.InterpolationColors = cb;
                e.Graphics.FillRectangle(brush, guna2GradientPanel1.ClientRectangle);
            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (user == null)
            {
                MessageBox.Show("There is no one available to complete the process.", "Wrong Credintials", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            user._Password = txtNewPassword.Text;
            if (user.Save())
            {
                MessageBox.Show("Changed Password Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Changed Password Faild.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
    }
}
