using DVLD.Properties;
using DVLD_Buisness;
using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.People.Control_For_People
{
    public partial class ctrlPersonalCard : UserControl
    {

        private int _PersonID;

        private clsPerson _Person;

        public int PersonID { get { return _PersonID; } }
        public clsPerson Person { get { return _Person; } }

        public void LoadPersonData(int PersonID)
        {
            _Person = clsPerson.Find(PersonID);

            if (_Person == null)
            {
                ResetPersonInfo();
                MessageBox.Show("No Person with PersonID = " + PersonID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillFillData();
        }

        public void LoadPersonData(string NationalNo)
        {
            _Person = clsPerson.Find(NationalNo);

            if (_Person == null)
            {
                MessageBox.Show("No Person with ID = " + _PersonID, "Person Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            _FillFillData();
        }

        private void _FillFillData()
        {
            lblName.Text = _Person.FullName;
           
            lblNationalNo.Text = _Person.NationalNo;
            
            lblPersonID.Text = _Person.PersonID.ToString();
            
            lblPhone.Text = _Person.Phone;

            
            lblCountry.Text = clsCountry.Find(_Person.NationalityCountryID).CountryName;
            


            lblGender.Text = (_Person.Gendor == 0) ? "Male" : "Female";
            
            lblDateOfBrith.Text = _Person.DateOfBirth.ToString();

            lblEmail.Text = (_Person.Email == string.Empty) ? "?" : _Person.Email;
            
            lblAddress.Text = _Person.Address;
           
            _FillImage();
        }
        public void ResetPersonInfo()
        {
            _PersonID = -1;
            lblPersonID.Text = "No Info";
            lblNationalNo.Text = "No Info";
            lblName.Text = "No Info";
            lblGender.Text = "No Info";
            lblEmail.Text = "No Info";
            lblPhone.Text = "No Info";
            lblDateOfBrith.Text = "No Info";
            lblCountry.Text = "No Info";
            lblAddress.Text = "No Info";
            pbPicturePerson.Image = Resources.man_separate;

        }

        private void _FillImage()
        {
            if (_Person.ImagePath == string.Empty)
            {
               if (_Person.Gendor == 0)
               {
                   pbPicturePerson.Image = Resources.man_separate;
               }
               else
               {
                   pbPicturePerson.Image = Resources.woman_separate__1_;
               }
            }
            else
            {
                if (File.Exists(_Person.ImagePath))
                {
                    pbPicturePerson.ImageLocation = _Person.ImagePath;
                }
                else
                {
                   MessageBox.Show("The Image does not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }


        }

        public ctrlPersonalCard()
        {
            InitializeComponent();
        }
        private void btnEditPersonInfo_Click_1(object sender, EventArgs e)
        {
            AddEditPersonInfo frm = new AddEditPersonInfo(_Person.PersonID);

            frm.ShowDialog();

            _FillFillData();
        }

        private void PanelWindow_Paint(object sender, PaintEventArgs e)
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

        
    }
}
