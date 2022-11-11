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
    public partial class fThanhToan : Form
    {
        CultureInfo culture = new CultureInfo("es-US");

        private List<DTO.Menu> menu;
        private Ban ban;
        private NguoiDung nguoiDung;

        private decimal TongHoaDon = 0;
        private float MucGiamGia = 0;
        private decimal GiamGia = 0;
        private decimal KhachCanTra = 0;
        private decimal TienThuaKhach = 0;
        private decimal KhachThanhToan = 0;
        private int MaKM;

        public List<DTO.Menu> MenuThanhToan { get => menu; set => menu = value; }
        public Ban Ban { get => ban; set => ban = value; }
        public NguoiDung NguoiDung { get => nguoiDung; set => nguoiDung = value; }

        public fThanhToan(List<DTO.Menu> menu, Ban maBan, NguoiDung maNguoiDung)
        {
            InitializeComponent();
            this.Opacity = 0;
            timer1.Start();
            this.MenuThanhToan = menu;
            this.Ban = maBan;
            this.NguoiDung = maNguoiDung;
        }
        private void fThanhToan_Load(object sender, EventArgs e)
        {
            timerThanhToan.Enabled = true;

            TaiDanhSachKhuyenMai();
            TaiDanhSachMonAn();
        }

        public void TaiDanhSachKhuyenMai()
        {
            List<KhuyenMai> khuyenMais = KhuyenMaiDAL.Instance.LayDanhSachKhuyenMai();

            cbbKhuyenMai.DataSource = khuyenMais;
            cbbKhuyenMai.DisplayMember = "TieuDe";
        }

        public void TaiDanhSachMonAn()
        {
            foreach (var item in MenuThanhToan)
            {
                Button btnMonAn = new Button()
                {
                    Width = 520,
                    Height = 40,
                    TextAlign = ContentAlignment.MiddleLeft,
                    BackColor = Color.White,
                    ForeColor = Color.Black,
                    Font = new Font("Arial", 10, FontStyle.Bold)
                };
                btnMonAn.Font = new Font("Arial", 10, FontStyle.Bold);
                btnMonAn.Text = item.TenMA;

                Label labelSoLuong = new Label()
                {
                    Width = 50,
                    Height = 20,
                    Location = new Point(160, 12),
                    Text = item.SoLuong.ToString()
                };

                Label labelGiaTien = new Label()
                {
                    Width = 130,
                    Height = 17,
                    Location = new Point(210, 12),
                    TextAlign = ContentAlignment.MiddleRight,
                    Text = item.GiaTien.ToString("c", culture)
                };

                Label labelTongTien = new Label()
                {
                    Width = 130,
                    Height = 17,
                    Location = new Point(350, 12),
                    TextAlign = ContentAlignment.MiddleRight,
                    Text = item.TongTien.ToString("c", culture)
                };
                TongHoaDon += item.TongTien;

                lbMaHoaDon.Text = item.MaHD.ToString();
                lbBanVaKhuVuc.Text = "Bàn " + Ban.MaBan + " - " + Ban.MaKV;

                btnMonAn.Controls.Add(labelSoLuong);
                btnMonAn.Controls.Add(labelGiaTien);
                btnMonAn.Controls.Add(labelTongTien);

                flpnMonAn.Controls.Add(btnMonAn);
            }
            txtTongTien.Text = TongHoaDon.ToString("c", culture);

            KhachCanTra = TongHoaDon - GiamGia;
            txtKhachCanTra.Text = KhachCanTra.ToString("c", culture);

            TienThuaKhach = decimal.Parse(txtKhachThanhToan.Text) - KhachCanTra;
            txtTienThuaKhach.Text = TienThuaKhach.ToString("c", culture);
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            int MaHD = HoaDonDAL.Instance.LayMaHDTheoBan(Ban.MaBan);
            decimal result = 0;
            if (!decimal.TryParse(txtKhachThanhToan.Text,out result)) return;
            if (result >= KhachCanTra)
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn thanh toán hóa đơn cho bàn " + Ban.MaBan, "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    HoaDonDAL.Instance.ThanhToan(MaHD, MaKM);
                    MessageBox.Show("Thanh toán thành công!");
                    this.Close();
                }
            }
            else
                MessageBox.Show("Sô tiền khách thanh toán không đủ để thanh toán!");

        }

        private void cbbKhuyenMai_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbb = sender as ComboBox;

            if (cbb.SelectedItem == null)
                return;

            KhuyenMai khuyenMai = cbb.SelectedItem as KhuyenMai;

            MaKM = khuyenMai.MaKM;

            MucGiamGia = khuyenMai.MucKM * 100;
            txtGiamGiaPT.Text = MucGiamGia.ToString() + "%";

            GiamGia = TongHoaDon * (decimal)khuyenMai.MucKM;
            txtGiamGia.Text = GiamGia.ToString("c", culture);

            KhachCanTra = TongHoaDon - GiamGia;
            txtKhachCanTra.Text = KhachCanTra.ToString("c", culture);

            TienThuaKhach = decimal.Parse(txtKhachThanhToan.Text) - KhachCanTra;
            txtTienThuaKhach.Text = TienThuaKhach.ToString("c", culture);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThanhToan_MouseLeave(object sender, EventArgs e)
        {
            btnThanhToan.ForeColor = Color.White;
        }

        private void btnThanhToan_MouseMove(object sender, MouseEventArgs e)
        {
            btnThanhToan.ForeColor = Color.Yellow;
        }

        private void btnThoat_MouseLeave(object sender, EventArgs e)
        {
            btnThoat.ForeColor = Color.White;
        }

        private void btnThoat_MouseMove(object sender, MouseEventArgs e)
        {
            btnThoat.ForeColor = Color.Yellow;
        }

        private void btnTienKhachKhac_Click(object sender, EventArgs e)
        {
            if (decimal.Parse(txtKhachThanhToan.Text) >= KhachCanTra)
            {
                TienThuaKhach = decimal.Parse(txtKhachThanhToan.Text) - KhachCanTra;
                txtTienThuaKhach.Text = TienThuaKhach.ToString("c", culture);
            }
            else
                MessageBox.Show("Vui lòng nhập giá lớn hơn số tiền khách cần trả!");
        }

        private void btnTienKhach1USD_Click(object sender, EventArgs e)
        {
            btnMenhGia(1);
        }

        private void btnTienKhach2USD_Click(object sender, EventArgs e)
        {
            btnMenhGia(2);
        }

        private void btnMenhGia(int MenhGia)
        {
            if (KhachCanTra <= MenhGia)
            {
                KhachThanhToan = MenhGia;
                txtKhachThanhToan.Text = KhachThanhToan.ToString();

                TienThuaKhach = KhachThanhToan - KhachCanTra;
                txtTienThuaKhach.Text = TienThuaKhach.ToString("c", culture);
            }
            else
                MessageBox.Show("Vui lòng chọn mệnh giá lớn hơn số tiền khách cần trả!");
        }

        private void btnTienKhach5USD_Click(object sender, EventArgs e)
        {
            btnMenhGia(5);
        }

        private void btnTienKhach10USD_Click(object sender, EventArgs e)
        {
            btnMenhGia(10);
        }

        private void btnTienKhach20USD_Click(object sender, EventArgs e)
        {
            btnMenhGia(20);
        }

        private void btnTienKhach50USD_Click(object sender, EventArgs e)
        {
            btnMenhGia(50);
        }

        private void btnTienKhach100USD_Click(object sender, EventArgs e)
        {
            btnMenhGia(100);
        }

        private void timerThanhToan_Tick(object sender, EventArgs e)
        {
            lbNgayGio.Text = DateTime.Now.ToString();
        }

        private void lbThemThongTinKhachHang_MouseLeave(object sender, EventArgs e)
        {
            lbThemThongTinKhachHang.Font = new Font("Arial", 10, FontStyle.Bold);
        }

        private void lbThemThongTinKhachHang_MouseMove(object sender, MouseEventArgs e)
        {
            lbThemThongTinKhachHang.Font = new Font("Arial", 10, FontStyle.Underline | FontStyle.Bold);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Opacity = this.Opacity + 0.1;
            if (this.Opacity == 1)
                timer1.Stop();
        }
    }
}
