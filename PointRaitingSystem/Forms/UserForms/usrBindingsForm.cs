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
        private List<GroupInfo> clbGroupsDataSource;


        public usrSettingsForm()
        {
            InitializeComponent();
            this.Text = Session.GetCurrentSession().UserName;
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
                List<Group> teacherGroups = DataService.SelectGroupsByTeacherId(Session.GetCurrentSession().ID);
                List<GroupInfo> groupsToCheck = (from gr in clbGroupsDataSource
                                                 join tGr in teacherGroups on gr.id equals tGr.id
                                                 select gr).ToList<GroupInfo>();
                foreach(int index in clbGroups.CheckedIndices)
                {
                    clbGroups.SetItemChecked(index, false);
                }

                foreach (var groupToCheck in groupsToCheck)
                {
                    if(clbGroups.Items.Contains(groupToCheck))
                        clbGroups.SetItemChecked(clbGroups.Items.IndexOf(groupToCheck), true);
                }
            }
            catch(Exception ex)
            {
                statusLabel.Text = "Возникла необработанная ошибка.";
                logger.Error(ex);
            }
        }
        private void PrintListOfGroupDiscipline()
        {
            List<Discipline> disciplines = DataService.SelectDisciplinesByTeacherIdAndGroupId(Session.GetCurrentSession().ID, ((GroupInfo)clbGroups.SelectedItem).id);
            DataSetInitializer<Discipline>.lbDataSetInitialize(ref lbDisciplines, disciplines, "id", "full_name");
        }
        
        private void InitializeDataSets()
        {
            try
            {
                clbGroupsDataSource = DataService.SelectAllGroupsInfo();
                DataSetInitializer<GroupInfo>.clbDataSetInitialize(ref clbGroups, clbGroupsDataSource, "id", "name");
                CheckAlreadyAttachedGroups(clbGroupsDataSource);

                List<DisciplineInfo> disciplinesInfo = DataService.SelectAllDisciplinesInfo();
                DataSetInitializer<DisciplineInfo>.ComboBoxDataSetInitializer(ref cbDisciplines, disciplinesInfo, "id", "disciplineFullName");
            }
            catch (Exception ex)
            {
                statusLabel.Text = "Возникла необработанная ошибка.";
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
            List<Discipline> teacherDisciplines = DataService.SelectDisciplinesByTeacherID(Session.GetCurrentSession().ID);
            List<Group> teacherGroups = DataService.SelectGroupsByTeacherId(Session.GetCurrentSession().ID);

            foreach (var checkedGroup in clbGroups.CheckedItems)
            {
                if(!teacherGroups.Any(item => item.id == ((GroupInfo)checkedGroup).id))
                    DataService.InsertIntoTeacherGroups(Session.GetCurrentSession().ID, ((GroupInfo)checkedGroup).id);
            }
            statusLabel.Text = "Сохранено";
            InitializeDataSets();
        }

        private void clbGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            PrintListOfGroupDiscipline();
        }
        private void btbBind_Click(object sender, EventArgs e)
        {
            try
            {
                if (DataService.isGroupDiscipline((int)cbDisciplines.SelectedValue, ((GroupInfo)clbGroups.SelectedItem).id))
                    return;

                DataService.InsertIntoGroupDiscipline((int)cbDisciplines.SelectedValue, ((GroupInfo)clbGroups.SelectedItem).id);
                if (!DataService.isTeacherDiscipline((int)cbDisciplines.SelectedValue, Session.GetCurrentSession().ID))
                    DataService.InsertIntoTeacherDisciplines(Session.GetCurrentSession().ID, (int)cbDisciplines.SelectedValue);
                PrintListOfGroupDiscipline();
            }
            catch(Exception ex)
            {
                statusLabel.Text = "Возникла необработанная ошибка.";
                logger.Error(ex);
            }
        }
        //HACK: придумать что-нибудь получше
        private void txtGroupsFilter_TextChanged(object sender, EventArgs e)
        {
            DataSetInitializer<GroupInfo>.clbDataSetInitialize(ref clbGroups, clbGroupsDataSource, "id", "name");
            CheckAlreadyAttachedGroups(clbGroupsDataSource);
            List<GroupInfo> groups = new List<GroupInfo>();

            foreach(GroupInfo item in clbGroups.Items)
            {
                if (item.name.Contains(txtGroupsFilter.Text))
                    groups.Add(item);
            }
            DataSetInitializer<GroupInfo>.clbDataSetInitialize(ref clbGroups, groups, "id", "name");
            CheckAlreadyAttachedGroups(groups);
        }
    }
}
