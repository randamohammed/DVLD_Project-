using DVLDSluotion.Global_Classes;
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

namespace DVLDSluotion.Applications.Renew_Driver_Licenes
{
    public partial class frmRenewLocalDrivingLicenseApplication : Form
    {

        public frmRenewLocalDrivingLicenseApplication()
        {
            InitializeComponent();
        }
        int NewLicenseID = -1;
        
        private void ctrlDriverLicenseInfoWithFilter1_OnLicenesSelect(int obj)
        {
          int  SelectedLicenseID = obj;
           int DefaultValidityLength = ctrlDriverLicenseInfoWithFilter1.SelectLicenesinfo.LicenseClassIfo.DefaultValidityLength;
            llShowLicenseHistor.Enabled = SelectedLicenseID != -1;
            if (SelectedLicenseID == -1)
            {
              return;
            }

            NewLicenseID = SelectedLicenseID;
            lblOldLicenseID.Text = SelectedLicenseID.ToString();
            lblExpirationDate.Text = ClsFormat.FormatDate(DateTime.Now.AddDays(DefaultValidityLength));          
            lblLicenseFees.Text = ctrlDriverLicenseInfoWithFilter1.SelectLicenesinfo.LicenseClassIfo.ClassFees.ToString();
            lblTotalFees.Text = (Convert.ToInt32(lblLicenseFees.Text) + Convert.ToInt32(lblApplicationFees.Text)).ToString();
            txtNotes.Text = ctrlDriverLicenseInfoWithFilter1.SelectLicenesinfo.Notes.ToString();


            if (!ctrlDriverLicenseInfoWithFilter1.SelectLicenesinfo.IsLicenseExpired())
            {
                MessageBox.Show("Selected License is not yet expiared, it will expire on: " + ClsFormat.FormatDate(ctrlDriverLicenseInfoWithFilter1.SelectLicenesinfo.ExpirationDate)
                    , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btRenewLicenes.Enabled = false;
                return;
            }

            if (!ctrlDriverLicenseInfoWithFilter1.SelectLicenesinfo.IsActive)
            {
                MessageBox.Show("Selected License is not Not Active, choose an active license."
                    , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                btRenewLicenes.Enabled = false;
                return;
            }
            btRenewLicenes.Enabled = true;

        }

        private void frmRenewLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            ctrlDriverLicenseInfoWithFilter1.txtLicenseIDFocus();
            lblApplicationDate.Text = ClsFormat.FormatDate(DateTime.Now);
            lblIssueDate.Text = ClsFormat.FormatDate(DateTime.Now);
            lblCreatedByUser.Text = clsGlobal.CurrentUser.UserName;
            lblApplicationFees.Text = clsAppplicationType.Find((int)clsApplication.enApplicationType.ReleaseDetainedDrivingLicsense).Fees.ToString();
        }

        private void btRenewLicenes_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Renew the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            clsLicenes NewLicense = ctrlDriverLicenseInfoWithFilter1.SelectLicenesinfo.RenewLicense(txtNotes.Text, clsGlobal.CurrentUser.UserID);

          if(NewLicense == null)
            {
                MessageBox.Show("Faild to Renew the License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            lblApplicationID.Text = NewLicense.ApplicationID.ToString();
            lblRenewedLicenseID.Text = NewLicense.LicenseID.ToString();
            NewLicenseID = NewLicense.LicenseID;
            MessageBox.Show("Licensed Renewed Successfully with ID=" + NewLicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
            llShowLicenseInfo.Enabled = true;
            ctrlDriverLicenseInfoWithFilter1.FilterEnabled = false;
            btRenewLicenes.Enabled = false;
            llShowLicenseInfo.Enabled = true;


        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo(NewLicenseID);
                frm.ShowDialog();
        }

        private void ctrlDriverLicenseInfoWithFilter1_Load(object sender, EventArgs e)
        {

        }

        private void llShowLicenseHistor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(ctrlDriverLicenseInfoWithFilter1.SelectLicenesinfo.SlelectDriverInfo.SelectPersonInfo.PersonID);
            frm.ShowDialog();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
