using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CandyBug.Models;

namespace CandyBug.Areas.Admin.Controllers
{
    public class QLHDController : Controller
    {
        private CandybugOnlineEntities db = new CandybugOnlineEntities();

        // GET: Admin/QLDH
        public ActionResult Index()
        {
            var oders = db.Oders.Include(o => o.Account);
            return View(oders.ToList());
        }

        // GET: Admin/QLDH/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oder oder = db.Oders.Find(id);
            if (oder == null)
            {
                return HttpNotFound();
            }
            return View(oder);
        }

        // GET: Admin/QLDH/Create
        public ActionResult Create()
        {
            ViewBag.IdAcc = new SelectList(db.Accounts, "Id", "UserName");
            return View();
        }

        // POST: Admin/QLDH/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdAcc,DateCreate,Status,Address,DeliveryDate,SDT")] Oder oder)
        {
            if (ModelState.IsValid)
            {
                db.Oders.Add(oder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdAcc = new SelectList(db.Accounts, "Id", "UserName", oder.IdAcc);
            return View(oder);
        }

        // GET: Admin/QLDH/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oder oder = db.Oders.Find(id);
            if (oder == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdAcc = new SelectList(db.Accounts, "Id", "UserName", oder.IdAcc);
            return View(oder);
        }

        // POST: Admin/QLDH/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdAcc,DateCreate,Status,Address,DeliveryDate,SDT")] Oder oder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdAcc = new SelectList(db.Accounts, "Id", "UserName", oder.IdAcc);
            return View(oder);
        }

        // GET: Admin/QLDH/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oder oder = db.Oders.Find(id);
            if (oder == null)
            {
                return HttpNotFound();
            }
            return View(oder);
        }

        // POST: Admin/QLDH/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Oder oder = db.Oders.Find(id);
            db.Oders.Remove(oder);
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
