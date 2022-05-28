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
     [RoutePrefix("api/CHITIETNHAPHANG")]
     public class CHITIETNHAPHANGController : ApiController
     {
        private CafeDbContext db = new CafeDbContext();
          private NhapHangDAO NhapHangDAO = new NhapHangDAO();
        // GET: api/CHITIETNHAPHANG
        public List<CHITIETNHAPHANG> GetCHITIETNHAPHANG()
        {
            return NhapHangDAO.GetCTNHAPHANG();
        }

        // GET: api/CHITIETNHAPHANG/5
        [ResponseType(typeof(CHITIETNHAPHANG))]
        public async Task<IHttpActionResult> GetCHITIETNHAPHANG(int id)
        {
            CHITIETNHAPHANG cHITIETNHAPHANG = NhapHangDAO.GetCHITIETNHAPHANGbyId(id);
            if (cHITIETNHAPHANG == null)
            {
                return NotFound();
            }

            return Ok(cHITIETNHAPHANG);
        }
          [ResponseType(typeof(CHITIETNHAPHANG))]
          public async Task<IHttpActionResult> GetCHITIETNHAPHANG(int id,int id2)
          {
               CHITIETNHAPHANG cHITIETNHAPHANG = NhapHangDAO.GetCHITIETNHAPHANGbyIDSP(id,id2);
               if (cHITIETNHAPHANG == null)
               {
                    return NotFound();
               }

               return Ok(cHITIETNHAPHANG);
          }
          // POST: api/CHITIETNHAPHANG
        [ResponseType(typeof(CHITIETNHAPHANG))]
        public async Task<IHttpActionResult> PostCHITIETNHAPHANG(CHITIETNHAPHANG cHITIETNHAPHANG)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            new NhapHangDAO().InsertCTNhapHang(cHITIETNHAPHANG);

            return CreatedAtRoute("DefaultApi", new { id = cHITIETNHAPHANG.ID }, cHITIETNHAPHANG);
        }
          [ResponseType(typeof(CHITIETNHAPHANG))]
          public async Task<IHttpActionResult> PutCHITIETNHAPHANG(CHITIETNHAPHANG cHITIETNHAPHANG)
          {
               if (!ModelState.IsValid)
               {
                    return BadRequest(ModelState);
               }
               try
               {
                    //await db.SaveChangesAsync();
                     NhapHangDAO.UpdateCTNH(cHITIETNHAPHANG);
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

        private bool CHITIETNHAPHANGExists(int id)
        {
            return db.CHITIETNHAPHANG.Count(e => e.ID == id) > 0;
        }
    }
}