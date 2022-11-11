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
    public class KhachHangDAL
    {
        private static KhachHangDAL instance;

        public static KhachHangDAL Instance 
        { 
            get { if (instance == null) instance = new KhachHangDAL(); return instance; }
            private set => instance = value; 
        }

        private KhachHangDAL() { }

        public int ThemVaLayKhachHangMoi(string TenKH, string DienThoai)
        {
            DataProvider.Instance.ExcuteNonQuery(string.Format("Insert into tblKhachHang values ( N'{0}', '{1}')", TenKH, DienThoai));

            return (int)DataProvider.Instance.ExecuteScalar("Select MAX(MaKH) from tblKhachHang");
        }

        public void UpdateKhachHangCu(int MaKH, string TenKH, string DienThoai)
        {
            DataProvider.Instance.ExcuteNonQuery(string.Format("exec kh_updatekhachhang {0}, N'{1}', '{2}'", MaKH, TenKH, DienThoai));
        }

        public List<KhachHang> TimKiemKhachHang(int MaKH)
        {
            List<KhachHang> danhSachKhachHang = new List<KhachHang>();

            DataTable  data =  DataProvider.Instance.ExcuteQuery(string.Format("select * from tblKhachHang where MaKH = {0}", MaKH));

            foreach (DataRow item in data.Rows)
            {
                KhachHang khachHang = new KhachHang(item);
                danhSachKhachHang.Add(khachHang);
            }

            return danhSachKhachHang;
        }

        public List<KhachHang> TimKiemKhachHang(string HoTen)
        {
            List<KhachHang> danhSachKhachHang = new List<KhachHang>();

            DataTable data = DataProvider.Instance.ExcuteQuery(string.Format("select * from tblKhachHang where dbo.fuConvertToUnsign1(HoTen) like N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%'", HoTen));

            foreach (DataRow item in data.Rows)
            {
                KhachHang khachHang = new KhachHang(item);
                danhSachKhachHang.Add(khachHang);
            }

            return danhSachKhachHang;
        }

        public KhachHang LayTTKHTheoMaKH(int MaKH)
        {
            DataTable data = DataProvider.Instance.ExcuteQuery("select * from tblKhachHang where MaKH = " + MaKH);

            foreach (DataRow item in data.Rows)
            {
                return new KhachHang(item);
            }
            return null;
        }

        public List<KhachHang> TaiDanhSachKhachHang()
        {
            List<KhachHang> danhSachKhachHang = new List<KhachHang>();

            DataTable data = DataProvider.Instance.ExcuteQuery("select * from tblKhachHang");

            foreach (DataRow item in data.Rows)
            {
                KhachHang khachHang = new KhachHang(item);
                danhSachKhachHang.Add(khachHang);
            }
            return danhSachKhachHang;
        }

        public bool SuaKhachHang(int MaKH, string HoTen, string DienThoai)
        {
            int result = DataProvider.Instance.ExcuteNonQuery(string.Format("update tblKhachHang set HoTen = N'{0}', DienThoai = '{1}' where MaKH = {2}", HoTen, DienThoai, MaKH));

            return result > 0;
        }

        public DataTable ListToDataTable(List<KhachHang> KhachHangs)
        {

            DataTable data = new DataTable(typeof(KhachHang).Name);
            PropertyInfo[] Props = typeof(KhachHang).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                data.Columns.Add(prop.Name);
            }
            foreach (KhachHang item in KhachHangs)
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
