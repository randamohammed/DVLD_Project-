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
    public partial class frmIssueDriverLicenseFirstTime : Form
    {
        public frmIssueDriverLicenseFirstTime(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
        }
        int _LocalDrivingLicenseApplicationID = 0;
        clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        clsLicenes _Licenes;
        private void frmIssueDriverLicenseFirstTime_Load(object sender, EventArgs e)
        {
            txtNotes.Focus();

            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseApplication(_LocalDrivingLicenseApplicationID);
            if (_LocalDrivingLicenseApplication == null)
            {

                MessageBox.Show("No Applicaiton with ID=" + _LocalDrivingLicenseApplicationID.ToString(), "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            if(!_LocalDrivingLicenseApplication.PassedAllTests())
            {
                MessageBox.Show("Person Should Pass All Tests First.", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            int LicenesID = _LocalDrivingLicenseApplication.GetActiveLicenseID();
            if (LicenesID !=  -1)
            {

                MessageBox.Show("Person already has License before with License ID=" + LicenesID.ToString(), "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            ctrlDrivingLicenseApplicationInfo1.LoadApplicationInfoByLocalDrivingAppID(_LocalDrivingLicenseApplicationID);
        }

        private void btnIssueLicense_Click(object sender, EventArgs e)
        {
            int LicenesID = _LocalDrivingLicenseApplication.IssueLicenseForTheFirtTime(txtNotes.Text, clsGlobal.CurrentUser.UserID);

            if(LicenesID != -1)
            {
                MessageBox.Show("Licenes Issue successfully with id = " + LicenesID.ToString(), "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("License Was not Issued ! ",
                   "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
