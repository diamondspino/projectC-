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
    public partial class Address : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=datauser;");

        public string usernametext5;

        public Address()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=datauser;");
            String sql = "UPDATE users SET addressz='" + textBox1.Text + "' ,phone='" + textBox2.Text + "'WHERE username = '" + usernametext5 + "'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            int rows = cmd.ExecuteNonQuery();
            

            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("fields are empty", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Your Item Will Send To You As Soon As Possible And The Delivery Man Will Take The Money From You Thank You For Buying ❤", "Thank You", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }

        private void Address_Load(object sender, EventArgs e)
        {
            
        }
    }
}
