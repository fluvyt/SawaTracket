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

namespace sawatracket.Resources
{
    public partial class PESANAN : Form
    {
        MySqlConnection conn;

        public PESANAN(MySqlConnection connection)
        {
            InitializeComponent();
            string connectionString = "server=localhost;database=TravelDB;uid=root;pwd=;";
            conn = new MySqlConnection(connectionString);

            this.Load += new EventHandler(PESANAN_Load);
            dataGridView1.CellClick += new DataGridViewCellEventHandler(dataGridView1_CellClick);
            button5.Click += new EventHandler(ButtonCreate_Click);
            button2.Click += new EventHandler(ButtonUpdate_Click);
            button3.Click += new EventHandler(ButtonDelete_Click);
            button4.Click += new EventHandler(ButtonSave_Click);
            LoadData();
        }
        private void PESANAN_Load(object? sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                string query = "SELECT id AS 'ID Pesanan', nama AS 'Nama', penjemputan AS 'Penjemputan', tujuan AS 'Tujuan', harga AS 'Harga', status AS 'Status', mobil AS 'Mobil', telepon AS 'Telepon' FROM pesanan";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridView1.DataSource = dt;
                // Pengaturan tampilan kolom dan lebar kolom
                dataGridView1.Columns["ID Pesanan"].Visible = false;
                dataGridView1.Columns["Nama"].Width = 150;
                dataGridView1.Columns["Penjemputan"].Width = 150;
                dataGridView1.Columns["Tujuan"].Width = 150;
                dataGridView1.Columns["Harga"].Width = 100;
                dataGridView1.Columns["Status"].Width = 100;
                dataGridView1.Columns["Mobil"].Width = 100;
                dataGridView1.Columns["Telepon"].Width = 100;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dataGridView1_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                textBox2.Text = row.Cells["Nama"].Value.ToString();
                textBox3.Text = row.Cells["Penjemputan"].Value.ToString();
                textBox4.Text = row.Cells["Tujuan"].Value.ToString();
                textBox5.Text = row.Cells["Harga"].Value.ToString();
                textBox6.Text = row.Cells["Status"].Value.ToString();
                textBox7.Text = row.Cells["Mobil"].Value.ToString();
                textBox8.Text = row.Cells["Telepon"].Value.ToString();
            }
        }

        private void ButtonCreate_Click(object? sender, EventArgs e)
        {
            ClearTextBoxes();
        }

        private void ButtonUpdate_Click(object? sender, EventArgs e)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                string query = "UPDATE pesanan SET nama = @Nama, penjemputan = @Penjemputan, tujuan = @Tujuan, harga = @Harga, status = @Status, mobil = @Mobil, telepon = @Telepon WHERE id = @ID";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    int selectedRowIndex = dataGridView1.CurrentCell.RowIndex;
                    DataGridViewRow selectedRow = dataGridView1.Rows[selectedRowIndex];
                    int idPesanan = Convert.ToInt32(selectedRow.Cells["ID Pesanan"].Value);

                    cmd.Parameters.AddWithValue("@ID", idPesanan);
                    cmd.Parameters.AddWithValue("@Nama", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Penjemputan", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Tujuan", textBox4.Text);
                    cmd.Parameters.AddWithValue("@Harga", textBox5.Text);
                    cmd.Parameters.AddWithValue("@Status", textBox6.Text);
                    cmd.Parameters.AddWithValue("@Mobil", textBox7.Text);
                    cmd.Parameters.AddWithValue("@Telepon", textBox8.Text);
                    cmd.ExecuteNonQuery();
                }
                LoadData();
                MessageBox.Show("Data updated successfully.");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        private void ButtonDelete_Click(object? sender, EventArgs e)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                string query = "DELETE FROM pesanan WHERE id = @ID";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    int selectedRowIndex = dataGridView1.CurrentCell.RowIndex;
                    DataGridViewRow selectedRow = dataGridView1.Rows[selectedRowIndex];
                    int idPesanan = Convert.ToInt32(selectedRow.Cells["ID Pesanan"].Value);

                    cmd.Parameters.AddWithValue("@ID", idPesanan);
                    cmd.ExecuteNonQuery();
                }
                LoadData();
                MessageBox.Show("Data deleted successfully.");
                ClearTextBoxes();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void ButtonSave_Click(object? sender, EventArgs e)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                string query = "INSERT INTO pesanan (nama, penjemputan, tujuan, harga, status, mobil, telepon) VALUES (@Nama, @Penjemputan, @Tujuan, @Harga, @Status, @Mobil, @Telepon)";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Nama", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Penjemputan", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Tujuan", textBox4.Text);
                    cmd.Parameters.AddWithValue("@Harga", textBox5.Text);
                    cmd.Parameters.AddWithValue("@Status", textBox6.Text);
                    cmd.Parameters.AddWithValue("@Mobil", textBox7.Text);
                    cmd.Parameters.AddWithValue("@Telepon", textBox8.Text);
                    cmd.ExecuteNonQuery();
                }
                LoadData();
                MessageBox.Show("Data saved successfully.");
                ClearTextBoxes();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void ClearTextBoxes()
        {
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
        }

        private void toolStripContainer1_TopToolStripPanel_Click(object sender, EventArgs e) { }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) { }

        private void textBox1_TextChanged(object sender, EventArgs e) { }

        private void label2_Click(object sender, EventArgs e) { }

        private void label7_Click(object sender, EventArgs e) { }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e) { }

        private void button4_Click(object sender, EventArgs e) { }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void button5_Click(object sender, EventArgs e) { }

        private void textBox1_TextChanged_1(object sender, EventArgs e) { }

        private void textBox2_TextChanged(object sender, EventArgs e) { }

        private void textBox3_TextChanged(object sender, EventArgs e) { }

        private void textBox4_TextChanged(object sender, EventArgs e) { }

        private void textBox5_TextChanged(object sender, EventArgs e) { }

        private void textBox6_TextChanged(object sender, EventArgs e) { }

        private void textBox7_TextChanged(object sender, EventArgs e) { }

        private void textBox8_TextChanged(object sender, EventArgs e) { }

        private void button2_Click(object sender, EventArgs e) { }

        private void button3_Click(object sender, EventArgs e) { }

        private void button4_Click_1(object sender, EventArgs e) { }

        private void PESANAN_Load_1(object sender, EventArgs e)
        {

        }
    }
}
