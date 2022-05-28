using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using CafeAPI.DAO;
using CafeAPI.Models;

namespace CafeAPI.Controllers
{
    [RoutePrefix("api/DONHANG")]
    public class DONHANGController : ApiController
    {
        private CafeDbContext db = new CafeDbContext();
        private DonHangDAO DH_DAO = new DonHangDAO();
        // GET: api/DONHANG
        public IEnumerable<DONHANG> GetDONHANG()
        {
            return DH_DAO.GetListDONHANG();
        }

        // GET: api/DONHANG/5
        [ResponseType(typeof(DONHANG))]
        public async Task<IHttpActionResult> GetDONHANG(int id)
        {
            DONHANG dONHANG = DH_DAO.GetDONHANG(id);
            if (dONHANG == null)
            {
                return NotFound();
            }

            return Ok(dONHANG);
        }

        // PUT: api/DONHANG/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDONHANG(DONHANG dONHANG)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                DH_DAO.UpdateTRANGTHAIDH(dONHANG.ID, dONHANG.TRANGTHAI_ID);
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/DONHANG
        [ResponseType(typeof(DONHANG))]
        public async Task<IHttpActionResult> PostDONHANG(DONHANG dONHANG)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            dONHANG.NGAYDAT = DateTime.Now;
            dONHANG.TRANGTHAI_ID = 1;
               //db.DONHANG.Add(dONHANG);
               //await db.SaveChangesAsync();
            DH_DAO.InsertDonHang(dONHANG);

            return CreatedAtRoute("DefaultApi", new { id = dONHANG.ID }, dONHANG);
        }

        // DELETE: api/DONHANG/5
        [ResponseType(typeof(DONHANG))]
        public async Task<IHttpActionResult> DeleteDONHANG(int id)
        {
            DONHANG dONHANG = await db.DONHANG.FindAsync(id);
            if (dONHANG == null)
            {
                return NotFound();
            }

            db.DONHANG.Remove(dONHANG);
            await db.SaveChangesAsync();

            return Ok(dONHANG);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DONHANGExists(int id)
        {
            return db.DONHANG.Count(e => e.ID == id) > 0;
        }

        [Route("dathang")]
        [ResponseType(typeof(int))]
        public IHttpActionResult Order(string nguoinhan, string sdt, string diachi, int? idKH, string listIdSP, string listsoluong)
        {
            try
            {
                int[] idSP = new DonHangDAO().ConvertStringToArray(listIdSP);
                int[] soluong = new DonHangDAO().ConvertStringToArray(listsoluong);
                DONHANG dh = new DONHANG(nguoinhan, sdt, diachi, idKH);
                int idDH = DH_DAO.InsertDonHang(dh);
                for (int i = 0; i < idSP.Length; i++)
                {
                    CHITIETDONHANG CTDH = new CHITIETDONHANG(idSP[i], dh.ID, soluong[i], (int)new SANPHAM_DAO().GetPriceBySanPham(idSP[i]).GIABAN);
                    new ChiTietDH_DAO().InsertCHITIETDH(CTDH);
                }
                return Ok(1);
            }
            catch
            {
                return Ok(0);
            }
        }
    }
}