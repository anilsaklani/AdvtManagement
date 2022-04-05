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
    public class CampaignsController : Controller
    {
        private AdvtManagementEntities db = new AdvtManagementEntities();

        // GET: Campaigns
        public ActionResult Index()
        {
            var cAMPAIGNs = db.CAMPAIGNs.Include(c => c.CAMPAIGN_STATUS_TYPE).Include(c => c.DEPARTMENT).Include(c => c.INVOICE).Include(c => c.REQUEST);
            return View(cAMPAIGNs.ToList());
        }

        // GET: Campaigns/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CAMPAIGN cAMPAIGN = db.CAMPAIGNs.Find(id);
            if (cAMPAIGN == null)
            {
                return HttpNotFound();
            }
            return View(cAMPAIGN);
        }

        // GET: Campaigns/Create
        public ActionResult Create()
        {
            ViewBag.Status = new SelectList(db.CAMPAIGN_STATUS_TYPE, "Code", "Description");
            ViewBag.Department_Code = new SelectList(db.DEPARTMENTs, "Code", "Name");
            ViewBag.Invoice_id = new SelectList(db.INVOICEs, "Id", "Id");
            ViewBag.Request_id = new SelectList(db.REQUESTs, "Id", "Description");
            return View();
        }

        // POST: Campaigns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Code,Request_id,Department_Code,Invoice_id,Status")] CAMPAIGN cAMPAIGN)
        {
            if (ModelState.IsValid)
            {
                db.CAMPAIGNs.Add(cAMPAIGN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Status = new SelectList(db.CAMPAIGN_STATUS_TYPE, "Code", "Description", cAMPAIGN.Status);
            ViewBag.Department_Code = new SelectList(db.DEPARTMENTs, "Code", "Name", cAMPAIGN.Department_Code);
            ViewBag.Invoice_id = new SelectList(db.INVOICEs, "Id", "Id", cAMPAIGN.Invoice_id);
            ViewBag.Request_id = new SelectList(db.REQUESTs, "Id", "Description", cAMPAIGN.Request_id);
            return View(cAMPAIGN);
        }

        // GET: Campaigns/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CAMPAIGN cAMPAIGN = db.CAMPAIGNs.Find(id);
            if (cAMPAIGN == null)
            {
                return HttpNotFound();
            }
            ViewBag.Status = new SelectList(db.CAMPAIGN_STATUS_TYPE, "Code", "Description", cAMPAIGN.Status);
            ViewBag.Department_Code = new SelectList(db.DEPARTMENTs, "Code", "Name", cAMPAIGN.Department_Code);
            ViewBag.Invoice_id = new SelectList(db.INVOICEs, "Id", "Id", cAMPAIGN.Invoice_id);
            ViewBag.Request_id = new SelectList(db.REQUESTs, "Id", "Description", cAMPAIGN.Request_id);
            return View(cAMPAIGN);
        }

        // POST: Campaigns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Code,Request_id,Department_Code,Invoice_id,Status")] CAMPAIGN cAMPAIGN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cAMPAIGN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Status = new SelectList(db.CAMPAIGN_STATUS_TYPE, "Code", "Description", cAMPAIGN.Status);
            ViewBag.Department_Code = new SelectList(db.DEPARTMENTs, "Code", "Name", cAMPAIGN.Department_Code);
            ViewBag.Invoice_id = new SelectList(db.INVOICEs, "Id", "Id", cAMPAIGN.Invoice_id);
            ViewBag.Request_id = new SelectList(db.REQUESTs, "Id", "Description", cAMPAIGN.Request_id);
            return View(cAMPAIGN);
        }

        // GET: Campaigns/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CAMPAIGN cAMPAIGN = db.CAMPAIGNs.Find(id);
            if (cAMPAIGN == null)
            {
                return HttpNotFound();
            }
            return View(cAMPAIGN);
        }

        // POST: Campaigns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CAMPAIGN cAMPAIGN = db.CAMPAIGNs.Find(id);
            db.CAMPAIGNs.Remove(cAMPAIGN);
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
