namespace BMPL
{
    partial class BM_service
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tree1 = new AdvancedDataGridView.TreeGridView();
            this.imageStrip = new System.Windows.Forms.ImageList(this.components);
            this.attachmentColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column2 = new AdvancedDataGridView.TreeGridColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.b0 = new System.Windows.Forms.DataGridViewImageColumn();
            this.b1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.b2 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.b3 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.parentid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tree1)).BeginInit();
            this.SuspendLayout();
            // 
            // tree1
            // 
            this.tree1.AllowUserToAddRows = false;
            this.tree1.AllowUserToDeleteRows = false;
            this.tree1.AllowUserToOrderColumns = true;
            this.tree1.AllowUserToResizeColumns = false;
            this.tree1.AllowUserToResizeRows = false;
            this.tree1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tree1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tree1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.tree1.BackgroundColor = System.Drawing.Color.LightSteelBlue;
            this.tree1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.attachmentColumn,
            this.Column2,
            this.Column3,
            this.Column4,
            this.b0,
            this.b1,
            this.b2,
            this.b3,
            this.id,
            this.parentid});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tree1.DefaultCellStyle = dataGridViewCellStyle1;
            this.tree1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.tree1.ImageList = null;
            this.tree1.Location = new System.Drawing.Point(12, 12);
            this.tree1.Name = "tree1";
            this.tree1.RowHeadersVisible = false;
            this.tree1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tree1.ShowLines = false;
            this.tree1.Size = new System.Drawing.Size(990, 275);
            this.tree1.TabIndex = 4;
            this.tree1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.treeGridView1_CellContentClick);
            // 
            // imageStrip
            // 
            this.imageStrip.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageStrip.ImageSize = new System.Drawing.Size(16, 16);
            this.imageStrip.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // attachmentColumn
            // 
            this.attachmentColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.attachmentColumn.FillWeight = 14.62532F;
            this.attachmentColumn.Frozen = true;
            this.attachmentColumn.HeaderText = "";
            this.attachmentColumn.Name = "attachmentColumn";
            this.attachmentColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.attachmentColumn.Visible = false;
            this.attachmentColumn.Width = 25;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column2.DefaultNodeImage = null;
            this.Column2.FillWeight = 91.16447F;
            this.Column2.HeaderText = "Наименование";
            this.Column2.Name = "Column2";
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column2.Width = 200;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column3.FillWeight = 203.0456F;
            this.Column3.HeaderText = "Версия";
            this.Column3.Name = "Column3";
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column4.FillWeight = 91.16447F;
            this.Column4.HeaderText = "Описание";
            this.Column4.MinimumWidth = 200;
            this.Column4.Name = "Column4";
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column4.Width = 400;
            // 
            // b0
            // 
            this.b0.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.b0.Description = "Статус сервиса";
            this.b0.HeaderText = "";
            this.b0.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.b0.MinimumWidth = 25;
            this.b0.Name = "b0";
            this.b0.ReadOnly = true;
            this.b0.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.b0.ToolTipText = "Статус сервиса";
            this.b0.Width = 25;
            // 
            // b1
            // 
            this.b1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.b1.HeaderText = "";
            this.b1.MinimumWidth = 25;
            this.b1.Name = "b1";
            this.b1.ReadOnly = true;
            this.b1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.b1.Width = 25;
            // 
            // b2
            // 
            this.b2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.b2.HeaderText = "";
            this.b2.MinimumWidth = 25;
            this.b2.Name = "b2";
            this.b2.ReadOnly = true;
            this.b2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.b2.Width = 25;
            // 
            // b3
            // 
            this.b3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.b3.HeaderText = "";
            this.b3.MinimumWidth = 25;
            this.b3.Name = "b3";
            this.b3.ReadOnly = true;
            this.b3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.b3.Width = 25;
            // 
            // id
            // 
            this.id.HeaderText = "";
            this.id.Name = "id";
            this.id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.id.Visible = false;
            // 
            // parentid
            // 
            this.parentid.HeaderText = "";
            this.parentid.Name = "parentid";
            this.parentid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.parentid.Visible = false;
            // 
            // BM_service
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1014, 411);
            this.Controls.Add(this.tree1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "BM_service";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Панель управления сервисами";
            this.Load += new System.EventHandler(this.BM_service_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tree1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private AdvancedDataGridView.TreeGridView tree1;
        private System.Windows.Forms.ImageList imageStrip;
        private System.Windows.Forms.DataGridViewImageColumn attachmentColumn;
        private AdvancedDataGridView.TreeGridColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewImageColumn b0;
        private System.Windows.Forms.DataGridViewButtonColumn b1;
        private System.Windows.Forms.DataGridViewButtonColumn b2;
        private System.Windows.Forms.DataGridViewButtonColumn b3;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn parentid;
    }
}