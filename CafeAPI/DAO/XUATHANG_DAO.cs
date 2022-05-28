using CafeAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CafeAPI.DAO
{
     
     public class XUATHANG_DAO
     {
          private Connection cn = new Connection();
          public List<XUATHANG> GetXUATHANG()
          {
               List<XUATHANG> lst = cn.ConvertToList<XUATHANG>(GetDataXUATHANG());
               return lst;
          }
          public DataTable GetDataXUATHANG()
          {
               string query = "select * from XUATHANG";
               DataTable tb = cn.LoadTable(query);
               return tb;
          }
          public XUATHANG GetXUATHANGbyId(int id)
          {
               string query = "select * from XUATHANG where ID = @id";
               string[] para = new string[1] { "@id" };
               object[] value = new object[1] { id };
               DataTable tb = cn.FillDataTable(query, CommandType.Text, para, value);
               XUATHANG sp = cn.ConvertToList<XUATHANG>(tb)[0];
               return sp;
          }
          public void InsertXUATHANG(XUATHANG xh)
          {
               string query = "insertXUATHANG";
               string[] para = new string[5] { "@idCTNhapHang", "@idCTDonHang", "@soluongxuat", "@gianhap", "@giaban" };
               object[] value = new object[5] { xh.NHAPHANG_ID,xh.CHITIETDH_ID,xh.SOLUONGXUAT,xh.GIANHAP ,xh.GIABAN};
               cn.Excute_Sql(query, CommandType.StoredProcedure, para, value);
          }
          public void UpdateXUATHANG(XUATHANG xh)
          {
               string query = "updateXUATHANG";
               string[] para = new string[6] { "@id","@idCTNhapHang", "@idCTDonHang", "@soluongxuat", "@gianhap", "@giaban" };
               object[] value = new object[6] { xh.ID, xh.NHAPHANG_ID, xh.CHITIETDH_ID, xh.SOLUONGXUAT, xh.GIANHAP, xh.GIABAN };
               cn.Excute_Sql(query, CommandType.StoredProcedure, para, value);
          }
          public void DeleteXUATHANG(XUATHANG xh)
          {
               string query = "deleteXUATHANG";
               string[] para = new string[1] { "@id" };
               object[] value = new object[1] { xh.ID };
               cn.Excute_Sql(query, CommandType.StoredProcedure, para, value);
          }
     }
}