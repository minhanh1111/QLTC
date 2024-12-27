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
    public partial class frmReportDoanhThu : Form
    {
        public frmReportDoanhThu()
        {
            InitializeComponent();
        }

        private void frmReportDoanhThu_Load(object sender, EventArgs e)
        {
           
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.Percent;
            reportViewer1.ZoomPercent = 100;
            DataSetDoanhThu DataSetDoanhThu = new DataSetDoanhThu();

            SqlDataAdapter dataAdapter1 = new SqlDataAdapter($"SELECT MONTH(NGAYLAP) AS THANG, SUM(TIENCONLAI) AS TONGTIEN FROM HOADON GROUP BY MONTH(NGAYLAP)", Functions.conn);


            dataAdapter1.Fill(DataSetDoanhThu.DataTableDT);


            reportViewer1.LocalReport.ReportEmbeddedResource = "DACS1_PJ15_NguyenThiMinhAnh_HuynhVanBao.Report.ReportDT.rdlc";
            ReportDataSource ds1 = new ReportDataSource(DataSetDoanhThu.DataTableDT.TableName, (object)DataSetDoanhThu.DataTableDT);


            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(ds1);


            this.reportViewer1.RefreshReport();
        }
    }
}
