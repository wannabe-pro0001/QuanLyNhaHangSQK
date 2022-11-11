using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHangSQK.DTO
{
    public class KhachHang
    {
        private int maKH;
        private string hoTen;
        private string dienThoai;

        public int MaKH { get => maKH; set => maKH = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public string DienThoai { get => dienThoai; set => dienThoai = value; }

        public KhachHang(int maKH, string hoTen, string dienThoai)
        {
            this.DienThoai = dienThoai;
            this.MaKH = maKH;
            this.HoTen = hoTen;
        }

        public KhachHang(DataRow row)
        {
            this.DienThoai = row["DienThoai"].ToString();
            this.HoTen = row["HoTen"].ToString();
            this.MaKH = (int)row["MaKH"];
        }
    }
}
