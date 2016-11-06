using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace StripeDemo.Models
{
    public class ApplicationUser: IdentityUser
    {
        public ApplicationUser()
        {

        }

        public string StripeClientId { get; set; }
    }
}
