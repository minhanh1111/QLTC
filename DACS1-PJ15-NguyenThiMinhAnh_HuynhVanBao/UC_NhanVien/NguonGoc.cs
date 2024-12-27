using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace DACS1_PJ15_NguyenThiMinhAnh_HuynhVanBao.UC_NhanVien
{
    public partial class NguonGoc : UserControl
    {
        SqlConnection data = Functions.conn;
        public Boolean chckUS { get; set; } = false;
        public NguonGoc()
        {
            InitializeComponent();
        }

        private void NguonGoc_Load(object sender, EventArgs e)
        {
           // Functions.Connect();
            LoadData();
            FillCbbTimKiem();
            dgv_NguonGoc.Columns[0].HeaderText = "Mã nguồn gốc";
            dgv_NguonGoc.Columns[1].HeaderText = "Tên nguồn gốc";
            dgv_NguonGoc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            lb_Thoat.Visible = chckUS;
        }
        void LoadData()
        {
            DataTable dt = Functions.ReadData("select MA_NG, TEN_NG from NGUONGOC");
            dgv_NguonGoc.DataSource = dt;
            ResetValues();
        }

        private void dgv_NguonGoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tb_MaNguonGoc.Text = dgv_NguonGoc.CurrentRow.Cells[0].Value.ToString();
            tb_TenNguonGoc.Text = dgv_NguonGoc.CurrentRow.Cells[1].Value.ToString();
            btn_Them.Enabled = false;
            btn_Sua.Enabled = true;
            btn_Xoa.Enabled = true;
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            //kiểm tra tính hợp lệ và đẩy đủ
            if (!Functions.CheckVAC(tb_MaNguonGoc.Text, tb_TenNguonGoc.Text))
            {
                MessageBox.Show("Dữ liệu không hợp lệ hoặc đầy đủ!");
                return;
            }
            //kiểm tra có trùng mã không
            DataTable CheckM = Functions.ReadData("select MA_NG, TEN_NG from NGUONGOC where Ma_NG = '" + tb_MaNguonGoc.Text + "'");
            if (CheckM.Rows.Count > 0)
            {
                MessageBox.Show("Mã nguồn gốc đã có, vui lòng nhập mã khác");
                tb_MaNguonGoc.Focus();
                return;
            }
            //thêm mới vào data
            string sqlIn = "insert into NGUONGOC (MA_NG, TEN_NG) values('" + tb_MaNguonGoc.Text + "',N'" + tb_TenNguonGoc.Text + "')";
            Functions.ChangeData(sqlIn);
            LoadData();
            MessageBox.Show("Thêm mới thành công");
            ResetValues();
            FillCbbTimKiem();
        }
        void ResetValues()
        {
            tb_MaNguonGoc.Text = "";
            tb_TenNguonGoc.Text = "";
            btn_Them.Enabled = true;
            btn_Sua.Enabled = false;
            btn_Xoa.Enabled = false;
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa không?", "Có hay không", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                try
                {
                    Functions.ChangeData("delete NGUONGOC where Ma_NG='" + tb_MaNguonGoc.Text + "'");
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
            if (tb_MaNguonGoc.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //kiểm tra tính hợp lệ và đẩy đủ
            if (!Functions.CheckVAC(tb_MaNguonGoc.Text, tb_TenNguonGoc.Text))
            {
                MessageBox.Show("Dữ liệu không hợp lệ hoặc đầy đủ!");
                return;
            }
            Functions.ChangeData("update NGUONGOC set Ten_NG=N'" + tb_TenNguonGoc.Text + "' where Ma_NG='" + tb_MaNguonGoc.Text + "'");
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
            string sqlTenNguonGoc = "select Ten_NG from NGUONGOC";
            DataTable dtTimKiem = Functions.ReadData(sqlTenNguonGoc);
            foreach(DataRow dtTK in dtTimKiem.Rows)
            {
                cbb_TimKiem.Items.Add(dtTK["Ten_NG"].ToString());
            }
        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            string sqlBtTimKiem = "select MA_NG, TEN_NG from NGUONGOC where Ten_NG=N'" + cbb_TimKiem.Text+"'";
            DataTable btTimKiem = Functions.ReadData(sqlBtTimKiem);
            if(btTimKiem !=null && btTimKiem.Rows.Count > 0 )
            {
                dgv_NguonGoc.DataSource = btTimKiem;
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
