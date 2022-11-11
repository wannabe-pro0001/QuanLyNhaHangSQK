using QuanLyNhaHangSQK.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHangSQK.DAL
{
    public class DangNhapDAL
    {
        private static DangNhapDAL instance;

        public static DangNhapDAL Instance 
        {
            get { if (instance == null) instance = new DangNhapDAL(); return instance; }
            private set { instance = value; }
        }

        private DangNhapDAL() { }

        public bool DangNhap(string email, string matKhau)
        {
            string query = string.Format("nd_dangnhap '{0}', '{1}'", email, matKhau);

            DataTable result = DataProvider.Instance.ExcuteQuery(query);

            return result.Rows.Count > 0;
        }

        
    }
}
