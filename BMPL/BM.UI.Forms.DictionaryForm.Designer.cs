namespace BMApp
{
    partial class DictionaryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DictionaryForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.с0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.с2 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cms1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmi1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi2 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.cms1.SuspendLayout();
            this.SuspendLayout();
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
            this.menuStrip1.Size = new System.Drawing.Size(847, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // propertiesToolStripMenuItem
            // 
            this.propertiesToolStripMenuItem.Image = global::BMApp.Properties.Resources.gear;
            this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(32, 24);
            this.propertiesToolStripMenuItem.ToolTipText = "Дополнительно";
            // 
            // dgv1
            // 
            this.dgv1.AllowUserToAddRows = false;
            this.dgv1.AllowUserToDeleteRows = false;
            this.dgv1.AllowUserToResizeColumns = false;
            this.dgv1.AllowUserToResizeRows = false;
            this.dgv1.BackgroundColor = System.Drawing.Color.LightSteelBlue;
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.с0,
            this.c1,
            this.с2});
            this.dgv1.Location = new System.Drawing.Point(14, 44);
            this.dgv1.Name = "dgv1";
            this.dgv1.ReadOnly = true;
            this.dgv1.RowHeadersVisible = false;
            this.dgv1.RowTemplate.Height = 24;
            this.dgv1.Size = new System.Drawing.Size(814, 365);
            this.dgv1.TabIndex = 1;
            this.dgv1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // с0
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.с0.DefaultCellStyle = dataGridViewCellStyle1;
            this.с0.Frozen = true;
            this.с0.HeaderText = "Наименование";
            this.с0.Name = "с0";
            this.с0.ReadOnly = true;
            this.с0.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.с0.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.с0.ToolTipText = "Наименование справочников";
            this.с0.Width = 250;
            // 
            // c1
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.c1.DefaultCellStyle = dataGridViewCellStyle2;
            this.c1.HeaderText = "Описание";
            this.c1.Name = "c1";
            this.c1.ReadOnly = true;
            this.c1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.c1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.c1.ToolTipText = "Описание справочников";
            this.c1.Width = 400;
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
            // cms1
            // 
            this.cms1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.cms1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cms1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi1,
            this.tsmi2});
            this.cms1.Name = "cms1";
            this.cms1.Size = new System.Drawing.Size(182, 84);
            // 
            // tsmi1
            // 
            this.tsmi1.Image = global::BMApp.Properties.Resources.minus;
            this.tsmi1.Name = "tsmi1";
            this.tsmi1.Size = new System.Drawing.Size(181, 26);
            this.tsmi1.Text = "Удалить";
            // 
            // tsmi2
            // 
            this.tsmi2.Image = global::BMApp.Properties.Resources.plus;
            this.tsmi2.Name = "tsmi2";
            this.tsmi2.Size = new System.Drawing.Size(181, 26);
            this.tsmi2.Text = "Добавить";
            // 
            // BM_dictionary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(847, 453);
            this.Controls.Add(this.dgv1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "BM_dictionary";
            this.Text = "Настройка справочников";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.cms1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.DataGridViewTextBoxColumn с0;
        private System.Windows.Forms.DataGridViewTextBoxColumn c1;
        private System.Windows.Forms.DataGridViewButtonColumn с2;
        private System.Windows.Forms.ContextMenuStrip cms1;
        private System.Windows.Forms.ToolStripMenuItem tsmi1;
        private System.Windows.Forms.ToolStripMenuItem tsmi2;
    }
}