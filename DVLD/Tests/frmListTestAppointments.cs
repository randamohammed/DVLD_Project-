using DVLDSluotion.Properties;
using DVLDSluotion.Tests;
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

namespace DVLDSluotion
{
    public partial class frmListTestAppointments : Form
    {
        public frmListTestAppointments(int LocalDrivingLicenseApplicationID, clsTestTypes.enTestType TestType)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestTypeID = TestType;
        }

        int _LocalDrivingLicenseApplicationID = -1;
        clsTestTypes.enTestType _TestTypeID = enTestType.VisionTes;
        clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;

        DataTable dtAllTestAppointments;
        private void frmListTestAppointments_Load(object sender, EventArgs e)
        {
            _LoadTestTypeImageAndTitle();

            ctrlDrivingLicenseApplicationInfo1.LoadApplicationInfoByLocalDrivingAppID(_LocalDrivingLicenseApplicationID);
            dtAllTestAppointments = clsTestAppointment.GetApplicationTestAppointmentsPerTestType(_LocalDrivingLicenseApplicationID, _TestTypeID);
            dgvLicenseTestAppointments.DataSource = dtAllTestAppointments;
            lbRecorde.Text = dgvLicenseTestAppointments.RowCount.ToString();

            if(dgvLicenseTestAppointments.RowCount > 0 )
            {
                dgvLicenseTestAppointments.Columns[0].HeaderText = "Appointment ID";
                dgvLicenseTestAppointments.Columns[0].Width= 100;

                dgvLicenseTestAppointments.Columns[1].HeaderText = "Appointment Date";
                dgvLicenseTestAppointments.Columns[1].Width = 200;

                dgvLicenseTestAppointments.Columns[2].HeaderText = "Paid Fees";
                dgvLicenseTestAppointments.Columns[2].Width = 140;

                dgvLicenseTestAppointments.Columns[3].HeaderText = "Is Locked";
                dgvLicenseTestAppointments.Columns[3].Width = 60;

     
            }

        }

        private void _LoadTestTypeImageAndTitle()
        {
            switch(_TestTypeID )
            {
                case enTestType.VisionTes:
                    {
                        lblTitle.Text = "Vision Test";
                        this.Text = lblTitle.Text;
                        pbTestTypeImage.Image = Resources.Vision_512;
                        break;
                    }
                case enTestType.WrittenTest:
                    {
                        lblTitle.Text = "Written Test";
                        this.Text = lblTitle.Text;
                        pbTestTypeImage.Image = Resources.Written_Test_512;
                        break;
                    }
                case enTestType.StreetTest:
                    {

                        lblTitle.Text = "Street Test";
                        this.Text = lblTitle.Text;
                        pbTestTypeImage.Image = Resources.TestType_512;
                        break;
                    }
            }
        }
        private void btAddNewTestAppiment_Click(object sender, EventArgs e)
        {
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseApplication(_LocalDrivingLicenseApplicationID);

       

            if (_LocalDrivingLicenseApplication.IsThereAnActiveScheduledTest(_TestTypeID))
            {
                MessageBox.Show("Person Already have an active appointment for this test, You cannot add new appointment", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsTests Test = _LocalDrivingLicenseApplication.GetLastTestPerTestType(_TestTypeID);
            if(Test == null)
            {
                frmScheduleTest frm = new frmScheduleTest(_LocalDrivingLicenseApplicationID,_TestTypeID);
                frm.ShowDialog();
                frmListTestAppointments_Load(null, null);
                return;
            }

            if(Test.TestResult == true)
            {
                MessageBox.Show("This person already passed this test before, you can only retake faild test", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmScheduleTest frm2 = new frmScheduleTest(_LocalDrivingLicenseApplicationID, _TestTypeID);
            frm2.ShowDialog();
            frmListTestAppointments_Load(null, null);



        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editTestApplointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ApplointmentID =(int )dgvLicenseTestAppointments.CurrentRow.Cells[0].Value;
            frmScheduleTest frm = new frmScheduleTest(_LocalDrivingLicenseApplicationID, _TestTypeID, ApplointmentID);
            frm.ShowDialog();
            frmListTestAppointments_Load(null, null);
        } 

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ApplointmentID = (int)dgvLicenseTestAppointments.CurrentRow.Cells[0].Value;
            frmTakeTest frm = new frmTakeTest(ApplointmentID, _TestTypeID);
            frm.ShowDialog();
            frmListTestAppointments_Load(null, null);
        }
    }
}
