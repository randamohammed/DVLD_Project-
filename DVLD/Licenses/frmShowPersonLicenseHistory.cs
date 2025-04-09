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
    public partial class frmShowPersonLicenseHistory : Form
    {
        public frmShowPersonLicenseHistory(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
        }
        public frmShowPersonLicenseHistory()
        {
            InitializeComponent();
        }
        int _PersonID = -1;

        private void frmShowPersonLicenseHistory_Load(object sender, EventArgs e)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShowPersonLicenseHistory_Load_1(object sender, EventArgs e)
        {
            if (_PersonID != -1)
            {
                ctrlPersonCardWithFiltere1.LoadPersonnfo(_PersonID);
                ctrlDriverLicenses1.LoadInfoByPersonID(_PersonID);
                ctrlPersonCardWithFiltere1.FilterEnable = false;

            }
            else
            {
                ctrlPersonCardWithFiltere1.FilterEnable = true;
                ctrlPersonCardWithFiltere1.TexFouce();
            }
        }

        private void ctrlPersonCardWithFiltere1_OnPersonSelect(int obj)
        {
            int PersonID = obj;

            if(PersonID == -1)
            {
                ctrlDriverLicenses1.Clear();
            }
            ctrlDriverLicenses1.LoadInfoByPersonID(PersonID);
        }
    }
}
