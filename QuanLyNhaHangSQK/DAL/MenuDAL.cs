using QuanLyNhaHangSQK.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHangSQK.DAL
{
    public class MenuDAL
    {
        private static MenuDAL instance;

        public static MenuDAL Instance
        {
            get { if (instance == null) instance = new MenuDAL(); return instance; }
            private set { instance = value; }
        }

        private MenuDAL() { }

        public List<Menu> LayDanhSachMenuTheoBan(int MaBan)
        {
            List<Menu> danhSachMenu = new List<Menu>();

            string query = "select c.HienTrang, c.MaMA, h.MaHD, m.TenTP, c.SoLuong, m.GiaTien, m.GiaTien*c.SoLuong as TongTien from tblChiTietHoaDon c, tblHoaDon h, tblMonAn m where c.MaHD = h.MaHD and c.MaMA = m.MaMA and h.MaBan = " + MaBan + " and h.TinhTrang = 0";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Menu menu = new Menu(item);
                danhSachMenu.Add(menu);
            }

            return danhSachMenu;
        }

        public List<Menu> TaiDanhSachMonAnTheoHoaDon(int MaHD)
        {
            List<Menu> danhSachMenu = new List<Menu>();

            string query = "select c.HienTrang, c.MaMA, h.MaHD, m.TenTP, c.SoLuong, m.GiaTien, m.GiaTien*c.SoLuong as TongTien from tblChiTietHoaDon c, tblHoaDon h, tblMonAn m where c.MaHD = h.MaHD and c.MaMA = m.MaMA and h.MaHD = " + MaHD;
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Menu menu = new Menu(item);
                danhSachMenu.Add(menu);
            }

            return danhSachMenu;
        }
    }
}
