namespace QuanLySinhVien.LopHocPhan
{
    partial class frmLopHocPhan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Ma_lop_hoc_phan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ma_hoc_phan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ten_hoc_phan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ma_giao_vien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.So_sv_toi_da = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Giang_duong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ngay_bat_dau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ngay_ket_thuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hinh_thuc_thi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaLopHocPhan = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnTimKiem);
            this.groupBox1.Controls.Add(this.txtMaLopHocPhan);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(12, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1006, 273);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ma_lop_hoc_phan,
            this.Ma_hoc_phan,
            this.Ten_hoc_phan,
            this.Ma_giao_vien,
            this.So_sv_toi_da,
            this.Giang_duong,
            this.Ngay_bat_dau,
            this.Ngay_ket_thuc,
            this.Hinh_thuc_thi});
            this.dataGridView1.Location = new System.Drawing.Point(7, 93);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(993, 183);
            this.dataGridView1.TabIndex = 0;
            // 
            // Ma_lop_hoc_phan
            // 
            this.Ma_lop_hoc_phan.HeaderText = "Mã lớp học phần";
            this.Ma_lop_hoc_phan.Name = "Ma_lop_hoc_phan";
            // 
            // Ma_hoc_phan
            // 
            this.Ma_hoc_phan.HeaderText = "Mã học phần";
            this.Ma_hoc_phan.Name = "Ma_hoc_phan";
            // 
            // Ten_hoc_phan
            // 
            this.Ten_hoc_phan.HeaderText = "Tên học phần";
            this.Ten_hoc_phan.Name = "Ten_hoc_phan";
            // 
            // Ma_giao_vien
            // 
            this.Ma_giao_vien.HeaderText = "Mã giáo viên";
            this.Ma_giao_vien.Name = "Ma_giao_vien";
            // 
            // So_sv_toi_da
            // 
            this.So_sv_toi_da.HeaderText = "Số sinh viên";
            this.So_sv_toi_da.Name = "So_sv_toi_da";
            // 
            // Giang_duong
            // 
            this.Giang_duong.HeaderText = "Giảng đường";
            this.Giang_duong.Name = "Giang_duong";
            // 
            // Ngay_bat_dau
            // 
            this.Ngay_bat_dau.HeaderText = "Ngày bắt đầu";
            this.Ngay_bat_dau.Name = "Ngay_bat_dau";
            // 
            // Ngay_ket_thuc
            // 
            this.Ngay_ket_thuc.HeaderText = "Ngày kết thúc";
            this.Ngay_ket_thuc.Name = "Ngay_ket_thuc";
            // 
            // Hinh_thuc_thi
            // 
            this.Hinh_thuc_thi.HeaderText = "Hình thức thi";
            this.Hinh_thuc_thi.Name = "Hinh_thuc_thi";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(407, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Lớp học phần";
            // 
            // txtMaLopHocPhan
            // 
            this.txtMaLopHocPhan.Location = new System.Drawing.Point(99, 26);
            this.txtMaLopHocPhan.Name = "txtMaLopHocPhan";
            this.txtMaLopHocPhan.Size = new System.Drawing.Size(160, 20);
            this.txtMaLopHocPhan.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 29);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Mã lớp học phần";
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(903, 26);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(75, 23);
            this.btnTimKiem.TabIndex = 21;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            // 
            // frmLopHocPhan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 328);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmLopHocPhan";
            this.Text = "Lớp học phần";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ma_lop_hoc_phan;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ma_hoc_phan;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ten_hoc_phan;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ma_giao_vien;
        private System.Windows.Forms.DataGridViewTextBoxColumn So_sv_toi_da;
        private System.Windows.Forms.DataGridViewTextBoxColumn Giang_duong;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ngay_bat_dau;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ngay_ket_thuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hinh_thuc_thi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TextBox txtMaLopHocPhan;
        private System.Windows.Forms.Label label10;
    }
}