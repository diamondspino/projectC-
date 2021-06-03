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
    public partial class Menu : Form
    {
        private MySqlConnection databaseConnection()
        {
            string connectionSting = "datasource=127.0.0.1;port=3306;username=root;password=;database=datauser;";
            MySqlConnection conn = new MySqlConnection(connectionSting);
            return conn;
        }

        public string usernametext;

        public Menu()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Close();
            Form1 f = new Form1();
            f.ShowDialog();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            hpxM f = new hpxM();
            f.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form4 f = new Form4();
            f.usernametext4 = usernametext;
            f.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label4.Text = Program.username;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            hpxHS f = new hpxHS();
            f.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            groupBoxGG.BringToFront();
        }

        
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            logicGPRO f = new logicGPRO();
            f.ShowDialog();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            hyxIE f = new hyxIE();
            f.ShowDialog();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            logicIE f = new logicIE();
            f.ShowDialog();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            logicG431 f = new logicG431();
            f.ShowDialog();
        }

       
        private void pictureBox10_Click(object sender, EventArgs e)
        {
            razM f = new razM();
            f.ShowDialog();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            razHS f = new razHS();
            f.ShowDialog();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            razIE f = new razIE();
            f.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBoxGG.BringToFront();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            groupBox1.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox3.BringToFront();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            NT5 f = new NT5();
            f.ShowDialog();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            PREDA f = new PREDA();
            f.ShowDialog();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            MSI f = new MSI();
            f.ShowDialog();
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            AW f = new AW();
            f.ShowDialog();
        }
    }
}