using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeThongThuongMaiDT
{
    public partial class frmLogIn1 : Form
    {
        string tendangnhap = "admin";
        string matkhau = "admin";
        public frmLogIn1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CheckLogin(txtTenDangNhap.Text,txtMatKhau.Text))
            {
                frmMain frm = new frmMain(); //Khởi tạo đối tượng
                
                this.Hide();
                frm.Show();
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                txtTenDangNhap.Focus();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        bool CheckLogin(string tendangnhap, string matkhau)
        {
            if(tendangnhap == this.tendangnhap && matkhau == this.matkhau)
            {
                return true;
            }
            else 
            { 
                return false; 
            }
        }

        private void frmLogIn1_Load(object sender, EventArgs e)
        {

        }
    }
}
