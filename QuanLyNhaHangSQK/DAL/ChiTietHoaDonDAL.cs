using QuanLyNhaHangSQK.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace QuanLyNhaHangSQK.DAL
{
    public class ChiTietHoaDonDAL
    {
        private static ChiTietHoaDonDAL instance;

        public static ChiTietHoaDonDAL Instance
        {
            get { if (instance == null) instance = new ChiTietHoaDonDAL(); return instance; }
            private set { instance = value; }
        }

        private ChiTietHoaDonDAL() { }

        public void ThemChiTietHoaDon(int MaHD, int MaMA, int SoLuong)
        {
            DataProvider.Instance.ExcuteNonQuery(string.Format(@"exec hd_themchitiethoadon {0}, {1}, {2}", MaHD, MaMA, SoLuong));
        }

        public void XoaMonAnChiTietHoaDon(int MaHD, int MaMA, int SoLuong)
        {
            DataProvider.Instance.ExcuteNonQuery(string.Format(@"exec hd_xoamonanchitiethoadon {0}, {1}, {2}", MaHD, MaMA, SoLuong));
        }

        public void XoaChiTietHoaDon(int MaHD)
        {
            DataProvider.Instance.ExcuteNonQuery(string.Format("delete tblChiTietHoaDon where MaHD = " + MaHD));
        }

        public void HuyHoaDon(int MaHD, int MaBan)
        {
            DataProvider.Instance.ExcuteNonQuery(string.Format(@"exec hd_huyhoadon {0}, {1}", MaHD, MaBan));
        }

        public void ThayDoiHienTrang(int MaHD, int MaMA, int HienTrang)
        {
            DataProvider.Instance.ExcuteNonQuery(string.Format("Update tblChiTietHoaDon set HienTrang = {0} where MaHD = {1} and MaMA = {2}", HienTrang, MaHD, MaMA));
        }
    }
}
