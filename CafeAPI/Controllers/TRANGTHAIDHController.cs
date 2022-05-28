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
     [RoutePrefix("api/TRANGTHAIDH")]
     public class TRANGTHAIDHController : ApiController
    {
        private CafeDbContext db = new CafeDbContext();
        private TrangThaiDH_DAO TrangThaiDH_DAO = new TrangThaiDH_DAO();
        // GET: api/TRANGTHAIDH
        public List<TRANGTHAIDH> GetTRANGTHAIDH()
        {
               //return db.TRANGTHAIDH;
               return TrangThaiDH_DAO.GetTRANGTHAIDH();
        }

        // GET: api/TRANGTHAIDH/5
        [ResponseType(typeof(TRANGTHAIDH))]
        public async Task<IHttpActionResult> GetTRANGTHAIDH(int id)
        {
            TRANGTHAIDH tRANGTHAIDH = TrangThaiDH_DAO.GetTRANGTHAIDHbyId(id);
            if (tRANGTHAIDH == null)
            {
                return NotFound();
            }

            return Ok(tRANGTHAIDH);
        }

        // PUT: api/TRANGTHAIDH/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTRANGTHAIDH(TRANGTHAIDH tRANGTHAIDH)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

           

            db.Entry(tRANGTHAIDH).State = EntityState.Modified;

            try
            {
                    //await db.SaveChangesAsync();
              TrangThaiDH_DAO.UpdateTRANGTHAIDH(tRANGTHAIDH);
            }
            catch (DbUpdateConcurrencyException)
            {
                
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/TRANGTHAIDH
        [ResponseType(typeof(TRANGTHAIDH))]
        public async Task<IHttpActionResult> PostTRANGTHAIDH(TRANGTHAIDH tRANGTHAIDH)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

               //db.TRANGTHAIDH.Add(tRANGTHAIDH);
               //await db.SaveChangesAsync();
               TrangThaiDH_DAO.InsertTRANGTHAIDH(tRANGTHAIDH);

            return CreatedAtRoute("DefaultApi", new { id = tRANGTHAIDH.ID }, tRANGTHAIDH);
        }

        // DELETE: api/TRANGTHAIDH/5
        [ResponseType(typeof(TRANGTHAIDH))]
        public async Task<IHttpActionResult> DeleteTRANGTHAIDH(int id)
        {
            TRANGTHAIDH tRANGTHAIDH = TrangThaiDH_DAO.GetTRANGTHAIDHbyId(id);
            if (tRANGTHAIDH == null)
            {
                return NotFound();
            }

               //db.TRANGTHAIDH.Remove(tRANGTHAIDH);
               //await db.SaveChangesAsync();
             TrangThaiDH_DAO.DeleteTRANGTHAIDH(tRANGTHAIDH);

            return Ok(tRANGTHAIDH);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TRANGTHAIDHExists(int id)
        {
            return db.TRANGTHAIDH.Count(e => e.ID == id) > 0;
        }
    }
}