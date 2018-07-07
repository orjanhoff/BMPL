using System;
using System.Drawing;
using System.Windows.Forms;

namespace BMApp
{
    public partial class ContentForm : Form
    {
        public ContentForm(params string[] data)
        {
            InitializeComponent();

            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;

            propertiesToolStripMenuItem.MouseDown += new MouseEventHandler(propertiesToolStripMenuItem_MouseDown);

            switch (data.Length)
            {
                case 2: Text = data[1] ?? data[0]; break;
                case 1: Text = data[0]; break;
                case 0: BMUiGear.Alert("{0}: Не задан справочник", "Ошибка приложения");
                    return;
            }

            BMGridGear.SetCellAlignment(dgv1, BMGridGear.CellAlign.CenterAndLeft);
            BMGridGear.SetVisualAttributes(dgv1);

            try
            {
                new BMGridGear().AssignTable(dgv1, BMHeartBeat.Cache[data[0]], 0, false, "ierrcode", "serrmsg");
            }
            catch (Exception ex)
            {
                BMUiGear.Alert(ex.Message, "Ошибка приложения");
            }
        }

        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void propertiesToolStripMenuItem_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    {
                        ToolStripMenuItem tsmi = (ToolStripMenuItem)sender;
                        cms1.Show(this, new Point(tsmi.Bounds.Location.X + tsmi.Width, tsmi.Bounds.Location.Y + tsmi.Height));
                    }
                    break;
            }
        }
    }
}
