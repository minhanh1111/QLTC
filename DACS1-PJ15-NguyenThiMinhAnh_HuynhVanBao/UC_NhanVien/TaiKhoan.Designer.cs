namespace DACS1_PJ15_NguyenThiMinhAnh_HuynhVanBao.UC_QuanLy
{
    partial class TaiKhoan
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaiKhoan));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lb_HoTenNhanVien = new System.Windows.Forms.Label();
            this.cbb_TimKiem = new System.Windows.Forms.ComboBox();
            this.cbb_HoTenNhanVien = new System.Windows.Forms.ComboBox();
            this.cbb_Quyen = new System.Windows.Forms.ComboBox();
            this.tb_MatKhau = new System.Windows.Forms.TextBox();
            this.tb_TenTaiKhoan = new System.Windows.Forms.TextBox();
            this.tb_MaTaiKhoan = new System.Windows.Forms.TextBox();
            this.lb_ChucVu = new System.Windows.Forms.Label();
            this.lb_MatKhau = new System.Windows.Forms.Label();
            this.lb_TenTaiKhoan = new System.Windows.Forms.Label();
            this.lb_MaTaiKhoan = new System.Windows.Forms.Label();
            this.bt_QuayLai = new System.Windows.Forms.Button();
            this.btn_Sua = new System.Windows.Forms.Button();
            this.lb_ThôngTinTaiKhoan = new System.Windows.Forms.Label();
            this.pn_Container = new System.Windows.Forms.Panel();
            this.lb_Header = new System.Windows.Forms.Label();
            this.dgv_TaiKhoan = new System.Windows.Forms.DataGridView();
            this.pn_Infor = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_TimKiem = new System.Windows.Forms.Button();
            this.btn_Xoa = new System.Windows.Forms.Button();
            this.btn_Them = new System.Windows.Forms.Button();
            this.pn_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_TaiKhoan)).BeginInit();
            this.pn_Infor.SuspendLayout();
            this.SuspendLayout();
            // 
            // lb_HoTenNhanVien
            // 
            this.lb_HoTenNhanVien.AutoSize = true;
            this.lb_HoTenNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_HoTenNhanVien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(10)))), ((int)(((byte)(255)))));
            this.lb_HoTenNhanVien.Location = new System.Drawing.Point(342, 38);
            this.lb_HoTenNhanVien.Name = "lb_HoTenNhanVien";
            this.lb_HoTenNhanVien.Size = new System.Drawing.Size(117, 18);
            this.lb_HoTenNhanVien.TabIndex = 121;
            this.lb_HoTenNhanVien.Text = "Tên nhân viên:";
            // 
            // cbb_TimKiem
            // 
            this.cbb_TimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbb_TimKiem.FormattingEnabled = true;
            this.cbb_TimKiem.Location = new System.Drawing.Point(640, 194);
            this.cbb_TimKiem.Margin = new System.Windows.Forms.Padding(4);
            this.cbb_TimKiem.Name = "cbb_TimKiem";
            this.cbb_TimKiem.Size = new System.Drawing.Size(153, 24);
            this.cbb_TimKiem.TabIndex = 120;
            // 
            // cbb_HoTenNhanVien
            // 
            this.cbb_HoTenNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbb_HoTenNhanVien.FormattingEnabled = true;
            this.cbb_HoTenNhanVien.Location = new System.Drawing.Point(461, 32);
            this.cbb_HoTenNhanVien.Margin = new System.Windows.Forms.Padding(4);
            this.cbb_HoTenNhanVien.Name = "cbb_HoTenNhanVien";
            this.cbb_HoTenNhanVien.Size = new System.Drawing.Size(163, 24);
            this.cbb_HoTenNhanVien.TabIndex = 120;
            // 
            // cbb_Quyen
            // 
            this.cbb_Quyen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbb_Quyen.FormattingEnabled = true;
            this.cbb_Quyen.Location = new System.Drawing.Point(746, 32);
            this.cbb_Quyen.Margin = new System.Windows.Forms.Padding(4);
            this.cbb_Quyen.Name = "cbb_Quyen";
            this.cbb_Quyen.Size = new System.Drawing.Size(163, 24);
            this.cbb_Quyen.TabIndex = 120;
            this.cbb_Quyen.DropDown += new System.EventHandler(this.cbb_Quyen_DropDown);
            // 
            // tb_MatKhau
            // 
            this.tb_MatKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_MatKhau.Location = new System.Drawing.Point(461, 121);
            this.tb_MatKhau.Margin = new System.Windows.Forms.Padding(4);
            this.tb_MatKhau.Name = "tb_MatKhau";
            this.tb_MatKhau.Size = new System.Drawing.Size(163, 22);
            this.tb_MatKhau.TabIndex = 117;
            // 
            // tb_TenTaiKhoan
            // 
            this.tb_TenTaiKhoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_TenTaiKhoan.Location = new System.Drawing.Point(137, 121);
            this.tb_TenTaiKhoan.Margin = new System.Windows.Forms.Padding(4);
            this.tb_TenTaiKhoan.Name = "tb_TenTaiKhoan";
            this.tb_TenTaiKhoan.Size = new System.Drawing.Size(163, 22);
            this.tb_TenTaiKhoan.TabIndex = 118;
            // 
            // tb_MaTaiKhoan
            // 
            this.tb_MaTaiKhoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_MaTaiKhoan.Location = new System.Drawing.Point(137, 34);
            this.tb_MaTaiKhoan.Margin = new System.Windows.Forms.Padding(4);
            this.tb_MaTaiKhoan.Name = "tb_MaTaiKhoan";
            this.tb_MaTaiKhoan.Size = new System.Drawing.Size(163, 22);
            this.tb_MaTaiKhoan.TabIndex = 118;
            // 
            // lb_ChucVu
            // 
            this.lb_ChucVu.AutoSize = true;
            this.lb_ChucVu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_ChucVu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(10)))), ((int)(((byte)(255)))));
            this.lb_ChucVu.Location = new System.Drawing.Point(672, 38);
            this.lb_ChucVu.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_ChucVu.Name = "lb_ChucVu";
            this.lb_ChucVu.Size = new System.Drawing.Size(65, 16);
            this.lb_ChucVu.TabIndex = 115;
            this.lb_ChucVu.Text = "Chức vụ:";
            // 
            // lb_MatKhau
            // 
            this.lb_MatKhau.AutoSize = true;
            this.lb_MatKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_MatKhau.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(10)))), ((int)(((byte)(255)))));
            this.lb_MatKhau.Location = new System.Drawing.Point(342, 125);
            this.lb_MatKhau.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_MatKhau.Name = "lb_MatKhau";
            this.lb_MatKhau.Size = new System.Drawing.Size(73, 16);
            this.lb_MatKhau.TabIndex = 115;
            this.lb_MatKhau.Text = "Mật khẩu:";
            // 
            // lb_TenTaiKhoan
            // 
            this.lb_TenTaiKhoan.AutoSize = true;
            this.lb_TenTaiKhoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_TenTaiKhoan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(10)))), ((int)(((byte)(255)))));
            this.lb_TenTaiKhoan.Location = new System.Drawing.Point(24, 125);
            this.lb_TenTaiKhoan.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_TenTaiKhoan.Name = "lb_TenTaiKhoan";
            this.lb_TenTaiKhoan.Size = new System.Drawing.Size(105, 16);
            this.lb_TenTaiKhoan.TabIndex = 116;
            this.lb_TenTaiKhoan.Text = "Tên tài khoản:";
            // 
            // lb_MaTaiKhoan
            // 
            this.lb_MaTaiKhoan.AutoSize = true;
            this.lb_MaTaiKhoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_MaTaiKhoan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(10)))), ((int)(((byte)(255)))));
            this.lb_MaTaiKhoan.Location = new System.Drawing.Point(24, 38);
            this.lb_MaTaiKhoan.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_MaTaiKhoan.Name = "lb_MaTaiKhoan";
            this.lb_MaTaiKhoan.Size = new System.Drawing.Size(99, 16);
            this.lb_MaTaiKhoan.TabIndex = 116;
            this.lb_MaTaiKhoan.Text = "Mã tài khoản:";
            // 
            // bt_QuayLai
            // 
            this.bt_QuayLai.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_QuayLai.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(239)))), ((int)(((byte)(254)))));
            this.bt_QuayLai.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_QuayLai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(10)))), ((int)(((byte)(255)))));
            this.bt_QuayLai.Image = ((System.Drawing.Image)(resources.GetObject("bt_QuayLai.Image")));
            this.bt_QuayLai.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_QuayLai.Location = new System.Drawing.Point(365, 185);
            this.bt_QuayLai.Margin = new System.Windows.Forms.Padding(4);
            this.bt_QuayLai.Name = "bt_QuayLai";
            this.bt_QuayLai.Size = new System.Drawing.Size(113, 37);
            this.bt_QuayLai.TabIndex = 109;
            this.bt_QuayLai.Text = "Quay lại";
            this.bt_QuayLai.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_QuayLai.UseVisualStyleBackColor = false;
            this.bt_QuayLai.Click += new System.EventHandler(this.bt_QuayLai_Click);
            // 
            // btn_Sua
            // 
            this.btn_Sua.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Sua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(239)))), ((int)(((byte)(254)))));
            this.btn_Sua.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Sua.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(10)))), ((int)(((byte)(255)))));
            this.btn_Sua.Image = ((System.Drawing.Image)(resources.GetObject("btn_Sua.Image")));
            this.btn_Sua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Sua.Location = new System.Drawing.Point(244, 185);
            this.btn_Sua.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Sua.Name = "btn_Sua";
            this.btn_Sua.Size = new System.Drawing.Size(100, 37);
            this.btn_Sua.TabIndex = 110;
            this.btn_Sua.Text = "Sửa";
            this.btn_Sua.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Sua.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Sua.UseVisualStyleBackColor = false;
            this.btn_Sua.Click += new System.EventHandler(this.btn_Sua_Click);
            // 
            // lb_ThôngTinTaiKhoan
            // 
            this.lb_ThôngTinTaiKhoan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_ThôngTinTaiKhoan.AutoSize = true;
            this.lb_ThôngTinTaiKhoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_ThôngTinTaiKhoan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(10)))), ((int)(((byte)(255)))));
            this.lb_ThôngTinTaiKhoan.Location = new System.Drawing.Point(510, 344);
            this.lb_ThôngTinTaiKhoan.Name = "lb_ThôngTinTaiKhoan";
            this.lb_ThôngTinTaiKhoan.Size = new System.Drawing.Size(163, 20);
            this.lb_ThôngTinTaiKhoan.TabIndex = 25;
            this.lb_ThôngTinTaiKhoan.Text = "Thông tin tài khoản";
            this.lb_ThôngTinTaiKhoan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pn_Container
            // 
            this.pn_Container.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(255)))), ((int)(((byte)(238)))));
            this.pn_Container.Controls.Add(this.lb_Header);
            this.pn_Container.Controls.Add(this.dgv_TaiKhoan);
            this.pn_Container.Controls.Add(this.lb_ThôngTinTaiKhoan);
            this.pn_Container.Controls.Add(this.pn_Infor);
            this.pn_Container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pn_Container.Location = new System.Drawing.Point(0, 0);
            this.pn_Container.Name = "pn_Container";
            this.pn_Container.Size = new System.Drawing.Size(934, 550);
            this.pn_Container.TabIndex = 2;
            // 
            // lb_Header
            // 
            this.lb_Header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(255)))), ((int)(((byte)(231)))));
            this.lb_Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.lb_Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Header.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(10)))), ((int)(((byte)(255)))));
            this.lb_Header.Location = new System.Drawing.Point(0, 0);
            this.lb_Header.Name = "lb_Header";
            this.lb_Header.Size = new System.Drawing.Size(934, 32);
            this.lb_Header.TabIndex = 27;
            this.lb_Header.Text = "DANH SÁCH TÀI KHOẢN";
            this.lb_Header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgv_TaiKhoan
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(255)))), ((int)(((byte)(157)))));
            this.dgv_TaiKhoan.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_TaiKhoan.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(255)))), ((int)(((byte)(238)))));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_TaiKhoan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_TaiKhoan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_TaiKhoan.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_TaiKhoan.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgv_TaiKhoan.Location = new System.Drawing.Point(0, 282);
            this.dgv_TaiKhoan.Name = "dgv_TaiKhoan";
            this.dgv_TaiKhoan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_TaiKhoan.Size = new System.Drawing.Size(934, 268);
            this.dgv_TaiKhoan.TabIndex = 26;
            this.dgv_TaiKhoan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_TaiKhoan_CellClick);
            // 
            // pn_Infor
            // 
            this.pn_Infor.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pn_Infor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(255)))), ((int)(((byte)(238)))));
            this.pn_Infor.Controls.Add(this.button1);
            this.pn_Infor.Controls.Add(this.lb_HoTenNhanVien);
            this.pn_Infor.Controls.Add(this.cbb_TimKiem);
            this.pn_Infor.Controls.Add(this.cbb_HoTenNhanVien);
            this.pn_Infor.Controls.Add(this.cbb_Quyen);
            this.pn_Infor.Controls.Add(this.tb_MatKhau);
            this.pn_Infor.Controls.Add(this.tb_TenTaiKhoan);
            this.pn_Infor.Controls.Add(this.tb_MaTaiKhoan);
            this.pn_Infor.Controls.Add(this.lb_ChucVu);
            this.pn_Infor.Controls.Add(this.lb_MatKhau);
            this.pn_Infor.Controls.Add(this.lb_TenTaiKhoan);
            this.pn_Infor.Controls.Add(this.lb_MaTaiKhoan);
            this.pn_Infor.Controls.Add(this.bt_QuayLai);
            this.pn_Infor.Controls.Add(this.btn_Sua);
            this.pn_Infor.Controls.Add(this.btn_TimKiem);
            this.pn_Infor.Controls.Add(this.btn_Xoa);
            this.pn_Infor.Controls.Add(this.btn_Them);
            this.pn_Infor.Location = new System.Drawing.Point(0, 32);
            this.pn_Infor.Name = "pn_Infor";
            this.pn_Infor.Size = new System.Drawing.Size(934, 244);
            this.pn_Infor.TabIndex = 24;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(239)))), ((int)(((byte)(254)))));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(10)))), ((int)(((byte)(255)))));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(498, 185);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 37);
            this.button1.TabIndex = 122;
            this.button1.Text = "Nhân viên";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_TimKiem
            // 
            this.btn_TimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_TimKiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(239)))), ((int)(((byte)(254)))));
            this.btn_TimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_TimKiem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(10)))), ((int)(((byte)(255)))));
            this.btn_TimKiem.Image = ((System.Drawing.Image)(resources.GetObject("btn_TimKiem.Image")));
            this.btn_TimKiem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_TimKiem.Location = new System.Drawing.Point(796, 185);
            this.btn_TimKiem.Margin = new System.Windows.Forms.Padding(4);
            this.btn_TimKiem.Name = "btn_TimKiem";
            this.btn_TimKiem.Size = new System.Drawing.Size(129, 37);
            this.btn_TimKiem.TabIndex = 111;
            this.btn_TimKiem.Text = "Tìm kiếm";
            this.btn_TimKiem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_TimKiem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_TimKiem.UseVisualStyleBackColor = false;
            this.btn_TimKiem.Click += new System.EventHandler(this.btn_TimKiem_Click);
            // 
            // btn_Xoa
            // 
            this.btn_Xoa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Xoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(239)))), ((int)(((byte)(254)))));
            this.btn_Xoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Xoa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(10)))), ((int)(((byte)(255)))));
            this.btn_Xoa.Image = ((System.Drawing.Image)(resources.GetObject("btn_Xoa.Image")));
            this.btn_Xoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Xoa.Location = new System.Drawing.Point(125, 185);
            this.btn_Xoa.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Xoa.Name = "btn_Xoa";
            this.btn_Xoa.Size = new System.Drawing.Size(100, 37);
            this.btn_Xoa.TabIndex = 112;
            this.btn_Xoa.Text = "Xóa";
            this.btn_Xoa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Xoa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Xoa.UseVisualStyleBackColor = false;
            this.btn_Xoa.Click += new System.EventHandler(this.btn_Xoa_Click);
            // 
            // btn_Them
            // 
            this.btn_Them.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Them.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(239)))), ((int)(((byte)(254)))));
            this.btn_Them.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Them.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(10)))), ((int)(((byte)(255)))));
            this.btn_Them.Image = ((System.Drawing.Image)(resources.GetObject("btn_Them.Image")));
            this.btn_Them.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Them.Location = new System.Drawing.Point(8, 185);
            this.btn_Them.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Them.Name = "btn_Them";
            this.btn_Them.Size = new System.Drawing.Size(100, 37);
            this.btn_Them.TabIndex = 113;
            this.btn_Them.Text = "Thêm";
            this.btn_Them.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Them.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Them.UseVisualStyleBackColor = false;
            this.btn_Them.Click += new System.EventHandler(this.btn_Them_Click);
            // 
            // TaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pn_Container);
            this.Name = "TaiKhoan";
            this.Size = new System.Drawing.Size(934, 550);
            this.Load += new System.EventHandler(this.TaiKhoan_Load);
            this.pn_Container.ResumeLayout(false);
            this.pn_Container.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_TaiKhoan)).EndInit();
            this.pn_Infor.ResumeLayout(false);
            this.pn_Infor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lb_HoTenNhanVien;
        private System.Windows.Forms.ComboBox cbb_TimKiem;
        private System.Windows.Forms.ComboBox cbb_HoTenNhanVien;
        private System.Windows.Forms.ComboBox cbb_Quyen;
        private System.Windows.Forms.TextBox tb_MatKhau;
        private System.Windows.Forms.TextBox tb_TenTaiKhoan;
        private System.Windows.Forms.TextBox tb_MaTaiKhoan;
        private System.Windows.Forms.Label lb_ChucVu;
        private System.Windows.Forms.Label lb_MatKhau;
        private System.Windows.Forms.Label lb_TenTaiKhoan;
        private System.Windows.Forms.Label lb_MaTaiKhoan;
        private System.Windows.Forms.Button bt_QuayLai;
        private System.Windows.Forms.Button btn_Sua;
        private System.Windows.Forms.Label lb_ThôngTinTaiKhoan;
        private System.Windows.Forms.Panel pn_Container;
        private System.Windows.Forms.Label lb_Header;
        private System.Windows.Forms.DataGridView dgv_TaiKhoan;
        private System.Windows.Forms.Panel pn_Infor;
        private System.Windows.Forms.Button btn_TimKiem;
        private System.Windows.Forms.Button btn_Xoa;
        private System.Windows.Forms.Button btn_Them;
        private System.Windows.Forms.Button button1;
    }
}
