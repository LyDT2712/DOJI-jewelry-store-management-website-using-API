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
    public class UserController : ApiController
    {
        // GET: User
        QLTrangSucEntities db = new QLTrangSucEntities();
        // GET: User
        [HttpGet]
        [Route("api/user/Get")]
        public List<user> GetAllUser()
        {
            return db.users.ToList();
        }

        // GET: User/Details/5
        [HttpGet]
        [Route("api/user/GetUserByID")]
        public user GetUserByID(int id)
        {
            return db.users.SingleOrDefault(r => r.id == id);
        }

        // GET: User/Create
        [HttpPost]
        [Route("api/user/Post")]
        public HttpResponseMessage Post([FromBody] user u)
        {
            using (QLTrangSucEntities db = new QLTrangSucEntities())
            {
                try
                {
                    db.users.Add(u);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.Created);
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Lỗi nhé:" + ex.Message);
                }
            }
        }



        // GET: User/Edit/5
        [HttpPut]
        [Route("api/user/Put")]
        public List<user> Put([FromBody] user u)
        {
            user n = db.users.FirstOrDefault(m => m.id == u.id);
            n.full_name = u.full_name;
            n.users_name = u.users_name;
            n.email = u.email;
            n.password = u.password;
            n.phone = u.phone;
            n.address = u.address;
            n.image = u.image;
            db.SaveChanges();
            return db.users.ToList();
        }

        [HttpDelete]

        [Route("api/user/Delete")]
        public List<user> Delete(int id)
        {
            db.users.Remove(db.users.Find(id));
            db.SaveChanges();
            return db.users.ToList();
        }
        [HttpGet]
        [Route("api/user/Search")]
        public List<user> Search(string key)
        {
            using (QLTrangSucEntities db = new QLTrangSucEntities())
            {
                try
                {
                    return db.users.Where(e => e.id.ToString().Contains(key) ||
                    (e.full_name + " " + e.users_name + " " + e.email + " " + e.password + " " + e.phone + " " + e.address + " " + e.image).Contains(key)).ToList();
                }
                catch
                {
                    return null;
                }

            }

        }
    }
}