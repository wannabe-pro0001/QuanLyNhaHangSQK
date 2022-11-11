using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHangSQK.DTO
{
    public class BoPhan
    {
        private string maBP;
        private string tenBP;

        public string MaBP { get => maBP; set => maBP = value; }
        public string TenBP { get => tenBP; set => tenBP = value; }

        public BoPhan(string maBP, string tenBP)
        {
            this.MaBP = maBP;
            this.TenBP = tenBP;
        }

        public BoPhan(DataRow row)
        {
            this.MaBP = row["MaBP"].ToString();
            this.TenBP = row["TenBP"].ToString();
        }
    }
}
