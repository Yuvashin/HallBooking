using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace ProjectHall4.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<ProjectHall4.Models.FileUploadModel> fileUploadModel { get; set; }
       // public System.Data.Entity.DbSet<ProjectHall4.Models.Booking> Bookings { get; set; }

        //public System.Data.Entity.DbSet<ProjectHall4.Models.Adult> Adults { get; set; }

       // public System.Data.Entity.DbSet<ProjectHall4.Models.Children> Children { get; set; }

        public System.Data.Entity.DbSet<ProjectHall4.Models.Decor> Decors { get; set; }

        public System.Data.Entity.DbSet<ProjectHall4.Models.Venue> Venues { get; set; }

        public System.Data.Entity.DbSet<ProjectHall4.Models.Booking2> Booking2s { get; set; }

        public System.Data.Entity.DbSet<ProjectHall4.Models.UserDecor> UserDecors { get; set; }

        public System.Data.Entity.DbSet<ProjectHall4.Models.UserCatering> UserCaterings { get; set; }

      //  public System.Data.Entity.DbSet<ProjectHall4.Models.Catering> Caterings { get; set; }

        //public System.Data.Entity.DbSet<ProjectHall4.Models.TotalPrices> TotalPrices { get; set; }
       public System.Data.Entity.DbSet<ProjectHall4.Models.TotalPrices2> TotalPrices2s { get; set; }

        public System.Data.Entity.DbSet<ProjectHall4.Models.Test> Tests { get; set; }

        //public System.Data.Entity.DbSet<ProjectHall4.Models.Catering> Caterings { get; set; }

        public System.Data.Entity.DbSet<ProjectHall4.Models.Cater> Caters { get; set; }
    }
}