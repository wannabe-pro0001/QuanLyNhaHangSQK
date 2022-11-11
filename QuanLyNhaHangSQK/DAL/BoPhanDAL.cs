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
    public class BoPhanDAL
    {
        private static BoPhanDAL instance;

        public static BoPhanDAL Instance
        {
            get { if (instance == null) instance = new BoPhanDAL(); return instance; }
            private set { instance = value; }
        }

        private BoPhanDAL() { }

        public BoPhan BoPhanNDDangNhap(string maBP)
        {
            DataTable data = DataProvider.Instance.ExcuteQuery("Select * from tblBoPhan where MaBP = '" + maBP + "'");

            foreach (DataRow item in data.Rows)
            {
                return new BoPhan(item);
            }
            return null;
        }

        public bool CapNhatBoPhanNguoiDung(int MaBP, string TenBP)
        {
            string query = string.Format("exec nd_capnhatbophan  N'{0}', N'{1}'", MaBP, TenBP);
            int result = DataProvider.Instance.ExcuteNonQuery(query);

            return result > 0;
        }

        public List<BoPhan> TaiDanhSachBoPhan()
        {
            List<BoPhan> danhSachBoPhan = new List<BoPhan>();

            DataTable data = DataProvider.Instance.ExcuteQuery("Select * from tblBoPhan");

            foreach (DataRow item in data.Rows)
            {
                BoPhan boPhan = new BoPhan(item);
                danhSachBoPhan.Add(boPhan);
            }

            return danhSachBoPhan;
        }

        public BoPhan TaiBoPhanTheoBP(string MaBP)
        {
            DataTable data = DataProvider.Instance.ExcuteQuery("select * from tblBoPhan where MaBP = '" + MaBP + "'");

            foreach (DataRow item in data.Rows)
            {
                return new BoPhan(item);
            }

            return null;
        }

        public bool ThemBoPhan(string MaBP, string TenBP)
        {
            int result = DataProvider.Instance.ExcuteNonQuery(string.Format("insert into tblBoPhan (MaBP, TenBP) values ('{0}', N'{1}')", MaBP, TenBP));

            return result > 0;
        }

        public bool XoaBoPhan(string MaBP)
        {
            int result = DataProvider.Instance.ExcuteNonQuery(string.Format("delete tblBoPhan where MaBP = '{0}'", MaBP));

            return result > 0;
        }

        public bool SuaBoPhan(string MaBP, string TenBP)
        {
            int result = DataProvider.Instance.ExcuteNonQuery(string.Format("update tblBoPhan set TenBP = N'{0}' where MaBP = '{1}'", TenBP, MaBP));

            return result > 0;
        }

        public List<BoPhan> TaiDanhSachBoPhanTheoTen(string TenBP)
        {
            List<BoPhan> danhSachBoPhan = new List<BoPhan>();

            DataTable data = DataProvider.Instance.ExcuteQuery(string.Format("Select * from tblBoPhan where dbo.fuConvertToUnsign1(TenBP) like N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%'", TenBP));

            foreach (DataRow item in data.Rows)
            {
                BoPhan boPhan = new BoPhan(item);
                danhSachBoPhan.Add(boPhan);
            }

            return danhSachBoPhan;
        }

        public DataTable ListToDataTable(List<BoPhan> boPhans)
        {

            DataTable data = new DataTable(typeof(BoPhan).Name);
            PropertyInfo[] Props = typeof(BoPhan).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                data.Columns.Add(prop.Name);
            }
            foreach (BoPhan item in boPhans)
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
