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
    public partial class frmReportSP : Form
    {
        public frmReportSP()
        {
            InitializeComponent();
        }

        private void frmReportSP_Load(object sender, EventArgs e)
        {
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.Percent;
            reportViewer1.ZoomPercent = 100;
            DataSetSP DataSetSP = new DataSetSP();

            SqlDataAdapter dataAdapter1 = new SqlDataAdapter($"SELECT SANPHAM.MA_SP, TEN_SP, SOlUONG_SP, GIA_SP, NGAYCAPNHAT_SP FROM SANPHAM INNER JOIN GIASP ON GIASP.MA_SP = SANPHAM.MA_SP ", Functions.conn);


            dataAdapter1.Fill(DataSetSP.DataTableSP);
            

            reportViewer1.LocalReport.ReportEmbeddedResource = "DACS1_PJ15_NguyenThiMinhAnh_HuynhVanBao.Report.ReportSP.rdlc";
            ReportDataSource ds1 = new ReportDataSource(DataSetSP.DataTableSP.TableName, (object)DataSetSP.DataTableSP);
           

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(ds1);
            

            this.reportViewer1.RefreshReport();
        }
    }
}
