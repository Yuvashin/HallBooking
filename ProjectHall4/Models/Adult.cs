using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectHall4.Models
{
    public class Adult
    {
        [Key]
        public int AdultID { get; set; }

        [Required(ErrorMessage = "Enter Catering type")]
        [DisplayName(" Catering Adult Options ")]
        public string CateringType { get; set; }

        [Required(ErrorMessage = "Enter Catering Price")]
        [DisplayName(" Catering Price ")]
        public decimal CateringPrice { get; set; }
    }
}