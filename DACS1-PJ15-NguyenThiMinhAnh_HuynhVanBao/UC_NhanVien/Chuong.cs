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
    public partial class Chuong : UserControl
    {
        SqlConnection data = Functions.conn;
        List<string> listTinhTrang = new List<string>() { "Trống", "Không" };
        public Boolean chckUS { get; set; } = false;
        public Chuong()
        {
            InitializeComponent();
        }

        private void Chuong_Load(object sender, EventArgs e)
        {
           // Functions.Connect();
            LoadData();
            FillCbbTimKiem();
            dgv_Chuong.Columns[0].HeaderText = "Mã chuồng";
            dgv_Chuong.Columns[1].HeaderText = "Tình trạng";
            dgv_Chuong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            cbb_TinhTrang.DataSource = listTinhTrang;
            lb_Thoat.Visible = chckUS;
            cbb_TinhTrang.Text = "";
        }
        void LoadData()
        {
            DataTable dt = Functions.ReadData("select MA_c, TINHTRANG from CHUONG");
            dgv_Chuong.DataSource = dt;
            ResetValues();
        }

        private void dgv_Chuong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tb_Chuong.Text = dgv_Chuong.CurrentRow.Cells[0].Value.ToString();
            cbb_TinhTrang.SelectedItem = dgv_Chuong.CurrentRow.Cells[1].Value.ToString();
            btn_Them.Enabled = false;
            btn_Sua.Enabled = true;
            btn_Xoa.Enabled = true;
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            //kiểm tra tính hợp lệ và đẩy đủ
            if (!Functions.CheckVAC(tb_Chuong.Text, cbb_TinhTrang.Text))
            {
                MessageBox.Show("Dữ liệu không hợp lệ hoặc đầy đủ!");
                return;
            }
            //kiểm tra có trùng mã không
            DataTable CheckM = Functions.ReadData("select MA_c, TINHTRANG from CHUONG where Ma_C = '" + tb_Chuong.Text + "'");
            if (CheckM.Rows.Count > 0)
            {
                MessageBox.Show("Mã chuồng đã có, vui lòng nhập mã khác");
                tb_Chuong.Focus();
                return;
            }
            //thêm mới vào data
            string sqlIn = "insert into CHUONG (MA_c, TINHTRANG) values('" + tb_Chuong.Text + "', N'" + cbb_TinhTrang.Text + "')";
            Functions.ChangeData(sqlIn);
            LoadData();
            MessageBox.Show("Thêm mới thành công");
            ResetValues();
            FillCbbTimKiem();
        }
        void ResetValues()
        {
            tb_Chuong.Text = "";
            cbb_TinhTrang.Text = "";
            btn_Them.Enabled = true;
            btn_Sua.Enabled = false;
            btn_Xoa.Enabled = false;
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa không?", "Có hay không", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                try
                {
                    Functions.ChangeData("delete CHUONG where Ma_C='" + tb_Chuong.Text + "'");
                    LoadData();
                    ResetValues();
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
            if (tb_Chuong.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // Kiểm tra tính hợp lệ và đầy đủ dữ liệu
            if (!Functions.CheckVAC(tb_Chuong.Text, cbb_TinhTrang.Text))
            {
                MessageBox.Show("Dữ liệu không hợp lệ hoặc đầy đủ!");
                return;
            }
            Functions.ChangeData("update CHUONG set TinhTrang=N'" + cbb_TinhTrang.Text + "' where Ma_C='" + tb_Chuong.Text + "'");
            MessageBox.Show("Cập nhật dữ liệu thành công");
            LoadData();
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
            string sqlTimKiem = "select Ma_C from CHUONG";
            DataTable dtTimKiem = Functions.ReadData(sqlTimKiem);
            foreach (DataRow drTK in dtTimKiem.Rows)
            {
                cbb_TimKiem.Items.Add(drTK["Ma_C"].ToString());
            }
        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            string sqlBtTimKiem = "select MA_c, TINHTRANG from CHUONG where Ma_C = N'" + cbb_TimKiem.Text+"'";
            DataTable btTimKiem = Functions.ReadData(sqlBtTimKiem);
            if(btTimKiem !=null & btTimKiem.Rows.Count > 0)
            {
                dgv_Chuong.DataSource = btTimKiem;
            }
            else
            {
                LoadData();
                MessageBox.Show("Dữ liệu không tồn tại");
            }
        }

        private void lb_Thoat_Click(object sender, EventArgs e)
        {
            ThuCung tc = new ThuCung();
            Functions functions = new Functions();
            functions.showUC(tc, pn_Container);
        }
    }
}
