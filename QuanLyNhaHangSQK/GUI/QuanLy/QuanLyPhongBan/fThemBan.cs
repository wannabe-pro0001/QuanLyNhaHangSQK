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
    public partial class fThemBan : Form
    {
        public fThemBan()
        {
            InitializeComponent();
        }

        private void fThemBan_Load(object sender, EventArgs e)
        {
            TaiDanhSachKhuVuc();

        }

        private void TaiDanhSachKhuVuc()
        {
            List<KhuVuc> khuVucs = KhuVucDAL.Instance.LayDanhSachKhuVuc();

            cbbKhuVuc.DataSource = khuVucs;
            cbbKhuVuc.DisplayMember = "TenKV";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbbKhuVuc.Text.Trim()))
            {
                MessageBox.Show("Vui lòng chọn khu vực!");
                cbbKhuVuc.Focus();
            }
            else
            {
                string MaKV = (cbbKhuVuc.SelectedItem as KhuVuc).MaKV;
                string GhiChu = txtGhiChu.Text;
                if (string.IsNullOrEmpty(txtGhiChu.Text.Trim()))
                {
                    GhiChu = "Chưa có ghi chú";
                }
                    
                if (BanDAL.Instance.ThemBan(MaKV, GhiChu))
                {
                    MessageBox.Show("Thêm thành công!");
                    this.Close();
                }
                else
                    MessageBox.Show("Thêm thất bại!");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
