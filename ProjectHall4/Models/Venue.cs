using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectHall4.Models
{
    public class Venue
    {
        [Key]
        [Required(ErrorMessage = "Enter Venue ID")]
        [DisplayName("Enter Venue ID ")]
        public int VenueID { get; set; }

        [Required(ErrorMessage = "Enter Venue Name")]
        [DisplayName("Enter Venue Venue Name ")]
        public string VenueName { get; set; }

        [Required(ErrorMessage = "Enter Venue  Venue Price")]
        [DisplayName(" Venue Price ")]
        public decimal VenuePrice { get; set; }
    }
}