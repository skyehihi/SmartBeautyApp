using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartBeauty.Models
{
    public class Appointment
    {
        public int AppointmentID { get; set; }

        [Display(Name = "Booking Date")]
        [DataType(DataType.Date)]
        public DateTime BookingDate { get; set; }
        public string ShowUp { get; set; }
        public string SalonID { get; set; }
        public Salon Salon { get; set; }
        public string StaffID { get; set; }
        public Staff Staff { get; set; }
        public string ClientID { get; set; }
        public Client Client { get; set; }
        public string TimeSpotID { get; set; }
        public TimeSpot TimeSpot { get; set; }
        public string ServiceID { get; set; }
        public Service Service { get; set; }
    }
}
