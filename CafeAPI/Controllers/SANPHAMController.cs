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
    [RoutePrefix("api/SANPHAM")]
    public class SANPHAMController : ApiController
    {
        private SANPHAM_DAO spDAO = new SANPHAM_DAO();
        private CafeDbContext db = new CafeDbContext();

        // GET: api/SANPHAM
        public List<SANPHAM> GetSANPHAM()
        {
            return spDAO.GetSANPHAM();
            //return db.SANPHAM.ToList();
        }

        // GET: api/SANPHAM/LoaiSP?id={id}
        [HttpGet]
        [Route("LoaiSP")]
        public IHttpActionResult GetSANPHAMbyLSP(int id)
        {
            List<SANPHAM> lst = spDAO.GetSANPHAMByLSP(id);
            return Ok(lst);
        }
        // GET: api/SANPHAM/5
        [ResponseType(typeof(SANPHAM))]
        public IHttpActionResult GetSANPHAM(int id)
        {
            SANPHAM sANPHAM = spDAO.GetSANPHAMbyId(id);
            //SANPHAM sANPHAM = await db.SANPHAM.FindAsync(id);
            if (sANPHAM == null)
            {
                return NotFound();
            }

            return Ok(sANPHAM);
        }

        // PUT: api/SANPHAM/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSANPHAM(SANPHAM sANPHAM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //db.Entry(sANPHAM).State = EntityState.Modified;
            try
            {
                spDAO.UpdateSANPHAM(sANPHAM);
                //await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/SANPHAM
        [ResponseType(typeof(SANPHAM))]
        public async Task<IHttpActionResult> PostSANPHAM(SANPHAM sANPHAM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            spDAO.InsertSANPHAM(sANPHAM);
            //db.SANPHAM.Add(sANPHAM);
            //await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = sANPHAM.ID }, sANPHAM);
        }

        // DELETE: api/SANPHAM/5
        [ResponseType(typeof(SANPHAM))]
        public IHttpActionResult DeleteSANPHAM(int id)
        {
            SANPHAM sANPHAM = spDAO.GetSANPHAMbyId(id);
            if (sANPHAM == null)
            {
                return NotFound();
            }

            spDAO.DeleteSANPHAM(sANPHAM);

            return Ok(sANPHAM);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SANPHAMExists(int id)
        {
            return db.SANPHAM.Count(e => e.ID == id) > 0;
        }

        // GET: api/SANPHAM/Price?id={id}
        [HttpGet]
        [Route("Price")]
        [ResponseType(typeof(int))]
        public IHttpActionResult getPrice(int id)
        {
            DateTime now = DateTime.Now;
            PRICE price = spDAO.GetPriceBySanPham(id);
            //PRICE price = await db.PRICE.SingleOrDefaultAsync<PRICE>(x => x.SANPHAM_ID == id && 
            //(x.BATDAU<= now && x.KETTHUC >=now || x.BATDAU <= now && x.KETTHUC == null));
            return Ok(price.GIABAN);
        }

        [HttpGet]
        [Route("ThongtinSP")]
        public IHttpActionResult GetInfoSANPHAM(int id)
        {
            DateTime now = DateTime.Now;
            var lst = (from p in db.SANPHAM
                       select new
                       {
                           ID = p.ID,
                           KHOILUONG = p.KHOILUONG,
                           MOTA = p.MOTA,
                           ANH = p.ANH,
                           SOLUONG = p.SOLUONG,
                           TEN = ((from z in db.LOAISP
                                      where z.ID == p.LOAISP_ID
                                      select new
                                      {
                                          z.TEN
                                      }).FirstOrDefault().TEN),
                           GIA = (from x in db.PRICE
                                  from y in db.SANPHAM
                                  where x.SANPHAM_ID == y.ID && (x.BATDAU <= now && x.KETTHUC >= now || x.BATDAU <= now && x.KETTHUC == null)
                                  select new
                                  {
                                      x.GIABAN
                                  }).FirstOrDefault().GIABAN,
                       });
            return Ok(lst);
        }
    }
}