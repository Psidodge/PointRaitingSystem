using MainLib.DBServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointRaitingSystem
{
    public partial class childForm2 : Form
    {
        public childForm2()
        {
            InitializeComponent();
        }
        public childForm2(Disciplines selectedDiscipline)
        {
            InitializeComponent();
            InitializeDataSets(selectedDiscipline);
        }
        private void InitializeDataSets(Disciplines selectedDiscipline)
        {
            dgvControlPoints.AutoGenerateColumns = true;
            dgvControlPoints.DataSource = DataService.SelectControlPoints(selectedDiscipline.id);
            dgvControlPoints.Columns[0].Visible = false;
            dgvControlPoints.Columns[1].Visible = false;
            dgvControlPoints.Columns[2].Visible = false;
            dgvControlPoints.Columns[5].Visible = false;
            foreach (DataGridViewColumn column in dgvControlPoints.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void dgvControlPoints_SelectionChanged(object sender, EventArgs e)
        {
            ControlPoints currentRowsCP = ((List<ControlPoints>)dgvControlPoints.DataSource)[dgvControlPoints.CurrentRow.Index];
            lblAuthor.Text = string.Format("Преподаватель:{0}{1}", Environment.NewLine, DataService.SelectTeacherById(currentRowsCP.id_of_teacher).Name);
            lblDiscipline.Text = string.Format("Дисциплина:{0}{1}", Environment.NewLine, DataService.SelectDisciplineById(currentRowsCP.id_of_discipline).discipline_name);
            txtDescription.Text = currentRowsCP.Description;
        }
    }
}
