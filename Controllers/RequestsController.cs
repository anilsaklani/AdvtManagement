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
    public class RequestsController : Controller
    {
        private AdvtManagementEntities db = new AdvtManagementEntities();

        // GET: Requests
        public ActionResult Index()
        {
            var rEQUESTs = db.REQUESTs.Include(r => r.AGE_TYPE).Include(r => r.COMPANY).Include(r => r.INDUSTRY_TYPE).Include(r => r.REGION_TYPE);
            return View(rEQUESTs.ToList());
        }

        // GET: Requests/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            REQUEST rEQUEST = db.REQUESTs.Find(id);
            if (rEQUEST == null)
            {
                return HttpNotFound();
            }
            return View(rEQUEST);
        }

        // GET: Requests/Create
        public ActionResult Create()
        {
            ViewBag.Age_code = new SelectList(db.AGE_TYPE, "Code", "Name");
            ViewBag.Company_Code = new SelectList(db.COMPANies, "Code", "Name");
            ViewBag.Industry_code = new SelectList(db.INDUSTRY_TYPE, "Code", "Description");
            ViewBag.Region_Code = new SelectList(db.REGION_TYPE, "Code", "Name");
            return View();
        }

        // POST: Requests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description,Industry_code,Start_Date,End_Date,Budget,Company_Code,Age_code,Region_Code")] REQUEST rEQUEST)
        {
            if (ModelState.IsValid)
            {
                db.REQUESTs.Add(rEQUEST);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Age_code = new SelectList(db.AGE_TYPE, "Code", "Name", rEQUEST.Age_code);
            ViewBag.Company_Code = new SelectList(db.COMPANies, "Code", "Name", rEQUEST.Company_Code);
            ViewBag.Industry_code = new SelectList(db.INDUSTRY_TYPE, "Code", "Description", rEQUEST.Industry_code);
            ViewBag.Region_Code = new SelectList(db.REGION_TYPE, "Code", "Name", rEQUEST.Region_Code);
            return View(rEQUEST);
        }

        // GET: Requests/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            REQUEST rEQUEST = db.REQUESTs.Find(id);
            if (rEQUEST == null)
            {
                return HttpNotFound();
            }
            ViewBag.Age_code = new SelectList(db.AGE_TYPE, "Code", "Name", rEQUEST.Age_code);
            ViewBag.Company_Code = new SelectList(db.COMPANies, "Code", "Name", rEQUEST.Company_Code);
            ViewBag.Industry_code = new SelectList(db.INDUSTRY_TYPE, "Code", "Description", rEQUEST.Industry_code);
            ViewBag.Region_Code = new SelectList(db.REGION_TYPE, "Code", "Name", rEQUEST.Region_Code);
            return View(rEQUEST);
        }

        // POST: Requests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description,Industry_code,Start_Date,End_Date,Budget,Company_Code,Age_code,Region_Code")] REQUEST rEQUEST)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rEQUEST).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Age_code = new SelectList(db.AGE_TYPE, "Code", "Name", rEQUEST.Age_code);
            ViewBag.Company_Code = new SelectList(db.COMPANies, "Code", "Name", rEQUEST.Company_Code);
            ViewBag.Industry_code = new SelectList(db.INDUSTRY_TYPE, "Code", "Description", rEQUEST.Industry_code);
            ViewBag.Region_Code = new SelectList(db.REGION_TYPE, "Code", "Name", rEQUEST.Region_Code);
            return View(rEQUEST);
        }

        // GET: Requests/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            REQUEST rEQUEST = db.REQUESTs.Find(id);
            if (rEQUEST == null)
            {
                return HttpNotFound();
            }
            return View(rEQUEST);
        }

        // POST: Requests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            REQUEST rEQUEST = db.REQUESTs.Find(id);
            db.REQUESTs.Remove(rEQUEST);
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
