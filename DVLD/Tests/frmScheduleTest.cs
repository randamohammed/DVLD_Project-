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

namespace DVLDSluotion
{
    public partial class frmScheduleTest : Form
    {
        
        public frmScheduleTest(int LoadTestAppointmentIID,clsTestTypes.enTestType testType,int AppointmentID = -1)
        {
            InitializeComponent();
            _AppointmentID = AppointmentID;
            _LoadTestAppointmentIID = LoadTestAppointmentIID;
            _TestType = testType;
        }
        clsTestTypes.enTestType _TestType = clsTestTypes.enTestType.VisionTes;
        int _LoadTestAppointmentIID = -1, _AppointmentID = -1;
        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctrlScheduleTest2_Load(object sender, EventArgs e)
        {

        }

        private void frmScheduleTest_Load(object sender, EventArgs e)
        {
            ctrlScheduleTest2.TestTypeID = _TestType;
            ctrlScheduleTest2.LoadInfo(_LoadTestAppointmentIID, _AppointmentID);
           
        }
    }
}
