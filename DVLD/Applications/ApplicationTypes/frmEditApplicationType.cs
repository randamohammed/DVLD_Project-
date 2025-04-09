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
    public partial class frmEditApplicationType : Form
    {
        public frmEditApplicationType(int ApplicationTypeID)
        {
            InitializeComponent();
            this.ApplicationTypeID = ApplicationTypeID;
        }

        clsAppplicationType AppplicationType;
        int ApplicationTypeID = -1;
        private void btClsoe_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmEditApplicationType_Load(object sender, EventArgs e)
        {
            AppplicationType = clsAppplicationType.Find(ApplicationTypeID);

            if (AppplicationType != null)
            {
                txtTitle.Focus();
                txtTitle.Text = AppplicationType.Title;
                txtFees.Text = AppplicationType.Fees.ToString();
                lbApplicationID.Text = AppplicationType.ApplicationTypeIID.ToString();
            }
            else
            {
                MessageBox.Show("Not Found Application Type with ID = " + ApplicationTypeID,
                    "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void txtTitle_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtTitle.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTitle, "this is Invaild");
            }
            else
                errorProvider1.SetError(txtTitle, null);

        }

        private void txtFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFees, "this is Invaild");
            }
            else
                errorProvider1.SetError(txtFees, null);

            if(!clsVildation.ISNumber(txtFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFees, "this is Invaild");
            }
            else
                errorProvider1.SetError(txtFees, null);

        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("Same vailed not invailed, put mouse over red icon(s) to see error", 
                    "Not Invalied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AppplicationType.Title = txtTitle.Text.Trim();
            AppplicationType.Fees = Convert.ToSingle( txtFees.Text);

            if(AppplicationType.Save())
            {
                MessageBox.Show("Date Save Successfully","Saved",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            frmEditApplicationType_Load(null, null);
        }
    }
}
