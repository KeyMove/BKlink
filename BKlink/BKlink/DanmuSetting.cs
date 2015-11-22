using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BKlink
{
    public partial class DanmuSetting : Form
    {
        Action<int,int> act;

        public DanmuSetting(Action<int, int> a)
        {
            act = a;
            InitializeComponent();
        }

        


        private void op_Scroll(object sender, EventArgs e)
        {
            this.Opacity = (op.Value + 10) / 100F;
            act(this.op.Value, this.speed.Value);
        }

        private void speed_Scroll(object sender, EventArgs e)
        {
            act(this.op.Value, this.speed.Value);
        }
    }
}
