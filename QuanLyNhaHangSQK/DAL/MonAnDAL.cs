using QuanLyNhaHangSQK.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHangSQK.DAL
{
    public class MonAnDAL
    {
        SqlConnection connect = new SqlConnection(DataProvider.connectionSTR);
        private static MonAnDAL instance;

        public static MonAnDAL Instance
        {
            get { if (instance == null) instance = new MonAnDAL(); return instance; }
            private set => instance = value;
        }

        private MonAnDAL() { }

        public List<MonAn> TaiDanhSachMonAn()
        {
            List<MonAn> danhSachMonAn = new List<MonAn>();

            DataTable data = DataProvider.Instance.ExcuteQuery("Select * from tblMonAn");

            foreach (DataRow item in data.Rows)
            {
                MonAn monAn = new MonAn(item);
                danhSachMonAn.Add(monAn);
            }

            return danhSachMonAn;
        }

        public List<MonAn> TaiDanhSachMonAnTheoNhomHang(int MaNH)
        {
            List<MonAn> danhSachMonAn = new List<MonAn>();

            DataTable data = DataProvider.Instance.ExcuteQuery("Select * from tblMonAn where MaNH = " + MaNH);

            foreach (DataRow item in data.Rows)
            {
                MonAn monAn = new MonAn(item);
                danhSachMonAn.Add(monAn);
            }

            return danhSachMonAn;
        }

        public List<MonAn> TimKiemMonAnTheoTenMA(string TenMA)
        {
            List<MonAn> danhSachMonAn = new List<MonAn>();

            DataTable data = DataProvider.Instance.ExcuteQuery(string.Format("Select * from tblMonAn where dbo.fuConvertToUnsign1(TenTP) like N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%'", TenMA));

            foreach (DataRow item in data.Rows)
            {
                MonAn monAn = new MonAn(item);
                danhSachMonAn.Add(monAn);
            }

            return danhSachMonAn;
        }

        public List<MonAn> TaiDanhSachMonAnTheoMaMA(int MaMA)
        {
            List<MonAn> danhSachMonAn = new List<MonAn>();

            DataTable data = DataProvider.Instance.ExcuteQuery("Select * from tblMonAn where MaMA = " + MaMA);

            foreach (DataRow item in data.Rows)
            {
                MonAn monAn = new MonAn(item);
                danhSachMonAn.Add(monAn);
            }

            return danhSachMonAn;
        }

        public MonAn MonAnHienTai(int MaMA)
        {
            DataTable data = DataProvider.Instance.ExcuteQuery("Select * from tblMonAn where MaMA = " + MaMA);

            foreach (DataRow item in data.Rows)
            {
                return new MonAn(item);
            }
            return null;
        }

        public void CapNhatAnhMonAn(int MaMA, byte[] Anh)
        {
            using (var cmd = new SqlCommand("update tblMonAn set Anh = @Anh where MaMA = @MaMA"))
            {
                cmd.Connection = connect;
                cmd.Parameters.AddWithValue("@MaMA", MaMA);
                cmd.Parameters.AddWithValue("@Anh", Anh);
                connect.Open();
                cmd.ExecuteNonQuery();
                connect.Close();
            }
        }

        public void ThemMonAn(int MaNH, string TenMA, decimal GiaTien, decimal GiaGoc, byte[] Anh, string DonViTinh)
        {
            using (var cmd = new SqlCommand("insert into tblMonAn (MaNH, TenTP, GiaTien, GiaGoc, Anh, DonViTinh) values (@MaNH, @TenMA, @GiaTien, @GiaGoc, @Anh, @DonViTinh)"))
            {
                cmd.Connection = connect;
                cmd.Parameters.AddWithValue("@MaNH", MaNH);
                cmd.Parameters.AddWithValue("@TenMA", TenMA);
                cmd.Parameters.AddWithValue("@GiaTien", GiaTien);
                cmd.Parameters.AddWithValue("@GiaGoc", GiaGoc);
                cmd.Parameters.AddWithValue("@Anh", Anh);
                cmd.Parameters.AddWithValue("@DonViTinh", DonViTinh);
                connect.Open();
                cmd.ExecuteNonQuery();
                connect.Close();
            }
        }

        public void CapNhatMonAn(int MaMA, int MaNH, string TenMA, decimal GiaTien, decimal GiaGoc, byte[] Anh, string DonViTinh)
        {
            using (var cmd = new SqlCommand("update tblMonAn set MaNH = @MaNH, TenTP = @TenMA, GiaTien = @GiaTien, GiaGoc = @GiaGoc, Anh = @Anh, DonViTinh = @DonViTinh where MaMA = " + MaMA))
            {
                cmd.Connection = connect;
                cmd.Parameters.AddWithValue("@MaNH", MaNH);
                cmd.Parameters.AddWithValue("@TenMA", TenMA);
                cmd.Parameters.AddWithValue("@GiaTien", GiaTien);
                cmd.Parameters.AddWithValue("@GiaGoc", GiaGoc);
                cmd.Parameters.AddWithValue("@Anh", Anh);
                cmd.Parameters.AddWithValue("@DonViTinh", DonViTinh);
                connect.Open();
                cmd.ExecuteNonQuery();
                connect.Close();
            }
        }

        public bool XoaMonAn(int MaMA)
        {
            int result = DataProvider.Instance.ExcuteNonQuery("delete tblMonAn where MaMA = " + MaMA);

            return result > 0;
        }

        public byte[] TaiAnhLen(int MaMA)
        {
            return (byte[])DataProvider.Instance.ExecuteScalar("Select Anh from tblMonAn where MaMA = " + MaMA);
        }

        public bool XoaMonAnTheoNhomHang(int MaNH)
        {
            int result = DataProvider.Instance.ExcuteNonQuery("delete tblMonAn where MaNH = " + MaNH);

            return result > 0;
        }

        public DataTable ListToDataTable(List<MonAn> MonAns)
        {

            DataTable data = new DataTable(typeof(MonAn).Name);
            PropertyInfo[] Props = typeof(MonAn).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                data.Columns.Add(prop.Name);
            }
            foreach (MonAn item in MonAns)
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
