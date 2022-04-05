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
    public class FeedbacksController : Controller
    {
        private AdvtManagementEntities db = new AdvtManagementEntities();

        // GET: Feedbacks
        public ActionResult Index()
        {
            var fEEDBACKs = db.FEEDBACKs.Include(f => f.DISCUSSION);
            return View(fEEDBACKs.ToList());
        }

        // GET: Feedbacks/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FEEDBACK fEEDBACK = db.FEEDBACKs.Find(id);
            if (fEEDBACK == null)
            {
                return HttpNotFound();
            }
            return View(fEEDBACK);
        }

        // GET: Feedbacks/Create
        public ActionResult Create()
        {
            ViewBag.Discussion_id = new SelectList(db.DISCUSSIONs, "ID", "Advertisement_Code");
            return View();
        }

        // POST: Feedbacks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Discussion_id,Details,Incorporated")] FEEDBACK fEEDBACK)
        {
            if (ModelState.IsValid)
            {
                db.FEEDBACKs.Add(fEEDBACK);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Discussion_id = new SelectList(db.DISCUSSIONs, "ID", "Advertisement_Code", fEEDBACK.Discussion_id);
            return View(fEEDBACK);
        }

        // GET: Feedbacks/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FEEDBACK fEEDBACK = db.FEEDBACKs.Find(id);
            if (fEEDBACK == null)
            {
                return HttpNotFound();
            }
            ViewBag.Discussion_id = new SelectList(db.DISCUSSIONs, "ID", "Advertisement_Code", fEEDBACK.Discussion_id);
            return View(fEEDBACK);
        }

        // POST: Feedbacks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Discussion_id,Details,Incorporated")] FEEDBACK fEEDBACK)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fEEDBACK).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Discussion_id = new SelectList(db.DISCUSSIONs, "ID", "Advertisement_Code", fEEDBACK.Discussion_id);
            return View(fEEDBACK);
        }

        // GET: Feedbacks/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FEEDBACK fEEDBACK = db.FEEDBACKs.Find(id);
            if (fEEDBACK == null)
            {
                return HttpNotFound();
            }
            return View(fEEDBACK);
        }

        // POST: Feedbacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            FEEDBACK fEEDBACK = db.FEEDBACKs.Find(id);
            db.FEEDBACKs.Remove(fEEDBACK);
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
