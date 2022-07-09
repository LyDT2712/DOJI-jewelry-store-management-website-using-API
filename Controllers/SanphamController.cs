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
    public class SanphamController : ApiController
    {
        // GET: Sanpham
        QLTrangSucEntities db = new QLTrangSucEntities();
        // GET: Sanpham
        [HttpGet]
        [Route("api/san_pham/Get")]
        public List<san_pham> GetAllSanpham()
        {
            return db.san_pham.ToList();
        }

        // GET: Sanpham/Details/5
        [HttpGet]
        [Route("api/san_pham/GetSanphamByID")]
        public san_pham GetSanphamByID(int id)
        {
            return db.san_pham.SingleOrDefault(r => r.id == id);
        }

        // GET: Sanpham/Create
        [HttpPost]
        [Route("api/san_pham/Post")]
        public HttpResponseMessage Post([FromBody] san_pham sp)
        {
            using (QLTrangSucEntities db = new QLTrangSucEntities())
            {
                try
                {
                    db.san_pham.Add(sp);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.Created);
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Lỗi nhé:" + ex.Message);
                }
            }
        }



        // GET: Sanpham/Edit/5
        [HttpPut]
        [Route("api/san_pham/Put")]
        public List<san_pham> Put([FromBody] san_pham sp)
        {
            san_pham n = db.san_pham.FirstOrDefault(m => m.id == sp.id);
            n.name = sp.name;
            n.id_loai_sp = sp.id_loai_sp;
            n.id_ncc = sp.id_ncc;
            n.image = sp.image;
            n.mota_sp = sp.mota_sp;
            n.unit_price = sp.unit_price;
            n.so_luong = sp.so_luong;
            n.image = sp.image;
            n.kich_thuoc = sp.kich_thuoc;
            db.SaveChanges();
            return db.san_pham.ToList();
        }

        [HttpDelete]

        [Route("api/san_pham/Delete")]
        public List<san_pham> Delete(int id)
        {
            db.san_pham.Remove(db.san_pham.Find(id));
            db.SaveChanges();
            return db.san_pham.ToList();
        }
        [HttpGet]
        [Route("api/san_pham/Search")]
        public List<san_pham> Search(string key)
        {
            using (QLTrangSucEntities db = new QLTrangSucEntities())
            {
                try
                {
                    return db.san_pham.Where(e => e.id.ToString().Contains(key) ||
                    (e.name + " " + e.id_loai_sp + " " + e.id_ncc + " " + e.mota_sp + " " + e.unit_price + " " + e.so_luong + " " + e.image + " " + e.kich_thuoc).Contains(key)).ToList();
                }
                catch
                {
                    return null;
                }

            }

        }
        [HttpGet]
        [Route("api/san_pham/GetSPtheoloai")]
        public List<san_pham> GetSPtheoloai(int id)
        {
            using (QLTrangSucEntities db = new QLTrangSucEntities())
            {
                try
                {
                    return db.san_pham.ToList().FindAll(e => e.id_loai_sp == id);
                }
                catch
                {
                    return null;
                }

            }

        }
    }
}