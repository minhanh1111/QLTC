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
    public partial class ThongKePhieuNhap : Form
    {
        private DataTable tblTKNH;
        public ThongKePhieuNhap()
        {
            InitializeComponent();
        }

        private void ThongKePhieuNhap_Load(object sender, EventArgs e)
        {
           
            Functions.FillCombo("SELECT MA_NCC, TEN_NCC FROM NHACUNGCAP", cboNCC, "MA_NCC", "TEN_NCC");
           
            LoadDataGridView("SELECT MA_PN, PHIEUNHAP.MA_NCC, TEN_NCC, NGAYNHAP, PHIEUNHAP.MA_NV, HOTEN_NV, TONGTIEN, GHICHU FROM PHIEUNHAP " +
            "INNER JOIN NHANVIEN ON PHIEUNHAP.MA_NV = NHANVIEN.MA_NV INNER JOIN NHACUNGCAP ON PHIEUNHAP.MA_NCC = NHACUNGCAP.MA_NCC");
        }
        private void LoadDataGridView(string query)
        {
            tblTKNH = Functions.ReadData(query);
            for (int i = 0; i < dgvTKNhapHang.ColumnCount; i++)
                dgvTKNhapHang.Columns[i].DataPropertyName = tblTKNH.Columns[i].ColumnName;
            dgvTKNhapHang.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvTKNhapHang.DataSource = tblTKNH;
          

        }

       
        private void Statistical()
        {
            label_SL.Text = Functions.getValueByKey($"SELECT COUNT (MA_PN) FROM PHIEUNHAP WHERE NGAYNHAP BETWEEN '{dtpTuNgay.Value}' AND '{dtpDenNgay.Value}'");
            LoadDataGridView($"SELECT MA_PN, PHIEUNHAP.MA_NCC, TEN_NCC, NGAYNHAP, PHIEUNHAP.MA_NV, HOTEN_NV, TONGTIEN, GHICHU FROM PHIEUNHAP INNER JOIN NHANVIEN ON PHIEUNHAP.MA_NV = NHANVIEN.MA_NV INNER JOIN NHACUNGCAP ON PHIEUNHAP.MA_NCC = NHACUNGCAP.MA_NCC WHERE NGAYNHAP BETWEEN '{dtpTuNgay.Value}'  AND '{dtpDenNgay.Value}'");

        }

        private void dtpDenNgay_ValueChanged(object sender, EventArgs e)
        {
            Statistical();
        }

        private void cboNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNCC.SelectedIndex >= 0)
            {
                labelTong.Text = Functions.getValueByKey($"SELECT COUNT (MA_PN) FROM PHIEUNHAP INNER JOIN NHACUNGCAP ON PHIEUNHAP.MA_NCC = NHACUNGCAP.MA_NCC WHERE PHIEUNHAP.MA_NCC = '{cboNCC.SelectedValue}'");
                LoadDataGridView($"SELECT MA_PN, PHIEUNHAP.MA_NCC, TEN_NCC, NGAYNHAP, PHIEUNHAP.MA_NV, HOTEN_NV, TONGTIEN, GHICHU FROM PHIEUNHAP INNER JOIN NHACUNGCAP ON PHIEUNHAP.MA_NCC = NHACUNGCAP.MA_NCC INNER JOIN NHANVIEN ON PHIEUNHAP.MA_NV = NHANVIEN.MA_NV WHERE PHIEUNHAP.MA_NCC = '{cboNCC.SelectedValue}'");

            }
            else
            {
                labelTong.Text = null;
            }
        }

        private void dtpTuNgay_ValueChanged(object sender, EventArgs e)
        {
            Statistical() ;
        }
    }
}
