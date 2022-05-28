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
     [RoutePrefix("api/NHACUNGCAP")]
     public class NHACUNGCAPController : ApiController
    {
        private CafeDbContext db = new CafeDbContext();
        private NHACUNGCAP_DAO nccDAO = new NHACUNGCAP_DAO();

        // GET: api/NHACUNGCAP
        public List<NHACUNGCAP> GetNHACUNGCAP()
        {
               return nccDAO.GetNCC();
        }

        // GET: api/NHACUNGCAP/5
        [ResponseType(typeof(NHACUNGCAP))]
        public async Task<IHttpActionResult> GetNHACUNGCAP(int id)
        {
               NHACUNGCAP nHACUNGCAP = nccDAO.GetNCCbyId(id);
            if (nHACUNGCAP == null)
            {
                return NotFound();
            }

            return Ok(nHACUNGCAP);
        }

        // PUT: api/NHACUNGCAP/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutNHACUNGCAP(NHACUNGCAP nHACUNGCAP)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            db.Entry(nHACUNGCAP).State = EntityState.Modified;

            try
            {

                    nccDAO.UpdateNCC(nHACUNGCAP);
            }
            catch (DbUpdateConcurrencyException)
            {
                
            }

            return Ok(nHACUNGCAP);
        }

        // POST: api/NHACUNGCAP
        [ResponseType(typeof(NHACUNGCAP))]
        public async Task<IHttpActionResult> PostNHACUNGCAP(NHACUNGCAP nHACUNGCAP)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            int ID = nccDAO.GetMaxID();
            /*MessageBox.Show(ID.ToString());*/
            nHACUNGCAP.ID = ID + 1;
            //db.NHACUNGCAP.Add(nHACUNGCAP);
            //await db.SaveChangesAsync();
            nccDAO.InsertNCC(nHACUNGCAP);

            /*return CreatedAtRoute("DefaultApi", new { id = nHACUNGCAP.ID }, nHACUNGCAP);*/
            return Ok(nHACUNGCAP);
        }

        // DELETE: api/NHACUNGCAP/5
        [ResponseType(typeof(NHACUNGCAP))]
        public async Task<IHttpActionResult> DeleteNHACUNGCAP(int id)
        {
            NHACUNGCAP nHACUNGCAP = nccDAO.GetNCCbyId(id);
            if (nHACUNGCAP == null)
            {
                return NotFound();
            }

            nccDAO.DeleteNCC(nHACUNGCAP);

            return Ok(nHACUNGCAP);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NHACUNGCAPExists(int id)
        {
            return db.NHACUNGCAP.Count(e => e.ID == id) > 0;
        }
    }
}