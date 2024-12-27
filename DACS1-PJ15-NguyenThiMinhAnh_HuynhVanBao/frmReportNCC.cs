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
    public partial class frmReportNCC : Form
    {
        public frmReportNCC()
        {
            InitializeComponent();
        }

        private void frmReportNCC_Load(object sender, EventArgs e)
        {
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.Percent;
            reportViewer1.ZoomPercent = 100;
            DataSetNCC DataSetNCC = new DataSetNCC();

            SqlDataAdapter dataAdapter1 = new SqlDataAdapter($"SELECT * FROM NHACUNGCAP", Functions.conn);


            dataAdapter1.Fill(DataSetNCC.DataTableNCC);


            reportViewer1.LocalReport.ReportEmbeddedResource = "DACS1_PJ15_NguyenThiMinhAnh_HuynhVanBao.Report.ReportNCC.rdlc";
            ReportDataSource ds1 = new ReportDataSource(DataSetNCC.DataTableNCC.TableName, (object)DataSetNCC.DataTableNCC);


            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(ds1);


            this.reportViewer1.RefreshReport();
        }
    }
}
