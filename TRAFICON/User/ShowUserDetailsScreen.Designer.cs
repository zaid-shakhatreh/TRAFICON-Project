namespace DVLD.User
{
    partial class ShowUserDetailsScreen
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
            this.components = new System.ComponentModel.Container();
            this.PanelWindow = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.ctrlUserDetail1 = new DVLD.User.Controls.ctrlUserDetail();
            this.PanelWindow.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelWindow
            // 
            this.PanelWindow.Controls.Add(this.guna2ControlBox1);
            this.PanelWindow.Controls.Add(this.ctrlUserDetail1);
            this.PanelWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelWindow.Location = new System.Drawing.Point(0, 0);
            this.PanelWindow.Name = "PanelWindow";
            this.PanelWindow.Size = new System.Drawing.Size(974, 613);
            this.PanelWindow.TabIndex = 0;
            this.PanelWindow.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelWindow_Paint);
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.BorderRadius = 2;
            this.guna2ControlBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox1.Location = new System.Drawing.Point(927, 12);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(35, 30);
            this.guna2ControlBox1.TabIndex = 59;
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl1.UseTransparentDrag = true;
            // 
            // ctrlUserDetail1
            // 
            this.ctrlUserDetail1.Location = new System.Drawing.Point(0, 0);
            this.ctrlUserDetail1.Name = "ctrlUserDetail1";
            this.ctrlUserDetail1.Size = new System.Drawing.Size(975, 615);
            this.ctrlUserDetail1.TabIndex = 0;
            // 
            // ShowUserDetailsScreen
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(974, 613);
            this.Controls.Add(this.PanelWindow);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ShowUserDetailsScreen";
            this.Text = "ShowUserDetailsScreen";
            this.Load += new System.EventHandler(this.ShowUserDetailsScreen_Load);
            this.PanelWindow.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private Guna.UI2.WinForms.Guna2GradientPanel PanelWindow;
        private Controls.ctrlUserDetail ctrlUserDetail1;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
    }
}