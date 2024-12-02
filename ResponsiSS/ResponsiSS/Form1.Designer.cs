namespace ResponsiSS
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            label1 = new Label();
            label2 = new Label();
            txtName = new TextBox();
            cbDepartemen = new ComboBox();
            idDepartemen = new ListBox();
            pictureBox1 = new PictureBox();
            dgvKaryawan = new DataGridView();
            btnInsert = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnLoad = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvKaryawan).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(53, 117);
            label1.Name = "label1";
            label1.Size = new Size(111, 17);
            label1.TabIndex = 0;
            label1.Text = "Nama Karyawan:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(53, 189);
            label2.Name = "label2";
            label2.Size = new Size(106, 17);
            label2.TabIndex = 1;
            label2.Text = "Dep. Karyawan: ";
            label2.Click += label2_Click;
            // 
            // txtName
            // 
            txtName.Location = new Point(186, 116);
            txtName.Name = "txtName";
            txtName.Size = new Size(200, 23);
            txtName.TabIndex = 2;
            // 
            // cbDepartemen
            // 
            cbDepartemen.FormattingEnabled = true;
            cbDepartemen.Location = new Point(186, 188);
            cbDepartemen.Name = "cbDepartemen";
            cbDepartemen.Size = new Size(200, 23);
            cbDepartemen.TabIndex = 3;
            // 
            // idDepartemen
            // 
            idDepartemen.FormattingEnabled = true;
            idDepartemen.ItemHeight = 15;
            idDepartemen.Items.AddRange(new object[] { "                           ID Departemen", "HR: HR", "ENG: Engineer", "DEV: Developer", "PM: Product Manager", "FIN: Finance" });
            idDepartemen.Location = new Point(500, 117);
            idDepartemen.Name = "idDepartemen";
            idDepartemen.Size = new Size(273, 94);
            idDepartemen.TabIndex = 4;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(347, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(131, 73);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // dgvKaryawan
            // 
            dgvKaryawan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKaryawan.Location = new Point(53, 306);
            dgvKaryawan.Name = "dgvKaryawan";
            dgvKaryawan.RowTemplate.Height = 25;
            dgvKaryawan.Size = new Size(720, 150);
            dgvKaryawan.TabIndex = 6;
            dgvKaryawan.CellClick += dgvKaryawan_CellClick;
            // 
            // btnInsert
            // 
            btnInsert.BackColor = Color.OliveDrab;
            btnInsert.Location = new Point(53, 262);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(135, 23);
            btnInsert.TabIndex = 7;
            btnInsert.Text = "Insert";
            btnInsert.UseVisualStyleBackColor = false;
            btnInsert.Click += btnInsert_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.SteelBlue;
            btnUpdate.Location = new Point(347, 262);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(135, 23);
            btnUpdate.TabIndex = 8;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.IndianRed;
            btnDelete.Location = new Point(638, 262);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(135, 23);
            btnDelete.TabIndex = 9;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnLoad
            // 
            btnLoad.BackColor = Color.Goldenrod;
            btnLoad.Location = new Point(673, 482);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(135, 23);
            btnLoad.TabIndex = 10;
            btnLoad.Text = "Load";
            btnLoad.UseVisualStyleBackColor = false;
            btnLoad.Click += btnLoad_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(820, 517);
            Controls.Add(btnLoad);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnInsert);
            Controls.Add(dgvKaryawan);
            Controls.Add(pictureBox1);
            Controls.Add(idDepartemen);
            Controls.Add(cbDepartemen);
            Controls.Add(txtName);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvKaryawan).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtName;
        private ComboBox cbDepartemen;
        private ListBox idDepartemen;
        private PictureBox pictureBox1;
        private DataGridView dgvKaryawan;
        private Button btnInsert;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnLoad;
    }
}