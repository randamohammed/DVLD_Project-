using DVLDSluotion.Global_Classes;
using DVLDSluotion.Properties;
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
using static SLDVLD_Buisness.clsTestTypes;

namespace DVLDSluotion.Tests.TestTypes
{
    public partial class ctrlSecheduledTest : UserControl
    {
        public ctrlSecheduledTest()
        {
            InitializeComponent();
        }

        clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        int _LocalDrivingLicenseApplicationID = -1;

        clsTestAppointment _TestAppointment;
        int _TestAppointmentID = -1;
        int _TestID  = -1;
        clsTestTypes.enTestType _TestypeID = clsTestTypes.enTestType.VisionTes;
        public clsTestTypes.enTestType TestTypeID
        {
            get
            {
                return (_TestypeID);
            }
            set
            {
                switch (_TestypeID)
                {
                    case clsTestTypes.enTestType.VisionTes:
                        {
                            gbTestType.Text = "Vision Test";
                            pbTestTypeImage.Image = Resources.Vision_512;
                            break;
                        }
                    case clsTestTypes.enTestType.WrittenTest:
                        {
                            gbTestType.Text = "Written Test";
                            pbTestTypeImage.Image = Resources.Written_Test_512;
                            break;
                        }
                    case clsTestTypes.enTestType.StreetTest:
                        {
                            gbTestType.Text = "Street Test";
                            pbTestTypeImage.Image = Resources.driving_test_512;
                            break;
                        }
                }
            }
        }
   
        public int TestAppointmentID
        {
            get { return _TestAppointmentID; }
        }

        public int TestID
        {
            get { return _TestID; }
        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        public void LoadInfo(int TestAppointmentID)
        {
            _TestAppointmentID = TestAppointmentID;

            _TestAppointment = clsTestAppointment.Find(TestAppointmentID);
            if( _TestAppointment == null )
            {
                MessageBox.Show("Error: No  Appointment ID = " + _TestAppointmentID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _TestAppointmentID = -1;
                return; ;
            }

            _LocalDrivingLicenseApplicationID = _TestAppointment.LocalDrivingLicenseApplicationID;
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseApplication(_LocalDrivingLicenseApplicationID);

            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("Error: No Local Driving License Application with ID = " + _LocalDrivingLicenseApplicationID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lbFees.Text = _LocalDrivingLicenseApplication.PaidFees.ToString();
            lbFullName.Text = _LocalDrivingLicenseApplication.FullName;
            lbLicenesClassName.Text = _LocalDrivingLicenseApplication.LicenseClass.ClassName;
            lbLocalApplicationID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lbTestDate.Text = ClsFormat.FormatDate(_LocalDrivingLicenseApplication.ApplicationDate);

            lbTrial.Text = _LocalDrivingLicenseApplication.TotalTrialsPerTest(_TestypeID).ToString();

            lbTestID.Text = (_TestAppointment.TestID != -1) ? _TestAppointment.TestID.ToString() : "No Test yet";
            _TestID = _TestAppointment.TestID;
        }
        private void ctrlSecheduledTest_Load(object sender, EventArgs e)
        {

        }
    }
}
