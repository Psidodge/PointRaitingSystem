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
    public partial class usrCertificationAddForm : Form
    {
        public usrCertificationAddForm()
        {
            InitializeComponent();
        }
        public usrCertificationAddForm(string groupName, int groupID, int disciplineID)
        {
            InitializeComponent();
            txtGroupName.Text = groupName;
            dataSetInitializer(groupID, disciplineID);
            this.groupID = groupID;
            this.disciplineID = disciplineID;
        }

        private int groupID,
                    disciplineID;
        private NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();



        private void dataSetInitializer(int groupID, int disciplineID)
        {
            try
            {
                List<StudentControlPoint> controlPoints = DataService.SelectStudentControPointsGroupDisc(groupID, disciplineID, MainLib.Session.Session.GetCurrentSession().ID)
                                                        .GroupBy(g => g.id_of_controlPoint)
                                                        .Select(s => s.First())
                                                        .ToList();
                GenerateControlPointEntityspseudonyms(ref controlPoints);
                DataSetInitializer.ComboBoxDataSetInitializer<StudentControlPoint>(ref cbPrevCP, controlPoints, "id_of_controlPoint", "pseudonym");
            }
            catch(Exception ex)
            {
                logger.Error(ex);
            }
        }

        private void GenerateControlPointEntityspseudonyms(ref List<StudentControlPoint> studentCertifications)
        {
            for(int i = 0; i < studentCertifications.Count; i++)
                studentCertifications[i].pseudonym = string.Format("КТ {0}", i + 1);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            List<Student> students = null;

            try
            {
                students = DataService.SelectStudentsByGroupId(groupID);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                tsslInfo.Text = "Ошибка при подключении к базе данных.";
            }

            foreach (Student student in students)
            {
                var certification = new StudentCertification()
                                    {
                                        id_of_student = student.id,
                                        id_of_prev_cp = (int)cbPrevCP.SelectedValue,
                                        id_of_discipline = disciplineID,
                                        id_of_user = Session.GetCurrentSession().ID,
                                        date = dtpDate.Value.Date
                                    };
                try
                {
                    certification.CountGrade(disciplineID, (int)cbPrevCP.SelectedValue);
                    DataService.InsertIntoStudentCertification(certification);
                    tsslInfo.Text = "Аттестация создана успешно.";
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                    tsslInfo.Text = "Ошибка при добавлении записи.";
                }
            }
        }
        private void usrCertificationAddForm_Load(object sender, EventArgs e)
        {

        }
        private void cbPrevCP_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            using (SolidBrush br = new SolidBrush(e.ForeColor))
            {
                e.Graphics.DrawString(((StudentControlPoint)cbPrevCP.Items[e.Index]).pseudonym, e.Font, br, e.Bounds);
            }

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                toolTipCPcb.Show(((StudentControlPoint)cbPrevCP.Items[e.Index]).description, cbPrevCP, e.Bounds.Right, e.Bounds.Bottom);

            e.DrawFocusRectangle();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
