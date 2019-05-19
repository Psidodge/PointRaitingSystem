using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
    public partial class usrShowAllBindings : Form
    {
        private NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        private List<Group> originGroupsList;
        private List<Discipline> originDisciplinesList;

        public usrShowAllBindings()
        {
            InitializeComponent();
            InitializeDataSets();
            LoadFontSettings();
        }

        private void PrintListOfGroupDiscipline()
        {
            try
            {
                List<Discipline> disciplines = DataService.SelectDisciplinesByTeacherIdAndGroupId(Session.GetCurrentSession().ID, ((Group)lbGroups.SelectedItem).id);
                DataSetInitializer.lbDataSetInitialize<Discipline>(ref lbDisciplines, disciplines, "id", "full_name");
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }
        private void InitializeDataSets()
        {
            try
            {
                List<Group> teacherGroups = originGroupsList = DataService.SelectGroupsByTeacherId(Session.GetCurrentSession().ID);
                DataSetInitializer.lbDataSetInitialize<Group>(ref lbGroups, teacherGroups, "id", "name");
                List<Discipline> disciplines = originDisciplinesList = DataService.SelectDisciplinesByTeacherIdAndGroupId(Session.GetCurrentSession().ID, ((Group)lbGroups.SelectedItem).id);
                DataSetInitializer.lbDataSetInitialize<Discipline>(ref lbDisciplines, disciplines, "id", "full_name");
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }

        private void LoadFontSettings()
        {
            System.ComponentModel.TypeConverter converter = System.ComponentModel.TypeDescriptor.GetConverter(typeof(Font));
            this.Font = (Font)converter.ConvertFromString(ConfigurationManager.AppSettings["fontSettings"]);
        }
        private void lbGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            PrintListOfGroupDiscipline();
        }
        private void RemoveDiscipline()
        {
            try
            {
                if (DataService.DeleteDisciplineBinding(((Discipline)lbDisciplines.SelectedItem).id, Session.GetCurrentSession().ID, ((Group)lbGroups.SelectedItem).id))
                {
                    List<Discipline> tempList = lbDisciplines.Items.Cast<Discipline>().ToList();
                    tempList.RemoveAt(lbDisciplines.SelectedIndex);
                    DataSetInitializer.lbDataSetInitialize<Discipline>(ref lbDisciplines, tempList, "id", "full_name");
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }
        private void RemoveGroup()
        {
            try
            {
                if (DataService.DeleteGroupBindingsTransact(lbDisciplines.Items.Cast<Discipline>().ToList(), Session.GetCurrentSession().ID, ((Group)lbGroups.SelectedItem).id))
                {
                    List<Group> tempList = lbGroups.Items.Cast<Group>().ToList();
                    tempList.RemoveAt(lbGroups.SelectedIndex);
                    DataSetInitializer.lbDataSetInitialize<Group>(ref lbGroups, tempList, "id", "name");
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }
        private void tsmiRemoveDisciplineBinding_Click(object sender, EventArgs e)
        {
            RemoveDiscipline();
        }
        private void lbDisciplines_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                RemoveDiscipline();
        }
        private void tsmiRemoveGroupBinding_Click(object sender, EventArgs e)
        {
            RemoveGroup();
        }
        private void lbGroups_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                RemoveGroup();
            }
        }
        private void txtGroupsFilter_TextChanged(object sender, EventArgs e)
        {
            DataSetInitializer.lbDataSetInitialize<Group>(ref lbGroups, originGroupsList, "id", "name");
            List<Group> tempGroups = (List<Group>)lbGroups.DataSource;

            if (string.IsNullOrWhiteSpace(txtGroupsFilter.Text))
                return;

            tempGroups = tempGroups.Where(x => x.name.ToLower().StartsWith(txtGroupsFilter.Text.ToLower())).ToList();
            DataSetInitializer.lbDataSetInitialize<Group>(ref lbGroups, tempGroups, "id", "name");

        }
        private void txtDisciplinesFilter_TextChanged(object sender, EventArgs e)
        {
            DataSetInitializer.lbDataSetInitialize<Discipline>(ref lbGroups, originDisciplinesList, "id", "full_name");
            List<Discipline> tempDisciplines = (List<Discipline>)lbDisciplines.DataSource;

            if (string.IsNullOrWhiteSpace(txtDisciplinesFilter.Text))
                return;

            tempDisciplines = tempDisciplines.Where(x => x.name.ToLower().StartsWith(txtDisciplinesFilter.Text.ToLower())).ToList();
            DataSetInitializer.lbDataSetInitialize<Discipline>(ref lbGroups, tempDisciplines, "id", "full_name");
        }
    }
}
