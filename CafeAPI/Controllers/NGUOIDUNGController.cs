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
using System.Windows.Forms;

namespace CafeAPI.Controllers
{
    [RoutePrefix("api/NGUOIDUNG")]
    public class NGUOIDUNGController : ApiController
    {
        private CafeDbContext db = new CafeDbContext();
          private NguoiDungDAO ndDAO = new NguoiDungDAO();
        // GET: api/NGUOIDUNG
        public List<NGUOIDUNG> GetNGUOIDUNG()
        {
               //return db.NGUOIDUNG;
               return ndDAO.GetNGUOIDUNG();
        }

        // GET: api/NGUOIDUNG/5
        [ResponseType(typeof(NGUOIDUNG))]
        public async Task<IHttpActionResult> GetNGUOIDUNG(int id)
        {
            NGUOIDUNG nGUOIDUNG = ndDAO.GetNGUOIDUNGbyID(id);
            if (nGUOIDUNG == null)
            {
                return NotFound();
            }

            return Ok(nGUOIDUNG);
        }

        // PUT: api/NGUOIDUNG/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutNGUOIDUNG(NGUOIDUNG nGUOIDUNG)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entry(nGUOIDUNG).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
               
            }
            catch (DbUpdateConcurrencyException)
            {
                
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/NGUOIDUNG
        [ResponseType(typeof(NGUOIDUNG))]
        public async Task<IHttpActionResult> PostNGUOIDUNG(NGUOIDUNG nGUOIDUNG)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            int ID = ndDAO.GetMaxID();
            /*MessageBox.Show(ID.ToString());*/
            nGUOIDUNG.ID = ID + 1;
            
            if (nGUOIDUNG.QUYEN == null) nGUOIDUNG.QUYEN = 0;
            db.NGUOIDUNG.Add(nGUOIDUNG);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = nGUOIDUNG.ID }, nGUOIDUNG);
        }

        // DELETE: api/NGUOIDUNG/5
        [ResponseType(typeof(NGUOIDUNG))]
        public async Task<IHttpActionResult> DeleteNGUOIDUNG(int id)
        {
            NGUOIDUNG nGUOIDUNG = await db.NGUOIDUNG.FindAsync(id);
            if (nGUOIDUNG == null)
            {
                return NotFound();
            }
            

            db.NGUOIDUNG.Remove(nGUOIDUNG);
            await db.SaveChangesAsync();

            return Ok(nGUOIDUNG);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NGUOIDUNGExists(int id)
        {
            return db.NGUOIDUNG.Count(e => e.ID == id) > 0;
        }

        [HttpGet]
        [Route("CheckLogin")]
        public int CheckLogin(string tendangnhap, string matkhau, int quyen)
        {
            if (db.NGUOIDUNG.Where(x => x.TENDANGNHAP == tendangnhap && x.MATKHAU == matkhau && x.QUYEN == quyen).ToList().Count == 0)
            {
                return 0;
            }
            else return 1;
        }
    }
}