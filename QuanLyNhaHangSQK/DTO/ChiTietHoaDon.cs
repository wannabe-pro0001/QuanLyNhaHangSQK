using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHangSQK.DTO
{
    public class ChiTietHoaDon
    {
        private int maMA;
        private int maHD;
        private decimal tongTien;
        private int soLuong;
        private int hienTrang;

        public int MaMA { get => maMA; set => maMA = value; }
        public int MaHD { get => maHD; set => maHD = value; }
        public decimal TongTien { get => tongTien; set => tongTien = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public int HienTrang { get => hienTrang; set => hienTrang = value; }

        public ChiTietHoaDon(int maHD, int maMA, decimal tongTien, int soLuong, int hienTrang)
        {
            this.MaHD = maHD;
            this.MaMA = maMA;
            this.TongTien = tongTien;
            this.SoLuong = soLuong;
            this.HienTrang = hienTrang;
        }

        public ChiTietHoaDon(DataRow row)
        {
            this.MaHD = (int)row["MaHD"];
            this.MaMA = (int)row["MaMA"];
            this.TongTien = (decimal)row["TongTien"];
            this.SoLuong = (int)row["SoLuong"];
            this.HienTrang = (int)row["HienTrang"];
        }
    }
}
