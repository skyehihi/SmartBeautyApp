using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartBeauty.Models
{
    public class LastAppointment

    {
        public string LastAppointmentID { get; set; }

        [Display(Name = "Last Appointment Date")]
        [DataType(DataType.Date)]
        public DateTime LastAppointmentDate { get; set; }

        [Display(Name = "Service Using")]
        public string ServiceUsing { get; set; }

        public string ClientID { get; set; }
        public Client Client { get; set; }

    }
}
