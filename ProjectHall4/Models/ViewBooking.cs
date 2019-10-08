using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectHall4.Models
{
    public class ViewBooking
    {
        public int id { get; set; }
        public DateTime date { get; set; }
        public string VenueName { get; set; }
        public int Capacity { get; set; }
        public decimal VenueCost { get; set; }
        public string eventType { get; set; }
        public  string CateringType { get; set; }
        public  decimal cateringCost { get; set; }
        public string DecorType { get; set; }
        public decimal decorCost { get; set; }
        public decimal totalCost { get; set; }
        public bool Status { get; set; }
    }
}