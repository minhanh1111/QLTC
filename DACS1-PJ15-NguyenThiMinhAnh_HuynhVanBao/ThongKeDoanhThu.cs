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
using System.Windows.Forms.DataVisualization.Charting;

namespace DACS1_PJ15_NguyenThiMinhAnh_HuynhVanBao
{
    public partial class ThongKeDoanhThu : Form
    {
        private DataTable dtChart;
        public ThongKeDoanhThu()
        {
            InitializeComponent();
        }

        private void ThongKeDoanhThu_Load(object sender, EventArgs e)
        {
            //Functions.Connect();
            LoadData();
            txtNam.Text = DateTime.Now.Year.ToString();
            dgv_ThongKeDoanhThu.Columns[0].HeaderText = "Mã khách hàng";
            dgv_ThongKeDoanhThu.Columns[1].HeaderText = "Ngày lập";
            dgv_ThongKeDoanhThu.Columns[2].HeaderText = "Tổng tiền";
            dgv_ThongKeDoanhThu.Columns[3].HeaderText = "Người lập";
            dgv_ThongKeDoanhThu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        void LoadData()
        {
            DataTable dt = Functions.ReadData("select SDT_KH, NGAYLAP, TIENCONLAI, HOTEN_NV from HOADON inner join NHANVIEN ON NHANVIEN.MA_NV = HOADON.MA_NV");
            dgv_ThongKeDoanhThu.DataSource = dt;
        }

        private void btn_ThongKe_Click(object sender, EventArgs e)
        {
            DateTime tungay = dtp_TuNgay.Value;
            DateTime denngay = dtp_DenNgay.Value;
            string query = $"select SDT_KH, NGAYLAP, TIENCONLAI, HOTEN_NV from HOADON inner join NHANVIEN ON NHANVIEN.MA_NV = HOADON.MA_NV WHERE NgayLap BETWEEN '{tungay.ToString("yyyy-MM-dd")}' AND '{denngay.ToString("yyyy-MM-dd")}'";
            DataTable dt = Functions.ReadData(query);
            dgv_ThongKeDoanhThu.DataSource = dt;
            float totalRevenue = 0;
            foreach (DataRow row in dt.Rows)
            {
                totalRevenue += float.Parse(row["TIENCONLAI"].ToString());
            }
            // Hiển thị tổng doanh thu trong TextBox
            tb_TongDoanhThu.Text = totalRevenue.ToString();
        }

        private void bt_QuayLai_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadChart()
        {
            dtChart = Functions.ReadData($"SELECT SUM(TIENCONLAI) AS DOANHTHU, MONTH(NGAYLAP) AS THANG FROM HOADON WHERE YEAR(NGAYLAP) = '{txtNam.Text}' GROUP BY MONTH(NGAYLAP) ORDER BY THANG ASC");
            chart1.Series["Doanh Thu"].Points.Clear();
            bool check = false;
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < dtChart.Rows.Count; j++)
                {
                    if (i + 1 == Convert.ToInt16(dtChart.Rows[j]["THANG"]))
                    {
                        chart1.Series["Doanh Thu"].Points.Add(Convert.ToInt64(dtChart.Rows[j]["DOANHTHU"]));
                        chart1.Series["Doanh Thu"].Points[i].Label = dtChart.Rows[j]["DOANHTHU"].ToString();
                        chart1.Series["Doanh Thu"].Points[i].AxisLabel = $"Tháng {i + 1}";
                        check = true;
                        break;
                    }
                    else
                        check = false;
                }
                if (!check)
                {
                    chart1.Series["Doanh Thu"].Points.Add(0);
                    chart1.Series["Doanh Thu"].Points[i].Label = "0";
                    chart1.Series["Doanh Thu"].Points[i].AxisLabel = $"Tháng {i + 1}";
                }
            }
        }

        private void txtNam_TextChanged(object sender, EventArgs e)
        {
            LoadChart();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            Functions.nam = txtNam.Text;
            frmReportDoanhThu frmReportDoanhThu = new frmReportDoanhThu();
            frmReportDoanhThu.ShowDialog();
        }
    }
}
