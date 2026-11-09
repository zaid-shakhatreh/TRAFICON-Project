using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class ctrlClockAndDate : UserControl
    {
        public ctrlClockAndDate()
        {
            InitializeComponent();

            // تفعيل خصائص منع الوميض ودعم الشفافية
            this.SetStyle(ControlStyles.UserPaint |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.SupportsTransparentBackColor, true);

            this.BackColor = Color.Transparent;
        }


        private Timer clockTimer;

        private void LoadDateAndClockInPage(object sender, EventArgs e)
        {
            lblClock.Text = DateTime.Now.ToString("yyyy-MM-dd | hh:mm:ss tt");
            lblClock.ForeColor = Color.FromArgb(227, 219, 168);
            lblClock.BackColor = Color.Transparent;
            lblClock.BringToFront();
           
            clockTimer = new Timer();
            clockTimer.Interval = 1000;
            clockTimer.Tick += (s, ev) =>
            {
                lblClock.Text = DateTime.Now.ToString("yyyy-MM-dd | hh:mm:ss tt");
            };
            clockTimer.Start();
        }
        private void ctrlClockAndDate_Load(object sender, EventArgs e)
        {
           
            LoadDateAndClockInPage(sender, e);
        }

        public int BorderRadius { get; set; } = 25;

  
        private GraphicsPath GetRoundedRectangle(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float d = radius * 2F;

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();

            return path;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // تفعيل تنعيم الحواف لمنع التعرجات
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);

            using (GraphicsPath path = GetRoundedRectangle(rect, BorderRadius))
            {
                // حدد درجات ألوان التدرج المنسجمة مع الخلفية
                Color colorStart = Color.FromArgb(50, 75, 52); // أخضر أفتح قليلاً
                Color colorEnd = Color.FromArgb(35, 50, 37);   // أخضر داكن مندمج مع الحواف

                using (LinearGradientBrush brush = new LinearGradientBrush(
                    rect,
                    colorStart,
                    colorEnd,
                    LinearGradientMode.Vertical)) // يمكنك جعله Horizontal حسب رغبتك
                {
                    e.Graphics.FillPath(brush, path);
                }

                // لقص الحواف الخارجية لضمان عدم ظهور أي زوايا مربعة حادة
                this.Region = new Region(path);
            }
        }
    }
}
