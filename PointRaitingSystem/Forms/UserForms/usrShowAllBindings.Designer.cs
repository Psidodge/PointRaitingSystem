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
            this.lbDisciplines = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.cms_lbGroups = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiRemoveGroupBinding = new System.Windows.Forms.ToolStripMenuItem();
            this.cns_lbDisciplines = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiRemoveDisciplineBinding = new System.Windows.Forms.ToolStripMenuItem();
            this.cms_lbGroups.SuspendLayout();
            this.cns_lbDisciplines.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbGroups
            // 
            this.lbGroups.ContextMenuStrip = this.cms_lbGroups;
            this.lbGroups.FormattingEnabled = true;
            this.lbGroups.Location = new System.Drawing.Point(9, 51);
            this.lbGroups.Margin = new System.Windows.Forms.Padding(2);
            this.lbGroups.Name = "lbGroups";
            this.lbGroups.Size = new System.Drawing.Size(106, 134);
            this.lbGroups.TabIndex = 0;
            this.lbGroups.SelectedIndexChanged += new System.EventHandler(this.lbGroups_SelectedIndexChanged);
            this.lbGroups.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbGroups_KeyDown);
            // 
            // lbDisciplines
            // 
            this.lbDisciplines.ContextMenuStrip = this.cns_lbDisciplines;
            this.lbDisciplines.FormattingEnabled = true;
            this.lbDisciplines.Location = new System.Drawing.Point(142, 51);
            this.lbDisciplines.Margin = new System.Windows.Forms.Padding(2);
            this.lbDisciplines.Name = "lbDisciplines";
            this.lbDisciplines.Size = new System.Drawing.Size(252, 134);
            this.lbDisciplines.TabIndex = 1;
            this.lbDisciplines.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbDisciplines_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Группы:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(140, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Дисциплины:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(9, 28);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(106, 20);
            this.textBox1.TabIndex = 4;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(142, 28);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(252, 20);
            this.textBox2.TabIndex = 5;
            // 
            // cms_lbGroups
            // 
            this.cms_lbGroups.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiRemoveGroupBinding});
            this.cms_lbGroups.Name = "cms_lbGroups";
            this.cms_lbGroups.Size = new System.Drawing.Size(119, 26);
            // 
            // tsmiRemoveGroupBinding
            // 
            this.tsmiRemoveGroupBinding.Name = "tsmiRemoveGroupBinding";
            this.tsmiRemoveGroupBinding.Size = new System.Drawing.Size(118, 22);
            this.tsmiRemoveGroupBinding.Text = "Удалить";
            this.tsmiRemoveGroupBinding.Click += new System.EventHandler(this.tsmiRemoveGroupBinding_Click);
            // 
            // cns_lbDisciplines
            // 
            this.cns_lbDisciplines.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiRemoveDisciplineBinding});
            this.cns_lbDisciplines.Name = "contextMenuStrip1";
            this.cns_lbDisciplines.Size = new System.Drawing.Size(119, 26);
            // 
            // tsmiRemoveDisciplineBinding
            // 
            this.tsmiRemoveDisciplineBinding.Name = "tsmiRemoveDisciplineBinding";
            this.tsmiRemoveDisciplineBinding.Size = new System.Drawing.Size(118, 22);
            this.tsmiRemoveDisciplineBinding.Text = "Удалить";
            this.tsmiRemoveDisciplineBinding.Click += new System.EventHandler(this.tsmiRemoveDisciplineBinding_Click);
            // 
            // usrShowAllBindings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 226);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbDisciplines);
            this.Controls.Add(this.lbGroups);
            this.Margin = new System.Windows.Forms.Padding(2);
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
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ContextMenuStrip cms_lbGroups;
        private System.Windows.Forms.ContextMenuStrip cns_lbDisciplines;
        private System.Windows.Forms.ToolStripMenuItem tsmiRemoveGroupBinding;
        private System.Windows.Forms.ToolStripMenuItem tsmiRemoveDisciplineBinding;
    }
}