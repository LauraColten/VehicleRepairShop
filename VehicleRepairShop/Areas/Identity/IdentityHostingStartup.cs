﻿using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VehicleRepairShop.Models;

[assembly: HostingStartup(typeof(VehicleRepairShop.Areas.Identity.IdentityHostingStartup))]
namespace VehicleRepairShop.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                //services.AddDefaultIdentity<User>(options =>
                //{
                //    //Default password settings
                //    options.Password.RequireDigit = false;
                //    options.Password.RequireLowercase = false;
                //    options.Password.RequireNonAlphanumeric = false;
                //    options.Password.RequireUppercase = false;
                //    options.Password.RequiredLength = 6;
                //    options.Password.RequiredUniqueChars = 1;
                //})
                //.AddRoles<IdentityRole>()
                //.AddEntityFrameworkStores<VehicleRepairShopContext>();

                services.AddIdentity<User, IdentityRole>()
.AddRoleManager<RoleManager<IdentityRole>>()
.AddDefaultUI()
.AddDefaultTokenProviders()
.AddEntityFrameworkStores<VehicleRepairShopContext>();

            });
        }
    }
}