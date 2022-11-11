using QuanLyNhaHangSQK.DAL;
using QuanLyNhaHangSQK.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaHangSQK.GUI
{
    public partial class fThongTinCaNhan : Form
    {
        private NguoiDung nguoiDungDangNhap;

        public NguoiDung NguoiDungDangNhap 
        { 
            get { return nguoiDungDangNhap; }
            set { nguoiDungDangNhap = value; LoadThongTinCaNhan(); }
        }

        public fThongTinCaNhan(NguoiDung nguoiDung)
        {
            InitializeComponent();
            this.Opacity = 0;
            timer1.Start();
            this.NguoiDungDangNhap = nguoiDung;
        }

        public void LoadThongTinCaNhan()
        {
            CultureInfo culture = new CultureInfo("es-US");

            BoPhan boPhan = BoPhanDAL.Instance.BoPhanNDDangNhap(NguoiDungDangNhap.MaBP);
            CaLamViec caLamViec = CaLamViecDAL.Instance.CaLamViecNDDangNhap(NguoiDungDangNhap.MaCLV);
            ChiNhanh chiNhanh = ChiNhanhDAL.Instance.TaiChiNhanhTheoCN(NguoiDungDangNhap.MaCN);
            
            txtTen.Text = NguoiDungDangNhap.HoTen;
            cbbGioiTinh.Text = NguoiDungDangNhap.GioiTinh;
            datetimeNgaySinh.Text = NguoiDungDangNhap.NgaySinh.ToString();
            txtCMND.Text = NguoiDungDangNhap.CMND;
            txtDiaChi.Text = NguoiDungDangNhap.DiaChi;
            txtDienThoai.Text = NguoiDungDangNhap.DienThoai;
            txtEmail.Text = NguoiDungDangNhap.Email;
            lbBoPhan.Text = boPhan.TenBP;
            lbCaLamViecBD.Text = caLamViec.GioBatDau.ToString();
            lbCaLamViecKT.Text = caLamViec.GioKetThuc.ToString();
            lbChiNhanh.Text = chiNhanh.TenCN;
            lbLuong.Text = NguoiDungDangNhap.Luong.ToString("c", culture);
        }

        public void LuuThongTinCaNhan()
        {
            int MaND = NguoiDungDangNhap.MaND;
            string HoTen = txtTen.Text;
            datetimeNgaySinh.CustomFormat = "yyyy-MM-dd";
            string GioiTinh = cbbGioiTinh.Text;
            string DienThoai = txtDienThoai.Text;
            string DiaChi = txtDiaChi.Text;
            string CMND = txtCMND.Text;
            string Email = txtEmail.Text;
            
            try
            {
                if (NguoiDungDAL.Instance.CapNhatThongTinNguoiDung(MaND, HoTen, datetimeNgaySinh.Text, GioiTinh, DienThoai, DiaChi, CMND, Email))
                {
                    MessageBox.Show("Cập nhật thành công!");
                }
                else
                    MessageBox.Show("Cập nhật thất bại!");
            }
            catch
            {
                MessageBox.Show("Cập nhật thất bại!");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_MouseLeave(object sender, EventArgs e)
        {
            btnLuu.ForeColor = Color.White;
        }

        private void btnLuu_MouseMove(object sender, MouseEventArgs e)
        {
            btnLuu.ForeColor = Color.Yellow;
        }

        private void btnThoat_MouseLeave(object sender, EventArgs e)
        {
            btnThoat.ForeColor = Color.White;
        }

        private void btnThoat_MouseMove(object sender, MouseEventArgs e)
        {
            btnThoat.ForeColor = Color.Yellow;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            LuuThongTinCaNhan();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Opacity = this.Opacity + 0.1;
            if (this.Opacity == 1)
                timer1.Stop();
        }
    }
}
