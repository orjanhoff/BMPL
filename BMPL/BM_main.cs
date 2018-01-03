﻿using System;
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
    public partial class BM_main : Form
    {
        BMUiCache.Cache cache;

        public BM_main()
        {
            InitializeComponent();

            //this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;

            BM_service bm_service = new BM_service();
            bm_service.MdiParent = this;
            bm_service.Show();

            cache = new BMUiCache.Cache(new BMDaGear());
            cache.BuildCache();

            MessageBox.Show(cache.Count.ToString());
            //MessageBox.Show(cache["service"].Rows[1][1].ToString());
        }

        private void словариToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BM_dictionary b_dictionary = new BM_dictionary(cache["sys_table"]);
            b_dictionary.ShowDialog();
        }
    }
}
