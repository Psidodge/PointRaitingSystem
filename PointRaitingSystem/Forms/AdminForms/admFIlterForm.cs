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
    public partial class admFIlterForm : Form
    {
        public admFIlterForm(params string[] columnNames)
        {
            InitializeComponent();
            this.clbColumns.Items.AddRange(columnNames);
        }
    }
}
