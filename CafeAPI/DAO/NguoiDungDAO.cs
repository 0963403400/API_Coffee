using CafeAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CafeAPI.DAO
{
     public class NguoiDungDAO
     {
          private Connection cn = new Connection();
          
          public List<NGUOIDUNG> GetNGUOIDUNG()
          {
               List<NGUOIDUNG> lst = cn.ConvertToList<NGUOIDUNG>(GetDataNGUOIDUNG());
               return lst;
          }
          private DataTable GetDataNGUOIDUNG()
          {
               string query = "select * from NGUOIDUNG";
               DataTable tb = cn.LoadTable(query);
               return tb;
          }
        public int GetMaxID()
        {
            string query = "select max(ID) from NGUOIDUNG";
            int tb = cn.Excute_Sql_GetMaxID(query);
            return tb;
        }
        public NGUOIDUNG GetNGUOIDUNGbyID(int id)
          {
               string query = "select * from NGUOIDUNG where id = @id";
               string[] para = new string[1] { "@id" };
               object[] value = new object[1] { id };
               DataTable tb = cn.FillDataTable(query, CommandType.Text, para, value);
              NGUOIDUNG nd = cn.ConvertToList<NGUOIDUNG>(tb)[0];
               return nd;
          }
     }
}