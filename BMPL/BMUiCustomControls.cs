using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace BMApp
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

        public class RoundButton : Button
        {
            protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
            {
                GraphicsPath grPath = new GraphicsPath();
                grPath.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
                Region = new Region(grPath);
                Height = 30;
                Width = 30;
                base.OnPaint(e);
            }
        }

        [Serializable]
        public class UIException : Exception
        {
            public UIException() : base() { }
            public UIException(string message) : base(message) { }
            public UIException(string message, Exception inner) : base(message, inner) { }
        }
    }
}
