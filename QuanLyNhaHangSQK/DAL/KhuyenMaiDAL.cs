using QuanLyNhaHangSQK.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHangSQK.DAL
{
    public class KhuyenMaiDAL
    {
        private static KhuyenMaiDAL instance;

        public static KhuyenMaiDAL Instance
        {
            get { if (instance == null) instance = new KhuyenMaiDAL(); return instance; }
            private set => instance = value;
        }

        private KhuyenMaiDAL() { }

        public List<KhuyenMai> LayDanhSachKhuyenMai()
        {
            List<KhuyenMai> danhSachKhuyenMai = new List<KhuyenMai>();

            DataTable data = DataProvider.Instance.ExcuteQuery("Select * from tblKhuyenMai where TinhTrang = 1");

            foreach (DataRow item in data.Rows)
            {
                KhuyenMai khuyenMai = new KhuyenMai(item);
                danhSachKhuyenMai.Add(khuyenMai);
            }

            return danhSachKhuyenMai;
        }

        public KhuyenMai LayTTKMTheoMaKM(int MaKM)
        {
            DataTable data = DataProvider.Instance.ExcuteQuery("select * from tblKhuyenMai where MaKM = " + MaKM);

            foreach (DataRow item in data.Rows)
            {
                return new KhuyenMai(item);
            }
            return null;
        }
    }
}
