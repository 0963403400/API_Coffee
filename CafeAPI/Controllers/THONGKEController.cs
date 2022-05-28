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
using CafeAPI.Models;
using CafeAPI.DAO;

namespace CafeAPI.Controllers
{
    [RoutePrefix("api/THONGKE")]
    public class THONGKEController : ApiController
    {
        private CafeDbContext db = new CafeDbContext();
          ThongKe_DAO tk_DAO = new ThongKe_DAO();
          // GET: api/THONGKE
        public List<THONGKE> GetTHONGKE()
        {
            return tk_DAO.GetTHONGKE();
        }

        // GET: api/THONGKE/5
        [ResponseType(typeof(THONGKE))]
        public async Task<IHttpActionResult> GetTHONGKE(int id)
        {
            THONGKE tHONGKE = tk_DAO.GetTHONGKEbyId(id);
            if (tHONGKE == null)
            {
                return NotFound();
            }

            return Ok(tHONGKE);
        }

        // PUT: api/THONGKE/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTHONGKE(THONGKE tHONGKE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

           

            db.Entry(tHONGKE).State = EntityState.Modified;

            try
            {
                    tk_DAO.UpdateTHONGKE_By_Tuan(tHONGKE);
               }
            catch (DbUpdateConcurrencyException)
            {
                
            }

            return Ok(tHONGKE);
        }

        // POST: api/THONGKE
        [ResponseType(typeof(THONGKE))]
        public async Task<IHttpActionResult> PostTHONGKE(THONGKE tHONGKE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            int ID = tk_DAO.GetMaxID();
            tHONGKE.ID = ID+1;
               //db.THONGKE.Add(tHONGKE);
               //await db.SaveChangesAsync();
               tk_DAO.InsertTHONGKE(tHONGKE);
            /*return CreatedAtRoute("DefaultApi", new { id = tHONGKE.ID }, tHONGKE);*/
            return Ok(tHONGKE);
        }

        // POST: api/THONGKE/GetThongKe
        [HttpPost]
        [Route("GetThongKe")]
        //[ResponseType(typeof(List<THONGKE>))]
        public async Task<IHttpActionResult> GetThongKe(ThongKeDate tkDate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           
            List<THONGKE> results = tk_DAO.getThongKe(tkDate);
            //return CreatedAtRoute("DefaultApi", new { id = 1 }, results);
            return Ok(results);
        }
        // POST: api/THONGKE/GetSanPhamBanChay
        [HttpPost]
        [Route("GetSanPhamBanChay")]
        //[ResponseType(typeof(List<THONGKE>))]
        public async Task<IHttpActionResult> GetSanPhamBanChay(ThongKeDate tkDate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ThongKe_DAO tk_DAO = new ThongKe_DAO();
            List<SanPhamBanChay> results = tk_DAO.getSanPhamBanChay(tkDate);
            //return CreatedAtRoute("DefaultApi", new { id = 1 }, results);
            return Ok(results);
        }

        // DELETE: api/THONGKE/5
        [ResponseType(typeof(THONGKE))]
        public async Task<IHttpActionResult> DeleteTHONGKE(int id)
        {
            THONGKE tHONGKE = await db.THONGKE.FindAsync(id);
            if (tHONGKE == null)
            {
                return NotFound();
            }

            db.THONGKE.Remove(tHONGKE);
            await db.SaveChangesAsync();

            return Ok(tHONGKE);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool THONGKEExists(int id)
        {
            return db.THONGKE.Count(e => e.ID == id) > 0;
        }
    }
}