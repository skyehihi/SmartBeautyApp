using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartBeauty.Models
{
    public class Staff

    {
        public string StaffID { get; set; }

        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Email { get; set; }

        public string Rating { get; set; }

        public string SalonID { get; set; }
        public Salon Salon { get; set; }
        public string TimeSpotID { get; set; }
        public TimeSpot TimeSpot { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
    }
}
