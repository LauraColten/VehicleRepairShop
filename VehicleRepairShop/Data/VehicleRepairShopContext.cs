using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace VehicleRepairShop.Models
{
    public class VehicleRepairShopContext : DbContext
    {
        public VehicleRepairShopContext (DbContextOptions<VehicleRepairShopContext> options)
            : base(options)
        {
        }

        public DbSet<VehicleRepairShop.Models.Vehicle> Vehicle { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
