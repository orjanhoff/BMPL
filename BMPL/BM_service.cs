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
        public BM_service(DataTable data)
        {
            InitializeComponent();

            BMUiGear.DgvAlignCenterAndLeft(treeGridView1);
            BMUiGear.TreeConfigureService(treeGridView1);

            try
            {
                BMUiGear.TreeFillData(treeGridView1, data);
            }
            catch (Exception ex)
            {
                BMUiCustomControls.UIException.Alert(ex.Message, "Ошибка приложения");
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
            treeGridView1.ImageList = imageStrip;
        }

        private void treeGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (TreeGridView)sender;
            BMUiCustomControls.DataGridViewImageButtonCell cell = senderGrid.Rows[e.RowIndex].Cells[e.ColumnIndex] as BMUiCustomControls.DataGridViewImageButtonCell;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                MessageBox.Show(treeGridView1.Rows[treeGridView1.SelectedCells[0].RowIndex].Cells[8].Value.ToString());
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
