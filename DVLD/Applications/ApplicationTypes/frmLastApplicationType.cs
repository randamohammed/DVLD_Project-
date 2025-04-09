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
    public partial class frmLastApplicationType : Form
    {
        public frmLastApplicationType()
        {
            InitializeComponent();
        }

        DataTable dtApplicationType;
        private void editAppplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ApplicationTypeID = (int)dvApplicationTypes.CurrentRow.Cells[0].Value;
            frmEditApplicationType frm = new frmEditApplicationType(ApplicationTypeID);
            frm.ShowDialog();
            frmLastApplicationType_Load(null,null);
        }

        private void frmLastApplicationType_Load(object sender, EventArgs e)
        {
            dtApplicationType = clsAppplicationType.GetAllApplicationnTypes();

            dvApplicationTypes.DataSource = dtApplicationType;
            lbRecorde.Text = dvApplicationTypes .RowCount.ToString();

            if(dvApplicationTypes.Rows.Count > 0 )
            {
                dvApplicationTypes.Columns[0].HeaderText = "ID";
                dvApplicationTypes.Columns[0].Width = 60;

                dvApplicationTypes.Columns[1].HeaderText = "Title";
                dvApplicationTypes.Columns[1].Width = 250;

                dvApplicationTypes.Columns[2].HeaderText = "Fees";
                dvApplicationTypes.Columns[2].Width = 80;
            }

        }

        private void buClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
