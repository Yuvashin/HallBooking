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
        
        
        public int VenueID { get; set; }

        [Required(ErrorMessage = "Enter Venue Name")]//Error messages should be required 
        [DisplayName("Venue Name ")]
        public string VenueName { get; set; }

        [DisplayName("Max Capcity")]
        public int MaxCapity { get; set; }

        [Required(ErrorMessage = "Enter Venue  Venue Price")]
        [DisplayName(" Venue Price ")]
        public decimal VenuePrice { get; set; }
    }
}