using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHangSQK.DTO
{
    public class MonAn
    {
        private int maMA;
        private int maNH;
        private string tenMA;
        private decimal giaTien;
        private decimal giaGoc;
        private byte[] anh;
        private string donViTinh;

        public int MaMA { get => maMA; set => maMA = value; }
        public int MaNH { get => maNH; set => maNH = value; }
        public string TenMA { get => tenMA; set => tenMA = value; }
        public decimal GiaTien { get => giaTien; set => giaTien = value; }
        public decimal GiaGoc { get => giaGoc; set => giaGoc = value; }
        public byte[] Anh { get => anh; set => anh = value; }
        public string DonViTinh { get => donViTinh; set => donViTinh = value; }
        

        public MonAn(int maMA, int maNH, string tenMA, decimal giaTien, decimal giaGoc, byte[] anh, string donViTinh)
        {
            this.MaMA = maMA;
            this.MaNH = maNH;
            this.TenMA = tenMA;
            this.GiaGoc = giaGoc;
            this.GiaTien = giaTien;
            this.Anh = anh;
            this.DonViTinh = donViTinh;
        }

        public MonAn(DataRow row)
        {
            this.MaMA = (int)row["MaMA"];
            this.MaNH = (int)row["MaNH"];
            this.TenMA = row["TenTP"].ToString();
            this.GiaGoc = (decimal)row["GiaGoc"];
            this.GiaTien = (decimal)row["GiaTien"];
            this.Anh = (byte[])row["Anh"];
            this.DonViTinh = row["DonViTinh"].ToString();

        }
    }
}
