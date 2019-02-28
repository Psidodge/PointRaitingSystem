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


        private void InitializeDataSets()
        {
            try
            {
                List<GroupInfo> groupsInfo = DataService.SelectAllGroupsInfo();
                DataSetInitializer<GroupInfo>.dgvDataSetInitializer(ref dgvGroups, groupsInfo, new int[] { 0 }, new string[] { "name" });
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }

        public tabGroups()
        {
            InitializeComponent();
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

                int recAffected = DataService.InsertIntoGroupsTable(group);

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
                    id = int.Parse(txtId.Text),
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
    }
}
