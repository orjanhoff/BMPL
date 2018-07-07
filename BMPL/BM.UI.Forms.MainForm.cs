using System;
using System.Windows.Forms;

namespace BMApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Text = string.Format("{0} v.{1}", Text, typeof(MainForm).Assembly.GetName().Version);

            //this.MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.Fixed3D;

            ServiceForm bm_service = new ServiceForm(BMHeartBeat.Cache["service"]);
            bm_service.MdiParent = this;
            bm_service.Show();
        }

        private void словариToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DictionaryForm b_dictionary = new DictionaryForm(BMHeartBeat.Cache["sys_table"]);
            b_dictionary.ShowDialog();
        }

        private void пользователиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserForm b_user = new UserForm(BMHeartBeat.Cache["user"]);
            b_user.ShowDialog();
        }

        private void реестрAPIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApiForm b_api = new ApiForm(BMHeartBeat.Cache["api"]);
            b_api.ShowDialog();
        }

        private void интеграцияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IntegrationForm b_msmq = new IntegrationForm();
            b_msmq.ShowDialog();
        }

        private void отчетыToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
