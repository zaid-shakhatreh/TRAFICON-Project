using DVLD.Classes;
using DVLD.Generral_Classes;
using DVLD.Properties;
using DVLD_Buisness;
using DVLD_Business;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.People
{
    public partial class AddEditPersonInfo : Form
    {
        public delegate void Hand(object sender, int PersonID);

        public event Hand DataBack;
        enum _enMode { AddNew=0,Update=1};

        _enMode mode;
        int _PersonID=-1;
        clsPerson _Person;

        public AddEditPersonInfo()
        {
            InitializeComponent();
            mode = _enMode.AddNew;
        }
        public AddEditPersonInfo(int PersonID)
        {
            InitializeComponent();
            mode = _enMode.Update;
             _PersonID = PersonID;
        }

        private void _FillCountryInComboBox()
        {
            DataTable dtCountries = clsCountry.GetAllCountries();

            cbCountry.DataSource = dtCountries;
            cbCountry.DisplayMember = "CountryName";
            cbCountry.ValueMember = "CountryID";
        }
        private void _ResetDefualtValues()
        {
            _FillCountryInComboBox();
            cbCountry.SelectedIndex = Convert.ToInt32(cbCountry.FindString("Jordan"));

            if (mode == _enMode.AddNew)
            {
                lblTitle.Text = "ADD NEW PERSON";
                _Person = new clsPerson();

            }
            else
            {
                lblTitle.Text = "UPDATE PERSON INFORMATION";
            }

            rbMale.Enabled = true;

            txtAddress.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtNationalID.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtSecondName.Text = string.Empty;
            txtThirdName.Text = string.Empty;
            pbPicturePerson.ImageLocation = null;
            btnRemoveImage.Enabled = (pbPicturePerson.ImageLocation!=null);

            //set default image for the person.
            if (rbMale.Checked)
                pbPicturePerson.Image = Resources.man_separate;
            else if (rbFemale.Checked)
                pbPicturePerson.Image = Resources.woman_separate__1_;
            
            

            DTPDateOfBirth.Value = DateTime.Now.AddYears(-18);
            
            DTPDateOfBirth.MinDate = DateTime.Now.AddYears(-100); 
            
            DTPDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);  

        }

        private void _LoadData()
        {

            _Person = clsPerson.Find(_PersonID);

            if (_Person == null)
            {
                MessageBox.Show("No Person with ID = " + _PersonID, "Person Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }

            //the following code will not be executed if the person was not found
            lblPersonID.Text = _PersonID.ToString();
            txtFirstName.Text = _Person.FirstName;
            txtSecondName.Text = _Person.SecondName;
            txtThirdName.Text = _Person.ThirdName;
            txtLastName.Text = _Person.LastName;
            txtNationalID.Text = _Person.NationalNo;
            DTPDateOfBirth.Value = _Person.DateOfBirth;

            if (_Person.Gendor == 0)
                rbMale.Checked = true;
            else if (_Person.Gendor == 1)
                rbFemale.Checked = true;

            if (rbMale.Checked)
               pbPicturePerson.Image =  Resources.man_separate;
            else if (rbFemale.Checked)
                pbPicturePerson.Image = Resources.woman_separate__1_;
            txtAddress.Text = _Person.Address;
            txtPhone.Text = _Person.Phone;
            txtEmail.Text = _Person.Email;
            cbCountry.SelectedValue = _Person.NationalityCountryID;

            //load person image incase it was set.
            if (_Person.ImagePath != "")
            {
               pbPicturePerson.ImageLocation = _Person.ImagePath;

            }

            //hide/show the remove linke incase there is no image for the person.
            btnRemoveImage.Enabled = (_Person.ImagePath != "");

        }

        private void AddEditPersonInfoForm_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();

            if(mode==_enMode.Update)
            _LoadData();

            this.AcceptButton = btnSave;
            this.CancelButton = btnClose;

        }

        private void guna2CustomGradientPanel1_Paint_1(object sender, PaintEventArgs e)
        {
         

            // To add colors to the background(light, medium, and dark oil)
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

        private bool _HandelImage()
        {
            if (_Person.ImagePath != pbPicturePerson.ImageLocation)
            {
                if (_Person.ImagePath != "")
                {
                    //first we delete the old image from the folder in case there is any.

                    try
                    {
                        File.Delete(_Person.ImagePath);
                        _Person.ImagePath = "";
                    }
                    catch (IOException)
                    {
                        // We could not delete the file.
                        //log it later   
                    }
                }

                if (!string.IsNullOrEmpty(pbPicturePerson.ImageLocation))
                {
                    //then we copy the new image to the image folder after we rename it

                    string SourceImageFile = pbPicturePerson.ImageLocation; 
                    if (clsUtil.CopyImageToProjectImagesFolder(ref SourceImageFile))
                    {
                        pbPicturePerson.ImageLocation = SourceImageFile;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

            }
            return true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (pbPicturePerson == null) return;

            if (rbMale.Checked)
            {
                    pbPicturePerson.Image = Resources.man_separate;
            }
            
               
            
            
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (pbPicturePerson == null) return;

            if (rbFemale.Checked)
            {
                pbPicturePerson.Image = Resources.woman_separate__1_;
            }

        }

        private void btnAddImage_Click(object sender, EventArgs e)
        {

            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                string selectedFilePath = openFileDialog1.FileName;
                pbPicturePerson.ImageLocation  =selectedFilePath;
                btnRemoveImage.Enabled = true;
            
            
            }


        }

        private void btnRemoveImage_Click(object sender, EventArgs e)
        {
            pbPicturePerson.ImageLocation= null;
            btnRemoveImage.Enabled = false;
           if (rbFemale.Checked) 
           {
               pbPicturePerson.Image = Resources.woman_separate__1_;
           }
           else 
           {
               pbPicturePerson.Image = Resources.man_separate;
           
           }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            _Person.FirstName    = txtFirstName.Text    ;
           _Person.SecondName   = txtSecondName.Text   ;
           _Person.ThirdName    = txtThirdName.Text    ;
           _Person.LastName     = txtLastName.Text     ;
           _Person.NationalNo   = txtNationalID.Text   ;
           _Person.DateOfBirth  = DTPDateOfBirth.Value ;
           _Person.Email = txtEmail.Text ;
           _Person.Address = txtAddress.Text ;
           _Person.Phone=txtPhone.Text ;
            _Person.NationalityCountryID = clsCountry.Find(cbCountry.Text).ID;

            if (!_HandelImage())
            {
                return;
            }



            if (rbMale.Checked)
            {
                _Person.Gendor = 0;
            }
            else
            {
                _Person.Gendor = 1;
            }

            if(pbPicturePerson.ImageLocation!=null)
            {
               _Person.ImagePath = pbPicturePerson.ImageLocation.ToString();
            }
            
            if (_Person.Save())
            {
                lblTitle.Text = "Update Person";
                mode = _enMode.Update;
                lblPersonID.Text=_Person.PersonID.ToString();
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DataBack?.Invoke(this, _Person.PersonID);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
       
        
        }

        private void textValidation(object sender, CancelEventArgs e)
        {
            Guna2TextBox temp = (Guna2TextBox)sender;

            if (!string.IsNullOrEmpty(temp.Text))
            {
                e.Cancel = false;
                errorProvider1.SetError(temp,null);
                return;
            }
            else 
            {
                e.Cancel = true;
                errorProvider1.SetError(temp, "Filling out this field is required");

            }

        }
        
        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {

           if(txtEmail.Text=="")
            {
                return;
            }

            if (!clsValidation.EmailValidation(txtEmail.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtEmail, "Invalid Email Address Format!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtEmail, null);
            }
            ;
        }

        private void txtNationalID_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNationalID.Text))
            {
                errorProvider1.SetError(txtNationalID,null);

            }
            else
            {
                e.Cancel= false;
                errorProvider1.SetError(txtNationalID, "Filling out this field is required");

            }


            if(txtNationalID.Text != _Person.NationalNo && clsPerson.isPersonExist(txtNationalID.Text.Trim()))
            {
                e.Cancel = false;
                errorProvider1.SetError(txtNationalID, "The format is wrong");
            }
            else
            {
                errorProvider1.SetError(txtNationalID, null);

            }
        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNationalID_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
