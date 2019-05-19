using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MainLib.DBServices;

namespace PointRaitingSystem
{
    public partial class tabGroups : UserControl
    {

        private NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        private List<GroupInfo> originGroupList;
        private Dictionary<string, string> allias;

        private void InitializeDataSets()
        {
            try
            {
                List<GroupInfo> groupsInfo = DataService.SelectAllGroupsInfo();
                originGroupList = groupsInfo;
                SetHeadersAllias();
                DataSetInitializer.dgvDataSetInitializer<GroupInfo>(ref dgvGroups, groupsInfo, allias, new int[] { 0 }, new string[] { "name" });
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }

        private void SetHeadersAllias()
        {
            allias = new Dictionary<string, string>();
            allias.Add("name", "Название");
            allias.Add("course", "Курс");
        }

        public tabGroups()
        {
            InitializeComponent();
        }

        public override void Refresh()
        {
            InitializeDataSets();
        }

        private void tabGroups_Load(object sender, EventArgs e)
        {
            InitializeDataSets();
        }
        private void dgvGroups_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvGroups.CurrentRow == null)
                return;

            txtId.Text = dgvGroups.CurrentRow.Cells["id"].Value.ToString();
            txtName.Text = dgvGroups.CurrentRow.Cells["name"].Value.ToString();
            txtCourse.Text = dgvGroups.CurrentRow.Cells["course"].Value.ToString();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Group group = new Group
                {
                    name = txtName.Text,
                    course = int.Parse(txtCourse.Text)
                };

                uint recAffected = DataService.InsertIntoGroupsTable(group);

                if (recAffected > 0)
                {
                    InitializeDataSets();
                    //NOTE: добавить пометку новых записей
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Group group = new Group
                {
                    id = uint.Parse(txtId.Text),
                    name = txtName.Text,
                    course = int.Parse(txtCourse.Text)
                };

                int recAffected = DataService.UpdateGroups(group);

                if (recAffected > 0)
                {
                    InitializeDataSets();
                    //NOTE: добавить пометку новых записей
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }
        private void btnAddFilter_Click(object sender, EventArgs e)
        {
            List<GroupInfo> tempList = (List<GroupInfo>)dgvGroups.DataSource;
            if (!string.IsNullOrWhiteSpace(txtNameFilter.Text))
                if(!chkbIsContains.Checked)
                    tempList = tempList.Where(x => x.name.StartsWith(txtNameFilter.Text)).ToList();
                else
                    tempList = tempList.Where(x => x.name.Contains(txtNameFilter.Text)).ToList();
            if (!string.IsNullOrWhiteSpace(txtCourseFilter.Text))
                tempList = tempList.Where(x => x.course == int.Parse(txtCourseFilter.Text)).ToList();

            DataSetInitializer.dgvDataSetInitializer<GroupInfo>(ref dgvGroups, tempList, allias, new int[] { 0 }, new string[] { "name" });
        }
        private void btnResetFilter_Click(object sender, EventArgs e)
        {
            DataSetInitializer.dgvDataSetInitializer<GroupInfo>(ref dgvGroups, originGroupList, allias, new int[] { 0 }, new string[] { "name" });
        }
    }
}
