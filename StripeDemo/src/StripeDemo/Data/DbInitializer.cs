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
        }

    }
}
