namespace DVLD.People
{
    partial class FindPerson
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
            this.ctrlPersonalCardWithFiltter1 = new DVLD.People.Control_For_People.ctrlPersonalCardWithFiltter();
            this.ctrlPersonalCardWithFiltter2 = new DVLD.People.Control_For_People.ctrlPersonalCardWithFiltter();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.SuspendLayout();
            // 
            // ctrlPersonalCardWithFiltter1
            // 
            this.ctrlPersonalCardWithFiltter1.AddShowEnabeld = true;
            this.ctrlPersonalCardWithFiltter1.FiltterEnabeld = true;
            this.ctrlPersonalCardWithFiltter1.Location = new System.Drawing.Point(0, 0);
            this.ctrlPersonalCardWithFiltter1.Name = "ctrlPersonalCardWithFiltter1";
            this.ctrlPersonalCardWithFiltter1.Size = new System.Drawing.Size(1017, 686);
            this.ctrlPersonalCardWithFiltter1.TabIndex = 0;
            // 
            // ctrlPersonalCardWithFiltter2
            // 
            this.ctrlPersonalCardWithFiltter2.AddShowEnabeld = true;
            this.ctrlPersonalCardWithFiltter2.FiltterEnabeld = true;
            this.ctrlPersonalCardWithFiltter2.Location = new System.Drawing.Point(0, 0);
            this.ctrlPersonalCardWithFiltter2.Name = "ctrlPersonalCardWithFiltter2";
            this.ctrlPersonalCardWithFiltter2.Size = new System.Drawing.Size(1017, 686);
            this.ctrlPersonalCardWithFiltter2.TabIndex = 0;
            this.ctrlPersonalCardWithFiltter2.Load += new System.EventHandler(this.ctrlPersonalCardWithFiltter2_Load);
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.BorderRadius = 2;
            this.guna2ControlBox1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.guna2ControlBox1.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox1.Location = new System.Drawing.Point(956, 12);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(35, 30);
            this.guna2ControlBox1.TabIndex = 33;
            // 
            // DragControl1
            // 
            this.DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.DragControl1.TargetControl = this.ctrlPersonalCardWithFiltter2;
            this.DragControl1.UseTransparentDrag = true;
            // 
            // FindPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1015, 683);
            this.Controls.Add(this.guna2ControlBox1);
            this.Controls.Add(this.ctrlPersonalCardWithFiltter2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FindPerson";
            this.Text = "FindPerson";
            this.ResumeLayout(false);

        }

        #endregion

        private Control_For_People.ctrlPersonalCardWithFiltter ctrlPersonalCardWithFiltter1;
        private Control_For_People.ctrlPersonalCardWithFiltter ctrlPersonalCardWithFiltter2;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2DragControl DragControl1;
    }
}