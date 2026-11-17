namespace DVLD.User
{
    partial class ListUsersScreen
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PanelWindow = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.cbAcitvationUsers = new Guna.UI2.WinForms.Guna2ComboBox();
            this.DGVUserInfo = new Guna.UI2.WinForms.Guna2DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.addNewUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chengePassordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddNewPerson = new Guna.UI2.WinForms.Guna2Button();
            this.txtFilterValue = new Guna.UI2.WinForms.Guna2TextBox();
            this.cbFiltterBy = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblNumberOfColumn = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.PanelWindow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVUserInfo)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelWindow
            // 
            this.PanelWindow.Controls.Add(this.cbAcitvationUsers);
            this.PanelWindow.Controls.Add(this.DGVUserInfo);
            this.PanelWindow.Controls.Add(this.btnAddNewPerson);
            this.PanelWindow.Controls.Add(this.txtFilterValue);
            this.PanelWindow.Controls.Add(this.cbFiltterBy);
            this.PanelWindow.Controls.Add(this.label3);
            this.PanelWindow.Controls.Add(this.guna2Panel1);
            this.PanelWindow.Controls.Add(this.guna2ControlBox1);
            this.PanelWindow.Controls.Add(this.lblTitle);
            this.PanelWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelWindow.Location = new System.Drawing.Point(0, 0);
            this.PanelWindow.Name = "PanelWindow";
            this.PanelWindow.Size = new System.Drawing.Size(1182, 697);
            this.PanelWindow.TabIndex = 0;
            this.PanelWindow.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2GradientPanel1_Paint);
            // 
            // cbAcitvationUsers
            // 
            this.cbAcitvationUsers.BackColor = System.Drawing.Color.Transparent;
            this.cbAcitvationUsers.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(219)))), ((int)(((byte)(168)))));
            this.cbAcitvationUsers.BorderRadius = 10;
            this.cbAcitvationUsers.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbAcitvationUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAcitvationUsers.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(90)))), ((int)(((byte)(70)))));
            this.cbAcitvationUsers.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbAcitvationUsers.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbAcitvationUsers.Font = new System.Drawing.Font("Century Gothic", 10.2F);
            this.cbAcitvationUsers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(219)))), ((int)(((byte)(168)))));
            this.cbAcitvationUsers.ItemHeight = 30;
            this.cbAcitvationUsers.Items.AddRange(new object[] {
            "All",
            "Yes",
            "No"});
            this.cbAcitvationUsers.Location = new System.Drawing.Point(471, 211);
            this.cbAcitvationUsers.Name = "cbAcitvationUsers";
            this.cbAcitvationUsers.Size = new System.Drawing.Size(183, 36);
            this.cbAcitvationUsers.StartIndex = 0;
            this.cbAcitvationUsers.TabIndex = 45;
            this.cbAcitvationUsers.Visible = false;
            this.cbAcitvationUsers.SelectedIndexChanged += new System.EventHandler(this.cbAcitvationUsers_SelectedIndexChanged);
            // 
            // DGVUserInfo
            // 
            this.DGVUserInfo.AllowUserToAddRows = false;
            this.DGVUserInfo.AllowUserToDeleteRows = false;
            this.DGVUserInfo.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.DGVUserInfo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVUserInfo.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(90)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(90)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 11.2F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(219)))), ((int)(((byte)(168)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(42)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(219)))), ((int)(((byte)(168)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVUserInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGVUserInfo.ColumnHeadersHeight = 42;
            this.DGVUserInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.DGVUserInfo.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVUserInfo.DefaultCellStyle = dataGridViewCellStyle3;
            this.DGVUserInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DGVUserInfo.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(80)))), ((int)(((byte)(60)))));
            this.DGVUserInfo.Location = new System.Drawing.Point(0, 276);
            this.DGVUserInfo.Name = "DGVUserInfo";
            this.DGVUserInfo.ReadOnly = true;
            this.DGVUserInfo.RowHeadersVisible = false;
            this.DGVUserInfo.RowHeadersWidth = 51;
            this.DGVUserInfo.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(90)))), ((int)(((byte)(70)))));
            this.DGVUserInfo.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.DGVUserInfo.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(219)))), ((int)(((byte)(168)))));
            this.DGVUserInfo.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(42)))), ((int)(((byte)(30)))));
            this.DGVUserInfo.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(219)))), ((int)(((byte)(168)))));
            this.DGVUserInfo.RowTemplate.Height = 36;
            this.DGVUserInfo.Size = new System.Drawing.Size(1182, 421);
            this.DGVUserInfo.TabIndex = 44;
            this.DGVUserInfo.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.DGVUserInfo.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(90)))), ((int)(((byte)(70)))));
            this.DGVUserInfo.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(80)))), ((int)(((byte)(60)))));
            this.DGVUserInfo.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(90)))), ((int)(((byte)(70)))));
            this.DGVUserInfo.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Century Gothic", 11.2F);
            this.DGVUserInfo.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(219)))), ((int)(((byte)(168)))));
            this.DGVUserInfo.ThemeStyle.HeaderStyle.Height = 42;
            this.DGVUserInfo.ThemeStyle.ReadOnly = true;
            this.DGVUserInfo.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.DGVUserInfo.ThemeStyle.RowsStyle.Height = 36;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(35, 35);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDetailsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.addNewUserToolStripMenuItem,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.chengePassordToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(202, 220);
            // 
            // showDetailsToolStripMenuItem
            // 
            this.showDetailsToolStripMenuItem.Image = global::DVLD.Properties.Resources.show_Person_details;
            this.showDetailsToolStripMenuItem.Name = "showDetailsToolStripMenuItem";
            this.showDetailsToolStripMenuItem.Size = new System.Drawing.Size(201, 42);
            this.showDetailsToolStripMenuItem.Text = "Show Details";
            this.showDetailsToolStripMenuItem.Click += new System.EventHandler(this.showDetailsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(198, 6);
            // 
            // addNewUserToolStripMenuItem
            // 
            this.addNewUserToolStripMenuItem.Image = global::DVLD.Properties.Resources.Add_Person_image;
            this.addNewUserToolStripMenuItem.Name = "addNewUserToolStripMenuItem";
            this.addNewUserToolStripMenuItem.Size = new System.Drawing.Size(201, 42);
            this.addNewUserToolStripMenuItem.Text = "Add New User";
            this.addNewUserToolStripMenuItem.Click += new System.EventHandler(this.addNewUserToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = global::DVLD.Properties.Resources.Edit_image;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(201, 42);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::DVLD.Properties.Resources.Delete_Image_150;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(201, 42);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // chengePassordToolStripMenuItem
            // 
            this.chengePassordToolStripMenuItem.Image = global::DVLD.Properties.Resources.Password_32;
            this.chengePassordToolStripMenuItem.Name = "chengePassordToolStripMenuItem";
            this.chengePassordToolStripMenuItem.Size = new System.Drawing.Size(201, 42);
            this.chengePassordToolStripMenuItem.Text = "Chenge Passord";
            this.chengePassordToolStripMenuItem.Click += new System.EventHandler(this.chengePassordToolStripMenuItem_Click);
            // 
            // btnAddNewPerson
            // 
            this.btnAddNewPerson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddNewPerson.Animated = true;
            this.btnAddNewPerson.BackColor = System.Drawing.Color.Transparent;
            this.btnAddNewPerson.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(219)))), ((int)(((byte)(168)))));
            this.btnAddNewPerson.BorderRadius = 12;
            this.btnAddNewPerson.BorderThickness = 1;
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
            this.btnAddNewPerson.ImageSize = new System.Drawing.Size(40, 40);
            this.btnAddNewPerson.Location = new System.Drawing.Point(1046, 188);
            this.btnAddNewPerson.Name = "btnAddNewPerson";
            this.btnAddNewPerson.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(55)))), ((int)(((byte)(40)))));
            this.btnAddNewPerson.Size = new System.Drawing.Size(90, 69);
            this.btnAddNewPerson.TabIndex = 43;
            this.btnAddNewPerson.Click += new System.EventHandler(this.btnAddNewPerson_Click);
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
            this.txtFilterValue.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(90)))), ((int)(((byte)(70)))));
            this.txtFilterValue.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFilterValue.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.txtFilterValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.txtFilterValue.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFilterValue.Location = new System.Drawing.Point(471, 211);
            this.txtFilterValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.txtFilterValue.PlaceholderText = "";
            this.txtFilterValue.SelectedText = "";
            this.txtFilterValue.Size = new System.Drawing.Size(236, 36);
            this.txtFilterValue.TabIndex = 42;
            this.txtFilterValue.Visible = false;
            this.txtFilterValue.TextChanged += new System.EventHandler(this.txtFilterValue_TextChanged);
            this.txtFilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterValue_KeyPress);
