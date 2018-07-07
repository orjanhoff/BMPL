using AdvancedDataGridView;
using BMApp.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace BMApp
{
    class BMUiGear
    {
        //Вывод сообщения об ошибке
        public static void Alert(string err, string header)
        {
            MessageBox.Show(err, string.Format("[{0}]", header ?? "Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Вывод предупреждения
        public static void Warn(string msg, string header)
        {
            MessageBox.Show(msg, string.Format("[{0}]", header ?? "Information"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        // Вывод информативного сообщения
        public static void Inform(string msg, string header)
        {
            MessageBox.Show(msg, string.Format("[{0}]", header ?? "Information"), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Установка всплывающей подсказки
        public static void SetToolTip(Control o, string t = null)
        {
            ToolTip tt = new ToolTip();
            tt.ToolTipIcon = ToolTipIcon.None;

            switch (string.IsNullOrEmpty(t))
            {
                case true:
                    tt.SetToolTip(o, o.Name.ToString());
                    break;
                case false:
                    tt.SetToolTip(o, t);
                    break;
            }
        }

        //Установка статуса пользователя
        public static void ManageUser(DataGridView dgv, int status)
        {
            Image icon = Resources._lock;

            switch (status)
            {
                case 1: icon = Resources.unlock; break;
            }

            try
            {
                BMUserGear.ManageUser(dgv.SelectedCells[0].Value.ToString(), status.ToString());
            }
            catch (Exception ex)
            {
                Alert(ex.Message, "{0}: Ошибка обработки статуса пользователя");
                return;
            }

            dgv.Rows[dgv.SelectedCells[0].RowIndex].Cells[3] = new BMUiCustomControls.DataGridViewImageButtonCell(status, icon, "Статус пользователя в системе");
        }

        //Установка роли пользователя
        public static void ManageUserRole(DataGridView dgv, int role)
        {
            Image icon = Resources._operator;

            switch (role)
            {
                case 2: icon = Resources.auditor; break;
                case 3: icon = Resources.admin; break;
            }

            try
            {
                BMUserGear.ManageUserRole(dgv.SelectedCells[0].Value.ToString(), role.ToString());
            }
            catch (Exception ex)
            {
                Alert(ex.Message, "{0}: Ошибка обработки статуса пользователя");
                return;
            }

            dgv.Rows[dgv.SelectedCells[0].RowIndex].Cells[4] = new BMUiCustomControls.DataGridViewImageButtonCell(role, icon, "Роль пользователя в системе");
        }

        //Установка статуса сервиса
        public static void ManageService(TreeGridView tree, int status)
        {
            Image icon = Resources.off;

            switch (status)
            {
                case 1: icon = Resources.on; break;
            }

            try
            {
                BMSrvGear.ManageService(tree.SelectedCells[8].Value.ToString(), status.ToString());
            }
            catch (Exception ex)
            {
                Alert(ex.Message, "{0}: Ошибка обработки сервиса");
                return;
            }

            tree.SelectedCells[4].Value = icon;
            tree.Rows[tree.SelectedCells[5].RowIndex].Cells[5] = new BMUiCustomControls.DataGridViewImageButtonCell(status, Resources.power, "Включить/Выключить сервис");
        }

        //Установка статуса типа обработки
        public static void ManageWorkType(TreeGridView tree, int status)
        {
            Image icon = Resources.checkno;

            switch (status)
            {
                case 1: icon = Resources.checkok; break;
            }

            try
            {
                BMSrvGear.ManageWorkType(tree.SelectedCells[9].Value.ToString(), status.ToString(), tree.SelectedCells[8].Value.ToString());
            }
            catch (Exception ex)
            {
                Alert(ex.Message, "{0}: Ошибка обработки сервиса");
                return;
            }

            tree.SelectedCells[4].Value = icon;
            tree.Rows[tree.SelectedCells[5].RowIndex].Cells[5] = new BMUiCustomControls.DataGridViewImageButtonCell(status, Resources.wtpower, "Включить/Выключить опцию");
        }
    }
}
