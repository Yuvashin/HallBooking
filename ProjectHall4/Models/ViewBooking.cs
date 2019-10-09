using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectHall4.Models
{
    public class ViewBooking
    {
        public int id { get; set; }
        [Display(Name ="Date")]
        public DateTime date { get; set; }
        [Display(Name = "Venue")]
        public string VenueName { get; set; }
        [Display(Name = "Capacity")]
        public int Capacity { get; set; }
        [Display(Name = "Venue Price")]
        public decimal VenueCost { get; set; }
        [Display(Name = "Occasion")]
        public string eventType { get; set; }
        [Display(Name = "Catering Package")]
        public string CateringType { get; set; }
        [Display(Name = "Catering Cost")]
        public decimal cateringCost { get; set; }
        [Display(Name = "Decor Package")]
        public string DecorType { get; set; }
        [Display(Name = "Decor Cost")]
        public decimal decorCost { get; set; }
        [Display(Name = "Total Cost")]
        public decimal totalCost { get; set; }
        [Display(Name = "Status")]
        public bool Status { get; set; }
    }
}