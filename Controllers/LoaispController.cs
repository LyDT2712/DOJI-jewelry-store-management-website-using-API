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
    public class LoaispController : ApiController
    {
        // GET: Loaisp
        QLTrangSucEntities db = new QLTrangSucEntities();
        // GET: Loaisp
        [HttpGet]
        [Route("api/loai_sp/Get")]
        public List<loai_sp> GetAllLoaisp()
        {
            return db.loai_sp.ToList();
        }

        // GET: Loaisp/Details/5
        [HttpGet]
        [Route("api/loai_sp/GetLoaispByID")]
        public loai_sp GetLoaispByID(int id)
        {
            return db.loai_sp.SingleOrDefault(r => r.id == id);
        }

        // GET: Loaisp/Create
        [HttpPost]
        [Route("api/loai_sp/Post")]
        public HttpResponseMessage Post([FromBody] loai_sp kh)
        {
            using (QLTrangSucEntities db = new QLTrangSucEntities())
            {
                try
                {
                    db.loai_sp.Add(kh);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.Created);
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Lỗi nhé:" + ex.Message);
                }
            }
        }



        // GET: Loaisp/Edit/5
        [HttpPut]
        [Route("api/loai_sp/Put")]
        public List<loai_sp> Put([FromBody] loai_sp lsp)
        {
            loai_sp n = db.loai_sp.FirstOrDefault(m => m.id == lsp.id);
            n.tenloai = lsp.tenloai;
            db.SaveChanges();
            return db.loai_sp.ToList();
        }

        [HttpDelete]

        [Route("api/loai_sp/Delete")]
        public List<loai_sp> Delete(int id)
        {
            db.loai_sp.Remove(db.loai_sp.Find(id));
            db.SaveChanges();
            return db.loai_sp.ToList();
        }
        [HttpGet]
        [Route("api/loai_sp/Search")]
        public List<loai_sp> Search(string key)
        {
            using (QLTrangSucEntities db = new QLTrangSucEntities())
            {
                try
                {
                    return db.loai_sp.Where(e => e.id.ToString().Contains(key) ||
                    (e.tenloai).Contains(key)).ToList();
                }
                catch
                {
                    return null;
                }

            }

        }
        
    }
}