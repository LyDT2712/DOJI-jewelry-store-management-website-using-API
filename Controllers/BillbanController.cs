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
    public class BillbanController : ApiController
    {
        // GET: Billban
        QLTrangSucEntities db = new QLTrangSucEntities();
        // GET: Billban
        [HttpGet]
        [Route("api/bills_ban/Get")]
        public List<bills_ban> GetAllBillban()
        {
            return db.bills_ban.ToList();
        }

        // GET: Billban/Details/5
        [HttpGet]
        [Route("api/bills_ban/GetBillbanByID")]
        public bills_ban GetBillbanByID(int id)
        {
            return db.bills_ban.SingleOrDefault(r => r.id == id);
        }

        // GET: Billban/Create
        [HttpPost]
        [Route("api/bills_ban/Post")]
        public HttpResponseMessage Post([FromBody] bills_ban bb)
        {
            using (QLTrangSucEntities db = new QLTrangSucEntities())
            {
                try
                {
                    bb.date_order = DateTime.Now;
            
                    db.bills_ban.Add(bb);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.Created);
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "LỖi: " + ex.InnerException);
                }
            }
        }



        // GET: Billban/Edit/5
        [HttpPut]
        [Route("api/bills_ban/Put")]
        public List<bills_ban> Put([FromBody] bills_ban bb)
        {
            bills_ban n = db.bills_ban.FirstOrDefault(m => m.id == bb.id);
            n.id_kh = bb.id_kh;
            n.date_order = bb.date_order;
            n.tong_tien = bb.tong_tien;
            n.payment = bb.payment;
            n.status = bb.status;
            n.note = bb.note;
            db.SaveChanges();
            return db.bills_ban.ToList();
        }

        [HttpDelete]

        [Route("api/bills_ban/Delete")]
        public List<bills_ban> Delete(int id)
        {
            db.bills_ban.Remove(db.bills_ban.Find(id));
            db.SaveChanges();
            return db.bills_ban.ToList();
        }
        [HttpGet]
        [Route("api/bills_ban/Search")]
        public List<bills_ban> Search(string key)
        {
            using (QLTrangSucEntities db = new QLTrangSucEntities())
            {
                try
                {
                    return db.bills_ban.Where(e => e.id_kh.ToString().Contains(key) ||
                    (e.id_kh + " " + e.date_order + " " + e.tong_tien + " " + e.payment + " " + e.status + " " + e.note).Contains(key)).ToList();
                }
                catch
                {
                    return null;
                }

            }

        }
        [HttpGet]
        [Route("api/bills_ban/Getbb")]
        public Object Getbb()
        {
            var data = (from b in db.khach_hang
                        join c in db.bills_ban 
                        on b.id equals c.id_kh
                      
                        select new
                        {
                            id = c.id,
                            ten_kh = b.ten_kh,
                            sdt = b.sdt,
                            dia_chi = b.dia_chi,
                            date_order = c.date_order,
                            tong_tien = c.tong_tien,
                            payment = c.payment,
                            status = c.status,
                            note = c.note
          

                        }).ToList();

            return data;
        }
    }
}