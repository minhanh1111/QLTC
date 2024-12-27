using DACS1_PJ15_NguyenThiMinhAnh_HuynhVanBao.UC_NhanVien;
using DACS1_PJ15_NguyenThiMinhAnh_HuynhVanBao.UC_QuanLy;
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
    public partial class DangNhap : Form
    {
        SqlConnection data = Functions.conn;
        public DangNhap()
        {
            InitializeComponent();
        }

        private void btn_DangNhap_Click(object sender, EventArgs e)
        {
            string tk = tb_Name.Text;
            string mk = tb_Pass.Text;
            if (string.IsNullOrWhiteSpace(tk))
            {
                MessageBox.Show("Bạn chưa nhập tên tài khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tb_Name.Focus();
                return;
            }
            else if (string.IsNullOrWhiteSpace(mk))
            {
                MessageBox.Show("Bạn chưa nhập mật khẩu tài khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tb_Pass.Focus();
                return;
            }
            string sql = $"SELECT * FROM TAIKHOAN WHERE TEN_TK = '{tk}' AND MATKHAU = '{mk}'";
            DataTable dt = Functions.ReadData(sql);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Chào mừng đến với AB PET SHOP!");
                string q = dt.Rows[0]["QUYEN"].ToString();
                string maNV = dt.Rows[0]["MA_NV"].ToString();
                string sqlMaCN = $"SELECT MACN FROM NHANVIEN WHERE MA_NV = '{maNV}'";
                DataTable dtMaCN = Functions.ReadData(sqlMaCN);
                if (dtMaCN.Rows.Count > 0)
                {
                    Functions.Disconnect();
                    string maCN = dtMaCN.Rows[0]["MACN"].ToString();
                    Functions.Connect(maCN);
                    Functions.maCN = maCN;
                    frmChinh fc = new frmChinh(tk, q, maCN);
                    this.Hide();
                    fc.Show();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy mã chi nhánh liên kết với tài khoản này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Tên tài khoản hoặc mật khẩu không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lb_Thoat_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Bạn có muốn thoát chương trình không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {
            Functions.Connect("CNT");
            
        }

        private void label5_Click(object sender, EventArgs e)
        {
            DangKy dangKy = new DangKy();
            dangKy.Show();
            this.Hide();
        }

        private void cb_SPL_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_SPL.Checked == true)
            {
                tb_Pass.UseSystemPasswordChar = false;
                tb_Pass.PasswordChar = '\0';
            }
            else
            {
                tb_Pass.UseSystemPasswordChar = true;
            }
        }
    }
}
