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
    public class CustomersController : Controller
    {
        private AdvtManagementEntities db = new AdvtManagementEntities();

        // GET: Customers
        public ActionResult Index()
        {
            var cUSTOMERs = db.CUSTOMERs.Include(c => c.CITY).Include(c => c.INDUSTRY_TYPE);
            return View(cUSTOMERs.ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUSTOMER cUSTOMER = db.CUSTOMERs.Find(id);
            if (cUSTOMER == null)
            {
                return HttpNotFound();
            }
            return View(cUSTOMER);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            ViewBag.City_Code = new SelectList(db.CITies, "Code", "Name");
            ViewBag.Industry_Code = new SelectList(db.INDUSTRY_TYPE, "Code", "Description");
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Code,Name,City_Code,Industry_Code")] CUSTOMER cUSTOMER)
        {
            if (ModelState.IsValid)
            {
                db.CUSTOMERs.Add(cUSTOMER);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.City_Code = new SelectList(db.CITies, "Code", "Name", cUSTOMER.City_Code);
            ViewBag.Industry_Code = new SelectList(db.INDUSTRY_TYPE, "Code", "Description", cUSTOMER.Industry_Code);
            return View(cUSTOMER);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUSTOMER cUSTOMER = db.CUSTOMERs.Find(id);
            if (cUSTOMER == null)
            {
                return HttpNotFound();
            }
            ViewBag.City_Code = new SelectList(db.CITies, "Code", "Name", cUSTOMER.City_Code);
            ViewBag.Industry_Code = new SelectList(db.INDUSTRY_TYPE, "Code", "Description", cUSTOMER.Industry_Code);
            return View(cUSTOMER);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Code,Name,City_Code,Industry_Code")] CUSTOMER cUSTOMER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cUSTOMER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.City_Code = new SelectList(db.CITies, "Code", "Name", cUSTOMER.City_Code);
            ViewBag.Industry_Code = new SelectList(db.INDUSTRY_TYPE, "Code", "Description", cUSTOMER.Industry_Code);
            return View(cUSTOMER);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUSTOMER cUSTOMER = db.CUSTOMERs.Find(id);
            if (cUSTOMER == null)
            {
                return HttpNotFound();
            }
            return View(cUSTOMER);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CUSTOMER cUSTOMER = db.CUSTOMERs.Find(id);
            db.CUSTOMERs.Remove(cUSTOMER);
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
