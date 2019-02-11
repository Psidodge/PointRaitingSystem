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
    public partial class admMainForm : Form
    {
        public admMainForm()
        {
            InitializeComponent();
        }

        private void btnAddStudents_Click(object sender, EventArgs e)
        {
            this.tabControl.Controls.Add(new CustomTabPage(CustomTabPage.PAGE_TYPE.STUDENTS) { Text = "Студенты" });
            this.tabControl.SelectedIndex = this.tabControl.Controls.Count - 1;
        }

        private void btnAddTeachers_Click(object sender, EventArgs e)
        {
            this.tabControl.Controls.Add(new CustomTabPage(CustomTabPage.PAGE_TYPE.TEACHERS) { Text = "Преподаватели" });
            this.tabControl.SelectedIndex = this.tabControl.Controls.Count - 1;
        }

        private void btnAddDisciplines_Click(object sender, EventArgs e)
        {
            this.tabControl.Controls.Add(new CustomTabPage(CustomTabPage.PAGE_TYPE.DISCIPLINES) { Text = "Дисциплины" });
            this.tabControl.SelectedIndex = this.tabControl.Controls.Count - 1;
        }

        private void btnAddGroups_Click(object sender, EventArgs e)
        {
            this.tabControl.Controls.Add(new CustomTabPage(CustomTabPage.PAGE_TYPE.GROUPS) { Text = "Группы" });
            this.tabControl.SelectedIndex = this.tabControl.Controls.Count - 1;
        }
    }
}
