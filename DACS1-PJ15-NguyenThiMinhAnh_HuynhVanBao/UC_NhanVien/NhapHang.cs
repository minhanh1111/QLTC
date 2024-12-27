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
    public partial class NhapHang : UserControl
    {
       
        public NhapHang()
        {
            InitializeComponent();
        }
        private bool? isUpdatePN = null;
        private bool? isUpdateCT = null;
        private bool isCheckedChange;
        private DataTable tblNH;
        private DataTable tblCT;
        private string keyPN { get; set; }
        private int index { get; set; }
        private void NhapHang_Load(object sender, EventArgs e)
        {
           
            Functions.FillCombo("SELECT MA_NCC, TEN_NCC FROM NHACUNGCAP", cboNCC, "MA_NCC", "TEN_NCC");
            Functions.FillCombo("SELECT MA_SP, TEN_SP FROM SANPHAM", cboSP, "MA_SP", "TEN_SP");
            Functions.FillCombo("SELECT MA_NV, HOTEN_NV FROM NHANVIEN", cboNguoiLap, "MA_NV", "HOTEN_NV");
            LoadDataGridViewPN("SELECT MA_PN, PHIEUNHAP.MA_NCC, TEN_NCC, NGAYNHAP, PHIEUNHAP.MA_NV, HOTEN_NV, TONGTIEN, GHICHU, TRANGTHAI FROM PHIEUNHAP INNER JOIN NHANVIEN ON PHIEUNHAP.MA_NV = NHANVIEN.MA_NV INNER JOIN NHACUNGCAP ON PHIEUNHAP.MA_NCC = NHACUNGCAP.MA_NCC ORDER BY NGAYNHAP DESC");
            AllowInputPN(false);
            AllowInputCT(false);
            dgvNhapHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCTNhapHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (dgvCTNhapHang.Rows.Count <= 0)
            {
                MessageBox.Show("Bạn phải nhập chi tiết!");
                return;
            }
            string keyPN = "";
            if (isUpdatePN == false)
            {
                if (CheckValuePN() && CheckValueCT())
                {
                    keyPN = Functions.createKey("PN_");
                    Functions.runSql($"INSERT INTO PHIEUNHAP VALUES('{keyPN}','{cboNCC.SelectedValue}', '{cboNguoiLap.SelectedValue}','{Functions.maCN}', '{dtpNgayLap.Value}', {txtTongTien.Text}, N'{txtGhiChu.Text.Trim()}', N'{(chkKiemHang.Checked == true ? "Đã kiểm hàng" : "Chưa kiểm hàng")}')");
                    Functions.runSql($"INSERT INTO CHITIETPHIEUNHAP(MACHITIETPHIEU, MA_PN, MA_SP, LO, SOLUONG, DONGIA) VALUES ( '{Functions.createKey("CTPN_")}','{keyPN}', '{cboSP.SelectedValue}', '{Functions.createKey("L_")}', {numericSL.Value}, '{txtDonGia.Text.Trim()}')");
                }
            }
            else
            {
                keyPN = dgvNhapHang.SelectedCells[0].Value.ToString();
                if (isUpdatePN == true && CheckValuePN())
                {
                    Functions.runSql($"UPDATE PHIEUNHAP SET MA_NCC = '{cboNCC.SelectedValue}', MA_NV = '{cboNguoiLap.SelectedValue}', NGAYNHAP= '{dtpNgayLap.Value}', TONGTIEN = {txtTongTien.Text.Trim()}, GHICHU = N'{txtGhiChu.Text.Trim()}', TRANGTHAI = N'{(chkKiemHang.Checked == true ? "Đã kiểm hàng" : "Chưa kiểm hàng")}' WHERE MA_PN= '{keyPN}' ");
                    if ((!isCheckedChange && chkKiemHang.Checked) || (isCheckedChange && !chkKiemHang.Checked))
                    {
                        if (chkKiemHang.Checked == true)
                        {
                            for (int i = 0; i < dgvCTNhapHang.RowCount; i++)
                            {
                                Functions.runSql($"UPDATE SANPHAM SET SOLUONG_SP = SOLUONG_SP + {dgvCTNhapHang.Rows[i].Cells[4].Value} WHERE MA_SP = '{dgvCTNhapHang.Rows[i].Cells[1].Value}'");
                            }
                        }
                        else
                        {
                            for (int i = 0; i < dgvCTNhapHang.RowCount; i++)
                            {
                                Functions.runSql($"UPDATE SANPHAM SET SOLUONG_SP = SOLUONG_SP - {dgvCTNhapHang.Rows[i].Cells[4].Value} WHERE MA_SP = '{dgvCTNhapHang.Rows[i].Cells[1].Value}'");
                            }
                        }
                    }

                }

                if (isUpdateCT == true && CheckValueCT())
                {
                    Functions.runSql($"UPDATE CHITIETPHIEUNHAP SET MA_SP='{cboSP.SelectedValue}', SOLUONG='{numericSL.Value}', DONGIA='{txtDonGia.Text.Trim()}' WHERE MACHITIETPHIEU='{dgvCTNhapHang.SelectedCells[0].Value}' "); }
            }
            DisableControl(true, true);
            LoadDataGridViewCT($"SELECT MACHITIETPHIEU, CHITIETPHIEUNHAP.MA_SP, TEN_SP, LO, SOLUONG, DONGIA, SOLUONG * DONGIA AS THANHTIEN FROM CHITIETPHIEUNHAP INNER JOIN SANPHAM ON CHITIETPHIEUNHAP.MA_SP = SANPHAM.MA_SP INNER JOIN PHIEUNHAP ON CHITIETPHIEUNHAP.MA_PN = PHIEUNHAP.MA_PN WHERE CHITIETPHIEUNHAP.MA_PN = '{keyPN}'");
            TotalAmount();
            Functions.runSql($"UPDATE PHIEUNHAP SET TONGTIEN = {txtTongTien.Text} WHERE MA_PN = '{dgvNhapHang.SelectedCells[0].Value}'");
            LoadDataGridViewPN("SELECT MA_PN, PHIEUNHAP.MA_NCC, TEN_NCC, NGAYNHAP, PHIEUNHAP.MA_NV, HOTEN_NV, TONGTIEN, GHICHU, TRANGTHAI FROM PHIEUNHAP INNER JOIN NHANVIEN ON PHIEUNHAP.MA_NV = NHANVIEN.MA_NV INNER JOIN NHACUNGCAP ON PHIEUNHAP.MA_NCC = NHACUNGCAP.MA_NCC ORDER BY NGAYNHAP DESC");
            isUpdatePN = null;
            isUpdateCT = null;
            btnThem.Enabled = true;
            chkKiemHang.Checked = false;
            btnBoQuaPN.Enabled = true;
            btnLuu.Enabled = false;
            btnSuaPN.Enabled = false;
            btnXoaPN.Enabled = false;
            btnThemPN.Enabled = true;
            btnInPN.Enabled = false;
            dgvCTNhapHang.Enabled = false;
            MessageBox.Show("Cập nhật thành công", "Quản Lý Thú Cưng", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CheckValueCT())
            {
                if (isUpdatePN == false)
                {
                    keyPN = Functions.createKey("PN_");
                    if (CheckValuePN())
                    {
                        Functions.runSql($"INSERT INTO PHIEUNHAP(MA_PN, MA_NCC, MA_NV, MACN, NGAYNHAP, TONGTIEN, GHICHU, TRANGTHAI) VALUES('{keyPN}', '{cboNCC.SelectedValue}', '{cboNguoiLap.SelectedValue}', '{Functions.maCN}', '{dtpNgayLap.Value}', {(String.IsNullOrEmpty(txtTongTien.Text) ? "0" : txtTongTien.Text)}, N'{txtGhiChu.Text.Trim()}', N'Chưa kiểm hàng')");
                        isUpdatePN = null;
                    }
                    else
                    {
                        return;
                    }
                }
               
                Functions.runSql($"INSERT INTO CHITIETPHIEUNHAP(MACHITIETPHIEU, MA_PN, MA_SP, LO, SOLUONG, DONGIA) VALUES('{Functions.createKey("CTPN_")}', '{keyPN}', '{cboSP.SelectedValue}', '{Functions.createKey("L_")}', {numericSL.Value}, '{txtDonGia.Text.Trim()}')");

                LoadDataGridViewCT($"SELECT MACHITIETPHIEU, CHITIETPHIEUNHAP.MA_SP, TEN_SP, LO, SOLUONG, DONGIA, SOLUONG * DONGIA AS THANHTIEN FROM CHITIETPHIEUNHAP INNER JOIN SANPHAM ON CHITIETPHIEUNHAP.MA_SP = SANPHAM.MA_SP INNER JOIN PHIEUNHAP ON CHITIETPHIEUNHAP.MA_PN = PHIEUNHAP.MA_PN WHERE CHITIETPHIEUNHAP.MA_PN = '{keyPN}'");
                TotalAmount();
                Functions.runSql($"UPDATE PHIEUNHAP SET TONGTIEN = {txtTongTien.Text.Trim()} WHERE MA_PN = '{keyPN}'");
                LoadDataGridViewPN("SELECT MA_PN, PHIEUNHAP.MA_NCC, TEN_NCC, NGAYNHAP, PHIEUNHAP.MA_NV, HOTEN_NV, TONGTIEN, GHICHU, TRANGTHAI FROM PHIEUNHAP INNER JOIN NHANVIEN ON PHIEUNHAP.MA_NV = NHANVIEN.MA_NV INNER JOIN NHACUNGCAP ON PHIEUNHAP.MA_NCC = NHACUNGCAP.MA_NCC ORDER BY NGAYNHAP DESC");
                dgvNhapHang.Rows[0].Selected = false;
                dgvNhapHang.Rows[index].Selected = true;
                
                RsValueCT();
            }
        }
        private void LoadDataGridViewPN(string query)
        {
            tblNH = Functions.ReadData(query);
            for (int i = 0; i < dgvNhapHang.ColumnCount; i++)
                dgvNhapHang.Columns[i].DataPropertyName = tblNH.Columns[i].ColumnName;
            dgvNhapHang.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvNhapHang.DataSource = tblNH;
           
        }

        private void LoadDataGridViewCT(string query)
        {
            tblCT = Functions.ReadData(query);
            for (int i = 0; i < dgvCTNhapHang.ColumnCount; i++)
                dgvCTNhapHang.Columns[i].DataPropertyName = tblCT.Columns[i].ColumnName;
            dgvCTNhapHang.DataSource = tblCT;
           
        }

        private void TotalAmount()
        {
            if (dgvCTNhapHang.Rows.Count > 0)
            {
                long tmp = 0;
                for (int i = 0; i < dgvCTNhapHang.Rows.Count; i++)
                {
                    tmp += Convert.ToInt64(dgvCTNhapHang.Rows[i].Cells[6].Value);
                }
                txtTongTien.Text = tmp.ToString();
            }
            else
            {
                txtTongTien.Text = "0";
            }
        }

        private void AllowInputPN(bool control)
        {
            cboNCC.Enabled = control;
            cboNguoiLap.Enabled = control;
            dtpNgayLap.Enabled = control;
            txtDonGia.Enabled = control;
            txtGhiChu.Enabled = control;
        }

        private void AllowInputCT(bool control)
        {

            cboSP.Enabled = control;
            numericSL.Enabled = control;
        }

        private void btnThemPN_Click(object sender, EventArgs e)
        {
            btnThemPN.Enabled = false;
            dgvNhapHang.Enabled = false;
            btnBoQuaPN.Enabled = true;
            chkKiemHang.Enabled = false;
            keyPN = Functions.createKey("PN_");

            for (int i = 0; i < dgvCTNhapHang.RowCount; i++)
            {
                dgvCTNhapHang.Rows.RemoveAt(i);
            }
            btnLuu.Enabled = true;
            isUpdatePN = false;
            AllowInputPN(true);
            AllowInputCT(true);
            DisableControl(true, false);
            btnThem.Enabled = true;
            RsValuePN();
            RsValueCT();
        }
        private void DisableControl(bool btnPN, bool btnCT)
        {
            //PN
            dgvNhapHang.Enabled = btnPN;
            btnThemPN.Enabled = btnPN;
            btnXoaPN.Enabled = false;
            btnSuaPN.Enabled = false;
            btnBoQuaPN.Enabled = true;

            //CT
            btnThem.Enabled = btnCT;
            dgvCTNhapHang.Enabled = btnCT;
           
            btnXoa.Enabled = false;
            btnBoQua.Enabled = false;
        }

        private bool CheckValuePN()
        {
            if (cboNguoiLap.SelectedIndex < 0)
            {
                MessageBox.Show("Bạn phải chọn nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cboNguoiLap.SelectedIndex < 0)
            {
                MessageBox.Show("Bạn phải chọn người lập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private bool CheckValueCT()
        {
            if (cboSP.SelectedIndex < 0)
            {
                MessageBox.Show("Bạn phải chọn sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (numericSL.Value < 1)
            {
                MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void RsValuePN()
        {
            cboNCC.SelectedIndex = -1;
            cboNguoiLap.SelectedIndex = -1;
            dtpNgayLap.Value = DateTime.Now;
            txtTongTien.Clear();
            txtGhiChu.Clear();
            chkKiemHang.Checked = false;
        }

        private void RsValueCT()
        {

            cboSP.SelectedIndex = -1;
            txtDonGia.Clear();
            numericSL.Value = 0;
        }

        private void DisplayValuePN()
        {
            if (dgvNhapHang.SelectedRows.Count > 0)
            {
                cboNCC.SelectedValue = dgvNhapHang.SelectedCells[1].Value;
                dtpNgayLap.Value = Convert.ToDateTime(dgvNhapHang.SelectedCells[3].Value);
                cboNguoiLap.SelectedValue = dgvNhapHang.SelectedCells[4].Value;
                txtTongTien.Text = dgvNhapHang.SelectedCells[6].Value.ToString();
                txtGhiChu.Text = dgvNhapHang.SelectedCells[7].Value.ToString();
                if (dgvNhapHang.SelectedCells[8].Value.ToString() == chkKiemHang.Text)
                    chkKiemHang.Checked = true;
                else
                    chkKiemHang.Checked = false;
            }
            else
            {
                RsValuePN();

            }
        }

        private void DisplayValueCT()
        {
            if (dgvCTNhapHang.SelectedRows.Count > 0)
            {
                cboSP.SelectedValue = dgvCTNhapHang.SelectedCells[1].Value;
                numericSL.Value = Convert.ToInt16(dgvCTNhapHang.SelectedCells[4].Value);
                txtDonGia.Text = dgvCTNhapHang.SelectedCells[5].Value.ToString();
            }
            else
            {
                RsValueCT();
            }
        }

        private void dgvNhapHang_Click(object sender, EventArgs e)
        {
            keyPN = dgvNhapHang.SelectedCells[0].Value.ToString();
            index = dgvNhapHang.CurrentRow.Index;
            if (dgvNhapHang.SelectedRows.Count > 0)
            {
                LoadDataGridViewCT($"SELECT MACHITIETPHIEU, CHITIETPHIEUNHAP.MA_SP, TEN_SP, LO, SOLUONG, DONGIA, SOLUONG * DONGIA AS THANHTIEN FROM CHITIETPHIEUNHAP INNER JOIN SANPHAM ON CHITIETPHIEUNHAP.MA_SP = SANPHAM.MA_SP INNER JOIN PHIEUNHAP ON CHITIETPHIEUNHAP.MA_PN = PHIEUNHAP.MA_PN WHERE CHITIETPHIEUNHAP.MA_PN = '{dgvNhapHang.SelectedCells[0].Value}'");
                DisplayValuePN();
                DisplayValueCT();
                AllowInputPN(false);
                AllowInputCT(false);
                dgvCTNhapHang.Enabled = false;
                btnThemPN.Enabled = false;
                btnSuaPN.Enabled = true;
                btnXoaPN.Enabled = true;
                btnInPN.Enabled = true;
                btnBoQuaPN.Enabled = true;
                isCheckedChange = chkKiemHang.Checked;
                btnThem.Enabled = true ;
            }
        }



        private void btnSuaPN_Click(object sender, EventArgs e)
        {
            AllowInputPN(true);
            AllowInputCT(true);
            keyPN = dgvNhapHang.SelectedCells[0].Value.ToString();
            btnInPN.Enabled = false;
            dgvNhapHang.Enabled = false;
            dgvCTNhapHang.Enabled = true;
            isUpdatePN = true;
            isUpdateCT = true;
            btnBoQuaPN.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = true;
            btnThemPN.Enabled = false;
            btnSuaPN.Enabled = false;
            btnXoaPN.Enabled = false;
            btnBoQua.Enabled = true;
            chkKiemHang.Enabled = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            AllowInputCT(true);
            isUpdateCT = true;
            isUpdatePN = true;
            btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
           
            btnXoa.Enabled = false;
        }

        private void dgvCTNhapHang_Click(object sender, EventArgs e)
        {
            if (tblCT.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                DisplayValueCT();
                btnBoQua.Enabled = true;
                btnLuu.Enabled = true;
               
                btnThem.Enabled = false;
                btnXoa.Enabled = true;
            }
        }

        
           

        private void btnXoaPN_Click(object sender, EventArgs e)
        {
            string mes;
            int rowCount = dgvNhapHang.SelectedRows.Count;
            if (rowCount > 1)
                mes = rowCount + " dòng dữ liệu sẽ bị xóa, bạn chắc muốn xóa các dòng đó không ?";
            else
                mes = "Dòng dữ liệu sẽ bị xóa, bạn có chắc muốn xóa không ?";
            if (MessageBox.Show(mes, "Warnning", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                for (int i = 0; i < rowCount; i++)
                {
                    Functions.runSql($"DELETE CHITIETPHIEUNHAP WHERE MA_PN = '{dgvNhapHang.SelectedRows[i].Cells[0].Value}' ");
                    Functions.runSql($"DELETE PHIEUNHAP WHERE MA_PN = '{dgvNhapHang.SelectedRows[i].Cells[0].Value}' ");

                }
                LoadDataGridViewPN("SELECT MA_PN, PHIEUNHAP.MA_NCC, TEN_NCC, NGAYNHAP, PHIEUNHAP.MA_NV, HOTEN_NV, TONGTIEN, GHICHU, TRANGTHAI FROM PHIEUNHAP INNER JOIN NHANVIEN ON PHIEUNHAP.MA_NV = NHANVIEN.MA_NV INNER JOIN NHACUNGCAP ON PHIEUNHAP.MA_NCC = NHACUNGCAP.MA_NCC ORDER BY NGAYNHAP DESC");
                AllowInputPN(false);
                if (dgvNhapHang.Rows.Count > 0)
                {
                    LoadDataGridViewCT($"SELECT MACHITIETPHIEU, CHITIETPHIEUNHAP.MA_SP, TEN_SP, LO, SOLUONG, DONGIA, SOLUONG * DONGIA AS THANHTIEN FROM CHITIETPHIEUNHAP INNER JOIN SANPHAM ON CHITIETPHIEUNHAP.MA_SP = SANPHAM.MA_SP INNER JOIN PHIEUNHAP ON CHITIETPHIEUNHAP.MA_PN = PHIEUNHAP.MA_PN WHERE CHITIETPHIEUNHAP.MA_PN = '{dgvNhapHang.SelectedCells[0].Value}'");
                }
                else
                {
                    LoadDataGridViewCT($"SELECT MACHITIETPHIEU, CHITIETPHIEUNHAP.MA_SP, TEN_SP, LO, SOLUONG, DONGIA, SOLUONG * DONGIA AS THANHTIEN FROM CHITIETPHIEUNHAP INNER JOIN SANPHAM ON CHITIETPHIEUNHAP.MA_SP = SANPHAM.MA_SP INNER JOIN PHIEUNHAP ON CHITIETPHIEUNHAP.MA_PN = PHIEUNHAP.MA_PN WHERE CHITIETPHIEUNHAP.MA_PN = ''");
                }
            }

            btnBoQuaPN.Enabled = false;
            btnSuaPN.Enabled = false;
            btnXoaPN.Enabled = false;
            btnThemPN.Enabled = true;
            dgvCTNhapHang.Refresh();
            DisplayValuePN();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string mes;
            int rowCount = dgvCTNhapHang.SelectedRows.Count;
            if (rowCount > 1)
                mes = rowCount + " dòng dữ liệu sẽ bị xóa, bạn chắc muốn xóa các dòng đó không ?";
            else
                mes = "Dòng dữ liệu sẽ bị xóa, bạn có chắc muốn xóa không ?";
            if (MessageBox.Show(mes, "Warnning", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                for (int i = 0; i < rowCount; i++)
                {
                    Functions.runSql(" DELETE CHITIETPHIEUNHAP WHERE MACHITIETPHIEU = '" + dgvCTNhapHang.SelectedRows[i].Cells[0].Value.ToString() + "' ");
                }

                LoadDataGridViewCT($"SELECT MACHITIETPHIEU, CHITIETPHIEUNHAP.MA_SP, TEN_SP, LO, SOLUONG, DONGIA, SOLUONG * DONGIA AS THANHTIEN FROM CHITIETPHIEUNHAP INNER JOIN SANPHAM ON CHITIETPHIEUNHAP.MA_SP = SANPHAM.MA_SP INNER JOIN PHIEUNHAP ON CHITIETPHIEUNHAP.MA_PN = PHIEUNHAP.MA_PN WHERE CHITIETPHIEUNHAP.MA_PN = '{dgvNhapHang.SelectedCells[0].Value}'");
                TotalAmount();
                Functions.runSql($"UPDATE PHIEUNHAP SET TONGTIEN = {txtTongTien.Text} WHERE MA_PN = '{dgvNhapHang.SelectedCells[0].Value}'");

                LoadDataGridViewPN("SELECT MA_PN, PHIEUNHAP.MA_NCC, TEN_NCC, NGAYNHAP, PHIEUNHAP.MA_NV, HOTEN_NV, TONGTIEN, GHICHU, TRANGTHAI FROM PHIEUNHAP INNER JOIN NHANVIEN ON PHIEUNHAP.MA_NV = NHANVIEN.MA_NV INNER JOIN NHACUNGCAP ON PHIEUNHAP.MA_NCC = NHACUNGCAP.MA_NCC ORDER BY NGAYNHAP DESC");

            }

            btnBoQua.Enabled = false;
           
            btnXoa.Enabled = false;
            btnThem.Enabled = true;
            DisplayValueCT();
        }

        private void btnInPN_Click(object sender, EventArgs e)
        {
            Functions.maPN = dgvNhapHang.SelectedCells[0].Value.ToString();
            frmReportPN frmReportPN = new frmReportPN();
            frmReportPN.ShowDialog();
        }

        private void btnCapNhatNCC_Click(object sender, EventArgs e)
        {
            NhaCungCap userControl = new NhaCungCap();

            Form popupForm = new Form();
            popupForm.Text = "Cập nhật nhà cung cấp";
            popupForm.Controls.Add(userControl);
            popupForm.StartPosition = FormStartPosition.CenterParent;
            popupForm.Width = 950;
            popupForm.Height = 540;
            popupForm.ShowDialog();
        }

        private void btnBoQuaPN_Click(object sender, EventArgs e)
        {
            dgvNhapHang.Enabled = true;
            btnThemPN.Enabled = true;
            btnBoQuaPN.Enabled = false;
            btnSuaPN.Enabled = false;
            btnXoaPN.Enabled = false;
            btnThem.Enabled = false;
            btnLuu.Enabled = false;
            btnInPN.Enabled = false;
            DisplayValuePN();
            AllowInputPN(true);
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            AllowInputCT(true);
            DisplayValueCT();
            btnThem.Enabled = true;
            btnBoQua.Enabled = false;          
            btnXoa.Enabled = false;
            btnInPN.Enabled = false;
           
           
        }

      

        private void btn_ThongKe_Click(object sender, EventArgs e)
        {
            ThongKePhieuNhap thongKePhieuNhap = new ThongKePhieuNhap();
            thongKePhieuNhap.ShowDialog();
        }

       

        

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            LoadDataGridViewPN("SELECT MA_PN, PHIEUNHAP.MA_NCC, TEN_NCC, NGAYNHAP, PHIEUNHAP.MA_NV, HOTEN_NV, TONGTIEN, GHICHU, TRANGTHAI FROM PHIEUNHAP " +
               "INNER JOIN NHANVIEN ON PHIEUNHAP.MA_NV = NHANVIEN.MA_NV INNER JOIN NHACUNGCAP ON PHIEUNHAP.MA_NCC = NHACUNGCAP.MA_NCC " +
               "WHERE MA_PN LIKE '%" + txtTimKiem.Text.Trim() + "%' OR CONVERT(VARCHAR(20), NGAYNHAP, 103) LIKE '%" + txtTimKiem.Text.Trim() + "%'" +
               " OR TEN_NCC LIKE N'%" + txtTimKiem.Text.Trim() + "%' OR HOTEN_NV LIKE N'%" + txtTimKiem.Text.Trim() + "%' OR TONGTIEN LIKE '%" + txtTimKiem.Text.Trim() + "%' OR GHICHU LIKE '%" + txtTimKiem.Text.Trim() + "%' OR TRANGTHAI LIKE N'%" + txtTimKiem.Text.Trim() + "%' ");
        }
    }
    }

