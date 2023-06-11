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
            services.AddScoped<IReportFactory, ReportFactory>();
            services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddDefaultIdentity<ApplicationUser>(options =>
           options.SignIn.RequireConfirmedAccount = true)
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
            services.AddHangfire(configuration => configuration.UseSqlServerStorage(Configuration.GetConnectionString("DefaultConnection")));
            services.AddSingleton<IMailgunService, MailgunServiceClass>();
            services.AddSingleton(Configuration.GetConnectionString("DefaultConnection"));

            services.AddSingleton<IEmailService, EmailService>();
            services.AddSingleton<IMailgunService>(s =>
            {
                var apiKey = "fff937c6161272edc197b20416ff89a3-6d1c649a-0f2959e2\r\n"; // Replace with your Mailgun API key
                var domain = "sandbox88a6eff4d8924e7bb58ed3ab18073bf7.mailgun.org";
                return new MailgunServiceClass(apiKey, domain);
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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

            app.UseRouting();

            app.UseAuthentication();
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
