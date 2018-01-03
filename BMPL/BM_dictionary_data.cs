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
        public BM_dictionary_data(string table)
        {
            InitializeComponent();

            MaximizeBox = false;
            MinimizeBox = false;

            Text = table;

            dgv1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv1.EnableHeadersVisualStyles = false;
            dgv1.ShowCellToolTips = true;
            dgv1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            BMUiGear.DgvAlignCenter(dgv1);
            try
            {
                BMUiGear.DgvFillData(dgv1, BMUiConst.UiConst.Cache[table], false, "ierrcode", "serrmsg");
            }
            catch (Exception ex)
            {
                BMUiCustomControls.UIException.Alert(ex.Message, "Ошибка приложения");
            }
        }

        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
