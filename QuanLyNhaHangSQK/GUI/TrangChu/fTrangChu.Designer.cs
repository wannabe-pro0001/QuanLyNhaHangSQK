
namespace QuanLyNhaHangSQK
{
    partial class fTrangChu
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fTrangChu));
            this.btnQuanLy = new System.Windows.Forms.Button();
            this.btnThuNgan = new System.Windows.Forms.Button();
            this.btnNhaBep = new System.Windows.Forms.Button();
            this.txtTenND = new System.Windows.Forms.TextBox();
            this.lbThongTinCaNhan = new System.Windows.Forms.Label();
            this.lbDoiMatKhau = new System.Windows.Forms.Label();
            this.lbDangXuat = new System.Windows.Forms.Label();
            this.ptExit = new System.Windows.Forms.PictureBox();
            this.formTrangChu = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ptExit)).BeginInit();
            this.SuspendLayout();
            // 
            // btnQuanLy
            // 
            this.btnQuanLy.BackColor = System.Drawing.Color.Transparent;
            this.btnQuanLy.BackgroundImage = global::QuanLyNhaHangSQK.Properties.Resources.btnTrangChu2;
            this.btnQuanLy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnQuanLy.FlatAppearance.BorderSize = 0;
            this.btnQuanLy.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnQuanLy.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnQuanLy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuanLy.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuanLy.ForeColor = System.Drawing.Color.White;
            this.btnQuanLy.Location = new System.Drawing.Point(607, 279);
            this.btnQuanLy.Name = "btnQuanLy";
            this.btnQuanLy.Size = new System.Drawing.Size(163, 48);
            this.btnQuanLy.TabIndex = 1;
            this.btnQuanLy.Text = "Quản lý";
            this.btnQuanLy.UseVisualStyleBackColor = false;
            this.btnQuanLy.Click += new System.EventHandler(this.btnQuanLy_Click);
            this.btnQuanLy.MouseLeave += new System.EventHandler(this.btnQuanLy_MouseLeave);
            this.btnQuanLy.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnQuanLy_MouseMove);
            // 
            // btnThuNgan
            // 
            this.btnThuNgan.BackColor = System.Drawing.Color.Transparent;
            this.btnThuNgan.BackgroundImage = global::QuanLyNhaHangSQK.Properties.Resources.btnTrangChu2;
            this.btnThuNgan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnThuNgan.FlatAppearance.BorderSize = 0;
            this.btnThuNgan.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnThuNgan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnThuNgan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThuNgan.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThuNgan.ForeColor = System.Drawing.Color.White;
            this.btnThuNgan.Location = new System.Drawing.Point(607, 352);
            this.btnThuNgan.Name = "btnThuNgan";
            this.btnThuNgan.Size = new System.Drawing.Size(163, 48);
            this.btnThuNgan.TabIndex = 2;
            this.btnThuNgan.Text = "Thu ngân";
            this.btnThuNgan.UseVisualStyleBackColor = false;
            this.btnThuNgan.Click += new System.EventHandler(this.btnThuNgan_Click);
            this.btnThuNgan.MouseLeave += new System.EventHandler(this.btnThuNgan_MouseLeave);
            this.btnThuNgan.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnThuNgan_MouseMove);
            // 
            // btnNhaBep
            // 
            this.btnNhaBep.BackColor = System.Drawing.Color.Transparent;
            this.btnNhaBep.BackgroundImage = global::QuanLyNhaHangSQK.Properties.Resources.btnTrangChu2;
            this.btnNhaBep.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNhaBep.FlatAppearance.BorderSize = 0;
            this.btnNhaBep.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnNhaBep.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnNhaBep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNhaBep.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNhaBep.ForeColor = System.Drawing.Color.White;
            this.btnNhaBep.Location = new System.Drawing.Point(607, 426);
            this.btnNhaBep.Name = "btnNhaBep";
            this.btnNhaBep.Size = new System.Drawing.Size(163, 48);
            this.btnNhaBep.TabIndex = 3;
            this.btnNhaBep.Text = "Nhà bếp";
            this.btnNhaBep.UseVisualStyleBackColor = false;
            this.btnNhaBep.Click += new System.EventHandler(this.btnNhaBep_Click);
            this.btnNhaBep.MouseLeave += new System.EventHandler(this.btnNhaBep_MouseLeave);
            this.btnNhaBep.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnNhaBep_MouseMove);
            // 
            // txtTenND
            // 
            this.txtTenND.BackColor = System.Drawing.Color.White;
            this.txtTenND.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTenND.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenND.ForeColor = System.Drawing.Color.Black;
            this.txtTenND.Location = new System.Drawing.Point(0, 72);
            this.txtTenND.Multiline = true;
            this.txtTenND.Name = "txtTenND";
            this.txtTenND.ReadOnly = true;
            this.txtTenND.Size = new System.Drawing.Size(308, 34);
            this.txtTenND.TabIndex = 3;
            this.txtTenND.Text = "Xin chào\r\nAdmin";
            this.txtTenND.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbThongTinCaNhan
            // 
            this.lbThongTinCaNhan.AutoSize = true;
            this.lbThongTinCaNhan.BackColor = System.Drawing.Color.Transparent;
            this.lbThongTinCaNhan.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbThongTinCaNhan.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbThongTinCaNhan.Location = new System.Drawing.Point(12, 279);
            this.lbThongTinCaNhan.Name = "lbThongTinCaNhan";
            this.lbThongTinCaNhan.Size = new System.Drawing.Size(151, 19);
            this.lbThongTinCaNhan.TabIndex = 4;
            this.lbThongTinCaNhan.Text = "Thông tin cá nhân";
            this.lbThongTinCaNhan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbThongTinCaNhan.Click += new System.EventHandler(this.lbThongTinCaNhan_Click);
            this.lbThongTinCaNhan.MouseLeave += new System.EventHandler(this.lbThongTinCaNhan_MouseLeave);
            this.lbThongTinCaNhan.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lbThongTinCaNhan_MouseMove);
            // 
            // lbDoiMatKhau
            // 
            this.lbDoiMatKhau.AutoSize = true;
            this.lbDoiMatKhau.BackColor = System.Drawing.Color.Transparent;
            this.lbDoiMatKhau.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDoiMatKhau.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbDoiMatKhau.Location = new System.Drawing.Point(12, 310);
            this.lbDoiMatKhau.Name = "lbDoiMatKhau";
            this.lbDoiMatKhau.Size = new System.Drawing.Size(112, 19);
            this.lbDoiMatKhau.TabIndex = 5;
            this.lbDoiMatKhau.Text = "Đổi mật khẩu";
            this.lbDoiMatKhau.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbDoiMatKhau.Click += new System.EventHandler(this.lbDoiMatKhau_Click);
            this.lbDoiMatKhau.MouseLeave += new System.EventHandler(this.lbDoiMatKhau_MouseLeave);
            this.lbDoiMatKhau.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lbDoiMatKhau_MouseMove);
            // 
            // lbDangXuat
            // 
            this.lbDangXuat.AutoSize = true;
            this.lbDangXuat.BackColor = System.Drawing.Color.Transparent;
            this.lbDangXuat.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDangXuat.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbDangXuat.Location = new System.Drawing.Point(12, 341);
            this.lbDangXuat.Name = "lbDangXuat";
            this.lbDangXuat.Size = new System.Drawing.Size(89, 19);
            this.lbDangXuat.TabIndex = 6;
            this.lbDangXuat.Text = "Đăng xuất";
            this.lbDangXuat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbDangXuat.Click += new System.EventHandler(this.lbDangXuat_Click);
            this.lbDangXuat.MouseLeave += new System.EventHandler(this.lbDangXuat_MouseLeave);
            this.lbDangXuat.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lbDangXuat_MouseMove);
            // 
            // ptExit
            // 
            this.ptExit.BackColor = System.Drawing.Color.Transparent;
            this.ptExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ptExit.Image = global::QuanLyNhaHangSQK.Properties.Resources.exit2;
            this.ptExit.Location = new System.Drawing.Point(1033, 12);
            this.ptExit.Name = "ptExit";
            this.ptExit.Size = new System.Drawing.Size(35, 35);
            this.ptExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptExit.TabIndex = 6;
            this.ptExit.TabStop = false;
            this.ptExit.Click += new System.EventHandler(this.ptExit_Click);
            // 
            // formTrangChu
            // 
            this.formTrangChu.BorderRadius = 40;
            this.formTrangChu.TargetControl = this;
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // fTrangChu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::QuanLyNhaHangSQK.Properties.Resources.TrangChu2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1080, 608);
            this.Controls.Add(this.ptExit);
            this.Controls.Add(this.lbDangXuat);
            this.Controls.Add(this.lbDoiMatKhau);
            this.Controls.Add(this.lbThongTinCaNhan);
            this.Controls.Add(this.btnNhaBep);
            this.Controls.Add(this.btnThuNgan);
            this.Controls.Add(this.btnQuanLy);
            this.Controls.Add(this.txtTenND);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1080, 608);
            this.MinimumSize = new System.Drawing.Size(1080, 608);
            this.Name = "fTrangChu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fTrangChu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fTrangChu_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.ptExit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnQuanLy;
        private System.Windows.Forms.Button btnThuNgan;
        private System.Windows.Forms.Button btnNhaBep;
        private System.Windows.Forms.TextBox txtTenND;
        private System.Windows.Forms.Label lbThongTinCaNhan;
        private System.Windows.Forms.Label lbDoiMatKhau;
        private System.Windows.Forms.Label lbDangXuat;
        private System.Windows.Forms.PictureBox ptExit;
        private Guna.UI2.WinForms.Guna2Elipse formTrangChu;
        private System.Windows.Forms.Timer timer1;
    }
}