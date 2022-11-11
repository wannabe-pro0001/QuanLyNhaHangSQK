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

namespace QuanLyNhaHangSQK.GUI.QuanLy.QuanLyNhomHang
{
    public partial class fChiTietNhomHang : Form
    {
        private NhomHang nhomHang;

        public NhomHang NhomHang { get => nhomHang; set => nhomHang = value; }

        public fChiTietNhomHang(NhomHang nhomHang)
        {
            InitializeComponent();

            this.NhomHang = nhomHang;
        }

        private void fChiTietNhomHang_Load(object sender, EventArgs e)
        {
            TaiThongTinNhomHang();
        }

        private void TaiThongTinNhomHang()
        {
            txtMaNH.Text = NhomHang.MaNH.ToString();
            txtTenNH.Text = NhomHang.TenNH;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaNH.Text.Trim()))
            {
                MessageBox.Show("Vul lòng nhập mã nhóm hàng!");
                txtMaNH.Focus();
            }
            else if (string.IsNullOrEmpty(txtTenNH.Text.Trim()))
            {
                MessageBox.Show("Vul lòng nhập tên nhóm hàng!");
                txtTenNH.Focus();
            }
            else
            {
                string TenNH = txtTenNH.Text;
                int MaNH = int.Parse(txtMaNH.Text);
                if (NhomHangDAL.Instance.SuaNhomHang(MaNH, TenNH))
                {
                    MessageBox.Show("Sửa thành công!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Sửa thất bại!");
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
