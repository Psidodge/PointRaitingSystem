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
    public partial class usrCPShowForm : Form
    {
        public usrCPShowForm()
        {
            InitializeComponent();
        }
        public usrCPShowForm(Discipline selectedDiscipline)
        {
            InitializeComponent();
            InitializeDataSets(selectedDiscipline);
        }
        private void InitializeDataSets(Discipline selectedDiscipline)
        {
            dgvControlPoints.AutoGenerateColumns = true;
            dgvControlPoints.DataSource = DataService.SelectControlPointsByDisciplineId(selectedDiscipline.id);
            dgvControlPoints.Columns[0].Visible = false;
            dgvControlPoints.Columns[1].Visible = false;
            dgvControlPoints.Columns[2].Visible = false;
            dgvControlPoints.Columns[5].Visible = false;
            dgvControlPoints.Columns[6].Visible = false;
            foreach (DataGridViewColumn column in dgvControlPoints.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void dgvControlPoints_SelectionChanged(object sender, EventArgs e)
        {
            ControlPoint currentRowsCP = ((List<ControlPoint>)dgvControlPoints.DataSource)[dgvControlPoints.CurrentRow.Index];
            lblAuthor.Text = string.Format("Преподаватель:{0}{1}", Environment.NewLine, DataService.SelectTeacherById(currentRowsCP.id_of_teacher).Name);
            lblDiscipline.Text = string.Format("Дисциплина:{0}{1}", Environment.NewLine, DataService.SelectDisciplineById(currentRowsCP.id_of_discipline).discipline_name);
            txtDescription.Text = currentRowsCP.Description;
        }
    }
}
