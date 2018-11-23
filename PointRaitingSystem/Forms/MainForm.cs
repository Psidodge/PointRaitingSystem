using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MainLib;

namespace PointRaitingSystem
{
    public partial class MainForm : Form
    {
        private SQLworker sqlHandler;
        private ErrorLogger errLogger;

        public MainForm()
        {
            InitializeComponent();
            InitializeSQLworker();
            errLogger = new ErrorLogger();
        }

        private void InitializeSQLworker()
        {
            if (string.IsNullOrEmpty(Properties.Settings.Default.ConnectionString))
                sqlHandler = new SQLworker(ref errLogger);
            else
                sqlHandler = new SQLworker(Properties.Settings.Default.ConnectionString, ref errLogger);

        }
        private void tsmiDataSoruce_Click(object sender, EventArgs e)
        {
            dataSourceConnectionForm form = new dataSourceConnectionForm();
            form.ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // TOREF: Uncoment here
            //LoginForm loginForm = new LoginForm(ref sqlHandler);
            //loginForm.ShowDialog();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.sqlHandler.CloseConnection();
            // TODO: раскоментировать, когда допишу Close() для логгера
            //this.logger.Close();
        }

    }
}
