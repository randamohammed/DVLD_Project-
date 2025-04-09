namespace DVLDSluotion
{
    partial class frmLastTestType
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
            this.label2 = new System.Windows.Forms.Label();
            this.lbRecorde = new System.Windows.Forms.Label();
            this.dvTestType = new System.Windows.Forms.DataGridView();
            this.cmTestType = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.edtitTestTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btClose = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dvTestType)).BeginInit();
            this.cmTestType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(175, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Manage Test Types";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(31, 531);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "# Recorde:";
            // 
            // lbRecorde
            // 
            this.lbRecorde.AutoSize = true;
            this.lbRecorde.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRecorde.Location = new System.Drawing.Point(140, 531);
            this.lbRecorde.Name = "lbRecorde";
            this.lbRecorde.Size = new System.Drawing.Size(40, 24);
            this.lbRecorde.TabIndex = 3;
            this.lbRecorde.Text = "???";
            // 
            // dvTestType
            // 
            this.dvTestType.AllowUserToAddRows = false;
            this.dvTestType.AllowUserToDeleteRows = false;
            this.dvTestType.AllowUserToOrderColumns = true;
            this.dvTestType.BackgroundColor = System.Drawing.Color.White;
            this.dvTestType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvTestType.ContextMenuStrip = this.cmTestType;
            this.dvTestType.Location = new System.Drawing.Point(12, 191);
            this.dvTestType.Name = "dvTestType";
            this.dvTestType.ReadOnly = true;
            this.dvTestType.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dvTestType.Size = new System.Drawing.Size(668, 330);
            this.dvTestType.TabIndex = 5;
            // 
            // cmTestType
            // 
            this.cmTestType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmTestType.ImageScalingSize = new System.Drawing.Size(36, 36);
            this.cmTestType.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.edtitTestTypeToolStripMenuItem});
            this.cmTestType.Name = "cmTestType";
            this.cmTestType.Size = new System.Drawing.Size(205, 46);
            // 
            // edtitTestTypeToolStripMenuItem
            // 
            this.edtitTestTypeToolStripMenuItem.Image = global::DVLDSluotion.Properties.Resources.edit_32;
            this.edtitTestTypeToolStripMenuItem.Name = "edtitTestTypeToolStripMenuItem";
            this.edtitTestTypeToolStripMenuItem.Size = new System.Drawing.Size(204, 42);
            this.edtitTestTypeToolStripMenuItem.Text = "Edtit Test Type";
            this.edtitTestTypeToolStripMenuItem.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.edtitTestTypeToolStripMenuItem.Click += new System.EventHandler(this.edtitTestTypeToolStripMenuItem_Click);
            // 
            // btClose
            // 
            this.btClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btClose.Image = global::DVLDSluotion.Properties.Resources.cross_32;
            this.btClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btClose.Location = new System.Drawing.Point(569, 531);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(98, 33);
            this.btClose.TabIndex = 4;
            this.btClose.Text = "Close";
            this.btClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLDSluotion.Properties.Resources.TestType_512;
            this.pictureBox1.Location = new System.Drawing.Point(225, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(139, 128);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // frmLastTestType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(692, 584);
            this.Controls.Add(this.dvTestType);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.lbRecorde);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmLastTestType";
            this.Text = "frmLastTestType";
            this.Load += new System.EventHandler(this.frmLastTestType_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvTestType)).EndInit();
            this.cmTestType.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbRecorde;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.DataGridView dvTestType;
        private System.Windows.Forms.ContextMenuStrip cmTestType;
        private System.Windows.Forms.ToolStripMenuItem edtitTestTypeToolStripMenuItem;
    }
}