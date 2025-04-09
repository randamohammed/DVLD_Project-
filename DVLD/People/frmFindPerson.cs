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
    public partial class frmFindPerson : Form
    {
        public frmFindPerson()
        {
            InitializeComponent();
        }

        public delegate void DateBackEventHandler(object Sender, int PersonID);
        public virtual event DateBackEventHandler DateBack;


        private void butClose_Click(object sender, EventArgs e)
        {
            this.Close();
           DateBack?.Invoke(this,ctrlPersonCardWithFiltere1.PersonID);
        }
    }
}
