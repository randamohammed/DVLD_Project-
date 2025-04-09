namespace DVLDSluotion
{
    partial class ctrUserCard
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
            this.ctrlPersonCardcs1 = new DVLDSluotion.ctrlPersonCardcs();
            this.label1 = new System.Windows.Forms.Label();
            this.grUserInfromation = new System.Windows.Forms.GroupBox();
            this.lbUserID = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbUserName = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbISActive = new System.Windows.Forms.Label();
            this.grUserInfromation.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctrlPersonCardcs1
            // 
            this.ctrlPersonCardcs1.Location = new System.Drawing.Point(3, 3);
            this.ctrlPersonCardcs1.Name = "ctrlPersonCardcs1";
            this.ctrlPersonCardcs1.Size = new System.Drawing.Size(814, 251);
            this.ctrlPersonCardcs1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(97, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "User ID:";
            // 
            // grUserInfromation
            // 
            this.grUserInfromation.Controls.Add(this.lbISActive);
            this.grUserInfromation.Controls.Add(this.label5);
            this.grUserInfromation.Controls.Add(this.lbUserName);
            this.grUserInfromation.Controls.Add(this.label3);
            this.grUserInfromation.Controls.Add(this.lbUserID);
            this.grUserInfromation.Controls.Add(this.label1);
            this.grUserInfromation.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grUserInfromation.Location = new System.Drawing.Point(3, 243);
            this.grUserInfromation.Name = "grUserInfromation";
            this.grUserInfromation.Size = new System.Drawing.Size(811, 68);
            this.grUserInfromation.TabIndex = 2;
            this.grUserInfromation.TabStop = false;
            this.grUserInfromation.Text = "User Infromatoin";
            // 
            // lbUserID
            // 
            this.lbUserID.AutoSize = true;
            this.lbUserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUserID.Location = new System.Drawing.Point(179, 32);
            this.lbUserID.Name = "lbUserID";
            this.lbUserID.Size = new System.Drawing.Size(40, 24);
            this.lbUserID.TabIndex = 2;
            this.lbUserID.Text = "???";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(303, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 24);
            this.label3.TabIndex = 3;
            this.label3.Text = "User Name:";
            // 
            // lbUserName
            // 
            this.lbUserName.AutoSize = true;
            this.lbUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUserName.Location = new System.Drawing.Point(419, 32);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(40, 24);
            this.lbUserName.TabIndex = 4;
            this.lbUserName.Text = "???";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(534, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 24);
            this.label5.TabIndex = 5;
            this.label5.Text = "IS Active:";
            // 
            // lbISActive
            // 
            this.lbISActive.AutoSize = true;
            this.lbISActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbISActive.Location = new System.Drawing.Point(627, 32);
            this.lbISActive.Name = "lbISActive";
            this.lbISActive.Size = new System.Drawing.Size(40, 24);
            this.lbISActive.TabIndex = 6;
            this.lbISActive.Text = "???";
            // 
            // ctrUserCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grUserInfromation);
            this.Controls.Add(this.ctrlPersonCardcs1);
            this.Name = "ctrUserCard";
            this.Size = new System.Drawing.Size(817, 339);
            this.Load += new System.EventHandler(this.ctrUserCard_Load);
            this.grUserInfromation.ResumeLayout(false);
            this.grUserInfromation.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlPersonCardcs ctrlPersonCardcs1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grUserInfromation;
        private System.Windows.Forms.Label lbISActive;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbUserName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbUserID;
    }
}
