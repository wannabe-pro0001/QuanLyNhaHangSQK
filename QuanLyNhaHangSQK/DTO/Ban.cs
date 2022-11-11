using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHangSQK.DTO
{
    public class Ban
    {
        private int maBan;
        private string maKV;
        private string ghiChu;
        private bool tinhTrang;

        public int MaBan { get => maBan; set => maBan = value; }
        public string MaKV { get => maKV; set => maKV = value; }
        public string GhiChu { get => ghiChu; set => ghiChu = value; }
        public bool TinhTrang { get => tinhTrang; set => tinhTrang = value; }

        public Ban(int maBan, string maKV, string ghiChu, bool tinhTrang)
        {
            this.MaBan = maBan;
            this.MaKV = maKV;
            this.GhiChu = ghiChu;
            this.TinhTrang = tinhTrang;
        }

        public Ban(DataRow row)
        {
            this.MaBan = (int)row["MaBan"];
            this.MaKV = row["MaKV"].ToString();
            this.GhiChu = row["GhiChu"].ToString();
            this.TinhTrang = (bool)row["TinhTrang"]; 
        }
    }

}
