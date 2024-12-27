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
    public partial class SanPham : UserControl
    {
        private DataTable tblSP;
        public static bool control;
        public SanPham()
        {
            InitializeComponent();
        }

        private void SanPham_Load(object sender, EventArgs e)
        {
            //Functions.Connect();
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnQuayLai.Enabled = false;
            dgvSanPham.AllowUserToAddRows = false;
            dgvSanPham.EditMode = DataGridViewEditMode.EditProgrammatically;
            LoadDataGridView("SELECT MA_SP,TEN_SP,SOLUONG_SP, MACN FROM SANPHAM");
            AllowInput(false);
            btnIn.Enabled = true;
            DisplayValueTextbox();
            dgvSanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        public void LoadDataGridView(string query)
        {
            tblSP = Functions.ReadData(query);
            for (int i = 0; i < dgvSanPham.ColumnCount; i++)
                dgvSanPham.Columns[i].DataPropertyName = tblSP.Columns[i].ColumnName;
            dgvSanPham.DataSource = tblSP;
            
        }

        public void RsValue()
        {
            txtMaSP.Text = "";
            txtTenSP.Text = "";
            numericSL.Value = 0;
           
        }

        public void DisplayValueTextbox()
        {
            if (dgvSanPham.Rows.Count > 0)
            {
                txtMaSP.Text = dgvSanPham.SelectedCells[0].Value.ToString();
                txtTenSP.Text = dgvSanPham.SelectedCells[1].Value.ToString();
                numericSL.Value = Convert.ToInt16(dgvSanPham.SelectedCells[2].Value);
               
            }
            else
                RsValue();
        }

        private void AllowInput(bool control)
        {
            txtMaSP.Enabled = control;
            txtTenSP.Enabled = control;
            numericSL.Enabled = control;
            
        }

        private void dgvSanPham_Click(object sender, EventArgs e)
        {
            if (tblSP.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                DisplayValueTextbox();
                AllowInput(false);
                btnQuayLai.Enabled = true;
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnThem.Enabled = false;
                btnXoa.Enabled = true;
            }
        }

        private void txtGiaSP_KeyPress(object sender, KeyPressEventArgs e)
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
            btnThem.Enabled = true;
            btnLuu.Enabled = true;
            btnQuayLai.Enabled = true;
            RsValue();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (control == true)
            {
                if (txtMaSP.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập mã sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaSP.Focus();
                    return;
                }

                if (txtTenSP.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập tên sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenSP.Focus();
                    return;
                }

                

                if (numericSL.Value < 1)
                {
                    MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

               

                else
                {
                    Functions.runSql($"INSERT INTO SANPHAM(MA_SP, MACN,TEN_SP,SOLUONG_SP) VALUES('{txtMaSP.Text.Trim()}', '{Functions.maCN}', N'{txtTenSP.Text.Trim()}', {numericSL.Value})");

                    LoadDataGridView("SELECT MA_SP,TEN_SP,SOLUONG_SP, MACN FROM SANPHAM");
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
                if (tblSP.Rows.Count == 0)
                {
                    MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (txtTenSP.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập tên sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenSP.Focus();
                    return;
                }

                if (numericSL.Value < 1)
                {
                    MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                else
                {
                    if (MessageBox.Show("Thông tin sẽ bị sửa đổi! Bạn có chắc muốn sửa không?", "Warnning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        Functions.runSql($"UPDATE SANPHAM SET  TEN_SP = N'{txtTenSP.Text}', SOLUONG_SP={numericSL.Value}  WHERE MA_SP = '{txtMaSP.Text}'");
                         LoadDataGridView("SELECT MA_SP,TEN_SP,SOLUONG_SP, MACN FROM SANPHAM");
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
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnThem.Enabled = false;
            txtMaSP.Enabled = false;
            btnLuu.Enabled = true;
            control = false;
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
            int rowCount = dgvSanPham.SelectedRows.Count;
            if (rowCount > 1)
                mes = rowCount + " dòng dữ liệu sẽ bị xóa, bạn chắc muốn xóa các dòng đó không ?";
            else
                mes = "Dòng dữ liệu sẽ bị xóa, bạn có chắc muốn xóa không ?";
            if (MessageBox.Show(mes, "Warnning", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                for (int i = 0; i < rowCount; i++)

                {
                    if (String.IsNullOrEmpty(Functions.getValueByKey($"SELECT PHIEUNHAP.MA_PN FROM PHIEUNHAP INNER JOIN CHITIETPHIEUNHAP ON PHIEUNHAP.MA_PN = CHITIETPHIEUNHAP.MA_PN WHERE MA_SP = '{dgvSanPham.SelectedRows[i].Cells[0].Value}'")))
                    {
                        Functions.runSql("DELETE GIASP WHERE MA_SP = '" + dgvSanPham.SelectedRows[i].Cells[0].Value.ToString() + "' ");
                        Functions.runSql(" DELETE SANPHAM WHERE MA_SP = '" + dgvSanPham.SelectedRows[i].Cells[0].Value.ToString() + "' ");
                    }
                        
                    else
                        MessageBox.Show("Không thể xóa do có phiếu nhập của sản phẩm");
                }
                 LoadDataGridView("SELECT MA_SP,TEN_SP,SOLUONG_SP, MACN FROM SANPHAM");
            }
            DisplayValueTextbox();
            btnQuayLai.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = true;
        }

     
        

        private void btnCNGiaDV_Click(object sender, EventArgs e)
        {
           CapNhatGiaSP frmCapNhatGiaSP = new CapNhatGiaSP();
            frmCapNhatGiaSP.ShowDialog();
        }

        private void btn_ThongKe_Click(object sender, EventArgs e)
        {
            ThongKeSanPham frmtksp = new ThongKeSanPham();
            frmtksp.ShowDialog();
        }

        private void txtTimKiem_TextChanged_1(object sender, EventArgs e)
        {
            LoadDataGridView("SELECT MA_SP, TEN_SP, SOLUONG_SP, MACN FROM SANPHAM WHERE MA_SP LIKE '%" + txtTimKiem.Text.Trim() + "%' OR TEN_SP LIKE N'%" + txtTimKiem.Text.Trim() + "%'");
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            frmReportSP frmReportSP = new frmReportSP();
            frmReportSP.ShowDialog();
        }
    }
}
