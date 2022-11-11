using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHangSQK.DTO
{
    public class NhomHang
    {
        private int maNH;
        private string tenNH;

        public int MaNH { get => maNH; set => maNH = value; }
        public string TenNH { get => tenNH; set => tenNH = value; }

        public NhomHang(int maNH, string tenNH)
        {
            this.MaNH = maNH;
            this.TenNH = tenNH;
        }

        public NhomHang(DataRow row)
        {
            this.MaNH = (int)row["MaNH"];
            this.TenNH = row["TenNH"].ToString();
        }
    }
}
