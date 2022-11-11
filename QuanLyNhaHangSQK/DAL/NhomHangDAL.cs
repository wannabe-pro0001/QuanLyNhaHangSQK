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
    public class NhomHangDAL
    {
        private static NhomHangDAL instance;

        public static NhomHangDAL Instance
        {
            get { if (instance == null) instance = new NhomHangDAL(); return instance; }
            private set => instance = value;
        }

        private NhomHangDAL() { }

        public NhomHang NhomHangHienTai(int MaNH)
        {
            DataTable data = DataProvider.Instance.ExcuteQuery("select * from tblNhomHang where MaNH = " + MaNH);

            foreach (DataRow item in data.Rows)
            {
                return new NhomHang(item);
            }
            return null;
        }

        public List<NhomHang> TaiDanhSachNhomHang()
        {
            List<NhomHang> danhSachNhomHang = new List<NhomHang>();

            DataTable data = DataProvider.Instance.ExcuteQuery("Select * from tblNhomHang");

            foreach (DataRow item in data.Rows)
            {
                NhomHang nhomHang = new NhomHang(item);
                danhSachNhomHang.Add(nhomHang);
            }

            return danhSachNhomHang;
        }

        public List<NhomHang> TaiDanhSachNhomHangTheoTen(string TenNH)
        {
            List<NhomHang> danhSachNhomHang = new List<NhomHang>();

            DataTable data = DataProvider.Instance.ExcuteQuery(string.Format("Select * from tblNhomHang where dbo.fuConvertToUnsign1(TenNH) like N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%'", TenNH));

            foreach (DataRow item in data.Rows)
            {
                NhomHang nhomHang = new NhomHang(item);
                danhSachNhomHang.Add(nhomHang);
            }

            return danhSachNhomHang;
        }

        public bool ThemNhomHang(string TenNH)
        {
            int result = DataProvider.Instance.ExcuteNonQuery(string.Format("insert into tblNhomHang (TenNH) values (N'{0}')", TenNH));

            return result > 0;
        }

        public bool SuaNhomHang(int MaNH, string TenNH)
        {
            int result = DataProvider.Instance.ExcuteNonQuery(string.Format("update tblNhomHang set TenNH = N'{0}' where MaNH = {1}", TenNH, MaNH));

            return result > 0;
        }

        public bool XoaNhomHang(int MaNH)
        {
            int result = DataProvider.Instance.ExcuteNonQuery("delete tblNhomHang where MaNH = " + MaNH);

            return result > 0;
        }

        public DataTable ListToDataTable(List<NhomHang> NhomHangs)
        {

            DataTable data = new DataTable(typeof(NhomHang).Name);
            PropertyInfo[] Props = typeof(NhomHang).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                data.Columns.Add(prop.Name);
            }
            foreach (NhomHang item in NhomHangs)
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
