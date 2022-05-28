using CafeAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CafeAPI.DAO
{
    public class NHACUNGCAP_DAO
    {
        private Connection cn = new Connection();
          public List<NHACUNGCAP> GetNCC()
          {
               List<NHACUNGCAP> lst = cn.ConvertToList<NHACUNGCAP>(GetDataNCC());
               return lst;
          }
          public DataTable GetDataNCC()
          {
               string query = "select * from NHACUNGCAP";
               DataTable tb = cn.LoadTable(query);
               return tb;
          }
          public NHACUNGCAP GetNCCbyId(int id)
          {
               string query = "select * from NHACUNGCAP Where ID=@id";
               string[] para = new string[1] { "@id" };
               object[] value = new object[1] { id };
               DataTable tb = cn.FillDataTable(query, CommandType.Text, para, value);
               NHACUNGCAP sp = cn.ConvertToList<NHACUNGCAP>(tb)[0];
               return sp;
          }
          public void UpdateNCC(NHACUNGCAP ncc)
          {
               string query = "UpdateNCC";
               string[] para = new string[4] { "@ID", "@TEN", "@DIACHI", "@SDT" };
               object[] value = new object[4] { ncc.ID,ncc.TEN, ncc.DIACHI, ncc.SDT };
               cn.Excute_Sql(query, CommandType.StoredProcedure, para, value);
          }
          public void DeleteNCC(NHACUNGCAP ncc)
          {
               string query = "deleteLOAISP";
               string[] para = new string[1] { "@id" };
               object[] value = new object[1] { ncc.ID };
               cn.Excute_Sql(query, CommandType.StoredProcedure, para, value);
          }
          public void InsertNCC(NHACUNGCAP ncc)
        {
            string query = "insertNCC";
            string[] para = new string[3] { "@ten", "@diachi", "@sdt" };
            object[] value = new object[3] { ncc.TEN, ncc.DIACHI, ncc.SDT };
            cn.Excute_Sql(query, CommandType.StoredProcedure, para, value);
        }
        public int GetMaxID()
        {
            string query = "select max(ID) from NHACUNGCAP";
            int tb = cn.Excute_Sql_GetMaxID(query);
            return tb;
        }
    }
}