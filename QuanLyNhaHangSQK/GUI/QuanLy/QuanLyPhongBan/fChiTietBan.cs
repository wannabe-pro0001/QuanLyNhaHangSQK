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
    public partial class fChiTietBan : Form
    {
        private int ban;
        private string MaKHUpdate;

        public int Ban { get => ban; set => ban = value; }


        public fChiTietBan(int maBan)
        {
            InitializeComponent();

            this.Ban = maBan;
        }

        private void fChiTietBan_Load(object sender, EventArgs e)
        {
            TaiThongTinBan();
        }

        private void TaiDanhSachKhuVuc()
        {
            List<KhuVuc> khuVucs = KhuVucDAL.Instance.LayDanhSachKhuVuc();

            cbbKhuVuc.DataSource = khuVucs;
            cbbKhuVuc.DisplayMember = "TenKV";
        }

        private void TaiThongTinBan()
        {
            TaiDanhSachKhuVuc();
            Ban banHienTai = BanDAL.Instance.BanHienTai(Ban);

            txtMaBan.Text = banHienTai.MaBan.ToString();
            txtGhiChu.Text = banHienTai.GhiChu;

            if (banHienTai.TinhTrang)
                txtTinhTrang.Text = "Bàn đang có người";
            else
                txtTinhTrang.Text = "Bàn đang trống";

            int index = -1;
            int i = 0;
            foreach (KhuVuc item in cbbKhuVuc.Items)
            {
                if (item.MaKV == banHienTai.MaKV)
                {
                    index = i;
                }
                i++;
            }

            cbbKhuVuc.SelectedIndex = index;

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string GhiChu = txtGhiChu.Text;
            string MaKV = MaKHUpdate;

            if (string.IsNullOrEmpty(txtGhiChu.Text.Trim()))
            {
                GhiChu = "Chưa có ghi chú";
            }

            if (BanDAL.Instance.CapNhatBan(Ban, GhiChu, MaKV))
            {
                MessageBox.Show("Cập nhật thành công!");
                this.Close();
            }
            else
                MessageBox.Show("Cập nhật thất bại!");


        }

        private void cbbKhuVuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbb = sender as ComboBox;

            if (cbb.SelectedItem == null)
                return;

            KhuVuc khuVuc = cbb.SelectedItem as KhuVuc;

            MaKHUpdate = khuVuc.MaKV;
        }
    }
}
