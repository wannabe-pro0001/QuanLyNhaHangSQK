using QuanLyNhaHangSQK.DAL;
using QuanLyNhaHangSQK.DTO;
using QuanLyNhaHangSQK.GUI.QuanLy.QuanLyMonAn;
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

namespace QuanLyNhaHangSQK.GUI.QuanLy.QuanLyMonAn
{
    public partial class fQuanLyMonAn : Form
    {
        CultureInfo culture = new CultureInfo("es-US");

        public fQuanLyMonAn()
        {
            InitializeComponent();
        }

        private void fQuanLyMonAn_Load(object sender, EventArgs e)
        {
            TaiDanhSachMonAn();
            TaiDanhSachNhomHang();
        }

        private void VongLapTaiDanhSachMA(List<MonAn> danhSachMonAn)
        {
            foreach (var item in danhSachMonAn)
            {
                Button btnMonAn = new Button()
                {
                    Width = 1000,
                    Height = 40,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    BackColor = Color.White,
                    ForeColor = Color.Black

                };
                btnMonAn.Text = item.TenMA;
                btnMonAn.Click += btnMonAn_Click;
                btnMonAn.Tag = item;

                Label labelGiaBan = new Label()
                {
                    Width = 130,
                    Height = 17,
                    Location = new Point(538, 11),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Text = item.GiaTien.ToString("c", culture)
                };
                labelGiaBan.Click += lbMonAn_Click;
                labelGiaBan.Tag = item;

                Label labelGiaGoc = new Label()
                {
                    Width = 130,
                    Height = 17,
                    Location = new Point(821, 11),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Text = item.GiaGoc.ToString("c", culture)
                };
                labelGiaGoc.Click += lbMonAn_Click;
                labelGiaGoc.Tag = item;

                Label labelXoa = new Label()
                {
                    Width = 20,
                    Height = 20,
                    Location = new Point(970, 10),
                    BackColor = Color.Transparent,
                    //Image = Image.FromFile(@"D:\nam2_ky2\LT_Win\Do An Cuoi Ky\QuanLyNhaHangFul\QuanLyNhaHangSQK\QuanLyNhaHangSQK\Resources\DelMA.png")
                    Image = Image.FromFile(Application.StartupPath +  @"\Resources\DelMA.png")
                };
                labelXoa.Click += labelXoa_Click;
                labelXoa.Tag = item;

                btnMonAn.Controls.Add(labelGiaBan);
                btnMonAn.Controls.Add(labelGiaGoc);
                btnMonAn.Controls.Add(labelXoa);

                flpnMonAn.Controls.Add(btnMonAn);
            }
        }

        private void TaiDanhSachMonAn()
        {
            flpnMonAn.Controls.Clear();

            List<MonAn> danhSachMonAn = MonAnDAL.Instance.TaiDanhSachMonAn();

            VongLapTaiDanhSachMA(danhSachMonAn);
        }

        public void TaiDanhSachMonAnTheoNhomHang(int MaNH)
        {
            flpnMonAn.Controls.Clear();

            List<MonAn> danhSachMonAn = MonAnDAL.Instance.TaiDanhSachMonAnTheoNhomHang(MaNH);

            VongLapTaiDanhSachMA(danhSachMonAn);
        }

        public void TaiDanhSachMonAnTheoTimKiem(string TenMA)
        {
            flpnMonAn.Controls.Clear();

            List<MonAn> danhSachMonAn = MonAnDAL.Instance.TimKiemMonAnTheoTenMA(TenMA);

            VongLapTaiDanhSachMA(danhSachMonAn);
        }

        private void TaiDanhSachNhomHang()
        {
            List<NhomHang> danhSachNhomHang = NhomHangDAL.Instance.TaiDanhSachNhomHang();

            foreach (var item in danhSachNhomHang)
            {
                Button btnNhomHang = new Button()
                {
                    Width = 250,
                    Height = 40,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    BackColor = Color.White,
                    ForeColor = Color.FromArgb(0, 0, 192)
                };
                btnNhomHang.Click += btnNhomHang_Click;
                btnNhomHang.Tag = item;
                btnNhomHang.Text = item.TenNH;

                flpnNhomHang.Controls.Add(btnNhomHang);
            }
        }

        private void labelXoa_Click(object sender, EventArgs e)
        {
            int MaMA = ((sender as Label).Tag as MonAn).MaMA;

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa món ăn này không?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                if (MonAnDAL.Instance.XoaMonAn(MaMA))
                {
                    MessageBox.Show("Xóa thành công!");
                    TaiDanhSachMonAn();
                }
                else
                    MessageBox.Show("Xóa thất bại");
            }
        }

        private void btnNhomHang_Click(object sender, EventArgs e)
        {
            int MaNH = ((sender as Button).Tag as NhomHang).MaNH;

            TaiDanhSachMonAnTheoNhomHang(MaNH);
        }

        private void btnMonAn_Click(object sender, EventArgs e)
        {
            int MaMA = ((sender as Button).Tag as MonAn).MaMA;
            MonAn monAn = MonAnDAL.Instance.MonAnHienTai(MaMA);
            fChiTietMonAn f = new fChiTietMonAn(monAn);
            f.ShowDialog();
        }

        private void lbMonAn_Click(object sender, EventArgs e)
        {
            int MaMA = ((sender as Label).Tag as MonAn).MaMA;
            MonAn monAn = MonAnDAL.Instance.MonAnHienTai(MaMA);
            fChiTietMonAn f = new fChiTietMonAn(monAn);
            f.ShowDialog();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTimKiem.Text.Trim()))
                MessageBox.Show("Chưa nhập thông tin món ăn!");
            else
                TaiDanhSachMonAnTheoTimKiem(txtTimKiem.Text);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            fThemMonAn f = new fThemMonAn();
            f.ShowDialog();
        }
    }
}
