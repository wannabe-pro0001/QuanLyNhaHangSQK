using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHangSQK.DTO
{
    public class ChiNhanh
    {
        private int maCN;
        private int maCTY;
        private string tenCN;
        private string dienThoaiCN;
        private string email;
        private string soTKNH;
        private string tenNH;
        private string diaChiCN;

        public int MaCN { get => maCN; set => maCN = value; }
        public int MaCTY { get => maCTY; set => maCTY = value; }
        public string TenCN { get => tenCN; set => tenCN = value; }
        public string DienThoaiCN { get => dienThoaiCN; set => dienThoaiCN = value; }
        public string Email { get => email; set => email = value; }
        public string SoTKNH { get => soTKNH; set => soTKNH = value; }
        public string TenNH { get => tenNH; set => tenNH = value; }
        public string DiaChiCN { get => diaChiCN; set => diaChiCN = value; }

        public ChiNhanh(int maCN, int maCTY, string tenCN, string dienThoaiCN, string email, string soTKNH, string tenNH, string diaChiCN)
        {
            this.MaCTY = maCTY;
            this.MaCN = maCN;
            this.TenCN = tenCN;
            this.TenNH = tenNH;
            this.DiaChiCN = diaChiCN;
            this.DienThoaiCN = dienThoaiCN;
            this.Email = email;
            this.SoTKNH = soTKNH;
        }

        public ChiNhanh(DataRow row)
        {
            this.MaCN = (int)row["MaCN"];
            this.MaCTY = (int)row["MaCTY"];
            this.TenCN = row["TenCN"].ToString();
            this.SoTKNH = row["SoTKNH"].ToString();
            this.DiaChiCN = row["DiaChiCN"].ToString();
            this.DienThoaiCN = row["DienThoaiCN"].ToString();
            this.Email = row["Email"].ToString();
            this.TenNH = row["TenNH"].ToString();
        }
    }
}
