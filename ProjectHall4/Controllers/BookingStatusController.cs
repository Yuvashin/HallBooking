using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectHall4.Migrations;
using ProjectHall4.Models;

namespace ProjectHall4.Controllers
{
    [Authorize]
    public class BookingStatusController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BookingStatus
        public ActionResult Index()
        {
            return View(db.BookingStatus.ToList().Where(x=>x.Email==User.Identity.Name));
        }

        public ActionResult ViewBookings(int id)
        {
            if(id==null)return  new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            List<ViewBooking>vm= new List<ViewBooking>();
            var list = (from a in db.Booking2
                join b in db.UserCaterings on a.BookingStatusId equals b.BookingStatusId
                join c in db.UserDecors on b.BookingStatusId equals c.BookingStatusId
                join d in db.Payments on c.BookingStatusId equals d.BookingStatusId
                join e in db.BookingStatus on d.BookingStatusId equals e.BookingStatusId
                where a.BookingStatusId == id
                select new
                {
                    a.Venue.VenueName,a.Date,a.TotalNumberOfGuests,a.OccasionType,b.Catering.CateringPackage,b.Catering.CateringPrice
                    ,c.Decor.DecorColourOne,c.Decor.DecorPrice,d.TotalCost,e.Status,a.Venue.VenuePrice
                }).ToList();

            foreach (var item in list)
            {
                ViewBooking vnm = new ViewBooking()
                {
                    date = item.Date,
                    VenueName = item.VenueName,
                    VenueCost = item.VenuePrice,
                    Capacity = item.TotalNumberOfGuests,
                    eventType = item.OccasionType,
                    CateringType = item.CateringPackage,
                    cateringCost = item.CateringPrice*item.TotalNumberOfGuests,
                    DecorType = item.DecorColourOne,
                    decorCost = item.DecorPrice*item.TotalNumberOfGuests,
                    totalCost = item.TotalCost,
                    Status = item.Status

                };
                vm.Add(vnm);
            
            }

            return View(vm);
        }

        public ActionResult Step1()
        {
            return RedirectToAction("Venue", "Booking2");
        }
        public ActionResult Step2()
        {
            return RedirectToAction("Decor", "UserDecors");
        }
        public ActionResult Step3()
        {
            return RedirectToAction("Catering", "UserCaterings");
        }

        // GET: BookingStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingStatus bookingStatus = db.BookingStatus.Find(id);
            if (bookingStatus == null)
            {
                return HttpNotFound();
            }
            return View(bookingStatus);
        }

        public ActionResult BookNow(BookingStatus booking)
        {
            if (booking.bookingCheck(User.Identity.Name))
            {
                AutoCreate();
                var last = db.BookingStatus.ToList();
                createRef(last.LastOrDefault().BookingStatusId);
                return RedirectToAction("Venue", "Booking2");
            }

            TempData["Status"] = "You can only have one active booking open at a time.";
           return View("Index",db.BookingStatus.ToList().Where(x=>x.Email==User.Identity.Name));
        }
        public void createRef(int id)
        {
            var booking = db.BookingStatus.Find(id);
            var data = booking.generateRefernceNumber(id, User.Identity.Name).ToString();
            if (data.Contains('-')) booking.ReferenceNumber = data.Remove('-');
            else booking.ReferenceNumber = data;
            db.Entry(booking).State = EntityState.Modified;
            db.SaveChanges();

        }
        public void AutoCreate()
        {
            var booking = new BookingStatus();
            var create = new BookingStatus()
            {
               // ReferenceNumber =( booking.generateRefernceNumber(booking.BookingStatusId,User.Identity.Name)).ToString(),
                Step1 = false,
                Step2 = false,
                Step3 = false,
                Step4 = false,
                Status = false,
                Email = User.Identity.Name
            };
         
            db.BookingStatus.Add(create);
            db.SaveChanges();
        }
        // GET: BookingStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookingStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Email,Step1,Step2,Step3,Step4,Status")] BookingStatus bookingStatus)
        {
            if (ModelState.IsValid)
            {
                db.BookingStatus.Add(bookingStatus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bookingStatus);
        }

        // GET: BookingStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingStatus bookingStatus = db.BookingStatus.Find(id);
            if (bookingStatus == null)
            {
                return HttpNotFound();
            }
            return View(bookingStatus);
        }

        // POST: BookingStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Email,Step1,Step2,Step3,Step4,Status")] BookingStatus bookingStatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookingStatus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bookingStatus);
        }

        // GET: BookingStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingStatus bookingStatus = db.BookingStatus.Find(id);
            if (bookingStatus == null)
            {
                return HttpNotFound();
            }
            return View(bookingStatus);
        }

        // POST: BookingStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookingStatus bookingStatus = db.BookingStatus.Find(id);
            db.BookingStatus.Remove(bookingStatus);
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
