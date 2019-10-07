using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ProjectHall4.Models
{
    public class UserDecor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

       // public virtual ExternalLoginConfirmationViewModel ExternalLoginConfirmationViewModel { get; set; }
        public string Email { get; set; }
        
       
        public int DecorID { get; set; }
        public virtual Decor Decor { get; set; }

        
        public int Booking2ID { get; set; }
        public virtual Booking2 Booking2 { get; set; }

        public decimal DecorCost { get; set; }

        public int DecorNumberGuest { get; set; }




        private ApplicationDbContext db = new ApplicationDbContext();

        public int GetNumbOfGuests()
        {
            var numofguests = (from ac in db.Booking2
                               where ac.Booking2ID == Booking2ID
                              select ac.TotalNumberOfGuests).Single();
            return Convert.ToInt16(numofguests);
        }
        public decimal GetDecorPrice()
        {
            var decorprice = (from ac in db.Decors
                              where ac.DecorID == DecorID
                              select ac.DecorPrice).Single();
            return Convert.ToDecimal(decorprice * GetNumbOfGuests());
        }

        //public void edit()
        //{
        //    UserDecor decor = db.UserDecor.Find(id);
        //    decor = new UserDecor
        //    {
                
        //    };
        //}
    }
}