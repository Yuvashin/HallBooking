﻿using System;
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
    public class ChildrenController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Children
        public ActionResult Index()
        {
            return View(db.Children.ToList());
        }

        // GET: Children/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Children children = db.Children.Find(id);
            if (children == null)
            {
                return HttpNotFound();
            }
            return View(children);
        }

        // GET: Children/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Children/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ChildrenID,ChildrenFood,ChildrenFoodPrice")] Children children)
        {
            if (ModelState.IsValid)
            {
                db.Children.Add(children);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(children);
        }

        // GET: Children/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Children children = db.Children.Find(id);
            if (children == null)
            {
                return HttpNotFound();
            }
            return View(children);
        }

        // POST: Children/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ChildrenID,ChildrenFood,ChildrenFoodPrice")] Children children)
        {
            if (ModelState.IsValid)
            {
                db.Entry(children).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(children);
        }

        // GET: Children/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Children children = db.Children.Find(id);
            if (children == null)
            {
                return HttpNotFound();
            }
            return View(children);
        }

        // POST: Children/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Children children = db.Children.Find(id);
            db.Children.Remove(children);
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