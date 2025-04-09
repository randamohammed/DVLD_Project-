using SLDVLD_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SLDVLD_Buisness.clsPerson;

namespace DVLDSluotion
{
    public partial class fromAddUpdateUser : Form
    {
        public fromAddUpdateUser()
        {
            InitializeComponent();
            Mode = enMode.Add;
        }

        public fromAddUpdateUser(int UserID)
        {
            InitializeComponent();
            Mode = enMode.Uppdet;
            _UserID = UserID;
        }

        enum enMode { Add = 0, Uppdet = 1 };
        enMode Mode = enMode.Add;
        int _UserID = -1;
        clsUsers2 _User;

        void _RefrshDefluteValeus()
        {
            if (Mode == enMode.Add)
            {
                lbTitel.Text = "Add New User";
                this.Text = "Add New User";
                _User = new clsUsers2();

                tpLoginInfo.Enabled = false;

                ctrlPersonCardWithFiltere1.TexFouce();
            }
            else
            {
                lbTitel.Text = "Update User";
                this.Text = "Update User";

                btSave.Enabled = true;


            }


            txtConfirmPassword.Text = "";
            lbTitel.Text = "Add New User";
            this.Text = lbTitel.Text;
            txtPassword.Text = "";
            txtUserName.Text = "";
            lblUserID.Text = "A/N";
        }


        void _LoadData()
        {
            ctrlPersonCardWithFiltere1.FilterEnable = false;
            _User = clsUsers2.FindByUserID(_UserID);
            if(_User == null)
            {
                MessageBox.Show("No User with ID = " + _UserID, "User Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }

            lbTitel.Text = "Update User";
            this.Text = lbTitel.Text;
            txtPassword.Text = _User.Password;
            txtUserName.Text = _User.UserName;
            txtConfirmPassword.Text = txtPassword.Text;
            lblUserID.Text = _User.UserID.ToString();
            ctrlPersonCardWithFiltere1.LoadPersonnfo(_User.PersonID);
           
           
        }
        private void fromAddUpdateUser_Load(object sender, EventArgs e)
        {
            _RefrshDefluteValeus();
            if(Mode == enMode.Uppdet)
            _LoadData();
        }
        private void ValidaingAllText(object sender, CancelEventArgs e)
        {
            TextBox temp = (TextBox)sender;

           if(string.IsNullOrEmpty(temp.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(temp, "This is failed");
            }
           else
            {
                errorProvider1.SetError(temp, null);
            }
        }


        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
           if(string.IsNullOrEmpty(txtConfirmPassword.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "This is failed");
            }
           else
            {
                errorProvider1.SetError(txtConfirmPassword, null);
            }

           if(txtConfirmPassword.Text != txtPassword.Text)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "Cofirm Password must be same");
            }
           else
            {
                errorProvider1.SetError(txtConfirmPassword, null);
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                   "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _User.UserID = _UserID;
            _User.UserName =  txtUserName.Text.Trim();
            _User.PersonID = ctrlPersonCardWithFiltere1.PersonID;
            _User.Password = txtPassword.Text.Trim();
            _User.IsActive = chkIsActive.Checked;

            if(_User.Save())
            {
                MessageBox.Show("Data Save Successfully","Save Data",MessageBoxButtons.OK, MessageBoxIcon.Information);
                lbTitel.Text = "Update User";
                this.Text =lbTitel.Text;
                Mode = enMode.Uppdet;
                lblUserID.Text = _User.UserID.ToString();
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void btnPersonInfoNext_Click(object sender, EventArgs e)
        {
            if(Mode == enMode.Uppdet)
            {
                btSave.Visible = true;
                tpLoginInfo.Enabled = true;
                tbUsrInfo.SelectedTab = tbUsrInfo.TabPages["tpLoginInfo"];
            }
            else
            {
                if(ctrlPersonCardWithFiltere1.PersonID  !=-1)
                {
                    if(!clsUsers2.IsUserExistForPersonID(ctrlPersonCardWithFiltere1.PersonID))
                    {
                        btSave.Visible = true;
                        tpLoginInfo.Enabled = true;
                        tbUsrInfo.SelectedTab = tbUsrInfo.TabPages["tpLoginInfo"];
                    }
                    else
                    {
                        MessageBox.Show("Selected Person already has a user, choose another one.", "Select another Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ctrlPersonCardWithFiltere1.TexFouce();
                    }
                }
                else
                {

                    MessageBox.Show("Please Select a Person", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ctrlPersonCardWithFiltere1.TexFouce();
                }
            }
        }

        private void fromAddUpdateUser_Activated(object sender, EventArgs e)
        {
            ctrlPersonCardWithFiltere1.TexFouce();
        }
    }
}
