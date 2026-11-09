using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Licenses.International_License
{
    public partial class ShowInternationalLicenseInfoScreen : Form
    {
        int InternationalLicenseID;

        public ShowInternationalLicenseInfoScreen(int InternationalLicenseID)
        {
            InitializeComponent();
            this.InternationalLicenseID =InternationalLicenseID;
        }

        private void ShowInternationalLicenseInfoScreen_Load(object sender, EventArgs e)
        {
            ctrlDriverInternationalLicenseInfo1.LoadInformation(InternationalLicenseID);
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
    }
}
