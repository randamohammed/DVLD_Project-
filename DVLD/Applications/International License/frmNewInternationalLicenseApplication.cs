using DVLDSluotion.Global_Classes;
using DVLDSluotion.Licenses.International_License;
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
    public partial class frmNewInternationalLicenseApplication : Form
    {
        public frmNewInternationalLicenseApplication()
        {
            InitializeComponent();
        }

        int SelectLicenseID = -1;
        int _InternationalLicenseID =-1;
        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowInternationalLicenseInfo frm = new frmShowInternationalLicenseInfo(_InternationalLicenseID);
            frm.ShowDialog();
        }

        private void ctrlDriverLicenseInfoWithFilter1_Load(object sender, EventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void frmNewInternationalLicenseApplication_Load(object sender, EventArgs e)
        {
            lbApplicationDate.Text = ClsFormat.FormatDate(DateTime.Now);
            lbIssueDate.Text = lbApplicationDate.Text;
            lbExpirationDate.Text = ClsFormat.FormatDate(DateTime.Now.AddYears(1));
            lbcreatedByUser.Text = clsGlobal.CurrentUser.UserName;
            lbFees.Text = clsAppplicationType.Find((int)clsApplication.enApplicationType.NewInternationalLicense).Fees.ToString();

        }

        private void ctrlDriverLicenseInfoWithFilter1_OnLicenesSelect(int obj)
        {
            SelectLicenseID = obj;

            llShowLicenseHistory.Enabled = SelectLicenseID != -1;

            if (SelectLicenseID == -1)
                return;

            if(ctrlDriverLicenseInfoWithFilter1.SelectLicenesinfo.LicenseClassIfo.LicenseClassID != 3)
            {
                MessageBox.Show("Selected License should be Class 3, select another one.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int ActiveInternaionalLicenseID = clsInternationalLicense.GetActiveInternationalLicenseIDByDriverID(ctrlDriverLicenseInfoWithFilter1.SelectLicenesinfo.DriverID);

            if(ActiveInternaionalLicenseID != -1)
            {
                MessageBox.Show("Person already have an active international license with ID = " + ActiveInternaionalLicenseID.ToString(), "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                llShowLicenseInfo.Enabled = false;
                lblInternationalLicenseID.Text = ActiveInternaionalLicenseID.ToString();
                btnIssueLicense.Enabled = false;
                return;
            }
            btnIssueLicense.Enabled = true;


        }

        private void btnIssueLicense_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to issue the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            clsInternationalLicense InternationalLicense = new clsInternationalLicense();

            InternationalLicense.ApplicantPersonID = ctrlDriverLicenseInfoWithFilter1.SelectLicenesinfo.SlelectDriverInfo.PresonID;
            InternationalLicense.ApplicationDate = DateTime.Now;
            InternationalLicense.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
          //  InternationalLicense.ApplicationTypeID =(int) clsApplication.enApplicationType.NewInternationalLicense;
            InternationalLicense.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            InternationalLicense.LastStatusDate = DateTime.Now;
            InternationalLicense.PaidFees = clsAppplicationType.Find((int)clsApplication.enApplicationType.NewInternationalLicense).Fees;

            InternationalLicense.ExpirationDate = DateTime.Now.AddYears(1);
            InternationalLicense.IssueDate = DateTime.Now;
            InternationalLicense.DriverID = ctrlDriverLicenseInfoWithFilter1.SelectLicenesinfo.DriverID;
            InternationalLicense.IssuedUsingLocalLicenseID = ctrlDriverLicenseInfoWithFilter1.LicenesID;

            if (!InternationalLicense.Save())
            {
                MessageBox.Show("Faild to Issue International License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }


            lblInternationalLicenseID.Text = InternationalLicense.InternationalLicenseID.ToString();
            lblApplicationID.Text = InternationalLicense.ApplicationID.ToString();
            _InternationalLicenseID = InternationalLicense.InternationalLicenseID;

            MessageBox.Show("International License Issued Successfully with ID=" + InternationalLicense.InternationalLicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);



            ctrlDriverLicenseInfoWithFilter1.FilterEnabled = false;
            btnIssueLicense.Enabled = false;
            llShowLicenseInfo.Enabled = true;
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(ctrlDriverLicenseInfoWithFilter1.SelectLicenesinfo.SlelectDriverInfo.PresonID);
            frm.ShowDialog();
        }

        private void frmNewInternationalLicenseApplication_Activated(object sender, EventArgs e)
        {
            ctrlDriverLicenseInfoWithFilter1.txtLicenseIDFocus();
        }
    }
}
