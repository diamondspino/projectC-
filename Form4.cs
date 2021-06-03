using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace JIB.spino
{
    public partial class Form4 : Form
    {
        public string usernametext4;

        MySqlConnection connection = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=projectstock;");
        public Form4()
        {
            InitializeComponent();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=projectstock;");

            conn.Open();

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM equipment");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void ShowHistory()
        {
            MySqlConnection conn = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=projectstock;");
            DataSet ds = new DataSet();

            conn.Open();

            MySqlCommand cmd = new MySqlCommand("SELECT name,amount,price FROM equipment",conn);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);
            // adapter.Fill(ds);

            conn.Close();

            dataHistory.DataSource = ds.Tables[0].DefaultView;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            ShowHistory();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Address f = new Address();
            f.usernametext5 = usernametext4;
            f.ShowDialog();
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dataHistory.CurrentRow.Selected = true;
                int selecterow = dataHistory.CurrentCell.RowIndex;
                var deleteId = dataHistory.Rows[selecterow].Cells["name"].Value;

                MySqlConnection conn = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=projectstock;");

                string sql = "DELETE FROM equipment WHERE name = '" + deleteId + "'";

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                conn.Open();

                int rows = cmd.ExecuteNonQuery();

                conn.Close();

                if (rows > 0)
                {
                    MessageBox.Show("Deleted Your Order", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MySqlConnection conn2 = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=projectstock;");
                    DataSet ds = new DataSet();

                    conn2.Open();

                    MySqlCommand cmd2 = new MySqlCommand("SELECT name,amount,price FROM equipment", conn2);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd2);
                    adapter.Fill(ds);
                    // adapter.Fill(ds);

                    conn2.Close();

                    dataHistory.DataSource = ds.Tables[0].DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataHistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}


