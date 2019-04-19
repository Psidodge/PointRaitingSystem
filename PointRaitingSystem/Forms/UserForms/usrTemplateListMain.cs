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
        private int groupID, disciplineID;
        private double pointsLeft = 80d,
                       sumOfUsedPoints = 0d;

        public usrTemplateList(int groupID, int disciplineID)
        {
            InitializeComponent();
            this.groupID = groupID;
            this.disciplineID = disciplineID;
            IntializeDataSets(disciplineID);
            tsslPointsLeft.Text = $"Осталось баллов: {pointsLeft}";
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
                sumOfUsedPoints = DataService.GetSumOfPointsUsed(groupID, disciplineID);
                pointsLeft -= sumOfUsedPoints;
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
            if (clbTemplates.CheckedItems.Count == 0)
                return;

            List<ControlPointTemplate> templates = clbTemplates.CheckedItems.Cast<ControlPointTemplate>().ToList();
            List<ControlPoint> points;

            usrTemplateListRankingForm form = new usrTemplateListRankingForm(ref templates);
            form.ShowDialog();

            if (form.IsCanceld)
                return;
            
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
        private void usrTemplateList_Load(object sender, EventArgs e)
        {
            if (sumOfUsedPoints >= 80d)
            {
                MessageBox.Show("Использованы все баллы", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
        private void tssmDeleteSelecteTemplate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Удалить выбранный элемент", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                if (DataService.DeleteCPTemplate(((ControlPointTemplate)clbTemplates.SelectedItem).id))
                {
                    List<ControlPointTemplate> templates = DataService.SelectUserControlPointsTemplate(disciplineID, Session.GetCurrentSession().ID);
                    DataSetInitializer.clbDataSetInitialize<ControlPointTemplate>(ref clbTemplates, templates, "id", "GetFormatedString");
                }
            }
            catch(Exception ex)
            {
                logger.Error(ex);
            }
        }
        private void tsmiAddNewTemplate_Click(object sender, EventArgs e)
        {

        }
        private void clbTemplates_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if(e.NewValue == CheckState.Checked)
            {
                if(pointsLeft - ((ControlPointTemplate)clbTemplates.Items[e.Index]).weight < 0)
                {
                    MessageBox.Show("Нельзя выбрать эту КТ, так как ее вес превышает количество оставшихся баллов", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.NewValue = CheckState.Unchecked;
                    return;
                }

                pointsLeft -= ((ControlPointTemplate)clbTemplates.Items[e.Index]).weight;
                tsslPointsLeft.Text = $"Осталось баллов: {pointsLeft}";
                return;
            }

            if(e.NewValue == CheckState.Unchecked && e.CurrentValue == CheckState.Checked)
            {
                pointsLeft += ((ControlPointTemplate)clbTemplates.Items[e.Index]).weight;
                tsslPointsLeft.Text = $"Осталось баллов: {pointsLeft}";
            }
        }
    }
}
