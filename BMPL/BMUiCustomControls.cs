using System;
using System.Drawing;
using System.Windows.Forms;

namespace BMPL
{
    class BMUiCustomControls
    {
        public class DataGridViewImageButtonCell : DataGridViewButtonCell
        {
            Image icon;
            object val;

            public DataGridViewImageButtonCell(Image img)
            {
                icon = img;
            }

            public DataGridViewImageButtonCell(Image img, string tooltiptext)
            {
                icon = img;
                base.ToolTipText = tooltiptext;
            }

            public DataGridViewImageButtonCell(object val, Image img, string tooltiptext)
            {
                this.val = val;
                icon = img;
                base.ToolTipText = tooltiptext;
            }

            public object Val
            {
                get { return this.val; }
                set { this.val = value; }
            }

            public Image Icon
            {
                set { this.icon=value; }
            }

            protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates elementState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
            {
                base.Paint(graphics, clipBounds, cellBounds, rowIndex, elementState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
                graphics.DrawImage(icon, cellBounds);
            }
        }

        [Serializable]
        public class UIException : Exception
        {
            public UIException() : base() { }
            public UIException(string message) : base(message) { }
            public UIException(string message, Exception inner) : base(message, inner) { }

            public static void Alert(string err, string header)
            {
                MessageBox.Show(err, string.Format("[{0}]", header ?? "Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            public static void Warn(string msg, string header)
            {
                MessageBox.Show(msg, string.Format("[{0}]", header ?? "Information"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            public static void Inform(string msg, string header)
            {
                MessageBox.Show(msg, string.Format("[{0}]", header ?? "Information"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
