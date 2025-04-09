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
using static DVLDSluotion.Tests.ctrlScheduleTest;
using static SLDVLD_Buisness.clsPerson;

namespace DVLDSluotion.Tests
{
    public partial class ctrlScheduleTest : UserControl
    {
        public ctrlScheduleTest()
        {
            InitializeComponent();
        }

        enum enMode { AddNew = 0, Update = 1 };
        enMode Mode = enMode.AddNew;

        public enum enCreationMode { FirstTimeSchedule = 0, RetakeTestSchedule = 1 };
        private enCreationMode _CreationMode = enCreationMode.FirstTimeSchedule;

        public int _RetakeTestApplicationID = -1;

        clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        public int _LocalDrivingLicenseApplicationID = 0;

        clsTestAppointment _TestAppointment;
        public int _TestAppointmentID = -1;

        clsTestTypes.enTestType _TestypeID = clsTestTypes.enTestType.VisionTes;
        public clsTestTypes.enTestType TestTypeID
        {
            get {
                return (_TestypeID);
            }
            set
            {
                _TestypeID = value;
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

        public void LoadInfo(int LocalDrivingLicenseApplicationID, int AppointmentID)
        {
            if (AppointmentID == -1)
                Mode = enMode.AddNew;
            else
                Mode = enMode.Update;

            lbLocalDrivinApplicationID.Text = LocalDrivingLicenseApplicationID.ToString();
            _TestAppointmentID = AppointmentID;

            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseApplication(LocalDrivingLicenseApplicationID);

            if (_LocalDrivingLicenseApplication == null)
            {
                btSave.Visible = false;
                MessageBox.Show("Error: No Local Driving License Application with ID = " + _LocalDrivingLicenseApplicationID.ToString(),
                   "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_LocalDrivingLicenseApplication.DoesAttendTestType(TestTypeID))
            {
                _CreationMode = enCreationMode.RetakeTestSchedule;
            }
            else
                _CreationMode = enCreationMode.FirstTimeSchedule;

            if (_CreationMode == enCreationMode.RetakeTestSchedule)
            {
                lbTitel.Text = "Schedule Retake Test";
                lbRetakeTestFees.Text = "0";
                gbRetakeTestInfo.Enabled = true;
            }
            else
            {
                lbRetakTestID.Text = "A/N";
                lbTitel.Text = "Schedule Test";
                lbRetakeTestFees.Text = "0";
                gbRetakeTestInfo.Enabled = false;
            }

            lbLocalDrivinApplicationID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lbFullName.Text = _LocalDrivingLicenseApplication.FullName;
            lbClassName.Text = _LocalDrivingLicenseApplication.LicenseClass.ClassName;
            lbFees.Text = _LocalDrivingLicenseApplication.PaidFees.ToString();
            lbTiral.Text = _LocalDrivingLicenseApplication.TotalTrialsPerTest(TestTypeID).ToString();

            if (Mode == enMode.AddNew)
            {

                lbFees.Text = clsTestTypes.FindByID(_TestypeID).Fees.ToString();
                dtpDate.MinDate = DateTime.Now;
                lbRetakTestID.Text = "N/A";

                _TestAppointment = new clsTestAppointment();
            }
            else
            {
                if (!_LoadTestAppointmentData())
                    return;
            }


            lbTotalFees.Text = (Convert.ToInt32(lbFees.Text) + Convert.ToInt32(lbRetakeTestFees.Text)).ToString();

            if (!_HandleActiveTestAppointmentConstraint())
                return;

            if (!_HandleAppointmentLockedConstraint())
                return;

            if (!_HandlePrviousTestConstraint())
                return;

        }

        private bool _LoadTestAppointmentData()
        {
            _TestAppointment = clsTestAppointment.Find(_TestAppointmentID);
            if (_TestAppointment == null)
            {
                MessageBox.Show("Error: No Appointment with ID = " + _TestAppointmentID.ToString(),
               "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btSave.Enabled = false;
                return false;
            }
            else
            {
                lbFees.Text = _TestAppointment.PaidFees.ToString();

                if (DateTime.Compare(DateTime.Now, _TestAppointment.AppointmentDate) < 0)
                    dtpDate.MinDate = DateTime.Now;
                else
                    dtpDate.MinDate = _TestAppointment.AppointmentDate;

                dtpDate.Value = _TestAppointment.AppointmentDate;

                if (_RetakeTestApplicationID == -1)
                {
                    gbRetakeTestInfo.Enabled = false;
                    lbRetakTestID.Text = "A/N";
                    lbRetakeTestFees.Text = "0";
                }
                else
                {
                    gbRetakeTestInfo.Enabled = true;
                    lbTitel.Text = "Retak Test";
                    lbRetakTestID.Text = _TestAppointment.RetakeTestApplicationID.ToString();
                    lbRetakeTestFees.Text = clsAppplicationType.Find((int)clsApplication.enApplicationType.RetakeTest).Fees.ToString();
                }
                return true;

            }
        }
        private bool _HandleActiveTestAppointmentConstraint()
        {
            if (Mode == enMode.AddNew && clsLocalDrivingLicenseApplication.IsThereAnActiveScheduledTest(_LocalDrivingLicenseApplicationID, _TestypeID))
            {
                lblUserMessage.Text = "Person Already have an active appointment for this test";
                btSave.Enabled = false;
                dtpDate.Enabled = false;
                return false;
            }

            return true;
        }

        private bool _HandleAppointmentLockedConstraint()
        {
            if (_TestAppointment.IsLocked)
            {
                lblUserMessage.Text = "Person Already have an active appointment for this test";
                btSave.Enabled = false;
                dtpDate.Visible = false;
                lblUserMessage.Visible = true;
                return false;
            }
            lblUserMessage.Visible = false;
            return true;
        }

        private bool _HandlePrviousTestConstraint()
        {
            switch (TestTypeID)
            {
                case clsTestTypes.enTestType.VisionTes:
                    lblUserMessage.Visible = false;
                    return true;

                case clsTestTypes.enTestType.WrittenTest:
                    {
                        if (!_LocalDrivingLicenseApplication.DoesPassTestType(clsTestTypes.enTestType.VisionTes))
                        {
                            lblUserMessage.Visible = true;
                            lblUserMessage.Text = "Cannot Sechule, Vision Test should be passed first";
                            btSave.Visible = false;
                            dtpDate.Visible = false;
                            return false;
                        }
                        else
                        {
                            lblUserMessage.Visible = false;
                            btSave.Visible = true;
                            dtpDate.Visible = true;
                            return true;
                        }
                    }

                case clsTestTypes.enTestType.StreetTest:
                    {
                        if (!_LocalDrivingLicenseApplication.DoesPassTestType(clsTestTypes.enTestType.WrittenTest))
                        {
                            lblUserMessage.Visible = true;
                            lblUserMessage.Text = "Cannot Sechule, Written Test should be passed first";
                            btSave.Visible = false;
                            dtpDate.Visible = false;
                            return false;

                        }
                        else
                        {
                            lblUserMessage.Visible = false;
                            btSave.Visible = true;
                            dtpDate.Visible = true;
                            return true;
                        }
                    }
            }
                    return true;
            
        }
    
        private bool _HandleRetakeApplication()
        {
            if(Mode == enMode.AddNew && _CreationMode == enCreationMode.RetakeTestSchedule)
            {
                clsApplication _RetakeTestApplication = new clsApplication();

                _RetakeTestApplication.CreatedByUserID =  clsGlobal.CurrentUser.UserID;
                _RetakeTestApplication.LastStatusDate = DateTime.Now;
                _RetakeTestApplication.ApplicationDate = DateTime.Now;
                _RetakeTestApplication.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
                _RetakeTestApplication.ApplicationTypeID = (int)clsApplication.enApplicationType.RetakeTest;
                _RetakeTestApplication.ApplicantPersonID = _LocalDrivingLicenseApplication.ApplicantPersonID;
                _RetakeTestApplication.PaidFees = (float)clsAppplicationType.Find((int)clsApplication.enApplicationType.RetakeTest).Fees;

                if(!_RetakeTestApplication.Save())
                {
                    _TestAppointment.RetakeTestApplicationID = -1;
                    MessageBox.Show("Faild to Create application", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                _TestAppointment.RetakeTestApplicationID = _RetakeTestApplication.ApplicationID;
              
            }
            return true;
        }
        private void ctrlScheduleTest_Load(object sender, EventArgs e)
        {

        }
        private void btSave_Click(object sender, EventArgs e)
        {
            _TestAppointment.AppointmentDate = dtpDate.Value;
            _TestAppointment.IsLocked = false;
            _TestAppointment.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            _TestAppointment.TestTypeID = TestTypeID;
            _TestAppointment.PaidFees =Convert.ToSingle( lbFees.Text);
            _TestAppointment.LocalDrivingLicenseApplicationID = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID;

            if(_TestAppointment.Save())
            {

                Mode = enMode.Update;
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void gbTestType_Enter(object sender, EventArgs e)
        {

        }
    }
}
