using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHangSQK.DTO
{
    public class CaLamViec
    {
        private string maCLV;
        private string tenCLV;
        private TimeSpan gioBatDau;
        private TimeSpan gioKetThuc;
        private string ghiChu;

        public string MaCLV { get => maCLV; set => maCLV = value; }
        public string TenCLV { get => tenCLV; set => tenCLV = value; }
        public TimeSpan GioBatDau { get => gioBatDau; set => gioBatDau = value; }
        public TimeSpan GioKetThuc { get => gioKetThuc; set => gioKetThuc = value; }
        public string GhiChu { get => ghiChu; set => ghiChu = value; }

        public CaLamViec(string maCLV, string tenCLV, TimeSpan gioBatDau, TimeSpan gioKetThuc, string ghiChu)
        {
            this.MaCLV = maCLV;
            this.TenCLV = tenCLV;
            this.GioBatDau = gioBatDau;
            this.GioKetThuc = gioKetThuc;
            this.GhiChu = ghiChu;
        }
        
        public CaLamViec(DataRow row)
        {
            this.MaCLV = row["MaCLV"].ToString();
            this.TenCLV = row["TenCLV"].ToString();
            this.GioBatDau = (TimeSpan)row["GioBatDau"];
            this.GioKetThuc = (TimeSpan)row["GioKetThuc"];
            this.GhiChu = row["GhiChu"].ToString();

        }
    }
}
