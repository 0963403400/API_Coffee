using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using CafeAPI.Models;

namespace CafeAPI.DAO
{
    public class ThongKe_DAO
    {
        private Connection cn = new Connection();
          public List<THONGKE> GetTHONGKE()
          {
               List<THONGKE> lst = cn.ConvertToList<THONGKE>(GetDataTHONGKE());
               return lst;
          }
         public DataTable GetDataTHONGKE()
         {
               string query = "select * from THONGKE";
               DataTable tb = cn.LoadTable(query);
               return tb;
         }
          public THONGKE GetTHONGKEbyId(int id)
          {
               string query = "select * from THONGKE where ID = @id";
               string[] para = new string[1] { "@id" };
               object[] value = new object[1] { id };
               DataTable tb = cn.FillDataTable(query, CommandType.Text, para, value);
               THONGKE sp = cn.ConvertToList<THONGKE>(tb)[0];
               return sp;
          }
          public List<THONGKE> getThongKe (ThongKeDate tkDate)
        {
            string query = "select * from dbo.getThongKe(@fromYear,@fromMonth,@toYear,@toMonth)";
            string[] para = new string[4] { "@fromYear", "@fromMonth", "@toYear", "@toMonth" };
            object[] value = new object[4] { tkDate.fromYear, tkDate.fromMonth, tkDate.toYear, tkDate.toMonth };
            DataTable tb = cn.FillDataTable(query, CommandType.Text, para, value);
            List<THONGKE> results = new List<THONGKE>();
            foreach (DataRow row in tb.Rows)
            {
                THONGKE temp = new THONGKE();
                temp.ID = Convert.ToInt32(row["ID"]);
                temp.NGAY = Convert.ToDateTime(row["NGAY"]);
                temp.SANPHAM_ID = Convert.ToInt32(row["SANPHAM_ID"]);
                temp.SOLUONGBAN = Convert.ToInt32(row["SOLUONGBAN"]);
                temp.DOANHTHU = Convert.ToInt32(row["DOANHTHU"]);
                temp.LOINHUAN = Convert.ToInt32(row["LOINHUAN"]);
                results.Add(temp);
            }
            return results;
        }

        public List<SanPhamBanChay> getSanPhamBanChay(ThongKeDate tkDate)
        {
            string query = "select * from dbo.getSanPhamBanChay(@fromYear,@fromMonth,@toYear,@toMonth)";
            string[] para = new string[4] { "@fromYear", "@fromMonth", "@toYear", "@toMonth" };
            object[] value = new object[4] { tkDate.fromYear, tkDate.fromMonth, tkDate.toYear, tkDate.toMonth };
            DataTable tb = cn.FillDataTable(query, CommandType.Text, para, value);
            List<SanPhamBanChay> results = new List<SanPhamBanChay>();
            int i = 1;
            foreach (DataRow row in tb.Rows)
            {
                SanPhamBanChay temp = new SanPhamBanChay();
                temp.STT = i++;
                temp.TenSP = row["TenSP"].ToString();
                temp.KhoiLuong = Convert.ToInt32(row["KhoiLuong"]);
                temp.SoLuongBan = Convert.ToInt32(row["SoLuongBan"]);
                temp.SoLuongHoaDon = Convert.ToInt32(row["SoLuongHoaDon"]);
                results.Add(temp);
            }
            return results;
        }
          public void InsertTHONGKE(THONGKE tk)
          {
               string query = "insertTHONGKE";
               string[] para = new string[5] { "@date","@idsp" ,"@soluong", "@doanhthu", "@loinhuan"};
               object[] value = new object[5] { tk.NGAY,tk.SANPHAM_ID,tk.SOLUONGBAN,tk.DOANHTHU,tk.LOINHUAN };
               cn.Excute_Sql(query, CommandType.StoredProcedure, para, value);
          }
          public void UpdateTHONGKE(THONGKE tk)
          {
               string query = "updateXUATHANG";
               string[] para = new string[6] { "@id", "@date", "@idsp", "@soluong", "@doanhthu", "@loinhuan" };
               object[] value = new object[6] { tk.ID, tk.NGAY, tk.SANPHAM_ID, tk.SOLUONGBAN, tk.DOANHTHU, tk.LOINHUAN };
               cn.Excute_Sql(query, CommandType.StoredProcedure, para, value);
          }
        public void UpdateTHONGKE_By_Tuan(THONGKE tk)
        {
            string query = "UpdateThongKe";
            string[] para = new string[6] { "@ID", "@NGAY", "@SANPHAM_ID", "@SOLUONGBAN", "@DOANHTHU", "@LOINHUAN" };
            object[] value = new object[6] { tk.ID, tk.NGAY, tk.SANPHAM_ID, tk.SOLUONGBAN, tk.DOANHTHU, tk.LOINHUAN };
            cn.Excute_Sql(query, CommandType.StoredProcedure, para, value);
        }
        public int GetMaxID()
        {
            string query = "select max(ID) from THONGKE";
            int tb = cn.Excute_Sql_GetMaxID(query);
            return tb;
        }

    }
}