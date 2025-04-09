namespace DVLDSluotion
{
    partial class frmLastApplicationType
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
            this.dvApplicationTypes = new System.Windows.Forms.DataGridView();
            this.cmApplicationType = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editAppplicationTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.lbRecorde = new System.Windows.Forms.Label();
            this.buClose = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dvApplicationTypes)).BeginInit();
            this.cmApplicationType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(174, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Application Types";
            // 
            // dvApplicationTypes
            // 
            this.dvApplicationTypes.AllowUserToAddRows = false;
            this.dvApplicationTypes.AllowUserToDeleteRows = false;
            this.dvApplicationTypes.AllowUserToOrderColumns = true;
            this.dvApplicationTypes.BackgroundColor = System.Drawing.Color.White;
            this.dvApplicationTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvApplicationTypes.ContextMenuStrip = this.cmApplicationType;
            this.dvApplicationTypes.Location = new System.Drawing.Point(12, 173);
            this.dvApplicationTypes.Name = "dvApplicationTypes";
            this.dvApplicationTypes.ReadOnly = true;
            this.dvApplicationTypes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dvApplicationTypes.Size = new System.Drawing.Size(493, 392);
            this.dvApplicationTypes.TabIndex = 2;
            // 
            // cmApplicationType
            // 
            this.cmApplicationType.ImageScalingSize = new System.Drawing.Size(36, 36);
            this.cmApplicationType.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editAppplicationTypeToolStripMenuItem});
            this.cmApplicationType.Name = "cmApplicationType";
            this.cmApplicationType.Size = new System.Drawing.Size(248, 46);
            // 
            // editAppplicationTypeToolStripMenuItem
            // 
            this.editAppplicationTypeToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editAppplicationTypeToolStripMenuItem.Image = global::DVLDSluotion.Properties.Resources.edit_32;
            this.editAppplicationTypeToolStripMenuItem.Name = "editAppplicationTypeToolStripMenuItem";
            this.editAppplicationTypeToolStripMenuItem.Size = new System.Drawing.Size(247, 42);
            this.editAppplicationTypeToolStripMenuItem.Text = "Edit Appplication Type";
            this.editAppplicationTypeToolStripMenuItem.Click += new System.EventHandler(this.editAppplicationTypeToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 580);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "# Recorde :";
            // 
            // lbRecorde
            // 
            this.lbRecorde.AutoSize = true;
            this.lbRecorde.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRecorde.Location = new System.Drawing.Point(123, 580);
            this.lbRecorde.Name = "lbRecorde";
            this.lbRecorde.Size = new System.Drawing.Size(32, 24);
            this.lbRecorde.TabIndex = 5;
            this.lbRecorde.Text = "??";
            // 
            // buClose
            // 
            this.buClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buClose.Image = global::DVLDSluotion.Properties.Resources.cross_32;
            this.buClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buClose.Location = new System.Drawing.Point(395, 572);
            this.buClose.Name = "buClose";
            this.buClose.Size = new System.Drawing.Size(98, 40);
            this.buClose.TabIndex = 3;
            this.buClose.Text = "Close";
            this.buClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buClose.UseVisualStyleBackColor = true;
            this.buClose.Click += new System.EventHandler(this.buClose_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLDSluotion.Properties.Resources.Application_Types_512;
            this.pictureBox1.Location = new System.Drawing.Point(178, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(147, 118);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // frmLastApplicationType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(517, 624);
            this.Controls.Add(this.lbRecorde);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buClose);
            this.Controls.Add(this.dvApplicationTypes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLastApplicationType";
            this.Text = "Last Application Type";
            this.Load += new System.EventHandler(this.frmLastApplicationType_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvApplicationTypes)).EndInit();
            this.cmApplicationType.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dvApplicationTypes;
        private System.Windows.Forms.Button buClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbRecorde;
        private System.Windows.Forms.ContextMenuStrip cmApplicationType;
        private System.Windows.Forms.ToolStripMenuItem editAppplicationTypeToolStripMenuItem;
    }
}