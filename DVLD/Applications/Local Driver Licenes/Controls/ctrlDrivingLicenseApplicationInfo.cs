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
using static System.Net.Mime.MediaTypeNames;

namespace DVLDSluotion.Applications.ApplicationTypes.Local_Driver_Licenes.Controls
{
    public partial class ctrlDrivingLicenseApplicationInfo : UserControl
    {
        public ctrlDrivingLicenseApplicationInfo()
        {
            InitializeComponent();
        }

        clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        int _LocalDrivingLicenseApplicationID = -1;
        int _LicenseID = -1;
        public int LocalDrivingLicenseApplicationID
        {
            get { return _LocalDrivingLicenseApplicationID; }
        }

        void ResetLocalDrivingLicenseApplication()
        {
            _LocalDrivingLicenseApplicationID = -1;
              lbLicenesclassName.Text =  "[????]";
              lbLocalApplicatonID.Text =  "[????]";
              lbPassedTests.Text  = "[????]";
            ctrlApplicationBasicInfo1.ResetApplicationInfo();
        }

        void _FillLocalDrivingLicenseApplication()
        {
            _LicenseID = _LocalDrivingLicenseApplication.GetActiveLicenseID();

            llShowLicenseInfo.Enabled = (_LicenseID != -1);


               lbPassedTests.Text =_LocalDrivingLicenseApplication.GetPassedTestCount().ToString();
            lbLocalApplicatonID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lbLicenesclassName.Text =clsLicenseClass.Find( _LocalDrivingLicenseApplication.LicenseClassID).ClassName;
            ctrlApplicationBasicInfo1.LoadApplicationInfo(_LocalDrivingLicenseApplication.ApplicationID);
        }

      public  void LoadApplicationInfoByLocalDrivingAppID(int LocalDrivingLicenseApplicationID)
        {
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseApplication(LocalDrivingLicenseApplicationID);

            if(_LocalDrivingLicenseApplication == null )
            {
                ResetLocalDrivingLicenseApplication();
                MessageBox.Show("No Application with ApplicationID = " + LocalDrivingLicenseApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                _FillLocalDrivingLicenseApplication();
            }

        }

        private void ctrlDrivingLicenseApplicationInfo_Load(object sender, EventArgs e)
        {
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
