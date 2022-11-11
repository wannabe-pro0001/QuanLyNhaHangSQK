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

namespace QuanLyNhaHangSQK
{
    public partial class fNhaBep : Form
    {
        public fNhaBep()
        {
            InitializeComponent();
            this.Opacity = 0;
            timer1.Start();
        }

        private void fNhaBep_Load(object sender, EventArgs e)
        {
            TaiDanhSachChuaNau(0);
            TaiDanhSachDaNau(1);
        }

        public void TaiDanhSachChuaNau(int HienTrang)
        {
            flpnChoCheBien.Controls.Clear();

            List<MenuBep> danhSachMenuBep = MenuBepDAL.Instance.TaiDanhSachMenuBep(HienTrang);

            foreach (var item in danhSachMenuBep)
            {
                Button btnMenuBep = new Button()
                {
                    Width = 700,
                    Height = 60,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    BackColor = Color.White,
                    ForeColor = Color.Black

                };
                btnMenuBep.Text = item.TenMA;

                Label labelSoLuong = new Label()
                {
                    Width = 50,
                    Height = 17,
                    Location = new Point(389, 20),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Text = item.SoLuong.ToString()
                };

                Label labelBan = new Label()
                {
                    Width = 130,
                    Height = 17,
                    Location = new Point(454, 20),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Text = item.MaBan.ToString()
                };

                Label labelChuyen = new Label()
                {
                    Width = 50,
                    Height = 29,
                    Location = new Point(619, 16),
                    TextAlign = ContentAlignment.MiddleLeft,
                    //Image = Image.FromFile(@"D:\nam2_ky2\LT_Win\Do An Cuoi Ky\QuanLyNhaHangFul\QuanLyNhaHangSQK\QuanLyNhaHangSQK\Resources\Chuyen2.png"),
                    Image = Image.FromFile(Application.StartupPath + @"\Resources\Chuyen2.png"),
                    BackColor = Color.Transparent
                };
                labelChuyen.Click += labelChuyen_Click;
                labelChuyen.Tag = item;

                btnMenuBep.Controls.Add(labelSoLuong);
                btnMenuBep.Controls.Add(labelBan);
                btnMenuBep.Controls.Add(labelChuyen);

                flpnChoCheBien.Controls.Add(btnMenuBep);
            }
        }
        public void TaiDanhSachDaNau(int HienTrang)
        {
            flpnCheBienXong.Controls.Clear();

            List<MenuBep> danhSachMenuBep = MenuBepDAL.Instance.TaiDanhSachMenuBep(HienTrang);

            foreach (var item in danhSachMenuBep)
            {
                Button btnMenuBep = new Button()
                {
                    Width = 700,
                    Height = 60,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    BackColor = Color.White,
                    ForeColor = Color.Black,

                };
                btnMenuBep.Text = item.TenMA;

                Label labelSoLuong = new Label()
                {
                    Width = 50,
                    Height = 17,
                    Location = new Point(389, 20),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Text = item.SoLuong.ToString()
                };

                Label labelBan = new Label()
                {
                    Width = 130,
                    Height = 17,
                    Location = new Point(454, 20),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Text = item.MaBan.ToString()
                };

                Label labelThongBao = new Label()
                {
                    Width = 50,
                    Height = 29,
                    Location = new Point(619, 16),
                    TextAlign = ContentAlignment.MiddleLeft,
                    //Image = Image.FromFile(@"D:\nam2_ky2\LT_Win\Do An Cuoi Ky\QuanLyNhaHangFul\QuanLyNhaHangSQK\QuanLyNhaHangSQK\Resources\ThongBao.png"),
                    Image = Image.FromFile(Application.StartupPath + @"\Resources\ThongBao.png"),
                    BackColor = Color.Transparent
                };
                labelThongBao.Click += labelThongBao_Click;
                labelThongBao.Tag = item;

                btnMenuBep.Controls.Add(labelSoLuong);
                btnMenuBep.Controls.Add(labelBan);
                btnMenuBep.Controls.Add(labelThongBao);

                flpnCheBienXong.Controls.Add(btnMenuBep);
            }
        }

        private void labelChuyen_Click(object sender, EventArgs eventArgs)
        {
            int MaHD = ((sender as Label).Tag as MenuBep).MaHD;
            int MaMA = ((sender as Label).Tag as MenuBep).MaMA;
            ChiTietHoaDonDAL.Instance.ThayDoiHienTrang(MaHD, MaMA, 1);
            TaiDanhSachChuaNau(0);
            TaiDanhSachDaNau(1);
        }
        private void labelThongBao_Click(object sender, EventArgs eventArgs)
        {
            int MaHD = ((sender as Label).Tag as MenuBep).MaHD;
            int MaMA = ((sender as Label).Tag as MenuBep).MaMA;
            ChiTietHoaDonDAL.Instance.ThayDoiHienTrang(MaHD, MaMA, 2);
            TaiDanhSachDaNau(1);
        }

        private void ptExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Opacity = this.Opacity + 0.1;
            if (this.Opacity == 1)
                timer1.Stop();
        }
    }
}
