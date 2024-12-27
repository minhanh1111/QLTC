using DACS1_PJ15_NguyenThiMinhAnh_HuynhVanBao.UC_NhanVien;
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
using DACS1_PJ15_NguyenThiMinhAnh_HuynhVanBao.UC_NhanVien;

namespace DACS1_PJ15_NguyenThiMinhAnh_HuynhVanBao.UC_QuanLy
{
    public partial class TaiKhoan : UserControl
    {
        Functions cbb = new Functions();
        List<string> listQuyen = new List<string>() { "Quản lý", "Nhân viên" };
        SqlConnection data = Functions.conn;
        public TaiKhoan()
        {
            InitializeComponent();
            DataTable dtNV = Functions.ReadData("select Ma_NV, HoTen_NV from NHANVIEN");
            cbb.FillCombobox(cbb_HoTenNhanVien, dtNV, "HoTen_NV", "Ma_NV");
            NhanVien nv = new NhanVien();

        }

        private void TaiKhoan_Load(object sender, EventArgs e)
        {
            //Functions.Connect();
            LoadData();
            FillCbbTimKiem();
            dgv_TaiKhoan.Columns[0].HeaderText = "Mã tài khoản";
            dgv_TaiKhoan.Columns[1].HeaderText = "Mã nhân viên";
            dgv_TaiKhoan.Columns[2].HeaderText = "Tên tài khoản";
            dgv_TaiKhoan.Columns[3].HeaderText = "Mật khẩu";
            dgv_TaiKhoan.Columns[4].HeaderText = "Quyền";
            dgv_TaiKhoan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            cbb_Quyen.DataSource = listQuyen;
            cbb_Quyen.Text = "";
            
        }
        void LoadData()
        {
            DataTable dt = Functions.ReadData("select MA_TK, MA_NV, TEN_TK, MATKHAU, QUYEN from TAIKHOAN");
            dgv_TaiKhoan.DataSource = dt;
            ResetValues();
        }

