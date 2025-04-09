namespace DVLDSluotion
{
    partial class frmLocalDriverLicenesApplicationInfo
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
            this.btClose = new System.Windows.Forms.Button();
            this.ctrlDrivingLicenseApplicationInfo1 = new DVLDSluotion.Applications.ApplicationTypes.Local_Driver_Licenes.Controls.ctrlDrivingLicenseApplicationInfo();
            this.SuspendLayout();
            // 
            // btClose
            // 
            this.btClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btClose.Image = global::DVLDSluotion.Properties.Resources.cross_32;
            this.btClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btClose.Location = new System.Drawing.Point(712, 383);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(101, 36);
            this.btClose.TabIndex = 1;
            this.btClose.Text = "Close";
            this.btClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // ctrlDrivingLicenseApplicationInfo1
            // 
            this.ctrlDrivingLicenseApplicationInfo1.Location = new System.Drawing.Point(6, 12);
            this.ctrlDrivingLicenseApplicationInfo1.Name = "ctrlDrivingLicenseApplicationInfo1";
            this.ctrlDrivingLicenseApplicationInfo1.Size = new System.Drawing.Size(847, 365);
            this.ctrlDrivingLicenseApplicationInfo1.TabIndex = 0;
            // 
            // frmLocalDriverLicenesApplicationInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(865, 429);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.ctrlDrivingLicenseApplicationInfo1);
            this.Name = "frmLocalDriverLicenesApplicationInfo";
            this.Text = "Local Driver Licenes Application Info";
            this.Load += new System.EventHandler(this.frmLocalDriverLicenesApplicationInfo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Applications.ApplicationTypes.Local_Driver_Licenes.Controls.ctrlDrivingLicenseApplicationInfo ctrlDrivingLicenseApplicationInfo1;
        private System.Windows.Forms.Button btClose;
    }
}