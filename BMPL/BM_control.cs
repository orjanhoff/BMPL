using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMPL
{
    public partial class BM_control : Form
    {
        private bool flag = true;

        public BM_control()
        {
            InitializeComponent();
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST)
                m.Result = (IntPtr)(HT_CAPTION);
        }

        private const int WM_NCHITTEST = 0x84;
        private const int HT_CLIENT = 0x1;
        private const int HT_CAPTION = 0x2;

        private void BM_control_Click(object sender, EventArgs e)
        {
            switch (flag)
            {
                case true:flag = false; this.Visible = false; this.Hide(); break;
            }
        }
    }
}
