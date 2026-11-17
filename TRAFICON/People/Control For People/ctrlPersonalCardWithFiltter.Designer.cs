namespace DVLD.People.Control_For_People
{
    partial class ctrlPersonalCardWithFiltter
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
            this.components = new System.ComponentModel.Container();
            this.pan = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.btnAddNewPerson = new Guna.UI2.WinForms.Guna2Button();
            this.btnFind = new Guna.UI2.WinForms.Guna2Button();
            this.txtFilterValue = new Guna.UI2.WinForms.Guna2TextBox();
            this.cbFilterBy = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ctrlPersonalCard1 = new DVLD.People.Control_For_People.ctrlPersonalCard();
            this.label1 = new System.Windows.Forms.Label();
            this.pan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // pan
            // 
            this.pan.Controls.Add(this.btnAddNewPerson);
            this.pan.Controls.Add(this.btnFind);
            this.pan.Controls.Add(this.txtFilterValue);
            this.pan.Controls.Add(this.cbFilterBy);
            this.pan.Controls.Add(this.label6);
            this.pan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pan.Location = new System.Drawing.Point(0, 0);
            this.pan.Name = "pan";
            this.pan.Size = new System.Drawing.Size(1017, 135);
            this.pan.TabIndex = 1;
            this.pan.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2GradientPanel1_Paint);
            // 
            // btnAddNewPerson
            // 
            this.btnAddNewPerson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddNewPerson.Animated = true;
            this.btnAddNewPerson.BackColor = System.Drawing.Color.Transparent;
            this.btnAddNewPerson.BorderRadius = 12;
            this.btnAddNewPerson.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddNewPerson.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddNewPerson.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddNewPerson.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddNewPerson.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(95)))), ((int)(((byte)(70)))));
            this.btnAddNewPerson.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnAddNewPerson.ForeColor = System.Drawing.Color.White;
            this.btnAddNewPerson.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(120)))), ((int)(((byte)(90)))));
            this.btnAddNewPerson.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnAddNewPerson.Image = global::DVLD.Properties.Resources.Add_Person_image;
            this.btnAddNewPerson.ImageSize = new System.Drawing.Size(35, 35);
            this.btnAddNewPerson.Location = new System.Drawing.Point(803, 37);
            this.btnAddNewPerson.Name = "btnAddNewPerson";
            this.btnAddNewPerson.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(55)))), ((int)(((byte)(40)))));
            this.btnAddNewPerson.Size = new System.Drawing.Size(70, 60);
            this.btnAddNewPerson.TabIndex = 22;
            this.btnAddNewPerson.Click += new System.EventHandler(this.btnAddNewPerson_Click);
            // 
            // btnFind
            // 
            this.btnFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFind.Animated = true;
            this.btnFind.BackColor = System.Drawing.Color.Transparent;
            this.btnFind.BorderRadius = 12;
            this.btnFind.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnFind.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnFind.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnFind.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnFind.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(95)))), ((int)(((byte)(70)))));
            this.btnFind.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnFind.ForeColor = System.Drawing.Color.White;
            this.btnFind.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(120)))), ((int)(((byte)(90)))));
            this.btnFind.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnFind.Image = global::DVLD.Properties.Resources.Find_Person;
            this.btnFind.ImageSize = new System.Drawing.Size(35, 35);
            this.btnFind.Location = new System.Drawing.Point(715, 37);
            this.btnFind.Name = "btnFind";
            this.btnFind.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(55)))), ((int)(((byte)(40)))));
            this.btnFind.Size = new System.Drawing.Size(70, 60);
            this.btnFind.TabIndex = 21;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.BackColor = System.Drawing.Color.Transparent;
            this.txtFilterValue.BorderRadius = 16;
            this.txtFilterValue.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFilterValue.DefaultText = "";
            this.txtFilterValue.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtFilterValue.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtFilterValue.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFilterValue.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFilterValue.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(95)))), ((int)(((byte)(70)))));
            this.txtFilterValue.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFilterValue.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilterValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(219)))), ((int)(((byte)(168)))));
            this.txtFilterValue.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFilterValue.Location = new System.Drawing.Point(413, 54);
            this.txtFilterValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.txtFilterValue.PlaceholderText = "";
            this.txtFilterValue.SelectedText = "";
            this.txtFilterValue.Size = new System.Drawing.Size(236, 36);
            this.txtFilterValue.TabIndex = 15;
            this.txtFilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterValue_KeyPress);
            this.txtFilterValue.Validating += new System.ComponentModel.CancelEventHandler(this.txtFilterValue_Validating);
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.BackColor = System.Drawing.Color.Transparent;
            this.cbFilterBy.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.cbFilterBy.BorderRadius = 18;
            this.cbFilterBy.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(90)))), ((int)(((byte)(70)))));
            this.cbFilterBy.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbFilterBy.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbFilterBy.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilterBy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(219)))), ((int)(((byte)(168)))));
            this.cbFilterBy.ItemHeight = 30;
            this.cbFilterBy.Items.AddRange(new object[] {
            "",
            "Person ID",
            "National No"});
            this.cbFilterBy.Location = new System.Drawing.Point(171, 54);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(211, 36);
            this.cbFilterBy.StartIndex = 1;
            this.cbFilterBy.TabIndex = 13;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(219)))), ((int)(((byte)(168)))));
            this.label6.Location = new System.Drawing.Point(27, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 27);
            this.label6.TabIndex = 12;
            this.label6.Text = "Filtter By : ";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ctrlPersonalCard1
            // 
            this.ctrlPersonalCard1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ctrlPersonalCard1.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlPersonalCard1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(219)))), ((int)(((byte)(168)))));
            this.ctrlPersonalCard1.Location = new System.Drawing.Point(0, 135);
            this.ctrlPersonalCard1.Name = "ctrlPersonalCard1";
            this.ctrlPersonalCard1.Size = new System.Drawing.Size(1017, 551);
            this.ctrlPersonalCard1.TabIndex = 0;
            this.ctrlPersonalCard1.Load += new System.EventHandler(this.ctrlPersonalCard1_Load);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(219)))), ((int)(((byte)(168)))));
            this.label1.Location = new System.Drawing.Point(-12, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1050, 3);
            this.label1.TabIndex = 40;
            // 
            // ctrlPersonalCardWithFiltter
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pan);
            this.Controls.Add(this.ctrlPersonalCard1);
            this.Name = "ctrlPersonalCardWithFiltter";
            this.Size = new System.Drawing.Size(1017, 686);
            this.Load += new System.EventHandler(this.ctrlPersonalCardWithFiltter_Load);
            this.pan.ResumeLayout(false);
            this.pan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2GradientPanel pan;
        private Guna.UI2.WinForms.Guna2ComboBox cbFilterBy;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2TextBox txtFilterValue;
        private Guna.UI2.WinForms.Guna2Button btnAddNewPerson;
        private Guna.UI2.WinForms.Guna2Button btnFind;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        public ctrlPersonalCard ctrlPersonalCard1;
        private System.Windows.Forms.Label label1;
    }
}
