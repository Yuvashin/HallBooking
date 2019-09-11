using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectHall4.Models
{
    public class TotalPrices2
    {
        [Key]
        public int TotalPrices2ID { get; set; }

        
        
        public int UserDecorID { get; set; }
        public virtual UserDecor UserDecor { get; set; }


       
        public int VenueID { get; set; }
        public virtual Venue Venue { get; set; }

        /*   public decimal TotalBookingPrice { get; set; }

           public decimal TotalVenuePrice { get; set; }

           public decimal TotalDecorPrice { get; set; }

           public decimal TotalCateringPrice { get; set; }*/

        private ApplicationDbContext db = new ApplicationDbContext();
        public decimal VenuePrice()
        {
            var venue = (from ac in db.Venues
                         where ac.VenueID == VenueID
                         select ac.VenuePrice).Single();
            return Convert.ToDecimal(venue);
        }
        public decimal DecorPrice()
        {
            var decor = (from ac in db.UserDecors
                         where ac.UserDecorID == UserDecorID
                         select ac.DecorCost).Single();
            return Convert.ToDecimal(decor);
        }
      
        public decimal totalPrice()
        {
            decimal total = 0;
            total = VenuePrice() + DecorPrice(); 
            return Convert.ToDecimal(total);
        }

    }
}