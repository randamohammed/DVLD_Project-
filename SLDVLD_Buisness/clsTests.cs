using SLDVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SLDVLD_Buisness.clsApplication;
using static SLDVLD_Buisness.clsPerson;

namespace SLDVLD_Buisness
{
    public class clsTests
    {
        public int TestID {  get; set; }
        public int TestAppointmentID { get; set; }
        
        public int CreatedByUserID { get; set; }
        public clsUsers2 SelectUsernfo;
        public string Notes {  get; set; }
        public bool TestResult {  get; set; }

        enum enMode { AddNew =0,Update = 1 }
        enMode Mode = enMode.AddNew;

        public clsTests()
        {
            TestID = -1;
            TestAppointmentID = -1;
            CreatedByUserID = -1;
            Notes = "";
            TestResult = false;
        }


        public clsTests(int TestID,int TestAppointmentID,int CreatedByUserID,bool TestResult,string Notes)
        {
            this.TestID = -TestID;
            this.TestAppointmentID =TestAppointmentID;
            this.CreatedByUserID = CreatedByUserID;
            this.Notes = Notes;
            this.TestResult = TestResult;
        }

        private bool _AddNewTest()
        {
            //call DataAccess Layer 

            this.TestID = clsTestData.AddNewTest(this.TestAppointmentID,
                this.TestResult, this.Notes, this.CreatedByUserID);


            return (this.TestID != -1);
        }

        private bool _UpdateTest()
        {
            //call DataAccess Layer 

            return clsTestData.UpdateTest(this.TestID, this.TestAppointmentID,
                this.TestResult, this.Notes, this.CreatedByUserID);
        }

        public static clsTests Find(int TestID)
        {
            int TestAppointmentID = -1;
            bool TestResult = false; string Notes = ""; int CreatedByUserID = -1;

            if (clsTestData.GetTestInfoByID(TestID,
            ref TestAppointmentID, ref TestResult,
            ref Notes, ref CreatedByUserID))

                return new clsTests(TestID,
                        TestAppointmentID, CreatedByUserID, TestResult,
                        Notes);
            else
                return null;

        }

        public static clsTests FindLastTestPerPersonAndLicenseClass
            (int PersonID, int LicenseClassID, clsTestTypes.enTestType TestTypeID)
        {
            int TestID = -1;
            int TestAppointmentID = -1;
            bool TestResult = false; string Notes = ""; int CreatedByUserID = -1;

            if (clsTestData.GetLastTestByPersonAndTestTypeAndLicenseClass
                (PersonID, LicenseClassID, (int)TestTypeID, ref TestID,
            ref TestAppointmentID, ref TestResult,
            ref Notes, ref CreatedByUserID))

                return new clsTests(TestID,
                        TestAppointmentID, CreatedByUserID,TestResult,
                        Notes);
            else
                return null;

        }

        public static DataTable GetAllTests()
        {
            return clsTestData.GetAllTests();

        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTest())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateTest();

            }

            return false;
        }

        public static byte GetPassedTestCount(int LocalDrivingLicenseApplicationID)
        {
            return clsTestData.GetPassedTestCount(LocalDrivingLicenseApplicationID);
        }

        public static bool PassedAllTests(int LocalDrivingLicenseApplicationID)
        {
            //if total passed test less than 3 it will return false otherwise will return true
            return GetPassedTestCount(LocalDrivingLicenseApplicationID) == 3;
        }



    }
}
