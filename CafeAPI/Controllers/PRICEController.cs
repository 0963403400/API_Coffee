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
     [RoutePrefix("api/PRICE")]
     public class PRICEController : ApiController
    {
        private CafeDbContext db = new CafeDbContext();
        private Price_DAO prDAO = new Price_DAO();

        // GET: api/PRICE
        public List<PRICE> GetPRICE()
        {
               //return db.PRICE;
               return prDAO.GetPrice();
        }

        // GET: api/PRICE/5
        [ResponseType(typeof(PRICE))]
        public async Task<IHttpActionResult> GetPRICE(int id)
        {
               //PRICE pRICE = await db.PRICE.FindAsync(id);
               PRICE pRICE = prDAO.GetPRICEbyId(id);
            if (pRICE == null)
            {
                return NotFound();
            }

            return Ok(pRICE);
        }

        // PUT: api/PRICE/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPRICE(PRICE pRICE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //db.Entry(pRICE).State = EntityState.Modified;
            try
            {
                prDAO.UpdatePrice(pRICE);
                //await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/PRICE
        [ResponseType(typeof(PRICE))]
        public async Task<IHttpActionResult> PostPRICE(PRICE pRICE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            prDAO.InsertPrice(pRICE);
            //db.PRICE.Add(pRICE);
            //await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = pRICE.ID }, pRICE);
        }

        // DELETE: api/PRICE/5
        [ResponseType(typeof(PRICE))]
        public async Task<IHttpActionResult> DeletePRICE(int id)
        {
               //PRICE pRICE = await db.PRICE.FindAsync(id);
            PRICE pRICE = prDAO.GetPRICEbyId(id);
            if (pRICE == null)
            {
                return NotFound();
            }

               //db.PRICE.Remove(pRICE);
               //await db.SaveChangesAsync();
            prDAO.DeletePrice(pRICE);
            return Ok(pRICE);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PRICEExists(int id)
        {
            return db.PRICE.Count(e => e.ID == id) > 0;
        }
    }
}