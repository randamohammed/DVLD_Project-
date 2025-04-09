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
    public partial class frmLocalDriverLicenesApplicationInfo : Form
    {
        public frmLocalDriverLicenesApplicationInfo(int ApplicationID)
        {
            InitializeComponent();
            this.ApplicationID = ApplicationID;
        }
        int ApplicationID = -1;
        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLocalDriverLicenesApplicationInfo_Load(object sender, EventArgs e)
        {
            ctrlDrivingLicenseApplicationInfo1.LoadApplicationInfoByLocalDrivingAppID(ApplicationID);

        }
    }
}
