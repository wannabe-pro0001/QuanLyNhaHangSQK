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
    public partial class fChiTietMonAn : Form
    {
        private MonAn monAn;
        private int MaNHUpdate;

        public MonAn MonAn { get => monAn; set => monAn = value; }

        public fChiTietMonAn(MonAn maMonAn)
        {
            InitializeComponent();

            this.MonAn = maMonAn;
        }

        private void fChiTietMonAn_Load(object sender, EventArgs e)
        {
            TaiThongTinMonAn();     
        }

        private void TaiLenDanhSachNhomHang()
        {
            List<NhomHang> nhomHangs = NhomHangDAL.Instance.TaiDanhSachNhomHang();

            cbbNhomHang.DataSource = nhomHangs;
            cbbNhomHang.DisplayMember = "TenNH";
        }

        private void TaiThongTinMonAn()
        {
            TaiLenDanhSachNhomHang();
            NhomHang nhomHang = NhomHangDAL.Instance.NhomHangHienTai(MonAn.MaNH);

            txtTenMA.Text = MonAn.TenMA;
            txtGiaGoc.Text = MonAn.GiaGoc.ToString();
            txtGiaBan.Text = MonAn.GiaTien.ToString();
            txtDonViTinh.Text = MonAn.DonViTinh;

            int index = -1;
            int i = 0;
            foreach (NhomHang item in cbbNhomHang.Items)
            {
                if (item.MaNH == nhomHang.MaNH)
                {
                    index = i;
                    break;
                }
                i++;
            }
            cbbNhomHang.SelectedIndex = index;

            byte[] Img = MonAnDAL.Instance.TaiAnhLen(MonAn.MaMA);

            pctAnhMA.BackgroundImage = XuLyAnh.Instance.ByteArrayToImage(Img);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
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
                int MaNH = MaNHUpdate;
                string DonViTnh = txtDonViTinh.Text;
                byte[] Img = XuLyAnh.Instance.ImageToByteArray(pctAnhMA.BackgroundImage);

                if (Img != null)
                {
                    MonAnDAL.Instance.CapNhatMonAn(MonAn.MaMA, MaNH, TenMA, GiaBan, GiaGoc, Img, DonViTnh);
                    MessageBox.Show("Cập nhật thành công!");
                    this.Close();
                    fChiTietMonAn_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại!");
                }
            }
        }

        //Thêm annhr
        private void btnThem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pctAnhMA.BackgroundImage = Image.FromFile(openFileDialog.FileName);
                txtDuongDan.Text = openFileDialog.FileName;
            }
        }

        private void cbbNhomHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbb = sender as ComboBox;

            if (cbb.SelectedItem == null)
                return;

            NhomHang nhomHang = cbb.SelectedItem as NhomHang;

            MaNHUpdate = nhomHang.MaNH;
        }
    }
}
