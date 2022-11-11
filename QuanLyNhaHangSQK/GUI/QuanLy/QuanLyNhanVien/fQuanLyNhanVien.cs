using ClosedXML.Excel;
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
    public partial class fQuanLyNhanVien : Form
    {
        public fQuanLyNhanVien()
        {
            InitializeComponent();
        }

        private void fQuanLyNhanVien_Load(object sender, EventArgs e)
        {
            TaiDanhSachBoPhan();
            TaiDanhSachChiNhanh();
            TaiDanhSachNhanVien();
            TaiDanhSachCaLamViec();
        }

        private void TaiDanhSachChiNhanh()
        {
            List<ChiNhanh> danhSachChiNhanh = ChiNhanhDAL.Instance.TaiDanhSachChiNhanh();

            foreach (var item in danhSachChiNhanh)
            {
                Button btnChiNhanh = new Button()
                {
                    Width = 250,
                    Height = 40,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    BackColor = Color.White,
                    ForeColor = Color.FromArgb(0, 0, 192)
                };
                btnChiNhanh.Click += btnChiNhanh_Click;
                btnChiNhanh.Tag = item;

                btnChiNhanh.Text = item.TenCN;

                flpnChiNhanh.Controls.Add(btnChiNhanh);
            }
        }
        private void TaiDanhSachBoPhan()
        {
            List<BoPhan> danhSachBoPhan = BoPhanDAL.Instance.TaiDanhSachBoPhan();

            foreach (var item in danhSachBoPhan)
            {
                Button btnBoPhan = new Button()
                {
                    Width = 250,
                    Height = 40,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    BackColor = Color.White,
                    ForeColor = Color.FromArgb(0, 0, 192)
                };
                btnBoPhan.Click += btnBoPhan_Click;
                btnBoPhan.Tag = item;
                btnBoPhan.Text = item.TenBP;

                flpnBoPhan.Controls.Add(btnBoPhan);
            }
        }

        private void TaiDanhSachCaLamViec()
        {
            List<CaLamViec> danhSachCaLamViec = CaLamViecDAL.Instance.TaiDanhSachCaLamViec();

            cbbCaLamViec.DataSource = danhSachCaLamViec;
            cbbCaLamViec.DisplayMember = "TenCLV";
        }

        private void VongLapTaiDanhSachNhanVien(List<NguoiDung> danhSachNguoiDung)
        {
            foreach (var item in danhSachNguoiDung)
            {
                BoPhan boPhan = BoPhanDAL.Instance.BoPhanNDDangNhap(item.MaBP);
                ChiNhanh chiNhanh = ChiNhanhDAL.Instance.TaiChiNhanhTheoCN(item.MaCN);

                Button btnNhanVien = new Button()
                {
                    Width = 1000,
                    Height = 40,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    BackColor = Color.White,
                    ForeColor = Color.Black

                };
                btnNhanVien.Text = item.HoTen;
                btnNhanVien.Click += btnNhanVien_Click;
                btnNhanVien.Tag = item;

                Label labelTenBP = new Label()
                {
                    Width = 130,
                    Height = 17,
                    Location = new Point(349, 10),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Text = boPhan.TenBP
                };
                labelTenBP.Click += labelNhanVien_Click;
                labelTenBP.Tag = item;

                Label labelTenChiNhanh = new Label()
                {
                    Width = 200,
                    Height = 17,
                    Location = new Point(535, 10),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Text = chiNhanh.TenCN
                };
                labelTenChiNhanh.Click += labelNhanVien_Click;
                labelTenChiNhanh.Tag = item;

                Label labelTrangThai = new Label()
                {
                    Width = 50,
                    Height = 17,
                    Location = new Point(843, 10),
                    TextAlign = ContentAlignment.MiddleLeft
                };
                labelTrangThai.Click += labelNhanVien_Click;
                labelTrangThai.Tag = item;

                if (item.TrangThai == true)
                {
                    labelTrangThai.Text = "Mở";
                }
                else
                    labelTrangThai.Text = "Khóa";

                Label labelXoa = new Label()
                {
                    Width = 20,
                    Height = 20,
                    Location = new Point(970, 10),
                    BackColor = Color.Transparent,
                    //Image = Image.FromFile(@"D:\nam2_ky2\LT_Win\Do An Cuoi Ky\QuanLyNhaHangFul\QuanLyNhaHangSQK\QuanLyNhaHangSQK\Resources\DelMA.png")
                    Image = Image.FromFile(Application.StartupPath + @"\Resources\DelMA.png")
                };
                labelXoa.Click += labelXoa_Click;
                labelXoa.Tag = item;

                btnNhanVien.Controls.Add(labelTrangThai);
                btnNhanVien.Controls.Add(labelTenBP);
                btnNhanVien.Controls.Add(labelTenChiNhanh);
                btnNhanVien.Controls.Add(labelXoa);

                flpnNhanVien.Controls.Add(btnNhanVien);
            }
        }

        private void TaiDanhSachNhanVien()
        {
            flpnNhanVien.Controls.Clear();

            List<NguoiDung> danhSachNguoiDung = NguoiDungDAL.Instance.TaiDanhSachNguoiDung();

            VongLapTaiDanhSachNhanVien(danhSachNguoiDung);
        }

        private void TaiDanhSachNhanVienTheoBoPhan(string MaBP)
        {
            flpnNhanVien.Controls.Clear();

            List<NguoiDung> danhSachNguoiDung = NguoiDungDAL.Instance.TaiDanhSachNguoiDungTheoBP(MaBP);

            VongLapTaiDanhSachNhanVien(danhSachNguoiDung);
        }

        private void TaiDanhSachNhanVienTheoChiNhanh(int MaCN)
        {
            flpnNhanVien.Controls.Clear();

            List<NguoiDung> danhSachNguoiDung = NguoiDungDAL.Instance.TaiDanhSachNguoiDungTheoChiNhanh(MaCN);

            VongLapTaiDanhSachNhanVien(danhSachNguoiDung);
        }

        private void TaiDanhSachNhanVienTheoCLV(string MaCLV)
        {
            flpnNhanVien.Controls.Clear();

            List<NguoiDung> danhSachNguoiDung = NguoiDungDAL.Instance.TaiDanhSachNguoiDungTheoCLV(MaCLV);

            VongLapTaiDanhSachNhanVien(danhSachNguoiDung);
        }

        private void TaiDanhSachNhanVienTheoTimKiem(string HoTen)
        {
            flpnNhanVien.Controls.Clear();

            List<NguoiDung> danhSachNguoiDung = NguoiDungDAL.Instance.TaiDanhSachNguoiDungTheoTenND(HoTen);

            VongLapTaiDanhSachNhanVien(danhSachNguoiDung);
        }

        private void btnChiNhanh_Click(object sender, EventArgs e)
        {
            int MaCN = ((sender as Button).Tag as ChiNhanh).MaCN;

            TaiDanhSachNhanVienTheoChiNhanh(MaCN);
        }

        private void labelXoa_Click(object sender, EventArgs e)
        {
            int MaND = ((sender as Label).Tag as NguoiDung).MaND;

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa người dùng này không?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                if (NguoiDungDAL.Instance.XoaNguoiDung(MaND))
                {
                    MessageBox.Show("Xóa thành công!");
                    TaiDanhSachNhanVien();
                }
                else
                    MessageBox.Show("Xóa thất bại");
            }
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            int MaND = ((sender as Button).Tag as NguoiDung).MaND;

            fChiTietNhanVien f = new fChiTietNhanVien(MaND);
            f.ShowDialog();
        }

        private void labelNhanVien_Click(object sender, EventArgs e)
        {
            int MaND = ((sender as Label).Tag as NguoiDung).MaND;

            fChiTietNhanVien f = new fChiTietNhanVien(MaND);
            f.ShowDialog();
        }


        private void btnBoPhan_Click(object sender, EventArgs e)
        {
            string MaBP = ((sender as Button).Tag as BoPhan).MaBP;

            TaiDanhSachNhanVienTheoBoPhan(MaBP);

        }

        private void cbbCaLamViec_SelectedIndexChanged(object sender, EventArgs e)
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

            TaiDanhSachNhanVienTheoCLV(caLamViec.MaCLV);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTimKiem.Text.Trim()))
                MessageBox.Show("Chưa nhập thông tin nhân viên!");
            else
                TaiDanhSachNhanVienTheoTimKiem(txtTimKiem.Text);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            fThemNhanVien f = new fThemNhanVien();
            f.ShowDialog();
            fQuanLyNhanVien_Load(sender, e);
        }
    }
}
