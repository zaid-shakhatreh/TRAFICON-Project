using DVLD.Generral_Classes;
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

namespace DVLD.User.Controls
{
    public partial class ctrlUserDetail : UserControl
    {

        
        public void  _LoadData(int UserID)
        {
            clsUser User = clsUser.FindUserByUserID(UserID);
            ctrlPersonalCard1.LoadPersonData(User._PersonID);
            lblUserName.Text = User._Username;
            lblUserID.Text = User._UserID.ToString();
            lblIsActive.Text = (User._IsActive) ? "Yes" : "No";
        }
        public ctrlUserDetail()
        {
            InitializeComponent();
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
