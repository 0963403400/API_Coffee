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
     [RoutePrefix("api/NHAPHANG")]
     public class NHAPHANGController : ApiController
    {
        private CafeDbContext db = new CafeDbContext();
          private NhapHangDAO NhapHangDAO = new NhapHangDAO();
        // GET: api/NHAPHANG
        public List<NHAPHANG> GetNHAPHANG()
        {
               return NhapHangDAO.GetNHAPHANG();
        }

        // GET: api/NHAPHANG/5
        [ResponseType(typeof(NHAPHANG))]
        public async Task<IHttpActionResult> GetNHAPHANG(int id)
        {
            NHAPHANG nHAPHANG = NhapHangDAO.GetNHAPHANGbyId(id);
            if (nHAPHANG == null)
            {
                return NotFound();
            }

            return Ok(nHAPHANG);
        }


        // POST: api/NHAPHANG
        [ResponseType(typeof(NHAPHANG))]
        public async Task<IHttpActionResult> PostNHAPHANG(NHAPHANG nHAPHANG)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            int idNH = new NhapHangDAO().InsertNhapHang(nHAPHANG);
            nHAPHANG.ID = idNH;

            return CreatedAtRoute("DefaultApi", new { id = nHAPHANG.ID }, nHAPHANG);
        }
          [ResponseType(typeof(void))]
          public async Task<IHttpActionResult> PutNHAPHANG(NHAPHANG nHAPHANG)
          {
               if (!ModelState.IsValid)
               {
                    return BadRequest(ModelState);
               }



               try
               {
                    //await db.SaveChangesAsync();
                    NhapHangDAO.UpdateNHAPHANG(nHAPHANG);
               }
               catch (DbUpdateConcurrencyException)
               {

               }

               return StatusCode(HttpStatusCode.NoContent);
          }

          protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NHAPHANGExists(int id)
        {
            return db.NHAPHANG.Count(e => e.ID == id) > 0;
        }
    }
}