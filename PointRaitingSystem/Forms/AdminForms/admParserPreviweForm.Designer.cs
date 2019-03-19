namespace PointRaitingSystem
{
    partial class admParserPreviweForm
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
            this.dgvPreviewData = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreviewData)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPreviewData
            // 
            this.dgvPreviewData.AllowUserToAddRows = false;
            this.dgvPreviewData.AllowUserToDeleteRows = false;
            this.dgvPreviewData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPreviewData.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvPreviewData.Location = new System.Drawing.Point(0, 0);
            this.dgvPreviewData.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvPreviewData.Name = "dgvPreviewData";
            this.dgvPreviewData.Size = new System.Drawing.Size(1092, 426);
            this.dgvPreviewData.TabIndex = 0;
            this.dgvPreviewData.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPreviewData_CellEndEdit);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(924, 438);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(152, 28);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(764, 438);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(152, 28);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // admParserPreviweForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1092, 474);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvPreviewData);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "admParserPreviweForm";
            this.Text = "Предпросмотр";
            this.Load += new System.EventHandler(this.admParserPreviweForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreviewData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPreviewData;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}