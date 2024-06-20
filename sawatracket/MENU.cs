using sawatracket.Resources;
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

namespace sawatracket
{
    public partial class MENU : Form
    {
        MySqlConnection conn;
        private bool isLoggedIn = false;
        private LOGIN? loginForm; // Nullable loginForm

        public MENU()
        {
            InitializeComponent();
            string connectionString = "server=localhost;database=TravelDB;uid=root;pwd=;";
            conn = new MySqlConnection(connectionString);

            try
            {
                conn.Open();
                MessageBox.Show("Koneksi ke database berhasil");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Koneksi gagal: " + ex.Message);
            }

            UpdateMenuItems();
        }

        private void UpdateMenuItems()
        {
            mobilToolStripMenuItem.Enabled = isLoggedIn;
            pesananToolStripMenuItem.Enabled = isLoggedIn;
        }

        private void mobilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isLoggedIn)
            {
                MOBIL mobilForm = new MOBIL(conn);
                mobilForm.Show();
            }
            else
            {
                MessageBox.Show("Silakan login terlebih dahulu");
            }
        }

        private void pesananToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isLoggedIn)
            {
                PESANAN pesananForm = new PESANAN(conn);
                pesananForm.Show();
            }
            else
            {
                MessageBox.Show("Silakan login terlebih dahulu");
            }
        }

        private void logInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (loginForm == null || loginForm.IsDisposed)
            {
                loginForm = new LOGIN(); // Inisialisasi loginForm di dalam method logInToolStripMenuItem_Click
                loginForm.FormClosed += LoginForm_FormClosed; // Subscribe ke event FormClosed
                loginForm.ShowDialog();
            }
        }

        private void LoginForm_FormClosed(object? sender, FormClosedEventArgs e)
        {
            if (sender is LOGIN)
            {
                isLoggedIn = ((LOGIN)sender).DialogResult == DialogResult.OK;
                UpdateMenuItems();
            }
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isLoggedIn = false;
            UpdateMenuItems();
            MessageBox.Show("Anda telah logout");
        }

        private void MENU_Load(object sender, EventArgs e)
        {

        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
