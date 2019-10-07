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
    public class CatersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Caters
        public ActionResult Index()
        {
            return View(db.Caters.ToList());
        }

        // GET: Caters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cater cater = db.Caters.Find(id);
            if (cater == null)
            {
                return HttpNotFound();
            }
            return View(cater);
        }

        // GET: Caters/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Caters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CateringID,CateringPackage,CateringPrice")] Cater cater)
        {
            if (ModelState.IsValid)
            {
                db.Caters.Add(cater);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cater);
        }

        // GET: Caters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cater cater = db.Caters.Find(id);
            if (cater == null)
            {
                return HttpNotFound();
            }
            return View(cater);
        }

        // POST: Caters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CateringID,CateringPackage,CateringPrice")] Cater cater)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cater).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cater);
        }

        // GET: Caters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cater cater = db.Caters.Find(id);
            if (cater == null)
            {
                return HttpNotFound();
            }
            return View(cater);
        }

        // POST: Caters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cater cater = db.Caters.Find(id);
            db.Caters.Remove(cater);
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
