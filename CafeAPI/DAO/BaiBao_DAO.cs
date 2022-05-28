using CafeAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CafeAPI.DAO
{
     public class BaiBao_DAO
     {
          private Connection cn = new Connection();
          public List<BAIBAO> GetBAIBAO()
          {
               List<BAIBAO> lst = cn.ConvertToList<BAIBAO>(GetDataBAIBAO());
               return lst;
          }
          public DataTable GetDataBAIBAO()
          {
               string query = "select * from BAIBAO";
               DataTable tb = cn.LoadTable(query);
               return tb;
          }
          public BAIBAO GetBAIBAObyId(int id)
          {
               string query = "select * from BAIBAO where id = @id";
               string[] para = new string[1] { "@id" };
               object[] value = new object[1] { id };
               DataTable tb = cn.FillDataTable(query, CommandType.Text, para, value);
               BAIBAO sp = cn.ConvertToList<BAIBAO>(tb)[0];
               return sp;
          }

          public void InsertBAIBAO(BAIBAO hang)
          {
               string query = "insertBAIBAO";
               string[] para = new string[3] { "@ten","@nd","@idSP" };
               object[] value = new object[3] { hang.TIEUDE,hang.NOIDUNG,hang.SANPHAM_ID };
               cn.Excute_Sql(query, CommandType.StoredProcedure, para, value);
          }
          public void UpdateBAIBAO(BAIBAO hang)
          {
               string query = "update BAIBAO set TIEUDE = @ten,NOIDUNG= @nd,SANPHAM_ID=@idSP where ID = @id";
               string[] para = new string[4] { "@id", "@ten", "@nd", "@idSP" };
               object[] value = new object[4] { hang.ID, hang.TIEUDE, hang.NOIDUNG, hang.SANPHAM_ID };
               cn.Excute_Sql(query, CommandType.Text, para, value);
          }
          public void DeleteBAIBAO(BAIBAO hang)
          {
               string query = "delete BAIBAO where ID=@id";
               string[] para = new string[1] { "@id" };
               object[] value = new object[1] { hang.ID };
               cn.Excute_Sql(query, CommandType.Text, para, value);
          }
     }
}