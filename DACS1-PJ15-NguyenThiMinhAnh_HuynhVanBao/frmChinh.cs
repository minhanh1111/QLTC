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
    public partial class frmChinh : Form
    {
        SqlConnection data = Functions.conn;
        public static string quyen;
        public static string chinhanh;
        bool Thoat = false;
        public frmChinh(string tk, string q, string cn)
        {
            InitializeComponent();
            //show menu
            dropdown();
            //show page tương ứng button
            TrangChu tc = new TrangChu();
            addUserControl(tc);
            //hiển thị thông tin tài khoản đăng nhập
            lb_Name.Text = tk;
            lb_ChucVu.Text = q;
            quyen = q;
            chinhanh = cn;
        }
        //hiển thị menu các cấp
        private void dropdown()
        {
            pn_DanhMuc.Visible = false;
            pn_ThuCung.Visible = false;
        }
        private void hideSubMenu()
        {
            if (pn_DanhMuc.Visible == true)
                pn_DanhMuc.Visible = false;
            if(pn_ThuCung.Visible == true)
                pn_ThuCung.Visible=false;
        }
        private void showSubMenu(Panel subMenu)
        {
            if(subMenu.Visible == false) 
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private void btn_DanhMuc_Click(object sender, EventArgs e)
        {
            showSubMenu(pn_DanhMuc);
        }

        private void btn_NhanVien_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            NhanVien nv = new NhanVien();
            addUserControl(nv);
        }

        private void btn_Khachhang_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            KhachHang kh = new KhachHang();
            addUserControl(kh);
        }

        private void btn_NhaCungCap_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            NhaCungCap ncc = new NhaCungCap();
            addUserControl(ncc);
        }

        private void btn_DichVu_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            DichVu dv = new DichVu();
            addUserControl(dv);
        }

        private void btn_SanPham_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            SanPham sp = new SanPham();
            addUserControl(sp);
        }

        private void btn_NhapHang_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            NhapHang nh = new NhapHang();
            addUserControl(nh);
        }

        private void btnThuCung_Click(object sender, EventArgs e)
        {
            showSubMenu(pn_ThuCung);
        }

        private void btn_ThuCung_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            ThuCung tc = new ThuCung();
            addUserControl(tc);
            tc.MaChiNhanh = chinhanh;
        }

        private void btn_Chuong_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            Chuong c = new Chuong();
            addUserControl(c);
        }

        private void btn_NguonGoc_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            NguonGoc ng = new NguonGoc();
            addUserControl(ng);
        }

        private void btn_Loai_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            Loai l = new Loai();
            addUserControl(l);
        }
        //hiển thị ngày giờ hệ thống
        private void timer_Time_Tick(object sender, EventArgs e)
        {
            lb_Date.Text = DateTime.Now.ToString("dd-MM-yyyy");
            lb_Time.Text = DateTime.Now.ToString("hh:mm:ss");
        }

        private void NhanVien_Load(object sender, EventArgs e)
        {
            timer_Time.Start();
            //phân quyền truy cập
            if(quyen == "Nhân Viên")
            {
                btn_TaiKhoan.Visible = false;
                btn_ChiNhanh.Visible = false;
            }
            string tencn = getTenCN(chinhanh);
            if(!string.IsNullOrEmpty(tencn))
            {
                lb_ChiNhanh.Text = tencn;
            }
        }
        public string getTenCN(string maCN)
        {
            string query = $"SELECT TENCN FROM CHINHANH WHERE MACN = '{maCN}'";
            DataTable dt = Functions.ReadData(query);
            if (dt != null && dt.Rows.Count > 0)
            {
                return dt.Rows[0]["TENCN"].ToString();
            }
            return null;
        }
        //hiển thị page tương ứng button
        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            pn_Container.Controls.Clear();
            pn_Container.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void btn_TrangChu_Click(object sender, EventArgs e)
        {
            TrangChu tc = new TrangChu();
            addUserControl(tc);
        }

      

        private void btn_TaiKhoan_Click(object sender, EventArgs e)
        {
            TaiKhoan tk = new TaiKhoan();
            addUserControl(tk);
        }

        private void btn_DangXuat_Click(object sender, EventArgs e)
        {
            Thoat = false;
            DialogResult dg = MessageBox.Show("Bạn có muốn đăng xuất không?", "Hòi người sử dụng", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
            {
                this.Close();
            }
            this.Close();
            DangNhap dn = new DangNhap();
            dn.Show();
        }

        private void btn_HD_Click(object sender, EventArgs e)
        {
             HoaDon hd = new HoaDon();
            addUserControl(hd);
        }

        private void btn_ChiNhanh_Click(object sender, EventArgs e)
        {
            ChiNhanh cn = new ChiNhanh();
            addUserControl(cn);
        }
    }
}
