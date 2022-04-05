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
    public class CompaniesController : Controller
    {
        private AdvtManagementEntities db = new AdvtManagementEntities();

        // GET: Companies
        public ActionResult Index()
        {
            var cOMPANies = db.COMPANies.Include(c => c.CITY).Include(c => c.EMPLOYEE);
            return View(cOMPANies.ToList());
        }

        // GET: Companies/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMPANY cOMPANY = db.COMPANies.Find(id);
            if (cOMPANY == null)
            {
                return HttpNotFound();
            }
            return View(cOMPANY);
        }

        // GET: Companies/Create
        public ActionResult Create()
        {
            ViewBag.City_code = new SelectList(db.CITies, "Code", "Name");
            ViewBag.Head_Code = new SelectList(db.EMPLOYEEs, "Code", "Name");
            return View();
        }

        // POST: Companies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Code,Name,Address,City_code,Head_Code")] COMPANY cOMPANY)
        {
            if (ModelState.IsValid)
            {
                db.COMPANies.Add(cOMPANY);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.City_code = new SelectList(db.CITies, "Code", "Name", cOMPANY.City_code);
            ViewBag.Head_Code = new SelectList(db.EMPLOYEEs, "Code", "Name", cOMPANY.Head_Code);
            return View(cOMPANY);
        }

        // GET: Companies/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMPANY cOMPANY = db.COMPANies.Find(id);
            if (cOMPANY == null)
            {
                return HttpNotFound();
            }
            ViewBag.City_code = new SelectList(db.CITies, "Code", "Name", cOMPANY.City_code);
            ViewBag.Head_Code = new SelectList(db.EMPLOYEEs, "Code", "Name", cOMPANY.Head_Code);
            return View(cOMPANY);
        }

        // POST: Companies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Code,Name,Address,City_code,Head_Code")] COMPANY cOMPANY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cOMPANY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.City_code = new SelectList(db.CITies, "Code", "Name", cOMPANY.City_code);
            ViewBag.Head_Code = new SelectList(db.EMPLOYEEs, "Code", "Name", cOMPANY.Head_Code);
            return View(cOMPANY);
        }

        // GET: Companies/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMPANY cOMPANY = db.COMPANies.Find(id);
            if (cOMPANY == null)
            {
                return HttpNotFound();
            }
            return View(cOMPANY);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            COMPANY cOMPANY = db.COMPANies.Find(id);
            db.COMPANies.Remove(cOMPANY);
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
