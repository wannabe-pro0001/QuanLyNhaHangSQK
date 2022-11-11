using QuanLyNhaHangSQK.DAL;
using QuanLyNhaHangSQK.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaHangSQK
{
    public partial class fDangNhap : Form
    {
        public fDangNhap()
        {
            InitializeComponent();
        }

        public bool DangNhap(string taiKhoan, string matKhau)
        {
            return DangNhapDAL.Instance.DangNhap(taiKhoan, matKhau);
        }

        #region Events
        //Sự kiện Enter đăng nhập txtMatKhau  
        // Event_Keydown: Có thể nhập từ bàn phím bằng cách giữ nguyên phím 
        private void txtMatKhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDangNhap.PerformClick();
            }
        }


        //Sự kiện Enter đăng nhập txtTaiKhoan
        private void txtTaiKhoan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDangNhap.PerformClick();
            }
        }


        //Sự kiện nhấn nút đăng nhập btnDangNhap
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (txtTaiKhoan.Text == "Email")
            {
                MessageBox.Show("Vui lòng nhập tên tài khoản!");
                txtTaiKhoan.Focus();
            }
            else if (txtMatKhau.Text == "Mật khẩu")
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!");
                txtMatKhau.Focus();
            }
            else
            {
                string taiKhoan = txtTaiKhoan.Text;
                string matKhau = txtMatKhau.Text;
                if (DangNhap(taiKhoan, matKhau))
                {
                    NguoiDung quyenND = NguoiDungDAL.Instance.TaiKhoanTuEmailND(taiKhoan);
                    fTrangChu f = new fTrangChu(quyenND);
                    txtMatKhau.Text = "";
                    this.Hide();
                    f.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Tài khoản mật khẩu sai");
                    txtMatKhau.Text = "";
                }
            }
        }

        //Sự kiện thông báo khi thoát chương trình
        private void fDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }


        //Sự kiện phụ
        private void btnDangNhap_MouseLeave(object sender, EventArgs e)
        {
            btnDangNhap.ForeColor = Color.Black;
        }
        private void btnDangNhap_MouseMove(object sender, MouseEventArgs e)
        {
            btnDangNhap.ForeColor = Color.Blue;
        }
        private void lbQuenMatKhau_MouseLeave(object sender, EventArgs e)
        {
            lbQuenMatKhau.ForeColor = Color.White;
        }
        private void lbQuenMatKhau_MouseMove(object sender, MouseEventArgs e)
        {
            lbQuenMatKhau.ForeColor = Color.Blue;
        }

        #endregion

        private void txtMatKhau_Enter(object sender, EventArgs e)
        {
            if (txtMatKhau.Text == "Mật khẩu")
            {
                txtMatKhau.Text = "";
                txtMatKhau.ForeColor = Color.White;
            }
        }

        private void txtMatKhau_Leave(object sender, EventArgs e)
        {
            if (txtMatKhau.Text == "")
            {
                txtMatKhau.Text = "Mật khẩu";
                txtMatKhau.ForeColor = Color.Gainsboro;
            }
        }

        private void txtTaiKhoan_Enter(object sender, EventArgs e)
        {
            if (txtTaiKhoan.Text == "Email")
            {
                txtTaiKhoan.Text = "";
                txtTaiKhoan.ForeColor = Color.White;
            }
        }

        private void txtTaiKhoan_Leave(object sender, EventArgs e)
        {
            if (txtTaiKhoan.Text == "")
            {
                txtTaiKhoan.Text = "Email";
                txtTaiKhoan.ForeColor = Color.Gainsboro;
            }
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
