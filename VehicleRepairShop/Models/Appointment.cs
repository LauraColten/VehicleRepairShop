using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleRepairShop.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        [Display(Name = "Scheduled Date")]
        public DateTime ScheduledDate { get; set; }
        [Display(Name = "Make and Model")]
        public Vehicle Vehicle { get; set; }
        public int VehicleId { get; set; }
        [Display(Name = "Customer Name")]
        public User User { get; set; }

        public string UserId { get; set; }
         
    }
}
