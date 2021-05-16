using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartBeauty.Models
{
    public class Service

    {
        public string ServiceID { get; set; }

        [Display(Name = "Service Name")]
        public string ServiceName { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }

        public ICollection<Appointment> Appointments { get; set; }

    }
}
