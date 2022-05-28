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
     [RoutePrefix("api/BAIBAO")]
     public class BAIBAOController : ApiController
    {
        private CafeDbContext db = new CafeDbContext();
          private BaiBao_DAO BaiBao_DAO = new BaiBao_DAO();
        // GET: api/BAIBAO
        public List<BAIBAO> GetBAIBAO()
        {
               return BaiBao_DAO.GetBAIBAO();
        }

        // GET: api/BAIBAO/5
        [ResponseType(typeof(BAIBAO))]
        public async Task<IHttpActionResult> GetBAIBAO(int id)
        {
            BAIBAO bAIBAO = BaiBao_DAO.GetBAIBAObyId(id);
            if (bAIBAO == null)
            {
                return NotFound();
            }

            return Ok(bAIBAO);
        }

        // PUT: api/BAIBAO/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBAIBAO(BAIBAO bAIBAO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

           

            db.Entry(bAIBAO).State = EntityState.Modified;

            try
            {
                    BaiBao_DAO.UpdateBAIBAO(bAIBAO);
                    //await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/BAIBAO
        [ResponseType(typeof(BAIBAO))]
        public async Task<IHttpActionResult> PostBAIBAO(BAIBAO bAIBAO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

               //db.BAIBAO.Add(bAIBAO);
               //await db.SaveChangesAsync();
               BaiBao_DAO.InsertBAIBAO(bAIBAO);

            return CreatedAtRoute("DefaultApi", new { id = bAIBAO.ID }, bAIBAO);
        }

        // DELETE: api/BAIBAO/5
        [ResponseType(typeof(BAIBAO))]
        public async Task<IHttpActionResult> DeleteBAIBAO(int id)
        {
            BAIBAO bAIBAO = BaiBao_DAO.GetBAIBAObyId(id);
            if (bAIBAO == null)
            {
                return NotFound();
            }

               //db.BAIBAO.Remove(bAIBAO);
               //await db.SaveChangesAsync();
            BaiBao_DAO.DeleteBAIBAO(bAIBAO);
            return Ok(bAIBAO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BAIBAOExists(int id)
        {
            return db.BAIBAO.Count(e => e.ID == id) > 0;
        }
    }
}