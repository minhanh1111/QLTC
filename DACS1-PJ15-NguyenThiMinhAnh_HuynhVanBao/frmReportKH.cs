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
    public partial class frmReportKH : Form
    {
        public frmReportKH()
        {
            InitializeComponent();
        }

       

        private void frmReportKH_Load(object sender, EventArgs e)
        {
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.Percent;
            reportViewer1.ZoomPercent = 100;
            DataSetKH DataSetKH = new DataSetKH();

            SqlDataAdapter dataAdapter1 = new SqlDataAdapter($"SELECT CHINHANH.TENCN, KHACHHANG.SDT_KH, KHACHHANG.MACN, KHACHHANG.HOTEN_KH, KHACHHANG.DIACHI_KH, KHACHHANG.GIOITINH_KH FROM CHINHANH INNER JOIN KHACHHANG ON CHINHANH.MACN = KHACHHANG.MACN", Functions.conn);


            dataAdapter1.Fill(DataSetKH.DataTableKH);


            reportViewer1.LocalReport.ReportEmbeddedResource = "DACS1_PJ15_NguyenThiMinhAnh_HuynhVanBao.Report.ReportKH.rdlc";
            ReportDataSource ds1 = new ReportDataSource(DataSetKH.DataTableKH.TableName, (object)DataSetKH.DataTableKH);


            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(ds1);


            this.reportViewer1.RefreshReport();
        }
    }
}
