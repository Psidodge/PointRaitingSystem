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
            this.btnCommit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.clbContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SuspendLayout();
            // 
            // clbTemplates
            // 
            this.clbTemplates.ContextMenuStrip = this.clbContextMenuStrip;
            this.clbTemplates.Dock = System.Windows.Forms.DockStyle.Top;
            this.clbTemplates.FormattingEnabled = true;
            this.clbTemplates.Location = new System.Drawing.Point(0, 0);
            this.clbTemplates.Name = "clbTemplates";
            this.clbTemplates.Size = new System.Drawing.Size(438, 378);
            this.clbTemplates.TabIndex = 0;
            // 
            // btnCommit
            // 
            this.btnCommit.Location = new System.Drawing.Point(303, 384);
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
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(123, 26);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Назад";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // clbContextMenuStrip
            // 
            this.clbContextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.clbContextMenuStrip.Name = "clbContextMenuStrip";
            this.clbContextMenuStrip.Size = new System.Drawing.Size(61, 4);
            // 
            // usrTemplateList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 419);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCommit);
            this.Controls.Add(this.clbTemplates);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "usrTemplateList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "usrTemplateList";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox clbTemplates;
        private System.Windows.Forms.Button btnCommit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ContextMenuStrip clbContextMenuStrip;
    }
}