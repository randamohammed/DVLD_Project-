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

namespace DVLDSluotion.Applications.International_License
{
    public partial class frmListInternationalLicesnseApplications : Form
    {
        public frmListInternationalLicesnseApplications()
        {
            InitializeComponent();
        }

        DataTable _dtAllInternationalLicesnseApplications;
        private void frmListInternationalLicesnseApplications_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;

            _dtAllInternationalLicesnseApplications = clsInternationalLicense.GetAllInternationalLicenses();
            dgInernationalLicenseApplications.DataSource = _dtAllInternationalLicesnseApplications;
            lbRecordes.Text = dgInernationalLicenseApplications.RowCount.ToString();

            if(dgInernationalLicenseApplications.Rows.Count > 0 )
            {
                dgInernationalLicenseApplications.Columns[0].HeaderText = "Int.License ID";
                dgInernationalLicenseApplications.Columns[0].Width = 120;

                dgInernationalLicenseApplications.Columns[1].HeaderText = "Application ID";
                dgInernationalLicenseApplications.Columns[1].Width = 120;

                dgInernationalLicenseApplications.Columns[2].HeaderText = "Driver ID";
                dgInernationalLicenseApplications.Columns[2].Width = 120;

                dgInernationalLicenseApplications.Columns[3].HeaderText = "L.License ID";
                dgInernationalLicenseApplications.Columns[3].Width = 120;

                dgInernationalLicenseApplications.Columns[4].HeaderText = "Issue Date";
                dgInernationalLicenseApplications.Columns[4].Width = 150;

                dgInernationalLicenseApplications.Columns[5].HeaderText = "Expiration Date";
                dgInernationalLicenseApplications.Columns[5].Width = 150;

                dgInernationalLicenseApplications.Columns[6].HeaderText = "Is Active";
                dgInernationalLicenseApplications.Columns[6].Width = 150;

                
            }

        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.Text == "Is Active")
            {
                cbIsReleased.SelectedIndex = 0;
                cbIsReleased.Visible = true;
                txtFilterValue.Visible = false;
                cbIsReleased.Focus();
                return;
            }
            else
            {
                txtFilterValue.Visible = cbFilterBy.Text != "None";
                cbIsReleased.Visible = false;

                if (cbFilterBy.Text == "None")
                {
                    txtFilterValue.Visible = false;
                }
                else
                    txtFilterValue.Enabled = true;

                txtFilterValue.Focus();
                txtFilterValue.Text = "";
                
            }
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";

            switch(cbFilterBy.Text )
            {
                case "International License ID":
                    FilterColumn = "InternationalLicenseID";
                    break;

                case "Local License ID":
                    FilterColumn = "ApplicationID";
                    break;

                case "Driver ID":
                    FilterColumn = "DriverID";
                    break;

                case "Application ID":
                    FilterColumn = "IssuedUsingLocalLicenseID";
                    break;

                case "Is Active":
                    FilterColumn = "IsActive";
                    break;

                default:
                    FilterColumn = "None";
                    break;

            }

            if(txtFilterValue.Text == "" || FilterColumn == "None")
            {
                _dtAllInternationalLicesnseApplications.DefaultView.RowFilter = "";
                lbRecordes.Text = dgInernationalLicenseApplications.Rows.Count.ToString();
                return;
            }

            _dtAllInternationalLicesnseApplications.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            lbRecordes.Text = dgInernationalLicenseApplications.RowCount.ToString();
            
                
        }

        private void cbIsReleased_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumns = "IsActive";
            string FilterValue = "";

            switch(cbIsReleased.Text )
            {
                case "All":
                    break;
                case "Yes":
                    FilterValue = "1";
                    break;
                case "No":
                    FilterValue = "0";
                    break;
            }

            if (FilterValue == "All")
                _dtAllInternationalLicesnseApplications.DefaultView.RowFilter = "";
            else
                _dtAllInternationalLicesnseApplications.DefaultView.RowFilter = string.Format("[{0}] = {1}",FilterColumns, FilterValue);

            lbRecordes.Text = dgInernationalLicenseApplications.RowCount.ToString();
                
        }

        private void PesonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int DriverID = (int)dgInernationalLicenseApplications.CurrentRow.Cells[2].Value;
            int PersonID = clsDriver.FindByID(DriverID).PresonID;

            frmShowPerson frm = new frmShowPerson(PersonID);
            frm.ShowDialog();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID =(int) dgInernationalLicenseApplications.CurrentRow.Cells[3].Value;

            frmShowLicenseInfo frm = new frmShowLicenseInfo(LicenseID);
            frm.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int DriverID = (int)dgInernationalLicenseApplications.CurrentRow.Cells[2].Value;
            int PersonID = clsDriver.FindByID(DriverID).PresonID;

            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(PersonID);
            frm.ShowDialog();
        }

        private void btAddNewInternational_Click(object sender, EventArgs e)
        {
            frmNewInternationalLicenseApplication frm = new frmNewInternationalLicenseApplication();
            frm.ShowDialog();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
