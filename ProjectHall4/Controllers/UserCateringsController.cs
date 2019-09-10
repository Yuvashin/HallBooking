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
    public class UserCateringsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: UserCaterings
        public ActionResult Index()
        {
            var userCaterings = db.UserCaterings.Include(u => u.Booking2).Include(u => u.Catering);
            return View(userCaterings.ToList());
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
            ViewBag.Booking2ID = new SelectList(db.Booking2s, "Booking2ID", "OccasionType");
            ViewBag.CateringID = new SelectList(db.Caterings, "CateringID", "CateringPackage");
            return View();
        }

        // POST: UserCaterings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserCateringID,ExternalLoginConfirmationViewModel,Email,CateringID,Booking2ID,CateringCost,CateringNumberGuest")] UserCatering userCatering)
        {
            if (ModelState.IsValid)
            {
                userCatering.CateringNumberGuest = userCatering.GetNumbOfGuests();
                userCatering.CateringCost = userCatering.GetCateringPrice();
                db.UserCaterings.Add(userCatering);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Booking2ID = new SelectList(db.Booking2s, "Booking2ID", "OccasionType", userCatering.Booking2ID);
            ViewBag.CateringID = new SelectList(db.Caterings, "CateringID", "CateringPackage", userCatering.CateringID);
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
            ViewBag.Booking2ID = new SelectList(db.Booking2s, "Booking2ID", "OccasionType", userCatering.Booking2ID);
            ViewBag.CateringID = new SelectList(db.Caterings, "CateringID", "CateringPackage", userCatering.CateringID);
            return View(userCatering);
        }

        // POST: UserCaterings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserCateringID,ExternalLoginConfirmationViewModel,Email,CateringID,Booking2ID,CateringCost,CateringNumberGuest")] UserCatering userCatering)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userCatering).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Booking2ID = new SelectList(db.Booking2s, "Booking2ID", "OccasionType", userCatering.Booking2ID);
            ViewBag.CateringID = new SelectList(db.Caterings, "CateringID", "CateringPackage", userCatering.CateringID);
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
