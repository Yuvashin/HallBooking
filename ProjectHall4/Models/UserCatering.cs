using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectHall4.Models
{
    public class UserCatering
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //public virtual ExternalLoginConfirmationViewModel ExternalLoginConfirmationViewModel { get; set; }
        //public string Email { get; set; }

        public virtual  BookingStatus BookingStatus { get; set; }
        public  int BookingStatusId { get; set; }

        public virtual Cater Catering { get; set; }
        public int CateringID { get; set; }

       /* public virtual Booking2 Booking2 { get; set; }
        public int Booking2ID { get; set; }

        public decimal CateringCost { get; set; }
        public int CateringNumberGuest { get; set; }*/

        private ApplicationDbContext db = new ApplicationDbContext();

        /*public int GetNumbOfGuests()
        {
            var numofguests = (from ac in db.Booking2
                               where ac.Booking2ID == Booking2ID
                               select ac.TotalNumberOfGuests).Single();
            return Convert.ToInt16(numofguests);
        }*/
      /*  public decimal GetCateringPrice()
        {
            var cateringprice = (from ac in db.Caterings
                              where ac.CateringID== CateringID
                              select ac.CateringPrice).Single();
            return Convert.ToDecimal(cateringprice * GetNumbOfGuests());
        }*/
    }
}