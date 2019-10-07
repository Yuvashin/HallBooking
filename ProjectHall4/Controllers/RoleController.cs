using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;
using ProjectHall4.Models;

namespace ProjectHall4.Controllers
{
 
    [Authorize(Roles ="Admin")]// change role to Admin
    public class RoleController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Role
       // [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var role = db.Roles.ToList();
            return View(role);
        }

        public ActionResult Create()
        {
            var role = new IdentityRole();
            return View(role);
        }

        [HttpPost]
       // [Authorize(Roles = "Admin")]
        public ActionResult Create(IdentityRole role)
        {
            db.Roles.Add(role);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}