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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            db db = new db();
            MySqlCommand command = new MySqlCommand("INSERT INTO `users`(`firstname`, `lastname`, `username`, `password`) VALUES (@fn, @ln, @usn, @pass)", db.getConnection());

            command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = textBoxFirstname.Text;
            command.Parameters.Add("@ln", MySqlDbType.VarChar).Value = textBoxLastname.Text;
            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = textBoxUsername.Text;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = textBoxPassword.Text;
            

            // open the connection
            db.openConnection();
            if (textBoxUsername.Text == "" || textBoxPassword.Text == "" || textBoxFirstname.Text == "" || textBoxLastname.Text == "" || textBoxPasswordConfirm.Text == "" )
            {
                MessageBox.Show("fields are empty", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            else
            {
                // check if the textboxes contains the default values 
                if (!checkTextBoxesValues())
                {
                    // check if the password equal the confirm password
                    if (textBoxPassword.Text.Equals(textBoxPasswordConfirm.Text))
                    {
                        // check if this username already exists
                        if (checkUsername())
                        {
                            MessageBox.Show("This Username Already Use", "Duplicate Username", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            // execute the query
                            if (command.ExecuteNonQuery() == 1)
                            {
                                MessageBox.Show("Your Account Has Been Created", "Account Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                                Form1 f = new Form1();
                                f.Show();
                            }
                            else
                            {
                                MessageBox.Show("ERROR");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Wrong Confirmation Password", "Password Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("Enter Your Informations First", "Empty Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }



                // close the connection
                db.closeConnection();
                
            }

        }


        // check if the username already exists
        public Boolean checkUsername()
        {
            db db = new db();

            String username = textBoxUsername.Text;

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `username` = @usn", db.getConnection());

            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = username;

            adapter.SelectCommand = command;

            adapter.Fill(table);

            // check if this username already exists in the database
            if (table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public Boolean checkTextBoxesValues()
        {
            String fname = textBoxFirstname.Text;
            String lname = textBoxLastname.Text;
            String uname = textBoxUsername.Text;
            String pass = textBoxPassword.Text;

            if (fname.Equals("first name") || lname.Equals("last name")  || uname.Equals("username")
                || pass.Equals("password"))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
 }

