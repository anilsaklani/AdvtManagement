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
    public class InvoicesController : Controller
    {
        private AdvtManagementEntities db = new AdvtManagementEntities();

        // GET: Invoices
        public ActionResult Index()
        {
            return View(db.INVOICEs.ToList());
        }

        // GET: Invoices/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INVOICE iNVOICE = db.INVOICEs.Find(id);
            if (iNVOICE == null)
            {
                return HttpNotFound();
            }
            return View(iNVOICE);
        }

        // GET: Invoices/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Invoices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date,Amount,PaidAmount,Status")] INVOICE iNVOICE)
        {
            if (ModelState.IsValid)
            {
                db.INVOICEs.Add(iNVOICE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(iNVOICE);
        }

        // GET: Invoices/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INVOICE iNVOICE = db.INVOICEs.Find(id);
            if (iNVOICE == null)
            {
                return HttpNotFound();
            }
            return View(iNVOICE);
        }

        // POST: Invoices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date,Amount,PaidAmount,Status")] INVOICE iNVOICE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iNVOICE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(iNVOICE);
        }

        // GET: Invoices/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INVOICE iNVOICE = db.INVOICEs.Find(id);
            if (iNVOICE == null)
            {
                return HttpNotFound();
            }
            return View(iNVOICE);
        }

        // POST: Invoices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            INVOICE iNVOICE = db.INVOICEs.Find(id);
            db.INVOICEs.Remove(iNVOICE);
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
