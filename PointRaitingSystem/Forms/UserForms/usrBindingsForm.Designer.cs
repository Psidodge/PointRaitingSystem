namespace PointRaitingSystem
{
    partial class usrSettingsForm
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
            this.clbGroups = new System.Windows.Forms.CheckedListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtGroupsFilter = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btbBind = new System.Windows.Forms.Button();
            this.lbDisciplines = new System.Windows.Forms.ListBox();
            this.cbDisciplines = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.привязкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showAllBindingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.delBindingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // clbGroups
            // 
            this.clbGroups.FormattingEnabled = true;
            this.clbGroups.Location = new System.Drawing.Point(6, 48);
            this.clbGroups.Name = "clbGroups";
            this.clbGroups.Size = new System.Drawing.Size(120, 184);
            this.clbGroups.TabIndex = 0;
            this.clbGroups.SelectedIndexChanged += new System.EventHandler(this.clbGroups_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtGroupsFilter);
            this.groupBox1.Controls.Add(this.clbGroups);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(139, 238);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Группы:";
            // 
            // txtGroupsFilter
            // 
            this.txtGroupsFilter.Location = new System.Drawing.Point(7, 22);
            this.txtGroupsFilter.Name = "txtGroupsFilter";
            this.txtGroupsFilter.Size = new System.Drawing.Size(119, 20);
            this.txtGroupsFilter.TabIndex = 1;
            this.txtGroupsFilter.TextChanged += new System.EventHandler(this.txtGroupsFilter_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btbBind);
            this.groupBox2.Controls.Add(this.lbDisciplines);
            this.groupBox2.Controls.Add(this.cbDisciplines);
            this.groupBox2.Location = new System.Drawing.Point(157, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(311, 238);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Дисциплины:";
            // 
            // btbBind
            // 
            this.btbBind.Location = new System.Drawing.Point(230, 18);
            this.btbBind.Name = "btbBind";
            this.btbBind.Size = new System.Drawing.Size(75, 23);
            this.btbBind.TabIndex = 2;
            this.btbBind.Text = "Привязать";
            this.btbBind.UseVisualStyleBackColor = true;
            this.btbBind.Click += new System.EventHandler(this.btbBind_Click);
            // 
            // lbDisciplines
            // 
            this.lbDisciplines.FormattingEnabled = true;
            this.lbDisciplines.Location = new System.Drawing.Point(7, 48);
            this.lbDisciplines.Name = "lbDisciplines";
            this.lbDisciplines.Size = new System.Drawing.Size(298, 186);
            this.lbDisciplines.TabIndex = 1;
            // 
            // cbDisciplines
            // 
            this.cbDisciplines.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbDisciplines.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbDisciplines.FormattingEnabled = true;
            this.cbDisciplines.Location = new System.Drawing.Point(7, 20);
            this.cbDisciplines.Name = "cbDisciplines";
            this.cbDisciplines.Size = new System.Drawing.Size(217, 21);
            this.cbDisciplines.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(312, 267);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(393, 267);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.привязкиToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(480, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 308);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(480, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // привязкиToolStripMenuItem
            // 
            this.привязкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showAllBindingsToolStripMenuItem,
            this.delBindingsToolStripMenuItem});
            this.привязкиToolStripMenuItem.Name = "привязкиToolStripMenuItem";
            this.привязкиToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.привязкиToolStripMenuItem.Text = "Привязки";
            // 
            // showAllBindingsToolStripMenuItem
            // 
            this.showAllBindingsToolStripMenuItem.Name = "showAllBindingsToolStripMenuItem";
            this.showAllBindingsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.showAllBindingsToolStripMenuItem.Text = "Все привязки";
            // 
            // delBindingsToolStripMenuItem
            // 
            this.delBindingsToolStripMenuItem.Name = "delBindingsToolStripMenuItem";
            this.delBindingsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.delBindingsToolStripMenuItem.Text = "Удалить привязки";
            // 
            // usrSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 330);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "usrSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "usrSettingsForm";
            this.Load += new System.EventHandler(this.usrSettingsForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox clbGroups;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtGroupsFilter;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.Button btbBind;
        private System.Windows.Forms.ListBox lbDisciplines;
        private System.Windows.Forms.ComboBox cbDisciplines;
        private System.Windows.Forms.ToolStripMenuItem привязкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showAllBindingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem delBindingsToolStripMenuItem;
    }
}