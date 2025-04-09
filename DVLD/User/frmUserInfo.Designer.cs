namespace DVLDSluotion
{
    partial class frmUserInfo
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
            this.ctrUserCard1 = new DVLDSluotion.ctrUserCard();
            this.btClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrUserCard1
            // 
            this.ctrUserCard1.Location = new System.Drawing.Point(-2, 33);
            this.ctrUserCard1.Name = "ctrUserCard1";
            this.ctrUserCard1.Size = new System.Drawing.Size(817, 339);
            this.ctrUserCard1.TabIndex = 0;
            // 
            // btClose
            // 
            this.btClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btClose.Image = global::DVLDSluotion.Properties.Resources.cross_32;
            this.btClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btClose.Location = new System.Drawing.Point(700, 354);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(86, 33);
            this.btClose.TabIndex = 1;
            this.btClose.Text = "Close";
            this.btClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // frmUserInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 399);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.ctrUserCard1);
            this.MaximizeBox = false;
            this.Name = "frmUserInfo";
            this.Text = "User Info";
            this.Load += new System.EventHandler(this.frmUserInfo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrUserCard ctrUserCard1;
        private System.Windows.Forms.Button btClose;
    }
}