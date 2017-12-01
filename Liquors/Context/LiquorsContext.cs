using System;
using Liquors.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Liquors.Context
{
    public class LiquorsContext : IdentityDbContext
    {
        public DbSet<Alcohol> Alcohols { get; set; }
        public DbSet<Vintage> Vintages { get; set; }
        public DbSet<AlcoholVintage> AlcoholVintages { get; set; }

        public DbSet<Wine> Wines { get; set; }
        public DbSet<UserRate> UserRates { get; set; }

        public LiquorsContext()
        { }

        public LiquorsContext(DbContextOptions options) : base(options)
        {
        }
    }
}