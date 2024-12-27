
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
    public partial class CapNhatGiaDV : Form
    {
        private DataTable tblCNDV;
        public static bool control;
        public CapNhatGiaDV()
        {
            InitializeComponent();
        }

        private void CapNhatGiaDV_Load(object sender, EventArgs e)
        {
            Functions.FillCombo("SELECT MA_DV, TEN_DV FROM DICHVU", cboTenCNDV, "MA_DV", "TEN_DV");
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnBoQua.Enabled = false;
            dgvCNDV.AllowUserToAddRows = false;
            dgvCNDV.EditMode = DataGridViewEditMode.EditProgrammatically;
            LoadDataGridView("SELECT MAGIA_DV, GIADV.MA_DV, TEN_DV, GIA_DV, NGAYCAPNHAT_DV FROM GIADV INNER JOIN DICHVU ON GIADV.MA_DV = DICHVU.MA_DV");
            AllowInput(false);
            DisplayValueTextbox();
        }
        public void LoadDataGridView(string query)
        {
            tblCNDV = Functions.ReadData(query);
            for (int i = 0; i < dgvCNDV.ColumnCount; i++)
                dgvCNDV.Columns[i].DataPropertyName = tblCNDV.Columns[i].ColumnName;
            dgvCNDV.Columns[4].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvCNDV.DataSource = tblCNDV;
          
        }

        public void RsValue()
        {
            txtMaCNDV.Text = "";
            cboTenCNDV.SelectedIndex = -1;
            txtGiaCNDV.Text = "";
            dtpNgayCNDV.Value = DateTime.Now;
        }

        public void DisplayValueTextbox()
        {
            if (dgvCNDV.Rows.Count > 0)
            {
                txtMaCNDV.Text = dgvCNDV.SelectedCells[0].Value.ToString();
                cboTenCNDV.SelectedValue = dgvCNDV.SelectedCells[1].Value;
                txtGiaCNDV.Text = dgvCNDV.SelectedCells[3].Value.ToString();
                dtpNgayCNDV.Value = Convert.ToDateTime(dgvCNDV.SelectedCells[4].Value);
            }
            else
                RsValue();
        }

        private void AllowInput(bool control)
        {

            cboTenCNDV.Enabled = control;
            txtGiaCNDV.Enabled = control;
            dtpNgayCNDV.Enabled = control;
        }

        private void dgvCNDV_Click(object sender, EventArgs e)
        {
            if (tblCNDV.Rows.Count == 0)
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

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (control == true)
            {
                if (cboTenCNDV.SelectedIndex < 0)
                {
                    MessageBox.Show("Bạn phải chọn dịch vụ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtGiaCNDV.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập giá cập nhật dịch vụ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtGiaCNDV.Focus();
                    return;
                }

                else
                {
                    Functions.runSql($"INSERT INTO GIADV(MAGIA_DV, MA_DV, GIA_DV, NGAYCAPNHAT_DV) VALUES('{Functions.createKey("MGDV_")}', '{cboTenCNDV.SelectedValue}', '{txtGiaCNDV.Text.Trim()}', '{dtpNgayCNDV.Value}')");
                    LoadDataGridView("SELECT MAGIA_DV, GIADV.MA_DV, TEN_DV, GIA_DV, NGAYCAPNHAT_DV FROM GIADV INNER JOIN DICHVU ON GIADV.MA_DV = DICHVU.MA_DV");
                    DisplayValueTextbox();
                    RsValue();
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
                if (cboTenCNDV.SelectedIndex < 0)
                {
                    MessageBox.Show("Bạn phải chọn dịch vụ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtGiaCNDV.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập giá cập nhật dịch vụ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtGiaCNDV.Focus();
                    return;
                }

                else
                {
                    if (MessageBox.Show("Thông tin sẽ bị sửa đổi! Bạn có chắc muốn sửa không?", "Warnning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        Functions.runSql($"UPDATE GIADV SET MA_DV = N'{cboTenCNDV.SelectedValue}', GIA_DV = '{txtGiaCNDV.Text.Trim()}', NGAYCAPNHAT_DV = '{dtpNgayCNDV.Value}' WHERE MAGIA_DV= '{dgvCNDV.SelectedCells[0].Value.ToString()}' ");
                        LoadDataGridView("SELECT MAGIA_DV, GIADV.MA_DV, TEN_DV, GIA_DV, NGAYCAPNHAT_DV FROM GIADV INNER JOIN DICHVU ON GIADV.MA_DV = DICHVU.MA_DV");
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

        private void cboTenCNDV_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMaCNDV.Text = Functions.getValueByKey("SELECT MA_DV FROM DICHVU WHERE MA_DV = '" + cboTenCNDV.SelectedValue + "'");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            AllowInput(true);
            btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnThem.Enabled = false;
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
            int rowCount = dgvCNDV.SelectedRows.Count;
            if (rowCount > 1)
                mes = rowCount + " dòng dữ liệu sẽ bị xóa, bạn chắc muốn xóa các dòng đó không ?";
            else
                mes = "Dòng dữ liệu sẽ bị xóa, bạn có chắc muốn xóa không ?";
            if (MessageBox.Show(mes, "Warnning", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                for (int i = 0; i < rowCount; i++)
                {
                    if (Convert.ToInt32(Functions.getValueByKey($"SELECT COUNT(MAGIA_DV) FROM GIADV WHERE MA_DV ='{dgvCNDV.SelectedRows[i].Cells[1].Value}'")) > 1)
                    {
                        Functions.runSql("DELETE GIADV WHERE MAGIA_DV = '" + dgvCNDV.SelectedRows[i].Cells[0].Value.ToString() + "' ");
                    }
                    else
                        MessageBox.Show("Không thể xóa do chỉ có 1 giá của dịch vụ");
                }
                LoadDataGridView("SELECT MAGIA_DV, GIADV.MA_DV, TEN_DV, GIA_DV, NGAYCAPNHAT_DV FROM GIADV INNER JOIN DICHVU ON GIADV.MA_DV = DICHVU.MA_DV");
            }
            DisplayValueTextbox();
            btnBoQua.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = true;
        }

        private void txtGiaCNDV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
