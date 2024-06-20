using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace sawatracket.Resources
{
    public partial class MOBIL : Form
    {
        MySqlConnection conn;

        public MOBIL(MySqlConnection connection)
        {
            InitializeComponent();
            conn = connection;
            this.Load += new System.EventHandler(this.MOBIL_Load);
            dataGridView1.CellClick += new DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            button1.Click += new EventHandler(this.ButtonCreate_Click);
            button2.Click += new EventHandler(this.ButtonUpdate_Click);
            button3.Click += new EventHandler(this.ButtonDelete_Click);
            button4.Click += new EventHandler(this.ButtonSave_Click);
        }

        private void MOBIL_Load(object? sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                string query = "SELECT id AS 'ID Mobil', jenis_mobil AS 'Jenis Mobil', supir AS 'Supir', jumlah_kursi AS 'Jumlah Kursi', rute AS 'Rute', status AS 'Status' FROM mobil";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridView1.DataSource = dt;
                dataGridView1.AlternatingRowsDefaultCellStyle = dataGridView1.DefaultCellStyle;

                dataGridView1.Columns["ID Mobil"].Visible = false;
                dataGridView1.Columns["Jenis Mobil"].Width = 250;
                dataGridView1.Columns["Supir"].Width = 150;
                dataGridView1.Columns["Jumlah Kursi"].Width = 250;
                dataGridView1.Columns["Rute"].Width = 200;
                dataGridView1.Columns["Status"].Width = 200;

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

                textBox1.Text = row.Cells["Jenis Mobil"].Value.ToString();
                textBox2.Text = row.Cells["Supir"].Value.ToString();
                textBox3.Text = row.Cells["Jumlah Kursi"].Value.ToString();
                textBox4.Text = row.Cells["Rute"].Value.ToString();
                textBox5.Text = row.Cells["Status"].Value.ToString();
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

                string query = "UPDATE mobil SET jenis_mobil = @Jenis, supir = @Supir, jumlah_kursi = @JumlahKursi, rute = @Rute, status = @Status WHERE id = @ID";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    int selectedRowIndex = dataGridView1.CurrentCell.RowIndex;
                    DataGridViewRow selectedRow = dataGridView1.Rows[selectedRowIndex];
                    int idMobil = Convert.ToInt32(selectedRow.Cells["ID Mobil"].Value);

                    cmd.Parameters.AddWithValue("@ID", idMobil);
                    cmd.Parameters.AddWithValue("@Jenis", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Supir", textBox2.Text);
                    cmd.Parameters.AddWithValue("@JumlahKursi", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Rute", textBox4.Text);
                    cmd.Parameters.AddWithValue("@Status", textBox5.Text);
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
                string query = "DELETE FROM mobil WHERE id = @ID";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    int selectedRowIndex = dataGridView1.CurrentCell.RowIndex;
                    DataGridViewRow selectedRow = dataGridView1.Rows[selectedRowIndex];
                    int idMobil = Convert.ToInt32(selectedRow.Cells["ID Mobil"].Value);

                    cmd.Parameters.AddWithValue("@ID", idMobil);
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
                string query = "INSERT INTO mobil (jenis_mobil, supir, jumlah_kursi, rute, status) VALUES (@Jenis, @Supir, @JumlahKursi, @Rute, @Status)";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Jenis", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Supir", textBox2.Text);
                    cmd.Parameters.AddWithValue("@JumlahKursi", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Rute", textBox4.Text);
                    cmd.Parameters.AddWithValue("@Status", textBox5.Text);
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
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void label5_Click(object sender, EventArgs e) { }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) { }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void textBox1_TextChanged(object sender, EventArgs e) { }

        private void textBox2_TextChanged(object sender, EventArgs e) { }

        private void textBox3_TextChanged(object sender, EventArgs e) { }

        private void textBox4_TextChanged(object sender, EventArgs e) { }

        private void textBox5_TextChanged(object sender, EventArgs e) { }

        private void button1_Click(object sender, EventArgs e) { }

        private void button2_Click(object sender, EventArgs e) { }

        private void button3_Click(object sender, EventArgs e) { }

        private void button4_Click(object sender, EventArgs e) { }
    }
}
