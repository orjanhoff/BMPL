using BMPL.Properties;
using System;
using System.Collections.Generic;
using System.Data;
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

            /*switch (columns[0].GetType() != typeof(string))
            {
                case true:  _dtbl.DefaultView.Sort = Int64.Parse(columns[0]) + " asc";
                            _dtbl = _dtbl.DefaultView.ToTable();
                            break;
            }*/

            foreach (DataRow row in _dtbl.Rows)
            {
                int num = dgvAddRow(_dgv);

                for (int i = 0; i<= columns.Length-1; i++)
                {
                    _dgv.Rows[num].Cells[i].Value = row[columns[i]];

                    switch (addbtn && i.Equals(columns.Length-1))
                    {
                        case true:
                            _dgv.Rows[num].Cells[columns.Length] = new BMUiCustomControls.DataGridViewImageButtonCell(Resources.view, "Просмотр справочника");
                            break;
                        default: break;
                    }
                }
            }
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
                                    _dgv.Rows[num].Cells[i] = new BMUiCustomControls.DataGridViewImageButtonCell(Resources._lock, "Статус пользователя в системе");
                                    break;
                                default:
                                    _dgv.Rows[num].Cells[i] = new BMUiCustomControls.DataGridViewImageButtonCell(Resources.unlock, "Статус пользователя в системе");
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
                                    _dgv.Rows[num].Cells[i] = new BMUiCustomControls.DataGridViewImageButtonCell(Resources._operator, "Роль пользователя в системе");
                                    break;
                                case 2:
                                    _dgv.Rows[num].Cells[i] = new BMUiCustomControls.DataGridViewImageButtonCell(Resources.auditor, "Роль пользователя в системе");
                                    break;
                                case 3:
                                    _dgv.Rows[num].Cells[i] = new BMUiCustomControls.DataGridViewImageButtonCell(Resources.admin, "Роль пользователя в системе");
                                    break;
                            }

                            break;
                        default: break;
                    }
                }
            }
        }
    }
}
