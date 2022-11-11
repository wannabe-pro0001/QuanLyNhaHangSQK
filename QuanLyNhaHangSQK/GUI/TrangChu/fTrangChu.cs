using QuanLyNhaHangSQK.DAL;
using QuanLyNhaHangSQK.DTO;
using QuanLyNhaHangSQK.GUI;
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
    public partial class fTrangChu : Form
    {
        private NguoiDung nguoiDungDangNhap;

        public NguoiDung NguoiDungDangNhap 
        { 
            get { return nguoiDungDangNhap; }
            set { nguoiDungDangNhap = value; PhanLoaiND(NguoiDungDangNhap.MaBP); }
        }

        public fTrangChu(NguoiDung nguoiDung)
        {
            InitializeComponent();
            this.Opacity = 0;
            timer1.Start();
            this.NguoiDungDangNhap = nguoiDung;
        }

        private void PhanLoaiND(string MaBP)
        {
            btnQuanLy.Enabled = MaBP == "QL";
            txtTenND.Text = "Xin chào" + Environment.NewLine + NguoiDungDangNhap.HoTen; 
        }


        #region Events
        private void ptExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lbDangXuat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lbThongTinCaNhan_MouseLeave(object sender, EventArgs e)
        {
            lbThongTinCaNhan.ForeColor = Color.White;
        }

        private void lbThongTinCaNhan_MouseMove(object sender, MouseEventArgs e)
        {
            lbThongTinCaNhan.ForeColor = Color.Yellow;
        }

        private void lbDoiMatKhau_MouseLeave(object sender, EventArgs e)
        {
            lbDoiMatKhau.ForeColor = Color.White;
        }

        private void lbDoiMatKhau_MouseMove(object sender, MouseEventArgs e)
        {
            lbDoiMatKhau.ForeColor = Color.Yellow;
        }

        private void lbDangXuat_MouseLeave(object sender, EventArgs e)
        {
            lbDangXuat.ForeColor = Color.White;
        }

        private void lbDangXuat_MouseMove(object sender, MouseEventArgs e)
        {
            lbDangXuat.ForeColor = Color.Yellow;
        }

        private void btnQuanLy_MouseLeave(object sender, EventArgs e)
        {
            btnQuanLy.ForeColor = Color.White;
        }

        private void btnQuanLy_MouseMove(object sender, MouseEventArgs e)
        {
            btnQuanLy.ForeColor = Color.Yellow;
        }

        private void btnThuNgan_MouseLeave(object sender, EventArgs e)
        {
            btnThuNgan.ForeColor = Color.White;
        }

        private void btnThuNgan_MouseMove(object sender, MouseEventArgs e)
        {
            btnThuNgan.ForeColor = Color.Yellow;
        }

        private void btnNhaBep_MouseLeave(object sender, EventArgs e)
        {
            btnNhaBep.ForeColor = Color.White;
        }

        private void btnNhaBep_MouseMove(object sender, MouseEventArgs e)
        {
            btnNhaBep.ForeColor = Color.Yellow;
        }

        private void fTrangChu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn đăng xuất?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        #endregion

        private void btnThuNgan_Click(object sender, EventArgs e)
        {

            fThuNgan f = new fThuNgan(NguoiDungDangNhap);
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void btnQuanLy_Click(object sender, EventArgs e)
        {
            GUI.QuanLy.fQuanLy f = new GUI.QuanLy.fQuanLy(NguoiDungDangNhap);
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void btnNhaBep_Click(object sender, EventArgs e)
        {
            fNhaBep f = new fNhaBep();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void lbThongTinCaNhan_Click(object sender, EventArgs e)
        {
            fThongTinCaNhan f = new fThongTinCaNhan(NguoiDungDangNhap);
            f.ShowDialog();
        }

        private void lbDoiMatKhau_Click(object sender, EventArgs e)
        {
            fDoiMatKhau f = new fDoiMatKhau(NguoiDungDangNhap);
            f.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Opacity = this.Opacity + 0.1;
            if (this.Opacity == 1)
                timer1.Stop();
        }
    }
}
