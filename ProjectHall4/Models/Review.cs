using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectHall4.Models
{
    public class Review
    {
        //Add Date
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string EventReview { get; set; }
        [Required]
        [Range(0,5)]
        public  int Rating { get; set; }
}
}