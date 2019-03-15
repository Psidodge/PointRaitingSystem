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

namespace PointRaitingSystem
{
    public partial class usrCertificationAddForm : Form
    {
        public usrCertificationAddForm()
        {
            InitializeComponent();
        }
        public usrCertificationAddForm(string groupName, int groupID, int disciplineID)
        {
            InitializeComponent();
            txtGroupName.Text = groupName;
            dataSetInitializer(groupID, disciplineID);
        }

        //private List<StudentControlPoint> controlPoints;
        private NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        private void dataSetInitializer(int groupID, int disciplineID)
        {
            try
            {
                //List<StudentControlPoint> controlPoints = DataService.SelectStudentControPointsGroupDisc(groupID, disciplineID).Distinct();
                //DataSetInitializer<StudentControlPoint>.ComboBoxDataSetInitializer(ref cbPrevCP, controlPoints, "id", "description");
            }
            catch(Exception ex)
            {
                logger.Error(ex);
            }
            //DataSetInitializer<ControlPoint>
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
