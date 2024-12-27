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
    public partial class DichVu : UserControl
    {
        private DataTable tblDV;
        public bool control;
        public DichVu()
        {
            InitializeComponent();
        }

        private void DichVu_Load(object sender, EventArgs e)
        {
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnQuayLai.Enabled = false;
            dgvDichVu.AllowUserToAddRows = false;
            dgvDichVu.EditMode = DataGridViewEditMode.EditProgrammatically;
            LoadDataGridView("SELECT MA_DV, TEN_DV FROM DICHVU");
            AllowInput(false);
            DisplayValueTextbox();
            btnIn.Enabled = true;
            dgvDichVu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        public void LoadDataGridView(string query)
        {
           tblDV = Functions.ReadData(query);
            for (int i = 0; i < dgvDichVu.ColumnCount; i++)
                dgvDichVu.Columns[i].DataPropertyName = tblDV.Columns[i].ColumnName;
            dgvDichVu.DataSource = tblDV;
           
        }

        public void RsValue()
        {
            txtMaDV.Text = "";
            txtTenDV.Text = "";
        }

        public void DisplayValueTextbox()
        {
             if (dgvDichVu.Rows.Count > 0)
             {
                   txtMaDV.Text = dgvDichVu.SelectedCells[0].Value.ToString();
                   txtTenDV.Text = dgvDichVu.SelectedCells[1].Value.ToString();
             }
                else
                    RsValue();
        }

        private void AllowInput(bool control)
        {
            txtMaDV.Enabled = control;
            txtTenDV.Enabled = control;
        }

        private void dgvDichVu_Click(object sender, EventArgs e)
        {
            if (tblDV.Rows.Count == 0)
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

        private void txtGiaDV_KeyPress(object sender, KeyPressEventArgs e)
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
                if (txtMaDV.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập mã dịch vụ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaDV.Focus();
                    return;
                }

                if (txtTenDV.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập tên dịch vụ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenDV.Focus();
                    return;
                }

                else
                {
                    Functions.runSql("INSERT INTO DICHVU(MA_DV,TEN_DV) VALUES " +
                        "('" + txtMaDV.Text.Trim() + "', N'" + txtTenDV.Text.Trim() + "')");
                    LoadDataGridView("SELECT MA_DV,TEN_DV FROM DICHVU");
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
                if (tblDV.Rows.Count == 0)
                {
                    MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (txtTenDV.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập tên dịch vụ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenDV.Focus();
                    return;
                }

               
                else
                {
                    if (MessageBox.Show("Thông tin sẽ bị sửa đổi! Bạn có chắc muốn sửa không?", "Warnning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        Functions.runSql("UPDATE DICHVU SET TEN_DV = N'" + txtTenDV.Text.Trim().ToString() + "' WHERE MA_DV = '" + txtMaDV.Text + "'");
                        LoadDataGridView("SELECT MA_DV, TEN_DV FROM DICHVU");
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
            txtMaDV.Enabled = false;
            control = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string mes;
            int rowCount = dgvDichVu.SelectedRows.Count;
            if (rowCount > 1)
                mes = rowCount + " dòng dữ liệu sẽ bị xóa, bạn chắc muốn xóa các dòng đó không ?";
            else
                mes = "Dòng dữ liệu sẽ bị xóa, bạn có chắc muốn xóa không ?";
            if (MessageBox.Show(mes, "Warnning", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                for (int i = 0; i < rowCount; i++)
                {
                    if (String.IsNullOrEmpty(Functions.getValueByKey($"SELECT HOADON.MA_HD FROM HOADON INNER JOIN CTHD_DV ON HOADON.MA_HD = CTHD_DV.MA_HD WHERE MA_DV = '{dgvDichVu.SelectedRows[i].Cells[0].Value}'")))
                    {
                        Functions.runSql("DELETE GIADV WHERE MA_DV = '" + dgvDichVu.SelectedRows[i].Cells[0].Value.ToString() + "' ");
                        Functions.runSql(" DELETE DICHVU WHERE MA_DV = '" + dgvDichVu.SelectedRows[i].Cells[0].Value.ToString() + "' ");
                    }

                    else
                        MessageBox.Show("Không thể xóa do có hóa đơn sử dụng dịch vụ");
                }
                LoadDataGridView("SELECT MA_DV, TEN_DV FROM DICHVU");
            }
            DisplayValueTextbox();
            btnQuayLai.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = true;
        }

       
      

        private void btnCNGiaDV_Click(object sender, EventArgs e)
        {
            CapNhatGiaDV frmCapNhatGiaDV = new CapNhatGiaDV();
            frmCapNhatGiaDV.ShowDialog();
        }

        private void txtTimKiem_TextChanged_1(object sender, EventArgs e)
        {
            LoadDataGridView("SELECT MA_DV, TEN_DV FROM DICHVU WHERE MA_DV LIKE '%" + txtTimKiem.Text.Trim() + "%' OR TEN_DV LIKE N'%" + txtTimKiem.Text.Trim() + "%'");
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            btnThem.Enabled=true;
            btnQuayLai.Enabled=false;
            btnSua.Enabled=false;
            btnXoa.Enabled=false;
            DisplayValueTextbox();
            AllowInput(false);
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            frmReportDV frmReportDV = new frmReportDV();
            frmReportDV.ShowDialog();
        }
    }
}
