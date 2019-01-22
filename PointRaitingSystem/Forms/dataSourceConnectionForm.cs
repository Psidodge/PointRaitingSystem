using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MainLib;

namespace PointRaitingSystem
{
    public partial class dataSourceConnectionForm : Form
    {
        private SQLworker sqlConnectionHandler;
        private ErrorLogger errorLogger;

        private bool isServerPicked = false,
                     isCanceld = false;

        public dataSourceConnectionForm(ref ErrorLogger errLogger)
        {
            InitializeComponent();
            this.errorLogger = errLogger;
        }
        public dataSourceConnectionForm(ref SQLworker sqlHandler, ref ErrorLogger errLogger)
        {
            InitializeComponent();
            this.sqlConnectionHandler = sqlHandler;
            this.errorLogger = errLogger;
        }

        private void cbISValidSqlServer_CheckedChanged(object sender, EventArgs e)
        {
            this.txtPassword.ReadOnly = this.checkbIsValidSqlServer.Checked;
            this.txtUserName.ReadOnly = this.checkbIsValidSqlServer.Checked;
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            sqlConnectionHandler.CreateConnection(this.cbServerPick.SelectedItem.ToString(), this.cbDbPick.SelectedItem.ToString());
            Properties.Settings.Default.ConnectionString = sqlConnectionHandler.GetConnectionString;
            Properties.Settings.Default.Save();
            this.sqlConnectionHandler.OpenConnection();
            this.Close();
        }
        private void btnCheckConnetion_Click(object sender, EventArgs e)
        {
            sqlConnectionHandler.CreateConnection(this.cbServerPick.SelectedItem.ToString(), this.cbDbPick.SelectedItem.ToString());
            if (sqlConnectionHandler.CheckConnection())
                MessageBox.Show("Соединение установлено.", "Успешно!", MessageBoxButtons.OK);
            else
                MessageBox.Show("Возникла ошибка при установлении соединения.", "Безуспешно!", MessageBoxButtons.OK);
        }

        private void cbServerPick_DropDown(object sender, EventArgs e)
        {
            if (this.cbServerPick.Items.Count == 0)
            {
                this.cbServerPick.Items.Add("Идет загрузка списка имен");
                this.bwSQLServerListQuery.RunWorkerAsync();
            }
        }
        private void cbDbPick_DropDown(object sender, EventArgs e)
        {
            string serverName;

            if (this.cbDbPick.Items.Count == 0 && isServerPicked)
            {
                serverName = this.cbServerPick.SelectedItem.ToString();
                this.cbDbPick.Items.Add("Идет загрузка списка имен");
                this.bwSQLListOfDatabasesQuery.RunWorkerAsync();
            }
        }

        private void bwSQLServerListQuery_DoWork(object sender, DoWorkEventArgs e)
        {
            List<string> tempList;
            try
            {
                tempList = this.sqlConnectionHandler.GetListOfServers();
                this.Invoke((MethodInvoker)delegate ()
                {
                    this.cbServerPick.Items.Clear();
                    this.cbServerPick.Items.AddRange(tempList.ToArray());
                    isServerPicked = true;
                });
                }
            catch (Exception ex)
            {
                errorLogger.ErrorStackTrace(ex.StackTrace.Trim());
                errorLogger.Error(this, ex.Message);
            }
        }
        private void bwSQLListOfDatabasesQuery_DoWork(object sender, DoWorkEventArgs e)
        {
            string _serverName = null;


            this.Invoke((MethodInvoker)delegate ()
            {
                _serverName = this.cbServerPick.SelectedItem.ToString();
            });

            if (_serverName == null)
                return;
            List<string> tempList;

            try
            {
                tempList = this.sqlConnectionHandler.GetListOfDatabases(_serverName);
                this.Invoke((MethodInvoker)delegate ()
                {
                    this.cbDbPick.Items.Clear();
                    this.cbDbPick.Items.AddRange(tempList.ToArray());
                });
            }
            catch(Exception ex)
            {
                errorLogger.ErrorStackTrace(ex.StackTrace.Trim());
                errorLogger.Error(this, ex.Message);
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            isCanceld = true;
            this.Close();
        }

        public bool IsCanceld { get => this.isCanceld; }
    }
}
