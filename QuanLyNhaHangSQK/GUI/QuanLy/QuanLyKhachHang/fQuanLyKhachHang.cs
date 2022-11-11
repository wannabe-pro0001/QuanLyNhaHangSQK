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

namespace QuanLyNhaHangSQK.GUI.QuanLy.QuanLyKhachHang
{
    public partial class fQuanLyKhachHang : Form
    {

        public fQuanLyKhachHang()
        {
            InitializeComponent();
        }

        private void fQuanLyKhachHang_Load(object sender, EventArgs e)
        {
            TaiDanhSachKhachHang();
        }

        private void VongLapTaiDanhSachHD(List<KhachHang> danhSachKhachHang)
        {
            foreach (KhachHang item in danhSachKhachHang)
            {
                Button btnKhachHang = new Button()
                {
                    Width = 1000,
                    Height = 40,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    BackColor = Color.White,
                    ForeColor = Color.Black
                };
                btnKhachHang.Click += btnKhachHang_Click;
                btnKhachHang.Tag = item;

                btnKhachHang.Text = item.MaKH.ToString();

                Label labelTenKH = new Label()
                {
                    Width = 200,
                    Height = 17,
                    Location = new Point(338, 11),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Text = item.HoTen
                };
                labelTenKH.Click += lbKhachHang_Click;
                labelTenKH.Tag = item;

                Label labelDienThoai = new Label()
                {
                    Width = 150,
                    Height = 17,
                    Location = new Point(821, 11),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Text = item.DienThoai
                };
                labelDienThoai.Click += lbKhachHang_Click;
                labelDienThoai.Tag = item;

                btnKhachHang.Controls.Add(labelTenKH);
                btnKhachHang.Controls.Add(labelDienThoai);

                flpnKhachHang.Controls.Add(btnKhachHang);
            }
        }


        private void TaiDanhSachKhachHangTheoTimKiem(string TenKH)
        {
            flpnKhachHang.Controls.Clear();

            List<KhachHang> danhSachKhachHang = KhachHangDAL.Instance.TimKiemKhachHang(TenKH);

            VongLapTaiDanhSachHD(danhSachKhachHang);

        }

        private void TaiDanhSachKhachHang()
        {
            flpnKhachHang.Controls.Clear();

            List<KhachHang> danhSachKhachHang = KhachHangDAL.Instance.TaiDanhSachKhachHang();

            VongLapTaiDanhSachHD(danhSachKhachHang);

        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            int MaKH = ((sender as Button).Tag as KhachHang).MaKH;

            fChiTietKhachHang f = new fChiTietKhachHang(MaKH);
            f.ShowDialog();

            fQuanLyKhachHang_Load(sender, e);

        }

        private void lbKhachHang_Click(object sender, EventArgs e)
        {
            int MaKH = ((sender as Label).Tag as KhachHang).MaKH;

            fChiTietKhachHang f = new fChiTietKhachHang(MaKH);
            f.ShowDialog();

            fQuanLyKhachHang_Load(sender, e);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTimKiem.Text.Trim()))
                MessageBox.Show("Chưa nhập thông tin khách hàng!");
            else
                TaiDanhSachKhachHangTheoTimKiem(txtTimKiem.Text);
        }
    }
}
