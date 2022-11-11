using QuanLyNhaHangSQK.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace QuanLyNhaHangSQK.DAL
{
    public class HoaDonDAL
    {
        private static HoaDonDAL instance;

        public static HoaDonDAL Instance
        {
            get { if (instance == null) instance = new HoaDonDAL(); return instance; }
            private set { instance = value; }
        }

        private HoaDonDAL() { }

        public int LayMaHDTheoBan(int MaBan)
        {
            DataTable data = DataProvider.Instance.ExcuteQuery("Select * from tblHoaDon where MaBan = " + MaBan + " and TinhTrang = 0");

            if (data.Rows.Count > 0)
            {
                HoaDon hoaDon = new HoaDon(data.Rows[0]);
                return hoaDon.MaHD;
            }

            return -1;
        }

        public void ThemHoaDon(int MaND, int MaBan)
        {
            DataProvider.Instance.ExcuteNonQuery(string.Format(@"exec hd_themhoadon {0}, {1}", MaND, MaBan));
        }

        public void UpdateMaKHHoaDon(int MaHD, int MaKH)
        {
            DataProvider.Instance.ExcuteNonQuery(string.Format(@"update tblHoaDon set MaKH = {0} where MaHD = {1}", MaKH, MaHD));
        }

        public int LayMaHDLonNhat()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("Select MAX(MaHD) from tblHoaDon");
            }
            catch
            {
                return 1;
            }
        }

        public HoaDon LayHDTheoMaHD(int MaHD)
        {
            DataTable data = DataProvider.Instance.ExcuteQuery("Select * from tblMaHD where MaHD = " + MaHD);

            foreach (DataRow item in data.Rows)
            {
                return new HoaDon(item);
            }
            return null;
        }

        public void ThanhToan(int MaHD, int MaKM)
        {
            DataProvider.Instance.ExcuteNonQuery(string.Format("Update tblHoaDon set TinhTrang = 1, TGTT = GETDATE(), MaKM = {0}  where MaHD = {1}", MaKM, MaHD));
        }

        public bool ChuyenHoaDon(int MaBanCu, int MaBanMoi, int MaHD)
        {
            int result = DataProvider.Instance.ExcuteNonQuery(string.Format("exec ban_chuyenban {0}, {1}, {2}", MaBanCu, MaBanMoi, MaHD));

            return result > 0;
        }

        public bool GopHoaDon(int MaBanCu, int MaBanMoi, int MaHDCu, int MaHDMoi)
        {
            int result = DataProvider.Instance.ExcuteNonQuery(string.Format("exec ban_gopban {0}, {1}, {2}, {3}", MaBanCu, MaBanMoi, MaHDCu, MaHDMoi));

            return result > 0;
        }

        public List<HoaDon> TaiDanhSachHoaDon()
        {
            List<HoaDon> danhSachHoaDon = new List<HoaDon>();

            DataTable data = DataProvider.Instance.ExcuteQuery("select * from tblHoaDon where TinhTrang = 1");

            foreach (DataRow item in data.Rows)
            {
                HoaDon hoaDon = new HoaDon(item);
                danhSachHoaDon.Add(hoaDon);
            }

            return danhSachHoaDon;
        }

        public List<HoaDon> TaiDanhSachHoaDonTheoNgay(string NgayBD, string NgayKT)
        {
            List<HoaDon> danhSachHoaDon = new List<HoaDon>();

            DataTable data = DataProvider.Instance.ExcuteQuery(string.Format("select * from tblHoaDon where TGTT between '{0}' and '{1}'", NgayBD, NgayKT));

            foreach (DataRow item in data.Rows)
            {
                HoaDon hoaDon = new HoaDon(item);
                danhSachHoaDon.Add(hoaDon);
            }

            return danhSachHoaDon;
        }

        public List<HoaDon> TaiDanhSachHoaDonTheoMaHD(int MaHD)
        {
            List<HoaDon> danhSachHoaDon = new List<HoaDon>();

            DataTable data = DataProvider.Instance.ExcuteQuery(string.Format("select * from tblHoaDon where dbo.fuConvertToUnsign1(MaHD) like N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%'", MaHD));

            foreach (DataRow item in data.Rows)
            {
                HoaDon hoaDon = new HoaDon(item);
                danhSachHoaDon.Add(hoaDon);
            }

            return danhSachHoaDon;
        }

        public int LayMaKMTheoHoaDon(int MaHD)
        {
            return (int)DataProvider.Instance.ExecuteScalar("select MaKM from tblHoaDon where MaHD = " + MaHD);
        }

        public int LayMaKHTheoHoaDon(int MaHD)
        {
            return (int)DataProvider.Instance.ExecuteScalar("select MaKH from tblHoaDon where MaHD = " + MaHD);
        }

        public DataTable ListToDataTable(List<HoaDon> hoaDons)
        {

            DataTable data = new DataTable(typeof(HoaDon).Name);
            PropertyInfo[] Props = typeof(HoaDon).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                data.Columns.Add(prop.Name);
            }
            foreach (HoaDon item in hoaDons)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    values[i] = Props[i].GetValue(item, null);

                }
                data.Rows.Add(values);
            }
            return data;
        }
    }
}