//            this.txtFilterValue.Validating += new System.ComponentModel.CancelEventHandler(this.txtFilterValue_Validating);
            // 
            // cbFiltterBy
            // 
            this.cbFiltterBy.BackColor = System.Drawing.Color.Transparent;
            this.cbFiltterBy.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(219)))), ((int)(((byte)(168)))));
            this.cbFiltterBy.BorderRadius = 10;
            this.cbFiltterBy.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbFiltterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFiltterBy.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(60)))), ((int)(((byte)(45)))));
            this.cbFiltterBy.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbFiltterBy.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbFiltterBy.Font = new System.Drawing.Font("Century Gothic", 10.2F);
            this.cbFiltterBy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(219)))), ((int)(((byte)(168)))));
            this.cbFiltterBy.ItemHeight = 30;
            this.cbFiltterBy.Items.AddRange(new object[] {
            "None",
            "User ID",
            "Person ID",
            "Full Name",
            "Active"});
            this.cbFiltterBy.Location = new System.Drawing.Point(166, 211);
            this.cbFiltterBy.Name = "cbFiltterBy";
            this.cbFiltterBy.Size = new System.Drawing.Size(265, 36);
            this.cbFiltterBy.StartIndex = 0;
            this.cbFiltterBy.TabIndex = 41;
            this.cbFiltterBy.SelectedIndexChanged += new System.EventHandler(this.cbFiltterBy_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(219)))), ((int)(((byte)(168)))));
            this.label3.Location = new System.Drawing.Point(19, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 36);
            this.label3.TabIndex = 40;
            this.label3.Text = "Fillter By : ";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.BorderRadius = 10;
            this.guna2Panel1.Controls.Add(this.lblNumberOfColumn);
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(95)))), ((int)(((byte)(70)))));
            this.guna2Panel1.Location = new System.Drawing.Point(37, 25);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(193, 45);
            this.guna2Panel1.TabIndex = 39;
            // 
            // lblNumberOfColumn
            // 
            this.lblNumberOfColumn.AutoSize = true;
            this.lblNumberOfColumn.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberOfColumn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(219)))), ((int)(((byte)(168)))));
            this.lblNumberOfColumn.Location = new System.Drawing.Point(145, 14);
            this.lblNumberOfColumn.Name = "lblNumberOfColumn";
            this.lblNumberOfColumn.Size = new System.Drawing.Size(19, 19);
            this.lblNumberOfColumn.TabIndex = 1;
            this.lblNumberOfColumn.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(219)))), ((int)(((byte)(168)))));
            this.label1.Location = new System.Drawing.Point(13, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Records No : ";
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.BorderRadius = 2;
            this.guna2ControlBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox1.Location = new System.Drawing.Point(1119, 25);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(35, 30);
            this.guna2ControlBox1.TabIndex = 37;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(219)))), ((int)(((byte)(168)))));
            this.lblTitle.Location = new System.Drawing.Point(474, 90);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(246, 39);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "Manage Users";
            // 
            // DragControl1
            // 
            this.DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.DragControl1.TargetControl = this.PanelWindow;
            this.DragControl1.UseTransparentDrag = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ListUsersScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 697);
            this.Controls.Add(this.PanelWindow);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ListUsersScreen";
            this.Text = "ManageUserScreen";
            this.Load += new System.EventHandler(this.ManageUserScreen_Load);
            this.PanelWindow.ResumeLayout(false);
            this.PanelWindow.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVUserInfo)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label lblNumberOfColumn;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox txtFilterValue;
        private Guna.UI2.WinForms.Guna2ComboBox cbFiltterBy;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2Button btnAddNewPerson;
        private Guna.UI2.WinForms.Guna2DragControl DragControl1;
        public Guna.UI2.WinForms.Guna2GradientPanel PanelWindow;
        private Guna.UI2.WinForms.Guna2DataGridView DGVUserInfo;
        private Guna.UI2.WinForms.Guna2ComboBox cbAcitvationUsers;
        private System.Windows.Forms.ToolStripMenuItem showDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem addNewUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chengePassordToolStripMenuItem;
        public System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}