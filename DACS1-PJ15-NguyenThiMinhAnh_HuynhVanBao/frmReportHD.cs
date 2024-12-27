    using Microsoft.Reporting.WinForms;
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
using DACS1_PJ15_NguyenThiMinhAnh_HuynhVanBao.FolderDataSet;

namespace DACS1_PJ15_NguyenThiMinhAnh_HuynhVanBao
{
    public partial class frmReportHD : Form
    {
        public frmReportHD()
        {
            InitializeComponent();
        }

        private void InReportHD_Load(object sender, EventArgs e)
        {
            
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.Percent;
            reportViewer1.ZoomPercent = 100;
            QLTC_HDDataSet QLTC_HDDataSet = new QLTC_HDDataSet();
            SqlDataAdapter dataAdapter1 = new SqlDataAdapter("SELECT KHACHHANG.HOTEN_KH, KHACHHANG.SDT_KH, NHANVIEN.HOTEN_NV, HOADON.SOLUONG_TC, HOADON.NGAYLAP, HOADON.NGAYNHAN, HOADON.NGAYTRA, HOADON.TONGNGAY, HOADON.TONGTIEN_HD, HOADON.KHAUTRU, HOADON.TIENCOC, HOADON.CHIPHIPHATSINH, HOADON.TIENCONLAI, HOADON.MA_HD FROM HOADON INNER JOIN KHACHHANG ON HOADON.SDT_KH = KHACHHANG.SDT_KH INNER JOIN NHANVIEN ON HOADON.MA_NV = NHANVIEN.MA_NV" +
                $" WHERE HOADON.MA_HD = '{Functions.maHD}'", Functions.conn);
            SqlDataAdapter dataAdapter2 = new SqlDataAdapter("SELECT THUCUNG.TEN_TC, SANPHAM.TEN_SP, CTHD_SP.SL_CTSP, GIASP.GIA_SP, GIA_SP*SL_CTSP AS THANHTIEN_SP FROM GIASP INNER JOIN SANPHAM ON GIASP.MA_SP = SANPHAM.MA_SP INNER JOIN CTHD_SP ON SANPHAM.MA_SP = CTHD_SP.MA_SP INNER JOIN THUCUNG ON CTHD_SP.MA_TC = THUCUNG.MA_TC" +
                $" WHERE CTHD_SP.MA_HD = '{Functions.maHD}'", Functions.conn);
            SqlDataAdapter dataAdapter3 = new SqlDataAdapter("SELECT THUCUNG.TEN_TC, DICHVU.TEN_DV, CTHD_DV.SL_CTDV, GIADV.GIA_DV, GIA_DV*SL_CTDV AS THANHTIEN_DV FROM GIADV INNER JOIN DICHVU ON GIADV.MA_DV = DICHVU.MA_DV INNER JOIN CTHD_DV ON DICHVU.MA_DV = CTHD_DV.MA_DV INNER JOIN THUCUNG ON CTHD_DV.MA_TC = THUCUNG.MA_TC" +
                $" WHERE CTHD_DV.MA_HD = '{Functions.maHD}'", Functions.conn);


            dataAdapter1.Fill(QLTC_HDDataSet.DataTableHD);
            dataAdapter2.Fill(QLTC_HDDataSet.DataTableCTHD_SP);
            dataAdapter3.Fill(QLTC_HDDataSet.DataTableCTHD_DV);


            reportViewer1.LocalReport.ReportEmbeddedResource = "DACS1_PJ15_NguyenThiMinhAnh_HuynhVanBao.Report.ReportHD.rdlc";
            ReportDataSource ds1 = new ReportDataSource(QLTC_HDDataSet.DataTableHD.TableName, (object)QLTC_HDDataSet.DataTableHD);
            ReportDataSource ds2 = new ReportDataSource(QLTC_HDDataSet.DataTableCTHD_SP.TableName, (object)QLTC_HDDataSet.DataTableCTHD_SP);
            ReportDataSource ds3 = new ReportDataSource(QLTC_HDDataSet.DataTableCTHD_DV.TableName, (object)QLTC_HDDataSet.DataTableCTHD_DV);

            reportViewer1.LocalReport.DataSources.Clear();
          
            reportViewer1.LocalReport.DataSources.Add(ds1);
            reportViewer1.LocalReport.DataSources.Add(ds2);
            reportViewer1.LocalReport.DataSources.Add(ds3);


            this.reportViewer1.RefreshReport();
        }
    }
}
