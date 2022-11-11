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

namespace QuanLyNhaHangSQK.GUI.QuanLy.QuanLyNhanVien
{
    public partial class fThemNhanVien : Form
    {
        public fThemNhanVien()
        {
            InitializeComponent();
        }

        private void fThemNhanVien_Load(object sender, EventArgs e)
        {
            TaiDanhSachBoPhan();
            TaiDanhSachCaLV();
            TaiDanhSachChiNhanh();

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

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

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

                    if (NguoiDungDAL.Instance.ThemNguoiDung(MaBP, MaCLV, MaCN, HoTen, datetimeNgaySinh.Text, datetimeNgayVL.Text, GioiTinh, DienThoai, DiaChi, Luong, CMND, Email))
                    {
                        MessageBox.Show("Thêm thành công!");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại!");
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
