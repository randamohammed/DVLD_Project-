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
    public partial class ctrlPersonCardcs : UserControl
    {
        public ctrlPersonCardcs()
        {
            InitializeComponent();
        }

        clsPerson _Preson;
        public clsPerson SelectedPersonInfo { get{ return _Preson; }}

        int _PersonnID = 0;
        public int PersonID { get { return _PersonnID; } }


        private void _RefrechDefultVaules()
        {
            _PersonnID = -1;
            laAddress.Text = "[????]";
            laNationalNo.Text  = "[????]";
            laPhone.Text  = "[????]";
            laGender.Text  = "[????]";
            laEmail.Text  = "[????]";
            laDateofBirth.Text  = "[????]";
            laCountry.Text  = "[????]";
            laPersonName.Text  = "[????]";
            laPersonID.Text  = "[????]";
            pbGenderImage.Image = Resources.Man_32;
            pbPersonImagge.Image = Resources.Male_512;

        }

        void _hindleImagePerson()
        {
            if(_Preson.Gendor ==1)
                pbPersonImagge.Image = Resources.Female_512;
            else
            pbPersonImagge.Image= Resources.Male_512;

            string ImagePath = _Preson.ImagePath;

            if(ImagePath != "")
           if (File.Exists(ImagePath))
                pbPersonImagge.ImageLocation = _Preson.ImagePath;
           else
                MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }
        private void _FillPersonInfo()
        {
            _PersonnID = _Preson.PersonID;
            laPersonID.Text = _PersonnID.ToString();
            laNationalNo.Text = _Preson.NationalNo;
            laPersonName.Text = _Preson.FullName;
            laGender.Text = _Preson.Gendor == 1 ? "FeMale" : "Male";
            laEmail.Text = _Preson.Email;
            laDateofBirth.Text = _Preson.DateOfBirth.ToString("dd/MMM/yyyy");
            laCountry.Text = clsCountry.Find(_Preson.NationalityCountryID).CountryName;
            laPhone.Text = _Preson.Phone;
            laAddress.Text = _Preson.Address;
            _hindleImagePerson();
            llEditpersoninfo.Enabled = true;
        }

        public void LoadPersonInfo(int PersonID)
        {

            _Preson = clsPerson.Find(PersonID);

            if(_Preson == null)
            {
                _RefrechDefultVaules();
                MessageBox.Show("No Person with Person ID = " +PersonID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillPersonInfo();

        }

        public void RestortDate()
        {
            _RefrechDefultVaules();
        }
        public void LoadPersonInfo(string NationalNo)
        {
            _Preson = clsPerson.Find(NationalNo);

            if (_Preson == null)
            {
                _RefrechDefultVaules();
                MessageBox.Show("No Person with National No. = " + NationalNo.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillPersonInfo();

        }

        private void llEditpersoninfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson(_PersonnID);
            frm.ShowDialog();
            LoadPersonInfo(_PersonnID);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
