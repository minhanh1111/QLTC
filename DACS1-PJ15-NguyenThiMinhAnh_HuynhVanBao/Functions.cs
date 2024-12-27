using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace DACS1_PJ15_NguyenThiMinhAnh_HuynhVanBao
{
    internal class Functions
    {
        public static SqlConnection conn;

        
        public static string maHD {  get; set; }
        public static string maCN { get; set; }
        public static string maPN { get; set; }
        public static string nam { get; set; }

        public static void Connect(String maCN)
        {
            if (conn == null || conn.State != ConnectionState.Open)
            {
                conn = new SqlConnection();
                if (maCN == "CNCT")
                     conn.ConnectionString = @"Data Source=MINHANH\CN1_CT;Initial Catalog=QLTC;Persist Security Info=True;User ID=sa;Password=1111;";
                else if (maCN == "CNSG")
                    conn.ConnectionString = @"Data Source=MINHANH\CN2_SG;Initial Catalog=QLTC;Persist Security Info=True;User ID=sa;Password=1111;";
                else
                    conn.ConnectionString = @"Data Source=MINHANH\CHINHANHTONG;Initial Catalog=QLTC;Persist Security Info=True;User ID=sa;Password=1111;";
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    MessageBox.Show("Kết nối thành công");
                }
                else MessageBox.Show("Không thể kết nối với dữ liệu");
            }
        }
        public static void Disconnect()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
                conn.Dispose();
                conn = null;
            }
        }
        //thực hiện lệnh select trả về datatable
        public static DataTable ReadData(string sql)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            adapter.Fill(dt);
            return dt;
        }
        //thực hiện lệnh insert, update,...
        public static void ChangeData(string sql)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();
            cmd.Dispose();  
        }
            
        //đổ dữ liệu lên combobox
        public void FillCombobox(ComboBox comboBox, DataTable data, string displayMember, string valueMember)
        {
            comboBox.DataSource = data;
            comboBox.DisplayMember = displayMember;
            comboBox.ValueMember = valueMember;
        }
        //kiểm tra tính đầy đủ và hợp lệ
        public static bool CheckVAC(params string[] inputs)
        {
            foreach (string input in inputs)
            {
                if (string.IsNullOrEmpty(input))
                {
                    return false;
                }
                if (input.Trim().Length == 0)
                {
                    return false;
                }
            }
            return true;
        }
        
        //mã tài khoản tự tăng
        public static string TKAuto()
        {
            string sql = "SELECT * FROM TAIKHOAN";
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            adapter.Fill(dt);
            string MA_TK = "";
            if (dt.Rows.Count <= 0)
            {
                MA_TK = "TK01";
            }
            else
            {
                int k;
                MA_TK = "TK";
                k = Convert.ToInt32(dt.Rows[dt.Rows.Count - 1][0].ToString().Substring(2, dt.Rows[dt.Rows.Count - 1][0].ToString().Length -2));
                k += 1;
                if (k < 10)
                {
                    MA_TK += "0";
                }
                MA_TK += k.ToString();
            }
            return MA_TK;
        }

        public void showUC(UserControl userControl, Panel pn_Container)
        {
            pn_Container.Controls.Clear();
            userControl.Dock = DockStyle.Fill;
            pn_Container.Controls.Add(userControl);
        }

           
            public static void runSql(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, conn); // Doi tuong thuoc lop SqlCommand
            try
            {
                cmd.ExecuteNonQuery(); //Thuc hien cau lenh SQL
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            cmd.Dispose(); // Giai phong bo nho
            cmd = null;
        }
        public static string createKey(string prefix)
        {
            string key = prefix;
            string[] date = convertDateToddMMyyyy(DateTime.Now).Split('-'); //Chuyển ngày về dd/MM/yyy và đưa vào mảng

            if (Convert.ToInt16(date[0]) < 10)            //Nếu ngày hoặc tháng nhỏ hơn 10 thì thêm 0
                date[0] = "0" + date[0];
            if (Convert.ToInt16(date[1]) < 10)
                date[1] = "0" + date[1];

            key += date[0] + date[1] + date[2];             //Cộng ngày đã đổi vào chuỗi

            string[] time = DateTime.Now.ToLongTimeString().Split(':');

            if (Convert.ToInt16(time[0]) < 10)
                time[0] = "0" + time[0];

            key += time[0] + time[1] + time[2];            //Cộng giờ đã đổi vào chuỗi

            key = key.Remove(key.Length - 3, 3);                   //Xóa khoảng trắng và kí tự AM, PM
            return key;
        }
        public static string convertDateToddMMyyyy(DateTime dateTime)
        {
            string[] date = dateTime.ToShortDateString().Split('/');
            string dateConvert = date[1] + '-' + date[0] + '-' + date[2];

            return dateConvert;
        }
        public static void FillCombo(string sql, ComboBox cbo, string ma, string ten)
        {
            SqlDataAdapter Mydata = new SqlDataAdapter(sql, conn);
            DataTable table = new DataTable();
            Mydata.Fill(table);
            cbo.DataSource = table;
            cbo.ValueMember = ma;
            cbo.DisplayMember = ten;
        }
        public static string getValueByKey(string sql)
        {
            string data = "";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                data = reader.GetValue(0).ToString();
            }
            reader.Close();
            return data;

        }

        
    }
}

