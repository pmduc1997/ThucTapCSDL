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
    public partial class frmLogin : Form
    {
        public static SqlConnection con; // Đối tượng cho việc kết nối với SQL
        public static string ID_USER = "";
        public frmLogin()
        {
            InitializeComponent();
        }
        private void connect()
        {
            String cn = @"server ='DUC-PC\SQLEXPRESS' ;database ='phanquyen' ;Integrated Security = true";//;Integrated Security = false
            con = new SqlConnection(cn);
            con.Open();
        }

        private string getID(string username, string pass)
        {
            string id = "";
            try
            {
                connect();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tbl_user WHERE username ='" + username + "' and pass ='" + pass + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        id = dr["id_user"].ToString();
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
        private void frmLogin_Load(object sender, EventArgs e)
        {
            connect();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            ID_USER = getID(txtUsername.Text, txtPassword.Text);
            if (ID_USER != "")
            {
                frmMain fmain = new frmMain();
                fmain.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Tài khoản và mật khẩu không đúng !");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            Dispose();
        }

        
    }
}
