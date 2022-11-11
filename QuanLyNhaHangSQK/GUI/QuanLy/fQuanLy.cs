using QuanLyNhaHangSQK.DAL;
using QuanLyNhaHangSQK.DTO;
using QuanLyNhaHangSQK.GUI.QuanLy.QuanLyKhachHang;
using QuanLyNhaHangSQK.GUI.QuanLy.QuanLyMonAn;
using QuanLyNhaHangSQK.GUI.QuanLy.QuanLyNhanVien;
using QuanLyNhaHangSQK.GUI.QuanLy.QuanLyNhomHang;
using QuanLyNhaHangSQK.GUI.QuanLy.QuanLyPhongBan;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaHangSQK.GUI.QuanLy
{
    public partial class fQuanLy : Form
    {
        CultureInfo culture = new CultureInfo("es-US");

        private Panel bottomborderbtn;
        private Form currentchildform;
        private NguoiDung nguoiDungDangNhap;

        public NguoiDung NguoiDungDangNhap
        {
            get { return nguoiDungDangNhap; }
            set { nguoiDungDangNhap = value; }
        }

        public fQuanLy(NguoiDung nguoiDung)
        {
            InitializeComponent();
            this.Opacity = 0;
            timer1.Start();
            this.NguoiDungDangNhap = nguoiDung;

            bottomborderbtn = new Panel();
            bottomborderbtn.Size = new Size(180, 7);
            pnDanhMuc.Controls.Add(bottomborderbtn);
        }


        private void DanhMucClick(object senderbtn, Color color, int locationX)
        {
            if (senderbtn != null)
            {
                //left border btn
                bottomborderbtn.BackColor = color;
                bottomborderbtn.Location = new Point(locationX, 53);
                bottomborderbtn.Visible = true;
                bottomborderbtn.BringToFront();
            }
        }

        private void MoTrangCon(Form trangCon)
        {
            if (currentchildform != null)
            {
                currentchildform.Close();

            }
            currentchildform = trangCon;
            trangCon.TopLevel = false;
            trangCon.FormBorderStyle = FormBorderStyle.None;
            trangCon.Dock = DockStyle.Fill;
            pnChinh.Controls.Add(trangCon);
            pnChinh.Tag = trangCon;
            trangCon.BringToFront();
            trangCon.Show();
            trangCon.Text = trangCon.Text;
        }

        private void btnTongQuan_Click(object sender, EventArgs e)
        {
            DanhMucClick(sender, Color.FromArgb(27, 30, 46), 0);
            if (currentchildform != null)
            {
                currentchildform.Close();

            }
        }
        private void btnHangHoa_Click(object sender, EventArgs e)
        {
            DanhMucClick(sender, Color.FromArgb(27, 30, 46), 180);
            MoTrangCon(new fQuanLyMonAn());
        }

        private void btnPhongBan_Click(object sender, EventArgs e)
        {
            DanhMucClick(sender, Color.FromArgb(27, 30, 46), 360);
            MoTrangCon(new fQuanLyPhongBan());
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            DanhMucClick(sender, Color.FromArgb(27, 30, 46), 540);
            MoTrangCon(new fQuanLyNhanVien());
        }
        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            DanhMucClick(sender, Color.FromArgb(27, 30, 46), 720);
            MoTrangCon(new fQuanLyKhachHang());
        }
        private void btn_Nhomhang_Click(object sender, EventArgs e)
        {
            DanhMucClick(sender, Color.FromArgb(27, 30, 46), 900);
            MoTrangCon(new fQuanLyNhomHang());
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
