using System;
using Microsoft.EntityFrameworkCore;

namespace Liquors.Context
{
    public class LiquorsContext : DbContext
    {
        public LiquorsContext()
        { }

        public LiquorsContext(DbContextOptions options) : base(options)
        {
        }
    }
}