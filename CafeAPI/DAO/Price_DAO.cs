using CafeAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CafeAPI.DAO
{
    public class Price_DAO
    {
        private Connection cn = new Connection();
        public List<PRICE> GetPrice()
        {
            List<PRICE> lst = cn.ConvertToList<PRICE>(GetDataPRICE());
            return lst;
        }
        public DataTable GetDataPRICE()
        {
            string query = "select * from PRICE";
            DataTable tb = cn.LoadTable(query);
            return tb;
        }
          public PRICE GetPRICEbyId(int id)
          {
               string query = "select * from PRICE where id = @id";
               string[] para = new string[1] { "@id" };
               object[] value = new object[1] { id };
               DataTable tb = cn.FillDataTable(query, CommandType.Text, para, value);
               PRICE sp = cn.ConvertToList<PRICE>(tb)[0];
               return sp;
          }
          public void InsertPrice(PRICE price)
        {
            string query = "InsertPrice";
            string[] para = new string[2] { "@idSP", "@giaban" };
            object[] value = new object[2] { price.SANPHAM_ID, price.GIABAN };
            cn.Excute_Sql(query, CommandType.StoredProcedure, para, value);
        }
        public void UpdatePrice(PRICE price)
        {
            string query = "UpdatePrice";
            string[] para = new string[2] { "@idSP", "@giaban" };
            object[] value = new object[2] { price.SANPHAM_ID, price.GIABAN };
            cn.Excute_Sql(query, CommandType.StoredProcedure, para, value);
        }
          public void DeletePrice(PRICE price)
          {
               string query = "delete PRICE where ID=@id";
               string[] para = new string[1] { "@id" };
               object[] value = new object[1] { price.ID };
               cn.Excute_Sql(query, CommandType.Text, para, value);
          }
     }
}