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
    public partial class frmReportTC : Form
    {
        public frmReportTC()
        {
            InitializeComponent();
        }

        private void frmReportTC_Load(object sender, EventArgs e)
        {
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.Percent;
            reportViewer1.ZoomPercent = 100;
            DataSetTC DataSetTC = new DataSetTC();

            SqlDataAdapter dataAdapter1 = new SqlDataAdapter($"SELECT THUCUNG.MA_TC, THUCUNG.TEN_TC, THUCUNG.GIONG_TC, THUCUNG.MAULONG, THUCUNG.CANNANG, LOAI.TEN_L, NGUONGOC.TEN_NG FROM THUCUNG INNER JOIN LOAI ON THUCUNG.MA_L = LOAI.MA_L INNER JOIN NGUONGOC ON THUCUNG.MA_NG = NGUONGOC.MA_NG ", Functions.conn);


            dataAdapter1.Fill(DataSetTC.DataTableTC);


            reportViewer1.LocalReport.ReportEmbeddedResource = "DACS1_PJ15_NguyenThiMinhAnh_HuynhVanBao.Report.ReportTC.rdlc";
            ReportDataSource ds1 = new ReportDataSource(DataSetTC.DataTableTC.TableName, (object)DataSetTC.DataTableTC);


            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(ds1);


            this.reportViewer1.RefreshReport();
        }
    }
}
