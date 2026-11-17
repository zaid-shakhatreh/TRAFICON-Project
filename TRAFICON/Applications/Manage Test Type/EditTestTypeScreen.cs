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

namespace DVLD.Applications.Manage_Test_Type
{
    public partial class EditTestTypeScreen : Form
    {
        clsTestType Type ;

        int _TestID;
        private void someFunctionForButton()
        {
            this.AcceptButton = btnSave;
            this.CancelButton = btnClose;
        }

        private void _LoadData()
        {
            someFunctionForButton();
            Type = clsTestType.FindByTestID(_TestID);
            lblID.Text = Type._ID.ToString();
            txtDescription.Text = Type._Description;
            txtTestType.Text = Type._TestType;
            txtFees.Text=Type._Fees.ToString();
        }

        private void EditTestTypeScreen_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        public EditTestTypeScreen(int TestID)
        {
            InitializeComponent();
            _TestID = TestID;
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            Type._TestType=txtTestType.Text;
            Type._Description=txtDescription.Text;
            Type._Fees =Convert.ToSingle( txtFees.Text);

            if (Type.UpdateTest())
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
            Guna2TextBox temp = (Guna2TextBox) sender;

            if (string.IsNullOrEmpty(temp.Text))
            {
                errorProvider1.SetError(temp, "Filling out this field is required");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(temp,string.Empty);
                e.Cancel = false;
            }


        }
       
        private void txtFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }
    }
}
