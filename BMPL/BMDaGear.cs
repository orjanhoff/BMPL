using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMPL
{
    class BMDaGear
    {
        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;
        private SQLiteDataAdapter data_adp;
        private DataSet data_set;
        private DataTable data_tbl;

        private string db_path;
        private string db_url;

        public BMDaGear (string db_path)
        {
            this.db_path = db_path;
            this.db_url= string.Format("Data Source={0};Version=3;New=False;Compress=True;", db_path);
        }

        public BMDaGear()
        {
            this.db_url = string.Format("Data Source={0};Version=3;New=False;Compress=True;", BMInitGear.Bm_path_db);
        }

        private void SetConnection()
        {
            sql_con = new SQLiteConnection(db_url);
            sql_con.Open();
        }

        private void CloseConnection()
        {
            if (sql_con.State!=ConnectionState.Closed)
            sql_con.Close();
        }

        public string IsConnected ()
        {
            return sql_con.State.ToString();
        }

        public void ExecuteQuery(string txtQuery)
        {
            SetConnection();
            sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = txtQuery;
            sql_cmd.ExecuteNonQuery();
            CloseConnection();
        }

        public DataTable SelectData(string tbl_name, string where=null)
        {
            string query_txt = "select * from " + tbl_name;

            SetConnection();
            sql_cmd = sql_con.CreateCommand();

            switch(string.IsNullOrEmpty(where))
            {
                case false: query_txt = "select * from " + tbl_name + " where " + where; break;
            }

            data_adp = new SQLiteDataAdapter(query_txt, sql_con);

            data_set = new DataSet();
            data_adp.Fill(data_set);

            data_tbl = new DataTable();
            data_tbl = data_set.Tables[0];

            CloseConnection();
            return data_tbl;
        }
    }
}
