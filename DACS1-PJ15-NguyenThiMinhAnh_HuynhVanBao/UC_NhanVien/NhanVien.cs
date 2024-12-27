using DACS1_PJ15_NguyenThiMinhAnh_HuynhVanBao.UC_QuanLy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DACS1_PJ15_NguyenThiMinhAnh_HuynhVanBao.UC_NhanVien
{
    public partial class NhanVien : UserControl
    {
        private DataTable tblNhanVien;
        public static bool control;
        public Boolean chckUS { get; set; } = false;
        public NhanVien()
        {
            InitializeComponent();
        }
        private void NhanVien_Load(object sender, EventArgs e)
        {
            //Functions.Connect();
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnQuayLai.Enabled = false;
            dgvNhanVien.AllowUserToAddRows = false;
            dgvNhanVien.EditMode = DataGridViewEditMode.EditProgrammatically;
            LoadDataGridView("SELECT MA_NV, HOTEN_NV, SDT_NV, DIACHI_NV, GIOITINH_NV, NGAYSINH_NV FROM NHANVIEN");
            AllowInput(false);
            DisplayValueTextbox();
            btnIn.Enabled = true;
            dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            lb_Thoat.Visible = chckUS;
        }
        public void LoadDataGridView(string query)
        {
            tblNhanVien = Functions.ReadData(query);
            for (int i = 0; i < dgvNhanVien.ColumnCount; i++)
                dgvNhanVien.Columns[i].DataPropertyName = tblNhanVien.Columns[i].ColumnName;
            dgvNhanVien.Columns[5].DefaultCellStyle.Format = "dd-MM-yyyy";
            dgvNhanVien.DataSource = tblNhanVien;
            
        }

        public void RsValue()
        {
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            txtSDT.Text = "";
            txtDiaChi.Text = "";
            radioNam.Checked = false;
            radioNu.Checked = false;
            dtpNgaySinh.Value = DateTime.Now;
        }
        public void DisplayValueTextbox()
        {
            if (dgvNhanVien.Rows.Count > 0)
            {
                txtMaNV.Text = dgvNhanVien.SelectedCells[0].Value.ToString();
                txtTenNV.Text = dgvNhanVien.SelectedCells[1].Value.ToString();
                txtSDT.Text = dgvNhanVien.SelectedCells[2].Value.ToString();
                txtDiaChi.Text = dgvNhanVien.SelectedCells[3].Value.ToString();
                if (dgvNhanVien.SelectedCells[4].Value.ToString() == "Nam")
                    radioNam.Checked = true;
                else
                    radioNu.Checked = true;
                dtpNgaySinh.Value = Convert.ToDateTime(dgvNhanVien.SelectedCells[5].Value);

            }
            else
                RsValue();
        }

        private void AllowInput(bool control)
        {
            txtMaNV.Enabled = control;
            txtTenNV.Enabled = control;
            txtSDT.Enabled = control;
            txtDiaChi.Enabled = control;
            radioNam.Enabled = control;
            radioNu.Enabled = control;
            dtpNgaySinh.Enabled = control;
        }

        private void txtTenNV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            control = true;
            AllowInput(true);
            btnSua.Enabled = false;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnQuayLai.Enabled = true;
            RsValue();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (control == true)
            {
                if (txtMaNV.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaNV.Focus();
                    return;
                }

                if (txtTenNV.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập họ tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenNV.Focus();
                    return;
                }

                if (txtSDT.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSDT.Focus();
                    return;
                }

                if (txtDiaChi.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập số điạ chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDiaChi.Focus();
                    return;

                }

                if (radioNam.Checked == false && radioNu.Checked == false)
                {
                    MessageBox.Show("Bạn phải chọn giới tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int dtime = DateTime.Now.Year - 18;

                if (dtpNgaySinh.Value.Year >= dtime)
                {
                    MessageBox.Show("Ngày Sinh >=" + dtime, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }

                else
                {
                    string GT;
                    if (radioNam.Checked == true)
                        GT = "Nam";
                    else
                        GT = "Nữ";
                    Functions.runSql($"INSERT INTO NHANVIEN(MA_NV, MACN, HOTEN_NV, SDT_NV, DIACHI_NV, GIOITINH_NV, NGAYSINH_NV) VALUES ('{txtMaNV.Text.Trim()}', '{Functions.maCN}',  N'{txtTenNV.Text.Trim()}', '{txtSDT.Text.Trim()}', N'{txtDiaChi.Text.Trim()}', N'{GT}', '{dtpNgaySinh.Value}')");
                    LoadDataGridView("SELECT MA_NV, HOTEN_NV, SDT_NV, DIACHI_NV, GIOITINH_NV, NGAYSINH_NV FROM NHANVIEN");
                    DisplayValueTextbox();
                    RsValue();
                    btnXoa.Enabled = true;
                    btnThem.Enabled = true;
                    btnSua.Enabled = true;
                    btnQuayLai.Enabled = false;
                    btnLuu.Enabled = false;
                    MessageBox.Show("Thực hiện lưu thành công!", "Infomation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (tblNhanVien.Rows.Count == 0)
                {
                    MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


                if (txtTenNV.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenNV.Focus();
                    return;
                }

                if (txtSDT.Text == "")
                {
                    MessageBox.Show("Bạn phải nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSDT.Focus();
                    return;
                }
                if (txtDiaChi.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDiaChi.Focus();
                    return;

                }

                int dtime = DateTime.Now.Year - 18;

                if (dtpNgaySinh.Value.Year >= dtime)
                {
                    MessageBox.Show("Ngày Sinh >=" + dtime, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }

                else
                {
                    if (MessageBox.Show("Thông tin sẽ bị sửa đổi! Bạn có chắc muốn sửa không?", "Warnning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        Functions.runSql("UPDATE NHANVIEN SET  HOTEN_NV = N'" + txtTenNV.Text.Trim().ToString() + "', SDT_NV='" + txtSDT.Text.Trim().ToString() + "',DIACHI_NV=N'" + txtDiaChi.Text.Trim().ToString() + "',GIOITINH_NV=N'" + (radioNam.Checked == true ? "Nam" : "Nữ") + "', NGAYSINH_NV='" + dtpNgaySinh.Value.ToString() + "' WHERE MA_NV = '" + txtMaNV.Text + "'");
                        LoadDataGridView("SELECT MA_NV, HOTEN_NV, SDT_NV, DIACHI_NV, GIOITINH_NV, NGAYSINH_NV FROM NHANVIEN");
                        DisplayValueTextbox();
                        btnXoa.Enabled = true;
                        btnThem.Enabled = true;
                        btnSua.Enabled = false;
                        btnQuayLai.Enabled = false;
                        btnLuu.Enabled = false;
                        MessageBox.Show("Sửa thành công!", "Infomation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            AllowInput(true);
           
            btnQuayLai.Enabled = true;
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnThem.Enabled = false;
            txtMaNV.Enabled = false;  
            control = false;
        }

       

        private void dgvNhanVien_Click(object sender, EventArgs e)
        {
            if (tblNhanVien.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                DisplayValueTextbox();
                AllowInput(false);
                btnQuayLai.Enabled = true;
                btnLuu.Enabled = true;
                btnSua.Enabled = true;
                btnThem.Enabled = false;
                btnXoa.Enabled = true;
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            AllowInput(true);
            btnThem.Enabled = true;
            btnQuayLai.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            DisplayValueTextbox();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string mes;
            int rowCount = dgvNhanVien.SelectedRows.Count;
            if (rowCount > 1)
                mes = rowCount + " dòng dữ liệu sẽ bị xóa, bạn chắc muốn xóa các dòng đó không ?";
            else
                mes = "Dòng dữ liệu sẽ bị xóa, bạn có chắc muốn xóa không ?";
            if (MessageBox.Show(mes, "Warnning", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                for (int i = 0; i < rowCount; i++)
                {
                    if (String.IsNullOrEmpty(Functions.getValueByKey($"SELECT MA_PN FROM PHIEUNHAP WHERE MA_NV = '{dgvNhanVien.SelectedRows[i].Cells[0].Value}'")) &&
                       (String.IsNullOrEmpty(Functions.getValueByKey($"SELECT MA_HD FROM HOADON WHERE MA_NV = '{dgvNhanVien.SelectedRows[i].Cells[0].Value}'"))))
                    {
                        Functions.runSql(" DELETE TAIKHOAN WHERE MA_NV = '" + dgvNhanVien.SelectedRows[i].Cells[0].Value.ToString() + "' ");
                        Functions.runSql(" DELETE NHANVIEN WHERE MA_NV = '" + dgvNhanVien.SelectedRows[i].Cells[0].Value.ToString() + "' ");
                    }

                    else
                        MessageBox.Show("Không thể xóa do có phiếu nhập hoặc hóa đơn của nhân viên lập");
                }
                LoadDataGridView("SELECT MA_NV, HOTEN_NV, SDT_NV, DIACHI_NV, GIOITINH_NV, NGAYSINH_NV FROM NHANVIEN");
            }
            DisplayValueTextbox();
            btnQuayLai.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = true;
        }

        private void tb_TimKiem_TextChanged(object sender, EventArgs e)
        {
            LoadDataGridView("SELECT MA_NV, HOTEN_NV, SDT_NV, DIACHI_NV, GIOITINH_NV, NGAYSINH_NV FROM NHANVIEN WHERE MA_NV LIKE '%" + tb_TimKiem.Text.Trim() + "%' OR HOTEN_NV LIKE N'%" + tb_TimKiem.Text.Trim() + "%' OR GIOITINH_NV LIKE N'%" + tb_TimKiem.Text.Trim() + "%' OR SDT_NV LIKE '%" + tb_TimKiem.Text.Trim() + "%' OR DIACHI_NV LIKE N'%" + tb_TimKiem.Text.Trim() + "%' OR CONVERT(VARCHAR(20), NGAYSINH_NV, 103) LIKE '%" + tb_TimKiem.Text.Trim() + "%' ");
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            frmReportNV frmReportNV = new frmReportNV();
            frmReportNV.ShowDialog();
        }

        private void lb_Thoat_Click(object sender, EventArgs e)
        {
            TaiKhoan tk = new TaiKhoan();
            Functions functions = new Functions();
            functions.showUC(tk, pn_Container);
        }
    }
}
