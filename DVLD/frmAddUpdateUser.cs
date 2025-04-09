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
    public partial class frmAddUpdateUser : Form
    {
        public frmAddUpdateUser()
        {
            InitializeComponent();
            Mode =enMode.Add;
        }

        public frmAddUpdateUser(int UserID)
        {
            InitializeComponent();
            Mode =enMode.Uppdet;
            _UserID = UserID;
        }

        enum enMode { Add =0,Uppdet =1};
        enMode Mode = enMode.Add;
        int _UserID = -1;
        private void tpLoginInfo_Click(object sender, EventArgs e)
        {

        }
    }
}
