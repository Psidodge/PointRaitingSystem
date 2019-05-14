namespace PointRaitingSystem
{
    partial class usrTemplateList
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
            this.clbTemplates = new System.Windows.Forms.CheckedListBox();
            this.clbContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiAddNewTemplate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEditTemplate = new System.Windows.Forms.ToolStripMenuItem();
            this.tssmDeleteSelecteTemplate = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCommit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslPointsLeft = new System.Windows.Forms.ToolStripStatusLabel();
            this.clbContextMenuStrip.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // clbTemplates
            // 
            this.clbTemplates.ContextMenuStrip = this.clbContextMenuStrip;
            this.clbTemplates.Dock = System.Windows.Forms.DockStyle.Top;
            this.clbTemplates.FormattingEnabled = true;
            this.clbTemplates.Location = new System.Drawing.Point(0, 0);
            this.clbTemplates.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.clbTemplates.Name = "clbTemplates";
            this.clbTemplates.Size = new System.Drawing.Size(437, 361);
            this.clbTemplates.TabIndex = 0;
            this.clbTemplates.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbTemplates_ItemCheck);
            this.clbTemplates.KeyDown += new System.Windows.Forms.KeyEventHandler(this.clbTemplates_KeyDown);
            // 
            // clbContextMenuStrip
            // 
            this.clbContextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.clbContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAddNewTemplate,
            this.tsmiEditTemplate,
            this.tssmDeleteSelecteTemplate});
            this.clbContextMenuStrip.Name = "clbContextMenuStrip";
            this.clbContextMenuStrip.Size = new System.Drawing.Size(211, 104);
            // 
            // tsmiAddNewTemplate
            // 
            this.tsmiAddNewTemplate.Name = "tsmiAddNewTemplate";
            this.tsmiAddNewTemplate.Size = new System.Drawing.Size(210, 24);
            this.tsmiAddNewTemplate.Text = "Добавить";
            this.tsmiAddNewTemplate.Click += new System.EventHandler(this.tsmiAddNewTemplate_Click);
            // 
            // tsmiEditTemplate
            // 
            this.tsmiEditTemplate.Name = "tsmiEditTemplate";
            this.tsmiEditTemplate.Size = new System.Drawing.Size(210, 24);
            this.tsmiEditTemplate.Text = "Редактировать";
            this.tsmiEditTemplate.Click += new System.EventHandler(this.tsmiEditTemplate_Click);
            // 
            // tssmDeleteSelecteTemplate
            // 
            this.tssmDeleteSelecteTemplate.Name = "tssmDeleteSelecteTemplate";
            this.tssmDeleteSelecteTemplate.Size = new System.Drawing.Size(210, 24);
            this.tssmDeleteSelecteTemplate.Text = "Удалить";
            this.tssmDeleteSelecteTemplate.Click += new System.EventHandler(this.tssmDeleteSelecteTemplate_Click);
            // 
            // btnCommit
            // 
            this.btnCommit.Location = new System.Drawing.Point(303, 384);
            this.btnCommit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCommit.Name = "btnCommit";
            this.btnCommit.Size = new System.Drawing.Size(123, 26);
            this.btnCommit.TabIndex = 1;
            this.btnCommit.Text = "Принять";
            this.btnCommit.UseVisualStyleBackColor = true;
            this.btnCommit.Click += new System.EventHandler(this.btnCommit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(12, 384);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(123, 26);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Назад";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslPointsLeft});
            this.statusStrip1.Location = new System.Drawing.Point(0, 418);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(437, 25);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslPointsLeft
            // 
            this.tsslPointsLeft.Name = "tsslPointsLeft";
            this.tsslPointsLeft.Size = new System.Drawing.Size(130, 20);
            this.tsslPointsLeft.Text = "Осталось баллов:";
            // 
            // usrTemplateList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 443);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCommit);
            this.Controls.Add(this.clbTemplates);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "usrTemplateList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "usrTemplateList";
            this.Load += new System.EventHandler(this.usrTemplateList_Load);
            this.clbContextMenuStrip.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox clbTemplates;
        private System.Windows.Forms.Button btnCommit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ContextMenuStrip clbContextMenuStrip;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslPointsLeft;
        private System.Windows.Forms.ToolStripMenuItem tssmDeleteSelecteTemplate;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddNewTemplate;
        private System.Windows.Forms.ToolStripMenuItem tsmiEditTemplate;
    }
}