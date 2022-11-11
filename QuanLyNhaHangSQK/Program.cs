using QuanLyNhaHangSQK.GUI;
using QuanLyNhaHangSQK.GUI.QuanLy.QuanLyKhachHang;
using QuanLyNhaHangSQK.GUI.QuanLy.QuanLyMonAn;
using QuanLyNhaHangSQK.GUI.QuanLy.QuanLyNhanVien;
using QuanLyNhaHangSQK.GUI.QuanLy.QuanLyPhongBan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaHangSQK
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new fDangNhap());
        }
    }
}
