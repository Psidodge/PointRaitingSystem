using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MainLib.DBServices;
using System.Linq;

namespace PointRaitingSystem
{
    public partial class tabDisciplines : UserControl
    {
        private NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        private List<DisciplineInfo> originDisciplineList;
        private Dictionary<string, string> allias;

        private void InitializeDataSets()
        {
            try
            {
                List<DisciplineInfo> disciplines = DataService.SelectAllDisciplinesInfo();
                originDisciplineList = disciplines;
                SetHeadersAllias();
                DataSetInitializer.dgvDataSetInitializer<DisciplineInfo>(ref dgvDisciplines, disciplines, allias, new int[] { 0, 3 }, new string[] { "name" });
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
            allias.Add("semestr", "Семестр");
        }

        public tabDisciplines()
        {
            InitializeComponent();
        }

        public override void Refresh()
        {
            InitializeDataSets();
        }
        
        private void tabDisciplines_Load(object sender, EventArgs e)
        {
            InitializeDataSets();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Discipline discipline = new Discipline
                {
                    name = txtName.Text,
                    semestr = int.Parse(txtSemestr.Text)
                };

                uint recAffected = DataService.InsertIntoDisciplinesTable(discipline);

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
                Discipline discipline = new Discipline
                {
                    id = uint.Parse(txtId.Text),
                    name = txtName.Text,
                    semestr = int.Parse(txtSemestr.Text)
                };

                int recAffected = DataService.UpdateDisciplines(discipline);

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
        private void dgvDisciplines_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDisciplines.CurrentRow == null)
                return;

            txtId.Text = dgvDisciplines.CurrentRow.Cells["id"].Value.ToString();
            txtName.Text = dgvDisciplines.CurrentRow.Cells["name"].Value.ToString();
            txtSemestr.Text = dgvDisciplines.CurrentRow.Cells["semestr"].Value.ToString();
        }
        private void btnAddFilter_Click(object sender, EventArgs e)
        {
            List<DisciplineInfo> tempList = (List<DisciplineInfo>)dgvDisciplines.DataSource;

            if (!string.IsNullOrWhiteSpace(txtNameFilter.Text))
                tempList = tempList.Where(x => x.name.StartsWith(txtNameFilter.Text)).ToList();

            if (!string.IsNullOrWhiteSpace(txtSemesterFilter.Text))
                tempList = tempList.Where(x => x.semestr == int.Parse(txtSemesterFilter.Text)).ToList();

            DataSetInitializer.dgvDataSetInitializer<DisciplineInfo>(ref dgvDisciplines, tempList, allias, new int[] { 0, 3 }, new string[] { "name" });
        }
        private void btnResetFilter_Click(object sender, EventArgs e)
        {
            DataSetInitializer.dgvDataSetInitializer<DisciplineInfo>(ref dgvDisciplines, originDisciplineList, allias, new int[] { 0, 3 }, new string[] { "name" });
        }
    }
}
