using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StripeDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Stripe;

namespace StripeDemo.Data
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public DbInitializer(ApplicationDbContext context, UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.context = context;
            this.roleManager = roleManager;
        }

        public void SeedData()
        {
            context.Database.Migrate();
          
            if (userManager.FindByNameAsync("testuser@gmail.com").GetAwaiter().GetResult() == null) {
                var clientopts = new StripeCustomerCreateOptions
                {
                    Email = "testuser@gmail.com",
                    SourceCard = new SourceCard()
                    {
                        Number = "4242424242424242",
                        ExpirationYear = "2022",
                        ExpirationMonth = "10"
                    }
                };
                var customerService = new StripeCustomerService();
                var customer = customerService.Create(clientopts);
                var user = new ApplicationUser() { UserName = "testuser@gmail.com", Email = "testuser@gmail.com", EmailConfirmed = true,StripeClientId=customer.Id, LockoutEnabled = false };
            userManager.CreateAsync(user).GetAwaiter().GetResult();
            userManager.AddPasswordAsync(user, "Password_1").GetAwaiter().GetResult();
        }
            if (!context.Products.Any())
            {
                context.Add(new Product
                {
                   LeftInStock=1000,
                   Name="Apple",
                   Price=10,
                   Description="Fruit",
                   Vendor="abcd"
                });
                context.Add(new Product
                {
                    LeftInStock = 10,
                    Name = "Vehicle",
                    Price = 200000,
                    Description = "M1 Abrams",
                    Vendor = "unknown"
                });
                context.Add(new Product
                {
                    LeftInStock = 0,
                    Name = "Snickers",
                    Price = 15,
                    Description = "Food",
                    Vendor = "Roshen"
                });
                context.SaveChanges();
            }

        }

    }
}
