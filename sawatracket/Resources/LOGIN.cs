using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace sawatracket.Resources
{
    public partial class LOGIN : Form
    {
        private MySqlConnection conn;
        public LOGIN()
        {

            InitializeComponent();
            string connectionString = "server=localhost;database=TravelDB;uid=root;pwd=;";
            conn = new MySqlConnection(connectionString);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            if (!AuthenticateUser(username, password))
            {
                MessageBox.Show("Username atau password salah.");
            }
            else
            {
                MessageBox.Show("Login berhasil");
                this.DialogResult = DialogResult.OK; // Mengatur DialogResult menjadi OK
                this.Close();
            }
        }

        private bool AuthenticateUser(string username, string password)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM Users WHERE username = @username AND password = @password";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                conn.Open();

                int result = Convert.ToInt32(cmd.ExecuteScalar());
                return result > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
