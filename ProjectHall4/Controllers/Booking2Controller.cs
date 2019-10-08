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
    [Authorize]
    public class Booking2Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Booking2
        public ActionResult Index()
        {
            var booking2s = db.Booking2.Include(b => b.Venue);
            return View(booking2s.ToList());
        }

        public ActionResult Venue()
        {
            return View(db.Venues.ToList());
        }

        // GET: Booking2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking2 booking2 = db.Booking2.Find(id);
            if (booking2 == null)
            {
                return HttpNotFound();
            }
            return View(booking2);
        }

       
        // GET: Booking2/Create
        public ActionResult Create(int id)
        {
            ViewBag.VenueID = new SelectList(db.Venues.Where(x=>x.VenueID==id), "VenueID", "VenueName");
            return View();
        }

        // POST: Booking2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Booking2ID,VenueID,Date,TotalNumberOfGuests,OccasionType")] Booking2 booking2,BookingStatus booking)
        {
            if (ModelState.IsValid)
            {
                if (booking.StageCheck(1, User.Identity.Name))
                {
                    ModelState.AddModelError("", @"You have already Completed this stage for your active booking.");
                    ViewBag.VenueID = new SelectList(db.Venues, "VenueID", "VenueName", booking2.VenueID);
                    return View(booking2);
                }
                if(!booking2.getDate(booking2.Date))
                {
                   // booking2.Email = User.Identity.Name;
                    booking2.BookingStatusId = booking.getBookingStatusId(User.Identity.Name);
                    booking.editStage(User.Identity.Name,1);
                    db.Booking2.Add(booking2);
                    db.SaveChanges();
                    return RedirectToAction("Decor","UserDecors");
                }
                ModelState.AddModelError("", "Date is already taken.");
                ViewBag.VenueID = new SelectList(db.Venues, "VenueID", "VenueName", booking2.VenueID);
                return View(booking2);
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
            Booking2 booking2 = db.Booking2.Find(id);
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
        public ActionResult Edit([Bind(Include = "Booking2ID,VenueID,Date,TotalNumberOfGuests,OccasionType")] Booking2 booking2)
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
            Booking2 booking2 = db.Booking2.Find(id);
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
            Booking2 booking2 = db.Booking2.Find(id);
            db.Booking2.Remove(booking2);
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
