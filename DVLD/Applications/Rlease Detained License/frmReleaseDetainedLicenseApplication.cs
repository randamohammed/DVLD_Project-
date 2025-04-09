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

namespace DVLDSluotion.Applications.Rlease_Detained_License
{
    public partial class frmReleaseDetainedLicenseApplication : Form
    {
        int _SelectLicenseID = -1;
        int _DetantID = -1;
        public frmReleaseDetainedLicenseApplication()
        {
            InitializeComponent();
        }


        public frmReleaseDetainedLicenseApplication(int LicenseID)
        {
            InitializeComponent();
            _SelectLicenseID = LicenseID;
            ctrlDriverLicenseInfoWithFilter1.LoadLicenseInfo(LicenseID);
            ctrlDriverLicenseInfoWithFilter1.FilterEnabled = false;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void lbFiineFees_Click(object sender, EventArgs e)
        {

        }

        private void ctrlDriverLicenseInfoWithFilter1_OnLicenesSelect(int obj)
        {
            _SelectLicenseID = obj;

            lbLicenseID.Text = _SelectLicenseID.ToString();
            llSowLicensesHistory.Enabled = (_SelectLicenseID != -1);

            if (_SelectLicenseID ==-1)
            {
                return;
            }

            if(!ctrlDriverLicenseInfoWithFilter1.SelectLicenesinfo.IsDetained)
            {
                MessageBox.Show("Selected License  is not detained, choose another one.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lbcreatedByUser.Text = clsGlobal.CurrentUser.UserName;
            lbDetaintID.Text = ctrlDriverLicenseInfoWithFilter1.SelectLicenesinfo.DetainedInfo.DetainID.ToString();
            lbFineFees.Text = ctrlDriverLicenseInfoWithFilter1.SelectLicenesinfo.DetainedInfo.FineFees.ToString();
            lbApplicationFees.Text =clsAppplicationType.Find((int) clsApplication.enApplicationType.ReleaseDetainedDrivingLicsense).Fees.ToString();
            lbDetinatDate.Text = ClsFormat.FormatDate(ctrlDriverLicenseInfoWithFilter1.SelectLicenesinfo.DetainedInfo.DetainDate);
           lbTotalFees.Text = (Convert.ToInt32(lbFineFees.Text) + Convert.ToInt32(lbApplicationFees.Text)).ToString();

            btReleaseLicenes.Enabled = true;
        }

        private void frmReleaseDetainedLicenseApplication_Load(object sender, EventArgs e)
        {

        }

        private void lbFineFees_Click(object sender, EventArgs e)
        {


        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btReleaseLicenes_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to release this detained  license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            int AppliactionID = -1;
            bool IsRelease = ctrlDriverLicenseInfoWithFilter1.SelectLicenesinfo.ReleaseDetainedLicense( clsGlobal.CurrentUser.UserID,ref AppliactionID);
     
           if(!IsRelease)
            {

                MessageBox.Show("Faild to to release the Detain License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lbApplicationID.Text = AppliactionID.ToString();
            MessageBox.Show("Detained License released Successfully ", "Detained License Released", MessageBoxButtons.OK, MessageBoxIcon.Information);
        
           
            btReleaseLicenes.Enabled = false;
            ctrlDriverLicenseInfoWithFilter1.FilterEnabled = false;
            llShowLicenesInfo.Enabled = true;
        
        }

        private void llShowLicenesInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo(_SelectLicenseID);
            frm.ShowDialog();
        }

        private void llSowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
         int PersonID=  ctrlDriverLicenseInfoWithFilter1.SelectLicenesinfo.SlelectDriverInfo.PresonID;
            //clsLicenseClass.Find(_SelectLicenseID).
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(PersonID);
            frm.ShowDialog();
        }

        private void frmReleaseDetainedLicenseApplication_Activated(object sender, EventArgs e)
        {
            ctrlDriverLicenseInfoWithFilter1.txtLicenseIDFocus();
        }
    }
}
