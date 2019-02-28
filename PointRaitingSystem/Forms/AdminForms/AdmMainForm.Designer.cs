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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAddGroups = new System.Windows.Forms.Button();
            this.btnAddDisciplines = new System.Windows.Forms.Button();
            this.btnAddTeachers = new System.Windows.Forms.Button();
            this.btnAddStudents = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cmsTabs = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.closeCurrentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.cmsTabs.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnAddGroups);
            this.panel1.Controls.Add(this.btnAddDisciplines);
            this.panel1.Controls.Add(this.btnAddTeachers);
            this.panel1.Controls.Add(this.btnAddStudents);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(184, 528);
            this.panel1.TabIndex = 0;
            // 
            // btnAddGroups
            // 
            this.btnAddGroups.Location = new System.Drawing.Point(12, 90);
            this.btnAddGroups.Name = "btnAddGroups";
            this.btnAddGroups.Size = new System.Drawing.Size(151, 23);
            this.btnAddGroups.TabIndex = 3;
            this.btnAddGroups.Text = "Добавить группы";
            this.btnAddGroups.UseVisualStyleBackColor = true;
            this.btnAddGroups.Click += new System.EventHandler(this.btnAddGroups_Click);
            // 
            // btnAddDisciplines
            // 
            this.btnAddDisciplines.Location = new System.Drawing.Point(12, 61);
            this.btnAddDisciplines.Name = "btnAddDisciplines";
            this.btnAddDisciplines.Size = new System.Drawing.Size(151, 23);
            this.btnAddDisciplines.TabIndex = 2;
            this.btnAddDisciplines.Text = "Добавить дисциплины";
            this.btnAddDisciplines.UseVisualStyleBackColor = true;
            this.btnAddDisciplines.Click += new System.EventHandler(this.btnAddDisciplines_Click);
            // 
            // btnAddTeachers
            // 
            this.btnAddTeachers.Location = new System.Drawing.Point(12, 32);
            this.btnAddTeachers.Name = "btnAddTeachers";
            this.btnAddTeachers.Size = new System.Drawing.Size(151, 23);
            this.btnAddTeachers.TabIndex = 1;
            this.btnAddTeachers.Text = "Добавить преподавателей";
            this.btnAddTeachers.UseVisualStyleBackColor = true;
            this.btnAddTeachers.Click += new System.EventHandler(this.btnAddTeachers_Click);
            // 
            // btnAddStudents
            // 
            this.btnAddStudents.Location = new System.Drawing.Point(12, 3);
            this.btnAddStudents.Name = "btnAddStudents";
            this.btnAddStudents.Size = new System.Drawing.Size(151, 23);
            this.btnAddStudents.TabIndex = 0;
            this.btnAddStudents.Text = "Добавить студентов";
            this.btnAddStudents.UseVisualStyleBackColor = true;
            this.btnAddStudents.Click += new System.EventHandler(this.btnAddStudents_Click);
            // 
            // tabControl
            // 
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.HotTrack = true;
            this.tabControl.Location = new System.Drawing.Point(184, 24);
            this.tabControl.Multiline = true;
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(764, 528);
            this.tabControl.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl.TabIndex = 1;
            this.tabControl.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.parseToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(948, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cmsTabs
            // 
            this.cmsTabs.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeCurrentToolStripMenuItem,
            this.closeAllToolStripMenuItem});
            this.cmsTabs.Name = "cmsTabs";
            this.cmsTabs.Size = new System.Drawing.Size(142, 48);
            // 
            // closeCurrentToolStripMenuItem
            // 
            this.closeCurrentToolStripMenuItem.Name = "closeCurrentToolStripMenuItem";
            this.closeCurrentToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.closeCurrentToolStripMenuItem.Text = "Закрыть";
            this.closeCurrentToolStripMenuItem.Click += new System.EventHandler(this.closeCurrentToolStripMenuItem_Click);
            // 
            // closeAllToolStripMenuItem
            // 
            this.closeAllToolStripMenuItem.Name = "closeAllToolStripMenuItem";
            this.closeAllToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.closeAllToolStripMenuItem.Text = "Закрыть все";
            this.closeAllToolStripMenuItem.Click += new System.EventHandler(this.closeAllToolStripMenuItem_Click);
            // 
            // parseToolStripMenuItem
            // 
            this.parseToolStripMenuItem.Name = "parseToolStripMenuItem";
            this.parseToolStripMenuItem.Size = new System.Drawing.Size(126, 20);
            this.parseToolStripMenuItem.Text = "Загрузить из файла";
            this.parseToolStripMenuItem.Click += new System.EventHandler(this.parseToolStripMenuItem_Click);
            // 
            // admMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 552);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "admMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdmMainForm";
            this.panel1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.cmsTabs.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.Button btnAddStudents;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Button btnAddTeachers;
        private System.Windows.Forms.Button btnAddGroups;
        private System.Windows.Forms.Button btnAddDisciplines;
        private System.Windows.Forms.ContextMenuStrip cmsTabs;
        private System.Windows.Forms.ToolStripMenuItem closeCurrentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parseToolStripMenuItem;
    }
}