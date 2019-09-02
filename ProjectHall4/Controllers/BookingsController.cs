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
    public class BookingsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Bookings
        public ActionResult Index()
        {
            var bookings = db.Bookings.Include(b => b.Adult).Include(b => b.Children).Include(b => b.Decor).Include(b => b.Venue);
            return View(bookings.ToList());
        }

        // GET: Bookings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // GET: Bookings/Create
        public ActionResult Create()
        {
            ViewBag.AdultID = new SelectList(db.Adults, "AdultID", "CateringType");
            ViewBag.ChildrenID = new SelectList(db.Children, "ChildrenID", "ChildrenFood");
            ViewBag.DecorID = new SelectList(db.Decors, "DecorID", "DecorColourOne");
            ViewBag.VenueID = new SelectList(db.Venues, "VenueID", "VenueName");
            return View();
        }
        public IEnumerable<SelectListItem> GetVenueDetails()
        {
            IEnumerable<SelectListItem> items = db.Venues.Select(c => new SelectListItem
            {
                Text = c.VenueName+c.MaxCapity
            });
            return items;
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookingID,Date,time,numbOfGuests,numbOfChildren,VenueID,cateringPackage,decorpackage,Total_Price,DecorID,AdultID,ChildrenID,Decor_Price,Catering_Price,ChildrenFood_Price,Venue_Price")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                booking.Catering_Price = booking.GetCateringPrice();
                booking.Decor_Price = booking.GetDecorPrice();
                booking.Venue_Price = booking.GetVenuePrice();
                booking.ChildrenFood_Price = booking.GetChildrenCateringPice();
                booking.Total_Price = booking.TotPrice();
                db.Bookings.Add(booking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AdultID = new SelectList(db.Adults, "AdultID", "CateringType", booking.AdultID);
            ViewBag.ChildrenID = new SelectList(db.Children, "ChildrenID", "ChildrenFood", booking.ChildrenID);
            ViewBag.DecorID = new SelectList(db.Decors, "DecorID", "DecorColourOne", booking.DecorID);
            ViewBag.VenueID = new SelectList(db.Venues, "VenueID", "VenueName", booking.VenueID);
            return View(booking);
        }

        // GET: Bookings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            ViewBag.AdultID = new SelectList(db.Adults, "AdultID", "CateringType", booking.AdultID);
            ViewBag.ChildrenID = new SelectList(db.Children, "ChildrenID", "ChildrenFood", booking.ChildrenID);
            ViewBag.DecorID = new SelectList(db.Decors, "DecorID", "DecorColourOne", booking.DecorID);
            ViewBag.VenueID = new SelectList(db.Venues, "VenueID", "VenueName", booking.VenueID);
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookingID,Date,time,numbOfGuests,numbOfChildren,VenueID,cateringPackage,decorpackage,Total_Price,DecorID,AdultID,ChildrenID,Decor_Price,Catering_Price,ChildrenFood_Price,Venue_Price")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AdultID = new SelectList(db.Adults, "AdultID", "CateringType", booking.AdultID);
            ViewBag.ChildrenID = new SelectList(db.Children, "ChildrenID", "ChildrenFood", booking.ChildrenID);
            ViewBag.DecorID = new SelectList(db.Decors, "DecorID", "DecorColourOne", booking.DecorID);
            ViewBag.VenueID = new SelectList(db.Venues, "VenueID", "VenueName", booking.VenueID);
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Booking booking = db.Bookings.Find(id);
            db.Bookings.Remove(booking);
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
