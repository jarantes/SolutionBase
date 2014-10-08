using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BASE_APP
{
    public partial class FrmProgramaticaly : Form
    {
        public FrmProgramaticaly()
        {
            InitializeComponent();
        }

        int index = 0;

        private void btnMover_Click(object sender, EventArgs e)
        {
            if (index == 3)
                index = 0;
            index++;
            var name = "gpbTarget" + index;
            foreach (GroupBox item in this.Controls.OfType<GroupBox>())
            {
                if (item.Name == name)
                {
                    item.Controls.Add(this.pnlDynamic);
                    pnlDynamic.Location = new System.Drawing.Point(7, 15);
                }
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            foreach (GroupBox item in this.Controls.OfType<GroupBox>())
            {
                item.Controls.Clear();
            }     
        }
    }
}
