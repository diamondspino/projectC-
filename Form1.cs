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
    
    public partial class Form1 : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=datauser;");

        public Form1()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {

            db db = new db();

            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `username` = @usn", db.getConnection());

            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = username;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = password;

            adapter.SelectCommand = command;

            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                Program.username = textBoxUsername.Text;
                MessageBox.Show("Login Success","Login",MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                Menu f = new Menu();
                f.usernametext = textBoxUsername.Text;
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("YOUR USERNAME OR PASSWORD ARE INCORRECT", "Login",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
           // MessageBox.Show("Are you sure?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
           
            
                Application.Exit();
            
        }

        private void regBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f = new Form3();
            f.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void textBoxUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
