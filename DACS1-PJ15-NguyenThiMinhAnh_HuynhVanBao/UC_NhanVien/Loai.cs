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
    public partial class Loai : UserControl
    {
        SqlConnection data = Functions.conn;
        public Boolean chckUS {  get; set; } =false;
        public Loai()
        {
            InitializeComponent();
        }

        private void Loai_Load(object sender, EventArgs e)
        {
            FillCbbTimKiem();
            LoadData();
            dgv_Loai.Columns[0].HeaderText = "Mã loài";
            dgv_Loai.Columns[1].HeaderText = "Tên loài";
            dgv_Loai.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            lb_Thoat.Visible = chckUS;
        }
        void LoadData()
        {
            DataTable dt = Functions.ReadData("select MA_L, TEN_L from LOAI");
            dgv_Loai.DataSource = dt;
            ResetValues();
        }

        private void dgv_Loai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tb_MaLoai.Text = dgv_Loai.CurrentRow.Cells[0].Value.ToString();
            tb_TenLoai.Text = dgv_Loai.CurrentRow.Cells[1].Value.ToString();
            btn_Them.Enabled = false;
            btn_Sua.Enabled = true;
            btn_Xoa.Enabled = true;
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            //kiểm tra tính hợp lệ và đẩy đủ
            if (!Functions.CheckVAC(tb_MaLoai.Text, tb_TenLoai.Text))
            {
                MessageBox.Show("Dữ liệu không hợp lệ hoặc đầy đủ!");
                return;
            }
            //kiểm tra có trùng mã không
            DataTable CheckM = Functions.ReadData("select MA_L, TEN_L from LOAI where Ma_L = '" + tb_MaLoai.Text + "'");
            if (CheckM.Rows.Count > 0)
            {
                MessageBox.Show("Mã loài đã có, vui lòng nhập mã khác");
                tb_MaLoai.Focus();
                return;
            }
            //thêm mới vào data
            string sqlIn = "insert into LOAI (MA_L, TEN_L) values('" + tb_MaLoai.Text + "',N'" + tb_TenLoai.Text + "')";
            Functions.ChangeData(sqlIn);
            LoadData();
            MessageBox.Show("Thêm mới thành công");
            ResetValues();
            FillCbbTimKiem();
        }
        void ResetValues()
        {
            tb_MaLoai.Text = "";
            tb_TenLoai.Text = "";
            btn_Them.Enabled = true;
            btn_Sua.Enabled = false;
            btn_Xoa.Enabled = false;
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa không?", "Có hay không", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                try
                {
                    Functions.ChangeData("delete LOAI where Ma_L='" + tb_MaLoai.Text + "'");
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
            if (tb_MaLoai.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //kiểm tra tính hợp lệ và đẩy đủ
            if (!Functions.CheckVAC(tb_MaLoai.Text, tb_TenLoai.Text))
            {
                MessageBox.Show("Dữ liệu không hợp lệ hoặc đầy đủ!");
                return;
            }
            Functions.ChangeData("update LOAI set Ten_L=N'" + tb_TenLoai.Text + "' where Ma_L='" + tb_MaLoai.Text + "'");
            MessageBox.Show("Cập nhật dữ liệu thành công");
            LoadData();
            ResetValues();
            FillCbbTimKiem();
        }

        private void btn_QuayLai_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void FillCbbTimKiem()
        {
            cbb_TimKiem.Items.Clear();
            string sqlTenThuCung = "select Ten_L from LOAI";
            DataTable dtTimKiem = Functions.ReadData(sqlTenThuCung);
            foreach (DataRow drTK in dtTimKiem.Rows)
            {
                cbb_TimKiem.Items.Add(drTK["Ten_L"].ToString());
            }
        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            string sqlBtTimKiem = "select MA_L, TEN_L from LOAI where Ten_L = N'" + cbb_TimKiem.Text+"'";
            DataTable btTimKiem = Functions.ReadData(sqlBtTimKiem);
            if(btTimKiem != null && btTimKiem.Rows.Count > 0 )
            {
                dgv_Loai.DataSource = btTimKiem;
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
