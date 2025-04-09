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
    public partial class frmChangePassword : Form
    {
        public frmChangePassword(int UserID)
        {
            InitializeComponent();
            _userID = UserID;
        }

        private int _userID = -1;
        clsUsers2 _User;
        private void _RefrshDefluteValuse()
        {
            txtCurrentPassword.Focus();
            txtNowPassword.Text = "";
            txtConfirmPassword.Text = "";
            txtCurrentPassword.Text = "";
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if(txtConfirmPassword.Text != txtNowPassword.Text)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "Password Confrimation dose not New Password!");
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, null);

            }
        }

        private void txtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCurrentPassword.Text) )
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCurrentPassword, "Current Password is wrong");
            }
            else
            {
                errorProvider1.SetError(txtCurrentPassword, null);
            }


            if (_User.Password != txtCurrentPassword.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCurrentPassword, "Current Password is wrong");
            }
            else
            {
                errorProvider1.SetError(txtCurrentPassword, null);
            }
        }

        private void txtNowPassword_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(txtNowPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNowPassword, "this is faled");
            }
            else
            {
                errorProvider1.SetError(txtNowPassword, null);
            }
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            _User = clsUsers2.FindByUserID(_userID);

            if( _User == null )
            {
                MessageBox.Show("Cloud not found User with Id = " + _userID, "Not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            ctrUserCard1.LoadUserInfo(_userID);
            _RefrshDefluteValuse();
        }

        private void buClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                                 "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _User.Password   = txtNowPassword.Text.Trim();
            if(MessageBox.Show("Are you sure you want to chanage password?","Confrim Change Password",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if(_User.Save())
                {
                    MessageBox.Show("Password chanage successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("An Erro Occured, Password did not change.",
                   "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
