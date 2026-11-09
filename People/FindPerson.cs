using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.People
{
    public partial class FindPerson : Form
    {
        public FindPerson()
        {
            InitializeComponent();
        }
        // Declare a delegate
        public delegate void DataBackEventHandler(object sender, int PersonID);

        // Declare an event using the delegate
        public event DataBackEventHandler DataBack;

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            DataBack?.Invoke(this, ctrlPersonalCardWithFiltter1.PersonID);

        }

        private void ctrlPersonalCardWithFiltter2_Load(object sender, EventArgs e)
        {

        }
    }
}
