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
    public partial class fChiTietKhachHang : Form
    {
        private int maKH;

        public int MaKH { get => maKH; set => maKH = value; }

        public fChiTietKhachHang(int maKHang)
        {
            InitializeComponent();

            this.MaKH = maKHang;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fChiTietKhachHang_Load(object sender, EventArgs e)
        {
            TaiThongTinKhachHangTheoMaKH();
        }

        private void TaiThongTinKhachHangTheoMaKH()
        {
            KhachHang khachHang = KhachHangDAL.Instance.LayTTKHTheoMaKH(MaKH);

            txtMaKH.Text = khachHang.MaKH.ToString();
            txtTenKH.Text = khachHang.HoTen;
            txtDienThoaiKH.Text = khachHang.DienThoai;
        }

        private void btnLuuThongTinKhachHang_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenKH.Text.Trim()))
            {
                MessageBox.Show("Vul lòng tên khách hàng!");
                txtTenKH.Focus();
            }
            else if (string.IsNullOrEmpty(txtDienThoaiKH.Text.Trim()))
            {
                MessageBox.Show("Vul lòng nhập số điện thoại!");
                txtDienThoaiKH.Focus();
            }
            else
            {
                string TenKH = txtTenKH.Text;
                string DienThoai = txtDienThoaiKH.Text;
                if (KhachHangDAL.Instance.SuaKhachHang(MaKH, TenKH, DienThoai))
                {
                    MessageBox.Show("Cập nhật thành công!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại!");
                }
            }
        }
    }
}
