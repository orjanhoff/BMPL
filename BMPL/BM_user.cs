using BMPL.Properties;
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
        BMDaGear bm_da_gear = new BMDaGear();

        public BM_user(DataTable data)
        {
            InitializeComponent();

            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;

            propertiesToolStripMenuItem.MouseDown += new MouseEventHandler(propertiesToolStripMenuItem_MouseDown);

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
            var senderGrid = (DataGridView)sender;
            BMUiCustomControls.DataGridViewImageButtonCell cell = senderGrid.Rows[e.RowIndex].Cells[e.ColumnIndex] as BMUiCustomControls.DataGridViewImageButtonCell;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (e.ColumnIndex == senderGrid.ColumnCount - 2)
                {
                    int r = senderGrid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Right;
                    int y = senderGrid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Location.Y;
                    int h = senderGrid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Height;

                    switch (int.Parse(cell.Value.ToString()).Equals(1))
                    {
                        case true:  cms2.Items[0].Enabled = true; cms2.Items[1].Enabled = false; break;
                        case false: cms2.Items[0].Enabled = false; cms2.Items[1].Enabled = true; ; break;
                    }

                    cms2.Show(this, new Point(r, y+2*h));
                }

                else if (e.ColumnIndex == senderGrid.ColumnCount - 1)
                {
                    int r = senderGrid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Right;
                    int y = senderGrid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Location.Y;
                    int h = senderGrid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Height;

                    switch (int.Parse(cell.Value.ToString()))
                    {
                        case 1: cms3.Items[0].Enabled = false; cms3.Items[1].Enabled = true; cms3.Items[2].Enabled = true; break;
                        case 2: cms3.Items[0].Enabled = true; cms3.Items[1].Enabled = false; cms3.Items[2].Enabled = true; break;
                        case 3: cms3.Items[0].Enabled = true; cms3.Items[1].Enabled = true; cms3.Items[2].Enabled = false; break;
                    }

                    cms3.Show(this, new Point(r, y + 2 * h));
                }
            }
        }

        private void propertiesToolStripMenuItem_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    {
                        ToolStripMenuItem tsmi= (ToolStripMenuItem)sender;
                        cms1.Show(this, new Point(tsmi.Bounds.Location.X+tsmi.Width, tsmi.Bounds.Location.Y+tsmi.Height));
                    }
                    break;
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            BMUiGear.changeUserStatus(dgv1,0);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            BMUiGear.changeUserStatus(dgv1, 1);
        }
    }
}
