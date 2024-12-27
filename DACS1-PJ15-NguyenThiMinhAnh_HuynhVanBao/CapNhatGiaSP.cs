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

namespace DACS1_PJ15_NguyenThiMinhAnh_HuynhVanBao
{
    public partial class CapNhatGiaSP : Form
    {
        private DataTable tblCNSP;
        public static bool control;
        public CapNhatGiaSP()
        {
            InitializeComponent();
        }

        private void CapNhatGiaSP_Load(object sender, EventArgs e)
        {
           
            Functions.FillCombo("SELECT MA_SP, TEN_SP FROM SANPHAM", cboTenCNSP, "MA_SP", "TEN_SP");
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnBoQua.Enabled = false;
            dgvCNSanPham.AllowUserToAddRows = false;
            dgvCNSanPham.EditMode = DataGridViewEditMode.EditProgrammatically;
            LoadDataGridView("SELECT MAGIA_SP, GIASP.MA_SP, TEN_SP, GIA_SP, NGAYCAPNHAT_SP FROM GIASP INNER JOIN SANPHAM ON GIASP.MA_SP = SANPHAM.MA_SP");
            AllowInput(false);
            DisplayValueTextbox();
        }
        public void LoadDataGridView(string query)
        {
            tblCNSP = Functions.ReadData(query);
            for (int i = 0; i < dgvCNSanPham.ColumnCount; i++)
                dgvCNSanPham.Columns[i].DataPropertyName = tblCNSP.Columns[i].ColumnName;
            dgvCNSanPham.Columns[4].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvCNSanPham.DataSource = tblCNSP;
          
        }

        public void RsValue()
        {
            txtMaCNSP.Text = "";
            cboTenCNSP.SelectedIndex = -1;
            txtGiaCNSP.Text = "";
            dtpNgayCNSP.Value = DateTime.Now;
        }

        public void DisplayValueTextbox()
        {
            if (dgvCNSanPham.Rows.Count > 0)
            {
                txtMaCNSP.Text = dgvCNSanPham.SelectedCells[0].Value.ToString();
                cboTenCNSP.SelectedValue = dgvCNSanPham.SelectedCells[1].Value.ToString();
                txtGiaCNSP.Text = dgvCNSanPham.SelectedCells[3].Value.ToString();
                dtpNgayCNSP.Value = Convert.ToDateTime(dgvCNSanPham.SelectedCells[4].Value);
            }
            else
                RsValue();
        }

        private void AllowInput(bool control)
        {

            cboTenCNSP.Enabled = control;
            txtGiaCNSP.Enabled = control;
            dtpNgayCNSP.Enabled = control;
        }

        private void dgvCNSanPham_Click(object sender, EventArgs e)
        {
            if (tblCNSP.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                DisplayValueTextbox();
                btnBoQua.Enabled = true;
                btnLuu.Enabled = true;
                btnSua.Enabled = true;
                btnThem.Enabled = false;
                btnXoa.Enabled = true;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            control = true;
            AllowInput(true);
            btnSua.Enabled = false;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnBoQua.Enabled = true;
            RsValue();
        }

        private void cboTenCNSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMaCNSP.Text = Functions.getValueByKey("SELECT MA_SP FROM SANPHAM WHERE MA_SP = '" + cboTenCNSP.SelectedValue + "'");
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (control == true)
            {
                if (cboTenCNSP.SelectedIndex < 0)
                {
                    MessageBox.Show("Bạn phải chọn sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtGiaCNSP.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập giá cập nhật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtGiaCNSP.Focus();
                    return;
                }

                else
                {
                    Functions.runSql($"INSERT INTO GIASP(MAGIA_SP ,MA_SP, GIA_SP, NGAYCAPNHAT_SP) VALUES('{Functions.createKey("MGSP_")}', '{cboTenCNSP.SelectedValue}', '{txtGiaCNSP.Text.Trim()}', '{dtpNgayCNSP.Value}')");
                    LoadDataGridView("SELECT MAGIA_SP, GIASP.MA_SP,TEN_SP, GIA_SP, NGAYCAPNHAT_SP FROM GIASP INNER JOIN SANPHAM ON GIASP.MA_SP = SANPHAM.MA_SP");
                    DisplayValueTextbox();
                    
                    btnXoa.Enabled = true;
                    btnThem.Enabled = true;
                    btnSua.Enabled = true;
                    btnBoQua.Enabled = false;
                    btnLuu.Enabled = false;
                    MessageBox.Show("Thực hiện lưu thành công!", "Infomation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (cboTenCNSP.SelectedIndex < 0)
                {
                    MessageBox.Show("Bạn phải chọn sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtGiaCNSP.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập giá cập nhật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtGiaCNSP.Focus();
                    return;
                }

                else
                {
                    if (MessageBox.Show("Thông tin sẽ bị sửa đổi! Bạn có chắc muốn sửa không?", "Warnning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        Functions.runSql($"UPDATE GIASP SET MA_SP = N'{cboTenCNSP.SelectedValue}', GIA_SP = '{txtGiaCNSP.Text.Trim()}', NGAYCAPNHAT_SP = '{dtpNgayCNSP.Value}' WHERE MAGIA_SP= '{dgvCNSanPham.SelectedCells[0].Value.ToString()}' ");
                        LoadDataGridView("SELECT MAGIA_SP, GIASP.MA_SP, TEN_SP, GIA_SP, NGAYCAPNHAT_SP FROM GIASP INNER JOIN SANPHAM ON GIASP.MA_SP = SANPHAM.MA_SP");
                        DisplayValueTextbox();
                        btnXoa.Enabled = true;
                        btnThem.Enabled = true;
                        btnSua.Enabled = false;
                        btnBoQua.Enabled = false;
                        btnLuu.Enabled = false;
                        MessageBox.Show("Sửa thành công!", "Infomation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            AllowInput(true);
            btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnThem.Enabled = false;
            control = false;
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            AllowInput(true);
            btnThem.Enabled = true;
            btnBoQua.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            DisplayValueTextbox();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string mes;
            int rowCount = dgvCNSanPham.SelectedRows.Count;
            if (rowCount > 1)
                mes = rowCount + " dòng dữ liệu sẽ bị xóa, bạn chắc muốn xóa các dòng đó không ?";
            else
                mes = "Dòng dữ liệu sẽ bị xóa, bạn có chắc muốn xóa không ?";
            if (MessageBox.Show(mes, "Warnning", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                for (int i = 0; i < rowCount; i++)
                {
                    if (Convert.ToInt32(Functions.getValueByKey($"SELECT COUNT(MAGIA_SP) FROM GIASP WHERE MA_SP ='{dgvCNSanPham.SelectedRows[i].Cells[1].Value}'")) > 1)
                    {
                        Functions.runSql("DELETE GIASP WHERE MAGIA_SP = '" + dgvCNSanPham.SelectedRows[i].Cells[0].Value.ToString() + "' ");
                    }
                    else
                        MessageBox.Show("Không thể xóa do chỉ có 1 giá của sản phẩm");


                }
                LoadDataGridView("SELECT MAGIA_SP, GIASP.MA_SP, TEN_SP, GIA_SP, NGAYCAPNHAT_SP FROM GIASP INNER JOIN SANPHAM ON GIASP.MA_SP = SANPHAM.MA_SP");
            }
            DisplayValueTextbox();
            btnBoQua.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = true;
        }

        private void txtGiaCNSP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
