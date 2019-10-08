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
    public class UserCateringsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: UserCaterings
        public ActionResult Index()
        {
            var userCaterings = db.UserCaterings;
            return View(userCaterings.ToList());
        }

        public ActionResult backto()
        {
            return RedirectToAction("Index", "BookingStatus");
        }
        public ActionResult ConfirmBooking(Payments pay,BookingStatus booking)
        {
            if (pay.PaymentCheck(User.Identity.Name))
            {
                booking.editStage(User.Identity.Name, 4);
                booking.editStage(User.Identity.Name, 5);
                return RedirectToAction("Payment");
            }
            return RedirectToAction("Payment");
        }
        public ActionResult Payment()
        {

            return View(db.Payments.ToList().Where(x=>x.BookingStatus.Email==User.Identity.Name));
        }
        public ActionResult Catering()
        {
            var userCaterings = db.Caters;
            return View(userCaterings.ToList());
        }
        public ActionResult CreateCater(int id, UserCatering userCater,BookingStatus booking,Payments payments)
        {
            if (booking.StageCheck(3, User.Identity.Name))
            {
                TempData["Status"] = "You have already Completed this stage for your active booking.";
                return RedirectToAction("Catering");
            }
           // var userDecor = new UserCatering { CateringID = id, BookingStatusId = 1 };//change 1
           userCater.CateringID = id;
           userCater.BookingStatusId = booking.getBookingStatusId(User.Identity.Name);
           booking.editStage(User.Identity.Name,3);
           if(payments.PaymentCheck(User.Identity.Name))payments.AddPayment(booking.getBookingStatusId(User.Identity.Name));
            db.UserCaterings.Add(userCater);
            db.SaveChanges();
            return RedirectToAction("Payment");
        }
        // GET: UserCaterings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserCatering userCatering = db.UserCaterings.Find(id);
            if (userCatering == null)
            {
                return HttpNotFound();
            }
            return View(userCatering);
        }

        // GET: UserCaterings/Create
        public ActionResult Create()
        {
          //  ViewBag.Booking2ID = new SelectList(db.Booking2, "Booking2ID", "OccasionType");
            ViewBag.CateringID = new SelectList(db.Caters, "CateringID", "CateringPackage");
            return View();
        }

        // POST: UserCaterings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserCateringId,BookingStatusId,CateringID,")] UserCatering userCatering)
        {
            if (ModelState.IsValid)
            {
                
               // userCatering.CateringNumberGuest = userCatering.GetNumbOfGuests();
               // userCatering.CateringCost = userCatering.GetCateringPrice();
                db.UserCaterings.Add(userCatering);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

           // ViewBag.Booking2ID = new SelectList(db.Booking2, "Booking2ID", "OccasionType", userCatering.Booking2ID);
            ViewBag.CateringID = new SelectList(db.Caters, "CateringID", "CateringPackage", userCatering.CateringID);
            return View(userCatering);
        }

        // GET: UserCaterings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserCatering userCatering = db.UserCaterings.Find(id);
            if (userCatering == null)
            {
                return HttpNotFound();
            }
            //ViewBag.Booking2ID = new SelectList(db.Booking2, "Booking2ID", "OccasionType", userCatering.Booking2ID);
           ViewBag.CateringID = new SelectList(db.Caters, "CateringID", "CateringPackage", userCatering.CateringID);
            return View(userCatering);
        }

        // POST: UserCaterings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ExternalLoginConfirmationViewModel,Email,CateringID,Booking2ID,CateringCost,CateringNumberGuest")] UserCatering userCatering)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userCatering).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           // ViewBag.Booking2ID = new SelectList(db.Booking2, "Booking2ID", "OccasionType", userCatering.Booking2ID);
              ViewBag.CateringID = new SelectList(db.Caters, "CateringID", "CateringPackage", userCatering.CateringID);
            return View(userCatering);
        }

        // GET: UserCaterings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserCatering userCatering = db.UserCaterings.Find(id);
            if (userCatering == null)
            {
                return HttpNotFound();
            }
            return View(userCatering);
        }

        // POST: UserCaterings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserCatering userCatering = db.UserCaterings.Find(id);
            db.UserCaterings.Remove(userCatering);
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
