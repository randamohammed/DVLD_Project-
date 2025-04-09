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
    public partial class CtrlPersonCardWithFiltere : UserControl
    {
        public CtrlPersonCardWithFiltere()
        {
            InitializeComponent();
        }

        clsPerson _Person;
        int _PersionID = 0;

        public event Action<int> OnPersonSelect;

        void PersonSelect(int personID)
        {
            Action<int> BackPersonID = OnPersonSelect;

            if (BackPersonID != null)
            {
                BackPersonID(personID);
            }
        }

        public clsPerson SelectPersoninfo
        {
            get 
            { 
                return ctrlPersonCardcs2.SelectedPersonInfo;
            }
        }
        public int PersonID
        {
            get
            {
                return ctrlPersonCardcs2.PersonID; 
            }
           
        }

        bool _FilterEnable = true;

        bool _ShowAddPerson = true;
        public bool TexFulterFouce
        {
            get { return _ShowAddPerson; }
            set 
            {
                _ShowAddPerson = value;
                btAddnewperson.Visible = _ShowAddPerson;
            }
        }
        public bool FilterEnable
        {
            get { return _FilterEnable; }
            set 
            { 
                _FilterEnable = value;
               gbFilter.Enabled = _FilterEnable;
            }
        }
       

     public  void FindNow()
        {
           _PersionID = Convert.ToInt32(tebFilter.Text);
            //_PersionID = int.Parse(tebFilter.Text);
            switch (conTypeFilter.Text)
            {
                case "Person ID":
                    {
                        ctrlPersonCardcs2.LoadPersonInfo(int.Parse(tebFilter.Text));
                        break;
                    }

                case "National No":
                    ctrlPersonCardcs2.LoadPersonInfo(tebFilter.Text);
                    break;
                default:            
                    break;
            }

            if (OnPersonSelect != null && FilterEnable)
                OnPersonSelect?.Invoke(ctrlPersonCardcs2.PersonID);
        }

       public void TexFouce()
        {
          
          tebFilter.Focus();
        }


        private void CtrlPersonCardWithFiltere_Load(object sender, EventArgs e)
        {
            tebFilter.Focus();
            conTypeFilter.SelectedIndex = 0;
        }

        public void LoadPersonnfo(int personID)
        {
            tebFilter.Text = personID.ToString();
            conTypeFilter.SelectedIndex = 0;
            FindNow();
        }
     
        private void btFind_Click(object sender, EventArgs e)
        {
           if(!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FindNow();
        }

        private void tebFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btFind.PerformClick();
            }

            if (conTypeFilter.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;

           
        }

        private void btAddnewperson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm =  new frmAddUpdatePerson();
            frm.ShowDialog();
            frm.DataBackPersonID += BackEvent;
        }

        private void BackEvent(object from, int PersonID)
        {
            conTypeFilter.SelectedIndex = 0;
            tebFilter.Text =PersonID.ToString();
           ctrlPersonCardcs2.LoadPersonInfo(PersonID);

        }

        private void tebFilter_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(tebFilter.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(tebFilter, "this is filed");
            }
            else
            {
                errorProvider1.SetError(tebFilter, null);
            }
        }

        private void tebFilter_TextChanged(object sender, EventArgs e)
        {

        }

        private void conTypeFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            tebFilter.Text = "";
            tebFilter.Focus();
        }

        private void ctrlPersonCardcs2_Load(object sender, EventArgs e)
        {

        }
    }
}
