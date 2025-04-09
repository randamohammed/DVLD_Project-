using SLDVLD_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace DVLDSluotion
{
    public partial class frmLastPeople : Form
    {
        public frmLastPeople()
        {
            InitializeComponent();
        }

       private static DataTable dtAllPeople = clsPerson.GetAllPerson(); 
       private static DataTable dtPeople = dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo",
                                                       "FirstName", "SecondName", "ThirdName", "LastName",
                                                       "GendorCaption", "DateOfBirth", "CountryName",
                                                       "Phone", "Email");
        private void frmLastPeople_Load(object sender, EventArgs e)
        {
            dgPaeople.DataSource = dtPeople;
            lbRecords.Text = dtPeople.Rows.Count.ToString();
            cbFilterBy.SelectedIndex = 0;

            if (dgPaeople.RowCount > 0)
            {
                dgPaeople.Columns[0].HeaderText = "Person ID";
                dgPaeople.Columns[0].Width = 110;

                dgPaeople.Columns[1].HeaderText = "National No";
                dgPaeople.Columns[1].Width = 100;

                dgPaeople.Columns[2].HeaderText = "First Name";
                dgPaeople.Columns[2].Width = 110;

                dgPaeople.Columns[3].HeaderText = "Second Name";
                dgPaeople.Columns[3].Width = 110;

                dgPaeople.Columns[4].HeaderText = "Third Name";
                dgPaeople.Columns[4].Width = 110;

                dgPaeople.Columns[5].HeaderText = "Last Name";
                dgPaeople.Columns[5].Width = 110;

                dgPaeople.Columns[6].HeaderText = "Gendor";
                dgPaeople.Columns[6].Width = 110;

                dgPaeople.Columns[7].HeaderText = "Date Of Birth";
                dgPaeople.Columns[7].Width = 130;

                dgPaeople.Columns[8].HeaderText = "Nationality";
                dgPaeople.Columns[8].Width = 100;

                dgPaeople.Columns[9].HeaderText = "Phone";
                dgPaeople.Columns[9].Width = 110;

                dgPaeople.Columns[10].HeaderText = "Emil";
                dgPaeople.Columns[10].Width = 160;


            }
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Visible = !(cbFilterBy.Text == "None");
            txtFilterValue.Text = "";
        }

        private void txtFilterValue_Validating(object sender, CancelEventArgs e)
        {
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) & e.KeyChar != (char)Keys.Back;

        }

        void _RefreshPeoplList()
        {


            dtAllPeople = clsPerson.GetAllPerson();
            dtPeople = dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo", "FirstName", "SecondName",
                                                                "ThirdName", "LastName", "GendorCaption", "DateOfBirth", "CountryName",
                                                                 "Phone", "Email" ); 

            dgPaeople.DataSource = dtPeople.DefaultView.ToTable();
            lbRecords.Text = dtPeople.Rows.Count.ToString();

        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";

            switch (cbFilterBy.Text)
            {
                case "Person ID":
                    FilterColumn = "PersonID";
                    break;
                case "National No":
                    FilterColumn = "NationalNo";
                    break;
                case "First Name":
                    FilterColumn = "FirstName";
                    break;

                case "Second Name":
                    FilterColumn = "SecondName";
                    break;


                case "Third Name":
                    FilterColumn = "ThirdName";
                    break;


                case "Last Name":
                    FilterColumn = "LastName";
                    break;


                case "Gander":
                    FilterColumn = "GanderCaption";
                    break;

                case "Phone":
                    FilterColumn = "Phone";
                    break;

                case "Country Name":
                    FilterColumn = "CountryName";
                    break;

                case "Email":
                    FilterColumn = "Email";
                    break;
                default:
                    FilterColumn = "None";
                    break;
            }

            if (FilterColumn == "None")
            {
                txtFilterValue.Visible = false;
                cmGender.Visible = false;
                _RefreshPeoplList();
            }

            if (FilterColumn == "PersonID")
                dtPeople.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                dtPeople.DefaultView.RowFilter = string.Format("[{0}] Like '{1}%'", FilterColumn, txtFilterValue.Text.Trim());
                   lbRecords.Text = dtPeople.Rows.Count.ToString();

        }

        private void cmGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmGender.Text)
            {
                case "All":
                    {
                        txtFilterValue.Visible = false;
                        _RefreshPeoplList();
                        break;
                    }
                case "Male":
                    dtPeople.DefaultView.RowFilter = string.Format("[{0}] = {1}", "GanderCaption", "0");
                    break;
                default:
                    dtPeople.DefaultView.RowFilter = string.Format("[{0}] = {1}", "GanderCaption", "1");
                    break;

            }




        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID =int.Parse( dgPaeople.CurrentRow.Cells[0].Value.ToString());
            Form frm = new frmShowPerson(PersonID);
            frm.ShowDialog();

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddUpdatePerson();
            frm.ShowDialog();
            _RefreshPeoplList();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = int.Parse(dgPaeople.CurrentRow.Cells[0].Value.ToString());
            Form frm = new frmAddUpdatePerson(PersonID);
            frm.ShowDialog();
            _RefreshPeoplList();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = int.Parse(dgPaeople.CurrentRow.Cells[0].Value.ToString());
            if (MessageBox.Show("Are you Sure yo want to delete person " + PersonID,"Delete",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                if(clsPerson.DeletePerson(PersonID))
                {
                    MessageBox.Show("Person Delete successfully", "Delete successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshPeoplList();
                }
            }
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void dgPaeople_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
    }
