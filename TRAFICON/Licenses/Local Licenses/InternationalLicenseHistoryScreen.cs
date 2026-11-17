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

namespace DVLD.Licenses.Local_Licenses
{
    public partial class InternationalLicenseHistoryScreen : Form
    {
        int PersonID;

        public InternationalLicenseHistoryScreen(int PersonID)
        {
            InitializeComponent();
            this.PersonID = PersonID;
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
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(227, 219, 168); // عاجي ناصع
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10.5f, FontStyle.Bold);

            // صفوف البيانات
            dgv.RowTemplate.Height = 36;
            dgv.DefaultCellStyle.BackColor = Color.FromArgb(45, 60, 45);
            dgv.DefaultCellStyle.ForeColor = Color.FromArgb(227, 219, 168);
            dgv.DefaultCellStyle.Font = new Font("Century Gothic", 9.5f, FontStyle.Regular);

            // تبادل الألوان (Zebra Striping)
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(52, 70, 52); // درجة تباين ناعمة
            dgv.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(227, 219, 168);

            // حالة التحديد (Selection)
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(107, 142, 107); // نفس لون بداية التدرج الفاتح
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(107, 142, 107);
            dgv.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.White;

            dgv.RowHeadersVisible = false;
        }
        private void _FillTable()
        {
            DGVShowLocalHistory.DataSource = clsDriver.GetInternationalLicenses(PersonID);
            ApplyOliveDarkTheme(DGVShowLocalHistory);
        }

        private void InternationalLicenseHistoryScreen_Load(object sender, EventArgs e)
        {
            _FillTable();

            if (DGVShowLocalHistory.Rows.Count > 0)
            {

                DGVShowLocalHistory.Columns[0].HeaderText = "Int.License ID";
                DGVShowLocalHistory.Columns[0].Width = 120;


                DGVShowLocalHistory.Columns[1].HeaderText = "Application.ID";
                DGVShowLocalHistory.Columns[1].Width = 120;



                DGVShowLocalHistory.Columns[2].HeaderText = "L.License ID";
                DGVShowLocalHistory.Columns[2].Width = 120;


                DGVShowLocalHistory.Columns[3].HeaderText = "Issue Date";
                DGVShowLocalHistory.Columns[3].Width = 150;


                DGVShowLocalHistory.Columns[4].HeaderText = "Expiration Date";
                DGVShowLocalHistory.Columns[4].Width = 150;


                DGVShowLocalHistory.Columns[5].HeaderText = "Activation";
                DGVShowLocalHistory.Columns[5].Width = 120;

            }

            lblNumberOfColumn.Text = DGVShowLocalHistory.Rows.Count.ToString();

        }

        private void PanelWindow_Paint(object sender, PaintEventArgs e)
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
    }
}
