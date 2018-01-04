namespace BMPL
{
    partial class BM_user
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BM_user));
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.co = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.с1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.с3 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.c4 = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
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
            this.co,
            this.с1,
            this.c2,
            this.с3,
            this.c4});
            this.dgv1.Location = new System.Drawing.Point(14, 44);
            this.dgv1.Name = "dgv1";
            this.dgv1.ReadOnly = true;
            this.dgv1.RowHeadersVisible = false;
            this.dgv1.RowTemplate.Height = 24;
            this.dgv1.Size = new System.Drawing.Size(814, 365);
            this.dgv1.TabIndex = 2;
            this.dgv1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv1_CellContentClick);
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
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // propertiesToolStripMenuItem
            // 
            this.propertiesToolStripMenuItem.Image = global::BMPL.Properties.Resources.gear;
            this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(32, 24);
            this.propertiesToolStripMenuItem.ToolTipText = "Конфигурация";
            // 
            // co
            // 
            this.co.Frozen = true;
            this.co.HeaderText = "";
            this.co.Name = "co";
            this.co.ReadOnly = true;
            this.co.Visible = false;
            // 
            // с1
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.с1.DefaultCellStyle = dataGridViewCellStyle1;
            this.с1.Frozen = true;
            this.с1.HeaderText = "Логин";
            this.с1.Name = "с1";
            this.с1.ReadOnly = true;
            this.с1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.с1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.с1.ToolTipText = "Логин пользователя";
            this.с1.Width = 250;
            // 
            // c2
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.c2.DefaultCellStyle = dataGridViewCellStyle2;
            this.c2.HeaderText = "Имя пользователя";
            this.c2.Name = "c2";
            this.c2.ReadOnly = true;
            this.c2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.c2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.c2.ToolTipText = "Имя пользователя";
            this.c2.Width = 400;
            // 
            // с3
            // 
            this.с3.HeaderText = "";
            this.с3.Name = "с3";
            this.с3.ReadOnly = true;
            this.с3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.с3.ToolTipText = "Статус пользователя";
            this.с3.Width = 25;
            // 
            // c4
            // 
            this.c4.HeaderText = "";
            this.c4.Name = "c4";
            this.c4.ReadOnly = true;
            this.c4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.c4.ToolTipText = "Роль пользователя";
            this.c4.Width = 25;
            // 
            // BM_user
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(847, 453);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.dgv1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BM_user";
            this.Text = "Пользователи системы";
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn co;
        private System.Windows.Forms.DataGridViewTextBoxColumn с1;
        private System.Windows.Forms.DataGridViewTextBoxColumn c2;
        private System.Windows.Forms.DataGridViewButtonColumn с3;
        private System.Windows.Forms.DataGridViewButtonColumn c4;
    }
}