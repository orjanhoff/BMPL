using AdvancedDataGridView;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace BMPL
{
    //dgv-DataGridView; tgv-TreeGridView;

    class BMGridGear
    {
        public enum GridType { DataGridView=1, TreeGridView=2 }

        public enum CellAlign { Center= 1, CenterAndLeft = 2 }

        public enum AttrSetType { Dictionary=1, User=2, Service=3 }

        private AttrSetType flag;

        //0. Конструктор и установка флага сетки
        public BMGridGear (AttrSetType flag = AttrSetType.Dictionary)
        {
            this.flag = flag;
        }

        //1. Добавление строки к dgw
        private static int CreateRow(object obj, GridType gtype = GridType.DataGridView)
        {
            if (gtype.Equals(GridType.DataGridView))
            {
                return ((DataGridView)obj).Rows.Add();
            }
            else return -1;
        }

        //2. Выравнивание ячеек
        public static void SetCellAlignment(DataGridView dgv, CellAlign cellalign = CellAlign.Center)
        {
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                if (cellalign == CellAlign.Center)
                {
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                else if (cellalign == CellAlign.CenterAndLeft)
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
        }

        //3. Установка атрибутов отображения
        public static void SetVisualAttributes (DataGridView dgv, AttrSetType ast = AttrSetType.Dictionary)
        {
            int i = (int)ast;

            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.EnableHeadersVisualStyles = false;
            dgv.ShowCellToolTips = true;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        //4. Заполнение сетки значениями из таблицы данных по заданным параметрам
        private static void assigntable(DataGridView dgv, DataTable dtbl, int col = 0, bool addbtn = true, params string[] columns)
        {
            if (col.Equals(0) && columns.Length.Equals(0))
            {
                throw new BMUiCustomControls.UIException("{0}: Не указан массив для определения данных");
            }

            if (col > 0)
            {
                foreach (DataRow row in dtbl.Rows)
                {
                    int num = CreateRow(dgv);

                    for (int i = 0; i <= col - 1; i++)
                    {
                        dgv.Rows[num].Cells[i].Value = row[i];

                        switch (addbtn && i.Equals(col - 1))
                        {
                            case true:
                                dgv.Rows[num].Cells[col] = new BMUiCustomControls.DataGridViewImageButtonCell(Properties.Resources.view, "Просмотр");
                                break;
                            default: break;
                        }
                    }
                }
            }

            else
            {
                foreach (DataRow row in dtbl.Rows)
                {
                    int num = CreateRow(dgv);

                    for (int i = 0; i <= columns.Length - 1; i++)
                    {
                        dgv.Rows[num].Cells[i].Value = row[columns[i]];

                        switch (addbtn && i.Equals(columns.Length - 1))
                        {
                            case true:
                                dgv.Rows[num].Cells[columns.Length] = new BMUiCustomControls.DataGridViewImageButtonCell(Properties.Resources.view, "Просмотр");
                                break;
                            default: break;
                        }
                    }
                }
            }
        }

        private static void assigntable(DataGridView dgv, DataTable dtbl, params string[] columns)
        {
            foreach (DataRow row in dtbl.Rows)
            {
                int num = CreateRow(dgv);

                for (int i = 0; i <= columns.Length - 1; i++)
                {
                    dgv.Rows[num].Cells[i].Value = row[columns[i]];

                    switch (i.Equals(columns.Length - 2))
                    {
                        case true:
                            switch (Int64.Parse(row[columns[i]].ToString()).Equals(0))
                            {
                                case true:
                                    dgv.Rows[num].Cells[i] = new BMUiCustomControls.DataGridViewImageButtonCell(row[columns[i]], Properties.Resources._lock, "Статус пользователя в системе");
                                    break;
                                default:
                                    dgv.Rows[num].Cells[i] = new BMUiCustomControls.DataGridViewImageButtonCell(row[columns[i]], Properties.Resources.unlock, "Статус пользователя в системе");
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
                                    dgv.Rows[num].Cells[i] = new BMUiCustomControls.DataGridViewImageButtonCell(row[columns[i]], Properties.Resources._operator, "Роль пользователя в системе");
                                    break;
                                case 2:
                                    dgv.Rows[num].Cells[i] = new BMUiCustomControls.DataGridViewImageButtonCell(row[columns[i]], Properties.Resources.auditor, "Роль пользователя в системе");
                                    break;
                                case 3:
                                    dgv.Rows[num].Cells[i] = new BMUiCustomControls.DataGridViewImageButtonCell(row[columns[i]], Properties.Resources.admin, "Роль пользователя в системе");
                                    break;
                            }

                            break;
                        default: break;
                    }
                }
            }
        }

        private static void assigntable(TreeGridView tree, DataTable dtbl)
        {
            TreeGridNode node = new TreeGridNode();
            TreeGridNode node2 = new TreeGridNode();

            foreach (DataRow row in dtbl.Rows)
            {
                if (Int64.Parse(row["isrvparentid"].ToString()).Equals(0))
                {
                    node = tree.Nodes.Add(null, @row["ssrvname"], @row["ssrvversion"], @row["ssrvdescription"], null, null, null, null, @row["isrvid"], @row["isrvparentid"]);
                    node.ImageIndex = 0;

                    BMSrvGear.ManageService(row[0].ToString(), row[4].ToString());

                    switch (Int64.Parse(row[4].ToString()))
                    {
                        case 0: tree.Rows[node.Index].Cells[4].Value = Properties.Resources.off; break;
                        case 1: tree.Rows[node.Index].Cells[4].Value = Properties.Resources.on; break;
                        default: tree.Rows[node.Index].Cells[4].Value = Properties.Resources.wrong; break;
                    }

                    tree.Rows[node.Index].Cells[5] = new BMUiCustomControls.DataGridViewImageButtonCell(@row[4], Properties.Resources.power, "Включить/Выключить сервис");
                    tree.Rows[node.Index].Cells[6] = new BMUiCustomControls.DataGridViewImageButtonCell(Properties.Resources.srvconfig, "Настройки сервиса");
                    tree.Rows[node.Index].Cells[7] = new BMUiCustomControls.DataGridViewImageButtonCell(Properties.Resources.srvxml, "XML файл сервиса");

                    //Добавление типов инициализации запуска сервиса
                    DataTable cdata =
                                        (
                                            from DataRow rowwt in BMInitGear.UiConst.Cache["service_work_type"].Rows
                                            where rowwt.Field<Int64>("isrvid").Equals(row["isrvid"])
                                            select rowwt
                                        ).CopyToDataTable();

                    if (cdata.Rows.Count > 0)
                    {
                        foreach (DataRow crowwt in cdata.Rows)
                        {
                            node2 = node.Nodes.Add(null, @crowwt["swtname"], null, @crowwt["swtdesc"], null, null, null, null, @crowwt["isrvworktype"], @crowwt["isrvid"]);
                            node2.ImageIndex = 1;

                            switch (Int64.Parse(crowwt[4].ToString()))
                            {
                                case 1: node.Nodes[node2.Index].Cells[4].Value = Properties.Resources.checkok; break;
                                default: node.Nodes[node2.Index].Cells[4].Value = Properties.Resources.checkno; break;
                            }

                            node.Nodes[node2.Index].Cells[2] = new DataGridViewTextBoxCell();
                            node.Nodes[node2.Index].Cells[2].ReadOnly = true;
                            node.Nodes[node2.Index].Cells[5] = new BMUiCustomControls.DataGridViewImageButtonCell(@crowwt[4], Properties.Resources.wtpower, "Включить/Выключить опцию");
                            node.Nodes[node2.Index].Cells[6] = new DataGridViewTextBoxCell();
                            node.Nodes[node2.Index].Cells[6].ReadOnly = true;
                            node.Nodes[node2.Index].Cells[7] = new DataGridViewTextBoxCell();
                            node.Nodes[node2.Index].Cells[7].ReadOnly = true;
                        }
                    }
                }
            }
        }

        public void AssignTable(object dgv, DataTable dtbl, int col = 0, bool addbtn = true, params string[] columns)
        {
                    switch (dtbl.Rows.Count > 0)
                    {
                        case false: throw new BMUiCustomControls.UIException("{0}: Таблица с данными не содержит строк");
                        default: break;
                    }

            switch (flag)
            {
                default: assigntable((DataGridView)dgv, dtbl, col, addbtn, columns); break;
                case AttrSetType.User: assigntable((DataGridView)dgv, dtbl, columns); break;
                case AttrSetType.Service: assigntable((TreeGridView)dgv, dtbl); break;
            }
            
        } 
    }
}
