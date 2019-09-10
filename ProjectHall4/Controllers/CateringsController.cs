using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectHall4.Models;

namespace ProjectHall4.Controllers
{
    public class CateringsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Caterings
        public ActionResult Index()
        {
            return View(db.Caterings.ToList());
        }

        // GET: Caterings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Catering catering = db.Caterings.Find(id);
            if (catering == null)
            {
                return HttpNotFound();
            }
            return View(catering);
        }

        // GET: Caterings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Caterings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CateringID,CateringPackage,CateringPrice")] Catering catering)
        {
            if (ModelState.IsValid)
            {
                db.Caterings.Add(catering);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(catering);
        }

        // GET: Caterings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Catering catering = db.Caterings.Find(id);
            if (catering == null)
            {
                return HttpNotFound();
            }
            return View(catering);
        }

        // POST: Caterings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CateringID,CateringPackage,CateringPrice")] Catering catering)
        {
            if (ModelState.IsValid)
            {
                db.Entry(catering).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(catering);
        }

        // GET: Caterings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Catering catering = db.Caterings.Find(id);
            if (catering == null)
            {
                return HttpNotFound();
            }
            return View(catering);
        }

        // POST: Caterings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Catering catering = db.Caterings.Find(id);
            db.Caterings.Remove(catering);
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
