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

namespace QuanLyNhaHangSQK.GUI.QuanLy.QuanLyNhanVien
{
    public partial class fChiTietNhanVien : Form
    {
        CultureInfo culture = new CultureInfo("es-US");

        private int maND;

        public int MaND { get => maND; set => maND = value; }

        public fChiTietNhanVien(int maNDung)
        {
            InitializeComponent();

            this.MaND = maNDung;
        }

        private void fChiTietNhanVien_Load(object sender, EventArgs e)
        {
            TaithongTinNguoiDung();
        }


        private void TaiDanhSachChiNhanh()
        {
            List<ChiNhanh> chiNhanhs = ChiNhanhDAL.Instance.TaiDanhSachChiNhanh();

            cbbChiNhanh.DataSource = chiNhanhs;
            cbbChiNhanh.DisplayMember = "TenCN";
        }

        private void TaiDanhSachCaLV()
        {
            List<CaLamViec> caLamViec = CaLamViecDAL.Instance.TaiDanhSachCaLamViec();

            cbbCaLV.DataSource = caLamViec;
            cbbCaLV.DisplayMember = "TenCLV";
        }

        private void TaiDanhSachBoPhan()
        {
            List<BoPhan> boPhan = BoPhanDAL.Instance.TaiDanhSachBoPhan();

            cbbBoPhan.DataSource = boPhan;
            cbbBoPhan.DisplayMember = "TenBP";
        }

