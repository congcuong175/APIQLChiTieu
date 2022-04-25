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
    public class LOAITHUNHAPsController : ApiController
    {
        private QLCHITEUEntities db = new QLCHITEUEntities();

        // GET: api/LOAITHUNHAPs
        public IQueryable<LOAITHUNHAP> GetLOAITHUNHAPs()
        {
            return db.LOAITHUNHAPs;
        }

        // GET: api/LOAITHUNHAPs/5
        [ResponseType(typeof(LOAITHUNHAP))]
        public IHttpActionResult GetLOAITHUNHAP(int id)
        {
            LOAITHUNHAP lOAITHUNHAP = db.LOAITHUNHAPs.Find(id);
            if (lOAITHUNHAP == null)
            {
                return NotFound();
            }

            return Ok(lOAITHUNHAP);
        }

        // PUT: api/LOAITHUNHAPs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLOAITHUNHAP(int id,[FromBody] LOAITHUNHAP lOAITHUNHAP)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lOAITHUNHAP.maLoaiTN)
            {
                return BadRequest();
            }

            db.Entry(lOAITHUNHAP).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LOAITHUNHAPExists(id))
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

        // POST: api/LOAITHUNHAPs
        [ResponseType(typeof(LOAITHUNHAP))]
        public IHttpActionResult PostLOAITHUNHAP([FromBody] LOAITHUNHAP lOAITHUNHAP)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LOAITHUNHAPs.Add(lOAITHUNHAP);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = lOAITHUNHAP.maLoaiTN }, lOAITHUNHAP);
        }

        // DELETE: api/LOAITHUNHAPs/5
        [ResponseType(typeof(LOAITHUNHAP))]
        public IHttpActionResult DeleteLOAITHUNHAP(int id)
        {
            bool kt = true;
            LOAITHUNHAP lOAITHUNHAP = db.LOAITHUNHAPs.Find(id);
            foreach (DBOChiTieu x in db.DBOChiTieux)
            {
                if (!(bool)x.isChiTieu)
                {
                    if (x.maLoaiChiTieu == lOAITHUNHAP.maLoaiTN)
                    {
                        kt = false;
                    }
                }
                
            }
            if (kt)
            {
                if (lOAITHUNHAP == null)
                {
                    return NotFound();
                }

                db.LOAITHUNHAPs.Remove(lOAITHUNHAP);
                db.SaveChanges();
            }
            else
            {
                return BadRequest("Không có");
            }

            return Ok(lOAITHUNHAP);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LOAITHUNHAPExists(int id)
        {
            return db.LOAITHUNHAPs.Count(e => e.maLoaiTN == id) > 0;
        }
    }
}