namespace DVLDSluotion
{
    partial class frmFindPerson
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
            this.butClose = new System.Windows.Forms.Button();
            this.ctrlPersonCardWithFiltere1 = new DVLDSluotion.CtrlPersonCardWithFiltere();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(339, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Find Person";
            // 
            // butClose
            // 
            this.butClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butClose.Image = global::DVLDSluotion.Properties.Resources.cross_32;
            this.butClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butClose.Location = new System.Drawing.Point(692, 382);
            this.butClose.Name = "butClose";
            this.butClose.Size = new System.Drawing.Size(103, 37);
            this.butClose.TabIndex = 2;
            this.butClose.Text = "   Close";
            this.butClose.UseVisualStyleBackColor = true;
            this.butClose.Click += new System.EventHandler(this.butClose_Click);
            // 
            // ctrlPersonCardWithFiltere1
            // 
            this.ctrlPersonCardWithFiltere1.FilterEnable = true;
            this.ctrlPersonCardWithFiltere1.Location = new System.Drawing.Point(3, 48);
            this.ctrlPersonCardWithFiltere1.Name = "ctrlPersonCardWithFiltere1";
            this.ctrlPersonCardWithFiltere1.Size = new System.Drawing.Size(820, 328);
            this.ctrlPersonCardWithFiltere1.TabIndex = 3;
            this.ctrlPersonCardWithFiltere1.TexFulterFouce = true;
            // 
            // frmFindPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 431);
            this.Controls.Add(this.ctrlPersonCardWithFiltere1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.butClose);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFindPerson";
            this.Text = "Find Person";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button butClose;
        private CtrlPersonCardWithFiltere ctrlPersonCardWithFiltere1;
    }
}