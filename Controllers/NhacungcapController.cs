using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using QLTS_api.Models;

namespace QLTS_api.Controllers
{
    public class NhacungcapController : ApiController
    {
        // GET: Nhacungcap
        QLTrangSucEntities db = new QLTrangSucEntities();
        // GET: Nhacungcap
        [HttpGet]
        [Route("api/nha_cung_cap/Get")]
        public List<nha_cung_cap> GetAllNhacungcap()
        {
            return db.nha_cung_cap.ToList();
        }

        // GET: Nhacungcap/Details/5
        [HttpGet]
        [Route("api/nha_cung_cap/GetNhacungcapByID")]
        public nha_cung_cap GetNhacungcapByID(int id)
        {
            return db.nha_cung_cap.SingleOrDefault(r => r.id == id);
        }

        // GET: Nhacungcap/Create
        [HttpPost]
        [Route("api/nha_cung_cap/Post")]
        public HttpResponseMessage Post([FromBody] nha_cung_cap ncc)
        {
            using (QLTrangSucEntities db = new QLTrangSucEntities())
            {
                try
                {
                    db.nha_cung_cap.Add(ncc);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.Created);
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Lỗi nhé:" + ex.Message);
                }
            }
        }



        // GET: Nhacungcap/Edit/5
        [HttpPut]
        [Route("api/nha_cung_cap/Put")]
        public List<nha_cung_cap> Put([FromBody] nha_cung_cap kh)
        {
            nha_cung_cap n = db.nha_cung_cap.FirstOrDefault(m => m.id == kh.id);
            n.ten_ncc = kh.ten_ncc;
            n.diachi_ncc = kh.diachi_ncc;
            n.email = kh.email;
            n.sdt = kh.sdt;
            db.SaveChanges();
            return db.nha_cung_cap.ToList();
        }

        [HttpDelete]

        [Route("api/nha_cung_cap/Delete")]
        public List<nha_cung_cap> Delete(int id)
        {
            db.nha_cung_cap.Remove(db.nha_cung_cap.Find(id));
            db.SaveChanges();
            return db.nha_cung_cap.ToList();
        }
        [HttpGet]
        [Route("api/nha_cung_cap/Search")]
        public List<nha_cung_cap> Search(string key)
        {
            using (QLTrangSucEntities db = new QLTrangSucEntities())
            {
                try
                {
                    return db.nha_cung_cap.Where(e => e.id.ToString().Contains(key) ||
                    (e.ten_ncc + " " + e.diachi_ncc + " " + e.email  + " " + e.sdt ).Contains(key)).ToList();
                }
                catch
                {
                    return null;
                }

            }

        }
    }
}