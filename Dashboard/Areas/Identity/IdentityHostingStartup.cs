using System;
using Dashboard.Areas.Identity.Data;
using Dashboard.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Dashboard.Areas.Identity.IdentityHostingStartup))]
namespace Dashboard.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<DashboardContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("DashboardContextConnection")));

                services.AddDefaultIdentity<DashboardUser>()
                    .AddEntityFrameworkStores<DashboardContext>();
            });
        }
    }
}