namespace PointRaitingSystem
{
    partial class tabStudents
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvStudents = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.gbStudentInfo = new System.Windows.Forms.GroupBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbGroup = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtStId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbGroupFrom = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbGroupTo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.gbTransferInfo = new System.Windows.Forms.GroupBox();
            this.studentNamePanel = new System.Windows.Forms.Panel();
            this.lblStudentName = new System.Windows.Forms.Label();
            this.checkBoxOnlySelecetdStudent = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).BeginInit();
            this.gbStudentInfo.SuspendLayout();
            this.gbTransferInfo.SuspendLayout();
            this.studentNamePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvStudents
            // 
            this.dgvStudents.AllowUserToAddRows = false;
            this.dgvStudents.AllowUserToDeleteRows = false;
            this.dgvStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudents.Dock = System.Windows.Forms.DockStyle.Right;
            this.dgvStudents.Location = new System.Drawing.Point(286, 0);
            this.dgvStudents.Margin = new System.Windows.Forms.Padding(4);
            this.dgvStudents.MultiSelect = false;
            this.dgvStudents.Name = "dgvStudents";
            this.dgvStudents.ReadOnly = true;
            this.dgvStudents.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvStudents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStudents.Size = new System.Drawing.Size(659, 596);
            this.dgvStudents.TabIndex = 1;
            this.dgvStudents.SelectionChanged += new System.EventHandler(this.dgvStudents_SelectionChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(48, 132);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(184, 28);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(48, 167);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(184, 28);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Text = "Изменить";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // gbStudentInfo
            // 
            this.gbStudentInfo.Controls.Add(this.txtName);
            this.gbStudentInfo.Controls.Add(this.label3);
            this.gbStudentInfo.Controls.Add(this.cbGroup);
            this.gbStudentInfo.Controls.Add(this.btnUpdate);
            this.gbStudentInfo.Controls.Add(this.label2);
            this.gbStudentInfo.Controls.Add(this.btnAdd);
            this.gbStudentInfo.Controls.Add(this.txtStId);
            this.gbStudentInfo.Controls.Add(this.label1);
            this.gbStudentInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbStudentInfo.Location = new System.Drawing.Point(0, 0);
            this.gbStudentInfo.Margin = new System.Windows.Forms.Padding(4);
            this.gbStudentInfo.Name = "gbStudentInfo";
            this.gbStudentInfo.Padding = new System.Windows.Forms.Padding(4);
            this.gbStudentInfo.Size = new System.Drawing.Size(286, 203);
            this.gbStudentInfo.TabIndex = 4;
            this.gbStudentInfo.TabStop = false;
            this.gbStudentInfo.Text = "Информация о студентах";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(69, 66);
            this.txtName.Margin = new System.Windows.Forms.Padding(4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(208, 22);
            this.txtName.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 70);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "ФИО";
            // 
            // cbGroup
            // 
            this.cbGroup.FormattingEnabled = true;
            this.cbGroup.Location = new System.Drawing.Point(69, 98);
            this.cbGroup.Margin = new System.Windows.Forms.Padding(4);
            this.cbGroup.Name = "cbGroup";
            this.cbGroup.Size = new System.Drawing.Size(132, 24);
            this.cbGroup.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 102);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Группа";
            // 
            // txtStId
            // 
            this.txtStId.Location = new System.Drawing.Point(69, 34);
            this.txtStId.Margin = new System.Windows.Forms.Padding(4);
            this.txtStId.Name = "txtStId";
            this.txtStId.ReadOnly = true;
            this.txtStId.Size = new System.Drawing.Size(36, 22);
            this.txtStId.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "id";
            // 
            // cbGroupFrom
            // 
            this.cbGroupFrom.FormattingEnabled = true;
            this.cbGroupFrom.Location = new System.Drawing.Point(40, 33);
            this.cbGroupFrom.Margin = new System.Windows.Forms.Padding(4);
            this.cbGroupFrom.Name = "cbGroupFrom";
            this.cbGroupFrom.Size = new System.Drawing.Size(103, 24);
            this.cbGroupFrom.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 36);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "Из";
            // 
            // cbGroupTo
            // 
            this.cbGroupTo.FormattingEnabled = true;
            this.cbGroupTo.Location = new System.Drawing.Point(40, 65);
            this.cbGroupTo.Margin = new System.Windows.Forms.Padding(4);
            this.cbGroupTo.Name = "cbGroupTo";
            this.cbGroupTo.Size = new System.Drawing.Size(103, 24);
            this.cbGroupTo.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 68);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 17);
            this.label6.TabIndex = 8;
            this.label6.Text = "В";
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(40, 183);
            this.btnApply.Margin = new System.Windows.Forms.Padding(4);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(184, 28);
            this.btnApply.TabIndex = 6;
            this.btnApply.Text = "Выполнить";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // gbTransferInfo
            // 
            this.gbTransferInfo.Controls.Add(this.studentNamePanel);
            this.gbTransferInfo.Controls.Add(this.checkBoxOnlySelecetdStudent);
            this.gbTransferInfo.Controls.Add(this.label5);
            this.gbTransferInfo.Controls.Add(this.btnApply);
            this.gbTransferInfo.Controls.Add(this.cbGroupFrom);
            this.gbTransferInfo.Controls.Add(this.cbGroupTo);
            this.gbTransferInfo.Controls.Add(this.label6);
            this.gbTransferInfo.Location = new System.Drawing.Point(3, 238);
            this.gbTransferInfo.Name = "gbTransferInfo";
            this.gbTransferInfo.Size = new System.Drawing.Size(274, 218);
            this.gbTransferInfo.TabIndex = 10;
            this.gbTransferInfo.TabStop = false;
            this.gbTransferInfo.Text = "Перевести студентов в другую группу";
            // 
            // studentNamePanel
            // 
            this.studentNamePanel.Controls.Add(this.lblStudentName);
            this.studentNamePanel.Location = new System.Drawing.Point(7, 132);
            this.studentNamePanel.Name = "studentNamePanel";
            this.studentNamePanel.Size = new System.Drawing.Size(261, 40);
            this.studentNamePanel.TabIndex = 11;
            this.studentNamePanel.Visible = false;
            // 
            // lblStudentName
            // 
            this.lblStudentName.AutoSize = true;
            this.lblStudentName.Location = new System.Drawing.Point(6, 12);
            this.lblStudentName.Name = "lblStudentName";
            this.lblStudentName.Size = new System.Drawing.Size(46, 17);
            this.lblStudentName.TabIndex = 0;
            this.lblStudentName.Text = "label4";
            // 
            // checkBoxOnlySelecetdStudent
            // 
            this.checkBoxOnlySelecetdStudent.AutoSize = true;
            this.checkBoxOnlySelecetdStudent.CausesValidation = false;
            this.checkBoxOnlySelecetdStudent.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxOnlySelecetdStudent.Location = new System.Drawing.Point(7, 104);
            this.checkBoxOnlySelecetdStudent.Name = "checkBoxOnlySelecetdStudent";
            this.checkBoxOnlySelecetdStudent.Size = new System.Drawing.Size(223, 21);
            this.checkBoxOnlySelecetdStudent.TabIndex = 10;
            this.checkBoxOnlySelecetdStudent.Text = "Только выбранного студента";
            this.checkBoxOnlySelecetdStudent.UseVisualStyleBackColor = true;
            this.checkBoxOnlySelecetdStudent.CheckedChanged += new System.EventHandler(this.checkBoxOnlySelecetdStudent_CheckedChanged);
            // 
            // tabStudents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbTransferInfo);
            this.Controls.Add(this.gbStudentInfo);
            this.Controls.Add(this.dgvStudents);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "tabStudents";
            this.Size = new System.Drawing.Size(945, 596);
            this.Load += new System.EventHandler(this.tabStudents_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).EndInit();
            this.gbStudentInfo.ResumeLayout(false);
            this.gbStudentInfo.PerformLayout();
            this.gbTransferInfo.ResumeLayout(false);
            this.gbTransferInfo.PerformLayout();
            this.studentNamePanel.ResumeLayout(false);
            this.studentNamePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvStudents;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.GroupBox gbStudentInfo;
        private System.Windows.Forms.TextBox txtStId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbGroup;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbGroupFrom;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbGroupTo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.GroupBox gbTransferInfo;
        private System.Windows.Forms.CheckBox checkBoxOnlySelecetdStudent;
        private System.Windows.Forms.Panel studentNamePanel;
        private System.Windows.Forms.Label lblStudentName;
    }
}
