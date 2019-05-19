namespace PointRaitingSystem
{
    partial class usrShowAllBindings
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
            this.lbGroups = new System.Windows.Forms.ListBox();
            this.cms_lbGroups = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiRemoveGroupBinding = new System.Windows.Forms.ToolStripMenuItem();
            this.lbDisciplines = new System.Windows.Forms.ListBox();
            this.cns_lbDisciplines = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiRemoveDisciplineBinding = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtGroupsFilter = new System.Windows.Forms.TextBox();
            this.txtDisciplinesFilter = new System.Windows.Forms.TextBox();
            this.cms_lbGroups.SuspendLayout();
            this.cns_lbDisciplines.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbGroups
            // 
            this.lbGroups.ContextMenuStrip = this.cms_lbGroups;
            this.lbGroups.FormattingEnabled = true;
            this.lbGroups.ItemHeight = 16;
            this.lbGroups.Location = new System.Drawing.Point(12, 63);
            this.lbGroups.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbGroups.Name = "lbGroups";
            this.lbGroups.Size = new System.Drawing.Size(140, 164);
            this.lbGroups.TabIndex = 0;
            this.lbGroups.SelectedIndexChanged += new System.EventHandler(this.lbGroups_SelectedIndexChanged);
            this.lbGroups.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbGroups_KeyDown);
            // 
            // cms_lbGroups
            // 
            this.cms_lbGroups.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cms_lbGroups.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiRemoveGroupBinding});
            this.cms_lbGroups.Name = "cms_lbGroups";
            this.cms_lbGroups.Size = new System.Drawing.Size(135, 28);
            // 
            // tsmiRemoveGroupBinding
            // 
            this.tsmiRemoveGroupBinding.Name = "tsmiRemoveGroupBinding";
            this.tsmiRemoveGroupBinding.Size = new System.Drawing.Size(134, 24);
            this.tsmiRemoveGroupBinding.Text = "Удалить";
            this.tsmiRemoveGroupBinding.Click += new System.EventHandler(this.tsmiRemoveGroupBinding_Click);
            // 
            // lbDisciplines
            // 
            this.lbDisciplines.ContextMenuStrip = this.cns_lbDisciplines;
            this.lbDisciplines.FormattingEnabled = true;
            this.lbDisciplines.ItemHeight = 16;
            this.lbDisciplines.Location = new System.Drawing.Point(189, 63);
            this.lbDisciplines.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbDisciplines.Name = "lbDisciplines";
            this.lbDisciplines.Size = new System.Drawing.Size(335, 164);
            this.lbDisciplines.TabIndex = 1;
            this.lbDisciplines.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbDisciplines_KeyDown);
            // 
            // cns_lbDisciplines
            // 
            this.cns_lbDisciplines.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cns_lbDisciplines.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiRemoveDisciplineBinding});
            this.cns_lbDisciplines.Name = "contextMenuStrip1";
            this.cns_lbDisciplines.Size = new System.Drawing.Size(135, 28);
            // 
            // tsmiRemoveDisciplineBinding
            // 
            this.tsmiRemoveDisciplineBinding.Name = "tsmiRemoveDisciplineBinding";
            this.tsmiRemoveDisciplineBinding.Size = new System.Drawing.Size(134, 24);
            this.tsmiRemoveDisciplineBinding.Text = "Удалить";
            this.tsmiRemoveDisciplineBinding.Click += new System.EventHandler(this.tsmiRemoveDisciplineBinding_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Группы:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(187, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Дисциплины:";
            // 
            // txtGroupsFilter
            // 
            this.txtGroupsFilter.Location = new System.Drawing.Point(12, 34);
            this.txtGroupsFilter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtGroupsFilter.Name = "txtGroupsFilter";
            this.txtGroupsFilter.Size = new System.Drawing.Size(140, 22);
            this.txtGroupsFilter.TabIndex = 4;
            this.txtGroupsFilter.TextChanged += new System.EventHandler(this.txtGroupsFilter_TextChanged);
            // 
            // txtDisciplinesFilter
            // 
            this.txtDisciplinesFilter.Location = new System.Drawing.Point(189, 34);
            this.txtDisciplinesFilter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDisciplinesFilter.Name = "txtDisciplinesFilter";
            this.txtDisciplinesFilter.Size = new System.Drawing.Size(335, 22);
            this.txtDisciplinesFilter.TabIndex = 5;
            this.txtDisciplinesFilter.TextChanged += new System.EventHandler(this.txtDisciplinesFilter_TextChanged);
            // 
            // usrShowAllBindings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 251);
            this.Controls.Add(this.txtDisciplinesFilter);
            this.Controls.Add(this.txtGroupsFilter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbDisciplines);
            this.Controls.Add(this.lbGroups);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "usrShowAllBindings";
            this.Text = "Просмотр текущих привязок";
            this.cms_lbGroups.ResumeLayout(false);
            this.cns_lbDisciplines.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbGroups;
        private System.Windows.Forms.ListBox lbDisciplines;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtGroupsFilter;
        private System.Windows.Forms.TextBox txtDisciplinesFilter;
        private System.Windows.Forms.ContextMenuStrip cms_lbGroups;
        private System.Windows.Forms.ContextMenuStrip cns_lbDisciplines;
        private System.Windows.Forms.ToolStripMenuItem tsmiRemoveGroupBinding;
        private System.Windows.Forms.ToolStripMenuItem tsmiRemoveDisciplineBinding;
    }
}