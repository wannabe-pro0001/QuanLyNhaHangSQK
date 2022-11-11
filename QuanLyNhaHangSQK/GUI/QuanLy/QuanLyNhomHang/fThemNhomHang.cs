using QuanLyNhaHangSQK.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaHangSQK.GUI.QuanLy.QuanLyMonAn
{
    public partial class fThemNhomHang : Form
    {
        public fThemNhomHang()
        {
            InitializeComponent();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenNhomHang.Text.Trim()))
            {
                MessageBox.Show("Vul lòng nhập mã khu vực!");
                txtTenNhomHang.Focus();
            }
            else
            {
                string TenNH = txtTenNhomHang.Text;
                if (NhomHangDAL.Instance.ThemNhomHang(TenNH))
                {
                    MessageBox.Show("Thêm thành công!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại!");
                }
            }
        }
    }
}
