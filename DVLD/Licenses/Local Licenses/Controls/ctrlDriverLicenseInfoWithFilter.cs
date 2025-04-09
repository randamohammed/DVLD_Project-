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
    public partial class ctrlDriverLicenseInfoWithFilter : UserControl
    {
        public ctrlDriverLicenseInfoWithFilter()
        {
            InitializeComponent();
        }

        public event Action<int> OnLicenesSelect;
       

        public virtual void LicenesSelect(int LicenesID)
        {
            Action<int>  Sender = OnLicenesSelect;
            if(Sender != null) 
                Sender(LicenesID);
        }

        int _LicenesID = -1;
        clsLicenes _Licenes;
        public int LicenesID
        {
            get { return ctrlDriverLicenseInfo1.LicenesID; }
        }

        public clsLicenes SelectLicenesinfo
        {
            get { return ctrlDriverLicenseInfo1.SelectLicenesnfo; }
        }

        bool _FilterEnabled = true;

        public bool FilterEnabled
        {
            get { return _FilterEnabled; }

            set
            {
                _FilterEnabled = value;
                gbFilter.Enabled = _FilterEnabled;
            }
        }

        public void LoadLicenseInfo(int LicenesID)
        {
            txtLicenseID.Text = LicenesID.ToString();

            ctrlDriverLicenseInfo1.LoadData(LicenesID);

            _LicenesID = ctrlDriverLicenseInfo1.LicenesID;

            if (OnLicenesSelect != null && FilterEnabled)
                OnLicenesSelect.Invoke(_LicenesID);
        }

        private void txtLicenseID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;

            if(e.KeyChar == (char)13)
                btFined.PerformClick();
        }

        private void txtLicenseID_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtLicenseID.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtLicenseID,"this is filed");
            }
            else
            {
                errorProvider1.SetError(txtLicenseID, null);
            }
        }

        private void btFined_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLicenseID.Focus();
                return;
            }
            _LicenesID =int.Parse( txtLicenseID.Text);
            LoadLicenseInfo(_LicenesID);
        }

        public void txtLicenseIDFocus()
        {
            txtLicenseID.Focus();
        }

        private void ctrlDriverLicenseInfoWithFilter_Load(object sender, EventArgs e)
        {

        }
    }
}
