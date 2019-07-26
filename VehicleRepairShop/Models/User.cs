using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleRepairShop.Models
{
    public class User : IdentityUser
    {
        public string Phone { get; set; }
        public string Address { get; set; }
        public int TypeId { get; set; }
    }
}