        private void TaithongTinNguoiDung()
        {
            TaiDanhSachBoPhan();
            TaiDanhSachCaLV();
            TaiDanhSachChiNhanh();

            NguoiDung nguoiDung = NguoiDungDAL.Instance.TaithongTinNguoiDungTheoMa(MaND);
            BoPhan boPhan = BoPhanDAL.Instance.TaiBoPhanTheoBP(nguoiDung.MaBP);
            ChiNhanh chiNhanh = ChiNhanhDAL.Instance.TaiChiNhanhTheoCN(nguoiDung.MaCN);
            CaLamViec caLamViec = CaLamViecDAL.Instance.TaiCaLamViecTheoCLV(nguoiDung.MaCLV);

            txtHoTen.Text = nguoiDung.HoTen;
            cbbGioiTinh.Text = nguoiDung.GioiTinh;
            txtCMND.Text = nguoiDung.CMND;
            datetimeNgaySinh.Text = nguoiDung.NgaySinh.ToString();
            txtDiaChi.Text = nguoiDung.DiaChi;
            txtDienThoai.Text = nguoiDung.DienThoai;
            txtEmail.Text = nguoiDung.Email;
            txtLuong.Text = nguoiDung.Luong.ToString();
            txtMatKhau.Text = nguoiDung.MatKhau;
            datetimeNgayVL.Text = nguoiDung.NgayVL.ToString();

            if (nguoiDung.TrangThai == true)
                rdbtnTrangThaiMo.Checked = true;
            else
                rdbtnTrangThaiKhoa.Checked = true;

            int indexBP = -1;
            int iBP = 0;
            foreach (BoPhan item in cbbBoPhan.Items)
            {
                if (item.MaBP == boPhan.MaBP)
                {
                    indexBP = iBP;
                    break;
                }
                iBP++;
            }
            cbbBoPhan.SelectedIndex = indexBP;

            int indexCN = -1;
            int iCN = 0;
            foreach (ChiNhanh item in cbbChiNhanh.Items)
            {
                if (item.MaCN == chiNhanh.MaCN)
                {
                    indexCN = iCN;
                    break;
                }
                iCN++;
            }
            cbbChiNhanh.SelectedIndex = indexCN;

            int indexCLV = -1;
            int iCLV = 0;
            foreach (CaLamViec item in cbbCaLV.Items)
            {
                if (item.MaCLV == caLamViec.MaCLV)
                {
                    indexCLV = iCLV;
                    break;
                }
                iCLV++;
            }
            cbbCaLV.SelectedIndex = indexCLV;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbbCaLV_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbb = sender as ComboBox;

            if (cbb.SelectedItem == null)
                return;

            CaLamViec caLamViec = cbb.SelectedItem as CaLamViec;

            TimeSpan timeBD = new TimeSpan(caLamViec.GioBatDau.Hours, caLamViec.GioBatDau.Minutes, caLamViec.GioBatDau.Seconds);
            txtGioBD.Text = string.Format("{0:D2}", timeBD.Hours);
            txtPhutBD.Text = string.Format("{0:D2}", timeBD.Minutes);
            txtGiayBD.Text = string.Format("{0:D2}", timeBD.Seconds);

            TimeSpan timeKT = new TimeSpan(caLamViec.GioKetThuc.Hours, caLamViec.GioKetThuc.Minutes, caLamViec.GioKetThuc.Seconds);
            txtGioKT.Text = string.Format("{0:D2}", timeKT.Hours);
            txtPhutKT.Text = string.Format("{0:D2}", timeKT.Minutes);
            txtGiayKT.Text = string.Format("{0:D2}", timeKT.Seconds);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtHoTen.Text.Trim()))
            {
                MessageBox.Show("Bạn chưa nhập tên nhân viên!");
                txtHoTen.Focus();
            }
            else if (string.IsNullOrEmpty(cbbGioiTinh.Text.Trim()))
            {
                MessageBox.Show("Bạn chưa chọn giới tính!");
                cbbGioiTinh.Focus();
            }
            else if (string.IsNullOrEmpty(datetimeNgaySinh.Text.Trim()))
            {
                MessageBox.Show("Bạn chưa chọn ngày sinh!");
                datetimeNgaySinh.Focus();
            }
            else if (string.IsNullOrEmpty(txtCMND.Text.Trim()))
            {
                MessageBox.Show("Bạn chưa nhập cmnd!");
                txtCMND.Focus();
            }
            else if (string.IsNullOrEmpty(txtDiaChi.Text.Trim()))
            {
                MessageBox.Show("Bạn chưa nhập địa chỉ!");
                txtDiaChi.Focus();
            }
            else if (string.IsNullOrEmpty(txtDienThoai.Text.Trim()))
            {
                MessageBox.Show("Bạn chưa nhập số điện thoại!");
                txtDienThoai.Focus();
            }
            else if (string.IsNullOrEmpty(txtEmail.Text.Trim()))
            {
                MessageBox.Show("Bạn chưa nhập email!");
                txtEmail.Focus();
            }
            else if (string.IsNullOrEmpty(txtLuong.Text.Trim()))
            {
                MessageBox.Show("Bạn chưa nhập lương!");
                txtLuong.Focus();
            }
            else if (string.IsNullOrEmpty(txtMatKhau.Text.Trim()))
            {
                MessageBox.Show("Bạn chưa nhập mật khẩu!");
                txtMatKhau.Focus();
            }
            else
            {
                try
                {
                    string HoTen = txtHoTen.Text;
                    string GioiTinh = cbbGioiTinh.Text;
                    datetimeNgaySinh.CustomFormat = "yyyy-MM-dd";
                    datetimeNgayVL.CustomFormat = "yyyy-MM-dd";
                    string CMND = txtCMND.Text;
                    string DiaChi = txtDiaChi.Text;
                    string DienThoai = txtDienThoai.Text;
                    string Email = txtEmail.Text;
                    decimal Luong = decimal.Parse(txtLuong.Text);
                    string MaBP = (cbbBoPhan.SelectedItem as BoPhan).MaBP;
                    string MaCLV = (cbbCaLV.SelectedItem as CaLamViec).MaCLV;
                    int MaCN = (cbbChiNhanh.SelectedItem as ChiNhanh).MaCN;
                    string MatKhau = txtMatKhau.Text;
                    int TrangThai;

                    if (rdbtnTrangThaiMo.Checked == true)
                        TrangThai = 1;
                    else
                        TrangThai = 0;


                    if (NguoiDungDAL.Instance.SuaNguoiDung(MaND, MaBP, MaCLV, MaCN, HoTen, datetimeNgaySinh.Text, datetimeNgayVL.Text, GioiTinh, DienThoai, DiaChi, Luong, CMND, Email, MatKhau, TrangThai))
                    {
                        MessageBox.Show("Cập nhật thành công!");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thất bại!");
                    }
                }
                catch
                {
                    MessageBox.Show("Emal sai định dạng!");
                }

            }
        }
    }
}
