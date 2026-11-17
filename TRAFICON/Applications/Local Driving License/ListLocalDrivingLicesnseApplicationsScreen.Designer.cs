namespace DVLD.Applications.Local_Driving_License
{
    partial class ListLocalDrivingLicesnseApplicationsScreen
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
            this.cbStatusFiltter = new Guna.UI2.WinForms.Guna2ComboBox();
            this.DGVShowPeopleInfo = new Guna.UI2.WinForms.Guna2DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.lblTitle = new System.Windows.Forms.Label();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFilterValue = new Guna.UI2.WinForms.Guna2TextBox();
            this.cbFiltterBy = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblNumberOfColumn = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.showDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CancelApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sechduleTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sechduleVisionTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sechduleWrittenTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sechduleStreetTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.issuingADrivingLicenseFirstTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showPersonLicenseHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddNewApplication = new Guna.UI2.WinForms.Guna2Button();
            this.PanelWindow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVShowPeopleInfo)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelWindow
            // 
            this.PanelWindow.Controls.Add(this.cbStatusFiltter);
            this.PanelWindow.Controls.Add(this.DGVShowPeopleInfo);
            this.PanelWindow.Controls.Add(this.lblTitle);
            this.PanelWindow.Controls.Add(this.guna2ControlBox1);
            this.PanelWindow.Controls.Add(this.btnAddNewApplication);
            this.PanelWindow.Controls.Add(this.label3);
            this.PanelWindow.Controls.Add(this.txtFilterValue);
            this.PanelWindow.Controls.Add(this.cbFiltterBy);
            this.PanelWindow.Controls.Add(this.guna2Panel1);
            this.PanelWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelWindow.Location = new System.Drawing.Point(0, 0);
            this.PanelWindow.Name = "PanelWindow";
            this.PanelWindow.Size = new System.Drawing.Size(1139, 605);
            this.PanelWindow.TabIndex = 0;
            this.PanelWindow.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelWindow_Paint);
            // 
            // cbStatusFiltter
            // 
            this.cbStatusFiltter.BackColor = System.Drawing.Color.Transparent;
            this.cbStatusFiltter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(219)))), ((int)(((byte)(168)))));
            this.cbStatusFiltter.BorderRadius = 10;
            this.cbStatusFiltter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbStatusFiltter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatusFiltter.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(90)))), ((int)(((byte)(70)))));
            this.cbStatusFiltter.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbStatusFiltter.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbStatusFiltter.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbStatusFiltter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(219)))), ((int)(((byte)(168)))));
            this.cbStatusFiltter.ItemHeight = 30;
            this.cbStatusFiltter.Items.AddRange(new object[] {
            "All",
            "New",
            "Canceled",
            "Completed"});
            this.cbStatusFiltter.Location = new System.Drawing.Point(442, 223);
            this.cbStatusFiltter.Name = "cbStatusFiltter";
            this.cbStatusFiltter.Size = new System.Drawing.Size(183, 36);
            this.cbStatusFiltter.StartIndex = 0;
            this.cbStatusFiltter.TabIndex = 49;
            this.cbStatusFiltter.Visible = false;
            this.cbStatusFiltter.SelectedIndexChanged += new System.EventHandler(this.cbStatusFiltter_SelectedIndexChanged);
            // 
            // DGVShowPeopleInfo
            // 
            this.DGVShowPeopleInfo.AllowUserToAddRows = false;
            this.DGVShowPeopleInfo.AllowUserToDeleteRows = false;
            this.DGVShowPeopleInfo.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.DGVShowPeopleInfo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVShowPeopleInfo.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(90)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(90)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 11.2F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(219)))), ((int)(((byte)(168)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(42)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(219)))), ((int)(((byte)(168)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVShowPeopleInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGVShowPeopleInfo.ColumnHeadersHeight = 42;
            this.DGVShowPeopleInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.DGVShowPeopleInfo.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVShowPeopleInfo.DefaultCellStyle = dataGridViewCellStyle3;
            this.DGVShowPeopleInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DGVShowPeopleInfo.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(80)))), ((int)(((byte)(60)))));
            this.DGVShowPeopleInfo.Location = new System.Drawing.Point(0, 267);
            this.DGVShowPeopleInfo.Name = "DGVShowPeopleInfo";
            this.DGVShowPeopleInfo.ReadOnly = true;
            this.DGVShowPeopleInfo.RowHeadersVisible = false;
            this.DGVShowPeopleInfo.RowHeadersWidth = 51;
            this.DGVShowPeopleInfo.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(90)))), ((int)(((byte)(70)))));
            this.DGVShowPeopleInfo.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.DGVShowPeopleInfo.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(219)))), ((int)(((byte)(168)))));
            this.DGVShowPeopleInfo.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(42)))), ((int)(((byte)(30)))));
            this.DGVShowPeopleInfo.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(219)))), ((int)(((byte)(168)))));
            this.DGVShowPeopleInfo.RowTemplate.Height = 36;
            this.DGVShowPeopleInfo.Size = new System.Drawing.Size(1139, 338);
            this.DGVShowPeopleInfo.TabIndex = 48;
            this.DGVShowPeopleInfo.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.DGVShowPeopleInfo.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(90)))), ((int)(((byte)(70)))));
            this.DGVShowPeopleInfo.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(80)))), ((int)(((byte)(60)))));
            this.DGVShowPeopleInfo.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(90)))), ((int)(((byte)(70)))));
            this.DGVShowPeopleInfo.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Century Gothic", 11.2F);
            this.DGVShowPeopleInfo.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(219)))), ((int)(((byte)(168)))));
            this.DGVShowPeopleInfo.ThemeStyle.HeaderStyle.Height = 42;
            this.DGVShowPeopleInfo.ThemeStyle.ReadOnly = true;
            this.DGVShowPeopleInfo.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.DGVShowPeopleInfo.ThemeStyle.RowsStyle.Height = 36;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(35, 35);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDetailsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.toolStripMenuItem5,
            this.CancelApplicationToolStripMenuItem,
            this.toolStripMenuItem2,
            this.sechduleTestToolStripMenuItem,
            this.toolStripMenuItem3,
            this.issuingADrivingLicenseFirstTimeToolStripMenuItem,
            this.showLicenseToolStripMenuItem,
            this.toolStripMenuItem4,
            this.showPersonLicenseHistoryToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(332, 370);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(328, 6);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(328, 6);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(328, 6);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(328, 6);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(328, 6);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(219)))), ((int)(((byte)(168)))));
            this.lblTitle.Location = new System.Drawing.Point(340, 36);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(548, 39);
            this.lblTitle.TabIndex = 47;
            this.lblTitle.Text = "Local Driving License Application";
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.BorderRadius = 2;
            this.guna2ControlBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox1.Location = new System.Drawing.Point(1092, 12);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(35, 30);
            this.guna2ControlBox1.TabIndex = 46;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(219)))), ((int)(((byte)(168)))));
            this.label3.Location = new System.Drawing.Point(20, 223);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 36);
            this.label3.TabIndex = 44;
            this.label3.Text = "Fillter By : ";
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
            this.txtFilterValue.Location = new System.Drawing.Point(442, 223);
            this.txtFilterValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.txtFilterValue.PlaceholderText = "";
            this.txtFilterValue.SelectedText = "";
            this.txtFilterValue.Size = new System.Drawing.Size(270, 36);
            this.txtFilterValue.TabIndex = 43;
            this.txtFilterValue.Visible = false;
            this.txtFilterValue.TextChanged += new System.EventHandler(this.txtFilterValue_TextChanged);
            // 
            // cbFiltterBy
            // 
            this.cbFiltterBy.BackColor = System.Drawing.Color.Transparent;
            this.cbFiltterBy.BorderRadius = 10;
            this.cbFiltterBy.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbFiltterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFiltterBy.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(60)))), ((int)(((byte)(45)))));
            this.cbFiltterBy.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbFiltterBy.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbFiltterBy.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.cbFiltterBy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(219)))), ((int)(((byte)(168)))));
            this.cbFiltterBy.ItemHeight = 30;
            this.cbFiltterBy.Items.AddRange(new object[] {
            "None",
            "L.D.L.Appliection",
            "Class Name",
            "Full Name",
            "National No",
            "Status"});
            this.cbFiltterBy.Location = new System.Drawing.Point(155, 223);
            this.cbFiltterBy.Name = "cbFiltterBy";
            this.cbFiltterBy.Size = new System.Drawing.Size(265, 36);
            this.cbFiltterBy.StartIndex = 0;
            this.cbFiltterBy.TabIndex = 42;
            this.cbFiltterBy.SelectedIndexChanged += new System.EventHandler(this.cbFiltterBy_SelectedIndexChanged);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.BorderRadius = 10;
            this.guna2Panel1.Controls.Add(this.lblNumberOfColumn);
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(95)))), ((int)(((byte)(70)))));
            this.guna2Panel1.Location = new System.Drawing.Point(12, 30);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(193, 45);
            this.guna2Panel1.TabIndex = 3;
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
            // guna2DragControl1
            // 
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl1.TargetControl = this.PanelWindow;
            this.guna2DragControl1.UseTransparentDrag = true;
            // 
            // showDetailsToolStripMenuItem
            // 
            this.showDetailsToolStripMenuItem.Image = global::DVLD.Properties.Resources.show_Person_details;
            this.showDetailsToolStripMenuItem.Name = "showDetailsToolStripMenuItem";
            this.showDetailsToolStripMenuItem.Size = new System.Drawing.Size(331, 42);
            this.showDetailsToolStripMenuItem.Text = "Show Application Details";
            this.showDetailsToolStripMenuItem.Click += new System.EventHandler(this.showDetailsToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = global::DVLD.Properties.Resources.Edit_image;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(331, 42);
            this.editToolStripMenuItem.Text = "Edit Application";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::DVLD.Properties.Resources.Delete_Image_150;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(331, 42);
            this.deleteToolStripMenuItem.Text = "Delete Application";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // CancelApplicationToolStripMenuItem
            // 
            this.CancelApplicationToolStripMenuItem.Image = global::DVLD.Properties.Resources.Close_Icon;
            this.CancelApplicationToolStripMenuItem.Name = "CancelApplicationToolStripMenuItem";
            this.CancelApplicationToolStripMenuItem.Size = new System.Drawing.Size(331, 42);
            this.CancelApplicationToolStripMenuItem.Text = "Cancel Application";
            this.CancelApplicationToolStripMenuItem.Click += new System.EventHandler(this.CancelApplicationToolStripMenuItem_Click);
            // 
            // sechduleTestToolStripMenuItem
            // 
            this.sechduleTestToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sechduleVisionTestToolStripMenuItem,
            this.sechduleWrittenTestToolStripMenuItem,
            this.sechduleStreetTestToolStripMenuItem});
            this.sechduleTestToolStripMenuItem.Image = global::DVLD.Properties.Resources.Schedule_Test;
            this.sechduleTestToolStripMenuItem.Name = "sechduleTestToolStripMenuItem";
            this.sechduleTestToolStripMenuItem.Size = new System.Drawing.Size(331, 42);
            this.sechduleTestToolStripMenuItem.Text = "Sechdule Test";
