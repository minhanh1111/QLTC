namespace DACS1_PJ15_NguyenThiMinhAnh_HuynhVanBao.UC_NhanVien
{
    partial class ChiNhanh
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChiNhanh));
            this.pn_Container = new System.Windows.Forms.Panel();
            this.lb_Header = new System.Windows.Forms.Label();
            this.dgv_ChiNhanh = new System.Windows.Forms.DataGridView();
            this.lb_ThongTinChiNhanh = new System.Windows.Forms.Label();
            this.pn_infor = new System.Windows.Forms.Panel();
            this.tb_DiaChi = new System.Windows.Forms.TextBox();
            this.btn_TimKiem = new System.Windows.Forms.Button();
            this.cbb_TimKiem = new System.Windows.Forms.ComboBox();
            this.bt_QuayLai = new System.Windows.Forms.Button();
            this.btn_Sua = new System.Windows.Forms.Button();
            this.btn_Them = new System.Windows.Forms.Button();
            this.tb_TenChiNhanh = new System.Windows.Forms.TextBox();
            this.tb_MaChiNhanh = new System.Windows.Forms.TextBox();
            this.lb_DiaChi = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_MaChiNhanh = new System.Windows.Forms.Label();
            this.pn_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ChiNhanh)).BeginInit();
            this.pn_infor.SuspendLayout();
            this.SuspendLayout();
            // 
            // pn_Container
            // 
            this.pn_Container.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(255)))), ((int)(((byte)(238)))));
            this.pn_Container.Controls.Add(this.lb_Header);
            this.pn_Container.Controls.Add(this.dgv_ChiNhanh);
            this.pn_Container.Controls.Add(this.lb_ThongTinChiNhanh);
            this.pn_Container.Controls.Add(this.pn_infor);
            this.pn_Container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pn_Container.Location = new System.Drawing.Point(0, 0);
            this.pn_Container.Name = "pn_Container";
            this.pn_Container.Size = new System.Drawing.Size(934, 540);
            this.pn_Container.TabIndex = 4;
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
            this.lb_Header.Text = "DANH SÁCH CHI NHÁNH";
            this.lb_Header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgv_ChiNhanh
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(255)))), ((int)(((byte)(157)))));
            this.dgv_ChiNhanh.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_ChiNhanh.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(255)))), ((int)(((byte)(238)))));
            this.dgv_ChiNhanh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_ChiNhanh.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_ChiNhanh.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgv_ChiNhanh.Location = new System.Drawing.Point(0, 273);
            this.dgv_ChiNhanh.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_ChiNhanh.Name = "dgv_ChiNhanh";
            this.dgv_ChiNhanh.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_ChiNhanh.Size = new System.Drawing.Size(934, 267);
            this.dgv_ChiNhanh.TabIndex = 10;
            this.dgv_ChiNhanh.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_ChiNhanh_CellClick);
            // 
            // lb_ThongTinChiNhanh
            // 
            this.lb_ThongTinChiNhanh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_ThongTinChiNhanh.AutoSize = true;
            this.lb_ThongTinChiNhanh.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_ThongTinChiNhanh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(10)))), ((int)(((byte)(255)))));
            this.lb_ThongTinChiNhanh.Location = new System.Drawing.Point(522, 348);
            this.lb_ThongTinChiNhanh.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_ThongTinChiNhanh.Name = "lb_ThongTinChiNhanh";
            this.lb_ThongTinChiNhanh.Size = new System.Drawing.Size(155, 18);
            this.lb_ThongTinChiNhanh.TabIndex = 9;
            this.lb_ThongTinChiNhanh.Text = "Thông tin chi nhánh";
            // 
            // pn_infor
            // 
            this.pn_infor.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pn_infor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(255)))), ((int)(((byte)(238)))));
            this.pn_infor.Controls.Add(this.tb_DiaChi);
            this.pn_infor.Controls.Add(this.btn_TimKiem);
            this.pn_infor.Controls.Add(this.cbb_TimKiem);
            this.pn_infor.Controls.Add(this.bt_QuayLai);
            this.pn_infor.Controls.Add(this.btn_Sua);
            this.pn_infor.Controls.Add(this.btn_Them);
            this.pn_infor.Controls.Add(this.tb_TenChiNhanh);
            this.pn_infor.Controls.Add(this.tb_MaChiNhanh);
            this.pn_infor.Controls.Add(this.lb_DiaChi);
            this.pn_infor.Controls.Add(this.label1);
            this.pn_infor.Controls.Add(this.lb_MaChiNhanh);
            this.pn_infor.Location = new System.Drawing.Point(0, 32);
            this.pn_infor.Margin = new System.Windows.Forms.Padding(4);
            this.pn_infor.Name = "pn_infor";
            this.pn_infor.Size = new System.Drawing.Size(934, 233);
            this.pn_infor.TabIndex = 8;
            // 
            // tb_DiaChi
            // 
            this.tb_DiaChi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_DiaChi.Location = new System.Drawing.Point(734, 61);
            this.tb_DiaChi.Margin = new System.Windows.Forms.Padding(4);
            this.tb_DiaChi.Name = "tb_DiaChi";
            this.tb_DiaChi.Size = new System.Drawing.Size(163, 22);
            this.tb_DiaChi.TabIndex = 123;
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
            // cbb_TimKiem
            // 
            this.cbb_TimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbb_TimKiem.FormattingEnabled = true;
            this.cbb_TimKiem.Location = new System.Drawing.Point(623, 177);
            this.cbb_TimKiem.Name = "cbb_TimKiem";
            this.cbb_TimKiem.Size = new System.Drawing.Size(153, 24);
            this.cbb_TimKiem.TabIndex = 111;
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
            this.btn_Sua.Location = new System.Drawing.Point(299, 169);
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
            // btn_Them
            // 
            this.btn_Them.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Them.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(239)))), ((int)(((byte)(254)))));
            this.btn_Them.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Them.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(10)))), ((int)(((byte)(255)))));
            this.btn_Them.Image = ((System.Drawing.Image)(resources.GetObject("btn_Them.Image")));
            this.btn_Them.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Them.Location = new System.Drawing.Point(106, 169);
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
            // tb_TenChiNhanh
            // 
            this.tb_TenChiNhanh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_TenChiNhanh.Location = new System.Drawing.Point(455, 58);
            this.tb_TenChiNhanh.Margin = new System.Windows.Forms.Padding(4);
            this.tb_TenChiNhanh.Name = "tb_TenChiNhanh";
            this.tb_TenChiNhanh.Size = new System.Drawing.Size(163, 22);
            this.tb_TenChiNhanh.TabIndex = 1;
            // 
            // tb_MaChiNhanh
            // 
            this.tb_MaChiNhanh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_MaChiNhanh.Location = new System.Drawing.Point(143, 58);
            this.tb_MaChiNhanh.Margin = new System.Windows.Forms.Padding(4);
            this.tb_MaChiNhanh.Name = "tb_MaChiNhanh";
            this.tb_MaChiNhanh.Size = new System.Drawing.Size(163, 22);
            this.tb_MaChiNhanh.TabIndex = 1;
            // 
            // lb_DiaChi
            // 
            this.lb_DiaChi.AutoSize = true;
            this.lb_DiaChi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_DiaChi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(10)))), ((int)(((byte)(255)))));
            this.lb_DiaChi.Location = new System.Drawing.Point(668, 64);
            this.lb_DiaChi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_DiaChi.Name = "lb_DiaChi";
            this.lb_DiaChi.Size = new System.Drawing.Size(58, 16);
            this.lb_DiaChi.TabIndex = 0;
            this.lb_DiaChi.Text = "Địa chỉ:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(10)))), ((int)(((byte)(255)))));
            this.label1.Location = new System.Drawing.Point(340, 64);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên chi nhánh:";
            // 
            // lb_MaChiNhanh
            // 
            this.lb_MaChiNhanh.AutoSize = true;
            this.lb_MaChiNhanh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_MaChiNhanh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(10)))), ((int)(((byte)(255)))));
            this.lb_MaChiNhanh.Location = new System.Drawing.Point(34, 64);
            this.lb_MaChiNhanh.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_MaChiNhanh.Name = "lb_MaChiNhanh";
            this.lb_MaChiNhanh.Size = new System.Drawing.Size(101, 16);
            this.lb_MaChiNhanh.TabIndex = 0;
            this.lb_MaChiNhanh.Text = "Mã chi nhánh:";
            // 
            // ChiNhanh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pn_Container);
            this.Name = "ChiNhanh";
            this.Size = new System.Drawing.Size(934, 540);
            this.Load += new System.EventHandler(this.ChiNhanh_Load);
            this.pn_Container.ResumeLayout(false);
            this.pn_Container.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ChiNhanh)).EndInit();
            this.pn_infor.ResumeLayout(false);
            this.pn_infor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pn_Container;
        private System.Windows.Forms.Label lb_Header;
        private System.Windows.Forms.DataGridView dgv_ChiNhanh;
        private System.Windows.Forms.Label lb_ThongTinChiNhanh;
        private System.Windows.Forms.Panel pn_infor;
        private System.Windows.Forms.TextBox tb_DiaChi;
        private System.Windows.Forms.Button btn_TimKiem;
        private System.Windows.Forms.ComboBox cbb_TimKiem;
        private System.Windows.Forms.Button bt_QuayLai;
        private System.Windows.Forms.Button btn_Sua;
        private System.Windows.Forms.Button btn_Them;
        private System.Windows.Forms.TextBox tb_TenChiNhanh;
        private System.Windows.Forms.TextBox tb_MaChiNhanh;
        private System.Windows.Forms.Label lb_DiaChi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_MaChiNhanh;
    }
}
