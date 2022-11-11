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

namespace QuanLyNhaHangSQK.GUI.QuanLy.QuanLyPhongBan
{
    public partial class fQuanLyPhongBan : Form
    {

        public fQuanLyPhongBan()
        {
            InitializeComponent();
        }

        private void fQuanLyPhongBan_Load(object sender, EventArgs e)
        {
            TaiDanhSachKhuVuc();
            TaiDanhSachBan();
        }

        private void TaiDanhSachKhuVuc()
        {
            flpnKhuVuc.Controls.Clear();

            List<KhuVuc> danhSachKhuVuc = KhuVucDAL.Instance.LayDanhSachKhuVuc();

            foreach (var item in danhSachKhuVuc)
            {
                Button btnKhuVuc = new Button()
                {
                    Width = 250,
                    Height = 40,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    BackColor = Color.White,
                    ForeColor = Color.FromArgb(0, 0, 192)

                };
                btnKhuVuc.Click += btnKhuVuc_Click;
                btnKhuVuc.Tag = item;
                btnKhuVuc.Text = item.TenKV;

                flpnKhuVuc.Controls.Add(btnKhuVuc);
            }
        }

        private void VongLapTaiDanhSachBan(List<Ban> danhSachBan)
        {
            foreach (var item in danhSachBan)
            {
                string tenKhuVuc = KhuVucDAL.Instance.LayTenKhuVucTheoMa(item.MaKV);

                Button btnBan = new Button()
                {
                    Width = 1000,
                    Height = 40,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    BackColor = Color.White,
                    ForeColor = Color.Black,

                };
                btnBan.Click += btnBan_Click;
                btnBan.Tag = item;
                btnBan.Text = "Bàn số " + item.MaBan.ToString();

                Label labelGhiChu = new Label()
                {
                    Width = 150,
                    Height = 17,
                    Location = new Point(538, 11),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Text = item.GhiChu
                };
                labelGhiChu.Click += lbBan_Click;
                labelGhiChu.Tag = item;

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

                Label labelKhuVuc = new Label()
                {
                    Width = 130,
                    Height = 17,
                    Location = new Point(821, 11),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Text = tenKhuVuc
                };
                labelKhuVuc.Click += lbBan_Click;
                labelKhuVuc.Tag = item;

                btnBan.Controls.Add(labelGhiChu);
                btnBan.Controls.Add(labelKhuVuc);
                btnBan.Controls.Add(labelXoa);

                flpnBan.Controls.Add(btnBan);
            }
        }

        private void TaiDanhSachBan()
        {
            flpnBan.Controls.Clear();

            List<Ban> danhSachBan = BanDAL.Instance.TaiDanhSachBan();

            VongLapTaiDanhSachBan(danhSachBan);
        }

        public void TaiDanhSachBanTheoKhuVuc(string MaKV)
        {
            flpnBan.Controls.Clear();

            List<Ban> danhSachBan = BanDAL.Instance.TaiDanhSachBanTheoKV(MaKV);

            VongLapTaiDanhSachBan(danhSachBan);
        }

        public void TaiDanhSachBanTheoTimKiem(int MaBan)
        {
            flpnBan.Controls.Clear();

            List<Ban> danhSachBan = BanDAL.Instance.TaiDanhSachBanTheoMaBan(MaBan);

            VongLapTaiDanhSachBan(danhSachBan);
        }

        private void labelXoa_Click(object sender, EventArgs e)
        {
            int MaBan = ((sender as Label).Tag as Ban).MaBan;

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa bàn này không?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                if (BanDAL.Instance.XoaBan(MaBan))
                {
                    MessageBox.Show("Xóa thành công!");
                    TaiDanhSachBan();
                }
                else
                    MessageBox.Show("Xóa thất bại");
            }
        }
        private void btnBan_Click(object sender, EventArgs e)
        {
            int MaBan = ((sender as Button).Tag as Ban).MaBan;

            fChiTietBan f = new fChiTietBan(MaBan);
            f.ShowDialog();
            TaiDanhSachBan();
        }

        private void lbBan_Click(object sender, EventArgs e)
        {
            int MaBan = ((sender as Label).Tag as Ban).MaBan;

            fChiTietBan f = new fChiTietBan(MaBan);
            f.ShowDialog();
            TaiDanhSachBan();
        }

        private void btnKhuVuc_Click(object sender, EventArgs e)
        {
            string MaKV = ((sender as Button).Tag as KhuVuc).MaKV;

            TaiDanhSachBanTheoKhuVuc(MaKV);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTimKiem.Text.Trim()))
                MessageBox.Show("Chưa nhập số bàn!");
            else
                TaiDanhSachBanTheoTimKiem(int.Parse(txtTimKiem.Text));

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            fThemBan f = new fThemBan();
            f.ShowDialog();
            TaiDanhSachBan();
        }
    }
}
