using CafeAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CafeAPI.DAO
{
    public class NhapHangDAO
    {
        private Connection cn = new Connection();
        public int[] ConvertStringToArray(string s)
        {
            string[] a = s.Split(',');
            int[] so = new int[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                so[i] = Convert.ToInt32(a[i].Trim());
            }
            return so;
        }
          public List<NHAPHANG> GetNHAPHANG()
          {
               List<NHAPHANG> lst = cn.ConvertToList<NHAPHANG>(GetDataNHAPHANG());
               return lst;
          }
          public DataTable GetDataNHAPHANG()
          {
               string query = "select * from NHAPHANG";
               DataTable tb = cn.LoadTable(query);
               return tb;
          }
          public NHAPHANG GetNHAPHANGbyId(int id)
          {
               string query = "select * from NHAPHANG where ID = @id";
               string[] para = new string[1] { "@id" };
               object[] value = new object[1] { id };
               DataTable tb = cn.FillDataTable(query, CommandType.Text, para, value);
               NHAPHANG sp = cn.ConvertToList<NHAPHANG>(tb)[0];
               return sp;
          }
          public List<CHITIETNHAPHANG> GetCTNHAPHANG()
          {
               List<CHITIETNHAPHANG> lst = cn.ConvertToList<CHITIETNHAPHANG>(GetDataCHITIETNHAPHANG());
               return lst;
          }
          public DataTable GetDataCHITIETNHAPHANG()
          {
               string query = "select * from CHITIETNHAPHANG";
               DataTable tb = cn.LoadTable(query);
               return tb;
          }
          public CHITIETNHAPHANG GetCHITIETNHAPHANGbyId(int id)
          {
               string query = "select * from CHITIETNHAPHANG where ID = @id";
               string[] para = new string[1] { "@id" };
               object[] value = new object[1] { id };
               DataTable tb = cn.FillDataTable(query, CommandType.Text, para, value);
               CHITIETNHAPHANG sp = cn.ConvertToList<CHITIETNHAPHANG>(tb)[0];
               return sp;
          }
          public CHITIETNHAPHANG GetCHITIETNHAPHANGbyIDSP(int id,int id2)
          {
               string query = "select * from CHITIETNHAPHANG where SANPHAM_ID = @id AND NHAPHANG_ID=@id2";
               string[] para = new string[2] { "@id","@id2" };
               object[] value = new object[2] { id,id2 };
               DataTable tb = cn.FillDataTable(query, CommandType.Text, para, value);
               CHITIETNHAPHANG sp = cn.ConvertToList<CHITIETNHAPHANG>(tb)[0];
               return sp;
          }

          public int InsertNhapHang(NHAPHANG nh)
          {
            try
            {
                string query = "insertNhaphang";
                string[] para = new string[1] { "@idNCC" };
                object[] value = new object[1] { nh.NHACC_ID };
                cn.Excute_Sql(query, CommandType.StoredProcedure, para, value);
                query = "select dbo.getNewIdNhapHang()";
                DataTable tb = cn.LoadTable(query);
                int id = Convert.ToInt32(tb.Rows[0][0]);
                return id;
            }
            catch(Exception ex)
            {
                throw;
            }
            
          }
          public void UpdateNHAPHANG(NHAPHANG nh)
          {
               string query = "update NHAPHANG set TONGTIEN=@tt where ID=@id";
               string[] para = new string[2] { "@id", "@tt" };
               object[] value = new object[2] { nh.ID,nh.TONGTIEN};
               cn.Excute_Sql(query, CommandType.Text, para, value);
          }
          public void InsertCTNhapHang(CHITIETNHAPHANG ct)
        {
            string query = "insertCHITIETNHAPHANG";
            string[] para = new string[4] { "@idSanPham", "@idNhapHang", "@soluongnhap", "@gianhap" };
            object[] value = new object[4] { ct.SANPHAM_ID, ct.NHAPHANG_ID, ct.SOLUONGNHAP, ct.GIANHAP };
            cn.Excute_Sql(query, CommandType.StoredProcedure, para, value);
        }
          public void UpdateCTNH(CHITIETNHAPHANG ct)
          {
               string query = "update CHITIETNHAPHANG set SOLUONGCONLAI = @sl where ID=@id";
               string[] para = new string[2] { "@id", "@sl" };
               object[] value = new object[2] { ct.ID, ct.SOLUONGCONLAI };
               cn.Excute_Sql(query, CommandType.Text, para, value);
          }
     }
}