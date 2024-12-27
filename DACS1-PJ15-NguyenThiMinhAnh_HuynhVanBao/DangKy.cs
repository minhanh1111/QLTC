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
using System.Text.RegularExpressions;

namespace DACS1_PJ15_NguyenThiMinhAnh_HuynhVanBao
{
    public partial class DangKy : Form
    {
        Functions cbb = new Functions();
        List<string> listQuyen = new List<string>() { "Nhân  viên", "Quản lý" };
        SqlConnection data = Functions.conn;
        public DangKy()
        {
            InitializeComponent();
            DataTable dtNV = Functions.ReadData("select * from NHANVIEN");
            cbb.FillCombobox(cbb_NhanVien, dtNV, "HOTEN_NV", "Ma_NV");
            cbb_Quyen.DataSource = listQuyen;
        }

        public bool checkAccount(string ac)
        {
            return Regex.IsMatch(ac, "^[a-zA-Z0-9]{3,24}$");
        }

        private void btn_DangKy_Click(object sender, EventArgs e)
        {
            string nv = cbb_NhanVien.Text;
            string tentk = tb_Name.Text;
            string mk = tb_Pass.Text;
            string cmk = tb_CPass.Text;
            string q = cbb_Quyen.Text;
            if (!Functions.CheckVAC(cbb_NhanVien.Text, tb_Name.Text, tb_Pass.Text, tb_CPass.Text, cbb_Quyen.Text))
            {
                MessageBox.Show("Dữ liệu không hợp lệ hoặc đầy đủ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (!checkAccount(tentk))
            {
                MessageBox.Show("Vui lòng nhập tên tài khoản dài 3-24 ký tự gồm các ký tự chữ và số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tb_Name.Clear();
                tb_Name.Focus();
                return;
            }
            else if (!checkAccount(mk))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu dài 3-24 ký tự gồm các ký tự chữ và số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tb_Pass.Clear();
                tb_Pass.Focus();
                return;
            }
            else if (!checkAccount(cmk))
            {
                MessageBox.Show("Vui lòng nhập đúng mật khẩu ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tb_CPass.Clear();
                tb_CPass.Focus();
                return;
            }
            DataTable chkM = Functions.ReadData("select * from TAIKHOAN where MA_NV = '" + cbb_NhanVien.SelectedValue + "'");
            if (chkM.Rows.Count > 0)
            {
                MessageBox.Show("Nhân viên này đã có tài khoản, vui lòng chọn nhân viên khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbb_NhanVien.Focus();
                return;
            }
            else if (tb_Pass.Text == tb_CPass.Text)
            {
                string MA_TK = Functions.TKAuto();
                string register = "INSERT INTO TAIKHOAN(MA_TK, MA_NV, TEN_TK, MATKHAU, QUYEN) VALUES('" + MA_TK + "','" + cbb_NhanVien.SelectedValue + "','" + tb_Name.Text + "', '" + tb_Pass.Text + "', '" + cbb_Quyen.SelectedValue + "')";
                Functions.ChangeData(register);
                MessageBox.Show("Tạo tài khoản thành công", "Đăng ký thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbb_NhanVien.Text = "";
                tb_Name.Clear();
                tb_Pass.Clear();
                tb_CPass.Clear();
                cbb_Quyen.Text = "";
            }
        }

        private void cb_SPR_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_SPR.Checked == true)
            {
                tb_Pass.UseSystemPasswordChar = false;
                tb_CPass.UseSystemPasswordChar = false;
                tb_Pass.PasswordChar = '\0';
                tb_CPass.PasswordChar = '\0';
            }
            else
            {
                tb_Pass.UseSystemPasswordChar = true;
                tb_CPass.UseSystemPasswordChar = true;
            }
        }

        private void lb_DangNhap_Click(object sender, EventArgs e)
        {
            DangNhap dangNhap = new DangNhap();
            dangNhap.Show();
            this.Hide();
        }

        private void DangKy_Load(object sender, EventArgs e)
        {
            //Functions.Connect();
            cbb_NhanVien.Text = "";
            cbb_Quyen.Text = "";
        }

        private void lb_Thoat_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Bạn có muốn thoát chương trình không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
