using SLDVLD_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVLDSluotion
{
    public partial class frmLadtApplication : Form
    {
        public frmLadtApplication()
        {
            InitializeComponent();
        }
        clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        DataTable dtAllLocalDrivingLicenseApplication;

        void _Refreshdate()
        {
            dtAllLocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplication();
            lbRecorde.Text = dvLocalDrivingLicense.RowCount.ToString();

            txtFilter.Visible = true;
            //  txtFilterValues.Focus();
        }
        private void frmLadtApplication_Load(object sender, EventArgs e)
        {
            dtAllLocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplication();
            dvLocalDrivingLicense.DataSource = dtAllLocalDrivingLicenseApplication;

            lbRecorde.Text = dvLocalDrivingLicense.RowCount.ToString();

            if (dvLocalDrivingLicense.RowCount > 0)
            {
                dvLocalDrivingLicense.Columns[0].HeaderText = "L.D.L AppIID";
                dvLocalDrivingLicense.Columns[0].Width = 100;

                dvLocalDrivingLicense.Columns[1].HeaderText = "Driving Class";
                dvLocalDrivingLicense.Columns[1].Width = 200;

                dvLocalDrivingLicense.Columns[2].HeaderText = "Natonal No.";
                dvLocalDrivingLicense.Columns[2].Width = 100;

                dvLocalDrivingLicense.Columns[3].HeaderText = "Full Name";
                dvLocalDrivingLicense.Columns[3].Width = 300;

                dvLocalDrivingLicense.Columns[4].HeaderText = "Application Date";
                dvLocalDrivingLicense.Columns[4].Width = 100;

                dvLocalDrivingLicense.Columns[5].HeaderText = "Passed Tests";
                dvLocalDrivingLicense.Columns[5].Width = 100;


                dvLocalDrivingLicense.Columns[6].HeaderText = "Status";
                dvLocalDrivingLicense.Columns[6].Width = 100;
            }
            cmFilter.SelectedIndex = 0;
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            switch (cmFilter.Text)
            {

                case "L.D.L.AppID":
                    FilterColumn = "LocalDrivingLicenseApplicationID";
                    break;

                case "National No.":
                    FilterColumn = "NationalNo";
                    break;


                case "Full Name":
                    FilterColumn = "FullName";
                    break;

                case "Status":
                    FilterColumn = "Status";
                    break;
                default:
                    FilterColumn = "None";
                    break;

            }

            if (txtFilter.Text == "" || FilterColumn == "None")
            {
                 _Refreshdate();
                dtAllLocalDrivingLicenseApplication.DefaultView.RowFilter = string.Format("");
                return;
            }

            if (FilterColumn == "LocalDrivingLicenseApplicationID")
            {
                dtAllLocalDrivingLicenseApplication.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilter.Text);
                lbRecorde.Text = dvLocalDrivingLicense.RowCount.ToString();
            }
            else
                dtAllLocalDrivingLicenseApplication.DefaultView.RowFilter = string.Format("[{0}] Like '{1}%'", FilterColumn, txtFilter.Text);
                lbRecorde.Text = dvLocalDrivingLicense.RowCount.ToString();
        }

        private void cmFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmFilter.Text =="None")
            {
                txtFilter.Visible = false;
                return;
            }
            txtFilter.Visible = true;
         txtFilter.Focus();
            txtFilter.Text = "";
        }
    }
    }

