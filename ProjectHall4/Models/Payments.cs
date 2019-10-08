using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectHall4.Models
{
    public class Payments
    {
        public int PaymentsId { get; set; }
        public virtual BookingStatus BookingStatus { get; set; }
        public int BookingStatusId { get; set; }
        public decimal TotalCost { get; set; }

        private ApplicationDbContext db = new ApplicationDbContext();

        public void AddPayment(int id)
        {
            var pay=new Payments()
            {
                BookingStatusId = id,
                TotalCost = CalculateCost(id)
            };
            db.Payments.Add(pay);
            db.SaveChanges();
        }


        public bool PaymentCheck(string email)
        {
            var list = db.BookingStatus.ToList();
            foreach (var item in list)
            {
                if (item.Email == email && item.Step1 && item.Step2 && item.Step3) return true;
            }

            return false;
        }

        public decimal CalculateCost(int id)
        {
            return getVenueCost(id) + getDecorCost(id) + getCateringCost(id);
        }

        private decimal getVenueCost(int id)
        {
            var venuecost = db.Booking2.ToList();
            decimal cost = 0;
            foreach (var item in venuecost)
            {
                if (item.BookingStatusId == id)
                {
                    cost = item.Venue.VenuePrice;
                    break;
                }
            }

            return cost;
        }

        private int getNumberGuest(int id)
        {
            var venuecost = db.Booking2.ToList();
            foreach (var item in venuecost)
            {
                if (item.BookingStatusId == id)
                {
                    return item.TotalNumberOfGuests;

                }
            }

            return 0;
        }

        private decimal getDecorCost(int id)
        {
            var decor = db.UserDecors.ToList();
            decimal cost = 0;
            foreach (var item in decor)
            {
                if (item.BookingStatusId == id)
                {
                    cost = item.Decor.DecorPrice * getNumberGuest(id);
                }
            }

            return cost;
        }
        private decimal getCateringCost(int id)
        {
            var decor = db.UserCaterings.ToList();
            decimal cost = 0;
            foreach (var item in decor)
            {
                if (item.BookingStatusId == id)
                {
                    cost = item.Catering.CateringPrice * getNumberGuest(id);
                }
            }

            return cost;
        }
    }
}