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

namespace QuanLyNhaHangSQK.GUI.QuanLy.QuanLyMonAn
{
    public partial class fThemMonAn : Form
    {
        public fThemMonAn()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fThemMonAn_Load(object sender, EventArgs e)
        {
            TaiLenDanhSachNhomHang();
        }

        private void TaiLenDanhSachNhomHang()
        {
            List<NhomHang> nhomHangs = NhomHangDAL.Instance.TaiDanhSachNhomHang();

            cbbNhomHang.DataSource = nhomHangs;
            cbbNhomHang.DisplayMember = "TenNH";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pctAnhMA.BackgroundImage = Image.FromFile(openFileDialog.FileName);
                txtDuongDan.Text = openFileDialog.FileName;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenMA.Text.Trim()))
            {
                MessageBox.Show("Bạn chưa nhập tên món ăn!");
                txtTenMA.Focus();
            }
            else if (string.IsNullOrEmpty(txtGiaGoc.Text.Trim()))
            {
                MessageBox.Show("Bạn chưa nhập giá gốc món ăn!");
                txtGiaGoc.Focus();
            }
            else if (string.IsNullOrEmpty(txtGiaBan.Text.Trim()))
            {
                MessageBox.Show("Bạn chưa nhập giá bán món ăn!");
                txtGiaBan.Focus();
            }
            else if (string.IsNullOrEmpty(cbbNhomHang.Text.Trim()))
            {
                MessageBox.Show("Bạn chưa chọn nhóm hàng món ăn!");
                cbbNhomHang.Focus();
            }
            else if (string.IsNullOrEmpty(txtDonViTinh.Text.Trim()))
            {
                MessageBox.Show("Bạn chưa nhập đơn vị tính!");
                txtDonViTinh.Focus();
            }
            else
            {
                string TenMA = txtTenMA.Text;
                decimal GiaGoc = decimal.Parse(txtGiaGoc.Text);
                decimal GiaBan = decimal.Parse(txtGiaBan.Text);
                int MaNH = (cbbNhomHang.SelectedItem as NhomHang).MaNH;
                string DonViTnh = txtDonViTinh.Text;
                if (string.IsNullOrEmpty(txtDuongDan.Text.Trim()))
                {
                    byte[] Img = XuLyAnh.Instance.ImageToByteArray(pctAnhMA.BackgroundImage);

                    if (MessageBox.Show("Bạn chưa chọn ảnh! bạn có chắc chắn muốn lưu không ảnh không?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                    {
                        MonAnDAL.Instance.ThemMonAn(MaNH, TenMA, GiaBan, GiaGoc, Img, DonViTnh);
                        MessageBox.Show("Thêm thành công!");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại!");
                    }
                }
                else
                {
                    byte[] Img = XuLyAnh.Instance.ImageToByteArray(pctAnhMA.BackgroundImage);

                    if (Img != null)
                    {
                        MonAnDAL.Instance.ThemMonAn(MaNH, TenMA, GiaBan, GiaGoc, Img, DonViTnh);
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
}
