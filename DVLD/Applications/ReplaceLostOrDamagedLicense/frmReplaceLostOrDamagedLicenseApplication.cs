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

namespace DVLDSluotion.Applications.ReplaceLostOrDamagedLicense
{
    public partial class frmReplaceLostOrDamagedLicenseApplication : Form
    {
        public frmReplaceLostOrDamagedLicenseApplication()
        {
            InitializeComponent();
        }
        int _NewLicenesID = 0;
        clsLicenes.enIssueReason GetIssueReason()
        {
            if(rbDamagedLicense.Checked)
                return clsLicenes.enIssueReason.DamagedReplacement;
            else
                return clsLicenes.enIssueReason.LostReplacement;
        }
        int GetApplicationTypeID()
        {
            if (rbDamagedLicense.Checked)
                return (int)clsApplication.enApplicationType.ReplaceDamagedDrivingLicense;
            else
                return (int)clsApplication.enApplicationType.ReplaceLostDrivingLicense;
        }
        private void frmReplaceLostOrDamagedLicenseApplication_Load(object sender, EventArgs e)
        {
            ctrlDriverLicenseInfoWithFilter1.txtLicenseIDFocus();
            lblApplicationDate.Text = ClsFormat.FormatDate(DateTime.Now);
            lblCreatedByUser.Text = clsGlobal.CurrentUser.UserName;
            rbDamagedLicense.Checked = true;
        }

        private void ctrlDriverLicenseInfoWithFilter1_OnLicenesSelect(int obj)
        {
            int SelectedLicenseID = obj;

            lblOldLicenseID.Text = SelectedLicenseID.ToString();
            llShowLicenesHstory.Enabled = SelectedLicenseID != -1;
            if (SelectedLicenseID == -1)
                return;

            if(!ctrlDriverLicenseInfoWithFilter1.SelectLicenesinfo.IsActive)
            {

                MessageBox.Show("Selected License is not Not Active, choose an active license."
                    , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnIssueReplacement.Enabled = false;
                return;
            }
            btnIssueReplacement.Enabled = true;

        }

        private void rbDamagedLicense_CheckedChanged(object sender, EventArgs e)
        {
            lbTitle.Text = "Replacement for Damaged License";
            this.Text = lbTitle.Text;
            lblApplicationFees.Text  = clsAppplicationType.Find(GetApplicationTypeID()).Fees.ToString();
        }

        private void rbLostLicense_CheckedChanged(object sender, EventArgs e)
        {
            lbTitle.Text = "Replacement for Lost License";
            this.Text = lbTitle.Text;
            lblApplicationFees.Text = clsAppplicationType.Find(GetApplicationTypeID()).Fees.ToString();
        }

        private void btnIssueReplacement_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Issue a Replacement for the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            clsLicenes NewLicense = ctrlDriverLicenseInfoWithFilter1.SelectLicenesinfo.Replace(GetIssueReason(), clsGlobal.CurrentUser.UserID);
            _NewLicenesID = NewLicense.LicenseID;
            if (NewLicense == null)
            {
                MessageBox.Show("Faild to Issue a replacemnet for this  License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblApplicationID.Text = NewLicense.ApplicationID.ToString();
            lblRreplacedLicenseID.Text = NewLicense.LicenseID.ToString();

            MessageBox.Show("Licenes Replaced successfully wiith id = " + _NewLicenesID,
                "License Issue", MessageBoxButtons.OK, MessageBoxIcon.Information);

            
            
           btnIssueReplacement.Enabled = false;
            llShowLicenesinfo.Enabled = true;
            ctrlDriverLicenseInfoWithFilter1.FilterEnabled = false;
            gbReplacementFor.Enabled = false;


        }

        private void llShowLicenesinfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo frm =   new frmShowLicenseInfo(_NewLicenesID);
            frm.ShowDialog();
        }

        private void frmReplaceLostOrDamagedLicenseApplication_Activated(object sender, EventArgs e)
        {
            ctrlDriverLicenseInfoWithFilter1.txtLicenseIDFocus();
        }

        private void llShowLicenesHstory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int PersonID = ctrlDriverLicenseInfoWithFilter1.SelectLicenesinfo.SlelectDriverInfo.PresonID;
            //clsLicenseClass.Find(_SelectLicenseID).
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(PersonID);
            frm.ShowDialog();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
