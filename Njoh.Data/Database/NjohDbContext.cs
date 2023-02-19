using Microsoft.EntityFrameworkCore;
using Njoh.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Njoh.Data.Database
{
    public class NjohDbContext : DbContext
    {
        public NjohDbContext(DbContextOptions<NjohDbContext> options)
            : base(options)
        {
        }

        public DbSet<Listing> Listings { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Specification> Spectifications { get; set; }
    }
}
