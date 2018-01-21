namespace BMPL
{
    partial class BM_api
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BM_api));
            this.cms1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmi1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi2 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.c0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.с1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.с2 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cms1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.SuspendLayout();
            // 
            // cms1
            // 
            this.cms1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.cms1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cms1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi1,
            this.tsmi2});
            this.cms1.Name = "cms1";
            this.cms1.Size = new System.Drawing.Size(152, 56);
            // 
            // tsmi1
            // 
            this.tsmi1.Image = global::BMPL.Properties.Resources.minus;
            this.tsmi1.Name = "tsmi1";
            this.tsmi1.Size = new System.Drawing.Size(151, 26);
            this.tsmi1.Text = "Удалить";
            // 
            // tsmi2
            // 
            this.tsmi2.Image = global::BMPL.Properties.Resources.plus;
            this.tsmi2.Name = "tsmi2";
            this.tsmi2.Size = new System.Drawing.Size(151, 26);
            this.tsmi2.Text = "Добавить";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.propertiesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuStrip1.ShowItemToolTips = true;
            this.menuStrip1.Size = new System.Drawing.Size(1282, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // propertiesToolStripMenuItem
            // 
            this.propertiesToolStripMenuItem.Image = global::BMPL.Properties.Resources.gear;
            this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(32, 24);
            this.propertiesToolStripMenuItem.ToolTipText = "Конфигурация";
            // 
            // dgv1
            // 
            this.dgv1.AllowUserToAddRows = false;
            this.dgv1.AllowUserToDeleteRows = false;
            this.dgv1.AllowUserToResizeColumns = false;
            this.dgv1.AllowUserToResizeRows = false;
            this.dgv1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv1.BackgroundColor = System.Drawing.Color.LightSteelBlue;
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c0,
            this.с1,
            this.c2,
            this.c3,
            this.c4,
            this.c5,
            this.с2});
            this.dgv1.Location = new System.Drawing.Point(14, 44);
            this.dgv1.Name = "dgv1";
            this.dgv1.ReadOnly = true;
            this.dgv1.RowHeadersVisible = false;
            this.dgv1.RowTemplate.Height = 24;
            this.dgv1.Size = new System.Drawing.Size(1256, 365);
            this.dgv1.TabIndex = 2;
            this.dgv1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // c0
            // 
            this.c0.Frozen = true;
            this.c0.HeaderText = "";
            this.c0.Name = "c0";
            this.c0.ReadOnly = true;
            this.c0.Visible = false;
            // 
            // с1
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.с1.DefaultCellStyle = dataGridViewCellStyle1;
            this.с1.HeaderText = "Наименование";
            this.с1.MinimumWidth = 100;
            this.с1.Name = "с1";
            this.с1.ReadOnly = true;
            this.с1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.с1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.с1.ToolTipText = "Наименование API";
            // 
            // c2
            // 
            this.c2.HeaderText = "Путь к файлу";
            this.c2.Name = "c2";
            this.c2.ReadOnly = true;
            this.c2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.c2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.c2.ToolTipText = "Путь к файлу";
            this.c2.Width = 200;
            // 
            // c3
            // 
            this.c3.HeaderText = "Атрибуты";
            this.c3.Name = "c3";
            this.c3.ReadOnly = true;
            this.c3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.c3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.c3.ToolTipText = "Атрибуты вызова";
            this.c3.Width = 200;
            // 
            // c4
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.c4.DefaultCellStyle = dataGridViewCellStyle2;
            this.c4.HeaderText = "Описание";
            this.c4.Name = "c4";
            this.c4.ReadOnly = true;
            this.c4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.c4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.c4.ToolTipText = "Описание API";
            this.c4.Width = 400;
            // 
            // c5
            // 
            this.c5.HeaderText = "Алиас";
            this.c5.Name = "c5";
            this.c5.ReadOnly = true;
            this.c5.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.c5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.c5.ToolTipText = "Алиас";
            // 
            // с2
            // 
            this.с2.HeaderText = "";
            this.с2.Name = "с2";
            this.с2.ReadOnly = true;
            this.с2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.с2.ToolTipText = "Просмотр справочника";
            this.с2.Width = 25;
            // 
            // BM_api
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1282, 428);
            this.Controls.Add(this.dgv1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BM_api";
            this.Text = "Реестр API";
            this.cms1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip cms1;
        private System.Windows.Forms.ToolStripMenuItem tsmi1;
        private System.Windows.Forms.ToolStripMenuItem tsmi2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.DataGridViewTextBoxColumn c0;
        private System.Windows.Forms.DataGridViewTextBoxColumn с1;
        private System.Windows.Forms.DataGridViewTextBoxColumn c2;
        private System.Windows.Forms.DataGridViewTextBoxColumn c3;
        private System.Windows.Forms.DataGridViewTextBoxColumn c4;
        private System.Windows.Forms.DataGridViewTextBoxColumn c5;
        private System.Windows.Forms.DataGridViewButtonColumn с2;
    }
}