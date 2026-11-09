using DVLD_Buisness;
using DVLD_Business;
using Guna.UI2.WinForms;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.User
{
    public partial class loginInfoScreen : Form
    {

        enum _enMode {AddNew=0,Update=1};

        _enMode mode;

        private int _PersonID;

        private int _UserID;

        clsUser user;
        public loginInfoScreen(clsPerson Person)
        {
            InitializeComponent();
            mode = _enMode.AddNew;
            _PersonID= Person.PersonID;
        }

        public loginInfoScreen(int UserID,int PersonID)
        {
            InitializeComponent();
            mode = _enMode.Update;
            _PersonID=PersonID;
            _UserID=UserID;
        }

        public void _ResetDefaultValue()
        {
            if(mode==_enMode.AddNew)
            {
                 user = new clsUser();
                lblTitle.Text = "Add new user";
                return;
            }
            else 
            {
                lblTitle.Text = "Update user Information";
            }

            txtUserName.Text = string.Empty;
            txtPassword.Text=string.Empty;
            txtConfirmPassword.Text=string.Empty;
            chbIsActive.Checked = false;
            
        }

        public void _LoadData()
        {
            user = clsUser.FindUserByUserID(_UserID);
            
            if(user == null )
            {
                MessageBox.Show("No User with ID = " + _UserID, "User Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }

            lblUserID.Text=user._UserID.ToString();
            txtUserName.Text = user._Username;
            txtPassword.Text = user._Password;
            txtConfirmPassword.Text = user._Password;
            chbIsActive.Checked = user._IsActive;

        }

        private void loginInfoScreen_Load(object sender, EventArgs e)
        {
            this.AcceptButton = btnSave;
            this.CancelButton = btnClose;
            _ResetDefaultValue();
            if(mode==_enMode.Update)
            {
                _LoadData();
            }
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if(!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            user._Username=txtUserName.Text;
            user._Password=txtPassword.Text;
            user._PersonID = _PersonID;
            user._IsActive = chbIsActive.Checked;

            if (user.Save())
            {
                lblTitle.Text = "User Information";
                lblUserID.Text = user._UserID.ToString();
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mode = _enMode.Update;
            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void textValidation(object sender, CancelEventArgs e)
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


        private void textPasswordValidation(object sender, CancelEventArgs e) 
        {
            Guna2TextBox Temp = (Guna2TextBox)sender;
            if (string.IsNullOrEmpty(Temp.Text))
            {
                errorProvider1.SetError(Temp, "Filling out this field is required");
                e.Cancel = true;
            }
            else
            {
              
                if(txtConfirmPassword.Text != txtPassword.Text )
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
    }
}
