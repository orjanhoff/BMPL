using BMApp.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace BMApp
{
    public partial class IntegrationForm : Form
    {
        public IntegrationForm()
        {
            InitializeComponent();
            SwitchFormCaption(BMMSMQGear.getInstance.IsOn);
            SetCellAlignment();
            BuildData();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var q = MessageBox.Show("Включить узел интеграции?", "Управление интеграцией", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (q == DialogResult.Yes)
            {
                if (BMMSMQGear.getInstance.IsOn)
                {
                    MessageBox.Show("Узел интеграции уже запущен", "Управление интеграцией", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                BMMSMQGear.getInstance.SwitchAll(true);
                SwitchFormCaption(BMMSMQGear.getInstance.IsOn);
                SwitchUiObjects(true, false);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var q = MessageBox.Show("Отключить узел интеграции?", "Управление интеграцией", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (q == DialogResult.Yes)
            {
                if (!BMMSMQGear.getInstance.IsOn)
                {
                    MessageBox.Show("Узел интеграции уже отключен", "Управление интеграцией", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                BMMSMQGear.getInstance.SwitchAll(false);
                SwitchFormCaption(BMMSMQGear.getInstance.IsOn);
                SwitchUiObjects(false, false);
            }
        }

        public void SetCellAlignment()
        {
            dgv1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv1.EnableHeadersVisualStyles = false;
            dgv1.ShowCellToolTips = true;
            dgv1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


            foreach (DataGridViewColumn col in dgv1.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void SwitchUiObjects(bool status, bool flag)
        {
            foreach (DataGridViewRow row in dgv1.Rows)
            {
                SwitchOneUiObject(row.Index, status, flag);
            }
        }

        private void SwitchOneUiObject (int index, bool status, bool flag = true)
        {
            Image icon = Resources.off;

            switch (status)
            {
                case true: icon = Resources.on; break;
            }

            if (dgv1.Rows[index].Cells[0].Value.Equals("mqServer"))
            {
                if (flag)
                    BMMSMQGear.getInstance.SwitchReceive(status);

                dgv1.Rows[index].Cells[2].Value = icon;
                dgv1.Rows[index].Cells[3] = new BMUiCustomControls.DataGridViewImageButtonCell(BMMSMQGear.getInstance.IsReceiveOn, Resources.power, "Включить/Выключить сервис");
            }

            if (dgv1.Rows[index].Cells[0].Value.Equals("mqClient"))
            {
                if (flag)
                    BMMSMQGear.getInstance.SwitchNotify(status);

                dgv1.Rows[index].Cells[2].Value = icon;
                dgv1.Rows[index].Cells[3] = new BMUiCustomControls.DataGridViewImageButtonCell(BMMSMQGear.getInstance.IsNotifyOn, Resources.power, "Включить/Выключить сервис");
            }
        }

        private void SwitchFormCaption(bool status)
        {
            string Text = "Узел интеграции ({0})";

            switch (status)
            {
                case true: Text = string.Format(Text, "Включен"); break;
                case false: Text = string.Format(Text, "Отключен"); break;
            }

            this.Text = Text;
        }

        private void BuildData()
        {
            //Добавление mqServer
            int index = dgv1.Rows.Add();
            dgv1.Rows[index].Cells[0].Value = "mqServer";
            dgv1.Rows[index].Cells[1].Value = "Сервис входящих сообщений";

            switch (BMMSMQGear.getInstance.IsReceiveOn)
            {
                case false: dgv1.Rows[index].Cells[2].Value = Resources.off; break;
                case true:  dgv1.Rows[index].Cells[2].Value = Resources.on; break;
            }

            dgv1.Rows[index].Cells[3] = new BMUiCustomControls.DataGridViewImageButtonCell(BMMSMQGear.getInstance.IsReceiveOn, Resources.power, "Включить/Выключить сервис");

            //Добавление mqClient
            index = dgv1.Rows.Add();
            dgv1.Rows[index].Cells[0].Value = "mqClient";
            dgv1.Rows[index].Cells[1].Value = "Сервис исходящих сообщений";

            switch (BMMSMQGear.getInstance.IsNotifyOn)
            {
                case false: dgv1.Rows[index].Cells[2].Value = Resources.off; break;
                case true: dgv1.Rows[index].Cells[2].Value = Resources.on; break;
            }

            dgv1.Rows[index].Cells[3] = new BMUiCustomControls.DataGridViewImageButtonCell(BMMSMQGear.getInstance.IsNotifyOn, Properties.Resources.power, "Включить/Выключить сервис");
        }

        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            BMUiCustomControls.DataGridViewImageButtonCell cell = senderGrid.Rows[e.RowIndex].Cells[e.ColumnIndex] as BMUiCustomControls.DataGridViewImageButtonCell;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                    var q = MessageBox.Show("Изменить состояние сервиса?", dgv1.SelectedCells[0].Value.ToString(), MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (q == DialogResult.Yes)
                    {
                        var dgvibc = dgv1.SelectedCells[3] as BMUiCustomControls.DataGridViewImageButtonCell;

                        switch ((bool)dgvibc.Val)
                        {
                            case true:  SwitchOneUiObject(e.RowIndex, false); break;
                            case false:
                                if (!BMMSMQGear.getInstance.IsOn)
                                {
                                    MessageBox.Show("Нельзя включить сервис, т.к. узел интеграции отключен", "Управление интеграцией", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }

                                SwitchOneUiObject(e.RowIndex, true); break;
                        }
                    }
                }
            }
    }
}
