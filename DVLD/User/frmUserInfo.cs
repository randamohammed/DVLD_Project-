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
    public partial class frmUserInfo : Form
    {
        public frmUserInfo(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
        }

        private int _UserID =-1;
        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmUserInfo_Load(object sender, EventArgs e)
        {
            ctrUserCard1.LoadUserInfo(_UserID);
        }
    }
}
