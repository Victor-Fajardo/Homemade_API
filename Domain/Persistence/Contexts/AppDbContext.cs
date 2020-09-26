using Homemade.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homemade.Domain.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<UserChef> UserChefs { get; set; }

        public DbSet<UserCommon> UserCommons { get; set; }

        public AppDbContext (DbContextOptions<AppDbContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder) 
        {
            base.OnModelCreating(builder);
            //UserChef Entity
            builder.Entity<UserChef>().ToTable("UserChefs");
            builder.Entity<UserChef>().HasKey(p => p.Id);
            builder.Entity<UserChef>().Property(P => P.Id).IsRequired().ValueGeneratedOnAdd();
            
        }

    }
}
