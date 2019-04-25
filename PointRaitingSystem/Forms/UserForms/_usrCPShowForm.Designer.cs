namespace PointRaitingSystem
{
    partial class usrCPShowForm
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
            this.dgvControlPoints = new System.Windows.Forms.DataGridView();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.lblDiscipline = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvControlPoints)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvControlPoints
            // 
            this.dgvControlPoints.AllowUserToAddRows = false;
            this.dgvControlPoints.AllowUserToDeleteRows = false;
            this.dgvControlPoints.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvControlPoints.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgvControlPoints.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvControlPoints.Location = new System.Drawing.Point(0, 0);
            this.dgvControlPoints.MultiSelect = false;
            this.dgvControlPoints.Name = "dgvControlPoints";
            this.dgvControlPoints.ReadOnly = true;
            this.dgvControlPoints.RowHeadersVisible = false;
            this.dgvControlPoints.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvControlPoints.ShowCellErrors = false;
            this.dgvControlPoints.ShowRowErrors = false;
            this.dgvControlPoints.Size = new System.Drawing.Size(408, 272);
            this.dgvControlPoints.TabIndex = 0;
            this.dgvControlPoints.SelectionChanged += new System.EventHandler(this.dgvControlPoints_SelectionChanged);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(427, 113);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(188, 146);
            this.txtDescription.TabIndex = 1;
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblAuthor.Location = new System.Drawing.Point(428, 13);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(0, 15);
            this.lblAuthor.TabIndex = 2;
            // 
            // lblDiscipline
            // 
            this.lblDiscipline.AutoSize = true;
            this.lblDiscipline.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDiscipline.Location = new System.Drawing.Point(427, 54);
            this.lblDiscipline.Name = "lblDiscipline";
            this.lblDiscipline.Size = new System.Drawing.Size(0, 15);
            this.lblDiscipline.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(428, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Описание:";
            // 
            // usrCPShowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 272);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblDiscipline);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.dgvControlPoints);
            this.Name = "usrCPShowForm";
            this.Text = "childForm2";
            ((System.ComponentModel.ISupportInitialize)(this.dgvControlPoints)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvControlPoints;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.Label lblDiscipline;
        private System.Windows.Forms.Label label3;
    }
}