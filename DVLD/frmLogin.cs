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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        clsUsers2 _User;

        private void frmLogin_Load(object sender, EventArgs e)
        {
            string Username = "", Passowrd = "";
            if(clsGlobal.GetStoredCredentil(ref Username, ref Passowrd))
            {
                txtPassword.Text = Passowrd;
                txtUsername.Text = Username;
                cbRememberMe.Checked = true;
                clsGlobal.CurrentUser = clsUsers2.FindByUsernameAndPassword(Username, Passowrd);
            }
            else
                cbRememberMe.Checked = false;
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
           
              _User = clsUsers2.FindByUsernameAndPassword(txtUsername.Text, txtPassword.Text);

                if(_User != null)
                {
                if (cbRememberMe.Checked)
                {
                    clsGlobal.RememberUsernameAndPassword(txtUsername.Text, txtPassword.Text);
                
                }
                else
                {
                    clsGlobal.RememberUsernameAndPassword("", "");
                }


                if (!_User.IsActive)
                {
                    txtUsername.Focus();
                    MessageBox.Show("your acounted is not Actve,Contact Adamin", "In Active", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                clsGlobal.CurrentUser = _User;
                frmMain frm = new frmMain(this);
                this.Hide();
                frm.ShowDialog();
               }
                else
                {
                txtUsername.Focus();
                MessageBox.Show("Invalid Username/Passsword.","Wrong", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                  }
       


        }

        private void buClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
