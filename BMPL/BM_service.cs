using AdvancedDataGridView;
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
    public partial class BM_service : Form
    {
        BMLoggingGear logger = new BMLoggingGear(typeof(BM_service), BMInitGear.Bm_path_log);

        public BM_service(DataTable data)
        {
            logger.Trace("Панель управления сервисами: инициализация");
            InitializeComponent();

            logger.Trace("Панель управления сервисами: установка атрибутов визуализации");
            BMGridGear.SetCellAlignment(tree1, BMGridGear.CellAlign.CenterAndLeft);
            BMGridGear.SetVisualAttributes(tree1, BMGridGear.AttrSetType.Service);

            logger.Trace("Панель управления сервисами: построение данных для отображения");

            try
            {
                new BMGridGear(BMGridGear.AttrSetType.Service).AssignTable(tree1, data);
            }
            catch (Exception ex)
            {
                BMUiGear.Alert(ex.Message, "Ошибка приложения");
            }
        }

       private void BM_service_Load(object sender, EventArgs e)
        {
            attachmentColumn.DefaultCellStyle.NullValue = null;

            // load image strip
            this.imageStrip.ImageSize = new Size(16, 16);
            this.imageStrip.TransparentColor = Color.Magenta;
            this.imageStrip.Images.AddStrip(Resources.parentservice);
            this.imageStrip.Images.AddStrip(Resources.childservice);
            tree1.ImageList = imageStrip;
        }

        private void treeGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (TreeGridView)sender;
            BMUiCustomControls.DataGridViewImageButtonCell cell = senderGrid.Rows[e.RowIndex].Cells[e.ColumnIndex] as BMUiCustomControls.DataGridViewImageButtonCell;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 5 && Int64.Parse(tree1.SelectedCells[9].Value.ToString()).Equals(0))
                {
                    var q = MessageBox.Show("Изменить состояние сервиса?", tree1.SelectedCells[1].Value.ToString(), MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (q == DialogResult.Yes)
                    {
                        var dgvibc = tree1.SelectedCells[5] as BMUiCustomControls.DataGridViewImageButtonCell;

                        switch (int.Parse(dgvibc.Val.ToString()))
                        {
                            case 1: BMUiGear.ManageService(tree1, 0); break;
                            case 0: BMUiGear.ManageService(tree1, 1); break;
                        }
                    }
                }

                if (e.ColumnIndex == 5 && !Int64.Parse(tree1.SelectedCells[9].Value.ToString()).Equals(0))
                {
                    var q = MessageBox.Show("Изменить статус обработки сервиса?", tree1.SelectedCells[1].Value.ToString(), MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (q == DialogResult.Yes)
                    {
                        var dgvibc = tree1.SelectedCells[5] as BMUiCustomControls.DataGridViewImageButtonCell;

                        switch (int.Parse(dgvibc.Val.ToString()))
                        {
                            case 1: BMUiGear.ManageWorkType(tree1, 0); break;
                            case 0: BMUiGear.ManageWorkType(tree1, 1); break;
                        }
                    }
                }
            }
        }

        internal class AttachmentColumnHeader : DataGridViewColumnHeaderCell
        {
            public Image _image;
            public AttachmentColumnHeader(Image img)
                : base()
            {
                this._image = img;
            }
            protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates dataGridViewElementState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
            {
                base.Paint(graphics, clipBounds, cellBounds, rowIndex, dataGridViewElementState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
                graphics.DrawImage(_image, cellBounds.X + 4, cellBounds.Y + 2);
            }
            protected override object GetValue(int rowIndex)
            {
                return null;
            }
        }
    }
}
