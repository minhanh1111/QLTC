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

namespace DACS1_PJ15_NguyenThiMinhAnh_HuynhVanBao.UC_NhanVien
{
    public partial class ThuCung : UserControl
    {
        public string MaChiNhanh { get; set; }
        Functions cbb = new Functions();
        List<string> listGiong = new List<string>() { "Đực", "Cái" };
        SqlConnection data=Functions.conn;
        public ThuCung()
        {
            InitializeComponent();
            DataTable dtL = Functions.ReadData("select MA_L, TEN_L from LOAI");
            cbb.FillCombobox(cbb_TenLoai, dtL, "TEN_L", "MA_L");
            DataTable dtNG = Functions.ReadData("select MA_NG, TEN_NG from NGUONGOC");
            cbb.FillCombobox(cbb_TenNguonGoc, dtNG, "TEN_NG", "MA_NG");
            DataTable dtKH = Functions.ReadData("select SDT_KH from KHACHHANG");
            cbb.FillCombobox(cbb_SDT, dtKH, "SDT_KH", "SDT_KH");
            DataTable dtC = Functions.ReadData("select MA_C from CHUONG where TINHTRANG = N'Trống' and MA_C not in (select MA_C from THUCUNG)");
            cbb.FillCombobox(cbb_MaChuong, dtC, "MA_C", "MA_C");
        }

        private void ThuCung_Load(object sender, EventArgs e)
        {
            //Functions.Connect();
            btnIn.Enabled = true;
            LoadData();
            FillCbbTimKiem();
            dgv_ThuCung.Columns[0].HeaderText = "Mã thú cưng";
            dgv_ThuCung.Columns[1].HeaderText = "SĐT";
            dgv_ThuCung.Columns[2].HeaderText = "Mã chuồng";
            dgv_ThuCung.Columns[3].HeaderText = "Tên loài";
            dgv_ThuCung.Columns[4].HeaderText = "Tên nguồn gốc";
            dgv_ThuCung.Columns[5].HeaderText = "Tên thú cưng";
            dgv_ThuCung.Columns[6].HeaderText = "Giống";
            dgv_ThuCung.Columns[7].HeaderText = "Màu lông";
            dgv_ThuCung.Columns[8].HeaderText = "Cân nặng";
            dgv_ThuCung.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            cbb_Giong.DataSource = listGiong;
            cbb_Giong.Text = "";
        }
        void LoadData()
        {
            DataTable dt = Functions.ReadData("SELECT TC.Ma_TC, TC.SDT_KH, C.MA_C, L.Ten_L , NG.Ten_NG , TC.TEN_TC ,  TC.Giong_TC, TC.MauLong, TC.CanNang FROM THUCUNG TC INNER JOIN LOAI L ON TC.Ma_L = L.Ma_L INNER JOIN NGUONGOC NG ON TC.Ma_NG = NG.Ma_NG INNER JOIN KHACHHANG KH ON KH.SDT_KH = TC.SDT_KH INNER JOIN CHUONG C ON TC.MA_C = C.MA_C");
            dgv_ThuCung.DataSource = dt;
            ResetValues();
        }

