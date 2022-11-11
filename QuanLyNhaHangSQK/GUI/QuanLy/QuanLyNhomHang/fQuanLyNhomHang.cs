using ClosedXML.Excel;
using QuanLyNhaHangSQK.DAL;
using QuanLyNhaHangSQK.DTO;
using QuanLyNhaHangSQK.GUI.QuanLy.QuanLyMonAn;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaHangSQK.GUI.QuanLy.QuanLyNhomHang
{
    public partial class fQuanLyNhomHang : Form
    {

        public fQuanLyNhomHang()
        {
            InitializeComponent();
        }

        private void fQuanLyNhomHang_Load(object sender, EventArgs e)
        {
            TaiDanhSachNhomHang();
        }

        private void VongLapTaiDanhSachNhomHang(List<NhomHang> nhomHangs)
        {
            foreach (var item in nhomHangs)
            {
                Button btnNhomHang = new Button()
                {
                    Width = 1000,
                    Height = 40,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    BackColor = Color.White,
                    ForeColor = Color.Black

                };
                btnNhomHang.Text = item.MaNH.ToString() ;
                btnNhomHang.Click += btnNhomHang_Click;
                btnNhomHang.Tag = item;

                Label labelTenNH = new Label()
                {
                    Width = 300,
                    Height = 17,
                    Location = new Point(335, 11),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Text = item.TenNH
                };
                labelTenNH.Click += labelNhomHang_Click;
                labelTenNH.Tag = item;

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

                btnNhomHang.Controls.Add(labelTenNH);
                btnNhomHang.Controls.Add(labelXoa);

                flpnNH.Controls.Add(btnNhomHang);
            }
        }

        private void labelXoa_Click(object sender, EventArgs e)
        {
            int MaNH = ((sender as Label).Tag as NhomHang).MaNH;

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa ca làm việc này không?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                if (NhomHangDAL.Instance.XoaNhomHang(MaNH))
                {
                    MessageBox.Show("Xóa thành công!");
                    TaiDanhSachNhomHang();
                }
                else
                    MessageBox.Show("Xóa thất bại");
            }
        }

        private void TaiDanhSachNhomHang()
        {
            flpnNH.Controls.Clear();

            List<NhomHang> nhomHangs = NhomHangDAL.Instance.TaiDanhSachNhomHang();

            VongLapTaiDanhSachNhomHang(nhomHangs);
        }

        private void TaiDanhSachNhomHangTheoTen(string TenNH)
        {
            flpnNH.Controls.Clear();

            List<NhomHang> nhomHangs = NhomHangDAL.Instance.TaiDanhSachNhomHangTheoTen(TenNH);

            VongLapTaiDanhSachNhomHang(nhomHangs);
        }

        private void labelNhomHang_Click(object sender, EventArgs e)
        {
            NhomHang nhomHang = (sender as Label).Tag as NhomHang;

            fChiTietNhomHang f = new fChiTietNhomHang(nhomHang);
            f.ShowDialog();

            TaiDanhSachNhomHang();
        }

        private void btnNhomHang_Click(object sender, EventArgs e)
        {
            NhomHang nhomHang = (sender as Button).Tag as NhomHang;

            fChiTietNhomHang f = new fChiTietNhomHang(nhomHang);
            f.ShowDialog();

            TaiDanhSachNhomHang();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            fThemNhomHang f = new fThemNhomHang();
            f.ShowDialog();

            TaiDanhSachNhomHang();
        }
    }
}
