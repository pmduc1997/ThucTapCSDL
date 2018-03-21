using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLySinhVien.SinhVien
{
    public partial class frmSinhVien : Form
    {
        public static SqlConnection con;
        public frmSinhVien()
        {
            InitializeComponent();
        }
        private void connect()
        {
            String cn = @"server ='DUC-PC\SQLEXPRESS' ;database ='Quan_ly_sinh_vien' ;Integrated Security = true";//;Integrated Security = false
            
            con = new SqlConnection(cn);
            con.Open();
            
        }
        public void getdata()
        {
            String sqlSELECT = "SELECT * FROM Sinh_vien";
            SqlCommand com = new SqlCommand(sqlSELECT, con);//thực thi câu lệnh trong SQL
            SqlDataAdapter da = new SqlDataAdapter(com); //vận chuyển dữ liệu
            DataTable dt = new DataTable();//tạo 1 bảng ảo
            da.Fill(dt); //đổ dữ liệu vào bảng ảo
            dataGridView1.DataSource = dt;
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void frmSinhVien_Load(object sender, EventArgs e)
        {
            connect();
            getdata();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmThemSinhVien frmthemsinhvien = new frmThemSinhVien();
            frmthemsinhvien.ShowDialog();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sua = "UPDATE Sinh_vien set Ten_sinh_vien = N'" + txtHoTen.Text + "',Ngay_sinh = N'" + txtNgaySinh.Text + "',Gioi_tinh = N'" + cbbGioiTinh.Text + "',Dia_chi = '" + txtDiaChi.Text + "',Ma_lop='" + txtMaLop.Text + "' where Ma_sinh_vien = '" + txtMaSinhVien.Text + "' ";
            SqlCommand comSua = new SqlCommand(sua, con);
            comSua.ExecuteNonQuery();
            getdata();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa k?", "Some Title", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string xoa = "DELETE from Sinh_vien where Ma_sinh_vien = '" + txtMaSinhVien.Text + "'";
                SqlCommand comXoa = new SqlCommand(xoa, con);
                comXoa.ExecuteNonQuery();
                getdata();
            }
            else if (dialogResult == DialogResult.No)
            {
                getdata();
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentRow.Index;
            txtMaSinhVien.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
            txtHoTen.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
            txtNgaySinh.Text = dataGridView1.Rows[index].Cells[2].Value.ToString();
            cbbGioiTinh.Text = dataGridView1.Rows[index].Cells[3].Value.ToString();
            txtDiaChi.Text = dataGridView1.Rows[index].Cells[4].Value.ToString();
            txtMaLop.Text = dataGridView1.Rows[index].Cells[5].Value.ToString();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            String sqlSELECT = "select * from Sinh_vien where Ma_sinh_vien like N'%" + txtTKMaSinhVien.Text + "%' and Ten_sinh_vien like N'%" + txtTKHoTen.Text + "%' and Ngay_sinh like N'%" + txtTKNgaySinh.Text + "%' and Gioi_tinh like N'%" + cbbTKGioiTinh.Text + "%' and Dia_chi like N'%" + txtTKDiaChi.Text + "%' and Ma_lop like N'%" + txtTKMaLop.Text + "%' ";
            SqlCommand com = new SqlCommand(sqlSELECT, con);//thực thi câu lệnh trong SQL
            SqlDataAdapter da = new SqlDataAdapter(com); //vận chuyển dữ liệu
            DataTable dt = new DataTable();//tạo 1 bảng ảo
            da.Fill(dt); //đổ dữ liệu vào bảng ảo
            dataGridView1.DataSource = dt; // đổ dữ liệu vào dG
        }
    }
}
