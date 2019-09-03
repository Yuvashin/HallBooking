using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectHall4.Models
{
    public class FileUploadVm
    {
        [Key]
        public int key { get; set; }
        [DisplayName("Select File to Upload")]
        public HttpPostedFileBase File { get; set; }
        [Display(Name = "File Name")]
        [Required]
        public string FileName { get; set; }
    }
}