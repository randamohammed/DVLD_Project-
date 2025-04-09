namespace DVLDSluotion.Drivers
{
    partial class frmListDrivers
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
            this.dgDriver = new System.Windows.Forms.DataGridView();
            this.cmsDrivers = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showPersonInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLicenesHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.txtValuesFilter = new System.Windows.Forms.TextBox();
            this.cmFilter = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbRecorde = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btclose = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgDriver)).BeginInit();
            this.cmsDrivers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(498, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Manage Drver";
            // 
            // dgDriver
            // 
            this.dgDriver.AllowUserToAddRows = false;
            this.dgDriver.AllowUserToDeleteRows = false;
            this.dgDriver.AllowUserToOrderColumns = true;
            this.dgDriver.BackgroundColor = System.Drawing.Color.White;
            this.dgDriver.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDriver.ContextMenuStrip = this.cmsDrivers;
            this.dgDriver.Location = new System.Drawing.Point(11, 258);
            this.dgDriver.Name = "dgDriver";
            this.dgDriver.ReadOnly = true;
            this.dgDriver.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgDriver.Size = new System.Drawing.Size(1020, 259);
            this.dgDriver.TabIndex = 2;
            // 
            // cmsDrivers
            // 
            this.cmsDrivers.ImageScalingSize = new System.Drawing.Size(33, 33);
            this.cmsDrivers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showPersonInfoToolStripMenuItem,
            this.showLicenesHistoryToolStripMenuItem});
            this.cmsDrivers.Name = "cmsDrivers";
            this.cmsDrivers.Size = new System.Drawing.Size(204, 106);
            // 
            // showPersonInfoToolStripMenuItem
            // 
            this.showPersonInfoToolStripMenuItem.Image = global::DVLDSluotion.Properties.Resources.PersonDetails_32;
            this.showPersonInfoToolStripMenuItem.Name = "showPersonInfoToolStripMenuItem";
            this.showPersonInfoToolStripMenuItem.Size = new System.Drawing.Size(203, 40);
            this.showPersonInfoToolStripMenuItem.Text = "Show Person Info";
            this.showPersonInfoToolStripMenuItem.Click += new System.EventHandler(this.showPersonInfoToolStripMenuItem_Click);
            // 
            // showLicenesHistoryToolStripMenuItem
            // 
            this.showLicenesHistoryToolStripMenuItem.Image = global::DVLDSluotion.Properties.Resources.PersonLicenseHistory_32;
            this.showLicenesHistoryToolStripMenuItem.Name = "showLicenesHistoryToolStripMenuItem";
            this.showLicenesHistoryToolStripMenuItem.Size = new System.Drawing.Size(203, 40);
            this.showLicenesHistoryToolStripMenuItem.Text = "Show Licenes History";
            this.showLicenesHistoryToolStripMenuItem.Click += new System.EventHandler(this.showLicenesHistoryToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 217);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Find By";
            // 
            // txtValuesFilter
            // 
            this.txtValuesFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValuesFilter.Location = new System.Drawing.Point(288, 220);
            this.txtValuesFilter.Name = "txtValuesFilter";
            this.txtValuesFilter.Size = new System.Drawing.Size(237, 24);
            this.txtValuesFilter.TabIndex = 4;
            this.txtValuesFilter.TextChanged += new System.EventHandler(this.txtValuesFilter_TextChanged);
            this.txtValuesFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValuesFilter_KeyPress);
            this.txtValuesFilter.Validating += new System.ComponentModel.CancelEventHandler(this.txtValuesFilter_Validating);
            // 
            // cmFilter
            // 
            this.cmFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmFilter.FormattingEnabled = true;
            this.cmFilter.Items.AddRange(new object[] {
            "None",
            "Driver ID",
            "Person ID",
            "National No.",
            "Full Name"});
            this.cmFilter.Location = new System.Drawing.Point(91, 219);
            this.cmFilter.Name = "cmFilter";
            this.cmFilter.Size = new System.Drawing.Size(176, 26);
            this.cmFilter.TabIndex = 5;
            this.cmFilter.SelectedIndexChanged += new System.EventHandler(this.cmFilter_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 536);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 18);
            this.label3.TabIndex = 7;
            this.label3.Text = "# Recorde:";
            // 
            // lbRecorde
            // 
            this.lbRecorde.AutoSize = true;
            this.lbRecorde.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRecorde.Location = new System.Drawing.Point(107, 537);
            this.lbRecorde.Name = "lbRecorde";
            this.lbRecorde.Size = new System.Drawing.Size(35, 18);
            this.lbRecorde.TabIndex = 8;
            this.lbRecorde.Text = "???";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btclose
            // 
            this.btclose.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btclose.Image = global::DVLDSluotion.Properties.Resources.cross_32;
            this.btclose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btclose.Location = new System.Drawing.Point(908, 526);
            this.btclose.Name = "btclose";
            this.btclose.Size = new System.Drawing.Size(123, 37);
            this.btclose.TabIndex = 6;
            this.btclose.Text = "Close";
            this.btclose.UseVisualStyleBackColor = true;
            this.btclose.Click += new System.EventHandler(this.btclose_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLDSluotion.Properties.Resources.Driver_Main;
            this.pictureBox1.Location = new System.Drawing.Point(490, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(168, 158);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // frmListDrivers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1043, 585);
            this.Controls.Add(this.lbRecorde);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btclose);
            this.Controls.Add(this.cmFilter);
            this.Controls.Add(this.txtValuesFilter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgDriver);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmListDrivers";
            this.Text = "frmListDrivers";
            this.Load += new System.EventHandler(this.frmListDrivers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgDriver)).EndInit();
            this.cmsDrivers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgDriver;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtValuesFilter;
        private System.Windows.Forms.ComboBox cmFilter;
        private System.Windows.Forms.Button btclose;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbRecorde;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ContextMenuStrip cmsDrivers;
        private System.Windows.Forms.ToolStripMenuItem showPersonInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLicenesHistoryToolStripMenuItem;
    }
}