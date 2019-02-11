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
    public partial class usrSettingsForm : Form
    {
        private NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public usrSettingsForm()
        {
            InitializeComponent();
        }
        private void usrSettingsForm_Load(object sender, EventArgs e)
        {
            InitializeDataSets();
        }

        //HACK: подумать над более лучшем решением
        private void CheckAlreadyAttachedGroups(List<GroupInfo> groups)
        {
            try
            {
                List<Group> teacherGroups = DataService.SelectGroupsByTeacherId(CurrentSession.GetCurrentSession().ID);
                List<GroupInfo> groupsToCheck = (from gr in groups
                                                join tGr in teacherGroups on gr.id equals tGr.id
                                                select gr).ToList<GroupInfo>();

                DataSetInitializer<GroupInfo>.ComboBoxDataSetInitializer(ref cbGroups, groupsToCheck, "id", "group_name");

                foreach (var groupToCheck in groupsToCheck)
                {
                    clbGroups.SetItemChecked(clbGroups.Items.IndexOf(groupToCheck), true);
                }
            }
            catch(Exception ex)
            {
                logger.Error(ex);
            }
        }
        private void CheckAlreadyAttachedDisciplines(List<DisciplineInfo> disciplines)
        {
            try
            {
                List<Discipline> teacherDisciplines = DataService.SelectDisciplinesByTeacherID(CurrentSession.GetCurrentSession().ID);
                List<DisciplineInfo> disciplinesToCheck = (from d in disciplines
                                                          join tD in teacherDisciplines on d.id equals tD.id
                                                          select d).ToList<DisciplineInfo>();

                DataSetInitializer<DisciplineInfo>.ComboBoxDataSetInitializer(ref cbDisciplines, disciplinesToCheck, "id", "full_name");

                foreach (var disciplineToCheck in disciplinesToCheck)
                {
                    clbDisciplines.SetItemChecked(clbDisciplines.Items.IndexOf(disciplineToCheck), true);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }
        //TODO: сделать пометку привязаных элементов
        private void InitializeDataSets()
        {
            try
            {
                List<GroupInfo> groups = DataService.SelectAllGroupsInfo();
                DataSetInitializer<GroupInfo>.clbDataSetInitialize(ref clbGroups, groups, "id", "group_name");
                CheckAlreadyAttachedGroups(groups); 

                List<DisciplineInfo> disciplines = DataService.SelectAllDisciplinesInfo();
                DataSetInitializer<DisciplineInfo>.clbDataSetInitialize(ref clbDisciplines, disciplines, "id", "full_name");
                CheckAlreadyAttachedDisciplines(disciplines);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //REF: инкапсулировть
        //HACK: добавлять только не привязанные данные, сделал хаком путем сравнивания
        private void btnSave_Click(object sender, EventArgs e)
        {
            List<Discipline> teacherDisciplines = DataService.SelectDisciplinesByTeacherID(CurrentSession.GetCurrentSession().ID);
            List<Group> teacherGroups = DataService.SelectGroupsByTeacherId(CurrentSession.GetCurrentSession().ID);

            foreach (var checkedGroup in clbGroups.CheckedItems)
            {
                if(!teacherGroups.Any(item => item.id == ((GroupInfo)checkedGroup).id))
                    DataService.InsertIntoTeacherGroups(CurrentSession.GetCurrentSession().ID, ((GroupInfo)checkedGroup).id);
            }

            foreach (var checkedDiscipline in clbDisciplines.CheckedItems)
            {
                if (!teacherDisciplines.Any(item => item.id == ((DisciplineInfo)checkedDiscipline).id))
                    DataService.InsertIntoTeacherDisciplines(CurrentSession.GetCurrentSession().ID, ((DisciplineInfo)checkedDiscipline).id);
            }
            statusLabel.Text = "Сохранено.";
            InitializeDataSets();
        }
        private void btnBindGrToDisc_Click(object sender, EventArgs e)
        {
            try
            {
                DataService.InsertIntoGroupDiscipline((int)cbDisciplines.SelectedValue, (int)cbGroups.SelectedValue);
                statusLabel.Text = "Предмет успешно привязан к группе.";
            }
            catch(Exception ex)
            {
                logger.Error(ex);
            }
        }
    }
}
