using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectHall4.Models
{
    public class Children
    {
        [Key]
        public int ChildrenID { get; set; }

        [Required(ErrorMessage = "Enter Children Food Option")]
        [DisplayName("Children Food Type")]
        public string ChildrenFood { get; set; }

        [Required(ErrorMessage = "Enter Children Food Price")]
        [DisplayName("Children Food Price")]
        public decimal ChildrenFoodPrice { get; set; }
    }
}