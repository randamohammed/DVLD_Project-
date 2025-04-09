using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDSluotion
{
    public partial class frmShowPerson : Form
    {
        public frmShowPerson(int PersonID)
        {
            InitializeComponent();
            ctrlPersonCardcs1.LoadPersonInfo(PersonID);
        }

        public frmShowPerson(string NationalNo)
        {
            InitializeComponent();
            ctrlPersonCardcs1.LoadPersonInfo(NationalNo);
        }


        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
