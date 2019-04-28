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

        private void RefreshAllTabs()
        {
            foreach (TabPage page in tabControl.Controls)
                page.Refresh();
        }

        private void btnAddStudents_Click(object sender, EventArgs e)
        {
            tabControl.SelectedIndex = 0;
            tabControl.SelectedTab.Refresh();
        }
        private void btnAddTeachers_Click(object sender, EventArgs e)
        {
            tabControl.SelectedIndex = 1;
            tabControl.SelectedTab.Refresh();
        }
        private void btnAddDisciplines_Click(object sender, EventArgs e)
        {
            tabControl.SelectedIndex = 2;
            tabControl.SelectedTab.Refresh();
        }
        private void btnAddGroups_Click(object sender, EventArgs e)
        {
            tabControl.SelectedIndex = 3;
            tabControl.SelectedTab.Refresh();
        }

        private void btnLoadFromFile_Click(object sender, EventArgs e)
        {
            admParserForm admParserForm = new admParserForm();
            admParserForm.ShowDialog();
            RefreshAllTabs();
        }

        private void admMainForm_Load(object sender, EventArgs e)
        {
            tabControl.Controls.Add(new CustomTabPage(CustomTabPage.PAGE_TYPE.STUDENTS)
            {
                Text = "Студенты"
            });
            tabControl.Controls.Add(new CustomTabPage(CustomTabPage.PAGE_TYPE.TEACHERS)
            {
                Text = "Преподаватели"
            });
            tabControl.Controls.Add(new CustomTabPage(CustomTabPage.PAGE_TYPE.DISCIPLINES)
            {
                Text = "Дисциплины",
            });
            tabControl.Controls.Add(new CustomTabPage(CustomTabPage.PAGE_TYPE.GROUPS)
            {
                Text = "Группы",
            });
            tabControl.SelectedIndex = 0;
        }

        private void tabControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.F)
            {
                admFIlterForm form = new admFIlterForm(((CustomTabPage)tabControl.SelectedTab).GetColumnNames());
                form.Show();
            }
        }
    }
}
