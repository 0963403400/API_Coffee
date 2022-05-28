using CafeAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
namespace CafeAPI.DAO
{
     public class TrangThaiDH_DAO
     {
          private Connection cn = new Connection();
          public List<TRANGTHAIDH> GetTRANGTHAIDH()
          {
               List<TRANGTHAIDH> lst = cn.ConvertToList<TRANGTHAIDH>(GetDataTRANGTHAIDH());
               return lst;
          }
          public DataTable GetDataTRANGTHAIDH()
          {
               string query = "select * from TRANGTHAIDH";
               DataTable tb = cn.LoadTable(query);
               return tb;
          }
          public TRANGTHAIDH GetTRANGTHAIDHbyId(int id)
          {
               string query = "select * from TRANGTHAIDH where id = @id";
               string[] para = new string[1] { "@id" };
               object[] value = new object[1] { id };
               DataTable tb = cn.FillDataTable(query, CommandType.Text, para, value);
               TRANGTHAIDH sp = cn.ConvertToList<TRANGTHAIDH>(tb)[0];
               return sp;
          }

          public void InsertTRANGTHAIDH(TRANGTHAIDH tRANGTHAIDH)
          {
               string query = "insertTRANGTHAIDH";
               string[] para = new string[1] { "@ten" };
               object[] value = new object[1] { tRANGTHAIDH.TEN };
               cn.Excute_Sql(query, CommandType.StoredProcedure, para, value);
          }
          public void UpdateTRANGTHAIDH(TRANGTHAIDH tRANGTHAIDH)
          {
               string query = "update TRANGTHAIDH set TEN = @ten where ID = @id";
               string[] para = new string[2] { "@id", "@ten" };
               object[] value = new object[2] { tRANGTHAIDH.ID, tRANGTHAIDH.TEN };
               cn.Excute_Sql(query, CommandType.Text, para, value);
          }
          public void DeleteTRANGTHAIDH(TRANGTHAIDH tRANGTHAIDH)
          {
               string query = "delete TRANGTHAIDH where ID=@id";
               string[] para = new string[1] { "@id" };
               object[] value = new object[1] { tRANGTHAIDH.ID };
               cn.Excute_Sql(query, CommandType.Text, para, value);
          }
     }
}