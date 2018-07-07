using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace BMApp
{
    public partial class UserForm : Form
    {
        BMDaGear bm_da_gear = new BMDaGear();

        public UserForm(DataTable data)
        {
            InitializeComponent();

            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;

            propertiesToolStripMenuItem.MouseDown += new MouseEventHandler(propertiesToolStripMenuItem_MouseDown);

            BMGridGear.SetCellAlignment(dgv1);
            BMGridGear.SetVisualAttributes(dgv1, BMGridGear.AttrSetType.User);

            try
            {
                new BMGridGear(BMGridGear.AttrSetType.User).AssignTable(dgv1, data, 0, false, "iuserid", "susername", "suserfio", "iuserstatus", "iuserrole");
            }
            catch (Exception ex)
            {
                BMUiGear.Alert(ex.Message, "Ошибка приложения");
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

                    switch (int.Parse(cell.Val.ToString()).Equals(1))
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

                    switch (int.Parse(cell.Val.ToString()))
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
            BMUiGear.ManageUser(dgv1,0);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            BMUiGear.ManageUser(dgv1, 1);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            BMUiGear.ManageUserRole(dgv1, 1);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            BMUiGear.ManageUserRole(dgv1, 2);
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            BMUiGear.ManageUserRole(dgv1, 3);
        }
    }
}