//            this.sechduleTestToolStripMenuItem.Click += new System.EventHandler(this.sechduleTestToolStripMenuItem_Click);
            // 
            // sechduleVisionTestToolStripMenuItem
            // 
            this.sechduleVisionTestToolStripMenuItem.Image = global::DVLD.Properties.Resources.Vison_Test;
            this.sechduleVisionTestToolStripMenuItem.Name = "sechduleVisionTestToolStripMenuItem";
            this.sechduleVisionTestToolStripMenuItem.Size = new System.Drawing.Size(250, 42);
            this.sechduleVisionTestToolStripMenuItem.Text = "Sechdule Vision Test";
            this.sechduleVisionTestToolStripMenuItem.Click += new System.EventHandler(this.sechduleVisionTestToolStripMenuItem_Click);
            // 
            // sechduleWrittenTestToolStripMenuItem
            // 
            this.sechduleWrittenTestToolStripMenuItem.Image = global::DVLD.Properties.Resources.written_Test;
            this.sechduleWrittenTestToolStripMenuItem.Name = "sechduleWrittenTestToolStripMenuItem";
            this.sechduleWrittenTestToolStripMenuItem.Size = new System.Drawing.Size(250, 42);
            this.sechduleWrittenTestToolStripMenuItem.Text = "Sechdule Written Test";
            this.sechduleWrittenTestToolStripMenuItem.Click += new System.EventHandler(this.sechduleWrittenTestToolStripMenuItem_Click);
            // 
            // sechduleStreetTestToolStripMenuItem
            // 
            this.sechduleStreetTestToolStripMenuItem.Image = global::DVLD.Properties.Resources.Street_Test;
            this.sechduleStreetTestToolStripMenuItem.Name = "sechduleStreetTestToolStripMenuItem";
            this.sechduleStreetTestToolStripMenuItem.Size = new System.Drawing.Size(250, 42);
            this.sechduleStreetTestToolStripMenuItem.Text = "Sechdule Street Test";
            this.sechduleStreetTestToolStripMenuItem.Click += new System.EventHandler(this.sechduleStreetTestToolStripMenuItem_Click);
            // 
            // issuingADrivingLicenseFirstTimeToolStripMenuItem
            // 
            this.issuingADrivingLicenseFirstTimeToolStripMenuItem.Image = global::DVLD.Properties.Resources.issue_Licence;
            this.issuingADrivingLicenseFirstTimeToolStripMenuItem.Name = "issuingADrivingLicenseFirstTimeToolStripMenuItem";
            this.issuingADrivingLicenseFirstTimeToolStripMenuItem.Size = new System.Drawing.Size(331, 42);
            this.issuingADrivingLicenseFirstTimeToolStripMenuItem.Text = "Issuing a driving license (First Time)";
            this.issuingADrivingLicenseFirstTimeToolStripMenuItem.Click += new System.EventHandler(this.issuingADrivingLicenseFirstTimeToolStripMenuItem_Click);
            // 
            // showLicenseToolStripMenuItem
            // 
            this.showLicenseToolStripMenuItem.Image = global::DVLD.Properties.Resources.Driver_License_48;
            this.showLicenseToolStripMenuItem.Name = "showLicenseToolStripMenuItem";
            this.showLicenseToolStripMenuItem.Size = new System.Drawing.Size(331, 42);
            this.showLicenseToolStripMenuItem.Text = "Show License";
            this.showLicenseToolStripMenuItem.Click += new System.EventHandler(this.showLicenseToolStripMenuItem_Click);
            // 
            // showPersonLicenseHistoryToolStripMenuItem
            // 
            this.showPersonLicenseHistoryToolStripMenuItem.Image = global::DVLD.Properties.Resources.Person_History;
            this.showPersonLicenseHistoryToolStripMenuItem.Name = "showPersonLicenseHistoryToolStripMenuItem";
            this.showPersonLicenseHistoryToolStripMenuItem.Size = new System.Drawing.Size(331, 42);
            this.showPersonLicenseHistoryToolStripMenuItem.Text = "Show Person License History";
            this.showPersonLicenseHistoryToolStripMenuItem.Click += new System.EventHandler(this.showPersonLicenseHistoryToolStripMenuItem_Click);
            // 
            // btnAddNewApplication
            // 
            this.btnAddNewApplication.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddNewApplication.Animated = true;
            this.btnAddNewApplication.BackColor = System.Drawing.Color.Transparent;
            this.btnAddNewApplication.BorderRadius = 12;
            this.btnAddNewApplication.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddNewApplication.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddNewApplication.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddNewApplication.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddNewApplication.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(95)))), ((int)(((byte)(70)))));
            this.btnAddNewApplication.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnAddNewApplication.ForeColor = System.Drawing.Color.White;
            this.btnAddNewApplication.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(120)))), ((int)(((byte)(90)))));
            this.btnAddNewApplication.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnAddNewApplication.Image = global::DVLD.Properties.Resources.ert;
            this.btnAddNewApplication.ImageSize = new System.Drawing.Size(35, 35);
            this.btnAddNewApplication.Location = new System.Drawing.Point(1025, 203);
            this.btnAddNewApplication.Name = "btnAddNewApplication";
            this.btnAddNewApplication.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(55)))), ((int)(((byte)(40)))));
            this.btnAddNewApplication.Size = new System.Drawing.Size(79, 56);
            this.btnAddNewApplication.TabIndex = 45;
            this.btnAddNewApplication.Click += new System.EventHandler(this.btnAddNewApplication_Click);
            // 
            // ListLocalDrivingLicesnseApplicationsScreen
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1139, 605);
            this.Controls.Add(this.PanelWindow);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ListLocalDrivingLicesnseApplicationsScreen";
            this.Text = "ListLocalDrivingLicesnseApplicationsScreen";
            this.Load += new System.EventHandler(this.ListLocalDrivingLicesnseApplicationsScreen_Load);
            this.PanelWindow.ResumeLayout(false);
            this.PanelWindow.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVShowPeopleInfo)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientPanel PanelWindow;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label lblNumberOfColumn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2TextBox txtFilterValue;
        private Guna.UI2.WinForms.Guna2ComboBox cbFiltterBy;
        private Guna.UI2.WinForms.Guna2Button btnAddNewApplication;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2ComboBox cbStatusFiltter;
        public System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem CancelApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem issuingADrivingLicenseFirstTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem showPersonLicenseHistoryToolStripMenuItem;
        public Guna.UI2.WinForms.Guna2DataGridView DGVShowPeopleInfo;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem sechduleTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sechduleVisionTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sechduleWrittenTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sechduleStreetTestToolStripMenuItem;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
    }
}