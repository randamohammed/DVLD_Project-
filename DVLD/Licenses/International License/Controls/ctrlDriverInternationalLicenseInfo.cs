using DVLDSluotion.Global_Classes;
using DVLDSluotion.Properties;
using SLDVLD_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDSluotion.Licenses.International_License.Controls
{
    public partial class ctrlDriverInternationalLicenseInfo : UserControl
    {
        public ctrlDriverInternationalLicenseInfo()
        {
            InitializeComponent();
        }
        clsInternationalLicense _InternationalLicense;
        int _InternationalLicenseID = -1;
        private void _LoadPersonImage()
        {
            if (_InternationalLicense.DriverInfo.SelectPersonInfo.Gendor == 0)
                pbPersonImage.Image = Resources.Male_512;
            else
                pbPersonImage.Image = Resources.Female_512;

            string ImagePath = _InternationalLicense.DriverInfo.SelectPersonInfo.ImagePath;

            if (ImagePath != "")
                if (File.Exists(ImagePath))
                    pbPersonImage.Load(ImagePath);
                else
                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        public void LoadInfo(int InternationalLicenseID)
        {
            _InternationalLicenseID = InternationalLicenseID;
            _InternationalLicense = clsInternationalLicense.Find(_InternationalLicenseID);

            if(_InternationalLicense == null)
            {

                MessageBox.Show("Could not find Internationa License ID = " + _InternationalLicenseID.ToString(),
                 "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _InternationalLicenseID = -1;
                return;
            }
            lblApplicationID.Text = _InternationalLicense.ApplicationID.ToString();
            lblDateOfBirth.Text = ClsFormat.FormatDate(_InternationalLicense.DriverInfo.SelectPersonInfo.DateOfBirth);
            lblDriverID.Text = _InternationalLicense.DriverID.ToString();
            lblExpirationDate.Text =ClsFormat.FormatDate (_InternationalLicense.ExpirationDate);
            lblFullName.Text = _InternationalLicense.FullName.ToString();
            lblGendor.Text = _InternationalLicense.DriverInfo.SelectPersonInfo.Gendor == 0 ? "Male" : "Female";
            lblIsActive.Text = _InternationalLicense.IsActive == true ? "true" : "false";
            lblIssueDate.Text = ClsFormat.FormatDate(_InternationalLicense.IssueDate);
            lblLocalLicenseID.Text = _InternationalLicense.IssuedUsingLocalLicenseID.ToString();
            lblNationalNo.Text = _InternationalLicense.DriverInfo.SelectPersonInfo.NationalNo;
            lblInternationalLicenseID.Text = _InternationalLicense.InternationalLicenseID.ToString();

            _LoadPersonImage();
        }
        private void ctrlDriverInternationalLicenseInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
