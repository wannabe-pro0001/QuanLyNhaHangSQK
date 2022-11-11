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

namespace QuanLyNhaHangSQK.GUI
{
    public partial class fDoiMatKhau : Form
    {
        private NguoiDung nguoiDungDangNhap;

        public NguoiDung NguoiDungDangNhap
        {
            get { return nguoiDungDangNhap; }
            set { nguoiDungDangNhap = value; }
        }

        public fDoiMatKhau(NguoiDung nguoiDung)
        {
            InitializeComponent();
            this.Opacity = 0;
            timer1.Start();
            this.NguoiDungDangNhap = nguoiDung;
        }

        public void DoiMatKhauND()
        {
            int MaND = NguoiDungDangNhap.MaND;
            string MatKhau = txtMatKhauCu.Text;
            string MatKhauMoi = txtMatKhauMoi.Text;
            string NhapLaiMatKhauMoi = txtNhapLaiMatKhau.Text;

            if (!MatKhauMoi.Equals(NhapLaiMatKhauMoi))
            {
                MessageBox.Show("Vui lòng nhập lại mật khẩu đúng với mật khẩu mới");
            }
            else
            {
                if (NguoiDungDAL.Instance.ThayDoiMatKhau(MaND, MatKhau, MatKhauMoi))
                {
                    MessageBox.Show("Cập nhật thành công");
                }
                else
                    MessageBox.Show("Cập nhật thất bại!");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCapNhatMatKhau_MouseLeave(object sender, EventArgs e)
        {
            btnCapNhatMatKhau.ForeColor = Color.White;
        }

        private void btnCapNhatMatKhau_MouseMove(object sender, MouseEventArgs e)
        {
            btnCapNhatMatKhau.ForeColor = Color.Yellow;
        }

        private void btnThoat_MouseLeave(object sender, EventArgs e)
        {
            btnThoat.ForeColor = Color.White;
        }

        private void btnThoat_MouseMove(object sender, MouseEventArgs e)
        {
            btnThoat.ForeColor = Color.Yellow;
        }

        private void btnCapNhatMatKhau_Click(object sender, EventArgs e)
        {
            DoiMatKhauND();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Opacity = this.Opacity + 0.1;
            if (this.Opacity == 1)
                timer1.Stop();
        }
    }
}
