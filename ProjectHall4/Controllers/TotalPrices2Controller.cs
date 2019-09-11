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
    public class TotalPrices2Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TotalPrices2
        public ActionResult Index()
        {
            var totalPrices2s = db.TotalPrices2s.Include(t => t.UserDecor).Include(t => t.Venue);
            return View(totalPrices2s.ToList());
        }

        // GET: TotalPrices2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TotalPrices2 totalPrices2 = db.TotalPrices2s.Find(id);
            if (totalPrices2 == null)
            {
                return HttpNotFound();
            }
            return View(totalPrices2);
        }

        // GET: TotalPrices2/Create
        public ActionResult Create()
        {
            ViewBag.UserDecorID = new SelectList(db.UserDecors, "UserDecorID", "Email");
            ViewBag.VenueID = new SelectList(db.Venues, "VenueID", "VenueName");
            return View();
        }

        // POST: TotalPrices2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TotalPrices2ID,UserDecorID,VenueID")] TotalPrices2 totalPrices2)
        {
            if (ModelState.IsValid)
            {
                db.TotalPrices2s.Add(totalPrices2);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserDecorID = new SelectList(db.UserDecors, "UserDecorID", "Email", totalPrices2.UserDecorID);
            ViewBag.VenueID = new SelectList(db.Venues, "VenueID", "VenueName", totalPrices2.VenueID);
            return View(totalPrices2);
        }

        // GET: TotalPrices2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TotalPrices2 totalPrices2 = db.TotalPrices2s.Find(id);
            if (totalPrices2 == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserDecorID = new SelectList(db.UserDecors, "UserDecorID", "Email", totalPrices2.UserDecorID);
            ViewBag.VenueID = new SelectList(db.Venues, "VenueID", "VenueName", totalPrices2.VenueID);
            return View(totalPrices2);
        }

        // POST: TotalPrices2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TotalPrices2ID,UserDecorID,VenueID")] TotalPrices2 totalPrices2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(totalPrices2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserDecorID = new SelectList(db.UserDecors, "UserDecorID", "Email", totalPrices2.UserDecorID);
            ViewBag.VenueID = new SelectList(db.Venues, "VenueID", "VenueName", totalPrices2.VenueID);
            return View(totalPrices2);
        }

        // GET: TotalPrices2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TotalPrices2 totalPrices2 = db.TotalPrices2s.Find(id);
            if (totalPrices2 == null)
            {
                return HttpNotFound();
            }
            return View(totalPrices2);
        }

        // POST: TotalPrices2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TotalPrices2 totalPrices2 = db.TotalPrices2s.Find(id);
            db.TotalPrices2s.Remove(totalPrices2);
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
