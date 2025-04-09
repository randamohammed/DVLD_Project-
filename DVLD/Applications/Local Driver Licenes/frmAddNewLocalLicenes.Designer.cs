namespace DVLDSluotion
{
    partial class frmAddNewLocalLicenes
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tcApplicationInfo = new System.Windows.Forms.TabControl();
            this.tpPersonInfo = new System.Windows.Forms.TabPage();
            this.btnApplicationInfoNext_ = new System.Windows.Forms.Button();
            this.ctrlPersonCardWithFiltere2 = new DVLDSluotion.CtrlPersonCardWithFiltere();
            this.tpApplicationInfo = new System.Windows.Forms.TabPage();
            this.cmLicenseClass = new System.Windows.Forms.ComboBox();
            this.lbApplicationDate = new System.Windows.Forms.Label();
            this.lbCreatedBy = new System.Windows.Forms.Label();
            this.lbApplicationFees = new System.Windows.Forms.Label();
            this.lbLocalID = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ctrlPersonCardWithFiltere1 = new DVLDSluotion.CtrlPersonCardWithFiltere();
            this.btCloase = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.lbTitle = new System.Windows.Forms.Label();
            this.tcApplicationInfo.SuspendLayout();
            this.tpPersonInfo.SuspendLayout();
            this.tpApplicationInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tcApplicationInfo
            // 
            this.tcApplicationInfo.Controls.Add(this.tpPersonInfo);
            this.tcApplicationInfo.Controls.Add(this.tpApplicationInfo);
            this.tcApplicationInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcApplicationInfo.Location = new System.Drawing.Point(12, 70);
            this.tcApplicationInfo.Name = "tcApplicationInfo";
            this.tcApplicationInfo.SelectedIndex = 0;
            this.tcApplicationInfo.Size = new System.Drawing.Size(839, 416);
            this.tcApplicationInfo.TabIndex = 0;
            // 
            // tpPersonInfo
            // 
            this.tpPersonInfo.Controls.Add(this.btnApplicationInfoNext_);
            this.tpPersonInfo.Controls.Add(this.ctrlPersonCardWithFiltere2);
            this.tpPersonInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpPersonInfo.Location = new System.Drawing.Point(4, 33);
            this.tpPersonInfo.Name = "tpPersonInfo";
            this.tpPersonInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpPersonInfo.Size = new System.Drawing.Size(831, 379);
            this.tpPersonInfo.TabIndex = 0;
            this.tpPersonInfo.Text = "Person Info";
            this.tpPersonInfo.UseVisualStyleBackColor = true;
            this.tpPersonInfo.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // btnApplicationInfoNext_
            // 
            this.btnApplicationInfoNext_.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApplicationInfoNext_.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApplicationInfoNext_.Image = global::DVLDSluotion.Properties.Resources.Next_321;
            this.btnApplicationInfoNext_.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnApplicationInfoNext_.Location = new System.Drawing.Point(732, 336);
            this.btnApplicationInfoNext_.Name = "btnApplicationInfoNext_";
            this.btnApplicationInfoNext_.Size = new System.Drawing.Size(93, 40);
            this.btnApplicationInfoNext_.TabIndex = 1;
            this.btnApplicationInfoNext_.Text = "Naxt";
            this.btnApplicationInfoNext_.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnApplicationInfoNext_.UseVisualStyleBackColor = true;
            this.btnApplicationInfoNext_.Click += new System.EventHandler(this.btnApplicationInfoNext__Click);
            // 
            // ctrlPersonCardWithFiltere2
            // 
            this.ctrlPersonCardWithFiltere2.FilterEnable = true;
            this.ctrlPersonCardWithFiltere2.Location = new System.Drawing.Point(6, 0);
            this.ctrlPersonCardWithFiltere2.Name = "ctrlPersonCardWithFiltere2";
            this.ctrlPersonCardWithFiltere2.Size = new System.Drawing.Size(820, 343);
            this.ctrlPersonCardWithFiltere2.TabIndex = 2;
            this.ctrlPersonCardWithFiltere2.TexFulterFouce = true;
            this.ctrlPersonCardWithFiltere2.OnPersonSelect += new System.Action<int>(this.ctrlPersonCardWithFiltere2_OnPersonSelect);
            // 
            // tpApplicationInfo
            // 
            this.tpApplicationInfo.Controls.Add(this.cmLicenseClass);
            this.tpApplicationInfo.Controls.Add(this.lbApplicationDate);
            this.tpApplicationInfo.Controls.Add(this.lbCreatedBy);
            this.tpApplicationInfo.Controls.Add(this.lbApplicationFees);
            this.tpApplicationInfo.Controls.Add(this.lbLocalID);
            this.tpApplicationInfo.Controls.Add(this.pictureBox5);
            this.tpApplicationInfo.Controls.Add(this.pictureBox4);
            this.tpApplicationInfo.Controls.Add(this.pictureBox3);
            this.tpApplicationInfo.Controls.Add(this.pictureBox2);
            this.tpApplicationInfo.Controls.Add(this.pictureBox1);
            this.tpApplicationInfo.Controls.Add(this.label1);
            this.tpApplicationInfo.Controls.Add(this.label2);
            this.tpApplicationInfo.Controls.Add(this.label15);
            this.tpApplicationInfo.Controls.Add(this.label5);
            this.tpApplicationInfo.Controls.Add(this.label4);
            this.tpApplicationInfo.Location = new System.Drawing.Point(4, 33);
            this.tpApplicationInfo.Name = "tpApplicationInfo";
            this.tpApplicationInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpApplicationInfo.Size = new System.Drawing.Size(831, 379);
            this.tpApplicationInfo.TabIndex = 1;
            this.tpApplicationInfo.Text = "Application Info";
            this.tpApplicationInfo.UseVisualStyleBackColor = true;
            // 
            // cmLicenseClass
            // 
            this.cmLicenseClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmLicenseClass.FormattingEnabled = true;
            this.cmLicenseClass.Location = new System.Drawing.Point(253, 149);
            this.cmLicenseClass.Name = "cmLicenseClass";
            this.cmLicenseClass.Size = new System.Drawing.Size(211, 28);
            this.cmLicenseClass.TabIndex = 157;
            this.cmLicenseClass.SelectedIndexChanged += new System.EventHandler(this.cmLicenseClass_SelectedIndexChanged);
            // 
            // lbApplicationDate
            // 
            this.lbApplicationDate.AutoSize = true;
            this.lbApplicationDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbApplicationDate.Location = new System.Drawing.Point(254, 109);
            this.lbApplicationDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbApplicationDate.Name = "lbApplicationDate";
            this.lbApplicationDate.Size = new System.Drawing.Size(129, 20);
            this.lbApplicationDate.TabIndex = 156;
            this.lbApplicationDate.Text = "[???/???/????]";
            // 
            // lbCreatedBy
            // 
            this.lbCreatedBy.AutoSize = true;
            this.lbCreatedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCreatedBy.Location = new System.Drawing.Point(254, 230);
            this.lbCreatedBy.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCreatedBy.Name = "lbCreatedBy";
            this.lbCreatedBy.Size = new System.Drawing.Size(59, 20);
            this.lbCreatedBy.TabIndex = 155;
            this.lbCreatedBy.Text = "[????]";
            // 
            // lbApplicationFees
            // 
            this.lbApplicationFees.AutoSize = true;
            this.lbApplicationFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbApplicationFees.Location = new System.Drawing.Point(254, 197);
            this.lbApplicationFees.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbApplicationFees.Name = "lbApplicationFees";
            this.lbApplicationFees.Size = new System.Drawing.Size(59, 20);
            this.lbApplicationFees.TabIndex = 154;
            this.lbApplicationFees.Text = "[????]";
            // 
            // lbLocalID
            // 
            this.lbLocalID.AutoSize = true;
            this.lbLocalID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLocalID.Location = new System.Drawing.Point(254, 71);
            this.lbLocalID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbLocalID.Name = "lbLocalID";
            this.lbLocalID.Size = new System.Drawing.Size(59, 20);
            this.lbLocalID.TabIndex = 153;
            this.lbLocalID.Text = "[????]";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::DVLDSluotion.Properties.Resources.User_32__2;
            this.pictureBox5.Location = new System.Drawing.Point(214, 223);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(33, 32);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 152;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::DVLDSluotion.Properties.Resources.money_32;
            this.pictureBox4.Location = new System.Drawing.Point(214, 185);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(33, 32);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 151;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::DVLDSluotion.Properties.Resources.License_Type_32;
            this.pictureBox3.Location = new System.Drawing.Point(214, 147);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(33, 32);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 150;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLDSluotion.Properties.Resources.calendar_month;
            this.pictureBox2.Location = new System.Drawing.Point(214, 109);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(33, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 149;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLDSluotion.Properties.Resources.Number_32;
            this.pictureBox1.Location = new System.Drawing.Point(214, 71);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(33, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 148;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(58, 223);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 20);
            this.label1.TabIndex = 147;
            this.label1.Text = "Created By:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(58, 185);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 20);
            this.label2.TabIndex = 146;
            this.label2.Text = "Application Fees:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(58, 147);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(125, 20);
            this.label15.TabIndex = 145;
            this.label15.Text = "License Class:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(58, 109);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 20);
            this.label5.TabIndex = 144;
            this.label5.Text = "Application Date:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(58, 71);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 20);
            this.label4.TabIndex = 143;
            this.label4.Text = "D.L.Application ID:";
            // 
            // ctrlPersonCardWithFiltere1
            // 
            this.ctrlPersonCardWithFiltere1.FilterEnable = true;
            this.ctrlPersonCardWithFiltere1.Location = new System.Drawing.Point(6, 6);
            this.ctrlPersonCardWithFiltere1.Name = "ctrlPersonCardWithFiltere1";
            this.ctrlPersonCardWithFiltere1.Size = new System.Drawing.Size(820, 328);
            this.ctrlPersonCardWithFiltere1.TabIndex = 0;
            this.ctrlPersonCardWithFiltere1.TexFulterFouce = true;
            this.ctrlPersonCardWithFiltere1.OnPersonSelect += new System.Action<int>(this.ctrlPersonCardWithFiltere1_OnPersonSelect);
            // 
            // btCloase
            // 
            this.btCloase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCloase.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCloase.Image = global::DVLDSluotion.Properties.Resources.cross_32;
            this.btCloase.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCloase.Location = new System.Drawing.Point(518, 508);
            this.btCloase.Name = "btCloase";
            this.btCloase.Size = new System.Drawing.Size(93, 40);
            this.btCloase.TabIndex = 3;
            this.btCloase.Text = "Close";
            this.btCloase.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCloase.UseVisualStyleBackColor = true;
            this.btCloase.Click += new System.EventHandler(this.btCloase_Click);
            // 
            // btSave
            // 
            this.btSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSave.Image = global::DVLDSluotion.Properties.Resources.Save_32;
            this.btSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btSave.Location = new System.Drawing.Point(754, 508);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(93, 40);
            this.btSave.TabIndex = 2;
            this.btSave.Text = "Save";
            this.btSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.Red;
            this.lbTitle.Location = new System.Drawing.Point(349, 39);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(139, 24);
            this.lbTitle.TabIndex = 4;
            this.lbTitle.Text = "Add New Local";
            // 
            // frmAddNewLocalLicenes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(863, 575);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.btCloase);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.tcApplicationInfo);
            this.Name = "frmAddNewLocalLicenes";
            this.Text = "frmAddNewLocalLicenes";
            this.Activated += new System.EventHandler(this.frmAddNewLocalLicenes_Activated);
            this.Load += new System.EventHandler(this.frmAddNewLocalLicenes_Load);
            this.tcApplicationInfo.ResumeLayout(false);
            this.tpPersonInfo.ResumeLayout(false);
            this.tpApplicationInfo.ResumeLayout(false);
            this.tpApplicationInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tcApplicationInfo;
        private System.Windows.Forms.TabPage tpPersonInfo;
        private System.Windows.Forms.Button btnApplicationInfoNext_;
        private CtrlPersonCardWithFiltere ctrlPersonCardWithFiltere1;
        private System.Windows.Forms.TabPage tpApplicationInfo;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Button btCloase;
        private System.Windows.Forms.Label lbCreatedBy;
        private System.Windows.Forms.Label lbApplicationFees;
        private System.Windows.Forms.Label lbLocalID;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmLicenseClass;
        private System.Windows.Forms.Label lbApplicationDate;
        private System.Windows.Forms.Label lbTitle;
        private CtrlPersonCardWithFiltere ctrlPersonCardWithFiltere2;
    }
}