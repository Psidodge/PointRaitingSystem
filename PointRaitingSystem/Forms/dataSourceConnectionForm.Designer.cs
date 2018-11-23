namespace PointRaitingSystem
{
    partial class dataSourceConnectionForm
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
            this.cbServerPick = new System.Windows.Forms.ComboBox();
            this.cbDbPick = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkbIsValidSqlServer = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCheckConnetion = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.bwSQLServerListQuery = new System.ComponentModel.BackgroundWorker();
            this.bwSQLListOfDatabasesQuery = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbServerPick
            // 
            this.cbServerPick.FormattingEnabled = true;
            this.cbServerPick.Location = new System.Drawing.Point(143, 82);
            this.cbServerPick.Name = "cbServerPick";
            this.cbServerPick.Size = new System.Drawing.Size(234, 24);
            this.cbServerPick.TabIndex = 2;
            this.cbServerPick.DropDown += new System.EventHandler(this.cbServerPick_DropDown);
            // 
            // cbDbPick
            // 
            this.cbDbPick.FormattingEnabled = true;
            this.cbDbPick.Location = new System.Drawing.Point(158, 197);
            this.cbDbPick.Name = "cbDbPick";
            this.cbDbPick.Size = new System.Drawing.Size(234, 24);
            this.cbDbPick.TabIndex = 3;
            this.cbDbPick.DropDown += new System.EventHandler(this.cbDbPick_DropDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Имя сервера";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 200);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Имя базы данных";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(143, 112);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.ReadOnly = true;
            this.txtUserName.Size = new System.Drawing.Size(234, 22);
            this.txtUserName.TabIndex = 6;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(143, 140);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.ReadOnly = true;
            this.txtPassword.Size = new System.Drawing.Size(234, 22);
            this.txtPassword.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkbIsValidSqlServer);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.cbServerPick);
            this.groupBox1.Controls.Add(this.txtUserName);
            this.groupBox1.Location = new System.Drawing.Point(15, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(390, 179);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Сервер";
            // 
            // checkbIsValidSqlServer
            // 
            this.checkbIsValidSqlServer.AutoSize = true;
            this.checkbIsValidSqlServer.Enabled = false;
            this.checkbIsValidSqlServer.Location = new System.Drawing.Point(11, 31);
            this.checkbIsValidSqlServer.Name = "checkbIsValidSqlServer";
            this.checkbIsValidSqlServer.Size = new System.Drawing.Size(260, 21);
            this.checkbIsValidSqlServer.TabIndex = 10;
            this.checkbIsValidSqlServer.Text = "Проверка подлинности SQL server";
            this.checkbIsValidSqlServer.UseVisualStyleBackColor = true;
            this.checkbIsValidSqlServer.CheckedChanged += new System.EventHandler(this.cbISValidSqlServer_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Пароль";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Имя пользователя";
            // 
            // btnCheckConnetion
            // 
            this.btnCheckConnetion.Location = new System.Drawing.Point(15, 229);
            this.btnCheckConnetion.Name = "btnCheckConnetion";
            this.btnCheckConnetion.Size = new System.Drawing.Size(189, 30);
            this.btnCheckConnetion.TabIndex = 9;
            this.btnCheckConnetion.Text = "Проверить подключение";
            this.btnCheckConnetion.UseVisualStyleBackColor = true;
            this.btnCheckConnetion.Click += new System.EventHandler(this.btnCheckConnetion_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(295, 263);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(97, 28);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(295, 229);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(97, 28);
            this.btnOk.TabIndex = 11;
            this.btnOk.Text = "Ок";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // bwSQLServerListQuery
            // 
            this.bwSQLServerListQuery.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwSQLServerListQuery_DoWork);
            // 
            // bwSQLListOfDatabasesQuery
            // 
            this.bwSQLListOfDatabasesQuery.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwSQLListOfDatabasesQuery_DoWork);
            // 
            // dataSourceConnectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 298);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCheckConnetion);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbDbPick);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "dataSourceConnectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Подключение истоника данных";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbServerPick;
        private System.Windows.Forms.ComboBox cbDbPick;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCheckConnetion;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.CheckBox checkbIsValidSqlServer;
        private System.ComponentModel.BackgroundWorker bwSQLServerListQuery;
        private System.ComponentModel.BackgroundWorker bwSQLListOfDatabasesQuery;
    }
}