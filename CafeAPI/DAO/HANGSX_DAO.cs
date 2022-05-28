using CafeAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CafeAPI.DAO
{
    public class HANGSX_DAO
    {
        private Connection cn = new Connection();
        public List<HANGSX> GetHANGSX()
        {
            List<HANGSX> lst = cn.ConvertToList<HANGSX>(GetDataHANGSX());
            return lst;
        }
        public DataTable GetDataHANGSX()
        {
            string query = "select * from HANGSX";
            DataTable tb = cn.LoadTable(query);
            return tb;
        }
        public HANGSX GetHANGSXbyId(int id)
        {
            string query = "select * from HANGSX where id = @id";
            string[] para = new string[1] { "@id" };
            object[] value = new object[1] { id };
            DataTable tb = cn.FillDataTable(query, CommandType.Text, para, value);
            HANGSX sp = cn.ConvertToList<HANGSX>(tb)[0];
            return sp;
        }

        public void InsertHANGSX(HANGSX hang)
        {
            string query = "insertHSX";
            string[] para = new string[1] { "@ten" };
            object[] value = new object[1] { hang.TEN };
            cn.Excute_Sql(query, CommandType.StoredProcedure, para, value);
        }
        public void UpdateHANGSX(HANGSX hang)
        {
            string query = "update HANGSX set TEN = @ten where ID = @id";
            string[] para = new string[2] { "@id", "@ten" };
            object[] value = new object[2] { hang.ID, hang.TEN };
            cn.Excute_Sql(query, CommandType.Text, para, value);
        }
        public void DeleteHANGSX(HANGSX hang)
        {
            string query = "delete HANGSX where ID=@id";
            string[] para = new string[1] { "@id" };
            object[] value = new object[1] { hang.ID };
            cn.Excute_Sql(query, CommandType.Text, para, value);
        }
        public int GetMaxID()
        {
            string query = "select max(ID) from HANGSX";
            int tb = cn.Excute_Sql_GetMaxID(query);
            return tb;
        }
    }
}