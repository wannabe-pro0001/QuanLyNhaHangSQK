using QuanLyNhaHangSQK.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHangSQK.DAL
{
    public class MenuBepDAL
    {
        private static MenuBepDAL instance;

        public static MenuBepDAL Instance
        {
            get { if (instance == null) instance = new MenuBepDAL(); return instance; }
            private set { instance = value; }
        }

        private MenuBepDAL() { }

        public List<MenuBep> TaiDanhSachMenuBep(int HienTrang)
        {
            List<MenuBep> danhSachMenuBep = new List<MenuBep>();

            string query = "select m.TenTP, c.SoLuong, h.MaBan, c.MaHD, c.MaMA, c.HienTrang, h.TinhTrang from tblChiTietHoaDon c, tblMonAn m, tblHoaDon h where c.MaHD = h.MaHD and c.MaMA = m.MaMA and h.TinhTrang = 0 and c.HienTrang = ";

            DataTable data = DataProvider.Instance.ExcuteQuery(query + HienTrang);

            foreach (DataRow item in data.Rows)
            {
                MenuBep menuBep = new MenuBep(item);
                danhSachMenuBep.Add(menuBep);
            }

            return danhSachMenuBep;
        }
    }
}
