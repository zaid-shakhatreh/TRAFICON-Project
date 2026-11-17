using DVLD.Applications.Application_Type;
using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Applications.Application_Typ
{
    public partial class ListApplicationTypeScreen : Form
    {
        public ListApplicationTypeScreen()
        {
            InitializeComponent();
        }
        
            private void ApplyOliveDarkTheme(DataGridView dgv)
        {
            dgv.BackgroundColor = Color.FromArgb(45, 60, 45); 
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = Color.FromArgb(60, 80, 60); // فواصل زيتية خافتة
            dgv.EnableHeadersVisualStyles = false;

            // رأس الأعمدة (Header)
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersHeight = 42;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 42, 30); // أغمق درجات الزيتي
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(235, 240, 230); // عاجي ناصع
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10.5f, FontStyle.Bold);

            // صفوف البيانات
            dgv.RowTemplate.Height = 36;
            dgv.DefaultCellStyle.BackColor = Color.FromArgb(45, 60, 45);
            dgv.DefaultCellStyle.ForeColor = Color.FromArgb(245, 245, 240);
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9.5f, FontStyle.Regular);

            // تبادل الألوان (Zebra Striping)
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(52, 70, 52); // درجة تباين ناعمة
            dgv.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(245, 245, 240);

            // حالة التحديد (Selection)
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(107, 142, 107); // نفس لون بداية التدرج الفاتح
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(107, 142, 107);
            dgv.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.White;

            dgv.RowHeadersVisible = false;
        }
        


        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {
            using (System.Drawing.Drawing2D.LinearGradientBrush brush =
                new System.Drawing.Drawing2D.LinearGradientBrush(
                    PanelWindow.ClientRectangle,
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
                e.Graphics.FillRectangle(brush, PanelWindow.ClientRectangle);
            }
        }

        DataTable Table;

        private void _loadData()
        {
            this.CancelButton = btnClose;
            ApplyOliveDarkTheme(DGVListApplicationType);
            Table = clsManageApplicationType.GetAllApplicationType();
            DGVListApplicationType.DataSource = Table;
            lblNumberOfColumn.Text=DGVListApplicationType.Rows.Count.ToString();
        }


        private void ListApplicationTypeScreen_Load(object sender, EventArgs e)
        {
            _loadData();

            if (Table.Rows.Count > 0) 
            {
                DGVListApplicationType.Columns[0].HeaderText = "ID";
                DGVListApplicationType.Columns[0].Width = 85;

                DGVListApplicationType.Columns[1].HeaderText = "Application Type";
                DGVListApplicationType.Columns[1].Width = 180;

                DGVListApplicationType.Columns[2].HeaderText = "Fees";
                DGVListApplicationType.Columns[2].Width = 100;

            }
            lblNumberOfColumn.Text = DGVListApplicationType.Rows.Count.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      //  private void editApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
      //  {
      //      EditApplicationTypeScreen Edit = new EditApplicationTypeScreen((int)DGVListApplicationType.CurrentRow.Cells[0].Value);
      //     // this.Hide();
      //      Edit.ShowDialog();
      //
      //      _loadData();
      //  }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditApplicationTypeScreen Edit = new EditApplicationTypeScreen((int)DGVListApplicationType.CurrentRow.Cells[0].Value);
            // this.Hide();
            Edit.ShowDialog();

            _loadData();
        }
    }
}
