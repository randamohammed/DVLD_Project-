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

namespace DVLDSluotion.Applications.Controls
{
    public partial class ctrlApplicationBasicInfo : UserControl
    {
        public ctrlApplicationBasicInfo()
        {
            InitializeComponent();
        }

        clsApplication _Application;
        int _ApplicationID = -1;

        public int ApplicationID { get { return _ApplicationID; } }
        public void ResetApplicationInfo()
        {
            _ApplicationID = -1;
            lbApplicationFees.Text = "[????]";
            lbApplicationID.Text = "[????]";
            lbApplicationStatus.Text = "[????]";
            lbApplicationType.Text = "[????]";
            lbApplicatonDate.Text = "[????]";
            lbCreatedByUser.Text = "[????]";
            lbPersonName.Text = "[????]";
            lbStatusDate.Text = "[????]";
        }

        private void _FillApplicationInfo()
        {
            llViewPersonInfo.Enabled = true;
            _ApplicationID = _Application.ApplicationID;
            lbApplicationFees.Text =_Application.PaidFees.ToString();
            lbApplicationID.Text = _Application.ApplicationID.ToString();
            lbApplicationStatus.Text = _Application.Status;
            lbApplicationType.Text = _Application.AppplicationType.Title;
            lbApplicatonDate.Text = ClsFormat.FormatDate(_Application.ApplicationDate);        
            lbCreatedByUser.Text = _Application.SelectUserInfo.UserName;
            lbPersonName.Text = _Application.FullName;
            lbStatusDate.Text = ClsFormat.FormatDate(_Application.LastStatusDate);
        }

        public void LoadApplicationInfo(int ApplcatiionID)
        {
            _Application = clsApplication.FindBaseApplication(ApplcatiionID);
            if(_Application == null)
            {

                ResetApplicationInfo();
                MessageBox.Show("No Application with ApplicationID = " + ApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                _FillApplicationInfo();

            }
        }
        private void ctrlApplicationBasicInfo_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void llViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPerson frm = new frmShowPerson(_Application.ApplicantPersonID);
                frm.ShowDialog();
            LoadApplicationInfo(_Application.ApplicantPersonID);
        }
    }
}
