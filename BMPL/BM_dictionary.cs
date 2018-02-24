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
            StartPosition = FormStartPosition.CenterParent;

            propertiesToolStripMenuItem.MouseDown += new MouseEventHandler(propertiesToolStripMenuItem_MouseDown);

            BMGridGear.SetCellAlignment(dgv1);
            BMGridGear.SetVisualAttributes(dgv1);

            DataTable copyDataTable = (from DataRow row in data.Rows where row.Field<Int64>(2).Equals(1) select row).CopyToDataTable();

            try
            {
                new BMGridGear().AssignTable(dgv1, copyDataTable, 0, true, "stblname", "stbldesc");
            }
            catch (Exception ex)
            {
                BMUiGear.Alert(ex.Message, "Ошибка приложения");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            string table = dgv1.Rows[e.RowIndex].Cells[0].Value.ToString();
            string description = dgv1.Rows[e.RowIndex].Cells[1].Value.ToString();

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
              if (e.ColumnIndex == senderGrid.ColumnCount-1)
                {
                    BM_dictionary_data b_dictionary_data = new BM_dictionary_data(table, description);
                    b_dictionary_data.ShowDialog();
                }
            }
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
