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
    public class DecorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Decors
        public ActionResult Index()
        {
            return View(db.Decors.ToList());
        }

        // GET: Decors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Decor decor = db.Decors.Find(id);
            if (decor == null)
            {
                return HttpNotFound();
            }
            return View(decor);
        }

        // GET: Decors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Decors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DecorID,DecorColourOne,DecorPrice")] Decor decor)
        {
            if (ModelState.IsValid)
            {
                db.Decors.Add(decor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(decor);
        }

        // GET: Decors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Decor decor = db.Decors.Find(id);
            if (decor == null)
            {
                return HttpNotFound();
            }
            return View(decor);
        }

        // POST: Decors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DecorID,DecorColourOne,DecorPrice")] Decor decor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(decor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(decor);
        }

        // GET: Decors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Decor decor = db.Decors.Find(id);
            if (decor == null)
            {
                return HttpNotFound();
            }
            return View(decor);
        }

        // POST: Decors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Decor decor = db.Decors.Find(id);
            db.Decors.Remove(decor);
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
