using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using APIQLChiTieu.Models;
using EntityState = System.Data.Entity.EntityState;

namespace APIQLChiTieu.Controllers
{
    public class LOAICHITIEUxController : ApiController
    {
        private QLCHITEUEntities db = new QLCHITEUEntities();

        // GET: api/LOAICHITIEUx
        public IQueryable<LOAICHITIEU> GetLOAICHITIEUx()
        {
            return db.LOAICHITIEUx;
        }

        // GET: api/LOAICHITIEUx/5
        [ResponseType(typeof(LOAICHITIEU))]
        public IHttpActionResult GetLOAICHITIEU(int id)
        {
            LOAICHITIEU lOAICHITIEU = db.LOAICHITIEUx.Find(id);
            if (lOAICHITIEU == null)
            {
                return NotFound();
            }

            return Ok(lOAICHITIEU);
        }

        // PUT: api/LOAICHITIEUx/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLOAICHITIEU(int id, [FromBody]LOAICHITIEU lOAICHITIEU)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lOAICHITIEU.maLoaiCT)
            {
                return BadRequest();
            }

            db.Entry(lOAICHITIEU).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LOAICHITIEUExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/LOAICHITIEUx
        [ResponseType(typeof(LOAICHITIEU))]
        public IHttpActionResult PostLOAICHITIEU(LOAICHITIEU lOAICHITIEU)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LOAICHITIEUx.Add(lOAICHITIEU);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = lOAICHITIEU.maLoaiCT }, lOAICHITIEU);
        }

        // DELETE: api/LOAICHITIEUx/5
        [ResponseType(typeof(LOAICHITIEU))]
        public IHttpActionResult DeleteLOAICHITIEU(int id)
        {
            
            LOAICHITIEU lOAICHITIEU = db.LOAICHITIEUx.Find(id);
            bool kt = true;
            foreach (DBOChiTieu x in db.DBOChiTieux)
            {
                if ((bool)x.isChiTieu)
                {
                    if (x.maLoaiChiTieu == lOAICHITIEU.maLoaiCT)
                    {
                        kt = false;
                    }
                }
                
            }
            if (kt)
            {
                if (lOAICHITIEU == null)
                {
                    return NotFound();
                }

                db.LOAICHITIEUx.Remove(lOAICHITIEU);
                db.SaveChanges();
            }
            else
            {
                return BadRequest("Không có");
            }
            
            return Ok(lOAICHITIEU);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LOAICHITIEUExists(int id)
        {
            return db.LOAICHITIEUx.Count(e => e.maLoaiCT == id) > 0;
        }
    }
}