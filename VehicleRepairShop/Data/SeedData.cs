using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleRepairShop.Models;

namespace VehicleRepairShop.Data
{
    public static class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            using (var context = new VehicleRepairShopContext(
                serviceProvider.GetRequiredService<DbContextOptions<VehicleRepairShopContext>>()))
            {
                string UserId = null;
                var userManager = serviceProvider.GetService<UserManager<User>>();
                var userEmail = "admin@test.com";


                if (!context.Users.Any())
                {
                    var user = new User()
                    {
                        FirstName = "Admin",
                        LastName = "Super",
                        Email = userEmail,
                        UserName = userEmail
                    };

                    var result = await userManager.CreateAsync(user, "password");
                    if (!result.Succeeded)
                    {
                        throw new Exception();
                    }
                    user = await userManager.FindByEmailAsync(userEmail);
                    var userId = await userManager.GetUserIdAsync(user);
                }

                if (UserId == null)
                {
                    var user = await userManager.FindByEmailAsync(userEmail);
                    UserId = await userManager.GetUserIdAsync(user);
                }

                if (!context.Vehicle.Any())
                {
                    context.Vehicle.AddRange(
                        new Vehicle()
                        {
                            Make = "Honda",
                            Model = "Clarity",
                            AcceptedDate = DateTime.Now,
                            IsInShop = true,
                            OwnerId = UserId
                        },
                    new Vehicle()
                    {
                        Make = "BMW",
                        Model = "X5",
                        AcceptedDate = DateTime.Now,
                        IsInShop = true,
                        OwnerId = UserId
                    });
                }
                context.SaveChanges();
            }
        }
    }
}
