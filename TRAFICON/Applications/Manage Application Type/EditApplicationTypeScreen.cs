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

namespace DVLD.Applications.Application_Type
{

    public partial class EditApplicationTypeScreen : Form
    {

        

        clsManageApplicationType Type;

        private void someButtonActivity()
        {
            this.AcceptButton = btnSave;
            this.CancelButton = btnClose;
        }
        private void _loadData(int ID)
        {
            someButtonActivity();
         Type = clsManageApplicationType.FindByID(ID);

            lblID.Text = Type._ID.ToString();
            txtApplicationType.Text = Type.ApplicationType.ToString();
            txtFees.Text=Type._Fees.ToString();
        
        }

        public EditApplicationTypeScreen(int ID)
        {
            InitializeComponent();
            _loadData(ID);
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


            Type._Fees = int.Parse(txtFees.Text);
            Type.ApplicationType = txtApplicationType.Text;


            if(Type.Update())
            {
                MessageBox.Show("Data Updated Successfully.", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Error: Data Is not Updated Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

        private void txtValidation(object sender, CancelEventArgs e)
        {
            Guna2TextBox temp = (Guna2TextBox)sender;

            if(!string.IsNullOrEmpty(temp.Text))
            {
                e.Cancel = false;
                errorProvider1.SetError(temp,string.Empty);
            }
            else 
            {
                e.Cancel = true;
                errorProvider1.SetError(temp, "Filling out this field is required");

            }



        }

        private void txtFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFees, "This field is required!");
            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(txtFees, null);
            }
        }
    }
}
