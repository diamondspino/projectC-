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

    public partial class AW : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=projectstock;");
        public AW()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
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
                String sql = "INSERT INTO equipment (name,amount,price) VALUES('NOTEBOOK ALIENWARE M15 R3 WW56911001THW10','" + comboBox1.Text + "','29900')";
                //"UPDATE users SET name ='NOTEBOOK ALIENWARE M15 R3 WW56911001THW10',amount= '" + comboBox1.Text + "',price='84900' WHERE id = '" + Program.username + "'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("Item Already Added To Your Cart Successfully", "Item Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
