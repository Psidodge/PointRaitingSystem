using System.Windows.Forms;

namespace PointRaitingSystem
{
    public class CustomTabPage : TabPage
    {
        public enum PAGE_TYPE { STUDENTS, TEACHERS, DISCIPLINES, GROUPS };


        private Control page;
        private PAGE_TYPE currentPageType;

        public CustomTabPage(PAGE_TYPE type)
        {
            page = null;
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

            currentPageType = type;
            page.Dock = DockStyle.Fill;
            this.Controls.Add(page);
        }

        public string[] GetColumnNames()
        {
            switch(currentPageType)
            {
                case PAGE_TYPE.DISCIPLINES:
                    return ((tabDisciplines)page).GetColumnNames;
            }
            return null;
        }
        public override void Refresh()
        {
            page.Refresh();
            base.Refresh();
        }
    }
}
