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
    public partial class frmReportPN : Form
    {
        public frmReportPN()
        {
            InitializeComponent();
        }

        private void ReportNhapHang_Load(object sender, EventArgs e)
        {
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.Percent;
            reportViewer1.ZoomPercent = 100;
            QLTCDataSet QLTCDataSet = new QLTCDataSet();

            SqlDataAdapter dataAdapter1 = new SqlDataAdapter($"SELECT PHIEUNHAP.MA_PN, PHIEUNHAP.NGAYNHAP, PHIEUNHAP.TONGTIEN, NHACUNGCAP.TEN_NCC, NHANVIEN.HOTEN_NV FROM PHIEUNHAP INNER JOIN NHACUNGCAP ON PHIEUNHAP.MA_NCC = NHACUNGCAP.MA_NCC INNER JOIN NHANVIEN ON PHIEUNHAP.MA_NV = NHANVIEN.MA_NV WHERE PHIEUNHAP.MA_PN = '{Functions.maPN}'", Functions.conn);
            SqlDataAdapter dataAdapter2 = new SqlDataAdapter($"SELECT CHITIETPHIEUNHAP.LO, CHITIETPHIEUNHAP.SOLUONG, CHITIETPHIEUNHAP.DONGIA, SOLUONG*DONGIA AS THANHTIEN, SANPHAM.TEN_SP FROM CHITIETPHIEUNHAP INNER JOIN SANPHAM ON CHITIETPHIEUNHAP.MA_SP = SANPHAM.MA_SP WHERE CHITIETPHIEUNHAP.MA_PN = '" + Functions.maPN + "'", Functions.conn);


            dataAdapter1.Fill(QLTCDataSet.DataTablePN);
            dataAdapter2.Fill(QLTCDataSet.DataTableCTPN);

            reportViewer1.LocalReport.ReportEmbeddedResource = "DACS1_PJ15_NguyenThiMinhAnh_HuynhVanBao.Report.ReportPN.rdlc";
            ReportDataSource ds1 = new ReportDataSource(QLTCDataSet.DataTablePN.TableName, (object)QLTCDataSet.DataTablePN);
            ReportDataSource ds2 = new ReportDataSource(QLTCDataSet.DataTableCTPN.TableName, (object)QLTCDataSet.DataTableCTPN);
         

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(ds1);
            reportViewer1.LocalReport.DataSources.Add(ds2);
        

            this.reportViewer1.RefreshReport();
        }
    }
}
