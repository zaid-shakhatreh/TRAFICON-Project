using DVLD_Buisness;
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

namespace DVLD.User
{
    public partial class PersonalInfoScreen : Form
    {
        public PersonalInfoScreen()
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

       

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void PersonalInfoScreen_Load(object sender, EventArgs e)
        {
            this.AcceptButton = btnNext;
            this.CancelButton = btnClose;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (ctrlPersonalCardWithFiltter1 != null)
            {
             clsPerson Person = ctrlPersonalCardWithFiltter1.PersonInfo;

                if(!clsUser.IsUserExistByPersonID(Person.PersonID))
                {
                    loginInfoScreen Form = new loginInfoScreen(Person);
                    this.Hide();
                    Form.ShowDialog();
                }
                else 
                {
                    MessageBox.Show("This person is already User ?!","Wrong",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
                
            }
            else
            {
                MessageBox.Show("There is no one available to complete the process.", "Wrong Credintials", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
