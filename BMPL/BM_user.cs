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
    public partial class BM_user : Form
    {
        public BM_user(DataTable data)
        {
            InitializeComponent();

            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;

            BMUiGear.DgvAlignCenter(dgv1);
            BMUiGear.DgvConfigureUser(dgv1);

            try
            {
                BMUiGear.DgvFillData(dgv1, data, "iuserid","susername", "suserfio", "iuserstatus", "iuserrole");
            }
            catch (Exception ex)
            {
                BMUiCustomControls.UIException.Alert(ex.Message, "Ошибка приложения");
            }
        }

        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
