using DACS1_PJ15_NguyenThiMinhAnh_HuynhVanBao.UC_NhanVien;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DACS1_PJ15_NguyenThiMinhAnh_HuynhVanBao
{
    public partial class HoaDon : UserControl
    {
        public HoaDon()
        {
            InitializeComponent();
        }

        private bool? isUpdateHD = null;
        private bool? isUpdateCTSP = null;
        private bool? isUpdateCTDV = null;
        private DataTable tblHD;
        private DataTable tblCTSP;
        private DataTable tblCTDV;
        private string keyHD { get; set; } 
        private int index {  get; set; }

        private void HoaDon_Load(object sender, EventArgs e)
        {
            

            Functions.FillCombo("SELECT MA_NV, HOTEN_NV FROM NHANVIEN", cboNguoiLap, "MA_NV", "HOTEN_NV");
            Functions.FillCombo("SELECT MA_SP, TEN_SP FROM SANPHAM", cboSP, "MA_SP", "TEN_SP");
            Functions.FillCombo("SELECT MA_DV, TEN_DV FROM DICHVU", cboDV, "MA_DV", "TEN_DV");
            LoadDataGridViewHD("SELECT HOADON.MA_HD, HOADON.SDT_KH, HOTEN_KH, HOADON.MA_NV, HOTEN_NV, SOLUONG_TC, NGAYLAP, NGAYNHAN, NGAYTRA, TONGNGAY, TONGTIEN_HD, TIENCOC,KHAUTRU, CHIPHIPHATSINH,TIENCONLAI, GHICHU_HD FROM HOADON INNER JOIN KHACHHANG ON KHACHHANG.SDT_KH = HOADON.SDT_KH INNER JOIN NHANVIEN ON HOADON.MA_NV = NHANVIEN.MA_NV ORDER BY NGAYLAP DESC");
            AllowInputHD(false);
        }

        private void AllowInputHD(bool control)
        {
            txtSDT.Enabled = control;
            txtKH.Enabled = control;
            cboNguoiLap.Enabled = control;
            dtpNgayLap.Enabled = control;
            numSLTC.Enabled = control;
            dtpNgayTra.Enabled = control;                    
            txtTienCoc.Enabled = control;
            txtPhatSinh.Enabled = control;
            txtKhauTru.Enabled = control;          
            txtGhiChu.Enabled = control;

        }

        private void AllowInputCTSP(bool control)
        {
            cboTC_SP.Enabled = control;
            cboSP.Enabled = control;
            txtGiaSP.Enabled = control;
            numericSL_SP.Enabled = control;
        }

        private void AllowInputCTDV(bool control)
        {
            cboTC_DV.Enabled = control;
            cboDV.Enabled = control;
            txtGiaDV.Enabled = control;
            numericSL_DV.Enabled = control;
        }


        private void LoadDataGridViewHD(string query)
        {
            tblHD = Functions.ReadData(query);
            for (int i = 0; i < dgvHD.ColumnCount; i++)
                dgvHD.Columns[i].DataPropertyName = tblHD.Columns[i].ColumnName;
            dgvHD.Columns[6].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvHD.Columns[7].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvHD.Columns[8].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvHD.DataSource = tblHD;

        }



        private bool CheckValueHD()
        {
            if (txtSDT.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cboNguoiLap.SelectedIndex < 0)
            {
                MessageBox.Show("Bạn phải chọn người lập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private bool CheckValueCTSP()
        {

            if (cboTC_SP.SelectedIndex < 0)
            {
                MessageBox.Show("Bạn phải chọn thú cưng sử dụng sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cboSP.SelectedIndex < 0)
            {
                MessageBox.Show("Bạn phải chọn sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (numericSL_SP.Value <= 0)
            {
                MessageBox.Show("Bạn phải chọn số lượng sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }


            return true;
        }

        private bool CheckValueCTDV()
        {
            if (cboTC_DV.SelectedIndex < 0)
            {
                MessageBox.Show("Bạn phải chọn thú cưng sử dụng dịch vụ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cboDV.SelectedIndex < 0)
            {
                MessageBox.Show("Bạn phải chọn dịch vụ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (numericSL_DV.Value <= 0)
            {
                MessageBox.Show("Bạn phải chọn số lượng dịch vụ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }



        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
            if (txtSDT.Text.Length == 10)
            {
                txtKH.Text = Functions.getValueByKey($"SELECT HOTEN_KH FROM KHACHHANG WHERE SDT_KH ='{txtSDT.Text}'");
                Functions.FillCombo($"SELECT MA_TC, TEN_TC FROM THUCUNG  WHERE SDT_KH='{txtSDT.Text}'", cboTC_SP, "MA_TC", "TEN_TC");
                Functions.FillCombo($"SELECT MA_TC, TEN_TC FROM THUCUNG  WHERE SDT_KH='{txtSDT.Text}'", cboTC_DV, "MA_TC", "TEN_TC");
            }
        }

        private void btnThemHD_Click(object sender, EventArgs e)
        {
            btnThemHD.Enabled = false;
            dgvHD.Enabled = false;
            btnBoQuaHD.Enabled = true;
            keyHD = Functions.createKey("HD_");

            for (int i = 0; i < dgvCT_SP.RowCount; i++)
            {
                dgvCT_SP.Rows.RemoveAt(i);
            }
            for (int i = 0; i < dgvCT_DV.RowCount; i++)
            {
                dgvCT_DV.Rows.RemoveAt(i);
            }
            btnLuu.Enabled = true;
            isUpdateHD = false;
            AllowInputHD(true);
            AllowInputCTSP(true);
            AllowInputCTDV(true);
            DisableControl(true, false, false);
            btnThem_SP.Enabled = true;
            btnThem_DV.Enabled = true;
            RsValueHD();
            RsValueCTSP();
            RsValueCTDV();
        }

        private void DisableControl(bool btnHD, bool btnCTSP, bool btnCTDV)
        {
            //HD
            dgvHD.Enabled = btnHD;
            btnThemHD.Enabled = btnHD;
            btnXoaHD.Enabled = false;
            btnSuaHD.Enabled = false;
            btnBoQuaHD.Enabled = false;

            //CT SP
            btnThem_SP.Enabled = btnCTSP;
            dgvCT_SP.Enabled = btnCTSP;
            
            btnXoa_SP.Enabled = false;
            btnBoQua_SP.Enabled = false;

            //CT DV
            btnThem_DV.Enabled = btnCTDV;
            dgvCT_DV.Enabled = btnCTDV;
            
            btnXoa_DV.Enabled = false;
            btnBoQua_DV.Enabled = false;
        }

        private void RsValueHD()
        {
            txtSDT.Clear();
            txtKH.Clear();
            cboNguoiLap.SelectedIndex = -1;
            numSLTC.Value = 0;
            dtpNgayLap.Value = DateTime.Now;
            dtpNgayNhan.Value = DateTime.Now;
            dtpNgayTra.Value = DateTime.Now;
            txtTongTien.Text="0";
            txtTongNgay.Text = "0";
            txtPhatSinh.Text = "0";
            txtTienCoc.Text = "0";
            txtConLai.Text = "0";
            txtGhiChu.Text = "";

        }

        private void RsValueCTSP()
        {
            cboTC_SP.SelectedIndex = -1;
            cboSP.SelectedIndex = -1;
            txtGiaSP.Clear();
            numericSL_SP.Value = 0;
            
        }
        private void RsValueCTDV()
        {
            cboTC_DV.SelectedIndex = -1;
            cboDV.SelectedIndex = -1;
            txtGiaDV.Clear();
            numericSL_DV.Value = 0;
        }


        private void DisplayValueHD()
        {
            if (dgvHD.SelectedRows.Count > 0)
            {

                dtpNgayTra.Value = DateTime.Now;
                txtSDT.Text = dgvHD.SelectedCells[1].Value.ToString();
                txtKH.Text = dgvHD.SelectedCells[2].Value.ToString();
                cboNguoiLap.SelectedValue = dgvHD.SelectedCells[3].Value;
                numSLTC.Value = Convert.ToInt16(dgvHD.SelectedCells[5].Value);
                dtpNgayLap.Value = Convert.ToDateTime(dgvHD.SelectedCells[6].Value);
                dtpNgayNhan.Value = Convert.ToDateTime(dgvHD.SelectedCells[7].Value);
                dtpNgayTra.Value = Convert.ToDateTime(dgvHD.SelectedCells[8].Value);
                txtTongNgay.Text = dgvHD.SelectedCells[9].Value.ToString();
                txtTongTien.Text = dgvHD.SelectedCells[10].Value.ToString();
                txtTienCoc.Text = dgvHD.SelectedCells[11].Value.ToString();
                txtKhauTru.Text = dgvHD.SelectedCells[12].Value.ToString();
                txtPhatSinh.Text = dgvHD.SelectedCells[13].Value.ToString();
                txtConLai.Text = dgvHD.SelectedCells[14].Value.ToString();
                txtGhiChu.Text = dgvHD.SelectedCells[15].Value.ToString();

            }
            else
            {
                RsValueHD();

            }
        }

        private void DisplayValueCTSP()
        {
            if (dgvCT_SP.Rows.Count > 0)
            {
                cboTC_SP.SelectedValue = dgvCT_SP.SelectedCells[1].Value;
                cboSP.SelectedValue = dgvCT_SP.SelectedCells[3].Value;
                txtGiaSP.Text = dgvCT_SP.SelectedCells[5].Value.ToString();
                numericSL_SP.Value = Convert.ToInt16(dgvCT_SP.SelectedCells[6].Value);
            }
        }

        private void DisplayValueCTDV()
        {
           if(dgvCT_DV.Rows.Count > 0)
            {
                cboTC_DV.SelectedValue = dgvCT_DV.SelectedCells[1].Value;
                cboDV.SelectedValue = dgvCT_DV.SelectedCells[3].Value;
                txtGiaDV.Text = dgvCT_DV.SelectedCells[5].Value.ToString();
                numericSL_DV.Value = Convert.ToInt16(dgvCT_DV.SelectedCells[6].Value);
            }
        }

        private void LoadDataGridViewCTSP(string query)
        {
            tblCTSP = Functions.ReadData(query);
            for (int i = 0; i < dgvCT_SP.ColumnCount; i++)
                dgvCT_SP.Columns[i].DataPropertyName = tblCTSP.Columns[i].ColumnName;
            dgvCT_SP.DataSource = tblCTSP;

        }

        private void LoadDataGridViewCTDV(string query)
        {
            tblCTDV = Functions.ReadData(query);
            for (int i = 0; i < dgvCT_DV.ColumnCount; i++)
                dgvCT_DV.Columns[i].DataPropertyName = tblCTDV.Columns[i].ColumnName;
            dgvCT_DV.DataSource = tblCTDV;

        }

        private bool KiemTraNgay()
        {
            if (dtpNgayNhan != null && dtpNgayTra.Value != null)
            {
               
                if (dtpNgayTra.Value.Date < dtpNgayNhan.Value.Date)
                {
                    MessageBox.Show("Ngày trả không được nhỏ hơn ngày nhận", "Quản Lý Thú Cưng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dtpNgayTra.Value = DateTime.Now;
                    return false;
                }
            }
            else
            {
                return false;
            }
            return true;

        }

        private void dgvHD_Click(object sender, EventArgs e)
        {
            keyHD = dgvHD.SelectedCells[0].Value.ToString();
            index = dgvHD.CurrentRow.Index;
           
            if (dgvHD.SelectedRows.Count > 0)
            {
                LoadDataGridViewCTSP($"SELECT CTHD_SP.MA_HD, CTHD_SP.MA_TC, TEN_TC, CTHD_SP.MA_SP, TEN_SP, GIA_SP, SL_CTSP, SL_CTSP*GIA_SP AS THANHTIEN_SP FROM CTHD_SP INNER JOIN THUCUNG ON CTHD_SP.MA_TC = THUCUNG.MA_TC INNER JOIN SANPHAM ON SANPHAM.MA_SP = CTHD_SP.MA_SP INNER JOIN GIASP ON GIASP.MA_SP = CTHD_SP.MA_SP WHERE CTHD_SP.MA_HD= '{dgvHD.SelectedCells[0].Value}'");
                LoadDataGridViewCTDV($"SELECT CTHD_DV.MA_HD, CTHD_DV.MA_TC, TEN_TC, CTHD_DV.MA_DV, TEN_DV, GIA_DV, SL_CTDV, SL_CTDV*GIA_DV AS THANHTIEN_DV FROM CTHD_DV INNER JOIN THUCUNG ON CTHD_DV.MA_TC = THUCUNG.MA_TC INNER JOIN DICHVU ON DICHVU.MA_DV = CTHD_DV.MA_DV INNER JOIN GIADV ON GIADV.MA_DV = CTHD_DV.MA_DV WHERE CTHD_DV.MA_HD= '{dgvHD.SelectedCells[0].Value}'");

                DisplayValueHD();
                DisplayValueCTSP();
                DisplayValueCTDV();
                AllowInputHD(false);
                dgvCT_SP.Enabled = false;
                dgvCT_DV.Enabled = false;
                btnThemHD.Enabled = false;
                btnSuaHD.Enabled = true;
                btnXoaHD.Enabled = true;
                btnIn.Enabled = true;
                btnBoQuaHD.Enabled = true;
                btnThem_SP.Enabled = true;
                btnThem_DV.Enabled = true;

            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (dgvCT_SP.Rows.Count <= 0 && dgvCT_DV.Rows.Count <= 0)
            {
                MessageBox.Show("Bạn phải nhập chi tiết!");
                return;
            }
            string keyPN = "";
            if (isUpdateHD == false)
            {
                if (CheckValueHD() && CheckValueCTSP() && CheckValueCTDV())
                {
                    keyPN = Functions.createKey("HD_");
                    Functions.runSql($"INSERT INTO HOADON(MA_HD, MA_NV, SDT_KH, MACN, SOLUONG_TC, NGAYLAP, NGAYNHAN, NGAYTRA, TONGNGAY, TONGTIEN_HD, TIENCOC, KHAUTRU, CHIPHIPHATSINH, TIENCONLAI, GHICHU_HD) VALUES" +
                                     $"('{keyHD}',N'{cboNguoiLap.SelectedValue}', '{txtSDT.Text.Trim()}','{Functions.maCN}', '{numSLTC.Value}', '{dtpNgayLap.Value}','{dtpNgayNhan.Value}', '{dtpNgayTra.Value}', '{txtTongNgay.Text.Trim()}', '{txtTongTien.Text.Trim()}', '{txtTienCoc.Text.Trim()}', '{txtKhauTru.Text.Trim()}', '{txtPhatSinh.Text.Trim()}', '{txtConLai.Text.Trim()}', N'{txtGhiChu.Text.Trim()}' )");
                    Functions.runSql($"INSERT INTO CTHD_SP(MA_HD, MA_SP, MA_TC, SL_CTSP) VALUES ('{keyHD}', '{cboSP.SelectedValue}', '{cboTC_SP.SelectedValue}', '{numericSL_SP.Value}') ");
                    Functions.runSql($"INSERT INTO CTHD_DV(MA_HD, MA_TC, MA_DV, SL_CTDV) VALUES ('{keyHD}', '{cboTC_DV.SelectedValue}','{cboDV.SelectedValue}', '{numericSL_DV.Value}') ");

                }
            }
            else
            {
                keyPN = dgvHD.SelectedCells[0].Value.ToString();
                if (isUpdateHD == true && CheckValueHD())
                {
                    Functions.runSql($"UPDATE HOADON SET MA_NV = '{cboNguoiLap.SelectedValue}', SDT_KH = '{txtSDT.Text.Trim()}', SOLUONG_TC= '{numSLTC.Value}', NGAYLAP = '{dtpNgayLap.Value}', NGAYNHAN='{dtpNgayNhan.Value}', NGAYTRA ='{dtpNgayTra.Value}', TIENCOC='{txtTienCoc.Text.Trim()}', KHAUTRU='{txtKhauTru.Text.Trim()}', CHIPHIPHATSINH='{txtPhatSinh.Text.Trim()}', TONGNGAY='{txtTongNgay.Text.Trim()}', TONGTIEN_HD='{txtTongTien.Text.Trim()}', TIENCONLAI='{txtConLai.Text.Trim()}', GHICHU_HD=N'{txtGhiChu.Text.Trim()}' WHERE MA_HD= '{keyHD}' ");
                   

                }

                if (dgvCT_SP.Rows.Count > 0)
                {
                    if(isUpdateCTSP == true && CheckValueCTSP())
                    {
                        Functions.runSql($"UPDATE CTHD_SP SET MA_SP='{cboSP.SelectedValue}', MA_TC='{cboTC_SP.SelectedValue}', SL_CTSP='{numericSL_SP.Value}' WHERE MA_HD='{dgvCT_SP.SelectedRows[0].Cells[0].Value}' AND MA_TC='{dgvCT_SP.SelectedRows[0].Cells[1].Value}'  AND MA_SP='{dgvCT_SP.SelectedRows[0].Cells[3].Value}' ");
                    }
                }

                if (dgvCT_DV.Rows.Count > 0)
                {
                    if (isUpdateCTDV == true && CheckValueCTDV())
                    {
                        Functions.runSql($"UPDATE CTHD_DV SET MA_TC='{cboTC_DV.SelectedValue}', MA_DV='{cboDV.SelectedValue}', SL_CTDV='{numericSL_DV.Value}' WHERE MA_HD='{dgvCT_DV.SelectedRows[0].Cells[0].Value}' AND MA_TC='{dgvCT_DV.SelectedRows[0].Cells[1].Value}'  AND MA_DV='{dgvCT_DV.SelectedRows[0].Cells[3].Value}' ");
                    }
                }
            }
            DisableControl(true, true, true);
            LoadDataGridViewCTSP($"SELECT CTHD_SP.MA_HD, CTHD_SP.MA_TC, TEN_TC, CTHD_SP.MA_SP, TEN_SP, GIA_SP, SL_CTSP, SL_CTSP*GIA_SP AS THANHTIEN_SP FROM CTHD_SP INNER JOIN THUCUNG ON CTHD_SP.MA_TC = THUCUNG.MA_TC INNER JOIN SANPHAM ON SANPHAM.MA_SP = CTHD_SP.MA_SP INNER JOIN GIASP ON GIASP.MA_SP = CTHD_SP.MA_SP WHERE CTHD_SP.MA_HD= '{keyHD}'");
            LoadDataGridViewCTDV($"SELECT CTHD_DV.MA_HD, CTHD_DV.MA_TC, TEN_TC, CTHD_DV.MA_DV, TEN_DV, GIA_DV, SL_CTDV, SL_CTDV*GIA_DV AS THANHTIEN_DV FROM CTHD_DV INNER JOIN THUCUNG ON CTHD_DV.MA_TC = THUCUNG.MA_TC INNER JOIN DICHVU ON DICHVU.MA_DV = CTHD_DV.MA_DV INNER JOIN GIADV ON GIADV.MA_DV = CTHD_DV.MA_DV WHERE CTHD_DV.MA_HD= '{keyHD}'");
            TotalAmount();
            Functions.runSql($"UPDATE HOADON SET TONGTIEN_HD = {txtTongTien.Text} WHERE MA_HD = '{dgvHD.SelectedCells[0].Value}'");
            TongTienConLai();
            Functions.runSql($"UPDATE HOADON SET TIENCONLAI = {txtConLai.Text.Trim()} WHERE MA_HD = '{keyHD}'");
            LoadDataGridViewHD("SELECT HOADON.MA_HD, HOADON.SDT_KH, HOTEN_KH, HOADON.MA_NV, HOTEN_NV, SOLUONG_TC, NGAYLAP, NGAYNHAN, NGAYTRA, TONGNGAY, TONGTIEN_HD, TIENCOC,KHAUTRU, CHIPHIPHATSINH,TIENCONLAI, GHICHU_HD FROM HOADON INNER JOIN KHACHHANG ON KHACHHANG.SDT_KH = HOADON.SDT_KH INNER JOIN NHANVIEN ON HOADON.MA_NV = NHANVIEN.MA_NV ORDER BY NGAYLAP DESC");
            isUpdateHD = null;
            isUpdateCTSP = null;
            isUpdateCTDV = null;
            btnThem_SP.Enabled = true;
            btnThem_DV.Enabled = true;
            btnBoQuaHD.Enabled = true;
            btnLuu.Enabled = false;
            btnSuaHD.Enabled = false;
            btnXoaHD.Enabled = false;
            btnThemHD.Enabled = true;
            btnIn.Enabled = false;
            dgvCT_SP.Enabled = false;
            dgvCT_DV.Enabled = false;
            MessageBox.Show("Cập nhật thành công", "Quản Lý Thú Cưng", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void TotalAmount()
         {
            if (dgvCT_SP.RowCount < 0 && dgvCT_DV.Rows.Count < 0)
            {
                    txtTongTien.Text = "0";
                return;
            }
            long tmpSP = 0, tmpDV = 0;

             if (dgvCT_SP.Rows.Count > 0)
             {
                 for (int i = 0; i < dgvCT_SP.Rows.Count; i++)
                 {

                     tmpSP += Convert.ToInt64(dgvCT_SP.Rows[i].Cells[7].Value);
                 }   
              
            }
             if (dgvCT_DV.Rows.Count > 0)
            {
                for (int i = 0; i < dgvCT_DV.Rows.Count; i++)
                {

                    tmpDV += Convert.ToInt64(dgvCT_DV.Rows[i].Cells[7].Value);
                }
            }
            txtTongTien.Text = (tmpSP + tmpDV).ToString();
        }


        private void TongTienConLai()
        {
            txtConLai.Text=((Convert.ToDouble(txtTongTien.Text)+Convert.ToDouble(txtPhatSinh.Text)) + (100000*Convert.ToInt16(txtTongNgay.Text) *Convert.ToInt16(numSLTC.Value)) -(Convert.ToDouble(txtTienCoc.Text)+Convert.ToDouble(txtKhauTru.Text))).ToString();
        }
        

       

        private void btnThem_SP_Click(object sender, EventArgs e)
        {
            if (CheckValueCTSP())
            {
                if (isUpdateHD == false)
                {
                    keyHD = Functions.createKey("HD_");
                    if (CheckValueHD())
                    {
                        Functions.runSql($"INSERT INTO HOADON(MA_HD, MA_NV, SDT_KH, MACN, SOLUONG_TC, NGAYLAP, NGAYNHAN, NGAYTRA, TONGNGAY, TONGTIEN_HD, TIENCOC, KHAUTRU, CHIPHIPHATSINH, TIENCONLAI, GHICHU_HD) VALUES" +
                                         $"('{keyHD}',N'{cboNguoiLap.SelectedValue}', '{txtSDT.Text.Trim()}','{Functions.maCN}', '{numSLTC.Value}', '{dtpNgayLap.Value}','{dtpNgayNhan.Value}', '{dtpNgayTra.Value}', '{txtTongNgay.Text.Trim()}', '{txtTongTien.Text.Trim()}', '{txtTienCoc.Text.Trim()}', '{txtKhauTru.Text.Trim()}', '{txtPhatSinh.Text.Trim()}', '{txtConLai.Text.Trim()}', N'{txtGhiChu.Text.Trim()}' )");
                        isUpdateHD = null;
                    }
                    else
                    {
                        return;
                    }
                }
               
                Functions.runSql($"INSERT INTO CTHD_SP(MA_HD, MA_SP, MA_TC, SL_CTSP) VALUES ('{keyHD}', '{cboSP.SelectedValue}', '{cboTC_SP.SelectedValue}', '{numericSL_SP.Value}') ");

                LoadDataGridViewCTSP($"SELECT CTHD_SP.MA_HD, CTHD_SP.MA_TC, TEN_TC, CTHD_SP.MA_SP, TEN_SP, GIA_SP, SL_CTSP, SL_CTSP*GIA_SP AS THANHTIEN_SP FROM CTHD_SP INNER JOIN THUCUNG ON CTHD_SP.MA_TC = THUCUNG.MA_TC INNER JOIN SANPHAM ON SANPHAM.MA_SP = CTHD_SP.MA_SP INNER JOIN GIASP ON GIASP.MA_SP = CTHD_SP.MA_SP WHERE CTHD_SP.MA_HD= '{keyHD}'");
                TotalAmount();
                
                Functions.runSql($"UPDATE HOADON SET TONGTIEN_HD = {txtTongTien.Text.Trim()} WHERE MA_HD = '{keyHD}'");
                TongTienConLai();
                Functions.runSql($"UPDATE HOADON SET TIENCONLAI = {txtConLai.Text.Trim()} WHERE MA_HD = '{keyHD}'");
                LoadDataGridViewHD("SELECT HOADON.MA_HD, HOADON.SDT_KH, HOTEN_KH, HOADON.MA_NV, HOTEN_NV, SOLUONG_TC, NGAYLAP, NGAYNHAN, NGAYTRA, TONGNGAY, TONGTIEN_HD, TIENCOC,KHAUTRU, CHIPHIPHATSINH,TIENCONLAI, GHICHU_HD FROM HOADON INNER JOIN KHACHHANG ON KHACHHANG.SDT_KH = HOADON.SDT_KH INNER JOIN NHANVIEN ON HOADON.MA_NV = NHANVIEN.MA_NV ORDER BY NGAYLAP DESC");
                dgvHD.Rows[0].Selected = false;
                dgvHD.Rows[index].Selected = true;
                
                RsValueCTSP();
            }
        }




        private void cboSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtGiaSP.Text = Functions.getValueByKey($"SELECT TOP 1 GIA_SP FROM GIASP WHERE MA_SP = '{cboSP.SelectedValue}' AND NGAYCAPNHAT_SP <= '{dtpNgayLap.Value}' ORDER BY NGAYCAPNHAT_SP DESC");
            
        }

        private void cboDV_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtGiaDV.Text = Functions.getValueByKey($"SELECT TOP 1 GIA_DV FROM GIADV WHERE MA_DV = '{cboDV.SelectedValue}' AND NGAYCAPNHAT_DV <= '{dtpNgayLap.Value}' ORDER BY NGAYCAPNHAT_DV DESC");
           
        }

        private void dtpNgayNhan_ValueChanged(object sender, EventArgs e)
        {
            KiemTraNgay();
            int date = Convert.ToInt32((Convert.ToDateTime(dtpNgayTra.Value.ToShortDateString()) - Convert.ToDateTime(dtpNgayNhan.Value.ToShortDateString())).Days) + 1;
            txtTongNgay.Text = date.ToString();
        }

        private void dtpNgayTra_ValueChanged(object sender, EventArgs e)
        {
            KiemTraNgay();
            int date = Convert.ToInt32((Convert.ToDateTime(dtpNgayTra.Value.ToShortDateString()) - Convert.ToDateTime(dtpNgayNhan.Value.ToShortDateString())).Days) + 1;
            txtTongNgay.Text = date.ToString();
        }

        private void btnBoQuaHD_Click(object sender, EventArgs e)
        {
            dgvHD.Enabled = true;
            btnThemHD.Enabled = true;
            btnBoQuaHD.Enabled = false;
            btnSuaHD.Enabled = false;
            btnXoaHD.Enabled = false;
            btnThem_SP.Enabled = false;
            btnThem_DV.Enabled = false;
            btnLuu.Enabled = false;
            btnIn.Enabled = false;
            DisplayValueHD();
            AllowInputHD(true);
        }

        private void btnThem_DV_Click(object sender, EventArgs e)
        {
            if (CheckValueCTDV())
            {
               
                if (isUpdateHD == false)
                {
                    keyHD = Functions.createKey("HD_");
                    if (CheckValueHD())
                    {
                        Functions.runSql($"INSERT INTO HOADON(MA_HD, MA_NV, SDT_KH, MACN, SOLUONG_TC, NGAYLAP, NGAYNHAN, NGAYTRA, TONGNGAY, TONGTIEN_HD, TIENCOC, KHAUTRU, CHIPHIPHATSINH, TIENCONLAI, GHICHU_HD) VALUES" +
                                         $"('{keyHD}',N'{cboNguoiLap.SelectedValue}', '{txtSDT.Text.Trim()}','{Functions.maCN}', '{numSLTC.Value}', '{dtpNgayLap.Value}','{dtpNgayNhan.Value}', '{dtpNgayTra.Value}', '{txtTongNgay.Text.Trim()}', '{txtTongTien.Text.Trim()}', '{txtTienCoc.Text.Trim()}', '{txtKhauTru.Text.Trim()}', '{txtPhatSinh.Text.Trim()}', '{txtConLai.Text.Trim()}', N'{txtGhiChu.Text.Trim()}' )");
                        isUpdateHD = null;
                    }
                    else
                    {
                        return;
                    }
                }
               
                Functions.runSql($"INSERT INTO CTHD_DV(MA_HD, MA_TC, MA_DV, SL_CTDV) VALUES ('{keyHD}', '{cboTC_DV.SelectedValue}','{cboDV.SelectedValue}', '{numericSL_DV.Value}') ");

                LoadDataGridViewCTDV($"SELECT CTHD_DV.MA_HD, CTHD_DV.MA_TC, TEN_TC, CTHD_DV.MA_DV, TEN_DV, GIA_DV, SL_CTDV, SL_CTDV*GIA_DV AS THANHTIEN_DV FROM CTHD_DV INNER JOIN THUCUNG ON CTHD_DV.MA_TC = THUCUNG.MA_TC INNER JOIN DICHVU ON DICHVU.MA_DV = CTHD_DV.MA_DV INNER JOIN GIADV ON GIADV.MA_DV = CTHD_DV.MA_DV WHERE CTHD_DV.MA_HD= '{keyHD}'");
                
                TotalAmount();
                Functions.runSql($"UPDATE HOADON SET TONGTIEN_HD = {txtTongTien.Text.Trim()} WHERE MA_HD = '{keyHD}'");
                TongTienConLai();
                Functions.runSql($"UPDATE HOADON SET TIENCONLAI = {txtConLai.Text.Trim()} WHERE MA_HD = '{keyHD}'");
                LoadDataGridViewHD("SELECT HOADON.MA_HD, HOADON.SDT_KH, HOTEN_KH, HOADON.MA_NV, HOTEN_NV, SOLUONG_TC, NGAYLAP, NGAYNHAN, NGAYTRA, TONGNGAY, TONGTIEN_HD, TIENCOC,KHAUTRU, CHIPHIPHATSINH,TIENCONLAI, GHICHU_HD FROM HOADON INNER JOIN KHACHHANG ON KHACHHANG.SDT_KH = HOADON.SDT_KH INNER JOIN NHANVIEN ON HOADON.MA_NV = NHANVIEN.MA_NV ORDER BY NGAYLAP DESC");
                dgvHD.Rows[index].Selected = true;
                dgvHD.Rows[0].Selected = false;
                RsValueCTDV();
            }
        }

        

        private void btnXoa_SP_Click(object sender, EventArgs e)
        {
            string mes;
            int rowCount = dgvCT_SP.SelectedRows.Count;
            if (rowCount > 1)
                mes = rowCount + " dòng dữ liệu sẽ bị xóa, bạn chắc muốn xóa các dòng đó không ?";
            else
                mes = "Dòng dữ liệu sẽ bị xóa, bạn có chắc muốn xóa không ?";
            if (MessageBox.Show(mes, "Warnning", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                for (int i = 0; i < rowCount; i++)
                {
                    Functions.runSql($" DELETE CTHD_SP WHERE MA_HD='{dgvCT_SP.SelectedRows[0].Cells[0].Value}' AND MA_TC='{dgvCT_SP.SelectedRows[0].Cells[1].Value}'  AND MA_SP='{dgvCT_SP.SelectedRows[0].Cells[3].Value}' ");
                }

                LoadDataGridViewCTSP($"SELECT CTHD_SP.MA_HD, CTHD_SP.MA_TC, TEN_TC, CTHD_SP.MA_SP, TEN_SP, GIA_SP, SL_CTSP, SL_CTSP*GIA_SP AS THANHTIEN_SP FROM CTHD_SP INNER JOIN THUCUNG ON CTHD_SP.MA_TC = THUCUNG.MA_TC INNER JOIN SANPHAM ON SANPHAM.MA_SP = CTHD_SP.MA_SP INNER JOIN GIASP ON GIASP.MA_SP = CTHD_SP.MA_SP WHERE CTHD_SP.MA_HD = '{dgvHD.SelectedCells[0].Value}'");
                TotalAmount();
                Functions.runSql($"UPDATE HOADON SET TONGTIEN_HD = {txtTongTien.Text} WHERE MA_HD = '{dgvHD.SelectedCells[0].Value}'");

                LoadDataGridViewHD("SELECT HOADON.MA_HD, HOADON.SDT_KH, HOTEN_KH, HOADON.MA_NV, HOTEN_NV, SOLUONG_TC, NGAYLAP, NGAYNHAN, NGAYTRA, TONGNGAY, TONGTIEN_HD, TIENCOC,KHAUTRU, CHIPHIPHATSINH,TIENCONLAI, GHICHU_HD FROM HOADON INNER JOIN KHACHHANG ON KHACHHANG.SDT_KH = HOADON.SDT_KH INNER JOIN NHANVIEN ON HOADON.MA_NV = NHANVIEN.MA_NV ORDER BY NGAYLAP DESC");

            }

            btnBoQuaHD.Enabled = true;
            btnSuaHD.Enabled = false;
            btnXoaHD.Enabled = false;
            btnThemHD.Enabled = true;
            DisplayValueCTSP();
        }

        private void btnSuaHD_Click(object sender, EventArgs e)
        {
            AllowInputHD(true);
            AllowInputCTSP(true);
            AllowInputCTDV(true);
            keyHD = dgvHD.SelectedCells[0].Value.ToString();
            btnIn.Enabled = false;
            dgvHD.Enabled = false;
            dgvCT_SP.Enabled = true;
            dgvCT_DV.Enabled = true;
            isUpdateHD = true;
            isUpdateCTSP = true;
            isUpdateCTDV = true;
            btnBoQuaHD.Enabled = true;
            btnLuu.Enabled = true;
            btnThem_SP.Enabled = true;
            btnThemHD.Enabled = false;
            btnSuaHD.Enabled = false;
            btnXoaHD.Enabled = false;
            btnBoQua_SP.Enabled = true;
            btnBoQua_DV.Enabled = true;
        }

        private void dgvCT_SP_Click(object sender, EventArgs e)
        {
            if (tblCTSP.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                DisplayValueCTSP();
                btnBoQua_SP.Enabled = true;
                btnLuu.Enabled = true;
               
                btnThem_SP.Enabled = false;
                btnXoa_SP.Enabled = true;
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            Functions.maHD = dgvHD.SelectedCells[0].Value.ToString();
            frmReportHD frmReportHD = new frmReportHD();
            frmReportHD.ShowDialog();
        }

        private void btn_ThongKe_Click(object sender, EventArgs e)
        {
            ThongKeDoanhThu ThongKeDoanhThu = new ThongKeDoanhThu();
            ThongKeDoanhThu.ShowDialog();
        }

        private void btnXoaHD_Click(object sender, EventArgs e)
        {
            string mes;
            int rowCount = dgvHD.SelectedRows.Count;
            if (rowCount > 1)
                mes = rowCount + " dòng dữ liệu sẽ bị xóa, bạn chắc muốn xóa các dòng đó không ?";
            else
                mes = "Dòng dữ liệu sẽ bị xóa, bạn có chắc muốn xóa không ?";
            if (MessageBox.Show(mes, "Warnning", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                for (int i = 0; i < rowCount; i++)
                {
                    Functions.runSql($"DELETE CTHD_SP WHERE MA_HD = '{dgvHD.SelectedRows[i].Cells[0].Value}' ");
                    Functions.runSql($"DELETE CTHD_DV WHERE MA_HD = '{dgvHD.SelectedRows[i].Cells[0].Value}' ");
                    Functions.runSql($"DELETE HOADON WHERE MA_HD = '{dgvHD.SelectedRows[i].Cells[0].Value}' ");

                }
                LoadDataGridViewHD("SELECT HOADON.MA_HD, HOADON.SDT_KH, HOTEN_KH, HOADON.MA_NV, HOTEN_NV, SOLUONG_TC, NGAYLAP, NGAYNHAN, NGAYTRA, TONGNGAY, TONGTIEN_HD, TIENCOC,KHAUTRU, CHIPHIPHATSINH,TIENCONLAI, GHICHU_HD FROM HOADON INNER JOIN KHACHHANG ON KHACHHANG.SDT_KH = HOADON.SDT_KH INNER JOIN NHANVIEN ON HOADON.MA_NV = NHANVIEN.MA_NV ORDER BY NGAYLAP DESC");
                AllowInputHD(false);
                if (dgvHD.Rows.Count > 0)
                {
                    LoadDataGridViewCTSP($"SELECT CTHD_SP.MA_HD, CTHD_SP.MA_TC, TEN_TC, CTHD_SP.MA_SP, TEN_SP, GIA_SP, SL_CTSP, SL_CTSP*GIA_SP AS THANHTIEN_SP FROM CTHD_SP INNER JOIN THUCUNG ON CTHD_SP.MA_TC = THUCUNG.MA_TC INNER JOIN SANPHAM ON SANPHAM.MA_SP = CTHD_SP.MA_SP INNER JOIN GIASP ON GIASP.MA_SP = CTHD_SP.MA_SP WHERE CTHD_SP.MA_HD = '{dgvHD.SelectedCells[0].Value}'");
                    LoadDataGridViewCTDV($"SELECT CTHD_DV.MA_HD, CTHD_DV.MA_TC, TEN_TC, CTHD_DV.MA_DV, TEN_DV, GIA_DV, SL_CTDV, SL_CTDV*GIA_DV AS THANHTIEN_DV FROM CTHD_DV INNER JOIN THUCUNG ON CTHD_DV.MA_TC = THUCUNG.MA_TC INNER JOIN DICHVU ON DICHVU.MA_DV = CTHD_DV.MA_DV INNER JOIN GIADV ON GIADV.MA_DV = CTHD_DV.MA_DV WHERE CTHD_DV.MA_HD= '{dgvHD.SelectedCells[0].Value}'");

                }
                else
                {
                    LoadDataGridViewCTSP($"SELECT CTHD_SP.MA_HD, CTHD_SP.MA_TC, TEN_TC, CTHD_SP.MA_SP, TEN_SP, GIA_SP, SL_CTSP, SL_CTSP*GIA_SP AS THANHTIEN_SP FROM CTHD_SP INNER JOIN THUCUNG ON CTHD_SP.MA_TC = THUCUNG.MA_TC INNER JOIN SANPHAM ON SANPHAM.MA_SP = CTHD_SP.MA_SP INNER JOIN GIASP ON GIASP.MA_SP = CTHD_SP.MA_SP WHERE CTHD_SP.MA_HD = ''");
                    LoadDataGridViewCTDV($"SELECT CTHD_DV.MA_HD, CTHD_DV.MA_TC, TEN_TC, CTHD_DV.MA_DV, TEN_DV, GIA_DV, SL_CTDV, SL_CTDV*GIA_DV AS THANHTIEN_DV FROM CTHD_DV INNER JOIN THUCUNG ON CTHD_DV.MA_TC = THUCUNG.MA_TC INNER JOIN DICHVU ON DICHVU.MA_DV = CTHD_DV.MA_DV INNER JOIN GIADV ON GIADV.MA_DV = CTHD_DV.MA_DV WHERE CTHD_DV.MA_HD= ''");
                }
            }

            btnBoQuaHD.Enabled = false;
            btnSuaHD.Enabled = false;
            btnXoaHD.Enabled = false;
            btnThemHD.Enabled = true;
           // dgvCT_SP.Refresh();
            //dgvCT_SP.Refresh();
            DisplayValueHD();
        }

        private void dgvCT_DV_Click(object sender, EventArgs e)
        {
            if (tblCTDV.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                DisplayValueCTDV();
                btnBoQua_DV.Enabled = true;
                btnLuu.Enabled = true;
               
                btnThem_DV.Enabled = false;
                btnXoa_DV.Enabled = true;
            }
        }

        private void btnXoa_DV_Click(object sender, EventArgs e)
        {
            string mes;
            int rowCount = dgvCT_DV.SelectedRows.Count;
            if (rowCount > 1)
                mes = rowCount + " dòng dữ liệu sẽ bị xóa, bạn chắc muốn xóa các dòng đó không ?";
            else
                mes = "Dòng dữ liệu sẽ bị xóa, bạn có chắc muốn xóa không ?";
            if (MessageBox.Show(mes, "Warnning", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                for (int i = 0; i < rowCount; i++)
                {
                    Functions.runSql($" DELETE CTHD_DV WHERE MA_HD='{dgvCT_DV.SelectedRows[0].Cells[0].Value}' AND MA_TC='{dgvCT_DV.SelectedRows[0].Cells[1].Value}'  AND MA_DV='{dgvCT_DV.SelectedRows[0].Cells[3].Value}' ");
                }

                LoadDataGridViewCTDV($"SELECT CTHD_DV.MA_HD, CTHD_DV.MA_TC, TEN_TC, CTHD_DV.MA_DV, TEN_DV, GIA_DV, SL_CTDV, SL_CTDV*GIA_DV AS THANHTIEN_DV FROM CTHD_DV INNER JOIN THUCUNG ON CTHD_DV.MA_TC = THUCUNG.MA_TC INNER JOIN DICHVU ON DICHVU.MA_DV = CTHD_DV.MA_DV INNER JOIN GIADV ON GIADV.MA_DV = CTHD_DV.MA_DV WHERE CTHD_DV.MA_HD= '{dgvHD.SelectedCells[0].Value}'");
                TotalAmount();
                Functions.runSql($"UPDATE HOADON SET TONGTIEN_HD = {txtTongTien.Text} WHERE MA_HD = '{dgvHD.SelectedCells[0].Value}'");

                LoadDataGridViewHD("SELECT HOADON.MA_HD, HOADON.SDT_KH, HOTEN_KH, HOADON.MA_NV, HOTEN_NV, SOLUONG_TC, NGAYLAP, NGAYNHAN, NGAYTRA, TONGNGAY, TONGTIEN_HD, TIENCOC,KHAUTRU, CHIPHIPHATSINH,TIENCONLAI, GHICHU_HD FROM HOADON INNER JOIN KHACHHANG ON KHACHHANG.SDT_KH = HOADON.SDT_KH INNER JOIN NHANVIEN ON HOADON.MA_NV = NHANVIEN.MA_NV ORDER BY NGAYLAP DESC");

            }

            btnBoQuaHD.Enabled = true;
            btnSuaHD.Enabled = false;
            btnXoaHD.Enabled = false;
            btnThemHD.Enabled = true;
            DisplayValueCTDV();
        }

        private void numSLTC_ValueChanged(object sender, EventArgs e)
        {
            
            TongTienConLai();
            Functions.runSql($"UPDATE HOADON SET TIENCONLAI = {txtConLai.Text.Trim()} WHERE MA_HD = '{keyHD}'");
        }
      

        private void txtTongNgay_TextChanged_1(object sender, EventArgs e)
        {
            TongTienConLai();
            Functions.runSql($"UPDATE HOADON SET TIENCONLAI = {txtConLai.Text.Trim()} WHERE MA_HD = '{keyHD}'");
        }

        private void btnBoQua_SP_Click(object sender, EventArgs e)
        {
            AllowInputCTSP(true);
            DisplayValueCTSP();
            btnThem_SP.Enabled = true;
            btnBoQua_SP.Enabled = false;
            btnXoa_SP.Enabled = false;
            btnIn.Enabled = false;

        }

        private void btnBoQua_DV_Click(object sender, EventArgs e)
        {
            AllowInputCTDV(true);
            DisplayValueCTDV();
            btnThem_DV.Enabled = true;
            btnBoQua_DV.Enabled = false;
            btnXoa_DV.Enabled = false;
            btnIn.Enabled = false;

        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            LoadDataGridViewHD($" SELECT HOADON.MA_HD, HOADON.SDT_KH, HOTEN_KH, HOADON.MA_NV, HOTEN_NV, SOLUONG_TC, NGAYLAP, NGAYNHAN, NGAYTRA, TONGNGAY, TONGTIEN_HD, TIENCOC,KHAUTRU, CHIPHIPHATSINH,TIENCONLAI, GHICHU_HD FROM HOADON INNER JOIN KHACHHANG ON KHACHHANG.SDT_KH = HOADON.SDT_KH INNER JOIN NHANVIEN ON HOADON.MA_NV = NHANVIEN.MA_NV  WHERE MA_HD LIKE '%{txtTimKiem.Text.Trim()}%' OR HOADON.SDT_KH LIKE '%{txtTimKiem.Text.Trim()}%' OR HOTEN_KH LIKE N'%{txtTimKiem.Text.Trim()}%' OR HOTEN_NV LIKE N'%{txtTimKiem.Text.Trim()}%' OR SOLUONG_TC LIKE '%{txtTimKiem.Text.Trim()}%'  OR CONVERT(VARCHAR(20), NGAYLAP, 103) LIKE '%{txtTimKiem.Text.Trim()}%' OR CONVERT(VARCHAR(20), NGAYNHAN, 103) LIKE '%{txtTimKiem.Text.Trim()}%' OR CONVERT(VARCHAR(20), NGAYTRA, 103) LIKE '%{txtTimKiem.Text.Trim()}%'  OR TONGNGAY LIKE '%{txtTimKiem.Text.Trim()}%'  OR TONGTIEN_HD LIKE '%{txtTimKiem.Text.Trim()}%'  OR TIENCOC LIKE '%{txtTimKiem.Text.Trim()}%'  OR CHIPHIPHATSINH LIKE '%{txtTimKiem.Text.Trim()}%'  OR KHAUTRU LIKE '%{txtTimKiem.Text.Trim()}%' OR TIENCONLAI LIKE '%{txtTimKiem.Text.Trim()}%'  OR GHICHU_HD LIKE N'%{txtTimKiem.Text.Trim()}%' ORDER BY NGAYLAP DESC");

        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            KhachHang userControl = new KhachHang();

            Form popupForm = new Form();
            popupForm.Text = "Thêm khách hàng";
            popupForm.Controls.Add(userControl);
            popupForm.StartPosition = FormStartPosition.CenterParent;
            popupForm.Width = 950;
            popupForm.Height = 540;
            popupForm.ShowDialog();
        }
    }
 }
