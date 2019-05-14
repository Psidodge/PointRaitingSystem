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
        private Control[] filterTextBoxes;

        public admFIlterForm(params string[] columnNames)
        {
            InitializeComponent();
            this.clbColumns.Items.AddRange(columnNames);
            CreateColumnFilterTextBoxes(columnNames.Length);
        }

        private void clbColumns_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if(e.NewValue == CheckState.Checked)
                this.Controls[$"txtColumnFilter{e.Index}"].Visible = true;
            else if(e.NewValue == CheckState.Unchecked)
                this.Controls[$"txtColumnFilter{e.Index}"].Visible = false;
        }

        private void CreateColumnFilterTextBoxes(int amountOfColumns)
        {
            int offset = 0;
            filterTextBoxes = new Control[amountOfColumns];

            for (int i = 0; i < amountOfColumns; i++, offset+=20)
                filterTextBoxes[i] = new TextBox(){ Name = $"txtColumnFilter{i}", Location = new Point(150, 13 + offset), Size = new Size(149, 20), Visible = false };

            this.Controls.AddRange(filterTextBoxes);
        }
    }
}
