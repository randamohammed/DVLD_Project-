using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDSluotion.Licenses.International_License
{
    public partial class frmShowInternationalLicenseInfo : Form
    {
        public frmShowInternationalLicenseInfo(int InternationalLicenseID)
        {
            InitializeComponent();
            _InternationalLicenseID = InternationalLicenseID;
        }
        int _InternationalLicenseID = 0;
        private void frmShowInternationalLicenseInfo_Load(object sender, EventArgs e)
        {
            ctrlDriverInternationalLicenseInfo1.LoadInfo(_InternationalLicenseID);
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
