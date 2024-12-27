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

namespace DACS1_PJ15_NguyenThiMinhAnh_HuynhVanBao
{
    public partial class frmReportNV : Form
    {
        public frmReportNV()
        {
            InitializeComponent();
        }

        private void frmReportNV_Load(object sender, EventArgs e)
        {
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.Percent;
            reportViewer1.ZoomPercent = 100;
            DataSetNV DataSetNV = new DataSetNV();

            SqlDataAdapter dataAdapter1 = new SqlDataAdapter($"SELECT CHINHANH.TENCN, NHANVIEN.MA_NV, NHANVIEN.HOTEN_NV, NHANVIEN.SDT_NV, NHANVIEN.DIACHI_NV, NHANVIEN.GIOITINH_NV, NHANVIEN.NGAYSINH_NV FROM CHINHANH INNER JOIN  NHANVIEN ON CHINHANH.MACN = NHANVIEN.MACN ", Functions.conn);


            dataAdapter1.Fill(DataSetNV.DataTableNV);


            reportViewer1.LocalReport.ReportEmbeddedResource = "DACS1_PJ15_NguyenThiMinhAnh_HuynhVanBao.Report.ReportNV.rdlc";
            ReportDataSource ds1 = new ReportDataSource(DataSetNV.DataTableNV.TableName, (object)DataSetNV.DataTableNV);


            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(ds1);


            this.reportViewer1.RefreshReport();
        }
    }
}
