namespace DVLDSluotion
{
    partial class frmShowPerson
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
            this.label1 = new System.Windows.Forms.Label();
            this.btClose = new System.Windows.Forms.Button();
            this.ctrlPersonCardcs1 = new DVLDSluotion.ctrlPersonCardcs();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(3, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(809, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Show person";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btClose
            // 
            this.btClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btClose.Image = global::DVLDSluotion.Properties.Resources.cross_32;
            this.btClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btClose.Location = new System.Drawing.Point(703, 322);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(100, 42);
            this.btClose.TabIndex = 1;
            this.btClose.Text = "Clsoe";
            this.btClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // ctrlPersonCardcs1
            // 
            this.ctrlPersonCardcs1.Location = new System.Drawing.Point(7, 65);
            this.ctrlPersonCardcs1.Name = "ctrlPersonCardcs1";
            this.ctrlPersonCardcs1.Size = new System.Drawing.Size(814, 251);
            this.ctrlPersonCardcs1.TabIndex = 3;
            // 
            // frmShowPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 368);
            this.Controls.Add(this.ctrlPersonCardcs1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btClose);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmShowPerson";
            this.Text = "Show Person Info";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Label label1;
        private ctrlPersonCardcs ctrlPersonCardcs1;
    }
}