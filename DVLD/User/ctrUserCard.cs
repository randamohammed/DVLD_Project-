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
    public partial class ctrUserCard : UserControl
    {
        public ctrUserCard()
        {
            InitializeComponent();
        }

        clsUsers2 _User;
        int _UserID =0;
        public int UserID { get { return _UserID;} }
        private void _FillUserInfo()
        {
            ctrlPersonCardcs1.LoadPersonInfo(_User.PersonID);
            lbUserID.Text = _User.UserID.ToString();
            lbUserName.Text = _User.UserName;
            lbISActive.Text = (_User.IsActive) ? "Yes" : "No";
        }
       private void _RefresDeflutValuse()
        {

            ctrlPersonCardcs1.RestortDate();
            lbUserName.Text = "???";
            lbUserID.Text = "???";
            lbISActive.Text = "???";
        }
        public void LoadUserInfo(int UserID)
        {
            _UserID = UserID;
            _User = clsUsers2.FindByUserID(UserID);

            if(_User == null )
            {
                MessageBox.Show(" No User with ID = "+ UserID ,"UError", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _RefresDeflutValuse();
               
            }
            else
            {
                _FillUserInfo();
            }
        }

        private void ctrUserCard_Load(object sender, EventArgs e)
        {

        }
    }
}
