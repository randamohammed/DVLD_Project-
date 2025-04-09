using DVLDSluotion.Global_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDSluotion.Licenses.Detain_License
{
    public partial class frmDetainLicenseApplication : Form
    {
        public frmDetainLicenseApplication()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        int _DetainID = -1;
        int _SelectLicenesID = -1;
        private void frmDetainLicenseApplication_Load(object sender, EventArgs e)
        {
            lbCreatedByUserID.Text = clsGlobal.CurrentUser.UserName;
            lbDetaiintDate.Text = ClsFormat.FormatDate(DateTime.Now);
            txtFeesDaetaint.Focus();
        }

        private void ctrlDriverLicenseInfoWithFilter1_OnLicenesSelect(int obj)
        {
             _SelectLicenesID = obj;

            lbLicenesID.Text = _SelectLicenesID.ToString();
            llShowLicenesHistory.Enabled = (_SelectLicenesID != -1);

            if(_SelectLicenesID == -1)
            {
                return;
            }

            if(ctrlDriverLicenseInfoWithFilter1.SelectLicenesinfo.IsDetained)
            {

                MessageBox.Show("Selected License i already detained, choose another one.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 return ;
            }


            if (!ctrlDriverLicenseInfoWithFilter1.SelectLicenesinfo.IsActive)
            {

                MessageBox.Show("Selected License is not anActive, choose another one.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            btDetaintLicenes.Enabled =true;

        }

        private void frmDetainLicenseApplication_Activated(object sender, EventArgs e)
        {
            ctrlDriverLicenseInfoWithFilter1.txtLicenseIDFocus();
        }

        private void txtFeesDaetaint_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFeesDaetaint.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFeesDaetaint, "Fees cannot be empty!");
            }
            else
                errorProvider1.SetError(txtFeesDaetaint, null);

            if(!clsVildation.ISNumber(txtFeesDaetaint.Text))
            {

                e.Cancel = true;
                errorProvider1.SetError(txtFeesDaetaint, "Invalid Number.");
            }
            else
                errorProvider1.SetError(txtFeesDaetaint, null);


        }

        private void llShowLicenesInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo(_SelectLicenesID);
            frm.ShowDialog();
        }

        private void btDetaintLicenes_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to detain this license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            if(!this.ValidateChildren())
            {
                MessageBox.Show("same vaild is not validet, put mouce over red icon(s) to see error", "not validat", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            float Fees =Convert.ToSingle( txtFeesDaetaint.Text);
            _DetainID = ctrlDriverLicenseInfoWithFilter1.SelectLicenesinfo.Detain(Fees, clsGlobal.CurrentUser.UserID);

            if(_DetainID == -1)
            {

                MessageBox.Show("Faild to Detain License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lbDatintID.Text = _DetainID.ToString();
            btDetaintLicenes.Enabled = false;
            llShowLicenesInfo.Enabled = true;

            MessageBox.Show("License Detained Successfully with ID=" + _DetainID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ctrlDriverLicenseInfoWithFilter1.FilterEnabled = false;
            txtFeesDaetaint.Enabled = false;

        }

        private void llShowLicenesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(ctrlDriverLicenseInfoWithFilter1.SelectLicenesinfo.SlelectDriverInfo.PresonID);
            frm.ShowDialog();
        }

        private void ctrlDriverLicenseInfoWithFilter1_Load(object sender, EventArgs e)
        {

        }
    }
}
