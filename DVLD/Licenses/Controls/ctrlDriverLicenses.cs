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

namespace DVLDSluotion.Licenses.Controls
{
    public partial class ctrlDriverLicenses : UserControl
    {
        public ctrlDriverLicenses()
        {
            InitializeComponent();
        }

        DataTable _dtDriverLocalLicenes;
        DataTable _dtDriverInternationalLicenes;
        int _DriverID = 0;
        clsDriver _Driver;
        private void _LoadInternationalLicenseInfo()
        {
            _dtDriverInternationalLicenes = clsInternationalLicense.GetDriverInternationalLicenses(_DriverID);
            dgInternationalLicenses.DataSource = _dtDriverInternationalLicenes;
                lbinternationalRecorde.Text = dgInternationalLicenses.RowCount.ToString();

                if (dgLocalDriverLicenesHisory.RowCount > 0)
                {
                    dgInternationalLicenses.Columns[0].HeaderText = "Int.License ID";
                    dgInternationalLicenses.Columns[0].Width = 140;

                   dgInternationalLicenses.Columns[1].HeaderText = "Application ID";
                   dgInternationalLicenses.Columns[1].Width = 140;

                dgInternationalLicenses.Columns[2].HeaderText = "L.License ID";
                dgInternationalLicenses.Columns[2].Width = 140;

                dgInternationalLicenses.Columns[3].HeaderText = "Issue Date";
                dgInternationalLicenses.Columns[3].Width = 140;

                dgInternationalLicenses.Columns[4].HeaderText = "Expiration Date";
                dgInternationalLicenses.Columns[4].Width = 180;

                dgInternationalLicenses.Columns[5].HeaderText = "is Active";
                dgInternationalLicenses.Columns[5].Width = 100;

                }
        }
        public void LoadInfo(int DriverID)
        {
            _Driver = clsDriver.FindByID(DriverID);

            if (_Driver == null)
            {
                return;
            }
            _DriverID = _Driver.DriverID;
            _LoadInternationalLicenseInfo();
            _LoadLocalLicenseInfo();
        }

        public void LoadInfoByPersonID(int PersonID)
        {
            _Driver = clsDriver.FindByPersonID(PersonID);

            if (_Driver == null)
            {
                return;
            }
            _DriverID = _Driver.DriverID;
            _LoadInternationalLicenseInfo();
            _LoadLocalLicenseInfo();
        }

        private void _LoadLocalLicenseInfo()
        {
            _dtDriverLocalLicenes = clsDriver.GetLicenses(_DriverID);
            dgLocalDriverLicenesHisory.DataSource = _dtDriverLocalLicenes;
            lbLocalRecorde.Text = dgLocalDriverLicenesHisory.RowCount.ToString();

            if(dgLocalDriverLicenesHisory.RowCount > 0 )
            {
                dgLocalDriverLicenesHisory.Columns[0].HeaderText = "Lic ID";
                dgLocalDriverLicenesHisory.Columns[0].Width = 120;

                dgLocalDriverLicenesHisory.Columns[1].HeaderText = "App ID";
                dgLocalDriverLicenesHisory.Columns[1].Width = 120;

                dgLocalDriverLicenesHisory.Columns[2].HeaderText = "Class Name";
                dgLocalDriverLicenesHisory.Columns[2].Width =180;

                dgLocalDriverLicenesHisory.Columns[3].HeaderText = "issue Date";
                dgLocalDriverLicenesHisory.Columns[3].Width = 140;

                dgLocalDriverLicenesHisory.Columns[4].HeaderText = "Expiration Date";
                dgLocalDriverLicenesHisory.Columns[4].Width = 180;

                dgLocalDriverLicenesHisory.Columns[5].HeaderText = "is Active";
                dgLocalDriverLicenesHisory.Columns[5].Width = 100;

            }

        }

        public void Clear()
        {
          _dtDriverInternationalLicenes.Clear();
            _dtDriverLocalLicenes.Clear();

        }
        private void ctrlDriverLicenses_Load(object sender, EventArgs e)
        {

        }

        private void gbDriverLicenses_Enter(object sender, EventArgs e)
        {

        }

        private void tbLocalLicenes_Click(object sender, EventArgs e)
        {

        }

        private void tbInternationalLicenses_Click(object sender, EventArgs e)
        {

        }

        private void dgLocalDriverLicenesHisory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
