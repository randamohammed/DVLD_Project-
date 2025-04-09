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
    public partial class frmEditTestType : Form
    {
        public frmEditTestType(clsTestTypes.enTestType TestTypeID)
        {
            InitializeComponent();
            _TestTypeID = TestTypeID;
        }
        clsTestTypes.enTestType _TestTypeID = clsTestTypes.enTestType.VisionTes;
        clsTestTypes _TestType;
        private void frmEditTestType_Load(object sender, EventArgs e)
        {
            _TestType = clsTestTypes.FindByID(_TestTypeID);

            if(_TestType != null)
            {
                lbTestTpyeID.Text =((int)_TestTypeID).ToString();
                txtFees.Text = _TestType.Fees.ToString();
                txtTitle.Text = _TestType.Title;
                txtDescription.Text = _TestType.Description;
            }
            else
            {
                MessageBox.Show("Could Not Found Test Type with Id = " +  ((int)_TestTypeID).ToString(),"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("Same validated is not validt,put mous over red icon(s) to see error", "Not validat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }

            _TestType.Title = txtTitle.Text;
            _TestType.Description = txtDescription.Text;
            _TestType.Fees =Convert.ToInt32( txtFees.Text);
            if(_TestType.Save())
            {
                MessageBox.Show("Update Date successfully", "Updateed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error:Not Update Date successfully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void txtFees_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFees, "This is vailed");
            }
            else
            {
                errorProvider1.SetError(txtFees, null);
            }

            if(!clsVildation.ISNumber(txtFees.Text))
            {

                e.Cancel = true;
                errorProvider1.SetError(txtFees, "This is vailed");
            }
            else
            {
                errorProvider1.SetError(txtFees, null);

            }

        }

        private void txtDescription_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtDescription, "This is vailed");
            }
            else
            {
                errorProvider1.SetError(txtDescription, null);
            }
        }

        private void txtTitle_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTitle.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTitle, "This is vailed");
            }
            else
            {
                errorProvider1.SetError(txtTitle, null);
            }
        }
    }
}
