using SLDVLD_Buisness;
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
    public partial class frmShowLicenseInfo : Form
    {
        public frmShowLicenseInfo(int LicenesID )
        {
            InitializeComponent();
            this.LicenesID = LicenesID;
        }

        int LicenesID = 0;
        private void frmShowLicenseInfo_Load(object sender, EventArgs e)
        {
            ctrlDriverLicenseInfo1.LoadData(LicenesID);
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