        private void dgv_ThuCung_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_ThuCung.SelectedRows.Count > 0)
            {
                tb_MaThuCung.Text = dgv_ThuCung.CurrentRow.Cells[0].Value.ToString();
                cbb_SDT.Text = dgv_ThuCung.CurrentRow.Cells[1].Value.ToString();
                cbb_MaChuong.Text = dgv_ThuCung.CurrentRow.Cells[2].Value.ToString();
                cbb_TenLoai.Text = dgv_ThuCung.CurrentRow.Cells[3].Value.ToString();
                cbb_TenNguonGoc.Text = dgv_ThuCung.CurrentRow.Cells[4].Value.ToString();
                tb_ThuCung.Text = dgv_ThuCung.CurrentRow.Cells[5].Value.ToString();
                cbb_Giong.Text = dgv_ThuCung.CurrentRow.Cells[6].Value.ToString();
                tb_MauLong.Text = dgv_ThuCung.CurrentRow.Cells[7].Value.ToString();
                tb_CanNang.Text = dgv_ThuCung.CurrentRow.Cells[8].Value.ToString();
                btn_Them.Enabled = false;
                btn_Sua.Enabled = true;
                btn_Xoa.Enabled = true;
            }
        }
        private void UpdateCbbMaChuong()
        {
            DataTable dtC = Functions.ReadData("select MA_C from CHUONG where TINHTRANG = N'Trống'");
            cbb.FillCombobox(cbb_MaChuong, dtC, "MA_C", "MA_C");
            cbb_MaChuong.Text = "";
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            //Kiểm tra xem đã chọn bản ghi nào chưa
            if (tb_MaThuCung.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //kiểm tra tính hợp lệ và đẩy đủ
            if (!Functions.CheckVAC(tb_MaThuCung.Text, cbb_TenLoai.Text, cbb_TenNguonGoc.Text, cbb_MaChuong.Text,cbb_Giong.Text, tb_MauLong.Text, tb_CanNang.Text, cbb_SDT.Text))
            {
                MessageBox.Show("Dữ liệu không hợp lệ hoặc đầy đủ!");
                return;
            }
            //kiểm tra có trùng mã không
            DataTable CheckM = Functions.ReadData("select Ma_TC from THUCUNG where Ma_TC = '" + tb_MaThuCung.Text + "'");
            if (CheckM.Rows.Count > 0)
            {
                MessageBox.Show("Mã thú cưng đã có, vui lòng nhập mã khác");
                tb_MaThuCung.Focus();
                return;
            }
            //thêm mới vào db
            string sqlIn = "insert into THUCUNG (Ma_TC, MACN, SDT_KH, MA_C, Ma_L, Ma_NG, TEN_TC, GIONG_TC, MAULONG, CANNANG) " +
                       "values('" + tb_MaThuCung.Text + "', '" + MaChiNhanh + "', N'" + cbb_SDT.SelectedValue + "', N'" + cbb_MaChuong.SelectedValue + "', N'" + cbb_TenLoai.SelectedValue + "', N'" + cbb_TenNguonGoc.SelectedValue + "', N'" + tb_ThuCung.Text + "', " +
                       "N'" + cbb_Giong.Text + "', N'" + tb_MauLong.Text + "', '" + tb_CanNang.Text + "')";
            Functions.ChangeData(sqlIn);
            string sqlTTCT = "update CHUONG set TINHTRANG = N'Không' where MA_C = '"+cbb_MaChuong.SelectedValue+"'";
            Functions.ChangeData(sqlTTCT);
            MessageBox.Show("Thêm mới dữ liệu thành công");
            LoadData();
            ResetValues();
            UpdateCbbMaChuong();
            FillCbbTimKiem();
        }
        void ResetValues()
        {
            tb_MaThuCung.Text = "";
            tb_ThuCung.Text = "";
            cbb_TenLoai.Text = "";
            cbb_TenNguonGoc.Text = "";
            cbb_Giong.Text = "";
            tb_MauLong.Text = "";
            tb_CanNang.Text = "";
            cbb_SDT.Text = "";
            cbb_MaChuong.Text = "";
            btn_Them.Enabled = true;
            btn_Sua.Enabled = false;
            btn_Xoa.Enabled = false;
        }
        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa không?", "Có hay không", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                try
                {
                    string getMC = "select MA_C from THUCUNG where MA_TC = '"+tb_MaThuCung.Text+"'";
                    DataTable dt = Functions.ReadData(getMC);
                    if(dt.Rows.Count > 0)
                    {
                        string maC = dt.Rows[0]["MA_C"].ToString();
                        Functions.ChangeData("delete THUCUNG where Ma_TC='" + tb_MaThuCung.Text + "'");
                        string sqlTTCK = "update CHUONG set TINHTRANG = N'Trống' where MA_C = '" + maC + "'";
                        Functions.ChangeData(sqlTTCK);
                        LoadData();
                        UpdateCbbMaChuong();
                        ResetValues();
                        MessageBox.Show("Xóa thú cưng và cập nhật trạng thái chuồng thành công ");
                    }
                }
                catch
                {
                    MessageBox.Show("Bạn không được xóa vì nó liên quan đến các danh mục khác");
                }
            FillCbbTimKiem();
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            //Kiểm tra xem đã chọn bản ghi nào chưa
            if (tb_MaThuCung.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //kiểm tra tính hợp lệ và đẩy đủ
            if (!Functions.CheckVAC(tb_MaThuCung.Text, cbb_TenLoai.Text, cbb_TenNguonGoc.Text, cbb_MaChuong.Text, cbb_Giong.Text, tb_MauLong.Text, tb_CanNang.Text, cbb_SDT.Text))
            {
                MessageBox.Show("Dữ liệu không hợp lệ hoặc đầy đủ!");
                return;
            }
            Functions.ChangeData("update THUCUNG set  SDT_KH = '" + cbb_SDT.SelectedValue + "', MA_C=N'" + cbb_MaChuong.SelectedValue + "', MA_L=N'" + cbb_TenLoai.SelectedValue + "', MA_NG=N'" + cbb_TenNguonGoc.SelectedValue + "', TEN_TC=N'" + tb_ThuCung.Text + "', GIONG_TC=N'" + cbb_Giong.Text + "', MAULONG=N'" + tb_MauLong.Text + "', CANNANG='" + tb_CanNang.Text + "' WHERE MA_TC='" + tb_MaThuCung.Text + "' AND MACN = N'" + MaChiNhanh + "' ");
            LoadData();
            MessageBox.Show("Cập nhật dữ liệu thành công");
            ResetValues();
            FillCbbTimKiem();
        }

        private void bt_QuayLai_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void FillCbbTimKiem()
        {
            cbb_TimKiem.Items.Clear();
            string sqlTimKiem = "select SDT_KH from THUCUNG";
            DataTable dtTimKiem = Functions.ReadData(sqlTimKiem);
            foreach (DataRow drTK in dtTimKiem.Rows)
            {
                cbb_TimKiem.Items.Add(drTK["SDT_KH"].ToString());
            }
        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            string sqlBtTimKiem = "select Ma_TC, SDT_KH, MA_C, Ma_L, Ma_NG, TEN_TC, GIONG_TC, MAULONG, CANNANG from THUCUNG where SDT_KH = N'" + cbb_TimKiem.Text + "'";
            DataTable btTimKiem = Functions.ReadData(sqlBtTimKiem);
            if (btTimKiem != null & btTimKiem.Rows.Count > 0)
            {
                dgv_ThuCung.DataSource = btTimKiem;
            }
            else
            {
                LoadData();
                MessageBox.Show("Dữ liệu không tồn tại");
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            frmReportTC frmReportTC = new frmReportTC();
            frmReportTC.ShowDialog();
        }

        private void btn_KhachHang_Click(object sender, EventArgs e)
        {
            KhachHang kh = new KhachHang()
            {
                chckUS = true
            };
            Functions functions = new Functions();
            functions.showUC(kh, pn_Container);
        }

        private void btn_Chuong_Click(object sender, EventArgs e)
        {
            Chuong c = new Chuong()
            {
                chckUS = true
            };
            Functions functions = new Functions();
            functions.showUC(c, pn_Container);
        }

        private void btn_NguonGoc_Click(object sender, EventArgs e)
        {
            NguonGoc ng = new NguonGoc()
            {
                chckUS = true
            };
            Functions functions = new Functions();
            functions.showUC(ng, pn_Container);
        }

        private void btn_Loai_Click(object sender, EventArgs e)
        {
            Loai l = new Loai()
            {
                chckUS = true
            };
            Functions functions = new Functions();
            functions.showUC(l, pn_Container);
        }
    }
}
