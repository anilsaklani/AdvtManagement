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
    public class CountriesController : Controller
    {
        private AdvtManagementEntities db = new AdvtManagementEntities();

        // GET: Countries
        public ActionResult Index()
        {
            return View(db.COUNTRies.ToList());
        }

        // GET: Countries/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COUNTRY cOUNTRY = db.COUNTRies.Find(id);
            if (cOUNTRY == null)
            {
                return HttpNotFound();
            }
            return View(cOUNTRY);
        }

        // GET: Countries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Countries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Code,Name")] COUNTRY cOUNTRY)
        {
            if (ModelState.IsValid)
            {
                db.COUNTRies.Add(cOUNTRY);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cOUNTRY);
        }

        // GET: Countries/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COUNTRY cOUNTRY = db.COUNTRies.Find(id);
            if (cOUNTRY == null)
            {
                return HttpNotFound();
            }
            return View(cOUNTRY);
        }

        // POST: Countries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Code,Name")] COUNTRY cOUNTRY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cOUNTRY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cOUNTRY);
        }

        // GET: Countries/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COUNTRY cOUNTRY = db.COUNTRies.Find(id);
            if (cOUNTRY == null)
            {
                return HttpNotFound();
            }
            return View(cOUNTRY);
        }

        // POST: Countries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            COUNTRY cOUNTRY = db.COUNTRies.Find(id);
            db.COUNTRies.Remove(cOUNTRY);
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
