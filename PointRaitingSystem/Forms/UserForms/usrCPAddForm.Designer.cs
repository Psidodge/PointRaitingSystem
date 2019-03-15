namespace PointRaitingSystem
{
    partial class usrCPAddForm
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
            this.bsStudents = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.txtCPWeight = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslPointsLeft = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslPointsRemain = new System.Windows.Forms.ToolStripStatusLabel();
            this.cbDiscipline = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblValidationInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsStudents)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Дисциплина";
            // 
            // txtCPWeight
            // 
            this.txtCPWeight.Location = new System.Drawing.Point(141, 39);
            this.txtCPWeight.Margin = new System.Windows.Forms.Padding(4);
            this.txtCPWeight.Name = "txtCPWeight";
            this.txtCPWeight.Size = new System.Drawing.Size(45, 22);
            this.txtCPWeight.TabIndex = 5;
            this.txtCPWeight.TextChanged += new System.EventHandler(this.txtCPWeight_TextChanged);
            this.txtCPWeight.Validating += new System.ComponentModel.CancelEventHandler(this.txtCPWeight_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 43);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Вес КТ";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(141, 70);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(243, 110);
            this.txtDescription.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 74);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Описание";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslPointsLeft,
            this.toolStripStatusLabel1,
            this.tsslPointsRemain});
            this.statusStrip1.Location = new System.Drawing.Point(0, 229);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(401, 25);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslPointsLeft
            // 
            this.tsslPointsLeft.Name = "tsslPointsLeft";
            this.tsslPointsLeft.Size = new System.Drawing.Size(114, 20);
            this.tsslPointsLeft.Text = "Использовано:";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(185, 20);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // tsslPointsRemain
            // 
            this.tsslPointsRemain.Name = "tsslPointsRemain";
            this.tsslPointsRemain.Size = new System.Drawing.Size(82, 20);
            this.tsslPointsRemain.Text = "Останется:";
            // 
            // cbDiscipline
            // 
            this.cbDiscipline.FormattingEnabled = true;
            this.cbDiscipline.Location = new System.Drawing.Point(141, 7);
            this.cbDiscipline.Margin = new System.Windows.Forms.Padding(4);
            this.cbDiscipline.Name = "cbDiscipline";
            this.cbDiscipline.Size = new System.Drawing.Size(243, 24);
            this.cbDiscipline.TabIndex = 11;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(285, 188);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 28);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblValidationInfo
            // 
            this.lblValidationInfo.AutoSize = true;
            this.lblValidationInfo.Location = new System.Drawing.Point(8, 194);
            this.lblValidationInfo.Name = "lblValidationInfo";
            this.lblValidationInfo.Size = new System.Drawing.Size(0, 17);
            this.lblValidationInfo.TabIndex = 14;
            // 
            // usrCPAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 254);
            this.Controls.Add(this.lblValidationInfo);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cbDiscipline);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCPWeight);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "usrCPAddForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "childForm";
            ((System.ComponentModel.ISupportInitialize)(this.bsStudents)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource bsStudents;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCPWeight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslPointsLeft;
        private System.Windows.Forms.ComboBox cbDiscipline;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tsslPointsRemain;
        private System.Windows.Forms.Label lblValidationInfo;
    }
}