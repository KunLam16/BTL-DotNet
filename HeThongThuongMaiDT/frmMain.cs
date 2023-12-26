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
    public partial class frmMain : Form
    {
        bool isThoat = true;
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Class.Functions.Connect(); //Mở kết nối
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            Class.Functions.Disconnect(); //Đóng kết nối
            Application.Exit(); //Thoát
            
        }

        private void ChatLieu_Click(object sender, EventArgs e)
        {
            frmDMChatLieu frm = new frmDMChatLieu(); //Khởi tạo đối tượng
            frm.MdiParent = this; //Hiển thị
            frm.Show();
        }

        private void mnuShipper_Click(object sender, EventArgs e)
        {
            frmDMShipper frm = new frmDMShipper(); //Khởi tạo đối tượng
            frm.MdiParent = this; //Hiển thị
            frm.Show();
        }

        private void mnuKhachHang_Click(object sender, EventArgs e)
        {
            frmDmKhachHang frm = new frmDmKhachHang(); //Khởi tạo đối tượng
            frm.MdiParent = this; //Hiển thị
            frm.Show();
        }
            private void mnuHangHoa_Click(object sender, EventArgs e)
        {
            frmHang frm = new frmHang(); //Khởi tạo đối tượng
            frm.MdiParent = this ; //Hiển thị
            frm.Show();
        }

        private void mnuHoaDonBan_Click(object sender, EventArgs e)
        {
            frmHoaDonBan frm = new frmHoaDonBan(); //Khởi tạo đối tượng
            frm.MdiParent = this; //Hiển thị
            frm.Show();
        }

        private void mnuThoat_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuFindHoaDon_Click(object sender, EventArgs e)
        {
            frmTimHoaDonBan frm = new frmTimHoaDonBan(); //Khởi tạo đối tượng
            frm.MdiParent = this; //Hiển thị
            frm.Show();
        }

        private void ChiTiet_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn đang sử dụng phần mềm quản lý thương mại điện tử Version 0.0.1 được phát triển bởi 16DaTeams.", "Thông Tin Chi Tiết", MessageBoxButtons.OK, MessageBoxIcon.Information); 
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(isThoat)
            Application.Exit();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isThoat = false;
            this.Close();
            frmLogIn1 frm = new frmLogIn1();
            frm.Show();
        }
    }
}
