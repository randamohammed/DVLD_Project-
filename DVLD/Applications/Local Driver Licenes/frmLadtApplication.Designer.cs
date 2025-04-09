namespace DVLDSluotion
{
    partial class frmLadtApplication
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
            this.label3 = new System.Windows.Forms.Label();
            this.showPersonLicenesHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.issueDrivingLicenesFirstTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sechduleTestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editApplicatiionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbRecorde = new System.Windows.Forms.Label();
            this.showApplicationDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmFilter = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dvLocalDrivingLicense = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showLicenesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btClose = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btAddNewLocalLicenes = new System.Windows.Forms.Button();
            this.txtFilter = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dvLocalDrivingLicense)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(29, 545);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 24);
            this.label3.TabIndex = 33;
            this.label3.Text = "# Records:";
            // 
            // showPersonLicenesHistoryToolStripMenuItem
            // 
            this.showPersonLicenesHistoryToolStripMenuItem.Name = "showPersonLicenesHistoryToolStripMenuItem";
            this.showPersonLicenesHistoryToolStripMenuItem.Size = new System.Drawing.Size(321, 36);
            this.showPersonLicenesHistoryToolStripMenuItem.Text = "Show Person Licenes History";
            // 
            // issueDrivingLicenesFirstTimeToolStripMenuItem
            // 
            this.issueDrivingLicenesFirstTimeToolStripMenuItem.Name = "issueDrivingLicenesFirstTimeToolStripMenuItem";
            this.issueDrivingLicenesFirstTimeToolStripMenuItem.Size = new System.Drawing.Size(321, 36);
            this.issueDrivingLicenesFirstTimeToolStripMenuItem.Text = "Issue Driving Licenes (First Time)";
            // 
            // sechduleTestsToolStripMenuItem
            // 
            this.sechduleTestsToolStripMenuItem.Name = "sechduleTestsToolStripMenuItem";
            this.sechduleTestsToolStripMenuItem.Size = new System.Drawing.Size(321, 36);
            this.sechduleTestsToolStripMenuItem.Text = "Sechdule Tests";
            // 
            // cancelApplicationToolStripMenuItem
            // 
            this.cancelApplicationToolStripMenuItem.Name = "cancelApplicationToolStripMenuItem";
            this.cancelApplicationToolStripMenuItem.Size = new System.Drawing.Size(321, 36);
            this.cancelApplicationToolStripMenuItem.Text = "Cancel Application";
            // 
            // deleteApplicationToolStripMenuItem
            // 
            this.deleteApplicationToolStripMenuItem.Name = "deleteApplicationToolStripMenuItem";
            this.deleteApplicationToolStripMenuItem.Size = new System.Drawing.Size(321, 36);
            this.deleteApplicationToolStripMenuItem.Text = "Delete Application";
            // 
            // editApplicatiionToolStripMenuItem
            // 
            this.editApplicatiionToolStripMenuItem.Name = "editApplicatiionToolStripMenuItem";
            this.editApplicatiionToolStripMenuItem.Size = new System.Drawing.Size(321, 36);
            this.editApplicatiionToolStripMenuItem.Text = "Edit Applicatiion";
            // 
            // lbRecorde
            // 
            this.lbRecorde.AutoSize = true;
            this.lbRecorde.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRecorde.Location = new System.Drawing.Point(136, 549);
            this.lbRecorde.Name = "lbRecorde";
            this.lbRecorde.Size = new System.Drawing.Size(30, 24);
            this.lbRecorde.TabIndex = 34;
            this.lbRecorde.Text = "??";
            // 
            // showApplicationDetailsToolStripMenuItem
            // 
            this.showApplicationDetailsToolStripMenuItem.Name = "showApplicationDetailsToolStripMenuItem";
            this.showApplicationDetailsToolStripMenuItem.Size = new System.Drawing.Size(321, 36);
            this.showApplicationDetailsToolStripMenuItem.Text = "Show Application Details";
            // 
            // cmFilter
            // 
            this.cmFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmFilter.FormattingEnabled = true;
            this.cmFilter.Items.AddRange(new object[] {
            "None",
            "L.D.L.AppID",
            "National No.",
            "Full Name",
            "Status"});
            this.cmFilter.Location = new System.Drawing.Point(92, 200);
            this.cmFilter.Name = "cmFilter";
            this.cmFilter.Size = new System.Drawing.Size(187, 28);
            this.cmFilter.TabIndex = 26;
            this.cmFilter.SelectedIndexChanged += new System.EventHandler(this.cmFilter_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 198);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 24);
            this.label2.TabIndex = 25;
            this.label2.Text = "Find By";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(334, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(304, 24);
            this.label1.TabIndex = 22;
            this.label1.Text = "Local Driving Licenes Applicton";
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(92, 200);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(187, 28);
            this.comboBox1.TabIndex = 27;
            // 
            // dvLocalDrivingLicense
            // 
            this.dvLocalDrivingLicense.AllowUserToAddRows = false;
            this.dvLocalDrivingLicense.AllowUserToDeleteRows = false;
            this.dvLocalDrivingLicense.AllowUserToOrderColumns = true;
            this.dvLocalDrivingLicense.BackgroundColor = System.Drawing.Color.White;
            this.dvLocalDrivingLicense.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvLocalDrivingLicense.ContextMenuStrip = this.contextMenuStrip1;
            this.dvLocalDrivingLicense.Location = new System.Drawing.Point(11, 232);
            this.dvLocalDrivingLicense.Name = "dvLocalDrivingLicense";
            this.dvLocalDrivingLicense.ReadOnly = true;
            this.dvLocalDrivingLicense.Size = new System.Drawing.Size(912, 300);
            this.dvLocalDrivingLicense.TabIndex = 31;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showApplicationDetailsToolStripMenuItem,
            this.editApplicatiionToolStripMenuItem,
            this.deleteApplicationToolStripMenuItem,
            this.cancelApplicationToolStripMenuItem,
            this.sechduleTestsToolStripMenuItem,
            this.issueDrivingLicenesFirstTimeToolStripMenuItem,
            this.showLicenesToolStripMenuItem,
            this.showPersonLicenesHistoryToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(322, 292);
            // 
            // showLicenesToolStripMenuItem
            // 
            this.showLicenesToolStripMenuItem.Image = global::DVLDSluotion.Properties.Resources.License_View_32;
            this.showLicenesToolStripMenuItem.Name = "showLicenesToolStripMenuItem";
            this.showLicenesToolStripMenuItem.Size = new System.Drawing.Size(321, 36);
            this.showLicenesToolStripMenuItem.Text = "Show Licenes";
            // 
            // btClose
            // 
            this.btClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btClose.Image = global::DVLDSluotion.Properties.Resources.cross_32;
            this.btClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btClose.Location = new System.Drawing.Point(830, 538);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(93, 35);
            this.btClose.TabIndex = 32;
            this.btClose.Text = "Close";
            this.btClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btClose.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLDSluotion.Properties.Resources.Local_321;
            this.pictureBox2.Location = new System.Drawing.Point(537, 43);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(76, 54);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 24;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLDSluotion.Properties.Resources.Applications;
            this.pictureBox1.Location = new System.Drawing.Point(417, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(147, 136);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            // 
            // btAddNewLocalLicenes
            // 
            this.btAddNewLocalLicenes.BackColor = System.Drawing.Color.White;
            this.btAddNewLocalLicenes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btAddNewLocalLicenes.Image = global::DVLDSluotion.Properties.Resources.New_Application_64;
            this.btAddNewLocalLicenes.Location = new System.Drawing.Point(849, 157);
            this.btAddNewLocalLicenes.Name = "btAddNewLocalLicenes";
            this.btAddNewLocalLicenes.Size = new System.Drawing.Size(74, 71);
            this.btAddNewLocalLicenes.TabIndex = 30;
            this.btAddNewLocalLicenes.UseVisualStyleBackColor = false;
            // 
            // txtFilter
            // 
            this.txtFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilter.Location = new System.Drawing.Point(299, 198);
            this.txtFilter.Multiline = true;
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(209, 30);
            this.txtFilter.TabIndex = 35;
            this.txtFilter.Visible = false;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // frmLadtApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 608);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.lbRecorde);
            this.Controls.Add(this.cmFilter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dvLocalDrivingLicense);
            this.Controls.Add(this.btAddNewLocalLicenes);
            this.Name = "frmLadtApplication";
            this.Text = "frmLadtApplication";
            this.Load += new System.EventHandler(this.frmLadtApplication_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvLocalDrivingLicense)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.ToolStripMenuItem showPersonLicenesHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLicenesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem issueDrivingLicenesFirstTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sechduleTestsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editApplicatiionToolStripMenuItem;
        private System.Windows.Forms.Label lbRecorde;
        private System.Windows.Forms.ToolStripMenuItem showApplicationDetailsToolStripMenuItem;
        private System.Windows.Forms.ComboBox cmFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataGridView dvLocalDrivingLicense;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button btAddNewLocalLicenes;
        private System.Windows.Forms.TextBox txtFilter;
    }
}