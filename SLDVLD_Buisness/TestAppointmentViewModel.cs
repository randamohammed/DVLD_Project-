using SLDVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLDVLD_Buisness
{
    public class TestAppointmentViewModel
    {

        public clsTestTypes.enTestType TestTypeID { set; get; }
        public DateTime AppointmentDate { set; get; }
        public float PaidFees { set; get; }
        public bool IsLocked { set; get; }

        public TestAppointmentViewModel() 
        {
        }

        public  static async Task<List<TestAppointmentViewModel>> GetAllTestAppointment(clsTestTypes.enTestType TestTypeID ,int LocalDrivingLicenseApplicationID)
        {
            DataTable dt =await clsTestAppointment.GetApplicationTestAppointmentsPerTestType(LocalDrivingLicenseApplicationID,TestTypeID);

            List<TestAppointmentViewModel> testAppointments = new List<TestAppointmentViewModel>();

            foreach (DataRow appointment in dt.Rows)
            {
                if(appointment == null)
                {

              //    testAppointments.Add(appointment);
                }
            }
            return testAppointments;
        }

        public static TestAppointmentViewModel Find(int TestAppointmentID)
        {
            int CreatedByUserID = 0, LocalDrivingLicenseApplicationID = 0, RetakeTestApplicationID = 0, TestTypeID = 0;
            ;
            float PaidFees = 0;
            DateTime AppointmentDate = DateTime.Now;
            bool IsLocked = false;

            bool ISfound = clsTestAppointmentData.GetTestAppointmentInfoByID(TestAppointmentID, ref CreatedByUserID, ref IsLocked, ref LocalDrivingLicenseApplicationID,
               ref RetakeTestApplicationID, ref TestTypeID, ref PaidFees, ref AppointmentDate);

            if (ISfound)
            {
                // return new TestAppointmentViewModel(TestAppointmentID, LocalDrivingLicenseApplicationID, CreatedByUserID,
                  //  RetakeTestApplicationID, (clsTestTypes.enTestType)TestTypeID, IsLocked, PaidFees, AppointmentDate);
            }
            else
                return null;

            return null;
        }
    }
}
