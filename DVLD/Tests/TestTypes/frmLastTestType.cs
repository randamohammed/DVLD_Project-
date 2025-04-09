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
    public partial class frmLastTestType : Form
    {
        public frmLastTestType()
        {
            InitializeComponent();
        }


        DataTable dtAllTestType;
        private void frmLastTestType_Load(object sender, EventArgs e)
        {
            dtAllTestType = clsTestTypes.GetAllTestType();
            dvTestType.DataSource = dtAllTestType;
            lbRecorde.Text = dvTestType.RowCount.ToString();

            if(dvTestType.Rows.Count > 0 )
            {
                dvTestType.Columns[0].HeaderText = "ID";
                dvTestType.Columns[0].Width = 100;

                dvTestType.Columns[1].HeaderText = "Title";
                dvTestType.Columns[1].Width = 100;

                dvTestType.Columns[2].HeaderText = "Description";
                dvTestType.Columns[2].Width = 400;

                dvTestType.Columns[3].HeaderText = "Fees";
                dvTestType.Columns[3].Width = 100;
            }


        }

        private void edtitTestTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int TestTypeID =(int) dvTestType.CurrentRow.Cells[0].Value;
            frmEditTestType frm = new frmEditTestType((clsTestTypes.enTestType)TestTypeID);
            frm.ShowDialog();

            frmLastTestType_Load(null,null);
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
