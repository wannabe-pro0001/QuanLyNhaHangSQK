using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHangSQK.DTO
{
    public class Menu
    {
        private int maMA;
        private int maHD;
        private string tenMA;
        private int soLuong;
        private decimal giaTien;
        private decimal tongTien;
        private int hienTrang;

        public string TenMA { get => tenMA; set => tenMA = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public decimal GiaTien { get => giaTien; set => giaTien = value; }
        public decimal TongTien { get => tongTien; set => tongTien = value; }
        public int MaHD { get => maHD; set => maHD = value; }
        public int MaMA { get => maMA; set => maMA = value; }
        public int HienTrang { get => hienTrang; set => hienTrang = value; }

        public Menu(int maMA, int maHD, string tenMA, int soLuong, decimal giaTien, decimal tongTien, int hienTrang)
        {
            this.MaMA = maMA;
            this.MaHD = maHD;
            this.TenMA = tenMA;
            this.SoLuong = soLuong;
            this.GiaTien = giaTien;
            this.TongTien = tongTien;
            this.HienTrang = hienTrang;
        }

        public Menu(DataRow row)
        {
            this.MaMA = (int)row["MaMA"];
            this.MaHD = (int)row["MaHD"];
            this.TenMA = row["TenTP"].ToString();
            this.SoLuong = (int)row["SoLuong"];
            this.GiaTien = (decimal)row["GiaTien"];
            this.TongTien = (decimal)row["TongTien"];
            this.HienTrang = (int)row["HienTrang"];
        }
    }
}
