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
    public partial class ShowPersonInfo : Form
    {

        private int PersonId = -1;

        public ShowPersonInfo(int PersonID)
        {
            InitializeComponent();
            PersonId = PersonID;
        }

        

        

        private void ctrlPersonalCard1_Load(object sender, EventArgs e)
        {
            ctrlPersonalCard1.LoadPersonData(PersonId);

        }
    }
}
