using CafeAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CafeAPI.DAO
{
    public class LOAISP_DAO
    {
        private Connection cn = new Connection();
        public List<LOAISP> GetLOAISP()
        {
            List<LOAISP> lst = cn.ConvertToList<LOAISP>(GetDataLOAISP());
            return lst;
        }
        public DataTable GetDataLOAISP()
        {
            string query = "select * from LOAISP";
            DataTable tb = cn.LoadTable(query);
            return tb;
        }
        public LOAISP GetLSPbyId(int id)
        {
            string query = "select * from dbo.getLOAISPbyID(@id)";
            string[] para = new string[1] { "@id" };
            object[] value = new object[1] { id };
            DataTable tb = cn.FillDataTable(query, CommandType.Text, para, value);
            LOAISP sp = cn.ConvertToList<LOAISP>(tb)[0];
            return sp;
        }
        public void InsertLOAISP(LOAISP lsp)
        {
            string query = "insertLOAISP";
            string[] para = new string[6] { "@ten", "@anh", "@mota", "@ngaytao" ,"@idhang", "@trangthai" };
            object[] value = new object[6] { lsp.TEN, lsp.ANH, lsp.MOTA, lsp.NGAYTAO, lsp.HANGSX_ID, lsp.TRANGTHAI };
            cn.Excute_Sql(query, CommandType.StoredProcedure, para, value);
        }
        public void UpdateLOAISP(LOAISP lsp)
        {
            string query = "updateLOAISP";
            string[] para = new string[7] { "@id", "@ten", "@anh", "@mota", "@ngaytao", "@idhang", "@trangthai"};
            object[] value = new object[7] { lsp.ID, lsp.TEN, lsp.ANH, lsp.MOTA, lsp.NGAYTAO, lsp.HANGSX_ID, lsp.TRANGTHAI };
            cn.Excute_Sql(query, CommandType.StoredProcedure, para, value);
        }
        public void DeleteLOAISP(LOAISP lsp)
        {
            string query = "deleteLOAISP";
            string[] para = new string[1] { "@id" };
            object[] value = new object[1] { lsp.ID };
            cn.Excute_Sql(query, CommandType.StoredProcedure, para, value);
        }
        public int GetMaxID()
        {
            string query = "select max(ID) from LOAISP";
            int tb = cn.Excute_Sql_GetMaxID(query);
            return tb;
        }
    }
}