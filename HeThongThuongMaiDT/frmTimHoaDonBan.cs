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
using HeThongThuongMaiDT.Class;

namespace HeThongThuongMaiDT
{
    public partial class frmTimHoaDonBan : Form
    {
        DataTable tblHDB; //Hoá đơn bán
        public frmTimHoaDonBan()
        {
            InitializeComponent();
        }

        private void frmTimHoaDonBan_Load(object sender, EventArgs e)
        {
            ResetValues();
            dgvTKHoaDon.DataSource = null;
        }
        private void ResetValues()
        {
            foreach (Control Ctl in this.Controls)
                if (Ctl is TextBox)
                    Ctl.Text = "";
            txtMaHDBan.Focus();
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txtMaHDBan.Text == "") && (txtThang.Text == "") && (txtNam.Text == "") &&
               (txtMaShipper.Text == "") && (txtMaKhach.Text == "") &&
               (txtTongTien.Text == ""))
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yêu cầu ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * FROM tblHDBan WHERE 1=1";
            if (txtMaHDBan.Text != "")
                sql = sql + " AND MaHDBan Like N'%" + txtMaHDBan.Text + "%'";
            if (txtThang.Text != "")
                sql = sql + " AND MONTH(NgayBan) =" + txtThang.Text;
            if (txtNam.Text != "")
                sql = sql + " AND YEAR(NgayBan) =" + txtNam.Text;
            if (txtMaShipper.Text != "")
                sql = sql + " AND MaShipper Like N'%" + txtMaShipper.Text + "%'";
            if (txtMaKhach.Text != "")
                sql = sql + " AND MaKhach Like N'%" + txtMaKhach.Text + "%'";
            if (txtTongTien.Text != "")
                sql = sql + " AND TongTien <=" + txtTongTien.Text;
            tblHDB = Functions.GetDataToTable(sql);
            if (tblHDB.Rows.Count == 0)
            {
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Có " + tblHDB.Rows.Count + " bản ghi thỏa mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvTKHoaDon.DataSource = tblHDB;
            LoadDataGridView();
        }
        private void LoadDataGridView()
        {
            dgvTKHoaDon.Columns[0].HeaderText = "Mã HĐB";
            dgvTKHoaDon.Columns[1].HeaderText = "Mã Shipper";
            dgvTKHoaDon.Columns[2].HeaderText = "Ngày bán";
            dgvTKHoaDon.Columns[3].HeaderText = "Mã khách";
            dgvTKHoaDon.Columns[4].HeaderText = "Tổng tiền";
            dgvTKHoaDon.Columns[0].Width = 150;
            dgvTKHoaDon.Columns[1].Width = 100;
            dgvTKHoaDon.Columns[2].Width = 80;
            dgvTKHoaDon.Columns[3].Width = 80;
            dgvTKHoaDon.Columns[4].Width = 80;
            dgvTKHoaDon.AllowUserToAddRows = false;
            dgvTKHoaDon.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void btnTimLai_Click(object sender, EventArgs e)
        {
            ResetValues();
            dgvTKHoaDon.DataSource = null;
        }
        private void txtTongTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }
        private void dgvTKHoaDon_DoubleClick(object sender, EventArgs e)
        {
            string mahd;
            if (MessageBox.Show("Bạn có muốn hiển thị thông tin chi tiết?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                mahd = dgvTKHoaDon.CurrentRow.Cells["MaHDBan"].Value.ToString();
                frmHoaDonBan frm = new frmHoaDonBan();
                frm.txtMaHDBan.Text = mahd;
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
            }
        }
        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
