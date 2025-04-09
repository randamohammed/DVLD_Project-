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

namespace DVLDSluotion.Tests
{
    public partial class frmTakeTest : Form
    {
        public frmTakeTest(int AppointmentID,clsTestTypes.enTestType TsetTypeID)
        {
            InitializeComponent();
            _AppointmentID = AppointmentID;
            this._TsetTypeID = TsetTypeID;
        }
        int _AppointmentID;
        clsTestAppointment _TestAppointment;
        clsTestTypes.enTestType _TsetTypeID = clsTestTypes.enTestType.VisionTes;

        int TestID = -1;
        clsTests _Tset;
        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        void LoadData()
        {
              ctrlSecheduledTest1.TestTypeID = _TsetTypeID;
              ctrlSecheduledTest1.LoadInfo(_AppointmentID);

            if(ctrlSecheduledTest1.TestAppointmentID == -1)
                 btSave.Enabled = false;
            else
                btSave.Enabled = true;

           
           TestID = ctrlSecheduledTest1.TestID;
            if (TestID != -1)
            {
                _Tset = clsTests.Find(TestID);



                if (_Tset.TestResult == true)
                    rbPass.Checked = true;
                else
                    rbFial.Checked = false;

                lblUserMessage.Visible = true;
                rbFial.Enabled = false;
                rbPass.Enabled = false;
                btSave.Enabled = true;
                txtNotes.Text = _Tset.Notes;
            }
            else
                _Tset = new clsTests();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to save? After that you cannot change the Pass/Fail results after you save?.",
                      "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes
             )
            {
                _Tset.Notes = txtNotes.Text;
                _Tset.TestResult = (rbPass.Checked) ? true : false;
                _Tset.CreatedByUserID = clsGlobal.CurrentUser.UserID;
                _Tset.TestAppointmentID = _AppointmentID;

                if (_Tset.Save())
                {
                    MessageBox.Show("Data Save Successfully","Saved",MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btSave.Enabled = false;
                    this.Close();
                }
                else
                    MessageBox.Show("Error: Data is not Save Successfully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
    }
}
