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
using static SLDVLD_Buisness.clsPerson;

namespace DVLDSluotion
{
    public partial class frmAddNewLocalLicenes : Form
    {
        public frmAddNewLocalLicenes()
        {
            InitializeComponent();
            Mode = enMode.AddNew;
        }


        public frmAddNewLocalLicenes(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            Mode = enMode.Update;
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
        }
        int _LocalDrivingLicenseApplicationID = -1;
        enum enMode { AddNew =0,Update =1};
        enMode Mode = enMode.AddNew;
        int _SelectPerson = -1;
        clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication = new clsLocalDrivingLicenseApplication();
        void _RefreshDevaulteData()
        {
            _FullLicenesClass();

            if (Mode == enMode.AddNew)
            {
               lbTitle.Text = "Add New Loacl Licesnes";
                this.Text = "Add New Loacl Licesnes";
                _LocalDrivingLicenseApplication = new clsLocalDrivingLicenseApplication();
                ctrlPersonCardWithFiltere1.TexFouce();
                tpApplicationInfo.Enabled = false;

                cmLicenseClass.SelectedIndex = 2;
                lbApplicationDate.Text = DateTime.Now.ToShortDateString();
                lbApplicationFees.Text = clsAppplicationType.Find((int)clsApplication.enApplicationType.NewDrivingLicense).Fees.ToString();
                lbCreatedBy.Text = clsGlobal.CurrentUser.UserName;
            }
            else
            {
                lbTitle.Text = "Update local Drivind Licenes Application";
                this.Text = "Update local Drivind Licenes Application";
                tpApplicationInfo.Enabled = true;
                btSave.Enabled = true;
            }
            
        }

        void _LoadData()
        {
            ctrlPersonCardWithFiltere1.FilterEnable = false;
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseApplication(_LocalDrivingLicenseApplicationID);

            if(_LocalDrivingLicenseApplication ==null)
            {

                MessageBox.Show("No Application with ID = " + _LocalDrivingLicenseApplicationID, "Application Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }
            else
            {
                lbApplicationDate.Text = ClsFormat.FormatDate(_LocalDrivingLicenseApplication.ApplicationDate);
                lbApplicationFees.Text = _LocalDrivingLicenseApplication.PaidFees.ToString();
                lbCreatedBy.Text =clsUsers2.FindByUserID( _LocalDrivingLicenseApplication.CreatedByUserID).UserName.ToString();
                lbLocalID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
                cmLicenseClass.SelectedIndex = cmLicenseClass.FindString(clsLicenseClass.Find(_LocalDrivingLicenseApplication.LicenseClassID).ClassName);
                ctrlPersonCardWithFiltere2.LoadPersonnfo(_LocalDrivingLicenseApplication.ApplicantPersonID);
            }
        }
        void _FullLicenesClass()
        {
            DataTable dt = new DataTable();

            dt = clsLicenseClass.GetAllLicenesClass();
            foreach (DataRow dr in dt.Rows)
            {
                cmLicenseClass.Items.Add(dr["ClassName"].ToString());
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void cmLicenseClass_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmAddNewLocalLicenes_Load(object sender, EventArgs e)
        {
            _RefreshDevaulteData();
            if(Mode == enMode.Update)
            {
               _LoadData();
            }
        }

        private void btCloase_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnApplicationInfoNext__Click(object sender, EventArgs e)
        {
            if(Mode == enMode.Update)
            {
                btSave.Enabled = true;
                tpApplicationInfo.Enabled = true;
                tcApplicationInfo.SelectedTab = tcApplicationInfo.TabPages["tpApplicationInfo"];
                return;
            }

            else
            {
                if(ctrlPersonCardWithFiltere1.PersonID != -1)
                {
                    btSave.Enabled = true;
                    tpApplicationInfo.Enabled = true;
                    tcApplicationInfo.SelectedTab = tcApplicationInfo.TabPages["tpApplicationInfo"];
                }
                else
                {
                    MessageBox.Show("Please Select a Person", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ctrlPersonCardWithFiltere1.TexFouce();
                }
            }
            }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int LicenesClassID = clsLicenseClass.GetLicenseClassInfoByClassName(cmLicenseClass.Text).LicenseClassID;
            int ActiveApplicationID = clsLocalDrivingLicenseApplication.GetActiveApplicationID(_SelectPerson, clsApplication.enApplicationType.NewInternationalLicense);

            if (ActiveApplicationID != -1)
            {
                MessageBox.Show("Choose another License Class, the selected Person Already have an active application for the selected class with id=" + ActiveApplicationID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmLicenseClass.Focus();
                return;
            }

            if (clsLicenes.IsLicenseExistByPersonID(ctrlPersonCardWithFiltere2.PersonID, LicenesClassID))
            {

                MessageBox.Show("Person already have a license with the same applied driving class, Choose diffrent driving class", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            _LocalDrivingLicenseApplication.ApplicantPersonID = ctrlPersonCardWithFiltere2.PersonID;
            _LocalDrivingLicenseApplication.ApplicationDate = DateTime.Now;
           _LocalDrivingLicenseApplication.ApplicationStatus =  clsApplication.enApplicationStatus.New;
            _LocalDrivingLicenseApplication.ApplicationTypeID =1;
            _LocalDrivingLicenseApplication.LastStatusDate = DateTime.Now;
            _LocalDrivingLicenseApplication.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            _LocalDrivingLicenseApplication.LicenseClassID = clsLicenseClass.GetLicenseClassInfoByClassName(cmLicenseClass.Text).LicenseClassID;
            _LocalDrivingLicenseApplication.PaidFees = Convert.ToSingle(lbApplicationFees.Text);

            if(_LocalDrivingLicenseApplication.Save())
            {
                Mode = enMode.Update;
                lbTitle.Text = "Update Local Driving License Application";
                lbLocalID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void ctrlPersonCardWithFiltere1_OnPersonSelect(int obj)
        {
            _SelectPerson = obj;
        }

        private void ctrlPersonCardWithFiltere2_OnPersonSelect(int obj)
        {
            _SelectPerson = obj;
            ///ctrlPersonCardWithFiltere1.LoadPersonnfo(_SelectPerson);
        }

        private void frmAddNewLocalLicenes_Activated(object sender, EventArgs e)
        {
            ctrlPersonCardWithFiltere2.TexFouce();
        }
    }
    
}
