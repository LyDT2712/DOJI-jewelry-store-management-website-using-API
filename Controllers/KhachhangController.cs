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
    public class KhachhangController : ApiController
    {
        QLTrangSucEntities db = new QLTrangSucEntities();
        // GET: Khachhang
        [HttpGet]
        [Route("api/khach_hang/Get")]
        public List<khach_hang> GetAllKhachhang()
        {
            return db.khach_hang.ToList();
        }

        // GET: Khachhang/Details/5
        [HttpGet]
        [Route("api/khach_hang/GetKhachhangByID")]
        public khach_hang GetKhachhangByID(int id)
        {
            return db.khach_hang.SingleOrDefault(r => r.id == id);
        }

        // GET: Khachhang/Create
        [HttpPost]
        [Route("api/khach_hang/Post")]
        public HttpResponseMessage Post([FromBody] khach_hang kh)
        {
            using (QLTrangSucEntities db = new QLTrangSucEntities())
            {
                try
                {
                    db.khach_hang.Add(kh);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.Created);
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Lỗi nhé:" + ex.Message);
                }
            }
        }



        // GET: Khachhang/Edit/5
        [HttpPut]
        [Route("api/khach_hang/Put")]
        public List<khach_hang> Put([FromBody] khach_hang kh)
        {
            khach_hang n = db.khach_hang.FirstOrDefault(m => m.id == kh.id);
            n.ten_kh = kh.ten_kh;
            n.email = kh.email;
            n.dia_chi = kh.dia_chi;
            n.sdt = kh.sdt;
            n.note = kh.note;
            n.password = kh.password;
            db.SaveChanges();
            return db.khach_hang.ToList();
        }

        [HttpDelete]

        [Route("api/khach_hang/Delete")]
        public List<khach_hang> Delete(int id)
        {
            db.khach_hang.Remove(db.khach_hang.Find(id));
            db.SaveChanges();
            return db.khach_hang.ToList();
        }
        [HttpGet]
        [Route("api/khach_hang/Search")]
        public List<khach_hang> Search(string key)
        {
            using (QLTrangSucEntities db = new QLTrangSucEntities())
            {
                try
                {
                    return db.khach_hang.Where(e => e.id.ToString().Contains(key) ||
                    (e.ten_kh + " " + e.email + " " + e.dia_chi + " " + e.sdt + " " + e.note + " " + e.password).Contains(key)).ToList();
                }
                catch
                {
                    return null;
                }

            }

        }
        [HttpGet]
        [Route("api/khach_hang/Login")]
        public List<khach_hang> Login(string email, string pass)
        {
            return db.khach_hang.Where(e => e.email == email && e.password == pass).ToList();

        }
    }
}
