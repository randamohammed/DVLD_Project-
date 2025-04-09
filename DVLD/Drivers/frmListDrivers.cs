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
        DataTable dtAllDriver;

        void RefreshDate()
        {
            dtAllDriver = clsDriver.GetAdllDrivers();
            dgDriver.DataSource = dtAllDriver;
            lbRecorde.Text = dgDriver.RowCount.ToString();
        }
        private void frmListDrivers_Load(object sender, EventArgs e)
        {
            dtAllDriver = clsDriver.GetAdllDrivers();
            dgDriver.DataSource = dtAllDriver;
            lbRecorde.Text = dgDriver.RowCount.ToString();

            if(dgDriver.Rows.Count > 0 )
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
            cmFilter.SelectedIndex = 0;
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
            string ColumnsFliter = "";

            switch(cmFilter.Text)
            {
                case "Driver ID":
                    ColumnsFliter = "DriverID";
                    break;
                case "Person ID":
                    ColumnsFliter = "PersonID";
                    break;
                case "National No.":
                    ColumnsFliter = "NationalNo";
                    break;
                case "Full Name":
                    ColumnsFliter = "FullName";
                    break;
                    default:
                    ColumnsFliter = "None";
                    break;


            }

            if(txtValuesFilter.Text ==    "" || ColumnsFliter == "None")
            {
                dtAllDriver.DefaultView.RowFilter = "";
                RefreshDate();
                return;
            }

            if(ColumnsFliter == "DriverID" || ColumnsFliter == "PersonID")
            {
                dtAllDriver.DefaultView.RowFilter = string.Format("[{0}] = {1}", ColumnsFliter, txtValuesFilter.Text.Trim());
                lbRecorde.Text = dgDriver.RowCount.ToString();
            }
            else
                dtAllDriver.DefaultView.RowFilter = string.Format("[{0}] Like '{1}%'", ColumnsFliter, txtValuesFilter.Text.Trim());
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
                frm.ShowDialog();
        }

        private void showLicenesHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgDriver.CurrentRow.Cells[1].Value;
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(PersonID);
                frm.ShowDialog();
        }
    }
}
