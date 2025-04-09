namespace DVLDSluotion.Applications.Rlease_Detained_License
{
    partial class frmListDetainedLicenses
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.dgListdetainedLicense = new System.Windows.Forms.DataGridView();
            this.cmsApplications = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showPersonDetailesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLicenseDetailesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showPersonLicenseHiistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.releaseDetainedLicenesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.lbRecordes = new System.Windows.Forms.Label();
            this.cmFindBy = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFiltervaiues = new System.Windows.Forms.TextBox();
            this.cmIsRelease = new System.Windows.Forms.ComboBox();
            this.btDetaintLicense = new System.Windows.Forms.Button();
            this.btReleaseLicense = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgListdetainedLicense)).BeginInit();
            this.cmsApplications.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(571, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "List Detained Licenses";
            // 
            // dgListdetainedLicense
            // 
            this.dgListdetainedLicense.AllowUserToAddRows = false;
            this.dgListdetainedLicense.AllowUserToDeleteRows = false;
            this.dgListdetainedLicense.AllowUserToOrderColumns = true;
            this.dgListdetainedLicense.BackgroundColor = System.Drawing.Color.White;
            this.dgListdetainedLicense.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgListdetainedLicense.ContextMenuStrip = this.cmsApplications;
            this.dgListdetainedLicense.Location = new System.Drawing.Point(12, 247);
            this.dgListdetainedLicense.Name = "dgListdetainedLicense";
            this.dgListdetainedLicense.ReadOnly = true;
            this.dgListdetainedLicense.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgListdetainedLicense.Size = new System.Drawing.Size(1187, 336);
            this.dgListdetainedLicense.TabIndex = 2;
            // 
            // cmsApplications
            // 
            this.cmsApplications.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsApplications.ImageScalingSize = new System.Drawing.Size(33, 33);
            this.cmsApplications.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showPersonDetailesToolStripMenuItem,
            this.showLicenseDetailesToolStripMenuItem,
            this.showPersonLicenseHiistoryToolStripMenuItem,
            this.releaseDetainedLicenesToolStripMenuItem});
            this.cmsApplications.Name = "cmsApplications";
            this.cmsApplications.Size = new System.Drawing.Size(301, 164);
            this.cmsApplications.Opening += new System.ComponentModel.CancelEventHandler(this.cmsApplications_Opening);
            // 
            // showPersonDetailesToolStripMenuItem
            // 
            this.showPersonDetailesToolStripMenuItem.Image = global::DVLDSluotion.Properties.Resources.PersonDetails_32;
            this.showPersonDetailesToolStripMenuItem.Name = "showPersonDetailesToolStripMenuItem";
            this.showPersonDetailesToolStripMenuItem.Size = new System.Drawing.Size(300, 40);
            this.showPersonDetailesToolStripMenuItem.Text = "Show Person Detailes";
            this.showPersonDetailesToolStripMenuItem.Click += new System.EventHandler(this.showPersonDetailesToolStripMenuItem_Click);
            // 
            // showLicenseDetailesToolStripMenuItem
            // 
            this.showLicenseDetailesToolStripMenuItem.Image = global::DVLDSluotion.Properties.Resources.License_View_32;
            this.showLicenseDetailesToolStripMenuItem.Name = "showLicenseDetailesToolStripMenuItem";
            this.showLicenseDetailesToolStripMenuItem.Size = new System.Drawing.Size(300, 40);
            this.showLicenseDetailesToolStripMenuItem.Text = "Show License Detailes";
            this.showLicenseDetailesToolStripMenuItem.Click += new System.EventHandler(this.showLicenseDetailesToolStripMenuItem_Click);
            // 
            // showPersonLicenseHiistoryToolStripMenuItem
            // 
            this.showPersonLicenseHiistoryToolStripMenuItem.Image = global::DVLDSluotion.Properties.Resources.PersonLicenseHistory_32;
            this.showPersonLicenseHiistoryToolStripMenuItem.Name = "showPersonLicenseHiistoryToolStripMenuItem";
            this.showPersonLicenseHiistoryToolStripMenuItem.Size = new System.Drawing.Size(300, 40);
            this.showPersonLicenseHiistoryToolStripMenuItem.Text = "Show Person License Hiistory";
            this.showPersonLicenseHiistoryToolStripMenuItem.Click += new System.EventHandler(this.showPersonLicenseHiistoryToolStripMenuItem_Click);
            // 
            // releaseDetainedLicenesToolStripMenuItem
            // 
            this.releaseDetainedLicenesToolStripMenuItem.Image = global::DVLDSluotion.Properties.Resources.Release_Detained_License_32;
            this.releaseDetainedLicenesToolStripMenuItem.Name = "releaseDetainedLicenesToolStripMenuItem";
            this.releaseDetainedLicenesToolStripMenuItem.Size = new System.Drawing.Size(300, 40);
            this.releaseDetainedLicenesToolStripMenuItem.Text = "Release Detained Licenes";
            this.releaseDetainedLicenesToolStripMenuItem.Click += new System.EventHandler(this.releaseDetainedLicenesToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(58, 593);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "# Recordes:";
            // 
            // lbRecordes
            // 
            this.lbRecordes.AutoSize = true;
            this.lbRecordes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRecordes.Location = new System.Drawing.Point(176, 593);
            this.lbRecordes.Name = "lbRecordes";
            this.lbRecordes.Size = new System.Drawing.Size(50, 24);
            this.lbRecordes.TabIndex = 5;
            this.lbRecordes.Text = "[???]";
            // 
            // cmFindBy
            // 
            this.cmFindBy.BackColor = System.Drawing.Color.Silver;
            this.cmFindBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmFindBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmFindBy.FormattingEnabled = true;
            this.cmFindBy.Items.AddRange(new object[] {
            "None",
            "Detain ID",
            "IS Released",
            "National No",
            "Full Name",
            "Release application ID"});
            this.cmFindBy.Location = new System.Drawing.Point(101, 215);
            this.cmFindBy.Name = "cmFindBy";
            this.cmFindBy.Size = new System.Drawing.Size(223, 26);
            this.cmFindBy.TabIndex = 8;
            this.cmFindBy.SelectedIndexChanged += new System.EventHandler(this.cmFindBy_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 220);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 24);
            this.label3.TabIndex = 9;
            this.label3.Text = "Find By";
            // 
            // txtFiltervaiues
            // 
            this.txtFiltervaiues.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiltervaiues.Location = new System.Drawing.Point(331, 216);
            this.txtFiltervaiues.Name = "txtFiltervaiues";
            this.txtFiltervaiues.Size = new System.Drawing.Size(219, 24);
            this.txtFiltervaiues.TabIndex = 10;
            this.txtFiltervaiues.Visible = false;
            this.txtFiltervaiues.TextChanged += new System.EventHandler(this.txtFiltervaiues_TextChanged);
            // 
            // cmIsRelease
            // 
            this.cmIsRelease.BackColor = System.Drawing.Color.Silver;
            this.cmIsRelease.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmIsRelease.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmIsRelease.FormattingEnabled = true;
            this.cmIsRelease.Items.AddRange(new object[] {
            "All",
            "Yes",
            "No"});
            this.cmIsRelease.Location = new System.Drawing.Point(330, 214);
            this.cmIsRelease.Name = "cmIsRelease";
            this.cmIsRelease.Size = new System.Drawing.Size(142, 26);
            this.cmIsRelease.TabIndex = 11;
            this.cmIsRelease.Visible = false;
            this.cmIsRelease.SelectedIndexChanged += new System.EventHandler(this.cmIsRelease_SelectedIndexChanged);
            // 
            // btDetaintLicense
            // 
            this.btDetaintLicense.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btDetaintLicense.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDetaintLicense.Image = global::DVLDSluotion.Properties.Resources.Detain_64;
            this.btDetaintLicense.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btDetaintLicense.Location = new System.Drawing.Point(1108, 182);
            this.btDetaintLicense.Name = "btDetaintLicense";
            this.btDetaintLicense.Size = new System.Drawing.Size(77, 61);
            this.btDetaintLicense.TabIndex = 7;
            this.btDetaintLicense.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btDetaintLicense.UseVisualStyleBackColor = true;
            this.btDetaintLicense.Click += new System.EventHandler(this.btDetaintLicense_Click);
            // 
            // btReleaseLicense
            // 
            this.btReleaseLicense.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btReleaseLicense.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btReleaseLicense.Image = global::DVLDSluotion.Properties.Resources.Release_Detained_License_64;
            this.btReleaseLicense.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btReleaseLicense.Location = new System.Drawing.Point(1025, 182);
            this.btReleaseLicense.Name = "btReleaseLicense";
            this.btReleaseLicense.Size = new System.Drawing.Size(77, 62);
            this.btReleaseLicense.TabIndex = 6;
            this.btReleaseLicense.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btReleaseLicense.UseVisualStyleBackColor = true;
            this.btReleaseLicense.Click += new System.EventHandler(this.btReleaseLicense_Click);
            // 
            // btClose
            // 
            this.btClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btClose.Image = global::DVLDSluotion.Properties.Resources.cross_32;
            this.btClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btClose.Location = new System.Drawing.Point(1081, 588);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(104, 37);
            this.btClose.TabIndex = 4;
            this.btClose.Text = "Close";
            this.btClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLDSluotion.Properties.Resources.Detain_512;
            this.pictureBox1.Location = new System.Drawing.Point(597, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(173, 125);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // frmListDetainedLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1211, 629);
            this.Controls.Add(this.cmIsRelease);
            this.Controls.Add(this.txtFiltervaiues);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmFindBy);
            this.Controls.Add(this.btDetaintLicense);
            this.Controls.Add(this.btReleaseLicense);
            this.Controls.Add(this.lbRecordes);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgListdetainedLicense);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmListDetainedLicenses";
            this.Text = "List Detained Licenses";
            this.Load += new System.EventHandler(this.frmListDetainedLicenses_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgListdetainedLicense)).EndInit();
            this.cmsApplications.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgListdetainedLicense;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Label lbRecordes;
        private System.Windows.Forms.Button btReleaseLicense;
        private System.Windows.Forms.Button btDetaintLicense;
        private System.Windows.Forms.ComboBox cmFindBy;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFiltervaiues;
        private System.Windows.Forms.ComboBox cmIsRelease;
        private System.Windows.Forms.ContextMenuStrip cmsApplications;
        private System.Windows.Forms.ToolStripMenuItem showPersonDetailesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLicenseDetailesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showPersonLicenseHiistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem releaseDetainedLicenesToolStripMenuItem;
    }
}