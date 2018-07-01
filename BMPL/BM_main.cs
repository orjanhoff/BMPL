using System;
using System.Windows.Forms;

namespace BMPL
{
    public partial class BM_main : Form
    {
        public BM_main()
        {
            InitializeComponent();
            Text = string.Format("{0} v.{1}", Text, typeof(BM_main).Assembly.GetName().Version);

            //this.MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.Fixed3D;

            BM_service bm_service = new BM_service(BMInitGear.UiConst.Cache["service"]);
            bm_service.MdiParent = this;
            bm_service.Show();
        }

        private void словариToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BM_dictionary b_dictionary = new BM_dictionary(BMInitGear.UiConst.Cache["sys_table"]);
            b_dictionary.ShowDialog();
        }

        private void пользователиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BM_user b_user = new BM_user(BMInitGear.UiConst.Cache["user"]);
            b_user.ShowDialog();
        }

        private void реестрAPIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BM_api b_api = new BM_api(BMInitGear.UiConst.Cache["api"]);
            b_api.ShowDialog();
        }

        private void интеграцияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BM_MSMQ b_msmq = new BM_MSMQ();
            b_msmq.ShowDialog();
        }
    }
}
