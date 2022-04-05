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
    public class DepartmentsController : Controller
    {
        private AdvtManagementEntities db = new AdvtManagementEntities();

        // GET: Departments
        public ActionResult Index()
        {
            var dEPARTMENTs = db.DEPARTMENTs.Include(d => d.COMPANY).Include(d => d.EMPLOYEE);
            return View(dEPARTMENTs.ToList());
        }

        // GET: Departments/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEPARTMENT dEPARTMENT = db.DEPARTMENTs.Find(id);
            if (dEPARTMENT == null)
            {
                return HttpNotFound();
            }
            return View(dEPARTMENT);
        }

        // GET: Departments/Create
        public ActionResult Create()
        {
            ViewBag.Company_Code = new SelectList(db.COMPANies, "Code", "Name");
            ViewBag.Head_Code = new SelectList(db.EMPLOYEEs, "Code", "Name");
            return View();
        }

        // POST: Departments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Code,Name,Company_Code,Head_Code")] DEPARTMENT dEPARTMENT)
        {
            if (ModelState.IsValid)
            {
                db.DEPARTMENTs.Add(dEPARTMENT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Company_Code = new SelectList(db.COMPANies, "Code", "Name", dEPARTMENT.Company_Code);
            ViewBag.Head_Code = new SelectList(db.EMPLOYEEs, "Code", "Name", dEPARTMENT.Head_Code);
            return View(dEPARTMENT);
        }

        // GET: Departments/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEPARTMENT dEPARTMENT = db.DEPARTMENTs.Find(id);
            if (dEPARTMENT == null)
            {
                return HttpNotFound();
            }
            ViewBag.Company_Code = new SelectList(db.COMPANies, "Code", "Name", dEPARTMENT.Company_Code);
            ViewBag.Head_Code = new SelectList(db.EMPLOYEEs, "Code", "Name", dEPARTMENT.Head_Code);
            return View(dEPARTMENT);
        }

        // POST: Departments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Code,Name,Company_Code,Head_Code")] DEPARTMENT dEPARTMENT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dEPARTMENT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Company_Code = new SelectList(db.COMPANies, "Code", "Name", dEPARTMENT.Company_Code);
            ViewBag.Head_Code = new SelectList(db.EMPLOYEEs, "Code", "Name", dEPARTMENT.Head_Code);
            return View(dEPARTMENT);
        }

        // GET: Departments/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEPARTMENT dEPARTMENT = db.DEPARTMENTs.Find(id);
            if (dEPARTMENT == null)
            {
                return HttpNotFound();
            }
            return View(dEPARTMENT);
        }

        // POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DEPARTMENT dEPARTMENT = db.DEPARTMENTs.Find(id);
            db.DEPARTMENTs.Remove(dEPARTMENT);
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
