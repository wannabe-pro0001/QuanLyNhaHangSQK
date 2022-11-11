using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHangSQK.DTO
{
    public class NguoiDung
    {
        private int maND;
        private string maBP;
        private string maCLV;
        private int maCN;
        private string gioiTinh;
        private DateTime ngayVL;
        private string hoTen;
        private DateTime ngaySinh;
        private string dienThoai;
        private string diaChi;
        private decimal luong;
        private string cMND;
        private string email;
        private string matKhau;
        private bool trangThai;

        public int MaND { get => maND; set => maND = value; }
        public string MaBP { get => maBP; set => maBP = value; }

        public string HoTen { get => hoTen; set => hoTen = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }

        public string Email { get => email; set => email = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }
        public decimal Luong { get => luong; set => luong = value; }
        public string MaCLV { get => maCLV; set => maCLV = value; }
        public int MaCN { get => maCN; set => maCN = value; }
        public DateTime NgayVL { get => ngayVL; set => ngayVL = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string CMND { get => cMND; set => cMND = value; }
        public string DienThoai { get => dienThoai; set => dienThoai = value; }
        public bool TrangThai { get => trangThai; set => trangThai = value; }

        public NguoiDung(int maND, DateTime ngayVL, string maBP, string gioiTinh, string maCLV, string hoTen, DateTime ngaySinh, string dienThoai, string diaChi, decimal luong, string cMND, string email, string matKhau, int maCN, bool trangThai)
        {
            this.MaND = maND;
            this.MaCN = maCN;
            this.MaBP = maBP;
            this.MaCLV = maCLV;
            this.HoTen = hoTen;
            this.NgaySinh = ngaySinh;
            this.DienThoai = dienThoai;
            this.DiaChi = diaChi;
            this.Luong = luong;
            this.CMND = cMND;
            this.Email = email;
            this.MatKhau = matKhau;
            this.NgayVL = ngayVL;
            this.GioiTinh = gioiTinh;
            this.TrangThai = trangThai;
        }

        public NguoiDung(DataRow row)
        {
            this.MaND = (int)row["MaND"];
            this.MaBP = row["MaBP"].ToString();
            this.MaCLV = row["MaCLV"].ToString();
            this.HoTen = row["HoTen"].ToString();
            this.NgaySinh = (DateTime)row["NgaySinh"];
            this.DienThoai = row["DienThoai"].ToString();
            this.DiaChi = row["DiaChi"].ToString();
            this.Luong = (decimal)row["Luong"];
            this.CMND = row["CMND"].ToString();
            this.Email = row["Email"].ToString();
            this.MatKhau = row["MatKhau"].ToString();
            this.MaCN = (int)row["MaCN"];
            this.NgayVL = (DateTime)row["NgayVL"];
            this.GioiTinh = row["GioiTinh"].ToString();
            this.TrangThai = (bool)row["TrangThai"];
        }
    }
}
