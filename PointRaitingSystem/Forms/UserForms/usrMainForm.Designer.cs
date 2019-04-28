namespace PointRaitingSystem
{
    partial class usrMainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.bindingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сформироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCertification = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExam = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPickReportFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDeb = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAdm = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDebChangeUser = new System.Windows.Forms.ToolStripMenuItem();
            this.tscbDebUserList = new System.Windows.Forms.ToolStripComboBox();
            this.menuPanel = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCreateCP = new System.Windows.Forms.Button();
            this.btnPickCPs = new System.Windows.Forms.Button();
            this.btnAddExam = new System.Windows.Forms.Button();
            this.gbCertificationInfo = new System.Windows.Forms.GroupBox();
            this.lblCertCreator = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblMaxPointsSum = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnCertification = new System.Windows.Forms.Button();
            this.gbCPInfo = new System.Windows.Forms.GroupBox();
            this.lblWeight = new System.Windows.Forms.Label();
            this.lblDiscipline = new System.Windows.Forms.Label();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnReexam = new System.Windows.Forms.Button();
            this.cbDiscipline = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbGroups = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslTeacherName = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslCurrentDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.dgvStudents = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            this.menuPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbCertificationInfo.SuspendLayout();
            this.gbCPInfo.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingsToolStripMenuItem,
            this.отчетыToolStripMenuItem,
            this.настройкиToolStripMenuItem,
            this.tsmDeb});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1046, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "mainMenuBar";
            // 
            // bindingsToolStripMenuItem
            // 
            this.bindingsToolStripMenuItem.Name = "bindingsToolStripMenuItem";
            this.bindingsToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.bindingsToolStripMenuItem.Text = "Привязки";
            this.bindingsToolStripMenuItem.Click += new System.EventHandler(this.bindingsToolStripMenuItem_Click);
            // 
            // отчетыToolStripMenuItem
            // 
            this.отчетыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сформироватьToolStripMenuItem});
            this.отчетыToolStripMenuItem.Name = "отчетыToolStripMenuItem";
            this.отчетыToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.отчетыToolStripMenuItem.Text = "Отчеты";
            // 
            // сформироватьToolStripMenuItem
            // 
            this.сформироватьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCertification,
            this.tsmiExam});
            this.сформироватьToolStripMenuItem.Name = "сформироватьToolStripMenuItem";
            this.сформироватьToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.сформироватьToolStripMenuItem.Text = "Сформировать";
            // 
            // tsmiCertification
            // 
            this.tsmiCertification.Name = "tsmiCertification";
            this.tsmiCertification.Size = new System.Drawing.Size(140, 22);
            this.tsmiCertification.Text = "Атттестация";
            this.tsmiCertification.Click += new System.EventHandler(this.tsmiCertification_Click);
            // 
            // tsmiExam
            // 
            this.tsmiExam.Name = "tsmiExam";
            this.tsmiExam.Size = new System.Drawing.Size(140, 22);
            this.tsmiExam.Text = "Экзамен";
            this.tsmiExam.Click += new System.EventHandler(this.tsmiExam_Click);
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiPickReportFolder});
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            // 
            // tsmiPickReportFolder
            // 
            this.tsmiPickReportFolder.Name = "tsmiPickReportFolder";
            this.tsmiPickReportFolder.Size = new System.Drawing.Size(269, 22);
            this.tsmiPickReportFolder.Text = "Выбрать папку сохранения отчетов";
            this.tsmiPickReportFolder.Click += new System.EventHandler(this.tsmiPickReportFolder_Click);
            // 
            // tsmDeb
            // 
            this.tsmDeb.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAdm,
            this.tsmiDebChangeUser});
            this.tsmDeb.Name = "tsmDeb";
            this.tsmDeb.Size = new System.Drawing.Size(53, 20);
            this.tsmDeb.Text = "debug";
            this.tsmDeb.Visible = false;
            // 
            // tsmiAdm
            // 
            this.tsmiAdm.Name = "tsmiAdm";
            this.tsmiAdm.Size = new System.Drawing.Size(167, 22);
            this.tsmiAdm.Text = "open admin form";
            this.tsmiAdm.Click += new System.EventHandler(this.tsmiAdm_Click);
            // 
            // tsmiDebChangeUser
            // 
            this.tsmiDebChangeUser.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tscbDebUserList});
            this.tsmiDebChangeUser.Name = "tsmiDebChangeUser";
            this.tsmiDebChangeUser.Size = new System.Drawing.Size(167, 22);
            this.tsmiDebChangeUser.Text = "change user";
            // 
            // tscbDebUserList
            // 
            this.tscbDebUserList.Items.AddRange(new object[] {
            "cep.ds",
            "ncep.ds"});
            this.tscbDebUserList.Name = "tscbDebUserList";
            this.tscbDebUserList.Size = new System.Drawing.Size(121, 23);
            this.tscbDebUserList.TextChanged += new System.EventHandler(this.tscbDebUserList_TextChanged);
            // 
            // menuPanel
            // 
            this.menuPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.menuPanel.Controls.Add(this.groupBox1);
            this.menuPanel.Controls.Add(this.btnAddExam);
            this.menuPanel.Controls.Add(this.gbCertificationInfo);
            this.menuPanel.Controls.Add(this.btnCertification);
            this.menuPanel.Controls.Add(this.gbCPInfo);
            this.menuPanel.Controls.Add(this.btnReexam);
            this.menuPanel.Controls.Add(this.cbDiscipline);
            this.menuPanel.Controls.Add(this.label4);
            this.menuPanel.Controls.Add(this.cbGroups);
            this.menuPanel.Controls.Add(this.label1);
            this.menuPanel.Location = new System.Drawing.Point(0, 24);
            this.menuPanel.Margin = new System.Windows.Forms.Padding(2);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(284, 556);
            this.menuPanel.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCreateCP);
            this.groupBox1.Controls.Add(this.btnPickCPs);
            this.groupBox1.Location = new System.Drawing.Point(11, 111);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(121, 82);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Работа с КТ";
            // 
            // btnCreateCP
            // 
            this.btnCreateCP.Location = new System.Drawing.Point(5, 29);
            this.btnCreateCP.Name = "btnCreateCP";
            this.btnCreateCP.Size = new System.Drawing.Size(107, 23);
            this.btnCreateCP.TabIndex = 7;
            this.btnCreateCP.Text = "Создать КТ";
            this.btnCreateCP.UseVisualStyleBackColor = true;
            this.btnCreateCP.Click += new System.EventHandler(this.btnCreateCP_Click);
            // 
            // btnPickCPs
            // 
            this.btnPickCPs.Location = new System.Drawing.Point(5, 53);
            this.btnPickCPs.Name = "btnPickCPs";
            this.btnPickCPs.Size = new System.Drawing.Size(107, 23);
            this.btnPickCPs.TabIndex = 11;
            this.btnPickCPs.Text = "Выбрать КТ";
            this.btnPickCPs.UseVisualStyleBackColor = true;
            this.btnPickCPs.Click += new System.EventHandler(this.btnPickCPs_Click);
            // 
            // btnAddExam
            // 
            this.btnAddExam.Location = new System.Drawing.Point(146, 111);
            this.btnAddExam.Name = "btnAddExam";
            this.btnAddExam.Size = new System.Drawing.Size(121, 23);
            this.btnAddExam.TabIndex = 10;
            this.btnAddExam.Text = "Экзамен";
            this.btnAddExam.UseVisualStyleBackColor = true;
            this.btnAddExam.Click += new System.EventHandler(this.btnAddExam_Click);
            // 
            // gbCertificationInfo
            // 
            this.gbCertificationInfo.Controls.Add(this.lblCertCreator);
            this.gbCertificationInfo.Controls.Add(this.label8);
            this.gbCertificationInfo.Controls.Add(this.lblDate);
            this.gbCertificationInfo.Controls.Add(this.label10);
            this.gbCertificationInfo.Controls.Add(this.lblMaxPointsSum);
            this.gbCertificationInfo.Controls.Add(this.label11);
            this.gbCertificationInfo.Location = new System.Drawing.Point(4, 362);
            this.gbCertificationInfo.Name = "gbCertificationInfo";
            this.gbCertificationInfo.Size = new System.Drawing.Size(277, 143);
            this.gbCertificationInfo.TabIndex = 9;
            this.gbCertificationInfo.TabStop = false;
            this.gbCertificationInfo.Text = "Описание Аттестации:";
            this.gbCertificationInfo.Visible = false;
            // 
            // lblCertCreator
            // 
            this.lblCertCreator.AutoSize = true;
            this.lblCertCreator.Location = new System.Drawing.Point(77, 80);
            this.lblCertCreator.Name = "lblCertCreator";
            this.lblCertCreator.Size = new System.Drawing.Size(0, 13);
            this.lblCertCreator.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 80);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Создана";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(77, 55);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(0, 13);
            this.lblDate.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 55);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(33, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "Дата";
            // 
            // lblMaxPointsSum
            // 
            this.lblMaxPointsSum.AutoSize = true;
            this.lblMaxPointsSum.Location = new System.Drawing.Point(77, 30);
            this.lblMaxPointsSum.Name = "lblMaxPointsSum";
            this.lblMaxPointsSum.Size = new System.Drawing.Size(0, 13);
            this.lblMaxPointsSum.TabIndex = 7;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 30);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "Максимум";
            // 
            // btnCertification
            // 
            this.btnCertification.Location = new System.Drawing.Point(146, 170);
            this.btnCertification.Name = "btnCertification";
            this.btnCertification.Size = new System.Drawing.Size(121, 23);
            this.btnCertification.TabIndex = 9;
            this.btnCertification.Text = "Создать аттестацию";
            this.btnCertification.UseVisualStyleBackColor = true;
            this.btnCertification.Click += new System.EventHandler(this.btnCertification_Click);
            // 
            // gbCPInfo
            // 
            this.gbCPInfo.Controls.Add(this.lblWeight);
            this.gbCPInfo.Controls.Add(this.lblDiscipline);
            this.gbCPInfo.Controls.Add(this.lblAuthor);
            this.gbCPInfo.Controls.Add(this.txtDescription);
            this.gbCPInfo.Controls.Add(this.label6);
            this.gbCPInfo.Controls.Add(this.label5);
            this.gbCPInfo.Controls.Add(this.label3);
            this.gbCPInfo.Controls.Add(this.label2);
            this.gbCPInfo.Location = new System.Drawing.Point(4, 362);
            this.gbCPInfo.Name = "gbCPInfo";
            this.gbCPInfo.Size = new System.Drawing.Size(277, 169);
            this.gbCPInfo.TabIndex = 8;
            this.gbCPInfo.TabStop = false;
            this.gbCPInfo.Text = "Описание контрольной точки:";
            this.gbCPInfo.Visible = false;
            // 
            // lblWeight
            // 
            this.lblWeight.AutoSize = true;
            this.lblWeight.Location = new System.Drawing.Point(94, 80);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(0, 13);
            this.lblWeight.TabIndex = 7;
            // 
            // lblDiscipline
            // 
            this.lblDiscipline.AutoSize = true;
            this.lblDiscipline.Location = new System.Drawing.Point(94, 55);
            this.lblDiscipline.Name = "lblDiscipline";
            this.lblDiscipline.Size = new System.Drawing.Size(0, 13);
            this.lblDiscipline.TabIndex = 6;
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Location = new System.Drawing.Point(94, 29);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(0, 13);
            this.lblAuthor.TabIndex = 5;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(97, 105);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(174, 58);
            this.txtDescription.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Описание";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Вес";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Дисциплина";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Создана";
            // 
            // btnReexam
            // 
            this.btnReexam.Location = new System.Drawing.Point(146, 141);
            this.btnReexam.Name = "btnReexam";
            this.btnReexam.Size = new System.Drawing.Size(121, 23);
            this.btnReexam.TabIndex = 6;
            this.btnReexam.Text = "Переэкзаменовка";
            this.btnReexam.UseVisualStyleBackColor = true;
            this.btnReexam.Click += new System.EventHandler(this.btnReExam_Click);
            // 
            // cbDiscipline
            // 
            this.cbDiscipline.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDiscipline.FormattingEnabled = true;
            this.cbDiscipline.Location = new System.Drawing.Point(11, 77);
            this.cbDiscipline.Margin = new System.Windows.Forms.Padding(2);
            this.cbDiscipline.Name = "cbDiscipline";
            this.cbDiscipline.Size = new System.Drawing.Size(219, 21);
            this.cbDiscipline.TabIndex = 5;
            this.cbDiscipline.SelectionChangeCommitted += new System.EventHandler(this.cbDiscipline_SelectionChangeCommitted);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 60);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Дисциплина";
            // 
            // cbGroups
            // 
            this.cbGroups.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGroups.FormattingEnabled = true;
            this.cbGroups.Location = new System.Drawing.Point(11, 27);
            this.cbGroups.Margin = new System.Windows.Forms.Padding(2);
            this.cbGroups.Name = "cbGroups";
            this.cbGroups.Size = new System.Drawing.Size(99, 21);
            this.cbGroups.TabIndex = 1;
            this.cbGroups.SelectedIndexChanged += new System.EventHandler(this.cbGroups_SelectedIndexChanged);
            this.cbGroups.SelectionChangeCommitted += new System.EventHandler(this.cbGroups_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Группа";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslTeacherName,
            this.toolStripStatusLabel1,
            this.tsslCurrentDate});
            this.statusStrip1.Location = new System.Drawing.Point(0, 558);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1046, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslTeacherName
            // 
            this.tsslTeacherName.Name = "tsslTeacherName";
            this.tsslTeacherName.Size = new System.Drawing.Size(43, 17);
            this.tsslTeacherName.Text = "tName";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(961, 17);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // tsslCurrentDate
            // 
            this.tsslCurrentDate.Name = "tsslCurrentDate";
            this.tsslCurrentDate.Overflow = System.Windows.Forms.ToolStripItemOverflow.Always;
            this.tsslCurrentDate.Size = new System.Drawing.Size(31, 17);
            this.tsslCurrentDate.Text = "Date";
            // 
            // dgvStudents
            // 
            this.dgvStudents.AllowUserToAddRows = false;
            this.dgvStudents.AllowUserToDeleteRows = false;
            this.dgvStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudents.Dock = System.Windows.Forms.DockStyle.Right;
            this.dgvStudents.Location = new System.Drawing.Point(289, 24);
            this.dgvStudents.Name = "dgvStudents";
            this.dgvStudents.RowHeadersVisible = false;
            this.dgvStudents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.ColumnHeaderSelect;
            this.dgvStudents.Size = new System.Drawing.Size(757, 534);
            this.dgvStudents.TabIndex = 4;
            this.dgvStudents.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStudents_CellEndEdit);
            this.dgvStudents.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvStudents_ColumnHeaderMouseClick);
            // 
            // usrMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1046, 580);
            this.Controls.Add(this.dgvStudents);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuPanel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "usrMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Меню";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.menuPanel.ResumeLayout(false);
            this.menuPanel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.gbCertificationInfo.ResumeLayout(false);
            this.gbCertificationInfo.PerformLayout();
            this.gbCPInfo.ResumeLayout(false);
            this.gbCPInfo.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.ComboBox cbDiscipline;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbGroups;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslTeacherName;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem bindingsToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvStudents;
        private System.Windows.Forms.Button btnCreateCP;
        private System.Windows.Forms.Button btnReexam;
        private System.Windows.Forms.GroupBox gbCPInfo;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblWeight;
        private System.Windows.Forms.Label lblDiscipline;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.ToolStripStatusLabel tsslCurrentDate;
        private System.Windows.Forms.Button btnCertification;
        private System.Windows.Forms.ToolStripMenuItem отчетыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сформироватьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiCertification;
        private System.Windows.Forms.ToolStripMenuItem tsmiExam;
        private System.Windows.Forms.GroupBox gbCertificationInfo;
        private System.Windows.Forms.Label lblMaxPointsSum;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblCertCreator;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Button btnAddExam;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiPickReportFolder;
        private System.Windows.Forms.Button btnPickCPs;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripMenuItem tsmDeb;
        private System.Windows.Forms.ToolStripMenuItem tsmiAdm;
        private System.Windows.Forms.ToolStripMenuItem tsmiDebChangeUser;
        private System.Windows.Forms.ToolStripComboBox tscbDebUserList;
    }
}

