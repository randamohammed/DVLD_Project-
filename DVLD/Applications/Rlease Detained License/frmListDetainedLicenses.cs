using DVLDSluotion.Licenses.Detain_License;
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

namespace DVLDSluotion.Applications.Rlease_Detained_License
{
    public partial class frmListDetainedLicenses : Form
    {
        public frmListDetainedLicenses()
        {
            InitializeComponent();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        DataTable _dtDetaintedLicense;

        private void frmListDetainedLicenses_Load(object sender, EventArgs e)
        {
            cmFindBy.SelectedIndex = 0;

            _dtDetaintedLicense = clsDetainedLicenses.GetAllDetainedLicenses();
            dgListdetainedLicense.DataSource = _dtDetaintedLicense;
            lbRecordes.Text = dgListdetainedLicense.RowCount.ToString();

            if(dgListdetainedLicense.Rows.Count > 0 )
            {
                dgListdetainedLicense.Columns[0].HeaderText = "D.ID";
                dgListdetainedLicense.Columns[0].Width = 90;

                dgListdetainedLicense.Columns[1].HeaderText = "L.ID";
                dgListdetainedLicense.Columns[1].Width = 90;

                dgListdetainedLicense.Columns[2].HeaderText = "D.Date";
                dgListdetainedLicense.Columns[2].Width = 160;

                dgListdetainedLicense.Columns[3].HeaderText = "Is Released";
                dgListdetainedLicense.Columns[3].Width = 100;

                dgListdetainedLicense.Columns[4].HeaderText = "Fine Fees";
                dgListdetainedLicense.Columns[4].Width = 110;

                dgListdetainedLicense.Columns[5].HeaderText = "Release Date";
                dgListdetainedLicense.Columns[5].Width = 160;

                dgListdetainedLicense.Columns[6].HeaderText = "N.No.";
                dgListdetainedLicense.Columns[6].Width = 90;

                dgListdetainedLicense.Columns[7].HeaderText = "Full Name";
                dgListdetainedLicense.Columns[7].Width = 250;

                dgListdetainedLicense.Columns[8].HeaderText = "Release App.ID";
                dgListdetainedLicense.Columns[8].Width = 150;
            }

        }

        private void cmFindBy_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            if (cmFindBy.Text == "IS Released")
            {
                txtFiltervaiues.Visible = false;
                cmIsRelease.Visible = true;
              //  cmIsRelease.Focus();
                cmIsRelease.SelectedIndex = 0;
            }
            else
            {
                txtFiltervaiues.Visible = !(cmFindBy.Text == "None");
                cmIsRelease.Visible = false;

                if (cmFindBy.Text == "None")
                {
                    txtFiltervaiues.Visible = false;
                }
                else
                    txtFiltervaiues.Visible = true;

                txtFiltervaiues.Text = "";
                txtFiltervaiues.Focus();
            }
           

        }

        private void txtFiltervaiues_TextChanged(object sender, EventArgs e)
        {
            string ColumnsFilter = "";

            switch(cmFindBy.Text)
            {
                case "Detain ID":
                    ColumnsFilter = "DetainID";
                    break;

                case "Release application ID":
                    ColumnsFilter = "ReleaseApplicationID";
                    break;

                case "National No":
                    ColumnsFilter = "NationalNo";
                    break;

                case "Full Name":
                    ColumnsFilter = "FullName";
                    break;
                default:
                    ColumnsFilter = "None";
                    break;
            }

            if(txtFiltervaiues.Text == "" || ColumnsFilter  == "None")
            {
                _dtDetaintedLicense.DefaultView.RowFilter = "";
                return;
            }

            if(ColumnsFilter != "FullName" && ColumnsFilter != "NationalNo")
            {
                _dtDetaintedLicense.DefaultView.RowFilter = string.Format("[{0}] = {1}", ColumnsFilter, txtFiltervaiues.Text.Trim());
                lbRecordes.Text = dgListdetainedLicense.RowCount.ToString();
            }
            else
            {
                _dtDetaintedLicense.DefaultView.RowFilter = string.Format("[{0}] Like '{1}%'", ColumnsFilter, txtFiltervaiues.Text.Trim());
                lbRecordes.Text = dgListdetainedLicense.RowCount.ToString();
            }


        }

        private void cmIsRelease_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "IsReleased";
            string FilterValue = cmIsRelease.Text;

            switch(cmIsRelease.Text)
            {
                case "All":
                    break ;
                case "Yes":
                    FilterValue = "1";
                    break ;
                case  "No":
                    FilterValue = "0";
                    break ;

            }

            if (FilterValue == "All")
                _dtDetaintedLicense.DefaultView.RowFilter = "";
                 else
                _dtDetaintedLicense.DefaultView.RowFilter = string.Format("[{0}] = {1}",FilterColumn, FilterValue);

            lbRecordes.Text = dgListdetainedLicense.RowCount.ToString() ;


        }

        private void cmsApplications_Opening(object sender, CancelEventArgs e)
        {
            bool IsReleased =(bool) dgListdetainedLicense.CurrentRow.Cells[3].Value;

                releaseDetainedLicenesToolStripMenuItem.Enabled = !(IsReleased);
           
        }

        private void showPersonDetailesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string NationalNo  = dgListdetainedLicense.CurrentRow.Cells[6].Value.ToString();
            int PersonID = clsPerson.Find(NationalNo).PersonID;

                frmShowPerson frm = new frmShowPerson(PersonID);
                frm.ShowDialog();

        }

        private void showLicenseDetailesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LiceseId = (int)dgListdetainedLicense.CurrentRow.Cells[1].Value;

            frmShowLicenseInfo frm = new frmShowLicenseInfo(LiceseId);
            frm.ShowDialog();
        }

        private void showPersonLicenseHiistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dgListdetainedLicense.CurrentRow.Cells[1].Value;
            int PersonID = clsLicenes.FindByID(LicenseID).SlelectDriverInfo.PresonID;

            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(PersonID);
            frm.ShowDialog();
                
        }

        private void releaseDetainedLicenesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dgListdetainedLicense.CurrentRow.Cells[1].Value;
            frmReleaseDetainedLicenseApplication frm = new frmReleaseDetainedLicenseApplication(LicenseID);
            frm.ShowDialog();
            frmListDetainedLicenses_Load(null, null);

        }

        private void btReleaseLicense_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicenseApplication frm = new frmReleaseDetainedLicenseApplication();
            frm.ShowDialog();
            frmListDetainedLicenses_Load(null, null);
        }

        private void btDetaintLicense_Click(object sender, EventArgs e)
        {
            frmDetainLicenseApplication frm = new frmDetainLicenseApplication();
                frm.ShowDialog();
            frmListDetainedLicenses_Load(null, null);

        }
    }
}
