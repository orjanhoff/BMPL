using AdvancedDataGridView;
using BMPL.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMPL
{
    class BMUiGear
    {
        //Добавление строки к сетке
        private static int dgvAddRow(DataGridView _dgv)
        {
            _dgv.Rows.Add();
            return _dgv.Rows.Count - 1;
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

        //Работа с DataGridView: Все по центру
        public static void DgvAlignCenter(DataGridView _dgv)
        {
            foreach (DataGridViewColumn col in _dgv.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        //Работа с DataGridView: Ключ по центру, остальное по левому краю
        public static void DgvAlignCenterAndLeft(DataGridView _dgv)
        {
            foreach (DataGridViewColumn col in _dgv.Columns)
            {
                switch (col.Index.Equals(0))
                {
                    case true:
                        col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        break;
                    default: 
                        col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        break;
                }
            }
        }

        //Установка атрибутов DataGridView для работы со справочниками
        public static void DgvConfigureDictionary(DataGridView _dgv)
        {
            _dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _dgv.EnableHeadersVisualStyles = false;
            _dgv.ShowCellToolTips = true;
            _dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _dgv.Columns [1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        //Установка атрибутов DataGridView для работы с пользователями
        public static void DgvConfigureUser(DataGridView _dgv)
        {
            _dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _dgv.EnableHeadersVisualStyles = false;
            _dgv.ShowCellToolTips = true;
            _dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _dgv.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        //Установка атрибутов дерева
        public static void TreeConfigureService(TreeGridView tree)
        {
            tree.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tree.EnableHeadersVisualStyles = false;
            tree.ShowCellToolTips = true;
            tree.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            tree.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        //Пошаговое заполнение сетки
        public static void DgvFillData(DataGridView _dgv, DataTable _dtbl, bool addbtn = true, params string[] columns)
        {
            switch (columns.Length > 0)
            {
                case false: throw new BMUiCustomControls.UIException("{0}: Не указаны наименования колонок в таблице с данными");
                default:
                    switch (_dtbl.Rows.Count > 0)
                    {
                        case false: throw new BMUiCustomControls.UIException("{0}: Таблица с данными не содержит строк");
                        default: break;
                    }

                    break;
            }

            DgvFillByRow(_dgv, _dtbl, 0, addbtn, columns);
        }

        public static void DgvFillData(DataGridView _dgv, DataTable _dtbl, params string[] columns)
        {
            switch (columns.Length > 0)
            {
                case false: throw new BMUiCustomControls.UIException("{0}: Не указаны наименования колонок в таблице с данными");
                default:
                    switch (_dtbl.Rows.Count > 0)
                    {
                        case false: throw new BMUiCustomControls.UIException("{0}: Таблица с данными не содержит строк");
                        default: break;
                    }

                    break;
            }

            foreach (DataRow row in _dtbl.Rows)
            {
                int num = dgvAddRow(_dgv);

                for (int i = 0; i <= columns.Length - 1; i++)
                {
                    _dgv.Rows[num].Cells[i].Value = row[columns[i]];

                    switch (i.Equals(columns.Length - 2))
                    {
                        case true:
                            switch (Int64.Parse(row[columns[i]].ToString()).Equals(0))
                            {
                                case true:
                                    _dgv.Rows[num].Cells[i] = new BMUiCustomControls.DataGridViewImageButtonCell(row[columns[i]], Resources._lock, "Статус пользователя в системе");
                                    break;
                                default:
                                    _dgv.Rows[num].Cells[i] = new BMUiCustomControls.DataGridViewImageButtonCell(row[columns[i]], Resources.unlock, "Статус пользователя в системе");
                                    break;
                            }

                            break;
                        default: break;
                    }

                    switch (i.Equals(columns.Length - 1))
                    {
                        case true:
                            switch (Int64.Parse(row[columns[i]].ToString()))
                            {
                                case 1:
                                    _dgv.Rows[num].Cells[i] = new BMUiCustomControls.DataGridViewImageButtonCell(row[columns[i]], Resources._operator, "Роль пользователя в системе");
                                    break;
                                case 2:
                                    _dgv.Rows[num].Cells[i] = new BMUiCustomControls.DataGridViewImageButtonCell(row[columns[i]], Resources.auditor, "Роль пользователя в системе");
                                    break;
                                case 3:
                                    _dgv.Rows[num].Cells[i] = new BMUiCustomControls.DataGridViewImageButtonCell(row[columns[i]], Resources.admin, "Роль пользователя в системе");
                                    break;
                            }

                            break;
                        default: break;
                    }
                }
            }
        }

        public static void DgvFillData(DataGridView _dgv, DataTable _dtbl, int columns, bool addbtn = true)
        {
            switch (columns > 0)
            {
                case false: throw new BMUiCustomControls.UIException("{0}: Не указаны наименования колонок в таблице с данными");
                default:
                    switch (_dtbl.Rows.Count > 0)
                    {
                        case false: throw new BMUiCustomControls.UIException("{0}: Таблица с данными не содержит строк");
                        default: break;
                    }

                    break;
            }

            DgvFillByRow(_dgv, _dtbl, columns, addbtn);
        }

        //Добавление данных на DGV
        private static void DgvFillByRow(DataGridView _dgv, DataTable _dtbl, int col = 0, bool addbtn = true, params string[] columns)
        {
            if (col.Equals(0) && columns.Length.Equals(0))
            {
                throw new BMUiCustomControls.UIException("{0}: Не указан массив для определения данных");
            }

            if (col > 0)
            {
                foreach (DataRow row in _dtbl.Rows)
                {
                    int num = dgvAddRow(_dgv);

                    for (int i = 0; i <= col - 1; i++)
                    {
                        _dgv.Rows[num].Cells[i].Value = row[i];

                        switch (addbtn && i.Equals(col - 1))
                        {
                            case true:
                                _dgv.Rows[num].Cells[col] = new BMUiCustomControls.DataGridViewImageButtonCell(Resources.view, "Просмотр");
                                break;
                            default: break;
                        }
                    }
                }
            }

            else
            {
                foreach (DataRow row in _dtbl.Rows)
                {
                    int num = dgvAddRow(_dgv);

                    for (int i = 0; i <= columns.Length - 1; i++)
                    {
                        _dgv.Rows[num].Cells[i].Value = row[columns[i]];

                        switch (addbtn && i.Equals(columns.Length - 1))
                        {
                            case true:
                                _dgv.Rows[num].Cells[columns.Length] = new BMUiCustomControls.DataGridViewImageButtonCell(Resources.view, "Просмотр");
                                break;
                            default: break;
                        }
                    }
                }
            }
        }

        //Добавление данных на дерево
        public static void TreeFillData(TreeGridView tree, DataTable _dtbl)
        {
                    switch (_dtbl.Rows.Count > 0)
                    {
                        case false: throw new BMUiCustomControls.UIException("{0}: Таблица с данными не содержит строк");
                        default: break;
                    }

            //DataTable cdata = (from DataRow row in _dtbl.Rows where row.Field<Int64>("isrvparentid").Equals(0) select row).CopyToDataTable();

            //Font boldFont = new Font(tree.DefaultCellStyle.Font, FontStyle.Bold);

            TreeGridNode node = new TreeGridNode();
            TreeGridNode node2 = new TreeGridNode();

            foreach (DataRow row in _dtbl.Rows)
            {
                if (Int64.Parse(row["isrvparentid"].ToString()).Equals(0))
                {
                    node = tree.Nodes.Add(null, @row["ssrvname"], @row["ssrvversion"], @row["ssrvdescription"],null,null,null,null,@row["isrvid"], @row["isrvparentid"]);
                    node.ImageIndex = 0;

                    BMController.ChangeServiceStatus(int.Parse(row[0].ToString()), int.Parse(row[4].ToString()));

                    switch (Int64.Parse(row[4].ToString()))
                    {
                        case 0: tree.Rows[node.Index].Cells[4].Value = Resources.off; break;
                        case 1: tree.Rows[node.Index].Cells[4].Value = Resources.on; break;
                        default: tree.Rows[node.Index].Cells[4].Value = Resources.wrong; break;
                    }

                    tree.Rows[node.Index].Cells[5] = new BMUiCustomControls.DataGridViewImageButtonCell(@row[4], Resources.power, "Включить/Выключить сервис");
                    tree.Rows[node.Index].Cells[6] = new BMUiCustomControls.DataGridViewImageButtonCell(Resources.srvconfig, "Настройки сервиса");
                    tree.Rows[node.Index].Cells[7] = new BMUiCustomControls.DataGridViewImageButtonCell(Resources.srvxml, "XML файл сервиса");

                    //Добавление типов инициализации запуска сервиса
                    DataTable cdata = 
                                        (
                                            from DataRow rowwt in BMUiConst.UiConst.Cache["service_work_type"].Rows
                                            where rowwt.Field<Int64>("isrvid").Equals(row["isrvid"]) select rowwt
                                        )   .CopyToDataTable();

                    if (cdata.Rows.Count>0)
                    {
                        foreach (DataRow crowwt in cdata.Rows)
                        {
                            node2 = node.Nodes.Add(null, @crowwt["swtname"], null, @crowwt["swtdesc"], null, null, null, null, @crowwt["isrvworktype"], @crowwt["isrvid"]);
                            node2.ImageIndex = 1;

                            switch (Int64.Parse(crowwt[4].ToString()))
                            {
                                case 1: node.Nodes[node2.Index].Cells[4].Value = Resources.checkok; break;
                                default: node.Nodes[node2.Index].Cells[4].Value = Resources.checkno; break;
                            }

                            node.Nodes[node2.Index].Cells[2] = new DataGridViewTextBoxCell();
                            node.Nodes[node2.Index].Cells[2].ReadOnly = true;
                            node.Nodes[node2.Index].Cells[5] = new BMUiCustomControls.DataGridViewImageButtonCell(@crowwt[4], Resources.wtpower, "Включить/Выключить опцию");
                            node.Nodes[node2.Index].Cells[6] = new DataGridViewTextBoxCell();
                            node.Nodes[node2.Index].Cells[6].ReadOnly = true;
                            node.Nodes[node2.Index].Cells[7] = new DataGridViewTextBoxCell();
                            node.Nodes[node2.Index].Cells[7].ReadOnly = true;
                        }
                    }
                }
            }
        }

        //Добавление лидирующих пробелов к строке
        private static string AddLeadSpace (string mystring)
        {
            return " " + mystring;
        }

        //Установка статуса пользователя
        public static void changeUserStatus(DataGridView dgv, int status)
        {
            Image icon = Resources._lock;

            switch (status)
            {
                case 1: icon = Resources.unlock; break;
            }

            new BMDaGear().ExecuteQuery(
                                     "update user set iuserstatus=" +
                                     status                         +
                                     AddLeadSpace("where iuserid=") +
                                     dgv.SelectedCells[0].Value.ToString()
                                     );

            DataRow row = BMUiConst.UiConst.Cache["user"]
                                                            .Select("iuserid=" + dgv.SelectedCells[0]
                                                            .Value
                                                            .ToString())
                                                            .First();
            row["iuserstatus"] = status;

            dgv.Rows[dgv.SelectedCells[0].RowIndex].Cells[3] = new BMUiCustomControls.DataGridViewImageButtonCell(status, icon, "Статус пользователя в системе");
        }

        //Установка роли пользователя
        public static void changeUserRole(DataGridView dgv, int role)
        {
            Image icon = Resources._operator;

            switch (role)
            {
                case 2: icon = Resources.auditor; break;
                case 3: icon = Resources.admin; break;
            }

            new BMDaGear().ExecuteQuery(
                         "update user set iuserrole="   +
                         role                           +
                         AddLeadSpace("where iuserid=") +
                         dgv.SelectedCells[0].Value.ToString()
                         );

            DataRow row = BMUiConst.UiConst.Cache["user"]
                                                            .Select("iuserid=" + dgv.SelectedCells[0]
                                                            .Value
                                                            .ToString())
                                                            .First();
            row["iuserrole"] = role;

            dgv.Rows[dgv.SelectedCells[0].RowIndex].Cells[4] = new BMUiCustomControls.DataGridViewImageButtonCell(role, icon, "Роль пользователя в системе");
        }

        //Установка статуса сервиса
        public static void changeServiceStatus (TreeGridView tree, int status)
        {
            Image icon = Resources.off;

            switch (status)
            {
                case 1: icon = Resources.on; break;
            }

            new BMDaGear().ExecuteQuery(
                                     "update service set isrvstatus=" +
                                     status +
                                     AddLeadSpace("where isrvid=") +
                                     tree.SelectedCells[8].Value.ToString()
                                     );

            DataRow row = BMUiConst.UiConst.Cache["service"]
                                                            .Select("isrvid=" + tree.SelectedCells[8]
                                                            .Value
                                                            .ToString())
                                                            .First();
            row["isrvstatus"] = status;

            BMController.ChangeServiceStatus(int.Parse(tree.SelectedCells[8].Value.ToString()),status);

            tree.SelectedCells[4].Value = icon;
            tree.Rows[tree.SelectedCells[5].RowIndex].Cells[5] = new BMUiCustomControls.DataGridViewImageButtonCell(status, Resources.power, "Включить/Выключить сервис");
        }

        //Установка статуса типа обработки
        public static void changeWTStatus(TreeGridView tree, int status)
        {
            Image icon = Resources.checkno;

            switch (status)
            {
                case 1: icon = Resources.checkok; break;
            }
            new BMDaGear().ExecuteQuery(
                                     "update service_work_type set iwtstatus=" +
                                     status +
                                     AddLeadSpace("where isrvid=") +
                                     tree.SelectedCells[9].Value.ToString() +
                                     AddLeadSpace("and isrvworktype=") +
                                     tree.SelectedCells[8].Value.ToString()
                                     );

            DataRow row = BMUiConst.UiConst.Cache["service_work_type"]
                                                            .Select("isrvid=" + tree.SelectedCells[9].Value.ToString() + 
                                                                     AddLeadSpace("and isrvworktype=") + tree.SelectedCells[8].Value.ToString()
                                                                   )
                                                            .First();
            row["iwtstatus"] = status;

            tree.SelectedCells[4].Value = icon;
            tree.Rows[tree.SelectedCells[5].RowIndex].Cells[5] = new BMUiCustomControls.DataGridViewImageButtonCell(status, Resources.wtpower, "Включить/Выключить опцию");
        }
    }
}
