namespace DVLDSluotion
{
    partial class frmLastUser
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
            this.cmFilter = new System.Windows.Forms.ComboBox();
            this.txtFilterVaaluse = new System.Windows.Forms.TextBox();
            this.dvUsers = new System.Windows.Forms.DataGridView();
            this.cmUsers = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showDetilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chanagPasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sandEmilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sandPhoneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.lbRecorde = new System.Windows.Forms.Label();
            this.cmISActive = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btClose = new System.Windows.Forms.Button();
            this.btAddNewUsers = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dvUsers)).BeginInit();
            this.cmUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(398, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Manage Last User";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // cmFilter
            // 
            this.cmFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmFilter.FormattingEnabled = true;
            this.cmFilter.Items.AddRange(new object[] {
            "None",
            "User ID",
            "Person ID",
            "User Name",
            "Full Name",
            "Is Active"});
            this.cmFilter.Location = new System.Drawing.Point(103, 165);
            this.cmFilter.Name = "cmFilter";
            this.cmFilter.Size = new System.Drawing.Size(138, 26);
            this.cmFilter.TabIndex = 2;
            this.cmFilter.SelectedIndexChanged += new System.EventHandler(this.cmFilter_SelectedIndexChanged);
            // 
            // txtFilterVaaluse
            // 
            this.txtFilterVaaluse.Location = new System.Drawing.Point(247, 162);
            this.txtFilterVaaluse.Multiline = true;
            this.txtFilterVaaluse.Name = "txtFilterVaaluse";
            this.txtFilterVaaluse.Size = new System.Drawing.Size(199, 29);
            this.txtFilterVaaluse.TabIndex = 3;
            this.txtFilterVaaluse.Visible = false;
            this.txtFilterVaaluse.TextChanged += new System.EventHandler(this.txtFilterVaaluse_TextChanged);
            this.txtFilterVaaluse.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterVaaluse_KeyPress);
            // 
            // dvUsers
            // 
            this.dvUsers.AllowUserToAddRows = false;
            this.dvUsers.AllowUserToDeleteRows = false;
            this.dvUsers.AllowUserToOrderColumns = true;
            this.dvUsers.BackgroundColor = System.Drawing.Color.White;
            this.dvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvUsers.ContextMenuStrip = this.cmUsers;
            this.dvUsers.Location = new System.Drawing.Point(12, 194);
            this.dvUsers.Name = "dvUsers";
            this.dvUsers.ReadOnly = true;
            this.dvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dvUsers.Size = new System.Drawing.Size(903, 349);
            this.dvUsers.TabIndex = 4;
            this.dvUsers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvUsers_CellContentClick);
            // 
            // cmUsers
            // 
            this.cmUsers.ImageScalingSize = new System.Drawing.Size(36, 36);
            this.cmUsers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDetilesToolStripMenuItem,
            this.addNewToolStripMenuItem,
            this.editUserToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.chanagPasswordToolStripMenuItem,
            this.sandEmilToolStripMenuItem,
            this.sandPhoneToolStripMenuItem});
            this.cmUsers.Name = "contextMenuStrip1";
            this.cmUsers.Size = new System.Drawing.Size(189, 298);
            // 
            // showDetilesToolStripMenuItem
            // 
            this.showDetilesToolStripMenuItem.Image = global::DVLDSluotion.Properties.Resources.PersonDetails_321;
            this.showDetilesToolStripMenuItem.Name = "showDetilesToolStripMenuItem";
            this.showDetilesToolStripMenuItem.Size = new System.Drawing.Size(188, 42);
            this.showDetilesToolStripMenuItem.Text = "Show Detiles";
            this.showDetilesToolStripMenuItem.Click += new System.EventHandler(this.showDetilesToolStripMenuItem_Click);
            // 
            // addNewToolStripMenuItem
            // 
            this.addNewToolStripMenuItem.Image = global::DVLDSluotion.Properties.Resources.Add_New_User_72;
            this.addNewToolStripMenuItem.Name = "addNewToolStripMenuItem";
            this.addNewToolStripMenuItem.Size = new System.Drawing.Size(188, 42);
            this.addNewToolStripMenuItem.Text = "Add New ";
            this.addNewToolStripMenuItem.Click += new System.EventHandler(this.addNewToolStripMenuItem_Click);
            // 
            // editUserToolStripMenuItem
            // 
            this.editUserToolStripMenuItem.Image = global::DVLDSluotion.Properties.Resources.edit_32;
            this.editUserToolStripMenuItem.Name = "editUserToolStripMenuItem";
            this.editUserToolStripMenuItem.Size = new System.Drawing.Size(188, 42);
            this.editUserToolStripMenuItem.Text = "Edit User";
            this.editUserToolStripMenuItem.Click += new System.EventHandler(this.editUserToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::DVLDSluotion.Properties.Resources.Delete_32_2;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(188, 42);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // chanagPasswordToolStripMenuItem
            // 
            this.chanagPasswordToolStripMenuItem.Image = global::DVLDSluotion.Properties.Resources.Password_321;
            this.chanagPasswordToolStripMenuItem.Name = "chanagPasswordToolStripMenuItem";
            this.chanagPasswordToolStripMenuItem.Size = new System.Drawing.Size(188, 42);
            this.chanagPasswordToolStripMenuItem.Text = "Chanag Password";
            this.chanagPasswordToolStripMenuItem.Click += new System.EventHandler(this.chanagPasswordToolStripMenuItem_Click);
            // 
            // sandEmilToolStripMenuItem
            // 
            this.sandEmilToolStripMenuItem.Image = global::DVLDSluotion.Properties.Resources.Email_32;
            this.sandEmilToolStripMenuItem.Name = "sandEmilToolStripMenuItem";
            this.sandEmilToolStripMenuItem.Size = new System.Drawing.Size(188, 42);
            this.sandEmilToolStripMenuItem.Text = "Sand Emil";
            // 
            // sandPhoneToolStripMenuItem
            // 
            this.sandPhoneToolStripMenuItem.Image = global::DVLDSluotion.Properties.Resources.Phone_32;
            this.sandPhoneToolStripMenuItem.Name = "sandPhoneToolStripMenuItem";
            this.sandPhoneToolStripMenuItem.Size = new System.Drawing.Size(188, 42);
            this.sandPhoneToolStripMenuItem.Text = "Phone call";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 560);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 24);
            this.label2.TabIndex = 7;
            this.label2.Text = "# Recorde :";
            // 
            // lbRecorde
            // 
            this.lbRecorde.AutoSize = true;
            this.lbRecorde.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRecorde.Location = new System.Drawing.Point(126, 563);
            this.lbRecorde.Name = "lbRecorde";
            this.lbRecorde.Size = new System.Drawing.Size(40, 24);
            this.lbRecorde.TabIndex = 8;
            this.lbRecorde.Text = "???";
            // 
            // cmISActive
            // 
            this.cmISActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmISActive.FormattingEnabled = true;
            this.cmISActive.Items.AddRange(new object[] {
            "All",
            "Yes",
            "No"});
            this.cmISActive.Location = new System.Drawing.Point(247, 163);
            this.cmISActive.Name = "cmISActive";
            this.cmISActive.Size = new System.Drawing.Size(139, 28);
            this.cmISActive.TabIndex = 9;
            this.cmISActive.Visible = false;
            this.cmISActive.SelectedIndexChanged += new System.EventHandler(this.cmISActive_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 24);
            this.label3.TabIndex = 10;
            this.label3.Text = "Find By:";
            // 
            // btClose
            // 
            this.btClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btClose.Image = global::DVLDSluotion.Properties.Resources.cross_32;
            this.btClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btClose.Location = new System.Drawing.Point(750, 560);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(96, 32);
            this.btClose.TabIndex = 6;
            this.btClose.Text = "Clsoe";
            this.btClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // btAddNewUsers
            // 
            this.btAddNewUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAddNewUsers.Image = global::DVLDSluotion.Properties.Resources.Add_New_User_72;
            this.btAddNewUsers.Location = new System.Drawing.Point(789, 124);
            this.btAddNewUsers.Name = "btAddNewUsers";
            this.btAddNewUsers.Size = new System.Drawing.Size(96, 64);
            this.btAddNewUsers.TabIndex = 5;
            this.btAddNewUsers.UseVisualStyleBackColor = true;
            this.btAddNewUsers.Click += new System.EventHandler(this.btAddNewUsers_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLDSluotion.Properties.Resources.Users_2_400;
            this.pictureBox1.Location = new System.Drawing.Point(417, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(142, 105);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // frmLastUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 595);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmISActive);
            this.Controls.Add(this.lbRecorde);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.btAddNewUsers);
            this.Controls.Add(this.dvUsers);
            this.Controls.Add(this.txtFilterVaaluse);
            this.Controls.Add(this.cmFilter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmLastUser";
            this.Text = "frmLastUser";
            this.Load += new System.EventHandler(this.frmLastUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvUsers)).EndInit();
            this.cmUsers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmFilter;
        private System.Windows.Forms.TextBox txtFilterVaaluse;
        private System.Windows.Forms.DataGridView dvUsers;
        private System.Windows.Forms.Button btAddNewUsers;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbRecorde;
        private System.Windows.Forms.ComboBox cmISActive;
        private System.Windows.Forms.ContextMenuStrip cmUsers;
        private System.Windows.Forms.ToolStripMenuItem showDetilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chanagPasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sandEmilToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sandPhoneToolStripMenuItem;
        private System.Windows.Forms.Label label3;
    }
}