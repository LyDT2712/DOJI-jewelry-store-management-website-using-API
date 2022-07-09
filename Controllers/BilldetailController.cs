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
    public class BilldetailController : ApiController
    {
        // GET: Billdetail

        QLTrangSucEntities db = new QLTrangSucEntities();
        [HttpGet]
        [Route("api/bill_detail_ban/Get")]
        public List<bill_detail_ban> GetAllBilldetailban()
        {
            return db.bill_detail_ban.ToList();
        }
        [HttpGet]
        [Route("api/bill_detail_ban/Search")]
        public List<bill_detail_ban> Search(string key)
        {
            using (QLTrangSucEntities db = new QLTrangSucEntities())
            {
                try
                {
                    return db.bill_detail_ban.Where(e => e.id.ToString().Contains(key) ||
                    (e.id_bills_ban + " " + e.id_sp + " " + e.sl + " ").Contains(key)).ToList();
                }
                catch
                {
                    return null;
                }

            }

        }

    }
}