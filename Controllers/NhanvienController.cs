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
    public class NhanvienController : ApiController
    {
        QLTrangSucEntities db = new QLTrangSucEntities();
        // GET: Nhanvien
        [HttpGet]
        [Route("api/nhan_vien/Get")]
        public List<nhan_vien> GetAllNhanvien()
        {
            return db.nhan_vien.ToList();
        }

        // GET api/<controller>/5
        [HttpGet]
        [Route("api/nhan_vien/GetNhanvienByID")]
        public nhan_vien GetNhanvienByID(int id)
        {
            return db.nhan_vien.SingleOrDefault(r => r.id == id);
        }

       

        // POST: Nhanvien/Create
        [HttpPost]
        [Route("api/nhan_vien/Post")]
        public HttpResponseMessage Post([FromBody] nhan_vien nv)
        {
            using (QLTrangSucEntities db = new QLTrangSucEntities())
            {
                try
                {
                    db.nhan_vien.Add(nv);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.Created);
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Lỗi nhé:" + ex.Message);
                }
            }
        }
        
        // GET: Nhanvien/Edit/5
        [HttpPut]
        [Route("api/nhan_vien/Put")]
        public List<nhan_vien> Put([FromBody] nhan_vien nv)
        {
            nhan_vien n = db.nhan_vien.FirstOrDefault(m => m.id == nv.id);
            n.ten_nhanvien = nv.ten_nhanvien;
            n.gioitinh = nv.gioitinh;
            n.ngaysinh = nv.ngaysinh;
            n.quequan = nv.quequan;
            n.sdt = nv.sdt;
            n.email = nv.email;
            n.capbac = nv.capbac;
            db.SaveChanges();
            return db.nhan_vien.ToList();
        }

        // GET: Nhanvien/Delete/5
        [HttpDelete]
        // POST api/<controller>
        [Route("api/nhan_vien/Delete")]
        public List<nhan_vien> Delete(int id)
        {
            db.nhan_vien.Remove(db.nhan_vien.Find(id));
            db.SaveChanges();
            return db.nhan_vien.ToList();
        }
        [HttpGet]
        [Route("api/nhan_vien/Search")]
        public List<nhan_vien> Search(string key)
        {
            using (QLTrangSucEntities db = new QLTrangSucEntities())
            {
                try
                {
                    return db.nhan_vien.Where(e => e.id.ToString().Contains(key) || 
                    (e.ten_nhanvien + " " + e.gioitinh + " " + e.ngaysinh + " " + e.quequan + " " + e.sdt + " " + e.email + " "+ e.capbac+" ").Contains(key)).ToList();
                }
                catch
                {
                    return null;
                }

            }

        }
    }
}

