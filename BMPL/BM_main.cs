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
    public partial class BM_main : Form
    {
        public BM_main()
        {
            InitializeComponent();

            //this.MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.Fixed3D;

            BM_service bm_service = new BM_service();
            bm_service.MdiParent = this;
            bm_service.Show();

            switch (BMUiConst.UiConst.Equals(null))
            {
                case true:
                    BMUiCustomControls.UIException.Alert("{0}: Ошибка при построении кэша", "Ошибка приложения");
                    break;
                default: break;
            }
        }

        private void словариToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BM_dictionary b_dictionary = new BM_dictionary(BMUiConst.UiConst.Cache["sys_table"]);
            b_dictionary.ShowDialog();
        }

        private void пользователиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BM_user b_user = new BM_user(BMUiConst.UiConst.Cache["user"]);
            b_user.ShowDialog();
        }

        private void реестрAPIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BM_api b_api = new BM_api(BMUiConst.UiConst.Cache["api"]);
            b_api.ShowDialog();
        }
    }
}
