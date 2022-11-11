
namespace QuanLyNhaHangSQK
{
    partial class fDangNhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fDangNhap));
            this.label1 = new System.Windows.Forms.Label();
            this.txtTaiKhoan = new System.Windows.Forms.TextBox();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.lbQuenMatKhau = new System.Windows.Forms.Label();
            this.btnDangNhap = new System.Windows.Forms.Button();
            this.formDangNhap = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.btn_Thoat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(416, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 44);
            this.label1.TabIndex = 1;
            this.label1.Text = "Đăng nhập";
            // 
            // txtTaiKhoan
            // 
            this.txtTaiKhoan.BackColor = System.Drawing.Color.Black;
            this.txtTaiKhoan.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTaiKhoan.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTaiKhoan.ForeColor = System.Drawing.Color.Gainsboro;
            this.txtTaiKhoan.Location = new System.Drawing.Point(376, 159);
            this.txtTaiKhoan.Multiline = true;
            this.txtTaiKhoan.Name = "txtTaiKhoan";
            this.txtTaiKhoan.Size = new System.Drawing.Size(283, 28);
            this.txtTaiKhoan.TabIndex = 2;
            this.txtTaiKhoan.Text = "admin@gmail.com";
            this.txtTaiKhoan.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTaiKhoan.Enter += new System.EventHandler(this.txtTaiKhoan_Enter);
            this.txtTaiKhoan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTaiKhoan_KeyDown);
            this.txtTaiKhoan.Leave += new System.EventHandler(this.txtTaiKhoan_Leave);
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.BackColor = System.Drawing.SystemColors.InfoText;
            this.txtMatKhau.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMatKhau.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatKhau.ForeColor = System.Drawing.Color.Gainsboro;
            this.txtMatKhau.Location = new System.Drawing.Point(376, 208);
            this.txtMatKhau.Multiline = true;
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.PasswordChar = '●';
            this.txtMatKhau.Size = new System.Drawing.Size(283, 28);
            this.txtMatKhau.TabIndex = 3;
            this.txtMatKhau.Text = "12345678";
            this.txtMatKhau.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMatKhau.Enter += new System.EventHandler(this.txtMatKhau_Enter);
            this.txtMatKhau.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMatKhau_KeyDown);
            this.txtMatKhau.Leave += new System.EventHandler(this.txtMatKhau_Leave);
            // 
            // lbQuenMatKhau
            // 
            this.lbQuenMatKhau.AutoSize = true;
            this.lbQuenMatKhau.BackColor = System.Drawing.Color.Transparent;
            this.lbQuenMatKhau.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbQuenMatKhau.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbQuenMatKhau.Location = new System.Drawing.Point(538, 248);
            this.lbQuenMatKhau.Name = "lbQuenMatKhau";
            this.lbQuenMatKhau.Size = new System.Drawing.Size(112, 16);
            this.lbQuenMatKhau.TabIndex = 5;
            this.lbQuenMatKhau.Text = "Quên mật khẩu?";
            this.lbQuenMatKhau.MouseLeave += new System.EventHandler(this.lbQuenMatKhau_MouseLeave);
            this.lbQuenMatKhau.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lbQuenMatKhau_MouseMove);
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.BackColor = System.Drawing.Color.Transparent;
            this.btnDangNhap.BackgroundImage = global::QuanLyNhaHangSQK.Properties.Resources.btn;
            this.btnDangNhap.FlatAppearance.BorderSize = 0;
            this.btnDangNhap.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnDangNhap.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnDangNhap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangNhap.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangNhap.Location = new System.Drawing.Point(455, 288);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(128, 41);
            this.btnDangNhap.TabIndex = 4;
            this.btnDangNhap.Text = "Đăng nhập";
            this.btnDangNhap.UseVisualStyleBackColor = false;
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            this.btnDangNhap.MouseLeave += new System.EventHandler(this.btnDangNhap_MouseLeave);
            this.btnDangNhap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnDangNhap_MouseMove);
            // 
            // formDangNhap
            // 
            this.formDangNhap.BorderRadius = 40;
            this.formDangNhap.TargetControl = this;
            // 
            // btn_Thoat
            // 
            this.btn_Thoat.BackColor = System.Drawing.Color.Transparent;
            this.btn_Thoat.BackgroundImage = global::QuanLyNhaHangSQK.Properties.Resources.exit2;
            this.btn_Thoat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Thoat.FlatAppearance.BorderSize = 0;
            this.btn_Thoat.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Thoat.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Thoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Thoat.ForeColor = System.Drawing.Color.Transparent;
            this.btn_Thoat.Location = new System.Drawing.Point(753, 12);
            this.btn_Thoat.Name = "btn_Thoat";
            this.btn_Thoat.Size = new System.Drawing.Size(35, 35);
            this.btn_Thoat.TabIndex = 1;
            this.btn_Thoat.Text = "g";
            this.btn_Thoat.UseVisualStyleBackColor = false;
            this.btn_Thoat.Click += new System.EventHandler(this.btn_Thoat_Click);
            // 
            // fDangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::QuanLyNhaHangSQK.Properties.Resources.BackgroundDangNhap115;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 423);
            this.Controls.Add(this.btn_Thoat);
            this.Controls.Add(this.btnDangNhap);
            this.Controls.Add(this.lbQuenMatKhau);
            this.Controls.Add(this.txtMatKhau);
            this.Controls.Add(this.txtTaiKhoan);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(800, 423);
            this.MinimumSize = new System.Drawing.Size(800, 423);
            this.Name = "fDangNhap";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fDangNhap_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTaiKhoan;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.Label lbQuenMatKhau;
        private System.Windows.Forms.Button btnDangNhap;
        private Guna.UI2.WinForms.Guna2Elipse formDangNhap;
        private System.Windows.Forms.Button btn_Thoat;
    }
}

