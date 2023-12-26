using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using HeThongThuongMaiDT.Class;

namespace HeThongThuongMaiDT
{
    public partial class frmDMShipper : Form


    {
        DataTable tblNV; //Lưu dữ liệu bảng nhân viên
        public frmDMShipper()
        {
            InitializeComponent();
        }
       

        private void frmDMShipper_Load(object sender, EventArgs e)
        {
            txtMaShipper.Enabled = false;
            txtTenShipper.Enabled = true;
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            LoadDataGridView();
        }
        public void LoadDataGridView()
        {
            string sql;
            sql = "SELECT MaShipper,TenShipper,GioiTinh,DiaChi,DienThoai,NgaySinh FROM tblShipper";
            tblNV = Functions.GetDataToTable(sql); //lấy dữ liệu
            dgvShipper.DataSource = tblNV;
            dgvShipper.Columns[0].HeaderText = "Mã Shipper";
            dgvShipper.Columns[1].HeaderText = "Tên Shipper";
            dgvShipper.Columns[2].HeaderText = "Giới tính";
            dgvShipper.Columns[3].HeaderText = "Địa chỉ";
            dgvShipper.Columns[4].HeaderText = "Điện thoại";
            dgvShipper.Columns[5].HeaderText = "Ngày sinh";
            dgvShipper.Columns[0].Width = 100;
            dgvShipper.Columns[1].Width = 150;
            dgvShipper.Columns[2].Width = 100;
            dgvShipper.Columns[3].Width = 150;
            dgvShipper.Columns[4].Width = 100;
            dgvShipper.Columns[5].Width = 100;
            dgvShipper.AllowUserToAddRows = false;
            dgvShipper.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

       /* private void dgvShipper_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        } */
        private void btnThem_Click(object sender, EventArgs e)
        {
            txtTenShipper.Enabled = true;
            
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValues();
            txtMaShipper.Enabled = true;
            txtMaShipper.Focus();
        }
        private void ResetValues()
        {
            txtMaShipper.Text = "";
            txtTenShipper.Text = "";
            chkGioiTinh.Checked = false;
            txtDiaChi.Text = "";
            dtpNgaySinh.Value = DateTime.Now;
            mtbDienThoai.Text = "";
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql, gt;
            if (txtMaShipper.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã shipper", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaShipper.Focus();
                return;
            }
            if (txtTenShipper.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên shipper", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenShipper.Focus();
                return;
            }
            if (txtDiaChi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiaChi.Focus();
                return;
            }
            if (mtbDienThoai.Text == "(   )     -")
            {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mtbDienThoai.Focus();
                return;
            }
           
           
            if (chkGioiTinh.Checked == true)
                gt = "Nam";
            else
                gt = "Nữ";
            sql = "SELECT MaShipper FROM tblShipper WHERE MaShipper=N'" + txtMaShipper.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã shipper này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaShipper.Focus();
                txtMaShipper.Text = "";
                return;
            }
            sql = "INSERT INTO tblShipper(MaShipper,TenShipper,GioiTinh, DiaChi,DienThoai, NgaySinh) VALUES (N'" + txtMaShipper.Text.Trim() + "',N'" + txtTenShipper.Text.Trim() + "',N'" + gt + "',N'" + txtDiaChi.Text.Trim() + "','" + mtbDienThoai.Text + "','" + dtpNgaySinh.Value + "')";
            Functions.RunSQL(sql);
            LoadDataGridView();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoQua.Enabled = false;
            btnLuu.Enabled = false;
            txtMaShipper.Enabled = false;
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql, gt;
            if (tblNV.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaShipper.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenShipper.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên shipper", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenShipper.Focus();
                return;
            }
            if (txtDiaChi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiaChi.Focus();
                return;
            }
            if (mtbDienThoai.Text == "(   )     -")
            {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mtbDienThoai.Focus();
                return;
            }
            if (dtpNgaySinh.Text == "  /  /")
            {
                MessageBox.Show("Bạn phải nhập ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNgaySinh.Focus();
                return;
            }
            /*if (!Functions.IsDate(dtpNgaySinh.Text))
            {
                MessageBox.Show("Bạn phải nhập lại ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNgaySinh.Text = "";
                dtpNgaySinh.Focus();
                return;
            }*/
            if (chkGioiTinh.Checked == true)
                gt = "Nam";
            else
                gt = "Nữ";
            sql = "UPDATE tblShipper SET  TenShipper=N'" + txtTenShipper.Text.Trim().ToString() +
                    "',DiaChi=N'" + txtDiaChi.Text.Trim().ToString() +
                    "',DienThoai='" + mtbDienThoai.Text.ToString() + "',GioiTinh=N'" + gt +
                    "',NgaySinh='" + Functions.ConvertDateTime(dtpNgaySinh.Text) +
                    "' WHERE MaShipper=N'" + txtMaShipper.Text + "'";
            Functions.RunSQL(sql);
            LoadDataGridView();
            ResetValues();
            btnBoQua.Enabled = false;
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblNV.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaShipper.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE tblShipper WHERE MaShipper=N'" + txtMaShipper.Text + "'";
                Functions.RunSqlDel(sql);
                LoadDataGridView();
                ResetValues();
            }

        }
        private void btnBoQua_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnBoQua.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtMaShipper.Enabled = false;
        }
        private void txtMaNhanVien_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }
        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvShipper_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaShipper.Focus();
                return;
            }
            if (tblNV.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaShipper.Text = dgvShipper.CurrentRow.Cells["MaShipper"].Value.ToString();
            txtTenShipper.Text = dgvShipper.CurrentRow.Cells["TenShipper"].Value.ToString();
            if (dgvShipper.CurrentRow.Cells["GioiTinh"].Value.ToString() == "Nam") chkGioiTinh.Checked = true;
            else chkGioiTinh.Checked = false;
            txtDiaChi.Text = dgvShipper.CurrentRow.Cells["DiaChi"].Value.ToString();
            mtbDienThoai.Text = dgvShipper.CurrentRow.Cells["DienThoai"].Value.ToString();
            dtpNgaySinh.Value = (DateTime)dgvShipper.CurrentRow.Cells["NgaySinh"].Value;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnXoa.Enabled = true;
        }

        
    }
}
