using Ayana.Data;
using Ayana.MailgunService;
using Ayana.Models;
using Ayana.Paterni;
using Ayana.Patterns;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ayana
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IProduct, ProductEditor>();
            services.AddScoped<IDiscountCodeVerifier, DiscountCodeVerifier>();
            services.AddSingleton<UserState>();

            services.AddScoped<IReportFactory, ReportFactory>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddDefaultIdentity<ApplicationUser>(options =>
           options.SignIn.RequireConfirmedAccount = true)
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
            services.AddSingleton<IMailgunService, MailgunServiceClass>();
            services.AddSingleton(Configuration.GetConnectionString("DefaultConnection"));
            services.AddHangfire(configuration => configuration.UseSqlServerStorage(Configuration.GetConnectionString("DefaultConnection")));
            services.AddSingleton<IEmailService, EmailService>();
            services.AddSingleton<IMailgunService>(s =>
            {
                var apiKey = "87a566fbabc4f7046dc86478f9cfb8d8-6d1c649a-79b20914"; // Replace with your Mailgun API key
                var domain = "sandbox1219ccda395b4a0bb2410b5b7376da7a.mailgun.org";
                return new MailgunServiceClass(apiKey, domain);
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        [Obsolete]
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {app.UseHangfireServer();
            app.UseHangfireDashboard();
            app.UseAuthentication();
            RecurringJob.AddOrUpdate<MailgunBackgroundJob>(x => x.CheckAndSendEmail(null), Cron.Daily, TimeZoneInfo.Local);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            // Inside the appropriate location (e.g., Startup.Configure, a job scheduler class, or a controller action)

            app.UseRouting();
                        app.UseAuthorization();

           

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
