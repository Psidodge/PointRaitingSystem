namespace PointRaitingSystem
{
    partial class admMainForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnLoadFromFile = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAddStudents = new System.Windows.Forms.Button();
            this.btnAddTeachers = new System.Windows.Forms.Button();
            this.btnAddGroups = new System.Windows.Forms.Button();
            this.btnAddDisciplines = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(245, 679);
            this.panel1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnLoadFromFile);
            this.groupBox2.Location = new System.Drawing.Point(12, 198);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(226, 100);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Загрузка из файла";
            // 
            // btnLoadFromFile
            // 
            this.btnLoadFromFile.Location = new System.Drawing.Point(7, 37);
            this.btnLoadFromFile.Margin = new System.Windows.Forms.Padding(4);
            this.btnLoadFromFile.Name = "btnLoadFromFile";
            this.btnLoadFromFile.Size = new System.Drawing.Size(201, 28);
            this.btnLoadFromFile.TabIndex = 4;
            this.btnLoadFromFile.Text = "Загрузить из файла";
            this.btnLoadFromFile.UseVisualStyleBackColor = true;
            this.btnLoadFromFile.Click += new System.EventHandler(this.btnLoadFromFile_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAddStudents);
            this.groupBox1.Controls.Add(this.btnAddTeachers);
            this.groupBox1.Controls.Add(this.btnAddGroups);
            this.groupBox1.Controls.Add(this.btnAddDisciplines);
            this.groupBox1.Location = new System.Drawing.Point(12, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(226, 176);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ручное редактирование";
            // 
            // btnAddStudents
            // 
            this.btnAddStudents.Location = new System.Drawing.Point(7, 22);
            this.btnAddStudents.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddStudents.Name = "btnAddStudents";
            this.btnAddStudents.Size = new System.Drawing.Size(201, 28);
            this.btnAddStudents.TabIndex = 0;
            this.btnAddStudents.Text = "Добавить студентов";
            this.btnAddStudents.UseVisualStyleBackColor = true;
            this.btnAddStudents.Click += new System.EventHandler(this.btnAddStudents_Click);
            // 
            // btnAddTeachers
            // 
            this.btnAddTeachers.Location = new System.Drawing.Point(7, 57);
            this.btnAddTeachers.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddTeachers.Name = "btnAddTeachers";
            this.btnAddTeachers.Size = new System.Drawing.Size(201, 28);
            this.btnAddTeachers.TabIndex = 1;
            this.btnAddTeachers.Text = "Добавить преподавателей";
            this.btnAddTeachers.UseVisualStyleBackColor = true;
            this.btnAddTeachers.Click += new System.EventHandler(this.btnAddTeachers_Click);
            // 
            // btnAddGroups
            // 
            this.btnAddGroups.Location = new System.Drawing.Point(7, 129);
            this.btnAddGroups.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddGroups.Name = "btnAddGroups";
            this.btnAddGroups.Size = new System.Drawing.Size(201, 28);
            this.btnAddGroups.TabIndex = 3;
            this.btnAddGroups.Text = "Добавить группы";
            this.btnAddGroups.UseVisualStyleBackColor = true;
            this.btnAddGroups.Click += new System.EventHandler(this.btnAddGroups_Click);
            // 
            // btnAddDisciplines
            // 
            this.btnAddDisciplines.Location = new System.Drawing.Point(7, 93);
            this.btnAddDisciplines.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddDisciplines.Name = "btnAddDisciplines";
            this.btnAddDisciplines.Size = new System.Drawing.Size(201, 28);
            this.btnAddDisciplines.TabIndex = 2;
            this.btnAddDisciplines.Text = "Добавить дисциплины";
            this.btnAddDisciplines.UseVisualStyleBackColor = true;
            this.btnAddDisciplines.Click += new System.EventHandler(this.btnAddDisciplines_Click);
            // 
            // tabControl
            // 
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.HotTrack = true;
            this.tabControl.Location = new System.Drawing.Point(245, 0);
            this.tabControl.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl.Multiline = true;
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1019, 679);
            this.tabControl.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl.TabIndex = 1;
            this.tabControl.TabStop = false;
            // 
            // admMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 679);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "admMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin dashboard";
            this.Load += new System.EventHandler(this.admMainForm_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.Button btnAddStudents;
        private System.Windows.Forms.Button btnAddTeachers;
        private System.Windows.Forms.Button btnAddGroups;
        private System.Windows.Forms.Button btnAddDisciplines;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnLoadFromFile;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}