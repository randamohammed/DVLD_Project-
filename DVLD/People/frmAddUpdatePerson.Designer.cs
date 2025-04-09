namespace DVLDSluotion
{
    partial class frmAddUpdatePerson
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
            this.lbTitel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbPersonID = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.llRemoveImage = new System.Windows.Forms.LinkLabel();
            this.llSetImage = new System.Windows.Forms.LinkLabel();
            this.label14 = new System.Windows.Forms.Label();
            this.combCountry = new System.Windows.Forms.ComboBox();
            this.tebEmail = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tePhone = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.rbFeMale = new System.Windows.Forms.RadioButton();
            this.rbMale = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpDataofBirth = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.tebNationalNo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tebLastName = new System.Windows.Forms.TextBox();
            this.tebThirdName = new System.Windows.Forms.TextBox();
            this.tebScenedname = new System.Windows.Forms.TextBox();
            this.tebFirstName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buClose = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pbPresonImage = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tebAdress = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPresonImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTitel
            // 
            this.lbTitel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbTitel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbTitel.Location = new System.Drawing.Point(29, 9);
            this.lbTitel.Name = "lbTitel";
            this.lbTitel.Size = new System.Drawing.Size(761, 34);
            this.lbTitel.TabIndex = 1;
            this.lbTitel.Text = "     Add New Person";
            this.lbTitel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbTitel.Click += new System.EventHandler(this.lbTitel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Person ID:";
            // 
            // lbPersonID
            // 
            this.lbPersonID.AutoSize = true;
            this.lbPersonID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPersonID.Location = new System.Drawing.Point(163, 64);
            this.lbPersonID.Name = "lbPersonID";
            this.lbPersonID.Size = new System.Drawing.Size(38, 20);
            this.lbPersonID.TabIndex = 4;
            this.lbPersonID.Text = "A/N";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 90);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(840, 350);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = "";
            // 
            // llRemoveImage
            // 
            this.llRemoveImage.AutoSize = true;
            this.llRemoveImage.Location = new System.Drawing.Point(714, 324);
            this.llRemoveImage.Name = "llRemoveImage";
            this.llRemoveImage.Size = new System.Drawing.Size(117, 20);
            this.llRemoveImage.TabIndex = 74;
            this.llRemoveImage.TabStop = true;
            this.llRemoveImage.Text = "Remove Image";
            this.llRemoveImage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llRemoveImage_LinkClicked_1);
            // 
            // llSetImage
            // 
            this.llSetImage.AutoSize = true;
            this.llSetImage.Location = new System.Drawing.Point(723, 293);
            this.llSetImage.Name = "llSetImage";
            this.llSetImage.Size = new System.Drawing.Size(83, 20);
            this.llSetImage.TabIndex = 73;
            this.llSetImage.TabStop = true;
            this.llSetImage.Text = "Set Image";
            this.llSetImage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llSetImage_LinkClicked_1);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(20, 303);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(70, 20);
            this.label14.TabIndex = 69;
            this.label14.Text = "Adress:";
            // 
            // combCountry
            // 
            this.combCountry.BackColor = System.Drawing.Color.White;
            this.combCountry.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.combCountry.FormattingEnabled = true;
            this.combCountry.Location = new System.Drawing.Point(521, 257);
            this.combCountry.Name = "combCountry";
            this.combCountry.Size = new System.Drawing.Size(153, 27);
            this.combCountry.TabIndex = 67;
            // 
            // tebEmail
            // 
            this.tebEmail.Location = new System.Drawing.Point(161, 256);
            this.tebEmail.Name = "tebEmail";
            this.tebEmail.Size = new System.Drawing.Size(153, 26);
            this.tebEmail.TabIndex = 65;
            this.tebEmail.Validating += new System.ComponentModel.CancelEventHandler(this.tebEmail_Validating_1);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(396, 256);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(76, 20);
            this.label13.TabIndex = 64;
            this.label13.Text = "Country:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(20, 256);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(58, 20);
            this.label12.TabIndex = 62;
            this.label12.Text = "Email:";
            // 
            // tePhone
            // 
            this.tePhone.Location = new System.Drawing.Point(521, 214);
            this.tePhone.Name = "tePhone";
            this.tePhone.Size = new System.Drawing.Size(153, 26);
            this.tePhone.TabIndex = 60;
            this.tePhone.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateEmptyTextBox);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(412, 212);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 20);
            this.label11.TabIndex = 59;
            this.label11.Text = "Phone:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox7);
            this.groupBox1.Controls.Add(this.rbFeMale);
            this.groupBox1.Controls.Add(this.rbMale);
            this.groupBox1.Location = new System.Drawing.Point(159, 198);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(186, 42);
            this.groupBox1.TabIndex = 58;
            this.groupBox1.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = global::DVLDSluotion.Properties.Resources.Woman_32;
            this.pictureBox7.Location = new System.Drawing.Point(68, 13);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(27, 26);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox7.TabIndex = 22;
            this.pictureBox7.TabStop = false;
            // 
            // rbFeMale
            // 
            this.rbFeMale.AutoSize = true;
            this.rbFeMale.Location = new System.Drawing.Point(100, 13);
            this.rbFeMale.Name = "rbFeMale";
            this.rbFeMale.Size = new System.Drawing.Size(80, 24);
            this.rbFeMale.TabIndex = 1;
            this.rbFeMale.TabStop = true;
            this.rbFeMale.Text = "FeMale";
            this.rbFeMale.UseVisualStyleBackColor = true;
            this.rbFeMale.CheckedChanged += new System.EventHandler(this.rbFeMale_CheckedChanged);
            // 
            // rbMale
            // 
            this.rbMale.AutoSize = true;
            this.rbMale.Location = new System.Drawing.Point(6, 13);
            this.rbMale.Name = "rbMale";
            this.rbMale.Size = new System.Drawing.Size(61, 24);
            this.rbMale.TabIndex = 0;
            this.rbMale.TabStop = true;
            this.rbMale.Text = "Male";
            this.rbMale.UseVisualStyleBackColor = true;
            this.rbMale.CheckedChanged += new System.EventHandler(this.rbMale_CheckedChanged_1);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(20, 214);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 20);
            this.label10.TabIndex = 56;
            this.label10.Text = "Gender:";
            // 
            // dtpDataofBirth
            // 
            this.dtpDataofBirth.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataofBirth.Location = new System.Drawing.Point(521, 166);
            this.dtpDataofBirth.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpDataofBirth.Name = "dtpDataofBirth";
            this.dtpDataofBirth.Size = new System.Drawing.Size(153, 26);
            this.dtpDataofBirth.TabIndex = 55;
            this.dtpDataofBirth.Value = new System.DateTime(2000, 12, 31, 0, 0, 0, 0);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(362, 166);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(120, 20);
            this.label9.TabIndex = 51;
            this.label9.Text = "Date Of Birth:";
            // 
            // tebNationalNo
            // 
            this.tebNationalNo.Location = new System.Drawing.Point(159, 166);
            this.tebNationalNo.Name = "tebNationalNo";
            this.tebNationalNo.Size = new System.Drawing.Size(153, 26);
            this.tebNationalNo.TabIndex = 50;
            this.tebNationalNo.Validating += new System.ComponentModel.CancelEventHandler(this.tebNationalNo_Validating_1);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(20, 167);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 20);
            this.label8.TabIndex = 49;
            this.label8.Text = "National No:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(714, 95);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 20);
            this.label7.TabIndex = 48;
            this.label7.Text = "Last";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(564, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 20);
            this.label6.TabIndex = 47;
            this.label6.Text = "Third";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(399, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 20);
            this.label5.TabIndex = 46;
            this.label5.Text = "Second";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(193, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 20);
            this.label4.TabIndex = 45;
            this.label4.Text = "First";
            // 
            // tebLastName
            // 
            this.tebLastName.Location = new System.Drawing.Point(702, 115);
            this.tebLastName.Name = "tebLastName";
            this.tebLastName.Size = new System.Drawing.Size(136, 26);
            this.tebLastName.TabIndex = 44;
            this.tebLastName.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateEmptyTextBox);
            // 
            // tebThirdName
            // 
            this.tebThirdName.Location = new System.Drawing.Point(521, 115);
            this.tebThirdName.Name = "tebThirdName";
            this.tebThirdName.Size = new System.Drawing.Size(153, 26);
            this.tebThirdName.TabIndex = 43;
            this.tebThirdName.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateEmptyTextBox);
            // 
            // tebScenedname
            // 
            this.tebScenedname.Location = new System.Drawing.Point(348, 118);
            this.tebScenedname.Name = "tebScenedname";
            this.tebScenedname.Size = new System.Drawing.Size(153, 26);
            this.tebScenedname.TabIndex = 42;
            this.tebScenedname.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateEmptyTextBox);
            // 
            // tebFirstName
            // 
            this.tebFirstName.Location = new System.Drawing.Point(159, 115);
            this.tebFirstName.Name = "tebFirstName";
            this.tebFirstName.Size = new System.Drawing.Size(153, 26);
            this.tebFirstName.TabIndex = 41;
            this.tebFirstName.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateEmptyTextBox);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 20);
            this.label3.TabIndex = 39;
            this.label3.Text = "Name:";
            // 
            // buClose
            // 
            this.buClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buClose.Image = global::DVLDSluotion.Properties.Resources.cross_32;
            this.buClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buClose.Location = new System.Drawing.Point(366, 390);
            this.buClose.Name = "buClose";
            this.buClose.Size = new System.Drawing.Size(100, 37);
            this.buClose.TabIndex = 72;
            this.buClose.Text = "    Close";
            this.buClose.UseVisualStyleBackColor = true;
            this.buClose.Click += new System.EventHandler(this.buClose_Click_1);
            // 
            // btSave
            // 
            this.btSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSave.Image = global::DVLDSluotion.Properties.Resources.Save_32;
            this.btSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btSave.Location = new System.Drawing.Point(612, 390);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(100, 37);
            this.btSave.TabIndex = 71;
            this.btSave.Text = "   Save";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click_1);
            // 
            // pictureBox11
            // 
            this.pictureBox11.Image = global::DVLDSluotion.Properties.Resources.Address_32;
            this.pictureBox11.Location = new System.Drawing.Point(128, 306);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new System.Drawing.Size(27, 26);
            this.pictureBox11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox11.TabIndex = 70;
            this.pictureBox11.TabStop = false;
            // 
            // pictureBox10
            // 
            this.pictureBox10.Image = global::DVLDSluotion.Properties.Resources.Country_32;
            this.pictureBox10.Location = new System.Drawing.Point(485, 256);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(27, 26);
            this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox10.TabIndex = 66;
            this.pictureBox10.TabStop = false;
            // 
            // pictureBox9
            // 
            this.pictureBox9.Image = global::DVLDSluotion.Properties.Resources.Email_32;
            this.pictureBox9.Location = new System.Drawing.Point(128, 256);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(27, 26);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox9.TabIndex = 63;
            this.pictureBox9.TabStop = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = global::DVLDSluotion.Properties.Resources.Phone_32;
            this.pictureBox8.Location = new System.Drawing.Point(488, 209);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(27, 26);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox8.TabIndex = 61;
            this.pictureBox8.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::DVLDSluotion.Properties.Resources.Female_512;
            this.pictureBox6.Location = new System.Drawing.Point(128, 210);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(27, 26);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 57;
            this.pictureBox6.TabStop = false;
            // 
            // pbPresonImage
            // 
            this.pbPresonImage.Location = new System.Drawing.Point(702, 161);
            this.pbPresonImage.Name = "pbPresonImage";
            this.pbPresonImage.Size = new System.Drawing.Size(136, 129);
            this.pbPresonImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPresonImage.TabIndex = 54;
            this.pbPresonImage.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::DVLDSluotion.Properties.Resources.calendar_month;
            this.pictureBox4.Location = new System.Drawing.Point(488, 161);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(27, 26);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 53;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::DVLDSluotion.Properties.Resources.view_grid;
            this.pictureBox3.Location = new System.Drawing.Point(128, 167);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(27, 26);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 52;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLDSluotion.Properties.Resources.Person_32;
            this.pictureBox2.Location = new System.Drawing.Point(128, 114);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(27, 26);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 40;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLDSluotion.Properties.Resources.Number_32;
            this.pictureBox1.Location = new System.Drawing.Point(128, 58);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(27, 26);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // tebAdress
            // 
            this.tebAdress.Location = new System.Drawing.Point(161, 300);
            this.tebAdress.Multiline = true;
            this.tebAdress.Name = "tebAdress";
            this.tebAdress.Size = new System.Drawing.Size(513, 78);
            this.tebAdress.TabIndex = 75;
            this.tebAdress.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateEmptyTextBox);
            // 
            // frmAddUpdatePerson
            // 
            this.AcceptButton = this.btSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.buClose;
            this.ClientSize = new System.Drawing.Size(855, 478);
            this.Controls.Add(this.tebAdress);
            this.Controls.Add(this.llRemoveImage);
            this.Controls.Add(this.llSetImage);
            this.Controls.Add(this.buClose);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.pictureBox11);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.combCountry);
            this.Controls.Add(this.pictureBox10);
            this.Controls.Add(this.tebEmail);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.pictureBox9);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.pictureBox8);
            this.Controls.Add(this.tePhone);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dtpDataofBirth);
            this.Controls.Add(this.pbPresonImage);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tebNationalNo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tebLastName);
            this.Controls.Add(this.tebThirdName);
            this.Controls.Add(this.tebScenedname);
            this.Controls.Add(this.tebFirstName);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.lbPersonID);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbTitel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddUpdatePerson";
            this.Text = "Add / Edit Person";
            this.Load += new System.EventHandler(this.frmAddUpdatePerson_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPresonImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbTitel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbPersonID;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.LinkLabel llRemoveImage;
        private System.Windows.Forms.LinkLabel llSetImage;
        private System.Windows.Forms.Button buClose;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.PictureBox pictureBox11;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox combCountry;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.TextBox tebEmail;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.TextBox tePhone;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.RadioButton rbFeMale;
        private System.Windows.Forms.RadioButton rbMale;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpDataofBirth;
        private System.Windows.Forms.PictureBox pbPresonImage;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tebNationalNo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tebLastName;
        private System.Windows.Forms.TextBox tebThirdName;
        private System.Windows.Forms.TextBox tebScenedname;
        private System.Windows.Forms.TextBox tebFirstName;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox tebAdress;
    }
}