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

namespace QuanLySinhVien
{
    public partial class frmMain : Form
    {
        public static SqlConnection con; // Đối tượng cho việc kết nối với SQL
        public frmMain()
        {
            InitializeComponent();
        }
        private void connect()
        {
            String cn = @"server ='DUC-PC\SQLEXPRESS' ;database ='phanquyen' ;Integrated Security = true";//;Integrated Security = false
            con = new SqlConnection(cn);
            con.Open();
        }
        private string id_per(string id_user)
        {
            string id = "";
            try
            {
                connect();
                SqlCommand cmd = new SqlCommand("SELECT * FROM relationship WHERE id_user ='" + id_user + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        id = dr["id_per"].ToString();
                    }
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi xảy ra khi truy vấn dữ liệu hoặc kết nối với server thất bại !");
            }
            finally
            {
                con.Close();
            }
            return id;
        }
        private List<string> list_per(string id_per)
        {
            List<string> termsList = new List<string>();
            try
            {
                connect();
                SqlCommand cmd = new SqlCommand("SELECT * FROM per_detail WHERE id_per ='" + id_per + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        termsList.Add(dr["code_action"].ToString());
                    }
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi xảy ra khi truy vấn dữ liệu hoặc kết nối với server thất bại !");
            }
            finally
            {
                con.Close();
            }
            return termsList;
        }
        List<string> list_detail;
        private void frmMain_Load(object sender, EventArgs e)
        {
            list_detail = list_per(id_per(frmLogin.ID_USER));
        }
        private Boolean checkper(string code)
        {
            Boolean check = false;
            foreach (string item in list_detail)
            {
                if (item == code)
                {
                    check = true;
                }
            }
            return check;
        }
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Dispose();
            frmLogin frmlogin = new frmLogin();
            frmlogin.ShowDialog();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Dispose();
        }
        private void giáoViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checkper("ADMIN") == true)
            {
                MessageBox.Show("có quyền");
            }
            else
            {
                MessageBox.Show("Bạn không có quyền");
            }
        }

        private void sinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SinhVien.frmSinhVien frmsinhvien = new SinhVien.frmSinhVien();
            frmsinhvien.ShowDialog();
        }
    }
}
