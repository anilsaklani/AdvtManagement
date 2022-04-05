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
    public class DiscussionsController : Controller
    {
        private AdvtManagementEntities db = new AdvtManagementEntities();

        // GET: Discussions
        public ActionResult Index()
        {
            var dISCUSSIONs = db.DISCUSSIONs.Include(d => d.ADVERTISEMENT);
            return View(dISCUSSIONs.ToList());
        }

        // GET: Discussions/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DISCUSSION dISCUSSION = db.DISCUSSIONs.Find(id);
            if (dISCUSSION == null)
            {
                return HttpNotFound();
            }
            return View(dISCUSSION);
        }

        // GET: Discussions/Create
        public ActionResult Create()
        {
            ViewBag.Advertisement_Code = new SelectList(db.ADVERTISEMENTs, "Code", "Campaign_Code");
            return View();
        }

        // POST: Discussions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Advertisement_Code,MeetingDate,Details")] DISCUSSION dISCUSSION)
        {
            if (ModelState.IsValid)
            {
                db.DISCUSSIONs.Add(dISCUSSION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Advertisement_Code = new SelectList(db.ADVERTISEMENTs, "Code", "Campaign_Code", dISCUSSION.Advertisement_Code);
            return View(dISCUSSION);
        }

        // GET: Discussions/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DISCUSSION dISCUSSION = db.DISCUSSIONs.Find(id);
            if (dISCUSSION == null)
            {
                return HttpNotFound();
            }
            ViewBag.Advertisement_Code = new SelectList(db.ADVERTISEMENTs, "Code", "Campaign_Code", dISCUSSION.Advertisement_Code);
            return View(dISCUSSION);
        }

        // POST: Discussions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Advertisement_Code,MeetingDate,Details")] DISCUSSION dISCUSSION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dISCUSSION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Advertisement_Code = new SelectList(db.ADVERTISEMENTs, "Code", "Campaign_Code", dISCUSSION.Advertisement_Code);
            return View(dISCUSSION);
        }

        // GET: Discussions/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DISCUSSION dISCUSSION = db.DISCUSSIONs.Find(id);
            if (dISCUSSION == null)
            {
                return HttpNotFound();
            }
            return View(dISCUSSION);
        }

        // POST: Discussions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            DISCUSSION dISCUSSION = db.DISCUSSIONs.Find(id);
            db.DISCUSSIONs.Remove(dISCUSSION);
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
