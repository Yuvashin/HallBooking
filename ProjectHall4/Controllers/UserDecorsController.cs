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
    public class UserDecorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: UserDecors
        public ActionResult Index()
        {
            var userDecors = db.UserDecors;
            return View(userDecors.ToList());
        }
        public ActionResult Decor()
        {
            var userDecors = db.Decors;
            return View(userDecors.ToList());
        }

        // GET: UserDecors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDecor userDecor = db.UserDecors.Find(id);
            if (userDecor == null)
            {
                return HttpNotFound();
            }
            return View(userDecor);
        }

        public ActionResult CreateDecor(int id,BookingStatus bookings,UserDecor userDecor)
        {
            if (bookings.StageCheck(2, User.Identity.Name))
            {
                TempData["Status"] = "You have already Completed this stage for your active booking.";
                return RedirectToAction("Decor");
            }

            userDecor.DecorID = id;
            userDecor.BookingStatusId = bookings.getBookingStatusId(User.Identity.Name);
            bookings.editStage(User.Identity.Name,2);
            db.UserDecors.Add(userDecor);
            db.SaveChanges();
            return RedirectToAction("Catering","UserCaterings");
        }
        // GET: UserDecors/Create
        public ActionResult Create()
        {
            //ViewBag.Booking2ID = new SelectList(db.Booking2, "Booking2ID", "OccasionType");
            ViewBag.DecorID = new SelectList(db.Decors, "DecorID", "DecorColourOne");
            return View();
        }

        // POST: UserDecors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserDecorId,Email,DecorID")] UserDecor userDecor,int id)
        {
            if (ModelState.IsValid)
            {
                userDecor.DecorID = id;
               // userDecor.Email = User.Identity.Name;
                db.UserDecors.Add(userDecor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

           // ViewBag.Booking2ID = new SelectList(db.Booking2, "Booking2ID", "OccasionType", userDecor.Booking2ID);
            ViewBag.DecorID = new SelectList(db.Decors, "DecorID", "DecorColourOne", userDecor.DecorID);
            return View(userDecor);
        }

        // GET: UserDecors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDecor userDecor = db.UserDecors.Find(id);
            if (userDecor == null)
            {
                return HttpNotFound();
            }
           // ViewBag.Booking2ID = new SelectList(db.Booking2, "Booking2ID", "OccasionType", userDecor.Booking2ID);
            ViewBag.DecorID = new SelectList(db.Decors, "DecorID", "DecorColourOne", userDecor.DecorID);
            return View(userDecor);
        }

        // POST: UserDecors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Email,DecorID")] UserDecor userDecor)
        {
            if (ModelState.IsValid)
            {
             //   userDecor.Email = User.Identity.Name;
                db.Entry(userDecor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           // ViewBag.Booking2ID = new SelectList(db.Booking2, "Booking2ID", "OccasionType", userDecor.Booking2ID);
            ViewBag.DecorID = new SelectList(db.Decors, "DecorID", "DecorColourOne", userDecor.DecorID);
            return View(userDecor);
        }

        // GET: UserDecors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDecor userDecor = db.UserDecors.Find(id);
            if (userDecor == null)
            {
                return HttpNotFound();
            }
            return View(userDecor);
        }

        // POST: UserDecors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserDecor userDecor = db.UserDecors.Find(id);
            db.UserDecors.Remove(userDecor);
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
