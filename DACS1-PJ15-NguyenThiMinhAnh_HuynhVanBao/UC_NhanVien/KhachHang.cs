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
    public partial class KhachHang : UserControl
    {
        private DataTable tblKH;
        public static bool control;
        public Boolean chckUS { get; set; } = false;
        public KhachHang()
        {
            InitializeComponent();
        }

        private void KhachHang_Load(object sender, EventArgs e)
        {
            
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnQuayLai.Enabled = false;
            dgvKhachHang.AllowUserToAddRows = false;
            dgvKhachHang.EditMode = DataGridViewEditMode.EditProgrammatically;
            AllowInput(false);
            LoadDataGridView("SELECT SDT_KH, HOTEN_KH, DIACHI_KH, GIOITINH_KH FROM KHACHHANG");
            DisplayValueTextbox();
            btnIn.Enabled = true;
            dgvKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            lb_Thoat.Visible = chckUS;
        }
        public void LoadDataGridView(string query)
        {
            tblKH = Functions.ReadData(query);
            for (int i = 0; i < dgvKhachHang.ColumnCount; i++)
                dgvKhachHang.Columns[i].DataPropertyName = tblKH.Columns[i].ColumnName;
            dgvKhachHang.DataSource = tblKH;
           
        }

        public void RsValue()
        {
            txtTenKH.Text = "";
            txtSDT_KH.Text = "";
            txtDiaChiKH.Text = "";
            radioNam.Checked = false;
            radioNu.Checked = false;

        }


        private void AllowInput(bool control)
        {
            txtTenKH.Enabled = control;
           
            txtDiaChiKH.Enabled = control;
            radioNam.Enabled = control;
            radioNu.Enabled = control;
        }

        public void DisplayValueTextbox()
        {
            if (dgvKhachHang.Rows.Count > 0)
            {
                txtSDT_KH.Text = dgvKhachHang.SelectedCells[0].Value.ToString();
                txtTenKH.Text = dgvKhachHang.SelectedCells[1].Value.ToString();  
                txtDiaChiKH.Text = dgvKhachHang.SelectedCells[2].Value.ToString();
                if (dgvKhachHang.SelectedCells[3].Value.ToString() == "Nam")
                    radioNam.Checked = true;
                else
                    radioNu.Checked = true;
            }
            else
                RsValue();

        }

        private void dgvKhachHang_Click(object sender, EventArgs e)
        {
            if (tblKH.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                DisplayValueTextbox();
                AllowInput(false);
                txtSDT_KH.Enabled=false;
                btnQuayLai.Enabled = true;
                btnLuu.Enabled = true;
                btnSua.Enabled = true;
                btnThem.Enabled = false;
                btnXoa.Enabled = true;
            }
        }

        private void txtTenKH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void txtSDT_KH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            control = true;
            AllowInput(true);
            txtSDT_KH.Enabled = true;
            btnSua.Enabled = false;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnQuayLai.Enabled = true;

            RsValue();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            AllowInput(true);
            btnQuayLai.Enabled = true;
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnThem.Enabled = false;
            control = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (control == true)
            {

                if (txtTenKH.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập họ tên khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenKH.Focus();
                    return;
                }

                if (txtSDT_KH.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSDT_KH.Focus();
                    return;
                }

                if (txtDiaChiKH.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập điạ chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDiaChiKH.Focus();
                    return;

                }

                if (radioNam.Checked == false && radioNu.Checked == false)
                {
                    MessageBox.Show("Bạn phải chọn giới tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                else
                {
                    string GT;
                    if (radioNam.Checked == true)
                        GT = "Nam";
                    else
                        GT = "Nữ";
                    Functions.runSql($"INSERT INTO KHACHHANG( SDT_KH, MACN, HOTEN_KH, DIACHI_KH, GIOITINH_KH) VALUES ('{txtSDT_KH.Text.Trim()}', '{Functions.maCN}', N'{txtTenKH.Text.Trim()}', N'{txtDiaChiKH.Text.Trim()}', N'{GT}')");
                    LoadDataGridView("SELECT SDT_KH, HOTEN_KH, DIACHI_KH, GIOITINH_KH FROM KHACHHANG");
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
                if (tblKH.Rows.Count == 0)
                {
                    MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (txtTenKH.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập tên khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenKH.Focus();
                    return;
                }

                if (txtSDT_KH.Text == "")
                {
                    MessageBox.Show("Bạn phải nhập số điện thoại khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSDT_KH.Focus();
                    return;
                }
                if (txtDiaChiKH.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập địa chỉ khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDiaChiKH.Focus();
                    return;

                }

                else
                {
                    if (MessageBox.Show("Thông tin sẽ bị sửa đổi! Bạn có chắc muốn sửa không?", "Warnning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        Functions.runSql("UPDATE KHACHHANG SET  HOTEN_KH = N'" + txtTenKH.Text.Trim().ToString() + "',DIACHI_KH=N'" + txtDiaChiKH.Text.Trim().ToString() + "',GIOITINH_KH=N'" + (radioNam.Checked == true ? "Nam" : "Nữ") + "' WHERE SDT_KH = '" + txtSDT_KH.Text + "'");
                        LoadDataGridView("SELECT SDT_KH, HOTEN_KH, DIACHI_KH, GIOITINH_KH FROM KHACHHANG");
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
            int rowCount = dgvKhachHang.SelectedRows.Count;
            if (rowCount > 1)
                mes = rowCount + " dòng dữ liệu sẽ bị xóa, bạn chắc muốn xóa các dòng đó không ?";
            else
                mes = "Dòng dữ liệu sẽ bị xóa, bạn có chắc muốn xóa không ?";
            if (MessageBox.Show(mes, "Warnning", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                for (int i = 0; i < rowCount; i++)
                {
                    if (String.IsNullOrEmpty(Functions.getValueByKey($"SELECT HOADON.MA_HD FROM HOADON WHERE SDT_KH = '{dgvKhachHang.SelectedRows[i].Cells[0].Value}'")) &&
                        String.IsNullOrEmpty(Functions.getValueByKey($"SELECT THUCUNG.MA_TC FROM THUCUNG WHERE SDT_KH = '{dgvKhachHang.SelectedRows[i].Cells[0].Value}'")))
                    {

                        Functions.runSql("DELETE KHACHHANG WHERE SDT_KH = '" + dgvKhachHang.SelectedRows[i].Cells[0].Value.ToString() + "' ");
                    }

                    else
                        MessageBox.Show("Không thể xóa do khách hàng có trong hóa đơn hoặc thú cưng");
                }
                LoadDataGridView("SELECT SDT_KH, HOTEN_KH, DIACHI_KH, GIOITINH_KH FROM KHACHHANG");
            }
            DisplayValueTextbox();
            btnQuayLai.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = true;
        }

       

        private void txtTimKiem_TextChanged_1(object sender, EventArgs e)
        {
            LoadDataGridView("SELECT SDT_KH, HOTEN_KH,  DIACHI_KH, GIOITINH_KH FROM KHACHHANG WHERE SDT_KH LIKE '%" + txtTimKiem.Text.Trim() + "%' OR HOTEN_KH LIKE N'%" + txtTimKiem.Text.Trim() + "%' OR GIOITINH_KH LIKE N'%" + txtTimKiem.Text.Trim() +  "%' OR DIACHI_KH LIKE N'%" + txtTimKiem.Text.Trim() + "%'");
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            frmReportKH frmReportKH = new frmReportKH();
            frmReportKH.ShowDialog();
        }

        private void lb_Thoat_Click(object sender, EventArgs e)
        {
            ThuCung tc = new ThuCung();
            Functions functions = new Functions();
            functions.showUC(tc, pn_Container);
        }
    }
}
