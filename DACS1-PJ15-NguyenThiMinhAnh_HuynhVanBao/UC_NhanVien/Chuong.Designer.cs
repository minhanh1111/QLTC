namespace DACS1_PJ15_NguyenThiMinhAnh_HuynhVanBao.UC_NhanVien
{
    partial class Chuong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Chuong));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btn_TimKiem = new System.Windows.Forms.Button();
            this.cbb_TinhTrang = new System.Windows.Forms.ComboBox();
            this.cbb_TimKiem = new System.Windows.Forms.ComboBox();
            this.pn_Container = new System.Windows.Forms.Panel();
            this.lb_Thoat = new System.Windows.Forms.Label();
            this.lb_Header = new System.Windows.Forms.Label();
            this.dgv_Chuong = new System.Windows.Forms.DataGridView();
            this.lb_ThongTinChuong = new System.Windows.Forms.Label();
            this.pn_infor = new System.Windows.Forms.Panel();
            this.bt_QuayLai = new System.Windows.Forms.Button();
            this.btn_Sua = new System.Windows.Forms.Button();
            this.btn_Xoa = new System.Windows.Forms.Button();
            this.btn_Them = new System.Windows.Forms.Button();
            this.tb_Chuong = new System.Windows.Forms.TextBox();
            this.lb_TinhTrang = new System.Windows.Forms.Label();
            this.lb_MaChuong = new System.Windows.Forms.Label();
            this.pn_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Chuong)).BeginInit();
            this.pn_infor.SuspendLayout();
            this.SuspendLayout();
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
            this.btn_TimKiem.Location = new System.Drawing.Point(783, 164);
            this.btn_TimKiem.Margin = new System.Windows.Forms.Padding(4);
            this.btn_TimKiem.Name = "btn_TimKiem";
            this.btn_TimKiem.Size = new System.Drawing.Size(129, 37);
            this.btn_TimKiem.TabIndex = 122;
            this.btn_TimKiem.Text = "Tìm kiếm";
            this.btn_TimKiem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_TimKiem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_TimKiem.UseVisualStyleBackColor = false;
            this.btn_TimKiem.Click += new System.EventHandler(this.btn_TimKiem_Click);
            // 
            // cbb_TinhTrang
            // 
            this.cbb_TinhTrang.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbb_TinhTrang.FormattingEnabled = true;
            this.cbb_TinhTrang.Location = new System.Drawing.Point(671, 58);
            this.cbb_TinhTrang.Margin = new System.Windows.Forms.Padding(4);
            this.cbb_TinhTrang.Name = "cbb_TinhTrang";
            this.cbb_TinhTrang.Size = new System.Drawing.Size(163, 24);
            this.cbb_TinhTrang.TabIndex = 121;
            // 
            // cbb_TimKiem
            // 
            this.cbb_TimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbb_TimKiem.FormattingEnabled = true;
            this.cbb_TimKiem.Location = new System.Drawing.Point(623, 177);
            this.cbb_TimKiem.Name = "cbb_TimKiem";
            this.cbb_TimKiem.Size = new System.Drawing.Size(153, 24);
            this.cbb_TimKiem.TabIndex = 111;
            // 
            // pn_Container
            // 
            this.pn_Container.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(255)))), ((int)(((byte)(238)))));
            this.pn_Container.Controls.Add(this.lb_Thoat);
            this.pn_Container.Controls.Add(this.lb_Header);
            this.pn_Container.Controls.Add(this.dgv_Chuong);
            this.pn_Container.Controls.Add(this.lb_ThongTinChuong);
            this.pn_Container.Controls.Add(this.pn_infor);
            this.pn_Container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pn_Container.Location = new System.Drawing.Point(0, 0);
            this.pn_Container.Name = "pn_Container";
            this.pn_Container.Size = new System.Drawing.Size(934, 540);
            this.pn_Container.TabIndex = 2;
            // 
            // lb_Thoat
            // 
            this.lb_Thoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_Thoat.AutoSize = true;
            this.lb_Thoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Thoat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(2)))), ((int)(((byte)(2)))));
            this.lb_Thoat.Location = new System.Drawing.Point(918, 10);
            this.lb_Thoat.Name = "lb_Thoat";
            this.lb_Thoat.Size = new System.Drawing.Size(16, 16);
            this.lb_Thoat.TabIndex = 111;
            this.lb_Thoat.Text = "X";
            this.lb_Thoat.Click += new System.EventHandler(this.lb_Thoat_Click);
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
            this.lb_Header.TabIndex = 15;
            this.lb_Header.Text = "DANH SÁCH CHUỒNG";
            this.lb_Header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgv_Chuong
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(255)))), ((int)(((byte)(157)))));
            this.dgv_Chuong.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Chuong.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(255)))), ((int)(((byte)(238)))));
            this.dgv_Chuong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Chuong.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_Chuong.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgv_Chuong.Location = new System.Drawing.Point(0, 273);
            this.dgv_Chuong.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_Chuong.Name = "dgv_Chuong";
            this.dgv_Chuong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Chuong.Size = new System.Drawing.Size(934, 267);
            this.dgv_Chuong.TabIndex = 10;
            this.dgv_Chuong.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Chuong_CellClick);
            // 
            // lb_ThongTinChuong
            // 
            this.lb_ThongTinChuong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_ThongTinChuong.AutoSize = true;
            this.lb_ThongTinChuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_ThongTinChuong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(10)))), ((int)(((byte)(255)))));
            this.lb_ThongTinChuong.Location = new System.Drawing.Point(522, 348);
            this.lb_ThongTinChuong.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_ThongTinChuong.Name = "lb_ThongTinChuong";
            this.lb_ThongTinChuong.Size = new System.Drawing.Size(138, 18);
            this.lb_ThongTinChuong.TabIndex = 9;
            this.lb_ThongTinChuong.Text = "Thông tin chuồng";
            // 
            // pn_infor
            // 
            this.pn_infor.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pn_infor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(255)))), ((int)(((byte)(238)))));
            this.pn_infor.Controls.Add(this.btn_TimKiem);
            this.pn_infor.Controls.Add(this.cbb_TinhTrang);
            this.pn_infor.Controls.Add(this.cbb_TimKiem);
            this.pn_infor.Controls.Add(this.bt_QuayLai);
            this.pn_infor.Controls.Add(this.btn_Sua);
            this.pn_infor.Controls.Add(this.btn_Xoa);
            this.pn_infor.Controls.Add(this.btn_Them);
            this.pn_infor.Controls.Add(this.tb_Chuong);
            this.pn_infor.Controls.Add(this.lb_TinhTrang);
            this.pn_infor.Controls.Add(this.lb_MaChuong);
            this.pn_infor.Location = new System.Drawing.Point(0, 32);
            this.pn_infor.Margin = new System.Windows.Forms.Padding(4);
            this.pn_infor.Name = "pn_infor";
            this.pn_infor.Size = new System.Drawing.Size(934, 233);
            this.pn_infor.TabIndex = 8;
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
            this.bt_QuayLai.Location = new System.Drawing.Point(472, 169);
            this.bt_QuayLai.Margin = new System.Windows.Forms.Padding(4);
            this.bt_QuayLai.Name = "bt_QuayLai";
            this.bt_QuayLai.Size = new System.Drawing.Size(113, 37);
            this.bt_QuayLai.TabIndex = 103;
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
            this.btn_Sua.Location = new System.Drawing.Point(318, 169);
            this.btn_Sua.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Sua.Name = "btn_Sua";
            this.btn_Sua.Size = new System.Drawing.Size(100, 37);
            this.btn_Sua.TabIndex = 104;
            this.btn_Sua.Text = "Sửa";
            this.btn_Sua.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Sua.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Sua.UseVisualStyleBackColor = false;
            this.btn_Sua.Click += new System.EventHandler(this.btn_Sua_Click);
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
            this.btn_Xoa.Location = new System.Drawing.Point(164, 169);
            this.btn_Xoa.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Xoa.Name = "btn_Xoa";
            this.btn_Xoa.Size = new System.Drawing.Size(100, 37);
            this.btn_Xoa.TabIndex = 106;
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
            this.btn_Them.Location = new System.Drawing.Point(8, 169);
            this.btn_Them.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Them.Name = "btn_Them";
            this.btn_Them.Size = new System.Drawing.Size(100, 37);
            this.btn_Them.TabIndex = 107;
            this.btn_Them.Text = "Thêm";
            this.btn_Them.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Them.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Them.UseVisualStyleBackColor = false;
            this.btn_Them.Click += new System.EventHandler(this.btn_Them_Click);
            // 
            // tb_Chuong
            // 
            this.tb_Chuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_Chuong.Location = new System.Drawing.Point(193, 58);
            this.tb_Chuong.Margin = new System.Windows.Forms.Padding(4);
            this.tb_Chuong.Name = "tb_Chuong";
            this.tb_Chuong.Size = new System.Drawing.Size(163, 22);
            this.tb_Chuong.TabIndex = 1;
            // 
            // lb_TinhTrang
            // 
            this.lb_TinhTrang.AutoSize = true;
            this.lb_TinhTrang.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_TinhTrang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(10)))), ((int)(((byte)(255)))));
            this.lb_TinhTrang.Location = new System.Drawing.Point(580, 64);
            this.lb_TinhTrang.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_TinhTrang.Name = "lb_TinhTrang";
            this.lb_TinhTrang.Size = new System.Drawing.Size(80, 16);
            this.lb_TinhTrang.TabIndex = 0;
            this.lb_TinhTrang.Text = "Tình trạng:";
            // 
            // lb_MaChuong
            // 
            this.lb_MaChuong.AutoSize = true;
            this.lb_MaChuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_MaChuong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(10)))), ((int)(((byte)(255)))));
            this.lb_MaChuong.Location = new System.Drawing.Point(98, 64);
            this.lb_MaChuong.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_MaChuong.Name = "lb_MaChuong";
            this.lb_MaChuong.Size = new System.Drawing.Size(86, 16);
            this.lb_MaChuong.TabIndex = 0;
            this.lb_MaChuong.Text = "Mã chuồng:";
            // 
            // Chuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pn_Container);
            this.Name = "Chuong";
            this.Size = new System.Drawing.Size(934, 540);
            this.Load += new System.EventHandler(this.Chuong_Load);
            this.pn_Container.ResumeLayout(false);
            this.pn_Container.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Chuong)).EndInit();
            this.pn_infor.ResumeLayout(false);
            this.pn_infor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_TimKiem;
        private System.Windows.Forms.ComboBox cbb_TinhTrang;
        private System.Windows.Forms.ComboBox cbb_TimKiem;
        private System.Windows.Forms.Panel pn_Container;
        private System.Windows.Forms.Label lb_Header;
        private System.Windows.Forms.DataGridView dgv_Chuong;
        private System.Windows.Forms.Label lb_ThongTinChuong;
        private System.Windows.Forms.Panel pn_infor;
        private System.Windows.Forms.Button bt_QuayLai;
        private System.Windows.Forms.Button btn_Sua;
        private System.Windows.Forms.Button btn_Xoa;
        private System.Windows.Forms.Button btn_Them;
        private System.Windows.Forms.TextBox tb_Chuong;
        private System.Windows.Forms.Label lb_TinhTrang;
        private System.Windows.Forms.Label lb_MaChuong;
        private System.Windows.Forms.Label lb_Thoat;
    }
}
