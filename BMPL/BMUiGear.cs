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

        //Работа с DataGridView
        public static void DgvAlignCenter(DataGridView _dgv)
        {
            foreach (DataGridViewColumn col in _dgv.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        //Пошаговое заполнение сетки
        public static void DgvFillData(DataGridView _dgv, DataTable _dtbl, string[] columns)
        {
            switch (columns.Length > 0)
            {
                case false: throw new BMUiCustomControls.UIException("{0}: Не указаны наименования колонок в талице с данными");
                default: 
                            switch (_dtbl.Rows.Count>0)
                            {
                                case false: throw new BMUiCustomControls.UIException("{0}: Таблица с данными не содежит строк");
                                default: break;
                            }

                        break;
            }

            foreach (DataRow row in _dtbl.Rows)
            {
                int num = dgvAddRow(_dgv);

                for (int i = 0; i<= columns.Length-1; i++)
                {
                    _dgv.Rows[num].Cells[i].Value = row[columns[i]];

                    switch (i.Equals(columns.Length-1))
                    {
                        case true:
                            _dgv.Rows[num].Cells[columns.Length] = new BMUiCustomControls.DataGridViewImageButtonCell(Resources.view, "Просмотр справочника");
                            break;
                        default: break;
                    }
                }
            }
        }
    }
}
