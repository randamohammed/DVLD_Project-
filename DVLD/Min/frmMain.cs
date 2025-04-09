using DVLDSluotion.Applications.International_License;
using DVLDSluotion.Applications.Renew_Driver_Licenes;
using DVLDSluotion.Applications.ReplaceLostOrDamagedLicense;
using DVLDSluotion.Applications.Rlease_Detained_License;
using DVLDSluotion.Drivers;
using DVLDSluotion.Licenses.Detain_License;
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
    public partial class frmMain : Form
    {
        Form _frmLogin;
        public frmMain(Form frmLogin)
        {
            InitializeComponent();
            _frmLogin = frmLogin;
        }

        private void frmMin_Load(object sender, EventArgs e)
        {
            this.Refresh();
            this.BackColor = Color.White;
        }

        private void peopleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmLastPeople frm = new frmLastPeople();
            frm.ShowDialog();
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
           frmListDrivers frm = new frmListDrivers();
            frm.ShowDialog();
        }

        private void usersToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmLastUser frm = new frmLastUser();
            frm.ShowDialog();
        }

        private void tsoCurrentUserInfo_Click(object sender, EventArgs e)
        {
            frmUserInfo frm = new frmUserInfo(clsGlobal.CurrentUser.UserID);
            frm.ShowDialog();
        }

        private void tsoChangePassword_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword(clsGlobal.CurrentUser.UserID);
            frm.ShowDialog();
        }

        private void stoSignOut_Click(object sender, EventArgs e)
        {
            this.Close();
            clsGlobal.CurrentUser = null;
            _frmLogin.Show();
        }

        private void manageApplicationTypesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmLastApplicationType frm = new frmLastApplicationType();
            frm.ShowDialog();
        }

        private void manageTestTypesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmLastTestType frm = new frmLastTestType();
            frm.ShowDialog();
        }

        private void tsoLocalLicense_Click(object sender, EventArgs e)
        {
            frmAddNewLocalLicenes frm = new frmAddNewLocalLicenes();
            frm.ShowDialog();
        }

        private void tsoLocalDrivingLicenseApplicatiions_Click(object sender, EventArgs e)
        {
            frmLastApplicationID frm = new frmLastApplicationID();
            frm.ShowDialog();
                
        }

        private void retakeTestToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmLastApplicationID frm = new frmLastApplicationID();
            frm.ShowDialog();
        }

        private void renewDrivingLicenseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmRenewLocalDrivingLicenseApplication frm = new frmRenewLocalDrivingLicenseApplication();
            frm.ShowDialog();
        }

        private void replacementForLostOrDamagedLicenseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmReplaceLostOrDamagedLicenseApplication frm = new frmReplaceLostOrDamagedLicenseApplication();
            frm.ShowDialog();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmDetainLicenseApplication frm = new frmDetainLicenseApplication();
            frm.ShowDialog();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicenseApplication frm = new frmReleaseDetainedLicenseApplication();
            frm.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmListDetainedLicenses frm = new frmListDetainedLicenses();
            frm.ShowDialog();
        }

        private void tsoInternationalLicenseApplication_Click(object sender, EventArgs e)
        {
            frmListInternationalLicesnseApplications frm = new frmListInternationalLicesnseApplications();
            frm.ShowDialog();
        }

        private void tsoInternationalLicense_Click(object sender, EventArgs e)
        {
            frmNewInternationalLicenseApplication frm = new frmNewInternationalLicenseApplication();
            frm.ShowDialog();
        }
    }
}
