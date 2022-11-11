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
    public class NguoiDungDAL
    {
        private static NguoiDungDAL instance;

        public static NguoiDungDAL Instance
        {
            get { if (instance == null) instance = new NguoiDungDAL(); return instance; }
            private set { instance = value; }
        }

        private NguoiDungDAL() { }

        public NguoiDung TaiKhoanTuEmailND(string email)
        {
            DataTable data = DataProvider.Instance.ExcuteQuery("Select * from tblNguoiDung where Email = '" + email + "'");

            foreach (DataRow item in data.Rows)
            {
                return new NguoiDung(item);
            }
            return null;
        }

        public bool CapNhatThongTinNguoiDung(int MaND, string HoTen, string NgaySinh, string GioiTinh, string DienThoai, string DiaChi, string CMND, string Email)
        {
            string query = string.Format("exec nd_capnhatthongtin  {0}, N'{1}', '{2}', N'{3}', '{4}', N'{5}', {6}, '{7}'", MaND, HoTen, NgaySinh, GioiTinh, DienThoai, DiaChi, CMND, Email);
            int result = DataProvider.Instance.ExcuteNonQuery(query);

            return result > 0; 
        }

        public bool ThayDoiMatKhau(int MaND, string MatKhau, string MatKhauMoi)
        {
            int result = DataProvider.Instance.ExcuteNonQuery(string.Format("exec nd_thaydoimatkhau @MaND = {0}, @MatKhau = '{1}', @MatKhauMoi = '{2}'", MaND, MatKhau, MatKhauMoi));

            return result > 0;
        }

        public List<NguoiDung> TaiDanhSachNguoiDung()
        {
            List<NguoiDung> danhSachNguoiDung = new List<NguoiDung>();

            DataTable data = DataProvider.Instance.ExcuteQuery("Select * from tblNguoiDung");

            foreach (DataRow item in data.Rows)
            {
                NguoiDung nguoiDUng = new NguoiDung(item);
                danhSachNguoiDung.Add(nguoiDUng);
            }

            return danhSachNguoiDung;
        }

        public List<NguoiDung> TaiDanhSachNguoiDungTheoBP(string MaBP)
        {
            List<NguoiDung> danhSachNguoiDung = new List<NguoiDung>();

            DataTable data = DataProvider.Instance.ExcuteQuery(string.Format("Select * from tblNguoiDung where MaBP = '{0}'", MaBP));

            foreach (DataRow item in data.Rows)
            {
                NguoiDung nguoiDUng = new NguoiDung(item);
                danhSachNguoiDung.Add(nguoiDUng);
            }

            return danhSachNguoiDung;
        }

        public List<NguoiDung> TaiDanhSachNguoiDungTheoChiNhanh(int MaCN)
        {
            List<NguoiDung> danhSachNguoiDung = new List<NguoiDung>();

            DataTable data = DataProvider.Instance.ExcuteQuery("Select * from tblNguoiDung where MaCN = " + MaCN);

            foreach (DataRow item in data.Rows)
            {
                NguoiDung nguoiDUng = new NguoiDung(item);
                danhSachNguoiDung.Add(nguoiDUng);
            }

            return danhSachNguoiDung;
        }

        public List<NguoiDung> TaiDanhSachNguoiDungTheoCLV(string MaCLV)
        {
            List<NguoiDung> danhSachNguoiDung = new List<NguoiDung>();

            DataTable data = DataProvider.Instance.ExcuteQuery(string.Format("Select * from tblNguoiDung where MaCLV = '{0}'", MaCLV));

            foreach (DataRow item in data.Rows)
            {
                NguoiDung nguoiDUng = new NguoiDung(item);
                danhSachNguoiDung.Add(nguoiDUng);
            }

            return danhSachNguoiDung;
        }

        public List<NguoiDung> TaiDanhSachNguoiDungTheoTenND(string HoTen)
        {
            List<NguoiDung> danhSachNguoiDung = new List<NguoiDung>();

            DataTable data = DataProvider.Instance.ExcuteQuery(string.Format("Select * from tblNguoiDung where dbo.fuConvertToUnsign1(HoTen) like N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%'", HoTen));

            foreach (DataRow item in data.Rows)
            {
                NguoiDung nguoiDUng = new NguoiDung(item);
                danhSachNguoiDung.Add(nguoiDUng);
            }

            return danhSachNguoiDung;
        }

        public bool XoaNguoiDung(int MaND)
        {
            int result = DataProvider.Instance.ExcuteNonQuery("delete tblNguoiDung where MaND = " + MaND);

            return result > 0;
        }

        public bool ThemNguoiDung(string MaBP, string MaCLV, int MaCN, string HoTen, string NgaySinh, string NgayVL, string GioiTinh, string DienThoai, string DiaChi, decimal Luong, string CMND, string Email)
        {
            int result = DataProvider.Instance.ExcuteNonQuery(string.Format("INSERT tblNguoiDung (MaBP, MaCLV, MaCN, HoTen, NgaySinh, NgayVL, GioiTinh, DienThoai, DiaChi, Luong, CMND, Email) VALUES ('{0}', '{1}', {2}, N'{3}', '{4}', '{5}', N'{6}', '{7}', N'{8}', {9}, '{10}', '{11}')", MaBP, MaCLV, MaCN, HoTen, NgaySinh, NgayVL, GioiTinh, DienThoai, DiaChi, Luong, CMND, Email));

            return result > 0;
        }

        public bool SuaNguoiDung(int MaND, string MaBP, string MaCLV, int MaCN, string HoTen, string NgaySinh, string NgayVL, string GioiTinh, string DienThoai, string DiaChi, decimal Luong, string CMND, string Email, string MatKhau, int TrangThai)
        {
            int result = DataProvider.Instance.ExcuteNonQuery(string.Format("update tblNguoiDung set MaBP = '{0}', MaCLV = '{1}', MaCN = {2}, HoTen = N'{3}', NgaySinh = '{4}', NgayVL = '{5}', GioiTinh = N'{6}', DienThoai = '{7}', DiaChi = N'{8}', Luong = {9}, CMND = '{10}', Email = '{11}', MatKhau = '{12}', TrangThai = {13} where MaND = {14}", MaBP, MaCLV, MaCN, HoTen, NgaySinh, NgayVL, GioiTinh, DienThoai, DiaChi, Luong, CMND, Email, MatKhau, TrangThai, MaND));

            return result > 0;
        }

        public NguoiDung TaithongTinNguoiDungTheoMa(int MaND)
        {
            DataTable data = DataProvider.Instance.ExcuteQuery("select * from tblNguoiDung where MaND = " + MaND);

            foreach (DataRow item in data.Rows)
            {
                return new NguoiDung(item);
            }
            return null;
        }

        public DataTable ListToDataTable(List<NguoiDung> NguoiDungs)
        {

            DataTable data = new DataTable(typeof(NguoiDung).Name);
            PropertyInfo[] Props = typeof(NguoiDung).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                data.Columns.Add(prop.Name);
            }
            foreach (NguoiDung item in NguoiDungs)
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
