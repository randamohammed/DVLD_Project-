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

namespace DVLDSluotion
{
    public partial class ctrlDriverLicenseInfo : UserControl
    {
        public ctrlDriverLicenseInfo()
        {
            InitializeComponent();
        }

        clsLicenes _Licenes;

        public int LicenesID { get; set; }

        public clsLicenes  SelectLicenesnfo
            {

            get
            {
                return _Licenes;
            }
            }
        private void label11_Click(object sender, EventArgs e)
        {

        }

        void _LoadPersonImage()
        {
            if (_Licenes.SlelectDriverInfo.SelectPersonInfo.Gendor == 1)
                pbPersonImage.Image = Resources.Female_512;
            else
                pbPersonImage.Image = Resources.Male_512;

            string ImagePath = _Licenes.SlelectDriverInfo.SelectPersonInfo.ImagePath;

            if (ImagePath != "")
                if (File.Exists(ImagePath))
                    pbPersonImage.ImageLocation = _Licenes.SlelectDriverInfo.SelectPersonInfo.ImagePath;
                else
                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }

        public void  LoadData(int LicenesID)
        {
            this.LicenesID = LicenesID;
            _Licenes = clsLicenes.FindByID(LicenesID);
           

            if (_Licenes == null)
            {
                MessageBox.Show("Could not found Licenes with id =" + LicenesID, "Not Found", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.LicenesID = -1;
                return;
            }

            lbLicnesID.Text = _Licenes.LicenseID.ToString();

                lbName.Text = _Licenes.SlelectDriverInfo.SelectPersonInfo.FullName;
                lbNationalNo.Text  = _Licenes.SlelectDriverInfo.SelectPersonInfo.NationalNo;
                lbIssueDate.Text = ClsFormat.FormatDate(_Licenes.IssueDate);
                lbGendor.Text = _Licenes.SlelectDriverInfo.SelectPersonInfo.Gendor ==0 ? "Male" : "Female";
                lbExpirationDate.Text = ClsFormat.FormatDate(_Licenes.ExpirationDate);
                lbDriverID.Text = _Licenes.DriverID.ToString();
                lbDateOfBirth.Text =ClsFormat.FormatDate( _Licenes.SlelectDriverInfo.SelectPersonInfo.DateOfBirth);
                lbIsActive.Text = _Licenes.IsActive == true ? "Yes" : "No";
                lbClass.Text = _Licenes.LicenseClassIfo.ClassName;
                 lbIsDetained.Text = _Licenes.IsDetained == true ? "Yes" : "No";
                  lbIssueReason.Text = _Licenes.IssueReasonText;
                lbNotes.Text = _Licenes.Notes == "" ? "No Notes" : _Licenes.Notes;

                _LoadPersonImage();
         

       }

        private void ctrlDriverLicenseInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
