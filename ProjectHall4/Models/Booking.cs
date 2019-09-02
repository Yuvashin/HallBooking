using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProjectHall4.Models
{
    public class Booking
    {
        [Key]
        [Required(ErrorMessage = "Enter Booking ID")]

        public int BookingID { get; set; }

        [Required(ErrorMessage = "Please Enter a Date")]
        [Display(Name = "Date of Event")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Please Enter a Time")]
        [Display(Name = "Timeof Booking")]
        [DataType(DataType.Time)]
        public DateTime time { get; set; }


        [Required(ErrorMessage = "Enter Number of Guests")]
        [DisplayName("Number of Guests")]
        public int numbOfGuests { get; set; }

        [Required(ErrorMessage = "Enter Number of Children")]
        [DisplayName("Number of Children")]
        public int numbOfChildren { get; set; }

        [Required(ErrorMessage = "Select A Venue")]
        public virtual Venue Venue { get; set; }
        public int VenueID { get; set; }

        [DisplayName("Catering Package ")]
        public bool cateringPackage { get; set; }

        [DisplayName("Decor Packages")]
        public bool decorpackage { get; set; }

        public decimal Total_Price { get; set; }

        public virtual Decor Decor { get; set; }
        public int DecorID { get; set; }

        public virtual Adult Adult { get; set; }
        public int AdultID { get; set; }

        public virtual Children Children { get; set; }
        public int ChildrenID { get; set; }

        public decimal Decor_Price { get; set; }
        public decimal Catering_Price { get; set; }
        public decimal ChildrenFood_Price { get; set; }

        public decimal Venue_Price { get; set; }



       /* public decimal GetDecorPrice()
        {
            OurDbContext db = new OurDbContext();
            var decorprice = (from ac in db.decors
                              where ac.DecorID == DecorID
                              select ac.DecorPrice).Single();
            return Convert.ToDecimal(decorprice * numbOfGuests);
        }
        public decimal GetCateringPrice()
        {
            OurDbContext db = new OurDbContext();
            var cateringprice = (from ac in db.cateringAdults
                                 where ac.AdultID == AdultID
                                 select ac.CateringPrice).Single();
            return Convert.ToDecimal(cateringprice * numbOfGuests);
        }
        public decimal GetVenuePrice()
        {
            OurDbContext db = new OurDbContext();
            var venueprice = (from ac in db.venues
                              where ac.VenueID == VenueID
                              select ac.VenuePrice).Single();
            return Convert.ToDecimal(venueprice);
        }
        public decimal GetChildrenCateringPice()
        {
            OurDbContext db = new OurDbContext();
            var childrenCateringPrice = (from ac in db.cateringChildrens
                                         where ac.ChildrenID == ChildrenID
                                         select ac.ChildrenFoodPrice).Single();
            return Convert.ToDecimal(childrenCateringPrice * numbOfChildren);
        }
        public decimal TotPrice()
        {
            decimal total = 0;
            total = GetDecorPrice() + GetCateringPrice() + GetVenuePrice();
            return total;
        }*/
    }
}