using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectHall4.Models
{
    public class Booking2
    {
        [Key]
        public int Booking2ID { get; set; }

        public virtual Venue Venue { get; set; }
        public int VenueID { get; set; }

        [Required(ErrorMessage = "Please Enter a Date")]
        [Display(Name = "Date of Event")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Please Enter Number of Guests")]
        [DisplayName("Total Number of Guests")]
        public int TotalNumberOfGuests { get; set; }

        [DisplayName("Occasion")]
        public string OccasionType { get; set; }

        public decimal baseVenuePrice { get; set; }

        private ApplicationDbContext db = new ApplicationDbContext();

        public decimal calcVenue()
        {
            var venueprice = (from ac in db.Venues
                              where ac.VenueID == VenueID
                              select ac.VenuePrice).Single();
            return Convert.ToDecimal(venueprice);
        }

    }
}