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
    public partial class ChiNhanh : UserControl
    {
        SqlConnection data = Functions.conn;
        public ChiNhanh()
        {
            InitializeComponent();
        }

        private void ChiNhanh_Load(object sender, EventArgs e)
        {
            //Functions.Connect();
            LoadData();
            FillCbbTimKiem();
            dgv_ChiNhanh.Columns[0].HeaderText = "Mã chi nhánh";
            dgv_ChiNhanh.Columns[1].HeaderText = "Tên chi nhánh";
            dgv_ChiNhanh.Columns[2].HeaderText = "Địa chỉ";
            dgv_ChiNhanh.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        void LoadData()
        {
            DataTable dt = Functions.ReadData("select MACN, TENCN, DIACHICN from CHINHANH");
            dgv_ChiNhanh.DataSource = dt;
            ResetValues();
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            //Kiểm tra xem đã chọn bản ghi nào chưa
            if (tb_MaChiNhanh.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //kiểm tra tính hợp lệ và đẩy đủ
            if (!Functions.CheckVAC(tb_MaChiNhanh.Text, tb_TenChiNhanh.Text, tb_DiaChi.Text))
            {
                MessageBox.Show("Dữ liệu không hợp lệ hoặc đầy đủ!");
                return;
            }
            //kiểm tra có trùng mã không
            DataTable CheckM = Functions.ReadData("select MACN, TENCN, DIACHICN from CHINHANH where MACN = '" + tb_MaChiNhanh.Text + "'");
            if (CheckM.Rows.Count > 0)
            {
                MessageBox.Show("Mã chi nhánh đã có, vui lòng nhập mã khác");
                tb_MaChiNhanh.Focus();
                return;
            }
            //thêm mới vào dat
            string sqlIn = "insert into CHINHANH (MACN, TENCN, DIACHICN) values('" + tb_MaChiNhanh.Text + "',  N'" + tb_TenChiNhanh.Text + "', N'" + tb_DiaChi.Text + "')";
            Functions.ChangeData(sqlIn);
            MessageBox.Show("Thêm mới dữ liệu thành công");
            LoadData();
            ResetValues();
            FillCbbTimKiem();
        }
        void ResetValues()
        {
            tb_MaChiNhanh.Text = "";
            tb_TenChiNhanh.Text = "";
            tb_DiaChi.Text = "";
            btn_Them.Enabled = true;
            btn_Sua.Enabled = false;
        }

       

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            //Kiểm tra xem đã chọn bản ghi nào chưa
            if (tb_MaChiNhanh.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // Kiểm tra tính hợp lệ và đầy đủ dữ liệu
            if (!Functions.CheckVAC(tb_TenChiNhanh.Text, tb_DiaChi.Text))
            {
                MessageBox.Show("Dữ liệu không hợp lệ hoặc đầy đủ!");
                return;
            }
            Functions.ChangeData("update CHINHANH set TENCN = N'" + tb_TenChiNhanh.Text + "', DIACHICN=N'" + tb_DiaChi.Text + "' where MACN='" + tb_MaChiNhanh.Text + "'");
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
            string sqlTimKiem = "select TENCN from CHINHANH";
            DataTable dtTimKiem = Functions.ReadData(sqlTimKiem);
            foreach (DataRow drTK in dtTimKiem.Rows)
            {
                cbb_TimKiem.Items.Add(drTK["TENCN"].ToString());
            }
        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            string sqlBtTimKiem = "select MACN, TENCN, DIACHICN from CHINHANH where TENCN = N'" + cbb_TimKiem.Text + "'";
            DataTable btTimKiem = Functions.ReadData(sqlBtTimKiem);
            if (btTimKiem != null & btTimKiem.Rows.Count > 0)
            {
                dgv_ChiNhanh.DataSource = btTimKiem;
            }
            else
            {
                LoadData();
                MessageBox.Show("Dữ liệu không tồn tại");
            }
        }

        private void dgv_ChiNhanh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_ChiNhanh.SelectedRows.Count > 0)
            {
                tb_MaChiNhanh.Text = dgv_ChiNhanh.CurrentRow.Cells[0].Value.ToString();
                tb_TenChiNhanh.Text = dgv_ChiNhanh.CurrentRow.Cells[1].Value.ToString();
                tb_DiaChi.Text = dgv_ChiNhanh.CurrentRow.Cells[2].Value.ToString();
                btn_Them.Enabled = false;
                btn_Sua.Enabled = true;
            }
        }
    }
}
