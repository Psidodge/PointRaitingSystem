using System.Windows.Forms;

namespace PointRaitingSystem
{
    public class CustomTabPage : TabPage
    {
        public enum PAGE_TYPE { STUDENTS, TEACHERS, DISCIPLINES, GROUPS };

        public CustomTabPage(PAGE_TYPE type)
        {
            Control page = null;
            switch (type)
            {
                case PAGE_TYPE.STUDENTS:
                    page = new tabStudents();
                    break;
                case PAGE_TYPE.TEACHERS:
                    page = new tabTeachers();
                    break;
                case PAGE_TYPE.DISCIPLINES:
                    page = new tabDisciplines();
                    break;
                case PAGE_TYPE.GROUPS:
                    page = new tabGroups();
                    break;
            }

            //NOTE: exception handler here
            if (page == null)
                return;

            page.Dock = DockStyle.Fill;
            this.Controls.Add(page);
        }
    }
}
