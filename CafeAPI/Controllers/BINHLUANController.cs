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

namespace CafeAPI.Controllers
{
    public class BINHLUANController : ApiController
    {
        private CafeDbContext db = new CafeDbContext();

        // GET: api/BINHLUAN
        public IQueryable<BINHLUAN> GetBINHLUAN()
        {
            //var bl = from d in db.BINHLUAN select d
            return db.BINHLUAN;
        }

        // GET: api/BINHLUAN/5
        [ResponseType(typeof(BINHLUAN))]
        public async Task<IHttpActionResult> GetBINHLUAN(int id)
        {
            BINHLUAN bINHLUAN = await db.BINHLUAN.FindAsync(id);
            if (bINHLUAN == null)
            {
                return NotFound();
            }

            return Ok(bINHLUAN);
        }

        // PUT: api/BINHLUAN/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBINHLUAN(BINHLUAN bINHLUAN)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            

            db.Entry(bINHLUAN).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/BINHLUAN
        [ResponseType(typeof(BINHLUAN))]
        public async Task<IHttpActionResult> PostBINHLUAN(BINHLUAN bINHLUAN)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BINHLUAN.Add(bINHLUAN);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = bINHLUAN.ID }, bINHLUAN);
        }

        // DELETE: api/BINHLUAN/5
        [ResponseType(typeof(BINHLUAN))]
        public async Task<IHttpActionResult> DeleteBINHLUAN(int id)
        {
            BINHLUAN bINHLUAN = await db.BINHLUAN.FindAsync(id);
            if (bINHLUAN == null)
            {
                return NotFound();
            }

            db.BINHLUAN.Remove(bINHLUAN);
            await db.SaveChangesAsync();

            return Ok(bINHLUAN);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BINHLUANExists(int id)
        {
            return db.BINHLUAN.Count(e => e.ID == id) > 0;
        }
    }
}