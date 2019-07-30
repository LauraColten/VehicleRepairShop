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
                services.AddDefaultIdentity<User>()
                .AddEntityFrameworkStores<VehicleRepairShopContext>();
            });
        }
    }
}