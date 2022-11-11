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
    public class BanDAL
    {
        private static BanDAL instance;

        public static BanDAL Instance 
        { 
            get { if (instance == null) instance = new BanDAL(); return instance; } 
            private set => instance = value; 
        }

        private BanDAL() { }

        public List<Ban> TaiDanhSachBan()
        {
            List<Ban> danhsachBan = new List<Ban>();

            DataTable data = DataProvider.Instance.ExcuteQuery("select * from tblBan");

            foreach (DataRow item in data.Rows)
            {
                Ban ban = new Ban(item);
                danhsachBan.Add(ban);
            }

            return danhsachBan;
        }

        public List<Ban> TaiDanhSachBanTheoKV(string MaKV)
        {
            List<Ban> danhsachBan = new List<Ban>();

            DataTable data = DataProvider.Instance.ExcuteQuery("select * from tblBan where MaKV = '"+ MaKV + "'");

            foreach (DataRow item in data.Rows)
            {
                Ban ban = new Ban(item);
                danhsachBan.Add(ban);
            }

            return danhsachBan;
        }

        public List<Ban> TaiDanhSachBanTheoMaBan(int MaBan)
        {
            List<Ban> danhsachBan = new List<Ban>();

            DataTable data = DataProvider.Instance.ExcuteQuery(string.Format("select * from tblBan where dbo.fuConvertToUnsign1(MaBan) like N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%'", MaBan));

            foreach (DataRow item in data.Rows)
            {
                Ban ban = new Ban(item);
                danhsachBan.Add(ban);
            }

            return danhsachBan;
        }

        public List<Ban> TaiDanhSachBanTheoKVVaTinhTrang(string MaKV, int TinhTrang)
        {
            List<Ban> danhsachBan = new List<Ban>();

            DataTable data = DataProvider.Instance.ExcuteQuery("select * from tblBan where MaKV = '" + MaKV + "' and TinhTrang = " + TinhTrang);

            foreach (DataRow item in data.Rows)
            {
                Ban ban = new Ban(item);
                danhsachBan.Add(ban);
            }

            return danhsachBan;
        }

        public List<Ban> TaiDanhSachBanTheoTinhTrang(int TinhTrang)
        {
            List<Ban> danhsachBan = new List<Ban>();

            DataTable data = DataProvider.Instance.ExcuteQuery("select * from tblBan where TinhTrang = '" + TinhTrang + "'");

            foreach (DataRow item in data.Rows)
            {
                Ban ban = new Ban(item);
                danhsachBan.Add(ban);
            }

            return danhsachBan;
        }

        public bool KemTraTinhTrangBan(int MaBan)
        {
            DataTable data = DataProvider.Instance.ExcuteQuery("Select * from tblBan where MaBan = " + MaBan);

            if (data.Rows.Count > 0)
            {
                Ban ban = new Ban(data.Rows[0]);

                return ban.TinhTrang;
            }

            return false;
        }

        public bool XoaBan(int MaBan)
        {
            int result = DataProvider.Instance.ExcuteNonQuery("delete tblBan where MaBan = " + MaBan);

            return result > 0;
        }

        public bool ThemBan(string MaKV, string GhiChu)
        {
            int result = DataProvider.Instance.ExcuteNonQuery(string.Format("Insert into tblBan (MaBan, MaKV, GhiChu) values ('{0}', N'{1}')", MaKV, GhiChu));

            return result > 0;
        }

        public Ban BanHienTai(int MaBan)
        {
            DataTable data = DataProvider.Instance.ExcuteQuery("Select * from tblBan where MaBan = " + MaBan);

            foreach (DataRow item in data.Rows)
            {
                return new Ban(item);
            }
            return null;
        }

        public bool CapNhatBan(int MaBan, string GhiChu, string MaKV)
        {
            int result = DataProvider.Instance.ExcuteNonQuery(string.Format("update tblBan set GhiChu = N'{0}', MaKV = '{1}' where MaBan = {2}", GhiChu, MaKV, MaBan));

            return result > 0;
        }

        public void XoaBanTheoMaKhuVuc(string MaKV)
        {
            DataProvider.Instance.ExcuteNonQuery("delete tblBan where MaKV = '" + MaKV + "'");
        }

        public DataTable ListToDataTable(List<Ban> Bans)
        {

            DataTable data = new DataTable(typeof(Ban).Name);
            PropertyInfo[] Props = typeof(Ban).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                data.Columns.Add(prop.Name);
            }
            foreach (Ban item in Bans)
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
