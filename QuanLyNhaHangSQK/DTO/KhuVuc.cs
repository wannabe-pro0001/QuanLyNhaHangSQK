using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHangSQK.DTO
{
    public class KhuVuc
    {
        private string maKV;
        private string tenKV;

        public string MaKV { get => maKV; set => maKV = value; }
        public string TenKV { get => tenKV; set => tenKV = value; }

        public KhuVuc(string maKV, string tenKV)
        {
            this.MaKV = maKV;
            this.TenKV = tenKV;
        }
        public KhuVuc(DataRow row)
        {
            this.MaKV = row["MaKV"].ToString();
            this.TenKV = row["TenKV"].ToString();
        }

    }
}
