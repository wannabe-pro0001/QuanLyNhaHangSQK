using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHangSQK.DTO
{
    public class MenuBep
    {
        private string tenMA;
        private int soLuong;
        private int maBan;
        private int maHD;
        private int maMA;
        private int hienTrang;

        public string TenMA { get => tenMA; set => tenMA = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public int HienTrang { get => hienTrang; set => hienTrang = value; }
        public int MaBan { get => maBan; set => maBan = value; }
        public int MaHD { get => maHD; set => maHD = value; }
        public int MaMA { get => maMA; set => maMA = value; }

        public MenuBep(string tenMA, int soLuong, int maBan, int maHD, int maMA, int hienTrang)
        {
            this.TenMA = tenMA;
            this.SoLuong = soLuong;
            this.MaBan = maBan;
            this.MaHD = maHD;
            this.MaMA = maMA;
            this.HienTrang = hienTrang;
        }

        public MenuBep(DataRow row)
        {
            this.TenMA = row["TenTP"].ToString();
            this.SoLuong = (int)row["SoLuong"];
            this.MaBan = (int)row["MaBan"];
            this.MaHD = (int)row["MaHD"];
            this.MaMA = (int)row["MaMA"];
            this.HienTrang = (int)row["HienTrang"];
        }
    }
}
