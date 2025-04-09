using DVLDSluotion.Properties;
using SLDVLD_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDSluotion
{
    public partial class frmAddUpdatePerson : Form
    {
        public frmAddUpdatePerson()
        {
            InitializeComponent();
            Mode = _Mode.AddPreson;
        }

        public frmAddUpdatePerson(int PersonID)
        {
            InitializeComponent();
            Mode = _Mode.UpdatePerson;
            _PersonID = PersonID;
        }

        public delegate void DataBackEventHandler(object from,int  PersonID);
        public event DataBackEventHandler DataBackPersonID;

        enum _Mode { AddPreson  =0,UpdatePerson=1};
        enum eGnder { Male =0,Female=1};
        _Mode Mode = _Mode.AddPreson;
        int _PersonID = 0;
        clsPerson _Person;

      private void _FullCountryIncombox()
        {
            DataTable dataTable = clsCountry.GetAllCountries();

            foreach(DataRow row in dataTable.Rows)
            {
                combCountry.Items.Add(row["CountryName"]);
            }
        }

        bool _HandleImagePerson()
        {
            if(_Person.ImagePath != pbPresonImage.ImageLocation)
            {
                if (_Person.ImagePath != "")
                {
                    try
                    {
                        File.Delete(_Person.ImagePath);
                    }
                    catch (IOException)
                    {
                        return false;
                    }
                }
               
                if(pbPresonImage.ImageLocation !=  null)
                {
                    string SourceImageFile = pbPresonImage.ImageLocation.ToString();

                    if (clsUtil.CopyImageinFloder( ref SourceImageFile))
                    {
                        pbPresonImage.ImageLocation = SourceImageFile;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                }
            
            return true;
        }
        

     void RefrechDefultValues()
     {
            _FullCountryIncombox();

            if (Mode == _Mode.AddPreson)
            {
                lbTitel.Text = "Add New Person";
                _Person = new clsPerson();
            }
            else
            {
                lbTitel.Text = "Update Person";
            }
            if (rbMale.Checked)
                pbPresonImage.Image = Resources.Male_512;
            else
                pbPresonImage.Image = Resources.Female_512;

            llRemoveImage.Visible = (pbPresonImage.ImageLocation != null);

            dtpDataofBirth.MaxDate = DateTime.Now.AddYears(-18);
            dtpDataofBirth.Value = dtpDataofBirth.MaxDate;

            dtpDataofBirth.MinDate = DateTime.Now.AddYears(-100);

            combCountry.SelectedIndex = combCountry.FindString("Jordan");

            tebFirstName.Text = "";
            tebLastName.Text = "";
            tebThirdName.Text = "";
            tebLastName.Text = "";
            tebNationalNo.Text = "";
            rbMale.Checked = true;
            tePhone.Text = "";
            tebEmail.Text = "";
            tebAdress.Text = "";
            llRemoveImage.Visible = false;
        }


        private void _LoadPerson()
      {
            _Person =  clsPerson.Find(_PersonID);


            if (_Person != null)
            {
                this.Text = lbTitel.Text.Trim();

                lbPersonID.Text = _PersonID.ToString();
                tebNationalNo.Text = _Person.NationalNo;
                tebFirstName.Text = _Person.FirstName;
                tebScenedname.Text = _Person.SecondName;
                tebThirdName.Text = _Person.ThirdName;
                tebLastName.Text = _Person.LastName;
                tePhone.Text = _Person.Phone;
                combCountry.SelectedIndex = combCountry.FindString(clsCountry.Find(_Person.NationalityCountryID).CountryName);
                tebAdress.Text = _Person.Address;
                tebEmail.Text = _Person.Email;
                dtpDataofBirth.Value = _Person.DateOfBirth;

                if (_Person.Gendor == 1)
                    rbFeMale.Checked = true;
                else
                    rbMale.Checked = true;

                if (_Person.ImagePath != "")
                    pbPresonImage.ImageLocation = _Person.ImagePath;

                llRemoveImage.Visible = _Person.ImagePath != "";
            }
        }

        private void frmAddUpdatePerson_Load(object sender, EventArgs e)
        {
            RefrechDefultValues();

            if (Mode == _Mode.UpdatePerson)
                _LoadPerson();
        }


        private void buClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void llSetImage_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string PathImag = openFileDialog1.FileName;
                pbPresonImage.ImageLocation = PathImag;
                llRemoveImage.Visible= true;
            }

        }

        private void btSave_Click_1(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                MessageBox.Show("Same fileds are  not viiled!,put this mouse over the red icon(s) to see error", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!_HandleImagePerson())
                return;

            _Person.PersonID = _PersonID;
            _Person.NationalNo = tebNationalNo.Text.Trim();
            _Person.FirstName = tebFirstName.Text.Trim();
            _Person.SecondName = tebScenedname.Text.Trim();
            _Person.ThirdName = tebThirdName.Text.Trim();
            _Person.LastName = tebLastName.Text.Trim();

            if (rbFeMale.Checked)
                _Person.Gendor = (short)eGnder.Female;
            else
                _Person.Gendor = (short)eGnder.Male;
            if(pbPresonImage.ImageLocation != null)
            _Person.ImagePath = pbPresonImage.ImageLocation;
            _Person.Address = tebAdress.Text.Trim();
            _Person.Email = tebEmail.Text.Trim();
            _Person.NationalityCountryID = clsCountry.Find(combCountry.Text).CountryID;
            _Person.DateOfBirth = dtpDataofBirth.Value;
            _Person.Phone = tePhone.Text.Trim();

            if (_Person.Save())
            {
                MessageBox.Show("Date Save Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lbPersonID.Text = _Person.PersonID.ToString();
                lbTitel.Text = "Update Person";
                this.Text = lbTitel.Text.Trim();
                DataBackPersonID?.Invoke(this,_PersonID);
            }
        }


        private void tebEmail_Validating_1(object sender, CancelEventArgs e)
        {
            if (tebEmail.Text == "")
                return;

            if (!clsVildation.ValidateEmail(tebEmail.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(tebEmail, "This field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(tebNationalNo, null);
            }
        }

        private void rbMale_CheckedChanged_1(object sender, EventArgs e)
        {
            if (pbPresonImage.ImageLocation == null)
                pbPresonImage.Image = Resources.Male_512;
        }

        private void rbFeMale_CheckedChanged(object sender, EventArgs e)
        {
            if (pbPresonImage.ImageLocation == null)
                pbPresonImage.Image = Resources.Female_512;
        }

        private void tebNationalNo_Validating_1(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tebNationalNo.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(tebNationalNo, "This field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(tebNationalNo, null);
            }

            if (tebNationalNo.Text != _Person.NationalNo && clsPerson.ISPeresonExist(_PersonID))
            {
                e.Cancel = true;
                errorProvider1.SetError(tebNationalNo, "National Number is used for another person!");
            }
            else
            {
                errorProvider1.SetError(tebNationalNo, null);
            }

        }

        private void llRemoveImage_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbPresonImage.ImageLocation = null;

            if (rbFeMale.Checked)
                pbPresonImage.Image = Resources.Female_512;
            else
                pbPresonImage.Image = Resources.Male_512;
        }

        private void buClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        
        private void ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {
            TextBox Temp = ((TextBox)sender);

            if(string.IsNullOrEmpty(Temp.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(Temp, "This field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(Temp, null);
            }

        }

        private void lbTitel_Click(object sender, EventArgs e)
        {

        }
    }
}
