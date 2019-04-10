namespace PointRaitingSystem.Forms.UserForms
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
            this.dgvStudentsReExams = new System.Windows.Forms.DataGridView();
            this.btnCommit = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudentsReExams)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvStudentsReExams
            // 
            this.dgvStudentsReExams.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudentsReExams.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvStudentsReExams.Location = new System.Drawing.Point(0, 0);
            this.dgvStudentsReExams.Name = "dgvStudentsReExams";
            this.dgvStudentsReExams.RowTemplate.Height = 24;
            this.dgvStudentsReExams.Size = new System.Drawing.Size(840, 424);
            this.dgvStudentsReExams.TabIndex = 0;
            // 
            // btnCommit
            // 
            this.btnCommit.Location = new System.Drawing.Point(691, 436);
            this.btnCommit.Name = "btnCommit";
            this.btnCommit.Size = new System.Drawing.Size(137, 28);
            this.btnCommit.TabIndex = 1;
            this.btnCommit.Text = "Принять";
            this.btnCommit.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(691, 470);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(137, 28);
            this.button2.TabIndex = 2;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Location = new System.Drawing.Point(0, 505);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(840, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // usrReExamFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 527);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnCommit);
            this.Controls.Add(this.dgvStudentsReExams);
            this.Name = "usrReExamFrom";
            this.Text = "usrReExamFrom";
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudentsReExams)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvStudentsReExams;
        private System.Windows.Forms.Button btnCommit;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.StatusStrip statusStrip1;
    }
}