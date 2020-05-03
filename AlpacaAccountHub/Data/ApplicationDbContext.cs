using System;
using System.Collections.Generic;
using System.Text;
using AlpacaAccountHub.Data.ApiKeys;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace AlpacaAccountHub.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<AlpacaApiKey> AlpacaApiKey { get; set; }
       // public DbSet<ApiKey> InteractiveBrokers { get; set; }



        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public ApplicationDbContext()
        {
        }
    }
}
