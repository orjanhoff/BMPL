using System;
using System.Windows.Forms;

namespace BMPL
{
    public partial class BM_MSMQ : Form
    {
        public BM_MSMQ()
        {
            InitializeComponent();
            SetCellAlignment();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
        }

        public void SetCellAlignment()
        {
            dgv1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv1.EnableHeadersVisualStyles = false;
            dgv1.ShowCellToolTips = true;
            dgv1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


            foreach (DataGridViewColumn col in dgv1.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
    }
}
