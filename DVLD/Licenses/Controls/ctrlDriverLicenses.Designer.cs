namespace DVLDSluotion.Licenses.Controls
{
    partial class ctrlDriverLicenses
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
            this.gbDriverLicenses = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbLocalLicenes = new System.Windows.Forms.TabPage();
            this.lbLocalRecorde = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgLocalDriverLicenesHisory = new System.Windows.Forms.DataGridView();
            this.cmsDriverLocalLiicenesHistory = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showLicenesInfoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tbInternationalLicenses = new System.Windows.Forms.TabPage();
            this.lbinternationalRecorde = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dgInternationalLicenses = new System.Windows.Forms.DataGridView();
            this.cmsInternationalLicenesHistory = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showLicenesInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbDriverLicenses.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tbLocalLicenes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgLocalDriverLicenesHisory)).BeginInit();
            this.cmsDriverLocalLiicenesHistory.SuspendLayout();
            this.tbInternationalLicenses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgInternationalLicenses)).BeginInit();
            this.cmsInternationalLicenesHistory.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbDriverLicenses
            // 
            this.gbDriverLicenses.Controls.Add(this.tabControl1);
            this.gbDriverLicenses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbDriverLicenses.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDriverLicenses.Location = new System.Drawing.Point(3, 3);
            this.gbDriverLicenses.Name = "gbDriverLicenses";
            this.gbDriverLicenses.Size = new System.Drawing.Size(1050, 297);
            this.gbDriverLicenses.TabIndex = 0;
            this.gbDriverLicenses.TabStop = false;
            this.gbDriverLicenses.Text = "Driver Licenses";
            this.gbDriverLicenses.Enter += new System.EventHandler(this.gbDriverLicenses_Enter);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbLocalLicenes);
            this.tabControl1.Controls.Add(this.tbInternationalLicenses);
            this.tabControl1.Location = new System.Drawing.Point(6, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1027, 273);
            this.tabControl1.TabIndex = 0;
            // 
            // tbLocalLicenes
            // 
            this.tbLocalLicenes.Controls.Add(this.lbLocalRecorde);
            this.tbLocalLicenes.Controls.Add(this.label2);
            this.tbLocalLicenes.Controls.Add(this.label1);
            this.tbLocalLicenes.Controls.Add(this.dgLocalDriverLicenesHisory);
            this.tbLocalLicenes.Location = new System.Drawing.Point(4, 29);
            this.tbLocalLicenes.Name = "tbLocalLicenes";
            this.tbLocalLicenes.Padding = new System.Windows.Forms.Padding(3);
            this.tbLocalLicenes.Size = new System.Drawing.Size(1019, 240);
            this.tbLocalLicenes.TabIndex = 0;
            this.tbLocalLicenes.Text = "Local";
            this.tbLocalLicenes.UseVisualStyleBackColor = true;
            this.tbLocalLicenes.Click += new System.EventHandler(this.tbLocalLicenes_Click);
            // 
            // lbLocalRecorde
            // 
            this.lbLocalRecorde.AutoSize = true;
            this.lbLocalRecorde.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLocalRecorde.Location = new System.Drawing.Point(112, 206);
            this.lbLocalRecorde.Name = "lbLocalRecorde";
            this.lbLocalRecorde.Size = new System.Drawing.Size(39, 20);
            this.lbLocalRecorde.TabIndex = 3;
            this.lbLocalRecorde.Text = "???";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 206);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "# Recorde:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Local Licenes History:";
            // 
            // dgLocalDriverLicenesHisory
            // 
            this.dgLocalDriverLicenesHisory.AllowUserToAddRows = false;
            this.dgLocalDriverLicenesHisory.AllowUserToDeleteRows = false;
            this.dgLocalDriverLicenesHisory.AllowUserToOrderColumns = true;
            this.dgLocalDriverLicenesHisory.BackgroundColor = System.Drawing.Color.White;
            this.dgLocalDriverLicenesHisory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgLocalDriverLicenesHisory.ContextMenuStrip = this.cmsDriverLocalLiicenesHistory;
            this.dgLocalDriverLicenesHisory.Location = new System.Drawing.Point(6, 37);
            this.dgLocalDriverLicenesHisory.Name = "dgLocalDriverLicenesHisory";
            this.dgLocalDriverLicenesHisory.ReadOnly = true;
            this.dgLocalDriverLicenesHisory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgLocalDriverLicenesHisory.Size = new System.Drawing.Size(1007, 163);
            this.dgLocalDriverLicenesHisory.TabIndex = 0;
            this.dgLocalDriverLicenesHisory.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgLocalDriverLicenesHisory_CellContentClick);
            // 
            // cmsDriverLocalLiicenesHistory
            // 
            this.cmsDriverLocalLiicenesHistory.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsDriverLocalLiicenesHistory.ImageScalingSize = new System.Drawing.Size(33, 33);
            this.cmsDriverLocalLiicenesHistory.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showLicenesInfoToolStripMenuItem1});
            this.cmsDriverLocalLiicenesHistory.Name = "cmsDriverLocalLiicenesHistory";
            this.cmsDriverLocalLiicenesHistory.Size = new System.Drawing.Size(214, 44);
            // 
            // showLicenesInfoToolStripMenuItem1
            // 
            this.showLicenesInfoToolStripMenuItem1.Image = global::DVLDSluotion.Properties.Resources.License_View_32;
            this.showLicenesInfoToolStripMenuItem1.Name = "showLicenesInfoToolStripMenuItem1";
            this.showLicenesInfoToolStripMenuItem1.Size = new System.Drawing.Size(213, 40);
            this.showLicenesInfoToolStripMenuItem1.Text = "Show Licenes Info";
            // 
            // tbInternationalLicenses
            // 
            this.tbInternationalLicenses.Controls.Add(this.lbinternationalRecorde);
            this.tbInternationalLicenses.Controls.Add(this.label5);
            this.tbInternationalLicenses.Controls.Add(this.label6);
            this.tbInternationalLicenses.Controls.Add(this.dgInternationalLicenses);
            this.tbInternationalLicenses.Location = new System.Drawing.Point(4, 29);
            this.tbInternationalLicenses.Name = "tbInternationalLicenses";
            this.tbInternationalLicenses.Padding = new System.Windows.Forms.Padding(3);
            this.tbInternationalLicenses.Size = new System.Drawing.Size(1019, 240);
            this.tbInternationalLicenses.TabIndex = 1;
            this.tbInternationalLicenses.Text = "International";
            this.tbInternationalLicenses.UseVisualStyleBackColor = true;
            this.tbInternationalLicenses.Click += new System.EventHandler(this.tbInternationalLicenses_Click);
            // 
            // lbinternationalRecorde
            // 
            this.lbinternationalRecorde.AutoSize = true;
            this.lbinternationalRecorde.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbinternationalRecorde.Location = new System.Drawing.Point(119, 206);
            this.lbinternationalRecorde.Name = "lbinternationalRecorde";
            this.lbinternationalRecorde.Size = new System.Drawing.Size(39, 20);
            this.lbinternationalRecorde.TabIndex = 7;
            this.lbinternationalRecorde.Text = "???";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 206);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "# Recorde:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(23, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(259, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "tInternational Licenses History:";
            // 
            // dgInternationalLicenses
            // 
            this.dgInternationalLicenses.AllowUserToAddRows = false;
            this.dgInternationalLicenses.AllowUserToDeleteRows = false;
            this.dgInternationalLicenses.AllowUserToOrderColumns = true;
            this.dgInternationalLicenses.BackgroundColor = System.Drawing.Color.White;
            this.dgInternationalLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgInternationalLicenses.ContextMenuStrip = this.cmsInternationalLicenesHistory;
            this.dgInternationalLicenses.Location = new System.Drawing.Point(13, 37);
            this.dgInternationalLicenses.Name = "dgInternationalLicenses";
            this.dgInternationalLicenses.ReadOnly = true;
            this.dgInternationalLicenses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgInternationalLicenses.Size = new System.Drawing.Size(1000, 163);
            this.dgInternationalLicenses.TabIndex = 4;
            // 
            // cmsInternationalLicenesHistory
            // 
            this.cmsInternationalLicenesHistory.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsInternationalLicenesHistory.ImageScalingSize = new System.Drawing.Size(33, 33);
            this.cmsInternationalLicenesHistory.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showLicenesInfoToolStripMenuItem});
            this.cmsInternationalLicenesHistory.Name = "cmsInternationalLicenesHistory";
            this.cmsInternationalLicenesHistory.Size = new System.Drawing.Size(214, 44);
            // 
            // showLicenesInfoToolStripMenuItem
            // 
            this.showLicenesInfoToolStripMenuItem.Image = global::DVLDSluotion.Properties.Resources.License_View_32;
            this.showLicenesInfoToolStripMenuItem.Name = "showLicenesInfoToolStripMenuItem";
            this.showLicenesInfoToolStripMenuItem.Size = new System.Drawing.Size(213, 40);
            this.showLicenesInfoToolStripMenuItem.Text = "Show Licenes info";
            // 
            // ctrlDriverLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gbDriverLicenses);
            this.Name = "ctrlDriverLicenses";
            this.Size = new System.Drawing.Size(1056, 303);
            this.Load += new System.EventHandler(this.ctrlDriverLicenses_Load);
            this.gbDriverLicenses.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tbLocalLicenes.ResumeLayout(false);
            this.tbLocalLicenes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgLocalDriverLicenesHisory)).EndInit();
            this.cmsDriverLocalLiicenesHistory.ResumeLayout(false);
            this.tbInternationalLicenses.ResumeLayout(false);
            this.tbInternationalLicenses.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgInternationalLicenses)).EndInit();
            this.cmsInternationalLicenesHistory.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDriverLicenses;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbLocalLicenes;
        private System.Windows.Forms.TabPage tbInternationalLicenses;
        private System.Windows.Forms.Label lbLocalRecorde;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgLocalDriverLicenesHisory;
        private System.Windows.Forms.Label lbinternationalRecorde;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgInternationalLicenses;
        private System.Windows.Forms.ContextMenuStrip cmsDriverLocalLiicenesHistory;
        private System.Windows.Forms.ToolStripMenuItem showLicenesInfoToolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip cmsInternationalLicenesHistory;
        private System.Windows.Forms.ToolStripMenuItem showLicenesInfoToolStripMenuItem;
    }
}
