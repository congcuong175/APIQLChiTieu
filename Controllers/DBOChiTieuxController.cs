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
    public class DBOChiTieuxController : ApiController
    {
        private QLCHITEUEntities db = new QLCHITEUEntities();

        // GET: api/DBOChiTieux
        public IHttpActionResult GetDBOChiTieux()
        {
            List<Ngay> ngays = new List<Ngay>();
            List<DBOChiTieu> list = new List<DBOChiTieu>();
            if (db.DBOChiTieux.ToList().Count > 0)
            {
                string ngay = db.DBOChiTieux.ToList()[0].ngayThang;
                for (int i = 0; i < db.DBOChiTieux.ToList().Count(); i++)
                {
                    if ((bool)db.DBOChiTieux.ToList()[i].isChiTieu)
                    {
                        foreach (LOAICHITIEU ct in db.LOAICHITIEUx.ToList())
                        {
                            if (db.DBOChiTieux.ToList()[i].maLoaiChiTieu == ct.maLoaiCT)
                            {
                                db.DBOChiTieux.ToList()[i].idicon = (int)ct.iCon;
                                db.DBOChiTieux.ToList()[i].tenChiTieu = ct.tenLoaiTN;
                                break;
                            }
                        }
                    }
                    else
                    {
                        foreach (LOAITHUNHAP tn in db.LOAITHUNHAPs.ToList())
                        {
                            if (db.DBOChiTieux.ToList()[i].maLoaiChiTieu == tn.maLoaiTN)
                            {
                                db.DBOChiTieux.ToList()[i].idicon = (int)tn.icon;
                                db.DBOChiTieux.ToList()[i].tenChiTieu = tn.tenLoaiTN;
                                break;
                            }
                        }
                    }
                    

                    if (ngay.ToUpper().Equals(db.DBOChiTieux.ToList()[i].ngayThang.ToUpper()))
                    {

                        list.Add(db.DBOChiTieux.ToList()[i]);
                        if (db.DBOChiTieux.ToList().Count - 1 == i)
                        {
                            ngays.Add(new Ngay(ngay, list));
                        }
                    }
                    else
                    {
                        ngays.Add(new Ngay(ngay, list));
                        list = new List<DBOChiTieu>();
                        list.Add(db.DBOChiTieux.ToList()[i]);
                        ngay = db.DBOChiTieux.ToList()[i].ngayThang;
                        if (db.DBOChiTieux.ToList().Count - 1 == i)
                        {
                            ngays.Add(new Ngay(ngay, list));
                        }

                    }
                }
                return Ok(ngays);
            }
            return BadRequest("Lỗi");

        }


        // GET: api/DBOChiTieux/5
        [ResponseType(typeof(DBOChiTieu))]
        public IHttpActionResult GetDBOChiTieu(int id)
        {
            DBOChiTieu dBOChiTieu = db.DBOChiTieux.Find(id);
            if ((bool)dBOChiTieu.isChiTieu)
            {
                foreach (LOAICHITIEU ct in db.LOAICHITIEUx.ToList())
                {
                    if (dBOChiTieu.maLoaiChiTieu == ct.maLoaiCT)
                    {
                        dBOChiTieu.idicon = (int)ct.iCon;
                        dBOChiTieu.tenChiTieu = ct.tenLoaiTN;
                        break;
                    }

                }
            }
            else
            {
                foreach (LOAITHUNHAP tn in db.LOAITHUNHAPs.ToList())
                {
                    if (dBOChiTieu.maLoaiChiTieu == tn.maLoaiTN)
                    {
                        dBOChiTieu.idicon = (int)tn.icon;
                        dBOChiTieu.tenChiTieu = tn.tenLoaiTN;
                        break;
                    }
                }
            }

            if (dBOChiTieu == null)
            {
                return NotFound();
            }

            return Ok(dBOChiTieu);
        }

        // PUT: api/DBOChiTieux/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDBOChiTieu(int id,[FromBody] DBOChiTieu dBOChiTieu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dBOChiTieu.maChiTieu)
            {
                return BadRequest();
            }

            db.Entry(dBOChiTieu).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DBOChiTieuExists(id))
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

        // POST: api/DBOChiTieux
        [ResponseType(typeof(DBOChiTieu))]
        public IHttpActionResult PostDBOChiTieu([FromBody] DBOChiTieu dBOChiTieu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DBOChiTieux.Add(dBOChiTieu);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dBOChiTieu.maChiTieu }, dBOChiTieu);
        }

        // DELETE: api/DBOChiTieux/5
        [ResponseType(typeof(DBOChiTieu))]
        public IHttpActionResult DeleteDBOChiTieu(int id)
        {
            DBOChiTieu dBOChiTieu = db.DBOChiTieux.Find(id);
            if (dBOChiTieu == null)
            {
                return NotFound();
            }

            db.DBOChiTieux.Remove(dBOChiTieu);
            db.SaveChanges();

            return Ok(dBOChiTieu);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DBOChiTieuExists(int id)
        {
            return db.DBOChiTieux.Count(e => e.maChiTieu == id) > 0;
        }
    }
}