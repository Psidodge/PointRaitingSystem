namespace PointRaitingSystem
{
    partial class tabDisciplines
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvDisciplines = new System.Windows.Forms.DataGridView();
            this.isNew = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnLoadFromEXCEL = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtSemestr = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDisciplines)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDisciplines
            // 
            this.dgvDisciplines.AllowUserToAddRows = false;
            this.dgvDisciplines.AllowUserToDeleteRows = false;
            this.dgvDisciplines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDisciplines.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.isNew});
            this.dgvDisciplines.Dock = System.Windows.Forms.DockStyle.Right;
            this.dgvDisciplines.Location = new System.Drawing.Point(228, 0);
            this.dgvDisciplines.MultiSelect = false;
            this.dgvDisciplines.Name = "dgvDisciplines";
            this.dgvDisciplines.ReadOnly = true;
            this.dgvDisciplines.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dgvDisciplines.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDisciplines.Size = new System.Drawing.Size(410, 484);
            this.dgvDisciplines.TabIndex = 2;
            this.dgvDisciplines.SelectionChanged += new System.EventHandler(this.dgvDisciplines_SelectionChanged);
            // 
            // isNew
            // 
            this.isNew.HeaderText = "Новая";
            this.isNew.Name = "isNew";
            this.isNew.ReadOnly = true;
            this.isNew.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.isNew.ToolTipText = "Показывает новые записи";
            this.isNew.Width = 45;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(35, 122);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(151, 23);
            this.btnUpdate.TabIndex = 6;
            this.btnUpdate.Text = "Изменить";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(35, 93);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(151, 23);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnLoadFromEXCEL
            // 
            this.btnLoadFromEXCEL.Location = new System.Drawing.Point(38, 3);
            this.btnLoadFromEXCEL.Name = "btnLoadFromEXCEL";
            this.btnLoadFromEXCEL.Size = new System.Drawing.Size(151, 23);
            this.btnLoadFromEXCEL.TabIndex = 4;
            this.btnLoadFromEXCEL.Text = "Загрузить из файла";
            this.btnLoadFromEXCEL.UseVisualStyleBackColor = true;
            this.btnLoadFromEXCEL.Click += new System.EventHandler(this.btnLoadFromEXCEL_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Семестр";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(64, 17);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(28, 20);
            this.txtId.TabIndex = 9;
            // 
            // txtSemestr
            // 
            this.txtSemestr.Location = new System.Drawing.Point(64, 67);
            this.txtSemestr.Name = "txtSemestr";
            this.txtSemestr.Size = new System.Drawing.Size(28, 20);
            this.txtSemestr.TabIndex = 10;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(64, 41);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(130, 20);
            this.txtName.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Название";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.Controls.Add(this.txtSemestr);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtId);
            this.groupBox1.Location = new System.Drawing.Point(3, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(219, 163);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Дисциплина";
            // 
            // tabDisciplines
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnLoadFromEXCEL);
            this.Controls.Add(this.dgvDisciplines);
            this.Name = "tabDisciplines";
            this.Size = new System.Drawing.Size(638, 484);
            this.Load += new System.EventHandler(this.tabDisciplines_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDisciplines)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDisciplines;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isNew;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnLoadFromEXCEL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtSemestr;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
