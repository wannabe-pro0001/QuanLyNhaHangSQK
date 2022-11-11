using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHangSQK.DTO
{
    public class KhuyenMai
    {
        private int maKM;
        private string tieuDe;
        private float mucKM;
        private DateTime ngayBatDau;
        private DateTime ngayKetThuc;
        private string noiDung;
        private bool tinhTrang;

        public int MaKM { get => maKM; set => maKM = value; }
        public string TieuDe { get => tieuDe; set => tieuDe = value; }
        public float MucKM { get => mucKM; set => mucKM = value; }
        public DateTime NgayBatDau { get => ngayBatDau; set => ngayBatDau = value; }
        public DateTime NgayKetThuc { get => ngayKetThuc; set => ngayKetThuc = value; }
        public string NoiDung { get => noiDung; set => noiDung = value; }
        public bool TinhTrang { get => tinhTrang; set => tinhTrang = value; }
        

        public KhuyenMai(int maKM, string tieuDe, float mucKM, DateTime ngayBatDau, DateTime ngayKetThuc, string noiDung, bool tinhTrang)
        {
            this.MaKM = maKM;
            this.TieuDe = tieuDe;
            this.MucKM = mucKM;
            this.NgayBatDau = ngayBatDau;
            this.NgayKetThuc = ngayKetThuc;
            this.NoiDung = noiDung;
            this.TinhTrang = tinhTrang;
        }

        public KhuyenMai(DataRow row)
        {
            this.MaKM = (int)row["MaKM"];
            this.TieuDe = row["TieuDe"].ToString();
            this.MucKM = (float)Convert.ToDouble(row["MucKM"].ToString());
            this.NgayBatDau = (DateTime)row["NgayBatDau"];
            this.NoiDung = row["NoiDung"].ToString();
            this.NgayKetThuc = (DateTime)row["NgayKetThuc"];
            this.TinhTrang = (bool)row["TinhTrang"];
        }
    }
}
