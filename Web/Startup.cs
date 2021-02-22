using Core.Interfaces;
using Core.Services;
using Infrastructure.EntityFramework;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web
{
    public class Startup
    {
        IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Database configure
            services.AddDbContext<RentCarDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // adding UnitOfWork service
            services.AddScoped<IUnitOfWork, EFUnitOfWork>();

            // adding Entitys Services
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICouponService, CouponService>();
            services.AddScoped<IReservationService, ReservationService>();

            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // app.UseExceptionHandler("Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            // app.UseAuthorization();
            // app.UseAuthentication();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
