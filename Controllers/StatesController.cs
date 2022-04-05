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
    public class StatesController : Controller
    {
        private AdvtManagementEntities db = new AdvtManagementEntities();

        // GET: States
        public ActionResult Index()
        {
            var sTATEs = db.STATEs.Include(s => s.COUNTRY);
            return View(sTATEs.ToList());
        }

        // GET: States/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STATE sTATE = db.STATEs.Find(id);
            if (sTATE == null)
            {
                return HttpNotFound();
            }
            return View(sTATE);
        }

        // GET: States/Create
        public ActionResult Create()
        {
            ViewBag.Country_Code = new SelectList(db.COUNTRies, "Code", "Name");
            return View();
        }

        // POST: States/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Code,Name,Country_Code")] STATE sTATE)
        {
            if (ModelState.IsValid)
            {
                db.STATEs.Add(sTATE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Country_Code = new SelectList(db.COUNTRies, "Code", "Name", sTATE.Country_Code);
            return View(sTATE);
        }

        // GET: States/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STATE sTATE = db.STATEs.Find(id);
            if (sTATE == null)
            {
                return HttpNotFound();
            }
            ViewBag.Country_Code = new SelectList(db.COUNTRies, "Code", "Name", sTATE.Country_Code);
            return View(sTATE);
        }

        // POST: States/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Code,Name,Country_Code")] STATE sTATE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sTATE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Country_Code = new SelectList(db.COUNTRies, "Code", "Name", sTATE.Country_Code);
            return View(sTATE);
        }

        // GET: States/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STATE sTATE = db.STATEs.Find(id);
            if (sTATE == null)
            {
                return HttpNotFound();
            }
            return View(sTATE);
        }

        // POST: States/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            STATE sTATE = db.STATEs.Find(id);
            db.STATEs.Remove(sTATE);
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
