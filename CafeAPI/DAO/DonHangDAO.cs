using CafeAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CafeAPI.DAO
{
    public class DonHangDAO
    {
        private Connection cn = new Connection();
        public int[] ConvertStringToArray(string s)
        {
            string[] a = s.Split(',');
            int[] so = new int[a.Length];
            for(int i = 0; i<a.Length; i++)
            {
                so[i] = Convert.ToInt32(a[i].Trim());
            }
            return so;
        }
        public List<DONHANG> GetListDONHANG()
        {
            List<DONHANG> lst = cn.ConvertToList<DONHANG>(GetDataDONHANG());
            return lst;
        }
        private DataTable GetDataDONHANG()
        {
            string query = "select * from DONHANG";
            DataTable tb = cn.LoadTable(query);
            return tb;
        }
        public DONHANG GetDONHANG(int id)
        {
            string query = "select * from dbo.getDonHang(@id)";
            string[] para = new string[1] { "@id" };
            object[] value = new object[1] { id };
            DataTable tb = cn.FillDataTable(query, CommandType.Text, para, value);
            DONHANG dh = cn.ConvertToList<DONHANG>(tb)[0];
            return dh;
        }
        public int InsertDonHang(DONHANG dh)
        {
            try
            {
                string query = "insertDonHang";
                string[] para = new string[5] { "@nguoinhan", "@sdt", "@diachi", "@idKH","@tongtien" };
                object[] value = new object[5] { dh.TENNGUOINHAN, dh.SDT, dh.DIACHI, dh.KHACHHANG_ID,dh.TONGTIEN };
                cn.Excute_Sql(query, CommandType.StoredProcedure, para, value);
                query = "select dbo.getNewIdDonHang()";
                DataTable tb = cn.LoadTable(query);
                int id = Convert.ToInt32(tb.Rows[0][0]);
             
                return id;
            }
            catch
            {
                throw;
            }
        }
        public void UpdateTRANGTHAIDH(int idDH, int? trang_thai_moi)
        {
            string query = "updateTrangThaiDH";
            string[] para = new string[2] { "@idDH", "@idTrangThaiMoi" };
            object[] value = new object[2] { idDH, trang_thai_moi };
            cn.Excute_Sql(query, CommandType.StoredProcedure, para, value);
        }
    }
}