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
using System.Xml.Linq;

namespace DVLDSluotion
{
    public partial class frmLastUser : Form
    {
        public frmLastUser()
        {
            InitializeComponent();
        }
        DataTable dtAllUser;
        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        void _RefrshDefluteValuse()
        {
            cmFilter.SelectedIndex = 0;
            dtAllUser = clsUsers2.GetAllUsers();
          
            cmISActive.Visible =false;
            txtFilterVaaluse.Visible =false; 
            lbRecorde.Text = dvUsers.RowCount.ToString();
        }
        private void frmLastUser_Load(object sender, EventArgs e)
        {
             dtAllUser = clsUsers2.GetAllUsers();
            cmFilter.SelectedIndex = 0;
            dvUsers.DataSource = dtAllUser;
            lbRecorde.Text = dvUsers.RowCount.ToString();

            if(dvUsers.Rows.Count > 0 )
            {
                dvUsers.Columns[0].HeaderText = "User ID";
                dvUsers.Columns[0].Width = 110;

                dvUsers.Columns[1].HeaderText = "Person ID";
                dvUsers.Columns[1].Width = 110;

                dvUsers.Columns[2].HeaderText = "Full Name";
                dvUsers.Columns[2].Width = 310;

                dvUsers.Columns[3].HeaderText = "User Name";
                dvUsers.Columns[3].Width = 150;

                dvUsers.Columns[4].HeaderText = "IS Active";
                dvUsers.Columns[4].Width = 120;
               
            }
        }

        private void cmFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
           
          if(cmFilter.Text == "IS Active")
            {
                txtFilterVaaluse.Visible =false;
                cmFilter.Visible = true;
                cmISActive.SelectedIndex = 0;
                cmISActive.Focus(); 
            }
          else
            {
                txtFilterVaaluse.Visible = (cmFilter.Text != "None");
                cmISActive.Visible =false;

                if (cmFilter.Text != "None")
                {
                    
                    txtFilterVaaluse.Visible = true;
                    txtFilterVaaluse.Focus();
                    txtFilterVaaluse.Text = "";
                }
               
            }
           
        }

        private void txtFilterVaaluse_TextChanged(object sender, EventArgs e)
        {

            string CoulmnsFilter = ""; 
            switch(cmFilter.Text)
            {
                case "User ID":
                    CoulmnsFilter = "UserID";
                    break;
                case "Person ID":
                    CoulmnsFilter = "PersonID";
                    break ;
                case "User Name":
                    CoulmnsFilter = "UserName";
                    break ;
                case "Full Name":
                    CoulmnsFilter = "FullName";
                    break ;
                default:
                    CoulmnsFilter = "None";
                    break;
            }

            if(CoulmnsFilter == "None"|| txtFilterVaaluse.Text =="")
            {
                dtAllUser.DefaultView.RowFilter = "";
                _RefrshDefluteValuse();
                return;
            }

             if(CoulmnsFilter == "UserID" || CoulmnsFilter == "PersonID")
             {
                dtAllUser.DefaultView.RowFilter = string.Format("[{0}] ={1}",CoulmnsFilter,txtFilterVaaluse.Text);
             }
             else
                dtAllUser.DefaultView.RowFilter = string.Format("[{0}] Like '{1}%'", CoulmnsFilter, txtFilterVaaluse.Text);
            lbRecorde.Text = dvUsers.RowCount.ToString();
        }

        private void cmISActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = cmISActive.Text;
            switch (FilterColumn)
            {
                case "All":
                    {
                        _RefrshDefluteValuse();
                        break;
                    }
                case "Yes":
                    {
                        FilterColumn = "1";
                        break;
                    }
                default:
                    FilterColumn = "0";
                    break;
            }
                    dtAllUser.DefaultView.RowFilter = string.Format("[{0}] = {1}", "IsActive", FilterColumn);

        }

        private void addNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson();
            frm.ShowDialog();
            frmLastUser_Load(null, null);
        }

        private void editUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID =(int) dvUsers.CurrentRow.Cells[0].Value; 
            fromAddUpdateUser frm = new fromAddUpdateUser(UserID);
            frm.ShowDialog();
            frmLastUser_Load(null,null);
        }

        private void showDetilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = (int)dvUsers.CurrentRow.Cells[0].Value;
            frmUserInfo frm = new frmUserInfo(UserID);
            frm.ShowDialog();

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = (int)dvUsers.CurrentRow.Cells[0].Value;
            if (MessageBox.Show("Are you you srue you wante to delete this User","Confrim Delete",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                if(clsUsers2.DeleteUser(UserID))
                {
                    MessageBox.Show("User delete  successfully","Delet",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
            frmLastUser_Load(null,null );
        }

        private void chanagPasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = (int)dvUsers.CurrentRow.Cells[0].Value;
            frmChangePassword frm = new frmChangePassword(UserID);
            frm.ShowDialog();
        }

        private void txtFilterVaaluse_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(cmFilter.Text == "User   Name" || cmFilter.Text == "Full Name")
              e.Handled = char.IsDigit(e.KeyChar) && e.KeyChar !=  (char)Keys.Back;
        }

        private void btAddNewUsers_Click(object sender, EventArgs e)
        {


            frmAddUpdatePerson frm = new frmAddUpdatePerson();
            frm.ShowDialog();
            frmLastUser_Load(null, null);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
