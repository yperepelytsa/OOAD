using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Stripe;
using StripeDemo.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using StripeDemo.Data;
using Microsoft.AspNetCore.Http;
using StripeDemo.Services;

namespace StripeDemo
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            if (env.IsDevelopment())
            {
                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>().
            AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();
            services.AddSession(session =>
            {
                session.IdleTimeout = TimeSpan.FromMinutes(120);
            });
            services.Configure<IdentityOptions>(options =>
            {
                options.Cookies.ApplicationCookie.LoginPath = new PathString("/account/login");
                options.Cookies.ApplicationCookie.LogoutPath = new PathString("/account/logout");
            });
            services.AddAuthorization();
            services.AddSingleton<IDbInitializer, DbInitializer>();
            services.AddSingleton<IChargeService, ChargeService>();
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite("Filename=demo.db"));
            // Add framework services.
            services.AddApplicationInsightsTelemetry(Configuration);

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            StripeConfiguration.SetApiKey("sk_test_tZHt93U0YFMoTueSbZUgCC8q");
            app.UseApplicationInsightsRequestTelemetry();
            app.UseSession();
            app.UseCookieAuthentication();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseApplicationInsightsExceptionTelemetry();
            app.UseIdentity();
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}");
            });

            IDbInitializer databaseInitializer = app.ApplicationServices.GetService<IDbInitializer>();
            databaseInitializer.SeedData();
        }
    }
}
