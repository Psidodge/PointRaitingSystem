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
            this.привязкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showAllBindingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.delBindingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // clbGroups
            // 
            this.clbGroups.FormattingEnabled = true;
            this.clbGroups.Location = new System.Drawing.Point(8, 59);
            this.clbGroups.Margin = new System.Windows.Forms.Padding(4);
            this.clbGroups.Name = "clbGroups";
            this.clbGroups.Size = new System.Drawing.Size(159, 225);
            this.clbGroups.TabIndex = 0;
            this.clbGroups.SelectedIndexChanged += new System.EventHandler(this.clbGroups_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtGroupsFilter);
            this.groupBox1.Controls.Add(this.clbGroups);
            this.groupBox1.Location = new System.Drawing.Point(16, 33);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(185, 293);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Группы:";
            // 
            // txtGroupsFilter
            // 
            this.txtGroupsFilter.Location = new System.Drawing.Point(9, 27);
            this.txtGroupsFilter.Margin = new System.Windows.Forms.Padding(4);
            this.txtGroupsFilter.Name = "txtGroupsFilter";
            this.txtGroupsFilter.Size = new System.Drawing.Size(157, 22);
            this.txtGroupsFilter.TabIndex = 1;
            this.txtGroupsFilter.TextChanged += new System.EventHandler(this.txtGroupsFilter_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btbBind);
            this.groupBox2.Controls.Add(this.lbDisciplines);
            this.groupBox2.Controls.Add(this.cbDisciplines);
            this.groupBox2.Location = new System.Drawing.Point(209, 33);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(415, 293);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Дисциплины:";
            // 
            // btbBind
            // 
            this.btbBind.Location = new System.Drawing.Point(307, 22);
            this.btbBind.Margin = new System.Windows.Forms.Padding(4);
            this.btbBind.Name = "btbBind";
            this.btbBind.Size = new System.Drawing.Size(100, 28);
            this.btbBind.TabIndex = 2;
            this.btbBind.Text = "Привязать";
            this.btbBind.UseVisualStyleBackColor = true;
            this.btbBind.Click += new System.EventHandler(this.btbBind_Click);
            // 
            // lbDisciplines
            // 
            this.lbDisciplines.FormattingEnabled = true;
            this.lbDisciplines.ItemHeight = 16;
            this.lbDisciplines.Location = new System.Drawing.Point(9, 59);
            this.lbDisciplines.Margin = new System.Windows.Forms.Padding(4);
            this.lbDisciplines.Name = "lbDisciplines";
            this.lbDisciplines.Size = new System.Drawing.Size(396, 228);
            this.lbDisciplines.TabIndex = 1;
            // 
            // cbDisciplines
            // 
            this.cbDisciplines.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbDisciplines.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbDisciplines.FormattingEnabled = true;
            this.cbDisciplines.Location = new System.Drawing.Point(9, 25);
            this.cbDisciplines.Margin = new System.Windows.Forms.Padding(4);
            this.cbDisciplines.Name = "cbDisciplines";
            this.cbDisciplines.Size = new System.Drawing.Size(288, 24);
            this.cbDisciplines.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(416, 329);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 28);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(524, 329);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 28);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.привязкиToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(640, 28);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // привязкиToolStripMenuItem
            // 
            this.привязкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showAllBindingsToolStripMenuItem,
            this.delBindingsToolStripMenuItem});
            this.привязкиToolStripMenuItem.Name = "привязкиToolStripMenuItem";
            this.привязкиToolStripMenuItem.Size = new System.Drawing.Size(89, 24);
            this.привязкиToolStripMenuItem.Text = "Привязки";
            // 
            // showAllBindingsToolStripMenuItem
            // 
            this.showAllBindingsToolStripMenuItem.Name = "showAllBindingsToolStripMenuItem";
            this.showAllBindingsToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.showAllBindingsToolStripMenuItem.Text = "Все привязки";
            this.showAllBindingsToolStripMenuItem.Click += new System.EventHandler(this.showAllBindingsToolStripMenuItem_Click);
            // 
            // delBindingsToolStripMenuItem
            // 
            this.delBindingsToolStripMenuItem.Enabled = false;
            this.delBindingsToolStripMenuItem.Name = "delBindingsToolStripMenuItem";
            this.delBindingsToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.delBindingsToolStripMenuItem.Text = "Удалить привязки";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 384);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(640, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // usrSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 406);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "usrSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройка привязок";
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