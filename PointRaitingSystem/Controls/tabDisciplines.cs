using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MainLib.DBServices;
using MainLib.Parsing;

namespace PointRaitingSystem
{
    public partial class tabDisciplines : UserControl
    {
        private NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        private void InitializeDataSets()
        {
            try
            {
                List<DisciplineInfo> disciplines = DataService.SelectAllDisciplinesInfo();
                DataSetInitializer<DisciplineInfo>.dgvDataSetInitializer(ref dgvDisciplines, disciplines, new int[] { 0 }, new string[] { "name" });
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }

        public tabDisciplines()
        {
            InitializeComponent();
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

                int recAffected = DataService.InsertIntoDisciplinesTable(discipline);

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
                    id = int.Parse(txtId.Text),
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
    }
}
