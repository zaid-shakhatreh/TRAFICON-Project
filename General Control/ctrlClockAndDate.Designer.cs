namespace DVLD
{
    partial class ctrlClockAndDate
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelClock = new Guna.UI2.WinForms.Guna2Panel();
            this.lblClock = new System.Windows.Forms.Label();
            this.panelClock.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelClock
            // 
            this.panelClock.BackColor = System.Drawing.Color.Transparent;
            this.panelClock.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(219)))), ((int)(((byte)(168)))));
            this.panelClock.BorderRadius = 10;
            this.panelClock.BorderThickness = 1;
            this.panelClock.Controls.Add(this.lblClock);
            this.panelClock.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(95)))), ((int)(((byte)(70)))));
            this.panelClock.Location = new System.Drawing.Point(19, 11);
            this.panelClock.Name = "panelClock";
            this.panelClock.Size = new System.Drawing.Size(333, 45);
            this.panelClock.TabIndex = 9;
            // 
            // lblClock
            // 
            this.lblClock.AutoSize = true;
            this.lblClock.BackColor = System.Drawing.Color.Transparent;
            this.lblClock.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold);
            this.lblClock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(219)))), ((int)(((byte)(168)))));
            this.lblClock.Location = new System.Drawing.Point(49, 12);
            this.lblClock.Name = "lblClock";
            this.lblClock.Size = new System.Drawing.Size(79, 19);
            this.lblClock.TabIndex = 0;
            this.lblClock.Text = "00:00:00";
            // 
            // ctrlClockAndDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panelClock);
            this.ForeColor = System.Drawing.Color.Transparent;
            this.Name = "ctrlClockAndDate";
            this.Size = new System.Drawing.Size(371, 66);
            this.Load += new System.EventHandler(this.ctrlClockAndDate_Load);
            this.panelClock.ResumeLayout(false);
            this.panelClock.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel panelClock;
        private System.Windows.Forms.Label lblClock;
    }
}
