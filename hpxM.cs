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
    public partial class hpxM : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=projectstock;");
        public hpxM()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("PLEASE ENTER YOUR AMOUNT", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MySqlConnection conn = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=projectstock;");
                String sql = "INSERT INTO equipment (name,amount,price) VALUES('HyperX Pulsefire Surge RGB Gaming Mouse','" + comboBox1.Text + "','1690')";
                //UPDATE users SET name ='HyperX Pulsefire Surge RGB Gaming Mouse',amount= '" + comboBox1.Text + "',price='1690' WHERE id = '" + Program.username + "'";
                //"INSERT INTO users (name,amount,price) VALUES('HyperX Pulsefire Surge RGB Gaming Mouse','" + comboBox1.Text + "','1690')";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("Item Already Added To Your Cart Successfully", "Item Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
         Close();
        }
    }
}
