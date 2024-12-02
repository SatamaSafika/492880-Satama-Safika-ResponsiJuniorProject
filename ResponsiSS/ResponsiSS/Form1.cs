using System.Data;
using Npgsql;

namespace ResponsiSS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private NpgsqlConnection conn;
        private string connstring = "Host=localhost;Port=5432;Username=postgres;Password=informatika;Database=fikaresponsi";

        public DataTable dt;
        private NpgsqlCommand cmd;
        private string sql = null;
        private DataGridViewRow r;

        private void ConnectToDatabase()
        {
            try
            {
                // Inisialisasi koneksi dan buka
                conn = new NpgsqlConnection(connstring);
                conn.Open();

                // Cek status koneksi
                if (conn.State == ConnectionState.Open)
                {
                    MessageBox.Show("Connection Established", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show($"PostgreSQL error: {ex.Message}", "Connection Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"General error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LoadDepartments()
        {
            try
            {
                if (conn == null || conn.State != ConnectionState.Open)
                {
                    ConnectToDatabase();
                }

                sql = "SELECT id_dep, nama_dep FROM departemen";
                cmd = new NpgsqlCommand(sql, conn);

                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    DataTable dtDepartments = new DataTable();
                    dtDepartments.Load(reader);

                    cbDepartemen.DataSource = dtDepartments;
                    cbDepartemen.DisplayMember = "nama_dep";
                    cbDepartemen.ValueMember = "id_dep";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Load Departments Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ConnectToDatabase();
            LoadDepartments();

        }


        private void InsertDepartment(string departmentName)
        {
            try
            {
                // Pastikan koneksi sudah dibuka
                if (conn == null || conn.State != ConnectionState.Open)
                {
                    ConnectToDatabase();  // Membuka koneksi jika belum terbuka
                }

                // Membuat query untuk memasukkan data
                string insertQuery = "INSERT INTO departemen (nama_dep) VALUES (@nama_dep)";

                // Inisialisasi objek cmd dengan query dan koneksi
                cmd = new NpgsqlCommand(insertQuery, conn);

                // Menambahkan parameter untuk mencegah SQL injection
                cmd.Parameters.AddWithValue("@nama_dep", departmentName);

                // Eksekusi perintah SQL untuk menyisipkan data
                int rowsAffected = cmd.ExecuteNonQuery();  // Mengembalikan jumlah baris yang terpengaruh

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Department inserted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No rows were affected.", "Insert Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (NpgsqlException ex)
            {
                // Menangani kesalahan spesifik PostgreSQL
                MessageBox.Show($"PostgreSQL error: {ex.Message}", "Insert Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Menangani kesalahan lainnya
                MessageBox.Show($"General error: {ex.Message}", "Insert Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(connstring))
                {
                    conn.Open();

                    sql = @"SELECT * FROM insert_data(:_nama_karyawan, :_id_dep)";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                    {
                        // Pastikan nama dan departemen dipilih
                        if (string.IsNullOrEmpty(txtName.Text) || cbDepartemen.SelectedIndex == -1)
                        {
                            MessageBox.Show("Nama dan departemen tidak boleh kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // Mengisi parameter untuk fungsi insert_data
                        cmd.Parameters.AddWithValue("_nama_karyawan", txtName.Text);
                        cmd.Parameters.AddWithValue("_id_dep", cbDepartemen.SelectedValue); // Mengambil id_dep dari ComboBox

                        // Eksekusi query
                        if ((int)cmd.ExecuteScalar() == 1)
                        {
                            MessageBox.Show("Data berhasil ditambahkan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnLoad.PerformClick(); // Refresh data
                            txtName.Clear();
                            cbDepartemen.SelectedIndex = -1;
                        }
                        else
                        {
                            MessageBox.Show("Data gagal ditambahkan!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Insert FAIL!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(connstring))
                {
                    conn.Open();
                    dgvKaryawan.DataSource = null;

                    // Perbarui query untuk memanggil fungsi select_all
                    sql = "SELECT * FROM select_all()";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                    {
                        dt = new DataTable();
                        using (NpgsqlDataReader rd = cmd.ExecuteReader())
                        {
                            dt.Load(rd);
                            dgvKaryawan.DataSource = dt;

                            // Atur header kolom DataGridView
                            dgvKaryawan.Columns["_id_karyawan"].HeaderText = "ID Karyawan";
                            dgvKaryawan.Columns["_nama_karyawan"].HeaderText = "Nama";
                            dgvKaryawan.Columns["_id_dep"].HeaderText = "ID Departemen";
                            dgvKaryawan.Columns["_nama_dep"].HeaderText = "Nama Departemen";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "FAIL!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (r == null)
            {
                MessageBox.Show("Pilih baris data dahulu!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(connstring))
                {
                    conn.Open();
                    sql = @"SELECT * FROM update_data(:_id_karyawan, :_nama_karyawan, :_id_dep)";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("_id_karyawan", r.Cells["_id_karyawan"].Value.ToString());
                        cmd.Parameters.AddWithValue("_nama_karyawan", txtName.Text);
                        cmd.Parameters.AddWithValue("_id_dep", cbDepartemen.SelectedValue); // Gunakan id_dep dari ComboBox

                        if ((int)cmd.ExecuteScalar() == 1)
                        {
                            MessageBox.Show("Data Karyawan Berhasil Diperbarui", "Well Done!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnLoad.PerformClick();
                            txtName.Text = cbDepartemen.Text = null;
                            r = null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Update FAIL!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (r == null)
            {
                MessageBox.Show("Pilih baris data dahulu!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show($"Apakah Anda ingin menghapus data {r.Cells["_nama_karyawan"].Value}?",
                "Hapus data terkonfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (NpgsqlConnection conn = new NpgsqlConnection(connstring))
                    {
                        conn.Open();
                        sql = @"select * from delete_by_id(:_id_karyawan)";
                        using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("_id_karyawan", r.Cells["_id_karyawan"].Value.ToString());
                            if ((int)cmd.ExecuteScalar() == 1)
                            {
                                MessageBox.Show("Data Karyawan Berhasil Dihapus", "Well Done!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                btnLoad.PerformClick();
                                txtName.Text = cbDepartemen.Text = null;
                                r = null;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Delete FAIL!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (conn != null && conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }

        private void dgvKaryawan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                r = dgvKaryawan.Rows[e.RowIndex];
                txtName.Text = r.Cells["_nama_karyawan"].Value.ToString();
                cbDepartemen.SelectedValue = r.Cells["_id_dep"].Value.ToString();
            }
        }
    }
}