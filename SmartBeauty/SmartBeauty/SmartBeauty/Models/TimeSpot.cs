using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartBeauty.Models
{
    public class TimeSpot
    {
        [Key]
        public string TimeSpotID { get; set; }

        [Display(Name = "Time Spots")]
        public string TimeSpotName { get; set; }

        public ICollection<Appointment> Appointments { get; set; }

    }
}
