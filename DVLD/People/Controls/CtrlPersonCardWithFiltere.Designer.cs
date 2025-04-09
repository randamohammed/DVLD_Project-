namespace DVLDSluotion
{
    partial class CtrlPersonCardWithFiltere
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gbFilter = new System.Windows.Forms.GroupBox();
            this.btAddnewperson = new System.Windows.Forms.Button();
            this.btFind = new System.Windows.Forms.Button();
            this.tebFilter = new System.Windows.Forms.TextBox();
            this.conTypeFilter = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ctrlPersonCardcs1 = new DVLDSluotion.ctrlPersonCardcs();
            this.ctrlPersonCardcs2 = new DVLDSluotion.ctrlPersonCardcs();
            this.gbFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbFilter
            // 
            this.gbFilter.Controls.Add(this.btAddnewperson);
            this.gbFilter.Controls.Add(this.btFind);
            this.gbFilter.Controls.Add(this.tebFilter);
            this.gbFilter.Controls.Add(this.conTypeFilter);
            this.gbFilter.Controls.Add(this.label1);
            this.gbFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFilter.Location = new System.Drawing.Point(3, 14);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(814, 67);
            this.gbFilter.TabIndex = 1;
            this.gbFilter.TabStop = false;
            this.gbFilter.Text = "Filter";
            // 
            // btAddnewperson
            // 
            this.btAddnewperson.Image = global::DVLDSluotion.Properties.Resources.Add_Person_40;
            this.btAddnewperson.Location = new System.Drawing.Point(534, 15);
            this.btAddnewperson.Name = "btAddnewperson";
            this.btAddnewperson.Size = new System.Drawing.Size(53, 48);
            this.btAddnewperson.TabIndex = 4;
            this.btAddnewperson.UseVisualStyleBackColor = true;
            this.btAddnewperson.Click += new System.EventHandler(this.btAddnewperson_Click);
            // 
            // btFind
            // 
            this.btFind.Image = global::DVLDSluotion.Properties.Resources.SearchPerson;
            this.btFind.Location = new System.Drawing.Point(452, 16);
            this.btFind.Name = "btFind";
            this.btFind.Size = new System.Drawing.Size(53, 48);
            this.btFind.TabIndex = 3;
            this.btFind.UseVisualStyleBackColor = true;
            this.btFind.Click += new System.EventHandler(this.btFind_Click);
            // 
            // tebFilter
            // 
            this.tebFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tebFilter.Location = new System.Drawing.Point(267, 26);
            this.tebFilter.Multiline = true;
            this.tebFilter.Name = "tebFilter";
            this.tebFilter.Size = new System.Drawing.Size(159, 26);
            this.tebFilter.TabIndex = 2;
            this.tebFilter.TextChanged += new System.EventHandler(this.tebFilter_TextChanged);
            this.tebFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tebFilter_KeyPress);
            this.tebFilter.Validating += new System.ComponentModel.CancelEventHandler(this.tebFilter_Validating);
            // 
            // conTypeFilter
            // 
            this.conTypeFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.conTypeFilter.FormattingEnabled = true;
            this.conTypeFilter.Items.AddRange(new object[] {
            "Person ID",
            "National No"});
            this.conTypeFilter.Location = new System.Drawing.Point(102, 26);
            this.conTypeFilter.Name = "conTypeFilter";
            this.conTypeFilter.Size = new System.Drawing.Size(159, 26);
            this.conTypeFilter.TabIndex = 1;
            this.conTypeFilter.SelectedIndexChanged += new System.EventHandler(this.conTypeFilter_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Find By";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ctrlPersonCardcs1
            // 
            this.ctrlPersonCardcs1.Location = new System.Drawing.Point(3, 87);
            this.ctrlPersonCardcs1.Name = "ctrlPersonCardcs1";
            this.ctrlPersonCardcs1.Size = new System.Drawing.Size(814, 251);
            this.ctrlPersonCardcs1.TabIndex = 2;
            // 
            // ctrlPersonCardcs2
            // 
            this.ctrlPersonCardcs2.Location = new System.Drawing.Point(3, 87);
            this.ctrlPersonCardcs2.Name = "ctrlPersonCardcs2";
            this.ctrlPersonCardcs2.Size = new System.Drawing.Size(814, 240);
            this.ctrlPersonCardcs2.TabIndex = 2;
            this.ctrlPersonCardcs2.Load += new System.EventHandler(this.ctrlPersonCardcs2_Load);
            // 
            // CtrlPersonCardWithFiltere
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrlPersonCardcs2);
            this.Controls.Add(this.gbFilter);
            this.Name = "CtrlPersonCardWithFiltere";
            this.Size = new System.Drawing.Size(820, 343);
            this.Load += new System.EventHandler(this.CtrlPersonCardWithFiltere_Load);
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbFilter;
        private System.Windows.Forms.Button btAddnewperson;
        private System.Windows.Forms.Button btFind;
        private System.Windows.Forms.TextBox tebFilter;
        private System.Windows.Forms.ComboBox conTypeFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private ctrlPersonCardcs ctrlPersonCardcs1;
        private ctrlPersonCardcs ctrlPersonCardcs2;
    }
}
