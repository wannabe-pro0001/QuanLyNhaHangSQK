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
    public class ChiNhanhDAL
    {
        private static ChiNhanhDAL instance;

        public static ChiNhanhDAL Instance
        {
            get { if (instance == null) instance = new ChiNhanhDAL(); return instance; }
            private set { instance = value; }
        }

        private ChiNhanhDAL() { }


        public ChiNhanh TaiChiNhanhTheoCN(int MaCN)
        {
            DataTable data = DataProvider.Instance.ExcuteQuery("select * from tblChiNhanh where MaCN = " + MaCN);

            foreach (DataRow item in data.Rows)
            {
                return new ChiNhanh(item);
            }

            return null;
        }

        public List<ChiNhanh> TaiDanhSachChiNhanh()
        {
            List<ChiNhanh> danhSachChiNhanh = new List<ChiNhanh>();

            DataTable data = DataProvider.Instance.ExcuteQuery("Select * from tblChiNhanh");

            foreach (DataRow item in data.Rows)
            {
                ChiNhanh chiNhanh = new ChiNhanh(item);
                danhSachChiNhanh.Add(chiNhanh);
            }

            return danhSachChiNhanh;
        }

        public List<ChiNhanh> TaiDanhSachChiNhanhTheoMaCTY(int MaCTY)
        {
            List<ChiNhanh> danhSachChiNhanh = new List<ChiNhanh>();

            DataTable data = DataProvider.Instance.ExcuteQuery("Select * from tblChiNhanh where MaCTY = " + MaCTY);

            foreach (DataRow item in data.Rows)
            {
                ChiNhanh chiNhanh = new ChiNhanh(item);
                danhSachChiNhanh.Add(chiNhanh);
            }

            return danhSachChiNhanh;
        }

        public List<ChiNhanh> TaiDanhSachChiNhanhTheoTen(string TenCN)
        {
            List<ChiNhanh> danhSachChiNhanh = new List<ChiNhanh>();

            DataTable data = DataProvider.Instance.ExcuteQuery(string.Format("Select * from tblChiNhanh where dbo.fuConvertToUnsign1(TenCN) like N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%'", TenCN));

            foreach (DataRow item in data.Rows)
            {
                ChiNhanh chiNhanh = new ChiNhanh(item);
                danhSachChiNhanh.Add(chiNhanh);
            }

            return danhSachChiNhanh;
        }

        public bool ThemChiNhanh(string TenCN, string DiaChi, string DienThoai, string Email, string TenNH, string SoTKNH, int MaCTY)
        {
            int result = DataProvider.Instance.ExcuteNonQuery(string.Format("INSERT into tblChiNhanh (MaCTY, TenCN, DienThoaiCN, Email, SoTKNH, TenNH, DiaChiCN) VALUES ({0}, N'{1}', N'{2}', N'{3}', N'{4}', N'{5}', N'{6}')", MaCTY, TenCN, DienThoai, Email, SoTKNH, TenNH, DiaChi));

            return result > 0;
        }

        public bool SuaChiNhanh(string TenCN, string DiaChi, string DienThoai, string Email, string TenNH, string SoTKNH, int MaCTY, int MaCN)
        {
            int result = DataProvider.Instance.ExcuteNonQuery(string.Format("Update tblChiNhanh set TenCN = N'{0}', DienThoaiCN = '{1}', Email = '{2}', SoTKNH = '{3}', TenNH = N'{4}', DiaChiCN = N'{5}', MaCTY = {6} where MaCN = {7}", TenCN, DienThoai, Email, SoTKNH, TenNH, DiaChi, MaCTY, MaCN));

            return result > 0;
        }

        public bool XoaChiNhanh(int MaCN)
        {
            int result = DataProvider.Instance.ExcuteNonQuery(string.Format("delete tblChiNhanh where MaCN = {0} ", MaCN));

            return result > 0;
        }

        public DataTable ListToDataTable(List<ChiNhanh> chiNhanhs)
        {

            DataTable data = new DataTable(typeof(ChiNhanh).Name);
            PropertyInfo[] Props = typeof(ChiNhanh).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                data.Columns.Add(prop.Name);
            }
            foreach (ChiNhanh item in chiNhanhs)
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
