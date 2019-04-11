namespace PointRaitingSystem
{
    partial class usrReExamFrom
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
            this.dgvStudentsCPs = new System.Windows.Forms.DataGridView();
            this.btnCommit = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tpCP = new System.Windows.Forms.TabPage();
            this.gbCPInfo = new System.Windows.Forms.GroupBox();
            this.lblWeight = new System.Windows.Forms.Label();
            this.lblDiscipline = new System.Windows.Forms.Label();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tpExams = new System.Windows.Forms.TabPage();
            this.dgvExams = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudentsCPs)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tpCP.SuspendLayout();
            this.gbCPInfo.SuspendLayout();
            this.tpExams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExams)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvStudentsCPs
            // 
            this.dgvStudentsCPs.AllowUserToAddRows = false;
            this.dgvStudentsCPs.AllowUserToDeleteRows = false;
            this.dgvStudentsCPs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudentsCPs.Dock = System.Windows.Forms.DockStyle.Right;
            this.dgvStudentsCPs.Location = new System.Drawing.Point(324, 3);
            this.dgvStudentsCPs.Margin = new System.Windows.Forms.Padding(2);
            this.dgvStudentsCPs.Name = "dgvStudentsCPs";
            this.dgvStudentsCPs.RowHeadersVisible = false;
            this.dgvStudentsCPs.RowTemplate.Height = 24;
            this.dgvStudentsCPs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.ColumnHeaderSelect;
            this.dgvStudentsCPs.Size = new System.Drawing.Size(720, 364);
            this.dgvStudentsCPs.TabIndex = 0;
            this.dgvStudentsCPs.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStudentsCPs_CellEndEdit);
            this.dgvStudentsCPs.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvStudentsCPs_ColumnHeaderMouseClick);
            // 
            // btnCommit
            // 
            this.btnCommit.Location = new System.Drawing.Point(948, 401);
            this.btnCommit.Margin = new System.Windows.Forms.Padding(2);
            this.btnCommit.Name = "btnCommit";
            this.btnCommit.Size = new System.Drawing.Size(103, 23);
            this.btnCommit.TabIndex = 1;
            this.btnCommit.Text = "Принять";
            this.btnCommit.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(841, 401);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(103, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslInfo});
            this.statusStrip1.Location = new System.Drawing.Point(0, 435);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1055, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslInfo
            // 
            this.tsslInfo.Name = "tsslInfo";
            this.tsslInfo.Size = new System.Drawing.Size(13, 17);
            this.tsslInfo.Text = "1";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tpCP);
            this.tabControl.Controls.Add(this.tpExams);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl.HotTrack = true;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1055, 396);
            this.tabControl.TabIndex = 4;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tpCP
            // 
            this.tpCP.Controls.Add(this.gbCPInfo);
            this.tpCP.Controls.Add(this.dgvStudentsCPs);
            this.tpCP.Location = new System.Drawing.Point(4, 22);
            this.tpCP.Name = "tpCP";
            this.tpCP.Padding = new System.Windows.Forms.Padding(3);
            this.tpCP.Size = new System.Drawing.Size(1047, 370);
            this.tpCP.TabIndex = 0;
            this.tpCP.Text = "КТ";
            this.tpCP.UseVisualStyleBackColor = true;
            // 
            // gbCPInfo
            // 
            this.gbCPInfo.Controls.Add(this.lblWeight);
            this.gbCPInfo.Controls.Add(this.lblDiscipline);
            this.gbCPInfo.Controls.Add(this.lblAuthor);
            this.gbCPInfo.Controls.Add(this.txtDescription);
            this.gbCPInfo.Controls.Add(this.label6);
            this.gbCPInfo.Controls.Add(this.label5);
            this.gbCPInfo.Controls.Add(this.label3);
            this.gbCPInfo.Controls.Add(this.label2);
            this.gbCPInfo.Location = new System.Drawing.Point(8, 6);
            this.gbCPInfo.Name = "gbCPInfo";
            this.gbCPInfo.Size = new System.Drawing.Size(311, 358);
            this.gbCPInfo.TabIndex = 9;
            this.gbCPInfo.TabStop = false;
            this.gbCPInfo.Text = "Описание контрольной точки:";
            this.gbCPInfo.Visible = false;
            // 
            // lblWeight
            // 
            this.lblWeight.AutoSize = true;
            this.lblWeight.Location = new System.Drawing.Point(94, 80);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(0, 13);
            this.lblWeight.TabIndex = 7;
            // 
            // lblDiscipline
            // 
            this.lblDiscipline.AutoSize = true;
            this.lblDiscipline.Location = new System.Drawing.Point(94, 55);
            this.lblDiscipline.Name = "lblDiscipline";
            this.lblDiscipline.Size = new System.Drawing.Size(0, 13);
            this.lblDiscipline.TabIndex = 6;
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Location = new System.Drawing.Point(94, 29);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(0, 13);
            this.lblAuthor.TabIndex = 5;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(97, 105);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(208, 58);
            this.txtDescription.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Описание";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Вес";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Дисциплина";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Создана";
            // 
            // tpExams
            // 
            this.tpExams.Controls.Add(this.dgvExams);
            this.tpExams.Location = new System.Drawing.Point(4, 22);
            this.tpExams.Name = "tpExams";
            this.tpExams.Padding = new System.Windows.Forms.Padding(3);
            this.tpExams.Size = new System.Drawing.Size(1047, 370);
            this.tpExams.TabIndex = 1;
            this.tpExams.Text = "Экзамен";
            this.tpExams.UseVisualStyleBackColor = true;
            // 
            // dgvExams
            // 
            this.dgvExams.AllowUserToAddRows = false;
            this.dgvExams.AllowUserToDeleteRows = false;
            this.dgvExams.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExams.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvExams.Location = new System.Drawing.Point(3, 3);
            this.dgvExams.Margin = new System.Windows.Forms.Padding(2);
            this.dgvExams.Name = "dgvExams";
            this.dgvExams.RowHeadersVisible = false;
            this.dgvExams.RowTemplate.Height = 24;
            this.dgvExams.Size = new System.Drawing.Size(1041, 364);
            this.dgvExams.TabIndex = 1;
            this.dgvExams.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvExams_CellBeginEdit);
            this.dgvExams.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvExams_CellEndEdit);
            // 
            // usrReExamFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1055, 457);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnCommit);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "usrReExamFrom";
            this.Text = "usrReExamFrom";
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudentsCPs)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tpCP.ResumeLayout(false);
            this.gbCPInfo.ResumeLayout(false);
            this.gbCPInfo.PerformLayout();
            this.tpExams.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExams)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvStudentsCPs;
        private System.Windows.Forms.Button btnCommit;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tpCP;
        private System.Windows.Forms.TabPage tpExams;
        private System.Windows.Forms.DataGridView dgvExams;
        private System.Windows.Forms.ToolStripStatusLabel tsslInfo;
        private System.Windows.Forms.GroupBox gbCPInfo;
        private System.Windows.Forms.Label lblWeight;
        private System.Windows.Forms.Label lblDiscipline;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}