        private void dgv_TaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgv_TaiKhoan.SelectedRows.Count > 0)
            {
                tb_MaTaiKhoan.Text = dgv_TaiKhoan.CurrentRow.Cells[0].Value.ToString();
                cbb_HoTenNhanVien.SelectedValue = dgv_TaiKhoan.CurrentRow.Cells[1].Value.ToString();
                tb_TenTaiKhoan.Text = dgv_TaiKhoan.CurrentRow.Cells[2].Value.ToString();
                tb_MatKhau.Text = dgv_TaiKhoan.CurrentRow.Cells[3].Value.ToString();
                cbb_Quyen.Text = dgv_TaiKhoan.CurrentRow.Cells[4].Value.ToString();
                btn_Them.Enabled = false;
                btn_Sua.Enabled = true;
                btn_Xoa.Enabled = true;
            }    
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            // Kiểm tra tính hợp lệ và đầy đủ dữ liệu
            if (!Functions.CheckVAC(tb_MaTaiKhoan.Text, cbb_HoTenNhanVien.Text, tb_TenTaiKhoan.Text, tb_MatKhau.Text, cbb_Quyen.Text))
            {
                MessageBox.Show("Dữ liệu không hợp lệ hoặc đầy đủ!");
                return;
            }
            // Kiểm tra có trùng mã không
            DataTable CheckM = Functions.ReadData("SELECT MA_TK, MA_NV, TEN_TK, MATKHAU, QUYEN FROM TAIKHOAN WHERE Ma_TK = '" + tb_MaTaiKhoan.Text + "' OR Ma_NV = N'" + cbb_HoTenNhanVien.SelectedValue + "'");
            if (CheckM.Rows.Count > 0)
            {
                foreach (DataRow row in CheckM.Rows)
                {
                    string Ma_TK = row["Ma_TK"].ToString();
                    string Ma_NV = row["Ma_NV"].ToString();

                    if (tb_MaTaiKhoan.Text == Ma_TK && cbb_HoTenNhanVien.Text == Ma_NV)
                    {
                        MessageBox.Show("Mã tài khoản và mã nhân viên đã có, vui lòng nhập mã khác");
                        tb_MaTaiKhoan.Focus();
                        return;
                    }
                    else if (tb_MaTaiKhoan.Text == Ma_TK)
                    {
                        MessageBox.Show("Mã tài khoản đã có, vui lòng nhập mã khác");
                        tb_MaTaiKhoan.Focus();
                        return;
                    }
                    else if (cbb_HoTenNhanVien.SelectedValue.ToString() == Ma_NV)
                    {
                        MessageBox.Show("Mã nhân viên đã có, vui lòng nhập mã khác");
                        cbb_HoTenNhanVien.Focus();
                        return;
                    }
                }
            }
            // Thêm mới vào cơ sở dữ liệu
            string sqlIn = "INSERT INTO TAIKHOAN (MA_TK, MA_NV, TEN_TK, MATKHAU, QUYEN) VALUES('" + tb_MaTaiKhoan.Text + "','" + cbb_HoTenNhanVien.SelectedValue + "','" + tb_TenTaiKhoan.Text + "','" + tb_MatKhau.Text + "',N'" + cbb_Quyen.Text + "')";
            Functions.ChangeData(sqlIn);
            LoadData();
            MessageBox.Show("Thêm mới thành công");
            ResetValues();
            FillCbbTimKiem();
        }
        void ResetValues()
        {
            tb_MaTaiKhoan.Text = "";
            cbb_HoTenNhanVien.Text = "";
            tb_TenTaiKhoan.Text = "";
            tb_MatKhau.Text = "";
            cbb_Quyen.Text = "";
            btn_Them.Enabled = true;
            btn_Sua.Enabled = false;
            btn_Xoa.Enabled = false;
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa không?", "Có hay không", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                try
                {
                    Functions.ChangeData("delete TAIKHOAN where Ma_TK='" + tb_MaTaiKhoan.Text + "'");
                    LoadData();
                    ResetValues();
                }
                catch
                {
                    MessageBox.Show("Bạn không được xóa vì nó liên quan đến các danh mục khác");
                }
            FillCbbTimKiem() ;
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            //Kiểm tra xem đã chọn bản ghi nào chưa
            if (tb_MaTaiKhoan.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // Kiểm tra tính hợp lệ và đầy đủ dữ liệu
            if (!Functions.CheckVAC(tb_MaTaiKhoan.Text, cbb_HoTenNhanVien.Text, tb_TenTaiKhoan.Text, tb_MatKhau.Text, cbb_Quyen.Text))
            {
                MessageBox.Show("Dữ liệu không hợp lệ hoặc đầy đủ!");
                return;
            }
            // Kiểm tra có trùng mã không
            DataTable CheckM = Functions.ReadData("SELECT MA_TK, MA_NV, TEN_TK, MATKHAU, QUYEN FROM TAIKHOAN WHERE (Ma_TK = '" + tb_MaTaiKhoan.Text + "' OR Ma_NV = N'" + cbb_HoTenNhanVien.SelectedValue + "') AND Ma_TK != '" + tb_MaTaiKhoan.Text + "'");
            if (CheckM.Rows.Count > 0)
            {
                foreach (DataRow row in CheckM.Rows)
                {
                    string Ma_TK = row["Ma_TK"].ToString();
                    string Ma_NV = row["Ma_NV"].ToString();

                    if (tb_MaTaiKhoan.Text != Ma_TK && cbb_HoTenNhanVien.SelectedValue.ToString() != Ma_NV)
                    {
                        continue;
                    }
                    if (tb_MaTaiKhoan.Text == Ma_TK && cbb_HoTenNhanVien.SelectedValue.ToString() == Ma_NV)
                    {
                        MessageBox.Show("Mã tài khoản và mã nhân viên đã có, vui lòng nhập mã khác");
                        tb_MaTaiKhoan.Focus();
                        return;
                    }
                    else if (tb_MaTaiKhoan.Text == Ma_TK)
                    {
                        MessageBox.Show("Mã tài khoản đã có, vui lòng nhập mã khác");
                        tb_MaTaiKhoan.Focus();
                        return;
                    }
                    else if (cbb_HoTenNhanVien.SelectedValue.ToString() == Ma_NV)
                    {
                        MessageBox.Show("Mã nhân viên đã có, vui lòng nhập mã khác");
                        cbb_HoTenNhanVien.Focus();
                        return;
                    }
                }
            }
            // Tiến hành sửa dữ liệu
            string sqlUpdate = "UPDATE TAIKHOAN SET Ma_NV = '" + cbb_HoTenNhanVien.SelectedValue + "', Ten_TK = N'" + tb_TenTaiKhoan.Text + "', MatKhau = '" + tb_MatKhau.Text + "', QUYEN = N'" + cbb_Quyen.Text + "' WHERE Ma_TK = '" + tb_MaTaiKhoan.Text + "'";
            Functions.ChangeData(sqlUpdate);
            MessageBox.Show("Cập nhật dữ liệu thành công");
            LoadData();
            ResetValues();
            FillCbbTimKiem();
        }

        private void bt_QuayLai_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void FillCbbTimKiem()
        {
            cbb_TimKiem.Items.Clear();
            string sqlTimKiem = "select TEN_TK from TAIKHOAN";
            DataTable dtTimKiem = Functions.ReadData(sqlTimKiem);
            foreach(DataRow drTK in dtTimKiem.Rows)
            {
                cbb_TimKiem.Items.Add(drTK["Ten_TK"].ToString());
            }
        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            string sqlBtTimKiem = "select MA_TK, MA_NV, TEN_TK, MATKHAU, QUYEN from TAIKHOAN where Ten_TK = N'" + cbb_TimKiem.Text + "'";
            DataTable btTimKiem = Functions.ReadData(sqlBtTimKiem);
            if(btTimKiem != null && btTimKiem.Rows.Count > 0)
            {
                dgv_TaiKhoan.DataSource = btTimKiem;
            }
            else
            {
                LoadData();
                MessageBox.Show("Dữ liệu không tồn tại");
            }
        }

        private void cbb_Quyen_DropDown(object sender, EventArgs e)
        {
                cbb_Quyen.DataSource = listQuyen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NhanVien nv = new NhanVien()
            {
                chckUS = true
            };
            Functions functions = new Functions();
            functions.showUC(nv, pn_Container);
        }
    }
}
