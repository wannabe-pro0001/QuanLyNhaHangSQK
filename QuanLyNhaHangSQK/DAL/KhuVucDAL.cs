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
    public class KhuVucDAL
    {
        private static KhuVucDAL instance;

        public static KhuVucDAL Instance
        {
            get { if (instance == null) instance = new KhuVucDAL(); return instance; }
            private set => instance = value;
        }

        private KhuVucDAL() { }

        public List<KhuVuc> LayDanhSachKhuVuc()
        {
            List<KhuVuc> danhSachKhuVuc = new List<KhuVuc>();

            DataTable data = DataProvider.Instance.ExcuteQuery("Select * from tblKhuVuc");

            foreach (DataRow item in data.Rows)
            {
                KhuVuc khuVuc = new KhuVuc(item);
                danhSachKhuVuc.Add(khuVuc);
            }

            return danhSachKhuVuc;
        }

        public List<KhuVuc> LayDanhSachKhuVucTheoTen(string TenKV)
        {
            List<KhuVuc> danhSachKhuVuc = new List<KhuVuc>();

            DataTable data = DataProvider.Instance.ExcuteQuery(string.Format("Select * from tblKhuVuc where dbo.fuConvertToUnsign1(TenKV) like N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%'", TenKV));

            foreach (DataRow item in data.Rows)
            {
                KhuVuc khuVuc = new KhuVuc(item);
                danhSachKhuVuc.Add(khuVuc);
            }

            return danhSachKhuVuc;
        }

        public string LayTenKhuVucTheoMa(string MaKV)
        {
            DataTable data = DataProvider.Instance.ExcuteQuery(string.Format("Select * from tblKhuVuc where MaKV = '{0}'", MaKV));

            if (data.Rows.Count > 0)
            {
                KhuVuc khuVuc = new KhuVuc(data.Rows[0]);
                return khuVuc.TenKV;
            }

            return null;
        }

        public bool XoaKhuVuc(string MaKV)
        {
            int result = DataProvider.Instance.ExcuteNonQuery("delete tblKhuVuc where MaKV = '" + MaKV + "'");

            return result > 0;
        }

        public bool ThemKhuVuc(string MaKV, string TenKV)
        {
            int result = DataProvider.Instance.ExcuteNonQuery(string.Format("insert into tblKhuVuc (MaKV, TenKV) values ('{0}', N'{1}')", MaKV, TenKV));

            return result > 0;
        }

        public bool SuaKhuVuc(string MaKV, string TenKV)
        {
            int result = DataProvider.Instance.ExcuteNonQuery(string.Format("update tblKhuVuc set TenKV = N'{0}' where MaKV = '{1}'", TenKV, MaKV));

            return result > 0;
        }

        public DataTable ListToDataTable(List<KhuVuc> khuVucs)
        {

            DataTable data = new DataTable(typeof(KhuVuc).Name);
            PropertyInfo[] Props = typeof(KhuVuc).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                data.Columns.Add(prop.Name);
            }
            foreach (KhuVuc item in khuVucs)
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
