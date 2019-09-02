using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectHall4.Models
{
    public class AccountBusiness
    {
        private  ApplicationDbContext db = new ApplicationDbContext();

        public void AddAdminRole()
        {
            var role = new IdentityRole()
            {
                Name = "Admin"

            };
            db.Roles.Add(role);
            db.SaveChanges();
        }
    }
}