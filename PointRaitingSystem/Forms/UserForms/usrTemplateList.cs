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
using MainLib.Session;

namespace PointRaitingSystem
{
    public partial class usrTemplateList : Form
    {
        private NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        private int groupID;

        public usrTemplateList(int groupID, int disciplineID)
        {
            InitializeComponent();
            IntializeDataSets(disciplineID);
            this.groupID = groupID;
        }

        private void ClearSelected()
        {
            foreach (int elementIndex in clbTemplates.CheckedIndices)
            {
                clbTemplates.SetItemChecked(elementIndex, false);
            }
        }
        private void IntializeDataSets(int disciplineID)
        {
            try
            {
                List<ControlPointTemplate> templates = DataService.SelectUserControlPointsTemplate(disciplineID, Session.GetCurrentSession().ID);
                DataSetInitializer.clbDataSetInitialize<ControlPointTemplate>(ref clbTemplates, templates, "id", "GetFormatedString");
            }
            catch(Exception ex)
            {
                logger.Error(ex);
            }
        }
        private void btnCommit_Click(object sender, EventArgs e)
        {
            //NOTE: добавить сюда валидацию данных
            //if()
            List<ControlPointTemplate> templates = new List<ControlPointTemplate>();
            List<ControlPoint> points;

            foreach (var element in clbTemplates.CheckedItems)
            {
                templates.Add((ControlPointTemplate)element);
            }

            try
            {
                points = templates.Select(x => x.ConvertToControlPoint()).ToList();
                DataService.InsertIntoCPnStCPFromCPTemplateTransact(ref points, DataService.SelectStudentsByGroupId(groupID));
            }
            catch(Exception ex)
            {
                logger.Error(ex);
            }

            this.Close();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
