using CafeAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CafeAPI.DAO
{
    public class SANPHAM_DAO
    {
        private Connection cn = new Connection();
        public List<SANPHAM> GetSANPHAM()
        {
            List<SANPHAM> lst = cn.ConvertToList<SANPHAM>(GetDataSANPHAM());
            return lst;
        }
        public DataTable GetDataSANPHAM()
        {
            string query = "select * from SANPHAM";
            DataTable tb = cn.LoadTable(query);
            return tb;
        }
        public SANPHAM GetSANPHAMbyId(int id)
        {
            string query = "select * from SANPHAM Where ID = @id";
            string[] para = new string[1] { "@id" };
            object[] value = new object[1] { id };
            DataTable tb = cn.FillDataTable(query, CommandType.Text, para, value);
            SANPHAM sp = cn.ConvertToList<SANPHAM>(tb)[0];
            return sp;
        }
        public List<SANPHAM> GetSANPHAMByLSP(int id)
        {
            string query = "select * from dbo.getSanPhamByIdLSP(@id)";
            string[] para = new string[1] { "@id" };
            object[] value = new object[1] { id };
            DataTable tb = cn.FillDataTable(query, CommandType.Text, para, value);
            List<SANPHAM> sp = cn.ConvertToList<SANPHAM>(tb);
            return sp;
        }
        public void InsertSANPHAM(SANPHAM sp)
        {
            string query = "insertSANPHAM";
            string[] para = new string[5] { "@khoiluong", "@anh", "@mota", "@soluong", "@idloaisp" };
            object[] value = new object[5] { sp.KHOILUONG, sp.ANH, sp.MOTA, sp.SOLUONG, sp.LOAISP_ID };
            cn.Excute_Sql(query, CommandType.StoredProcedure, para, value);
        }
        public void UpdateSANPHAM(SANPHAM sp)
        {
            string query = "updateSANPHAM";
            string[] para = new string[6] { "@id", "@khoiluong", "@anh", "@mota", "@soluong", "@idloaisp" };
            object[] value = new object[6] { sp.ID, sp.KHOILUONG, sp.ANH, sp.MOTA, sp.SOLUONG, sp.LOAISP_ID };
            cn.Excute_Sql(query, CommandType.StoredProcedure, para, value);
        }
        public void DeleteSANPHAM(SANPHAM sp)
        {
            string query = "deleteSANPHAM";
            string[] para = new string[1] { "@id" };
            object[] value = new object[1] { sp.ID };
            cn.Excute_Sql(query, CommandType.StoredProcedure, para, value);
        }
        public PRICE GetPriceBySanPham(int id)
        {
            DateTime now = DateTime.Now;
            string query = "select * from dbo.getPriceBySanPham(@id)";
            string[] para = new string[1] { "@id" };
            object[] value = new object[1] { id };
            DataTable tb = cn.FillDataTable(query, CommandType.Text, para, value);
            PRICE pr = cn.ConvertToList<PRICE>(tb)[0];
            return pr;
        }
    }
}