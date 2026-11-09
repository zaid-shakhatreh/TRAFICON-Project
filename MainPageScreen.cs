using DVLD.Applications.Application_Typ;
using DVLD.Applications.Application_Type;
using DVLD.Applications.International_License;
using DVLD.Applications.Local_Driving_License;
using DVLD.Applications.Manage_Test_Type;
using DVLD.Applications.Renew_License;
using DVLD.Applications.Replace_Lost_Or_Damaged_License;
using DVLD.Applications.Rlease_Detained_License;
using DVLD.Drivers;
using DVLD.Generral_Classes;
using DVLD.Licenses.Detain_License;
using DVLD.Login;
using DVLD.People;
using DVLD.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{

    public partial class MainPageScreen : Form
    {
public MainPageScreen()
        {
            InitializeComponent();
        }
        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

            using (System.Drawing.Drawing2D.LinearGradientBrush brush =
                   new System.Drawing.Drawing2D.LinearGradientBrush(
                       guna2GradientPanel1.ClientRectangle,
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
                e.Graphics.FillRectangle(brush, guna2GradientPanel1.ClientRectangle);
            }
        }

        private void peopleToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ListPeople frm = new ListPeople();
         //   frm.MdiParent = this;
            frm.ShowDialog();
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListDriversScreen List = new ListDriversScreen();
            List.ShowDialog();
        }

        private void fintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FindPerson f = new FindPerson();
            f.ShowDialog();    
        }

    
        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginScreen loginScreen = new LoginScreen();
            this.Hide();
            loginScreen.ShowDialog();
            this.Close();
        }

        private void MainPage_Load(object sender, EventArgs e)
        {
            lblAdmin.Text = clsGlobal.CurrenUser._Username;
        }

        private void accountSettingsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ShowUserDetailsScreen SUDS = new ShowUserDetailsScreen();

            SUDS.ShowDialog();
        }

        private void cheangePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheangePasswordScreen Form = new CheangePasswordScreen();
            Form.ShowDialog();
        }

        private void signOutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            clsGlobal.CurrenUser = null;
         
            LoginScreen Login = new LoginScreen();
            
            this.Hide();
            
            Login.ShowDialog();

            this.Close();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListUsersScreen frm = new ListUsersScreen();
            frm.ShowDialog();
        }
        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListApplicationTypeScreen list = new ListApplicationTypeScreen();
                list.ShowDialog();
        }
        private void manageTestTypesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ListTestTypeScreen list=new ListTestTypeScreen();   
            list.ShowDialog();

        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {

            PersonalInfoForLocalDriverScreen info=new PersonalInfoForLocalDriverScreen();
            info.ShowDialog();

        }

        private void localDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListLocalDrivingLicesnseApplicationsScreen List =new ListLocalDrivingLicesnseApplicationsScreen();

            List.Show();
        }

      

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
        AddNewInternationalLicenseApplicationScreen Add = new AddNewInternationalLicenseApplicationScreen();
            Add.ShowDialog();
            
        }

        private void dToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListInternationalLicenseScreen list = new ListInternationalLicenseScreen();
            list.ShowDialog();

        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RenewLicenseScreen Renew = new RenewLicenseScreen();
        
            Renew.ShowDialog();
        
        }

        private void replacementForLostOrDamagedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReplaceLostOrDamagedLicenseApplicationScreen Replace = new ReplaceLostOrDamagedLicenseApplicationScreen();

            Replace.ShowDialog();
        }

        private void manageDetainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListDetainedLicensesScreen List = new ListDetainedLicensesScreen();

            List.ShowDialog();
        }

        private void detainLicensesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DetainLicenseApplicationScreen Detain = new DetainLicenseApplicationScreen();

            Detain.ShowDialog();
        }

        private void relaseDetainLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReleaseDetainedLicenseApplicationScreen Release = new ReleaseDetainedLicenseApplicationScreen();

            Release.ShowDialog();
        }

        private void signOutToolStripMenuItem_Click_2(object sender, EventArgs e)
        {
            clsGlobal.CurrenUser = null;
              
            LoginScreen login = new LoginScreen();

            this.Hide();
          
            login.ShowDialog();

            this.Close();
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserDetailsScreen Show = new ShowUserDetailsScreen(clsGlobal.CurrenUser._UserID);
            Show.ShowDialog();
        }

        private void cheangePasswordToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            CheangePasswordScreen cheange = new CheangePasswordScreen(clsGlobal.CurrenUser._UserID);
            cheange.ShowDialog();
        }

        private void releaseDetaindDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReleaseDetainedLicenseApplicationScreen release = new ReleaseDetainedLicenseApplicationScreen();
            release.ShowDialog();

        }

    }

    public class ModernOliveMenuRenderer : ToolStripProfessionalRenderer
    {
        public ModernOliveMenuRenderer() : base(new OliveColorTable()) { }

        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            if (e.Item.Selected) 
            {
                Rectangle rc = new Rectangle(Point.Empty, e.Item.Size);
             
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(125, 160, 125)))
                {
                    e.Graphics.FillRectangle(brush, rc);
                }
            }
            else
            {
                base.OnRenderMenuItemBackground(e);
            }
        }
    }

    public class OliveColorTable : ProfessionalColorTable
    {
        public override Color MenuBorder => Color.Transparent;
        public override Color ToolStripDropDownBackground => Color.FromArgb(45, 60, 45); 
        public override Color MenuItemBorder => Color.Transparent;
    }



}
