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
            tabControl.Controls.Add(new CustomTabPage(CustomTabPage.PAGE_TYPE.STUDENTS)
            {
                Text = "Студенты",
                ContextMenuStrip = cmsTabs
            });
            tabControl.SelectedIndex = tabControl.Controls.Count - 1;
        }
        private void btnAddTeachers_Click(object sender, EventArgs e)
        {
            tabControl.Controls.Add(new CustomTabPage(CustomTabPage.PAGE_TYPE.TEACHERS)
            {
                Text = "Преподаватели",
                ContextMenuStrip = this.cmsTabs
            });
            tabControl.SelectedIndex = tabControl.Controls.Count - 1;
        }
        private void btnAddDisciplines_Click(object sender, EventArgs e)
        {
            tabControl.Controls.Add(new CustomTabPage(CustomTabPage.PAGE_TYPE.DISCIPLINES)
            {
                Text = "Дисциплины",
                ContextMenuStrip = cmsTabs
            });

            tabControl.SelectedIndex = tabControl.Controls.Count - 1;
        }
        private void btnAddGroups_Click(object sender, EventArgs e)
        {
            tabControl.Controls.Add(new CustomTabPage(CustomTabPage.PAGE_TYPE.GROUPS)
            {
                Text = "Группы",
                ContextMenuStrip = cmsTabs
            });
            tabControl.SelectedIndex = tabControl.Controls.Count - 1;
        }
        private void closeCurrentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl.TabPages.Remove(tabControl.SelectedTab);
        }
        private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach(TabPage page in tabControl.TabPages)
            {
                tabControl.TabPages.Remove(page);
            }
        }
        private void parseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            admParserForm admParserForm = new admParserForm();
            admParserForm.ShowDialog();
        }
    }
}
