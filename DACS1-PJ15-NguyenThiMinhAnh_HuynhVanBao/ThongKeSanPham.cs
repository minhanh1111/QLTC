using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DACS1_PJ15_NguyenThiMinhAnh_HuynhVanBao
{
    public partial class ThongKeSanPham : Form
    {
        private DataTable tblTKSP;
        public ThongKeSanPham()
        {
            InitializeComponent();
        }

        private void ThongKeSanPham_Load(object sender, EventArgs e)
        {
          
            dgvTKSanPham.AllowUserToAddRows = false;
            dgvTKSanPham.EditMode = DataGridViewEditMode.EditProgrammatically;
            LoadDataGridView("SELECT MA_SP,TEN_SP,SOLUONG_SP FROM SANPHAM WHERE SOLUONG_SP < 10");
        }
        public void LoadDataGridView(string query)
        {
            tblTKSP = Functions.ReadData(query);
            for (int i = 0; i < dgvTKSanPham.ColumnCount; i++)
                dgvTKSanPham.Columns[i].DataPropertyName = tblTKSP.Columns[i].ColumnName;

            dgvTKSanPham.DataSource = tblTKSP;
          
        }
        private void TKSanPham()
        {
            DataTable dataTable = Functions.ReadData($"SELECT TOP 1 TEN_SP, COUNT(CTHD_SP.MA_SP) AS TONGSDNHIEU FROM SANPHAM INNER JOIN CTHD_SP ON SANPHAM.MA_SP = CTHD_SP.MA_SP INNER JOIN HOADON ON HOADON.MA_HD = CTHD_SP.MA_HD WHERE NGAYLAP BETWEEN '{dateTimePicker1.Value}' AND '{dateTimePicker2.Value}'  GROUP BY TEN_SP ORDER BY TONGSDNHIEU DESC");
            if (dataTable.Rows.Count > 0)
            {
                labelSPNhieu.Text = dataTable.Rows[0]["TEN_SP"].ToString();
                labelTongSPNhieu.Text = dataTable.Rows[0]["TONGSDNHIEU"].ToString();
            }
            DataTable dataTable2 = Functions.ReadData($"SELECT TOP 1 TEN_SP, COUNT(CTHD_SP.MA_SP) AS TONGSDIT FROM SANPHAM INNER JOIN CTHD_SP ON SANPHAM.MA_SP = CTHD_SP.MA_SP INNER JOIN HOADON ON HOADON.MA_HD = CTHD_SP.MA_HD WHERE NGAYLAP BETWEEN '{dateTimePicker1.Value}' AND '{dateTimePicker2.Value}'  GROUP BY TEN_SP ORDER BY TONGSDIT ASC");
            if (dataTable2.Rows.Count > 0)
            {
                labelSPIt.Text = dataTable2.Rows[0]["TEN_SP"].ToString();
                labelTongSPIt.Text = dataTable2.Rows[0]["TONGSDIT"].ToString();
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            TKSanPham();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            TKSanPham();
        }
    }
}
