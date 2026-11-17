namespace DVLD.User
{
    partial class PersonalInfoScreen
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
            this.btnNext = new Guna.UI2.WinForms.Guna2Button();
            this.ctrlPersonalCardWithFiltter1 = new DVLD.People.Control_For_People.ctrlPersonalCardWithFiltter();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.PanelWindow.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelWindow
            // 
            this.PanelWindow.Controls.Add(this.guna2ControlBox1);
            this.PanelWindow.Controls.Add(this.btnClose);
            this.PanelWindow.Controls.Add(this.btnNext);
            this.PanelWindow.Controls.Add(this.ctrlPersonalCardWithFiltter1);
            this.PanelWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelWindow.Location = new System.Drawing.Point(0, 0);
            this.PanelWindow.Name = "PanelWindow";
            this.PanelWindow.Size = new System.Drawing.Size(1015, 818);
            this.PanelWindow.TabIndex = 0;
            this.PanelWindow.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2GradientPanel1_Paint);
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.BorderRadius = 2;
            this.guna2ControlBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox1.Location = new System.Drawing.Point(951, 23);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(35, 30);
            this.guna2ControlBox1.TabIndex = 38;
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Animated = true;
            this.btnNext.BackColor = System.Drawing.Color.Transparent;
            this.btnNext.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(219)))), ((int)(((byte)(168)))));
            this.btnNext.BorderRadius = 12;
            this.btnNext.BorderThickness = 1;
            this.btnNext.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnNext.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnNext.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnNext.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnNext.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(95)))), ((int)(((byte)(70)))));
            this.btnNext.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(120)))), ((int)(((byte)(90)))));
            this.btnNext.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnNext.Image = global::DVLD.Properties.Resources.Next_32;
            this.btnNext.ImageSize = new System.Drawing.Size(35, 35);
            this.btnNext.Location = new System.Drawing.Point(883, 718);
            this.btnNext.Name = "btnNext";
            this.btnNext.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(55)))), ((int)(((byte)(40)))));
            this.btnNext.Size = new System.Drawing.Size(90, 69);
            this.btnNext.TabIndex = 48;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // ctrlPersonalCardWithFiltter1
            // 
            this.ctrlPersonalCardWithFiltter1.AddShowEnabeld = true;
            this.ctrlPersonalCardWithFiltter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrlPersonalCardWithFiltter1.FiltterEnabeld = true;
            this.ctrlPersonalCardWithFiltter1.Location = new System.Drawing.Point(0, 0);
            this.ctrlPersonalCardWithFiltter1.Name = "ctrlPersonalCardWithFiltter1";
            this.ctrlPersonalCardWithFiltter1.Size = new System.Drawing.Size(1015, 686);
            this.ctrlPersonalCardWithFiltter1.TabIndex = 7;
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl1.TargetControl = this.PanelWindow;
            this.guna2DragControl1.UseTransparentDrag = true;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Animated = true;
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(219)))), ((int)(((byte)(168)))));
            this.btnClose.BorderRadius = 12;
            this.btnClose.BorderThickness = 1;
            this.btnClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClose.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(95)))), ((int)(((byte)(70)))));
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(120)))), ((int)(((byte)(90)))));
            this.btnClose.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnClose.Image = global::DVLD.Properties.Resources.Close_Icon;
            this.btnClose.ImageSize = new System.Drawing.Size(35, 35);
            this.btnClose.Location = new System.Drawing.Point(746, 718);
            this.btnClose.Name = "btnClose";
            this.btnClose.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(55)))), ((int)(((byte)(40)))));
            this.btnClose.Size = new System.Drawing.Size(90, 69);
            this.btnClose.TabIndex = 49;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // PersonalInfoScreen
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1015, 818);
            this.Controls.Add(this.PanelWindow);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PersonalInfoScreen";
            this.Text = "PersonalInfoScreen";
            this.Load += new System.EventHandler(this.PersonalInfoScreen_Load);
            this.PanelWindow.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientPanel PanelWindow;
        private Guna.UI2.WinForms.Guna2Button btnNext;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        public People.Control_For_People.ctrlPersonalCardWithFiltter ctrlPersonalCardWithFiltter1;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
    }
}