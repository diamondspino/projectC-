﻿using System;
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
    public partial class logicGPRO : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=projectstock;");
        public logicGPRO()
        {
            InitializeComponent();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (comboBox4.Text == "")
            {
                MessageBox.Show("PLEASE ENTER YOUR AMOUNT", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MySqlConnection conn = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=projectstock;");
                String sql = "INSERT INTO equipment (name,amount,price) VALUES('Logitech G Pro Wireless Gaming Mouse','" + comboBox4.Text + "','3790')";
                //"UPDATE users SET name ='Logitech G Pro Wireless Gaming Mouse',amount= '" + comboBox4.Text + "',price='3790' WHERE id = '" + Program.username + "'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("Item Already Added To Your Cart Successfully", "Item Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
