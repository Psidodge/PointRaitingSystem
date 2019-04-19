using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MainLib.DBServices;

namespace PointRaitingSystem
{
    public partial class usrTemplateListRankingForm : Form
    {
        private NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        private List<ControlPointTemplate> pointTemplates;
        private bool isCanceld = true;

        public bool IsCanceld { get => isCanceld; }

        public usrTemplateListRankingForm(ref List<ControlPointTemplate> templates)
        {
            InitializeComponent();
            pointTemplates = templates;
            try
            {
                DataSetInitializer.lbDataSetInitialize(ref lbTemplates, templates, "id", "GetFormatedString");
            }
            catch(Exception ex)
            {
                logger.Error(ex);
            }

        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            if (lbTemplates.SelectedIndex == 0)
                return;

            pointTemplates.Insert(lbTemplates.SelectedIndex - 1, (ControlPointTemplate)lbTemplates.SelectedItem);
            pointTemplates.RemoveAt(lbTemplates.SelectedIndex + 1);
            lbTemplates.SelectedIndex = lbTemplates.SelectedIndex - 1;
            DataSetInitializer.lbDataSetInitialize(ref lbTemplates, pointTemplates, "id", "GetFormatedString");
        }
        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            if (lbTemplates.SelectedIndex == pointTemplates.Count - 1)
                return;

            pointTemplates.Insert(lbTemplates.SelectedIndex + 2, (ControlPointTemplate)lbTemplates.SelectedItem);
            pointTemplates.RemoveAt(lbTemplates.SelectedIndex);
            lbTemplates.SelectedIndex = lbTemplates.SelectedIndex + 1;
            //lbTemplates.DataSource = pointTemplates;
            //lbTemplates.Refresh();
            DataSetInitializer.lbDataSetInitialize(ref lbTemplates, pointTemplates, "id", "GetFormatedString");
        }
        private void btnAccept_Click(object sender, EventArgs e)
        {
            isCanceld = false;
            this.Close();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
