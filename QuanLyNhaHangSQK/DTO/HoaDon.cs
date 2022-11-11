using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHangSQK.DTO
{
    public class HoaDon
    {
        private int maHD;
        private int? maKH;
        private int maND;
        private int maBan;
        private int? maKM;
        private DateTime? tGTT;
        private bool tinhTrang;

        public int MaHD { get => maHD; set => maHD = value; }
        public int? MaKH { get => maKH; set => maKH = value; }
        public int MaND { get => maND; set => maND = value; }
        public int MaBan { get => maBan; set => maBan = value; }
        public int? MaKM { get => maKM; set => maKM = value; }
        public DateTime? TGTT { get => tGTT; set => tGTT = value; }
        public bool TinhTrang { get => tinhTrang; set => tinhTrang = value; }

        public HoaDon(int maHD, int maKH, int maND, int maBan, int maKM, DateTime tGTT, bool tinhTrang)
        {
            this.MaBan = maBan;
            this.MaHD = maHD;
            this.MaKH = maKH;
            this.MaKM = maKM;
            this.MaND = maND;
            this.TGTT = tGTT;
            this.TinhTrang = tinhTrang;
        }

        public HoaDon(DataRow row)
        {
            this.MaKH = (int)row["MaKH"];
            this.MaBan = (int)row["MaBan"];
            this.MaHD = (int)row["MaHD"];
            this.MaKM = (int)row["MaKM"];
            this.MaND = (int)row["MaND"];
            this.TGTT = (DateTime)row["TGTT"];
            this.TinhTrang = (bool)row["TinhTrang"];
        }

    }
}
