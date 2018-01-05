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
    public partial class BM_dictionary_data : Form
    {
        public BM_dictionary_data(params string[] data)
        {
            InitializeComponent();

            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;

            propertiesToolStripMenuItem.MouseDown += new MouseEventHandler(propertiesToolStripMenuItem_MouseDown);

            switch (data.Length)
            {
                case 2: Text = data[1] ?? data[0]; break;
                case 1: Text = data[0]; break;
                case 0: BMUiCustomControls.UIException.Alert("{0}: Не задан справочник", "Ошибка приложения");
                    return;
            }
            
            BMUiGear.DgvAlignCenterAndLeft(dgv1);
            BMUiGear.DgvConfigureDictionary(dgv1);

            try
            {
                BMUiGear.DgvFillData(dgv1, BMUiConst.UiConst.Cache[data[0]], false, "ierrcode", "serrmsg");
            }
            catch (Exception ex)
            {
                BMUiCustomControls.UIException.Alert(ex.Message, "Ошибка приложения");
            }
        }

        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void propertiesToolStripMenuItem_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    {
                        ToolStripMenuItem tsmi = (ToolStripMenuItem)sender;
                        cms1.Show(this, new Point(tsmi.Bounds.Location.X + tsmi.Width, tsmi.Bounds.Location.Y + tsmi.Height));
                    }
                    break;
            }
        }
    }
}
