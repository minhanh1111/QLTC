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
namespace DACS1_PJ15_NguyenThiMinhAnh_HuynhVanBao.UC_NhanVien
{
    public partial class NhaCungCap : UserControl
    {
        private DataTable tblNCC;
        public bool control;
        public NhaCungCap()
        {
            InitializeComponent();
        }

        private void NhaCungCap_Load(object sender, EventArgs e)
        {
           
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnQuayLai.Enabled = false;
            dgvNCC.AllowUserToAddRows = false;
            dgvNCC.EditMode = DataGridViewEditMode.EditProgrammatically;
            LoadDataGridView("SELECT MA_NCC, TEN_NCC, SDT_NCC, DIACHI_NCC FROM NHACUNGCAP");
            AllowInput(false);
            DisplayValueTextbox();
            btnIn.Enabled = true;
            dgvNCC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        public void LoadDataGridView(string query)
        {
            tblNCC = Functions.ReadData(query);
            int columnCount = Math.Min(dgvNCC.ColumnCount, tblNCC.Columns.Count);
            for (int i = 0; i < columnCount; i++)
            {
                dgvNCC.Columns[i].DataPropertyName = tblNCC.Columns[i].ColumnName;
            }
            dgvNCC.DataSource = tblNCC;
           
        }

        public void RsValue()
        {
            txtMaNCC.Text = "";
            txtTenNCC.Text = "";
            txtSDT_NCC.Text = "";
            txtDiaChiNCC.Text = "";
        }

        public void DisplayValueTextbox()
        {
            if (dgvNCC.Rows.Count > 0)
            {
                txtMaNCC.Text = dgvNCC.SelectedCells[0].Value.ToString();
                txtTenNCC.Text = dgvNCC.SelectedCells[1].Value.ToString();
                txtSDT_NCC.Text = dgvNCC.SelectedCells[2].Value.ToString();
                txtDiaChiNCC.Text = dgvNCC.SelectedCells[3].Value.ToString();
            }
            else
                RsValue();
        }

        private void AllowInput(bool control)
        {
            txtMaNCC.Enabled = control;
            txtTenNCC.Enabled = control;
            txtSDT_NCC.Enabled = control;
            txtDiaChiNCC.Enabled = control;
        }

        private void dgvNCC_Click(object sender, EventArgs e)
        {
            if (tblNCC.Rows.Count == 0)
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

        private void txtSDT_NCC_KeyPress(object sender, KeyPressEventArgs e)
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
                if (txtMaNCC.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập mã nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaNCC.Focus();
                    return;
                }

                if (txtTenNCC.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập tên nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenNCC.Focus();
                    return;
                }

                if (txtSDT_NCC.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải số điện thoại nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSDT_NCC.Focus();
                    return;
                }

                if (txtDiaChiNCC.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập địa chỉ nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDiaChiNCC.Focus();
                    return;

                }

                else
                {
                    Functions.runSql("INSERT INTO NHACUNGCAP(MA_NCC, TEN_NCC, SDT_NCC, DIACHI_NCC) VALUES " +
                        "('" + txtMaNCC.Text.Trim() + "', N'" + txtTenNCC.Text.Trim() + "', '" + txtSDT_NCC.Text.Trim() + "', N'" + txtDiaChiNCC.Text.Trim() + "')");
                    LoadDataGridView("SELECT MA_NCC, TEN_NCC, SDT_NCC, DIACHI_NCC FROM NHACUNGCAP");
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
                if (tblNCC.Rows.Count == 0)
                {
                    MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (txtTenNCC.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập tên nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenNCC.Focus();
                    return;
                }

                if (txtSDT_NCC.Text == "")
                {
                    MessageBox.Show("Bạn phải nhập số điện thoại nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSDT_NCC.Focus();
                    return;
                }
                if (txtDiaChiNCC.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập địa chỉ nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDiaChiNCC.Focus();
                    return;

                }
                else
                {
                    if (MessageBox.Show("Thông tin sẽ bị sửa đổi! Bạn có chắc muốn sửa không?", "Warnning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        Functions.runSql("UPDATE NHACUNGCAP SET  TEN_NCC = N'" + txtTenNCC.Text.Trim().ToString() + "', SDT_NCC='" + txtSDT_NCC.Text.Trim().ToString() + "',DIACHI_NCC=N'" + txtDiaChiNCC.Text.Trim().ToString() + "' WHERE MA_NCC = '" + txtMaNCC.Text + "'");
                        LoadDataGridView("SELECT MA_NCC, TEN_NCC, SDT_NCC, DIACHI_NCC FROM NHACUNGCAP");
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
            txtMaNCC.Enabled = false;
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
            int rowCount = dgvNCC.SelectedRows.Count;
            if (rowCount > 1)
                mes = rowCount + " dòng dữ liệu sẽ bị xóa, bạn chắc muốn xóa các dòng đó không ?";
            else
                mes = "Dòng dữ liệu sẽ bị xóa, bạn có chắc muốn xóa không ?";
            if (MessageBox.Show(mes, "Warnning", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                for (int i = 0; i < rowCount; i++)
                {
                    if (String.IsNullOrEmpty(Functions.getValueByKey($"SELECT MA_PN FROM PHIEUNHAP WHERE MA_NCC = '{dgvNCC.SelectedRows[i].Cells[0].Value}'")))
                        Functions.runSql(" DELETE NHACUNGCAP WHERE MA_NCC = '" + dgvNCC.SelectedRows[i].Cells[0].Value.ToString() + "' ");
                    else
                        MessageBox.Show("Không thể xóa do có phiếu nhập của nhà cung cấp");
                }
                LoadDataGridView("SELECT MA_NCC, TEN_NCC, SDT_NCC, DIACHI_NCC FROM NHACUNGCAP");
            }
            DisplayValueTextbox();
            btnQuayLai.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = true;
        }

       

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            LoadDataGridView("SELECT MA_NCC, TEN_NCC, SDT_NCC, DIACHI_NCC FROM NHACUNGCAP WHERE MA_NCC LIKE '%" + txtTimKiem.Text.Trim() + "%' OR TEN_NCC LIKE N'%" + txtTimKiem.Text.Trim() + "%' OR SDT_NCC LIKE '%" + txtTimKiem.Text.Trim() + "%' OR DIACHI_NCC LIKE N'%" + txtTimKiem.Text.Trim() + "%'");
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            frmReportNCC frmReportNCC = new frmReportNCC();
            frmReportNCC.ShowDialog();
        }
    }
}
