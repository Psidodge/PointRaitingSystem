namespace PointRaitingSystem
{
    partial class usrCertReportGenForm
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
            this.lbListOfCerts = new System.Windows.Forms.ListBox();
            this.btnGenerateReport = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbListOfCerts
            // 
            this.lbListOfCerts.FormattingEnabled = true;
            this.lbListOfCerts.Location = new System.Drawing.Point(12, 12);
            this.lbListOfCerts.Name = "lbListOfCerts";
            this.lbListOfCerts.Size = new System.Drawing.Size(120, 160);
            this.lbListOfCerts.TabIndex = 0;
            // 
            // btnGenerateReport
            // 
            this.btnGenerateReport.Location = new System.Drawing.Point(139, 13);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(100, 23);
            this.btnGenerateReport.TabIndex = 1;
            this.btnGenerateReport.Text = "Сформирвоать";
            this.btnGenerateReport.UseVisualStyleBackColor = true;
            this.btnGenerateReport.Click += new System.EventHandler(this.btnGenerateReport_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 175);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 13);
            this.lblStatus.TabIndex = 2;
            // 
            // usrCertReportGenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(246, 194);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnGenerateReport);
            this.Controls.Add(this.lbListOfCerts);
            this.Name = "usrCertReportGenForm";
            this.Text = "usrCertReportGenForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbListOfCerts;
        private System.Windows.Forms.Button btnGenerateReport;
        private System.Windows.Forms.Label lblStatus;
    }
}