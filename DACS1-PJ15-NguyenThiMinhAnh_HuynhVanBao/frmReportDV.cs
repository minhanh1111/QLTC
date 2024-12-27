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
    public partial class frmReportDV : Form
    {
        public frmReportDV()
        {
            InitializeComponent();
        }

        private void frmReportDV_Load(object sender, EventArgs e)
        {
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.Percent;
            reportViewer1.ZoomPercent = 100;
            DataSetDV DataSetDV = new DataSetDV();

            SqlDataAdapter dataAdapter1 = new SqlDataAdapter($"SELECT DICHVU.MA_DV, DICHVU.TEN_DV, GIADV.GIA_DV, GIADV.NGAYCAPNHAT_DV FROM DICHVU INNER JOIN GIADV ON DICHVU.MA_DV = GIADV.MA_DV", Functions.conn);


            dataAdapter1.Fill(DataSetDV.DataTableDV);


            reportViewer1.LocalReport.ReportEmbeddedResource = "DACS1_PJ15_NguyenThiMinhAnh_HuynhVanBao.Report.ReportDV.rdlc";
            ReportDataSource ds1 = new ReportDataSource(DataSetDV.DataTableDV.TableName, (object)DataSetDV.DataTableDV);


            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(ds1);


            this.reportViewer1.RefreshReport();
        }
    }
}
