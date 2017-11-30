using System;
using Liquors.Model;
using Microsoft.EntityFrameworkCore;

namespace Liquors.Context
{
    public class LiquorsContext : DbContext
    {
        public DbSet<Alcohol> Alcohols { get; set; }
        public DbSet<Vintage> Vintages { get; set; }


        public LiquorsContext()
        { }

        public LiquorsContext(DbContextOptions options) : base(options)
        {
        }
    }
}