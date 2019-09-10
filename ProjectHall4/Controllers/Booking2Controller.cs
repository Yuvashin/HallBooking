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
    public class Booking2Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Booking2
        public ActionResult Index()
        {
            var booking2s = db.Booking2s.Include(b => b.Venue);
            return View(booking2s.ToList());
        }

        // GET: Booking2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking2 booking2 = db.Booking2s.Find(id);
            if (booking2 == null)
            {
                return HttpNotFound();
            }
            return View(booking2);
        }

        // GET: Booking2/Create
        public ActionResult Create()
        {
            ViewBag.VenueID = new SelectList(db.Venues, "VenueID", "VenueName");
            return View();
        }

        // POST: Booking2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Booking2ID,VenueID,Date,TotalNumberOfGuests,OccasionType,baseVenuePrice")] Booking2 booking2)
        {
            if (ModelState.IsValid)
            {
                //add validation for calender
                booking2.baseVenuePrice = booking2.calcVenue();
                db.Booking2s.Add(booking2);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.VenueID = new SelectList(db.Venues, "VenueID", "VenueName", booking2.VenueID);
            return View(booking2);
        }

        // GET: Booking2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking2 booking2 = db.Booking2s.Find(id);
            if (booking2 == null)
            {
                return HttpNotFound();
            }
            ViewBag.VenueID = new SelectList(db.Venues, "VenueID", "VenueName", booking2.VenueID);
            return View(booking2);
        }

        // POST: Booking2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Booking2ID,VenueID,Date,TotalNumberOfGuests,OccasionType,baseVenuePrice")] Booking2 booking2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booking2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VenueID = new SelectList(db.Venues, "VenueID", "VenueName", booking2.VenueID);
            return View(booking2);
        }

        // GET: Booking2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking2 booking2 = db.Booking2s.Find(id);
            if (booking2 == null)
            {
                return HttpNotFound();
            }
            return View(booking2);
        }

        // POST: Booking2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Booking2 booking2 = db.Booking2s.Find(id);
            db.Booking2s.Remove(booking2);
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
