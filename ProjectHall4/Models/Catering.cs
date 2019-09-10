using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ProjectHall4.Models
{
    public class Catering
    {
        [Key]
        public int CateringID { get; set; }

        [Required(ErrorMessage = "Select Catering Package")]
        [DisplayName("Catering Choice")]
        public string CateringPackage { get; set; }

        [Required(ErrorMessage = "Enter Catering Price")]
        [DisplayName(" Catering Price ")]
        public decimal CateringPrice { get; set; }
    }
}