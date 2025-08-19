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

namespace DVLDSluotion.Drivers
{
    public partial class frmListDrivers : Form
    {
        public frmListDrivers()
        {
            InitializeComponent();
        }

        private void btclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
     
        List<DriverViewModel>DriverViews = new List<DriverViewModel>();
         void _RefreshDate()
        {
            dgDriver.DataSource = null;
            dgDriver.DataSource = DriverViews;

            lbRecorde.Text = dgDriver.RowCount.ToString();

            if (dgDriver.Rows.Count > 0)
            {
                dgDriver.Columns[0].HeaderText = "Driver ID";
                dgDriver.Columns[0].Width = 120;

                dgDriver.Columns[1].HeaderText = "Person ID";
                dgDriver.Columns[1].Width = 120;


                dgDriver.Columns[2].HeaderText = "National No.";
                dgDriver.Columns[2].Width = 140;

                dgDriver.Columns[3].HeaderText = "Full Name";
                dgDriver.Columns[3].Width = 320;

                dgDriver.Columns[4].HeaderText = "Date";
                dgDriver.Columns[4].Width = 160;

                dgDriver.Columns[5].HeaderText = "Active Licenses";
                dgDriver.Columns[5].Width = 120;
            }
        }
        private async void frmListDrivers_Load(object sender, EventArgs e)
        {
            DriverViews = await DriverViewModel.GetAdllDrivers();
            dgDriver.DataSource = DriverViews;
            cmFilter.SelectedIndex = 0;
            _RefreshDate();
        }

        private void txtValuesFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(cmFilter.Text == "National No." || cmFilter.Text ==  "Full Name")
            {
                e.Handled = char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
            }
        }

        private void txtValuesFilter_TextChanged(object sender, EventArgs e)
        { 
            List<DriverViewModel> DataFilter;

            if (txtValuesFilter.Text == "")
            {
                _RefreshDate();
                return;
            }

            switch (cmFilter.Text)
            {
                case "Driver ID":
                    {
                        DataFilter = DriverViews.Where(Drivers => Drivers.DriverID == int.Parse(txtValuesFilter.Text)).ToList();
                        dgDriver.DataSource = DataFilter;
                        break;
                    }
                case "Person ID":
                    {
                        DataFilter = DriverViews.Where(Drivers => Drivers.PersonID == int.Parse(txtValuesFilter.Text)).ToList();
                        dgDriver.DataSource = DataFilter;
                        break;
                    }
                case "National No.":
                    {
                        DataFilter = DriverViews.Where(Drivers => Drivers.NationalNo.ToLower().StartsWith(txtValuesFilter.Text.ToLower())).ToList();
                        dgDriver.DataSource = DataFilter;
                        break;
                    }
                case "Full Name": 
                    {
                        DataFilter = DriverViews.Where(Drivers => Drivers.FullName.ToLower().StartsWith(txtValuesFilter.Text.ToLower())).ToList();
                        dgDriver.DataSource = DataFilter;
                        break;
                    }
            }
            lbRecorde.Text = dgDriver.RowCount.ToString();

            

            
        }

        private void txtValuesFilter_Validating(object sender, CancelEventArgs e)
        {

        }

        private void cmFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtValuesFilter.Visible = (cmFilter.Text != "None");


            if (cmFilter.Text == "None")
            {
                txtValuesFilter.Enabled = false;
            }
            else
                txtValuesFilter.Enabled = true;

            txtValuesFilter.Text = "";
            txtValuesFilter.Focus();
        }

        private void showPersonInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonId = (int)dgDriver.CurrentRow.Cells[1].Value;
            frmShowPerson frm = new frmShowPerson(PersonId);
            frmAddUpdatePerson.DataBackperconAfertUpdate += DataBackperconAfertUpdate;
            frm.ShowDialog();
            _RefreshDate();
        }

        private void DataBackperconAfertUpdate(object from, clsPerson person)
        {
            for (int i = 0;i < DriverViews.Count;i++)
            {
              if(DriverViews[i].PersonID == person.PersonID)
              {
                    DriverViews[i].FullName = person.FullName;   
              }
            }
        }

        private void showLicenesHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgDriver.CurrentRow.Cells[1].Value;
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(PersonID);
            frm.ShowDialog();
            _RefreshDate();
        }
    }
}
