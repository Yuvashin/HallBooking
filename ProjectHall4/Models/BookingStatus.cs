using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Configuration;
using System.Web;

namespace ProjectHall4.Models
{
    public class BookingStatus
    {
        public int BookingStatusId { get; set; }
        public string Email { get; set; }
        public bool Step1 { get; set; }
        public bool Step2 { get; set; }
        public bool Step3 { get; set; }
        public bool Step4 { get; set; }
        public bool Status { get; set; }


       private  ApplicationDbContext db= new ApplicationDbContext();

       public List<BookingStatus> list()
       {
            return db.BookingStatus.ToList();
            
       }
        public bool bookingCheck(string Email)
        {
            var check = list();
            foreach (var item in check)
            {
                if (item.Email==Email&&!item.Status) return false;
            }

            return true;
        }

        public bool StageCheck(int stage,string Email)
        {
            bool flag = false;
            foreach (var item in list())
            {
                if (item.Email == Email)
                {
                    switch (stage)
                    {
                        case 1:
                            flag = item.Step1;
                            break;
                        case 2:
                            flag = item.Step2;
                            break;
                        case 3:
                            flag = item.Step3;
                            break;
                        case 4:
                            flag = item.Step4;
                            break;
                    }
                }
               
            }

            return flag;
        }

        public int getBookingStatusId(string email)
        {
            foreach (var item in list())
            {
                if (item.Email == email && !item.Status) return item.BookingStatusId;
            }

            return 0;
        }

        public void editStage(string email,int Stage)
        {
            var bookingstatus = db.BookingStatus.Find(getBookingStatusId(email));
            switch (Stage)
            {
                case 1:
                    bookingstatus.Step1 = true;
                    break;
                case 2:
                    bookingstatus.Step2 = true;
                    break;
                case 3:
                    bookingstatus.Step3 = true;
                    break;
                case 4:
                    bookingstatus.Step4 = true;
                    break;
                case 5:
                    bookingstatus.Status = true;
                    break;
                    
            }

            db.Entry(bookingstatus).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}