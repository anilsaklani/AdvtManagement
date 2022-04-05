using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AdvtManagement.Models;

namespace AdvtManagement.Controllers
{
    public class AdvertisementsController : Controller
    {
        private AdvtManagementEntities db = new AdvtManagementEntities();

        // GET: Advertisements
        public ActionResult Index()
        {
            var aDVERTISEMENTs = db.ADVERTISEMENTs.Include(a => a.ADVT_STATUS_TYPE).Include(a => a.CAMPAIGN).Include(a => a.MEDIA_TYPE);
            return View(aDVERTISEMENTs.ToList());
        }

        // GET: Advertisements/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ADVERTISEMENT aDVERTISEMENT = db.ADVERTISEMENTs.Find(id);
            if (aDVERTISEMENT == null)
            {
                return HttpNotFound();
            }
            return View(aDVERTISEMENT);
        }

        // GET: Advertisements/Create
        public ActionResult Create()
        {
            ViewBag.Status = new SelectList(db.ADVT_STATUS_TYPE, "Code", "Description");
            ViewBag.Campaign_Code = new SelectList(db.CAMPAIGNs, "Code", "Department_Code");
            ViewBag.Media_Code = new SelectList(db.MEDIA_TYPE, "Code", "Description");
            return View();
        }

        // POST: Advertisements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Code,Campaign_Code,Cost,Content_url,Status,Media_Code")] ADVERTISEMENT aDVERTISEMENT)
        {
            if (ModelState.IsValid)
            {
                db.ADVERTISEMENTs.Add(aDVERTISEMENT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Status = new SelectList(db.ADVT_STATUS_TYPE, "Code", "Description", aDVERTISEMENT.Status);
            ViewBag.Campaign_Code = new SelectList(db.CAMPAIGNs, "Code", "Department_Code", aDVERTISEMENT.Campaign_Code);
            ViewBag.Media_Code = new SelectList(db.MEDIA_TYPE, "Code", "Description", aDVERTISEMENT.Media_Code);
            return View(aDVERTISEMENT);
        }

        // GET: Advertisements/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ADVERTISEMENT aDVERTISEMENT = db.ADVERTISEMENTs.Find(id);
            if (aDVERTISEMENT == null)
            {
                return HttpNotFound();
            }
            ViewBag.Status = new SelectList(db.ADVT_STATUS_TYPE, "Code", "Description", aDVERTISEMENT.Status);
            ViewBag.Campaign_Code = new SelectList(db.CAMPAIGNs, "Code", "Department_Code", aDVERTISEMENT.Campaign_Code);
            ViewBag.Media_Code = new SelectList(db.MEDIA_TYPE, "Code", "Description", aDVERTISEMENT.Media_Code);
            return View(aDVERTISEMENT);
        }

        // POST: Advertisements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Code,Campaign_Code,Cost,Content_url,Status,Media_Code")] ADVERTISEMENT aDVERTISEMENT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aDVERTISEMENT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Status = new SelectList(db.ADVT_STATUS_TYPE, "Code", "Description", aDVERTISEMENT.Status);
            ViewBag.Campaign_Code = new SelectList(db.CAMPAIGNs, "Code", "Department_Code", aDVERTISEMENT.Campaign_Code);
            ViewBag.Media_Code = new SelectList(db.MEDIA_TYPE, "Code", "Description", aDVERTISEMENT.Media_Code);
            return View(aDVERTISEMENT);
        }

        // GET: Advertisements/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ADVERTISEMENT aDVERTISEMENT = db.ADVERTISEMENTs.Find(id);
            if (aDVERTISEMENT == null)
            {
                return HttpNotFound();
            }
            return View(aDVERTISEMENT);
        }

        // POST: Advertisements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ADVERTISEMENT aDVERTISEMENT = db.ADVERTISEMENTs.Find(id);
            db.ADVERTISEMENTs.Remove(aDVERTISEMENT);
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
