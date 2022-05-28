using CafeAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CafeAPI.DAO
{
    public class ChiTietDH_DAO
    {
        private Connection cn = new Connection();
          
          public List<CHITIETDONHANG> GetCTDH()
          {
               List<CHITIETDONHANG> lst = cn.ConvertToList<CHITIETDONHANG>(GetDataCTDH());
               return lst;
          }
          public DataTable GetDataCTDH()
          {
               string query = "select * from CHITIETDONHANG";
               DataTable tb = cn.LoadTable(query);
               return tb;
          }
          public CHITIETDONHANG GetCTDHbyId(int id)
          {
               string query = "select * from CHITIETDONHANG where id = @id";
               string[] para = new string[1] { "@id" };
               object[] value = new object[1] { id };
               DataTable tb = cn.FillDataTable(query, CommandType.Text, para, value);
              CHITIETDONHANG sp = cn.ConvertToList<CHITIETDONHANG>(tb)[0];
               return sp;
          }
          public void InsertCHITIETDH(CHITIETDONHANG CTDH)
          {
            string query = "insertCTDH";
            string[] para = new string[4] { "@idSP", "@idDH", "@soluong", "@giaban" };
            object[] value = new object[4] { CTDH.SANPHAM_ID, CTDH.DONHANG_ID, CTDH.SOLUONG, CTDH.DONGIA };
            cn.Excute_Sql(query, CommandType.StoredProcedure, para, value);
          }
          public void UpdateCHITIETDH(CHITIETDONHANG CTDH)
          {
               string query = "update CHITIETDONHANG set SANPHAM_ID=@idSP,DONHANG_ID=@idDH,SOLUONG=@soluong,DONGIA=@giaban where ID = @id";
               string[] para = new string[5] { "@id","@idSP", "@idDH", "@soluong", "@giaban" };
               object[] value = new object[5] { CTDH.ID,CTDH.SANPHAM_ID, CTDH.DONHANG_ID, CTDH.SOLUONG, CTDH.DONGIA };
               cn.Excute_Sql(query, CommandType.Text, para, value);
          }
          public void DeleteCHITIETDH(CHITIETDONHANG CTDH)
          {
               string query = "delete CHITIETDONHANG where ID=@id";
               string[] para = new string[1] { "@id" };
               object[] value = new object[1] { CTDH.ID };
               cn.Excute_Sql(query, CommandType.Text, para, value);
          }
     }
}