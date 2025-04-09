namespace DVLDSluotion
{
    partial class frmScheduleTest
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
            this.ctrlScheduleTest2 = new DVLDSluotion.Tests.ctrlScheduleTest();
            this.ctrlScheduleTest1 = new DVLDSluotion.Tests.ctrlScheduleTest();
            this.SuspendLayout();
            // 
            // btClose
            // 
            this.btClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btClose.Image = global::DVLDSluotion.Properties.Resources.cross_32;
            this.btClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btClose.Location = new System.Drawing.Point(161, 618);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(95, 35);
            this.btClose.TabIndex = 1;
            this.btClose.Text = "Close";
            this.btClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // ctrlScheduleTest2
            // 
            this.ctrlScheduleTest2.BackColor = System.Drawing.Color.White;
            this.ctrlScheduleTest2.Location = new System.Drawing.Point(5, 8);
            this.ctrlScheduleTest2.Name = "ctrlScheduleTest2";
            this.ctrlScheduleTest2.Size = new System.Drawing.Size(551, 645);
            this.ctrlScheduleTest2.TabIndex = 2;
            this.ctrlScheduleTest2.TestTypeID = SLDVLD_Buisness.clsTestTypes.enTestType.VisionTes;
            this.ctrlScheduleTest2.Load += new System.EventHandler(this.ctrlScheduleTest2_Load);
            // 
            // ctrlScheduleTest1
            // 
            this.ctrlScheduleTest1.BackColor = System.Drawing.Color.White;
            this.ctrlScheduleTest1.Location = new System.Drawing.Point(-1, 12);
            this.ctrlScheduleTest1.Name = "ctrlScheduleTest1";
            this.ctrlScheduleTest1.Size = new System.Drawing.Size(537, 650);
            this.ctrlScheduleTest1.TabIndex = 0;
            this.ctrlScheduleTest1.TestTypeID = SLDVLD_Buisness.clsTestTypes.enTestType.VisionTes;
            // 
            // frmScheduleTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 681);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.ctrlScheduleTest2);
            this.Name = "frmScheduleTest";
            this.Text = "frmScheduleTest";
            this.Load += new System.EventHandler(this.frmScheduleTest_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Tests.ctrlScheduleTest ctrlScheduleTest1;
        private System.Windows.Forms.Button btClose;
        private Tests.ctrlScheduleTest ctrlScheduleTest2;
    }
}