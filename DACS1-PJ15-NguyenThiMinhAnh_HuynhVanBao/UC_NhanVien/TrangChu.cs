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
    public partial class TrangChu : UserControl
    {
        SqlConnection data = Functions.conn;
        public TrangChu()
        {
            InitializeComponent();
            CountThuCung();
            CountSanPham();
            CountDatCho();
            CountDoanhThu();
        }
        private void CountThuCung()
        {
            string sqlThuCung = "select count(*) from THUCUNG";
            DataTable dtTC = Functions.ReadData(sqlThuCung);
            lb_ThuCung.Text = dtTC.Rows[0][0].ToString();
        }
        private void CountSanPham()
        {
            string sqlSanPham = "select count(*) from SANPHAM";
            DataTable dtSP = Functions.ReadData(sqlSanPham);
            lb_SanPham.Text = dtSP.Rows[0][0].ToString();
        }
        private void CountDatCho()
        {
            string sqlHoaDon = "select count(*) from HOADON";
            DataTable dtHD = Functions.ReadData(sqlHoaDon);
            lb_DatCho.Text = dtHD.Rows[0][0].ToString();
        }
        private void CountDoanhThu()
        {
            string sqlDoanhThu = "select sum(TienConLai) from HOADON";
            DataTable dtDC = Functions.ReadData(sqlDoanhThu);
            lb_DoanhThu.Text = dtDC.Rows[0][0].ToString();
        }
    }
}
