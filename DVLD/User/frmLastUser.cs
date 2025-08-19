using SLDVLD_Buisness;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
     
        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        List<UserViewModel> FilterDate;
        List<UserViewModel> listuser = new List<UserViewModel>();
        ObservableCollection<UserViewModel> ObservableCollectionusr  ;
      
        private    async void frmLastUser_Load(object sender, EventArgs e)
        {

            listuser =await UserViewModel.GetAllDataUserLst();
            ObservableCollectionusr = new ObservableCollection<UserViewModel>(listuser);
            
            cmFilter.SelectedIndex = 0;

            _RefreashData();
        }
        void _RefreashData()
        {
            dvUsers.DataSource = null;
            dvUsers.DataSource = ObservableCollectionusr;
            lbRecorde.Text = dvUsers.RowCount.ToString();

            if (dvUsers.Rows.Count > 0)
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
           
          if(cmFilter.Text == "Is Active")
            {
                txtFilterVaaluse.Visible =false;
                cmISActive.Visible = true;
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
            List<UserViewModel> FilterDate;

            if (txtFilterVaaluse.Text == "")
            {

                _RefreashData();
                lbRecorde.Text = dvUsers.RowCount.ToString();
                return;
            }

            switch (cmFilter.Text)
            {
                case "User ID":
                    {
                        FilterDate = ObservableCollectionusr.Where(n => n.UserID == int.Parse(txtFilterVaaluse.Text)).ToList();
                        dvUsers.DataSource = FilterDate;
                        break;
                    }
                case "Person ID":
                    {
                        FilterDate = ObservableCollectionusr.Where(n => n.PersonID == int.Parse(txtFilterVaaluse.Text)).ToList();
                        dvUsers.DataSource = FilterDate;
                        break;
                    }
                   
                case "User Name":
                    {
                        FilterDate = ObservableCollectionusr.Where(n => n.UserName == txtFilterVaaluse.Text).ToList();
                        dvUsers.DataSource = FilterDate;
                        break;
                    }
                case "Full Name":
                    {

                        FilterDate = ObservableCollectionusr.Where(n => n.UserName == txtFilterVaaluse.Text).ToList();
                        dvUsers.DataSource = FilterDate;
                        break;
                    }
            }

            lbRecorde.Text = dvUsers.RowCount.ToString();

        }
       
        private void cmISActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = cmISActive.Text;
            switch (FilterColumn)
            {
                case "All":
                    {
                        _RefreashData();
                        break;
                    }
                case "Yes":
                    {
                        FilterDate = ObservableCollectionusr.Where(n => n.IsActive == true).ToList();
                        dvUsers.DataSource = FilterDate;
                        break;
                    }
                default:
                    FilterDate = ObservableCollectionusr.Where(n => n.IsActive == false).ToList();
                    dvUsers.DataSource = FilterDate;
                    break;
            }
            lbRecorde.Text = dvUsers.RowCount.ToString();
        }

        private void addNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fromAddUpdateUser frm = new fromAddUpdateUser();

            frm.onUserAdded += handonuserAdded;
            frm.ShowDialog();
            
        }

        private void handonuserAdded(UserViewModel _user)
        {

           ObservableCollectionusr.Add(_user);
            _RefreashData();
        }

        private void editUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dvUsers.CurrentCell != null)
            {
                int UserID = (int)dvUsers.CurrentRow.Cells[0].Value;
                fromAddUpdateUser frm = new fromAddUpdateUser(UserID);
                frm.onUserUpdated += handonuserupdeter; 
                frm.ShowDialog();
            
            }
        }

        private void handonuserupdeter(UserViewModel _user)
        {
            for (int i = 0; i <= ObservableCollectionusr.Count - 1; i++)
            {
                if (ObservableCollectionusr[i].UserID == _user.UserID)
                {
                    ObservableCollectionusr[i].UserName = _user.UserName;
                    ObservableCollectionusr[i].IsActive = _user.IsActive;
                    ObservableCollectionusr[i].fullName = _user.fullName;
                    ObservableCollectionusr[i].PersonID = _user.PersonID;

                    break;
                }
            }
        }

      

        private void showDetilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = (int)dvUsers.CurrentRow.Cells[0].Value;
            frmUserInfo frm = new frmUserInfo(UserID);
            frm.ShowDialog();

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dvUsers.CurrentRow == null)
            {
                MessageBox.Show("Please select a user to delete.");
                return;
            }
              UserViewModel  SelectUser = dvUsers.CurrentRow.DataBoundItem as UserViewModel;
                if (MessageBox.Show("Are you you srue you wante to delete this User", "Confrim Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (clsUsers2.DeleteUser(SelectUser.UserID))
                    {
                        ObservableCollectionusr.Remove(SelectUser);
                    _RefreashData();
                    MessageBox.Show("User delete  successfully", "Delet", MessageBoxButtons.OK, MessageBoxIcon.Information);
                      
                    }
                    else
                    {
                        MessageBox.Show("Could not delete user.","Not delect", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                return;
                }
           
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


            fromAddUpdateUser frm = new fromAddUpdateUser();

            frm.onUserAdded += handonuserAdded;
            frm.ShowDialog();
            frm.onUserAdded -= handonuserAdded;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
