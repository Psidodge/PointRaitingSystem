using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MainLib.DBServices;
using MainLib.Session;

namespace PointRaitingSystem
{
    public partial class usrShowAllBindings : Form
    {
        public usrShowAllBindings()
        {
            InitializeComponent();
            InitializeDataSets();
        }

        private NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        private void InitializeDataSets()
        {
            try
            {
                List<Group> teacherGroups = DataService.SelectGroupsByTeacherId(Session.GetCurrentSession().ID);
                DataSetInitializer.lbDataSetInitialize<Group>(ref lbGroups, teacherGroups, "id", "name");
                List<Discipline> disciplines = DataService.SelectDisciplinesByTeacherID(Session.GetCurrentSession().ID);
                DataSetInitializer.lbDataSetInitialize<Discipline>(ref lbDisciplines, disciplines, "id", "full_name");
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }
    }
}
