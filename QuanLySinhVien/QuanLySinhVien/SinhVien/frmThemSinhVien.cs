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
    public partial class frmThemSinhVien : Form
    {
        public static SqlConnection con;
        public frmThemSinhVien()
        {
            InitializeComponent();
        }
        private void connect()
        {
            String cn = @"server ='DUC-PC\SQLEXPRESS' ;database ='Quan_ly_sinh_vien' ;Integrated Security = true";
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

            cbbGioiTinh.Items.Add("Nam");
            cbbGioiTinh.Items.Add("Nữ");
        }
        public bool kiemtratontai_masinhvien()
        {
            bool KT = false;
            SqlDataAdapter da_kiemtra = new SqlDataAdapter("Select * from Sinh_vien where Ma_sinh_vien='" + txtMaSinhVien.Text + "'", con);//vận chuyển dữ liệu
            DataTable dt_kiemtra = new DataTable();//tạo 1 bảng ảo
            da_kiemtra.Fill(dt_kiemtra);//đổ dữ liệu vào bảng ảo

            if (dt_kiemtra.Rows.Count > 0)
            {
                KT = true;
            }
            da_kiemtra.Dispose();
            return KT;
        }
        private void frmThemSinhVien_Load(object sender, EventArgs e)
        {
            connect();
            getdata();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            //frmSinhVien frmsinhvien = new frmSinhVien();
            //frmsinhvien.ShowDialog();
            this.Close();
            Dispose();
        }

        private void cbbGioiTinh_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (kiemtratontai_masinhvien())
            {
                MessageBox.Show("Mã sinh viên đã tồn tại. Vui lòng nhập lại !");
            }
            else
            if (txtMaSinhVien.Text == "")
            {
                MessageBox.Show("Bạn phải nhập mã sinh viên");
            }

            else
            {
                string them = "insert into Sinh_vien values ('" + txtMaSinhVien.Text + "',N'" + txtHoTen.Text + "',N'" + txtNgaySinh.Text + "',N'" + cbbGioiTinh.Text + "',N'" + txtDiaChi.Text + "',N'" + txtMaLop.Text + "')";
                SqlCommand comThem = new SqlCommand(them, con);
                comThem.ExecuteNonQuery();
                getdata();
                MessageBox.Show("Thêm mới thành công ");
                this.Close();
                frmSinhVien frmsinhvien = new frmSinhVien();
                frmsinhvien.ShowDialog();
            }
        }
    }
}
