using DVLD_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Windows.Forms;
//System.Windows.Forms.Button;



namespace DVLD.People.Control_For_People
{
    public partial class ctrlPersonalCardWithFiltter : UserControl
    {

        public event Action<int> OnPersonSelected;

        protected virtual void PersonSelected(int PersonID)
        {
            Action<int> Handler = OnPersonSelected;
            
            if(Handler != null)
            
            {
                Handler(PersonID);
            }
        
        }

        private bool _AddShowEnabeld=true;
        public bool AddShowEnabeld 
        {
            get 
            {
            return _AddShowEnabeld;
            }
            set 
            {
            _AddShowEnabeld = value;
                btnAddNewPerson.Visible = _AddShowEnabeld;
            
            } }

        private bool _FiltterEnabeld = true;
        public bool FiltterEnabeld
        {
            get
            {
                return _FiltterEnabeld;
            }
            set
            {
                _FiltterEnabeld = value;
                btnAddNewPerson.Enabled= _FiltterEnabeld;
                btnFind.Enabled = _FiltterEnabeld;
                txtFilterValue.Enabled = _FiltterEnabeld;
                cbFilterBy.Enabled = _FiltterEnabeld;


            }
        }


        public ctrlPersonalCardWithFiltter()
        {
            InitializeComponent();
            //cbFilterBy.SelectedIndex = 1;
        }


        int _PersonID = -1;
        public int PersonID
        {
            get { return _PersonID; }
        }

        public clsPerson PersonInfo
        {
            get { return ctrlPersonalCard1.Person; }

        }


        public void LoadDataInfo (int PersonID)
        {
            cbFilterBy.SelectedIndex = 1;
            txtFilterValue.Text=PersonID.ToString();

            FindNow();
        }

        private void FindNow()
        {

            switch (cbFilterBy.Text)
            {
                case "Person ID":
                    {
                        ctrlPersonalCard1.LoadPersonData(int.Parse(txtFilterValue.Text));
                        break;
                    }
                case "National No":
                    {
                        ctrlPersonalCard1.LoadPersonData(txtFilterValue.Text);
                        break;
                    }
                default:
                    break;

            }

            if(OnPersonSelected !=null && _FiltterEnabeld)
            {
                OnPersonSelected(ctrlPersonalCard1.PersonID);
            }
           



        }




                private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {


            // To add colors to the background(light, medium, and dark oil)
            using (System.Drawing.Drawing2D.LinearGradientBrush brush =
                   new System.Drawing.Drawing2D.LinearGradientBrush(
                       pan.ClientRectangle,
                       Color.Black, Color.White, 0f))
            {
                System.Drawing.Drawing2D.ColorBlend cb = new System.Drawing.Drawing2D.ColorBlend();
                cb.Colors = new Color[] {
                 Color.FromArgb(107, 142, 107),
                Color.FromArgb(70, 95, 70),
                Color.FromArgb(35, 50, 35)
};
                cb.Positions = new float[] { 0.0f, 0.5f, 1.0f };

                brush.InterpolationColors = cb;
                e.Graphics.FillRectangle(brush, pan.ClientRectangle);

            }
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Text = "";
            txtFilterValue.Focus();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return; 
            }

            FindNow();
        }

        private void ctrlPersonalCardWithFiltter_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 1;
            txtFilterValue.Focus();
        }

        private void txtFilterValue_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilterValue.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFilterValue, "This field is required!");
            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(txtFilterValue, null);
            }
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            AddEditPersonInfo frm = new AddEditPersonInfo();

            frm.DataBack += Frm_EventDataBack;
            frm.ShowDialog();
        }

        private void Frm_EventDataBack(object sender, int PersonID)
        {
            cbFilterBy.SelectedIndex = 1;
            txtFilterValue.Text = PersonID.ToString();
            ctrlPersonalCard1.LoadPersonData(PersonID);
        
        }

        public void FilterFocus()
        {
            txtFilterValue.Focus();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnFind.PerformClick();
            }

            //this will allow only digits if person id is selected
            if (cbFilterBy.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void ctrlPersonalCard1_Load(object sender, EventArgs e)
        {

        }
    }
}
