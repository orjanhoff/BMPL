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
    public partial class BM_dictionary : Form
    {
        public BM_dictionary(DataTable data)
        {
            InitializeComponent();

            MaximizeBox = false;
            MinimizeBox = false;

            dgv1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv1.EnableHeadersVisualStyles = false;
            dgv1.ShowCellToolTips = true;
            dgv1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            DataTable copyDataTable=null;
            copyDataTable = (from DataRow row in data.Rows where row.Field<Int64>(2).Equals(1) select row).CopyToDataTable();
            copyDataTable.Columns.Remove("icacheflag");
            copyDataTable.Columns.Remove("itbltype");

            BMUiGear.DgvAlignCenter(dgv1);
            try
            {
                BMUiGear.DgvFillData(dgv1, copyDataTable, new string[] { "stblname", "stbldesc" });
            }
            catch (Exception ex)
            {
                BMUiCustomControls.UIException.Alert(ex.Message, "Ошибка приложения");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            string table = dgv1.Rows[e.RowIndex].Cells[0].Value.ToString();

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
              if (e.ColumnIndex == senderGrid.ColumnCount-1)
                {
                    BMUiCustomControls.UIException.Warn("ToDo", table);
                }
            }
        }

        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BMUiCustomControls.UIException.Warn("ToDo", "Внимание");
        }
    }
}
