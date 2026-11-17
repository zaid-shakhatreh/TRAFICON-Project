namespace DVLD.Licenses.Local_Licenses
{
    partial class ShowLicenseInfoScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PanelWindow = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.ctrlDriverLicenseInfo1 = new DVLD.Licenses.Control.ctrlDriverLicenseInfo();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.PanelWindow.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelWindow
            // 
            this.PanelWindow.Controls.Add(this.guna2ControlBox1);
            this.PanelWindow.Controls.Add(this.ctrlDriverLicenseInfo1);
            this.PanelWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelWindow.Location = new System.Drawing.Point(0, 0);
            this.PanelWindow.Name = "PanelWindow";
            this.PanelWindow.Size = new System.Drawing.Size(825, 389);
            this.PanelWindow.TabIndex = 0;
            this.PanelWindow.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelWindow_Paint);
            // 
            // ctrlDriverLicenseInfo1
            // 
            this.ctrlDriverLicenseInfo1.Location = new System.Drawing.Point(0, 0);
            this.ctrlDriverLicenseInfo1.Name = "ctrlDriverLicenseInfo1";
            this.ctrlDriverLicenseInfo1.Size = new System.Drawing.Size(826, 389);
            this.ctrlDriverLicenseInfo1.TabIndex = 0;
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.BorderRadius = 2;
            this.guna2ControlBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox1.Location = new System.Drawing.Point(778, 12);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(35, 30);
            this.guna2ControlBox1.TabIndex = 53;
            // 
            // ShowLicenseInfoScreen
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(825, 389);
            this.Controls.Add(this.PanelWindow);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ShowLicenseInfoScreen";
            this.Text = "ShowLicenseInfoScreen";
            this.Load += new System.EventHandler(this.ShowLicenseInfoScreen_Load);
            this.PanelWindow.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private Guna.UI2.WinForms.Guna2GradientPanel PanelWindow;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Licenses.Control.ctrlDriverLicenseInfo ctrlDriverLicenseInfo1;

        #endregion
        //  private Control.ctrlDriverLicenseInfo ctrlDriverLicenseInfo1;
    }
}