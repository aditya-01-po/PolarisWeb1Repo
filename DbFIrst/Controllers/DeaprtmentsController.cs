using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DbFIrst.Models;
using Newtonsoft.Json;

namespace DbFIrst.Controllers
{
    public class DeaprtmentsController : Controller
    {
        private NettrainingEntities1 db = new NettrainingEntities1();

        //[Route("api")]
        // GET: Deaprtments
        public async Task<ActionResult> Index()
        {
            //return View(db.Deaprtments.ToList());

            //Yeh niche wala code is generally taking data from API jo ki kisi aur project meh run kar raha hai background meh live and displaying it directly to the UI controller.
            //Yeh actually service project meh likhna hoga but for simplicity we have written here.\

            List<Deaprtment> deaprtments = new List<Deaprtment>();
            
            string Baseurl = @"https://localhost:44362/";
            using (var client = new System.Net.Http.HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                System.Net.ServicePointManager.ServerCertificateValidationCallback =
                 delegate (
                 object s,
                X509Certificate certificate,
                 X509Chain chain,
                SslPolicyErrors sslPolicyErrors
                 )
                 {
                     return true;
                 };

                System.Net.Http.HttpResponseMessage Res = await client.GetAsync("api/Deaprtment");
                if (Res.IsSuccessStatusCode)
                {
                    // Storing the response details received from web API 
                    string DeaprtmentResponse = await Res.Content.ReadAsStringAsync();
                    // Deserializing the response received from web API and storing into the Department list
                    deaprtments = JsonConvert.DeserializeObject<List<Deaprtment>>(DeaprtmentResponse);
                }
            }
            return View(deaprtments.ToList());
        }


        // GET: Deaprtments/Details/5
        public ActionResult Details(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Deaprtment deaprtment = db.Deaprtments.Find(id);
            if (deaprtment == null)
            {
                return HttpNotFound();
            }
            return View(deaprtment);
        }

        // GET: Deaprtments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Deaprtments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DEPTNAME")] Deaprtment deaprtment)
        {
            if (ModelState.IsValid)
            {
                db.Deaprtments.Add(deaprtment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(deaprtment);
        }

        // GET: Deaprtments/Edit/5
        public ActionResult Edit(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Deaprtment deaprtment = db.Deaprtments.Find(id);
            if (deaprtment == null)
            {
                return HttpNotFound();
            }
            return View(deaprtment);
        }

        // POST: Deaprtments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DEPTNAME")] Deaprtment deaprtment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deaprtment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(deaprtment);
        }

        // GET: Deaprtments/Delete/5
        public ActionResult Delete(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Deaprtment deaprtment = db.Deaprtments.Find(id);
            if (deaprtment == null)
            {
                return HttpNotFound();
            }
            return View(deaprtment);
        }

        // POST: Deaprtments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(byte id)
        {
            Deaprtment deaprtment = db.Deaprtments.Find(id);
            db.Deaprtments.Remove(deaprtment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
