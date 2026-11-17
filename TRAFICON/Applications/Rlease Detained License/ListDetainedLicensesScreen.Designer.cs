namespace DVLD.Applications.Rlease_Detained_License
{
    partial class ListDetainedLicensesScreen
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
            this.cbIsReleased = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtFilterValue = new Guna.UI2.WinForms.Guna2TextBox();
            this.cbFiltterBy = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnReleaseDetainedLicense = new Guna.UI2.WinForms.Guna2Button();
            this.btnDetainLicense = new Guna.UI2.WinForms.Guna2Button();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.DGVDetainedLicenses = new Guna.UI2.WinForms.Guna2DataGridView();
            this.guna2ContextMenuStrip1 = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
            this.showPersonDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLicenseDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showPersonLicenseHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblNumberOfColumn = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.PanelWindow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVDetainedLicenses)).BeginInit();
            this.guna2ContextMenuStrip1.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelWindow
            // 
            this.PanelWindow.Controls.Add(this.cbIsReleased);
            this.PanelWindow.Controls.Add(this.txtFilterValue);
            this.PanelWindow.Controls.Add(this.cbFiltterBy);
            this.PanelWindow.Controls.Add(this.label3);
            this.PanelWindow.Controls.Add(this.btnReleaseDetainedLicense);
            this.PanelWindow.Controls.Add(this.btnDetainLicense);
            this.PanelWindow.Controls.Add(this.guna2ControlBox1);
            this.PanelWindow.Controls.Add(this.lblTitle);
            this.PanelWindow.Controls.Add(this.DGVDetainedLicenses);
            this.PanelWindow.Controls.Add(this.guna2Panel1);
            this.PanelWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelWindow.Location = new System.Drawing.Point(0, 0);
            this.PanelWindow.Name = "PanelWindow";
            this.PanelWindow.Size = new System.Drawing.Size(963, 450);
            this.PanelWindow.TabIndex = 0;
            this.PanelWindow.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelWindow_Paint);
            // 
            // cbIsReleased
            // 
            this.cbIsReleased.BackColor = System.Drawing.Color.Transparent;
            this.cbIsReleased.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(219)))), ((int)(((byte)(168)))));
            this.cbIsReleased.BorderRadius = 10;
            this.cbIsReleased.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbIsReleased.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIsReleased.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(90)))), ((int)(((byte)(70)))));
            this.cbIsReleased.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbIsReleased.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbIsReleased.Font = new System.Drawing.Font("Century Gothic", 10.2F);
            this.cbIsReleased.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(219)))), ((int)(((byte)(168)))));
            this.cbIsReleased.ItemHeight = 30;
            this.cbIsReleased.Items.AddRange(new object[] {
            "All",
            "Yes",
            "No"});
            this.cbIsReleased.Location = new System.Drawing.Point(403, 151);
            this.cbIsReleased.Name = "cbIsReleased";
            this.cbIsReleased.Size = new System.Drawing.Size(183, 36);
            this.cbIsReleased.StartIndex = 0;
            this.cbIsReleased.TabIndex = 53;
            this.cbIsReleased.Visible = false;
            this.cbIsReleased.SelectedIndexChanged += new System.EventHandler(this.cbIsReleased_SelectedIndexChanged);
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
            this.txtFilterValue.Location = new System.Drawing.Point(403, 151);
            this.txtFilterValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.txtFilterValue.PlaceholderText = "";
            this.txtFilterValue.SelectedText = "";
            this.txtFilterValue.Size = new System.Drawing.Size(236, 36);
            this.txtFilterValue.TabIndex = 52;
            this.txtFilterValue.Visible = false;
            this.txtFilterValue.TextChanged += new System.EventHandler(this.txtFilterValue_TextChanged);
            this.txtFilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterValue_KeyPress);
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
            "Detain ID",
            "Is Released",
            "National No.",
            "Full Name",
            "Release Application ID"});
            this.cbFiltterBy.Location = new System.Drawing.Point(139, 151);
            this.cbFiltterBy.Name = "cbFiltterBy";
            this.cbFiltterBy.Size = new System.Drawing.Size(239, 36);
            this.cbFiltterBy.StartIndex = 0;
            this.cbFiltterBy.TabIndex = 51;
            this.cbFiltterBy.SelectedIndexChanged += new System.EventHandler(this.cbFiltterBy_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(219)))), ((int)(((byte)(168)))));
            this.label3.Location = new System.Drawing.Point(16, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 36);
            this.label3.TabIndex = 50;
            this.label3.Text = "Fillter By : ";
            // 
            // btnReleaseDetainedLicense
            // 
            this.btnReleaseDetainedLicense.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReleaseDetainedLicense.Animated = true;
            this.btnReleaseDetainedLicense.BackColor = System.Drawing.Color.Transparent;
            this.btnReleaseDetainedLicense.BorderRadius = 12;
            this.btnReleaseDetainedLicense.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnReleaseDetainedLicense.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnReleaseDetainedLicense.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnReleaseDetainedLicense.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnReleaseDetainedLicense.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(95)))), ((int)(((byte)(70)))));
            this.btnReleaseDetainedLicense.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnReleaseDetainedLicense.ForeColor = System.Drawing.Color.White;
            this.btnReleaseDetainedLicense.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(120)))), ((int)(((byte)(90)))));
            this.btnReleaseDetainedLicense.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnReleaseDetainedLicense.Image = global::DVLD.Properties.Resources.Release_Detain_License;
            this.btnReleaseDetainedLicense.ImageSize = new System.Drawing.Size(35, 35);
            this.btnReleaseDetainedLicense.Location = new System.Drawing.Point(778, 130);
            this.btnReleaseDetainedLicense.Name = "btnReleaseDetainedLicense";
            this.btnReleaseDetainedLicense.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(55)))), ((int)(((byte)(40)))));
            this.btnReleaseDetainedLicense.Size = new System.Drawing.Size(76, 57);
            this.btnReleaseDetainedLicense.TabIndex = 49;
            this.btnReleaseDetainedLicense.Click += new System.EventHandler(this.btnReleaseDetainedLicense_Click);
            // 
            // btnDetainLicense
            // 
            this.btnDetainLicense.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDetainLicense.Animated = true;
            this.btnDetainLicense.BackColor = System.Drawing.Color.Transparent;
            this.btnDetainLicense.BorderRadius = 12;
            this.btnDetainLicense.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDetainLicense.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDetainLicense.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDetainLicense.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDetainLicense.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(95)))), ((int)(((byte)(70)))));
            this.btnDetainLicense.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnDetainLicense.ForeColor = System.Drawing.Color.White;
            this.btnDetainLicense.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(120)))), ((int)(((byte)(90)))));
            this.btnDetainLicense.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnDetainLicense.Image = global::DVLD.Properties.Resources.Detain_32;
            this.btnDetainLicense.ImageSize = new System.Drawing.Size(35, 35);
            this.btnDetainLicense.Location = new System.Drawing.Point(875, 130);
            this.btnDetainLicense.Name = "btnDetainLicense";
            this.btnDetainLicense.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(55)))), ((int)(((byte)(40)))));
            this.btnDetainLicense.Size = new System.Drawing.Size(76, 57);
            this.btnDetainLicense.TabIndex = 48;
            this.btnDetainLicense.Click += new System.EventHandler(this.btnDetainLicense_Click);
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.BorderRadius = 2;
            this.guna2ControlBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox1.Location = new System.Drawing.Point(916, 15);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(35, 30);
            this.guna2ControlBox1.TabIndex = 47;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(219)))), ((int)(((byte)(168)))));
            this.lblTitle.Location = new System.Drawing.Point(334, 47);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(366, 39);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "List Detained Licenses";
            // 
            // DGVDetainedLicenses
            // 
            this.DGVDetainedLicenses.AllowUserToAddRows = false;
            this.DGVDetainedLicenses.AllowUserToDeleteRows = false;
            this.DGVDetainedLicenses.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.DGVDetainedLicenses.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVDetainedLicenses.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(90)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(90)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 11.2F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(219)))), ((int)(((byte)(168)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(42)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(219)))), ((int)(((byte)(168)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVDetainedLicenses.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGVDetainedLicenses.ColumnHeadersHeight = 42;
            this.DGVDetainedLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.DGVDetainedLicenses.ContextMenuStrip = this.guna2ContextMenuStrip1;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVDetainedLicenses.DefaultCellStyle = dataGridViewCellStyle3;
            this.DGVDetainedLicenses.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DGVDetainedLicenses.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(80)))), ((int)(((byte)(60)))));
            this.DGVDetainedLicenses.Location = new System.Drawing.Point(0, 205);
            this.DGVDetainedLicenses.Name = "DGVDetainedLicenses";
            this.DGVDetainedLicenses.ReadOnly = true;
            this.DGVDetainedLicenses.RowHeadersVisible = false;
            this.DGVDetainedLicenses.RowHeadersWidth = 51;
            this.DGVDetainedLicenses.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(90)))), ((int)(((byte)(70)))));
            this.DGVDetainedLicenses.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.DGVDetainedLicenses.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(219)))), ((int)(((byte)(168)))));
            this.DGVDetainedLicenses.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(42)))), ((int)(((byte)(30)))));
            this.DGVDetainedLicenses.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(219)))), ((int)(((byte)(168)))));
            this.DGVDetainedLicenses.RowTemplate.Height = 36;
            this.DGVDetainedLicenses.Size = new System.Drawing.Size(963, 245);
            this.DGVDetainedLicenses.TabIndex = 46;
            this.DGVDetainedLicenses.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.DGVDetainedLicenses.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(90)))), ((int)(((byte)(70)))));
            this.DGVDetainedLicenses.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(80)))), ((int)(((byte)(60)))));
            this.DGVDetainedLicenses.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(90)))), ((int)(((byte)(70)))));
            this.DGVDetainedLicenses.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Century Gothic", 11.2F);
            this.DGVDetainedLicenses.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(219)))), ((int)(((byte)(168)))));
            this.DGVDetainedLicenses.ThemeStyle.HeaderStyle.Height = 42;
            this.DGVDetainedLicenses.ThemeStyle.ReadOnly = true;
            this.DGVDetainedLicenses.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.DGVDetainedLicenses.ThemeStyle.RowsStyle.Height = 36;
            // 
            // guna2ContextMenuStrip1
            // 
            this.guna2ContextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.guna2ContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showPersonDetailsToolStripMenuItem,
            this.showLicenseDetailsToolStripMenuItem,
            this.showPersonLicenseHistoryToolStripMenuItem});
            this.guna2ContextMenuStrip1.Name = "guna2ContextMenuStrip1";
            this.guna2ContextMenuStrip1.RenderStyle.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.guna2ContextMenuStrip1.RenderStyle.BorderColor = System.Drawing.Color.Gainsboro;
            this.guna2ContextMenuStrip1.RenderStyle.ColorTable = null;
            this.guna2ContextMenuStrip1.RenderStyle.RoundedEdges = true;
            this.guna2ContextMenuStrip1.RenderStyle.SelectionArrowColor = System.Drawing.Color.White;
            this.guna2ContextMenuStrip1.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.guna2ContextMenuStrip1.RenderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.guna2ContextMenuStrip1.RenderStyle.SeparatorColor = System.Drawing.Color.Gainsboro;
            this.guna2ContextMenuStrip1.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.guna2ContextMenuStrip1.Size = new System.Drawing.Size(265, 76);
            // 
            // showPersonDetailsToolStripMenuItem
            // 
            this.showPersonDetailsToolStripMenuItem.Name = "showPersonDetailsToolStripMenuItem";
            this.showPersonDetailsToolStripMenuItem.Size = new System.Drawing.Size(264, 24);
            this.showPersonDetailsToolStripMenuItem.Text = "Show Person Details";
            this.showPersonDetailsToolStripMenuItem.Click += new System.EventHandler(this.showPersonDetailsToolStripMenuItem_Click);
            // 
            // showLicenseDetailsToolStripMenuItem
            // 
            this.showLicenseDetailsToolStripMenuItem.Name = "showLicenseDetailsToolStripMenuItem";
            this.showLicenseDetailsToolStripMenuItem.Size = new System.Drawing.Size(264, 24);
            this.showLicenseDetailsToolStripMenuItem.Text = "Show License Details";
            this.showLicenseDetailsToolStripMenuItem.Click += new System.EventHandler(this.showLicenseDetailsToolStripMenuItem_Click);
            // 
            // showPersonLicenseHistoryToolStripMenuItem
            // 
            this.showPersonLicenseHistoryToolStripMenuItem.Name = "showPersonLicenseHistoryToolStripMenuItem";
            this.showPersonLicenseHistoryToolStripMenuItem.Size = new System.Drawing.Size(264, 24);
            this.showPersonLicenseHistoryToolStripMenuItem.Text = "Show Person License History";
            this.showPersonLicenseHistoryToolStripMenuItem.Click += new System.EventHandler(this.showPersonLicenseHistoryToolStripMenuItem_Click);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.BorderRadius = 10;
            this.guna2Panel1.Controls.Add(this.lblNumberOfColumn);
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(95)))), ((int)(((byte)(70)))));
            this.guna2Panel1.Location = new System.Drawing.Point(12, 12);
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
            // ListDetainedLicensesScreen
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(963, 450);
            this.Controls.Add(this.PanelWindow);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ListDetainedLicensesScreen";
            this.Text = "ListDetainedLicensesScreen";
            this.Load += new System.EventHandler(this.ListDetainedLicensesScreen_Load);
            this.PanelWindow.ResumeLayout(false);
            this.PanelWindow.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVDetainedLicenses)).EndInit();
            this.guna2ContextMenuStrip1.ResumeLayout(false);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientPanel PanelWindow;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label lblNumberOfColumn;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2DataGridView DGVDetainedLicenses;
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2Button btnReleaseDetainedLicense;
        private Guna.UI2.WinForms.Guna2Button btnDetainLicense;
        private Guna.UI2.WinForms.Guna2ComboBox cbIsReleased;
        private Guna.UI2.WinForms.Guna2TextBox txtFilterValue;
        private Guna.UI2.WinForms.Guna2ComboBox cbFiltterBy;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2ContextMenuStrip guna2ContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showPersonDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLicenseDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showPersonLicenseHistoryToolStripMenuItem;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
    }
}