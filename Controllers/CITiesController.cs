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
    public class CITiesController : Controller
    {
        private AdvtManagementEntities db = new AdvtManagementEntities();

        // GET: CITies
        public ActionResult Index()
        {
            var cITies = db.CITies.Include(c => c.STATE);
            return View(cITies.ToList());
        }

        // GET: CITies/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CITY cITY = db.CITies.Find(id);
            if (cITY == null)
            {
                return HttpNotFound();
            }
            return View(cITY);
        }

        // GET: CITies/Create
        public ActionResult Create()
        {
            ViewBag.State_Code = new SelectList(db.STATEs, "Code", "Name");
            return View();
        }

        // POST: CITies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Code,Name,State_Code")] CITY cITY)
        {
            if (ModelState.IsValid)
            {
                db.CITies.Add(cITY);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.State_Code = new SelectList(db.STATEs, "Code", "Name", cITY.State_Code);
            return View(cITY);
        }

        // GET: CITies/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CITY cITY = db.CITies.Find(id);
            if (cITY == null)
            {
                return HttpNotFound();
            }
            ViewBag.State_Code = new SelectList(db.STATEs, "Code", "Name", cITY.State_Code);
            return View(cITY);
        }

        // POST: CITies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Code,Name,State_Code")] CITY cITY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cITY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.State_Code = new SelectList(db.STATEs, "Code", "Name", cITY.State_Code);
            return View(cITY);
        }

        // GET: CITies/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CITY cITY = db.CITies.Find(id);
            if (cITY == null)
            {
                return HttpNotFound();
            }
            return View(cITY);
        }

        // POST: CITies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CITY cITY = db.CITies.Find(id);
            db.CITies.Remove(cITY);
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
