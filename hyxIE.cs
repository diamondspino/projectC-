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
    public partial class hyxIE : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=projectstock;");
        public hyxIE()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (comboBox3.Text == "")
            {
                MessageBox.Show("PLEASE ENTER YOUR AMOUNT", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MySqlConnection conn = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=projectstock;");
                String sql = "INSERT INTO equipment (name,amount,price) VALUES('HyperX Cloud Earbud','" + comboBox3.Text + "','1490')";
                //"UPDATE users SET name ='HyperX Cloud Earbud',amount= '" + comboBox3.Text + "',price='1490' WHERE id = '" + Program.username + "'";
                //"INSERT INTO users (name,amount,price) VALUES('HyperX Cloud Earbud','" + comboBox3.Text + "','1490')";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("Item Already Added To Your Cart Successfully", "Item Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
