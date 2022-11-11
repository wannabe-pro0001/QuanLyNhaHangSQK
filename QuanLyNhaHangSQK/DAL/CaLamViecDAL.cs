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
    public class CaLamViecDAL
    {
        private static CaLamViecDAL instance;

        public static CaLamViecDAL Instance
        {
            get { if (instance == null) instance = new CaLamViecDAL(); return instance; }
            private set { instance = value; }
        }

        private CaLamViecDAL() { }

        public CaLamViec CaLamViecNDDangNhap(string maCLV)
        {
            DataTable data = DataProvider.Instance.ExcuteQuery("Select * from tblCaLamViec where MaCLV = '" + maCLV + "'");

            foreach (DataRow item in data.Rows)
            {
                return new CaLamViec(item);
            }
            return null;
        }

        public List<CaLamViec> TaiDanhSachCaLamViec()
        {
            List<CaLamViec> danhSachCaLamViec = new List<CaLamViec>();

            DataTable data = DataProvider.Instance.ExcuteQuery("select * from tblCaLamViec");

            foreach (DataRow item in data.Rows)
            {
                CaLamViec caLamViec = new CaLamViec(item);
                danhSachCaLamViec.Add(caLamViec);
            }

            return danhSachCaLamViec;
        }

        public List<CaLamViec> TaiDanhSachCaLamViecTheoTen(string TenCLV)
        {
            List<CaLamViec> danhSachCaLamViec = new List<CaLamViec>();

            DataTable data = DataProvider.Instance.ExcuteQuery(string.Format("select * from tblCaLamViec where dbo.fuConvertToUnsign1(TenCLV) like N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%'", TenCLV));

            foreach (DataRow item in data.Rows)
            {
                CaLamViec caLamViec = new CaLamViec(item);
                danhSachCaLamViec.Add(caLamViec);
            }

            return danhSachCaLamViec;
        }

        public CaLamViec TaiCaLamViecTheoCLV(string MaCLV)
        {
            DataTable data = DataProvider.Instance.ExcuteQuery("select * from tblCaLamViec where MaCLV = '" + MaCLV + "'");

            foreach (DataRow item in data.Rows)
            {
                return new CaLamViec(item);
            }

            return null;
        }

        public bool ThemCLV(string MaCLV, string TenCLV, string GhiChu, string GioBD, string GioKT)
        {
            int result = DataProvider.Instance.ExcuteNonQuery(string.Format("insert into tblCaLamViec (MaCLV, TenCLV, GhiChu, GioBatDau, GioKetThuc) values ('{0}', N'{1}', N'{2}', '{3}', '{4}')", MaCLV, TenCLV, GhiChu, GioBD, GioKT));

            return result > 0;
        }

        public bool SuaCLV(string MaCLV, string TenCLV, string GhiChu, string GioBD, string GioKT)
        {
            int result = DataProvider.Instance.ExcuteNonQuery(string.Format("update tblCaLamViec set TenCLV = N'{0}', GhiChu = N'{1}', GioBatDau = '{2}', GioKetThuc = '{3}' where MaCLV = '{4}'", TenCLV, GhiChu, GioBD, GioKT, MaCLV));

            return result > 0;
        }

        public bool XoaCaLamViec(string MaCLV)
        {
            int result = DataProvider.Instance.ExcuteNonQuery(string.Format("delete tblCaLamViec where MaCLV = '{0}'", MaCLV));

            return result > 0;
        }

        public DataTable ListToDataTable(List<CaLamViec> caLamViecs)
        {

            DataTable data = new DataTable(typeof(CaLamViec).Name);
            PropertyInfo[] Props = typeof(CaLamViec).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                data.Columns.Add(prop.Name);
            }
            foreach (CaLamViec item in caLamViecs)
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
