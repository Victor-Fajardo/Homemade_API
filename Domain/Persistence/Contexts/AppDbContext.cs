using Homemade.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
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

        public DbSet<CommonChef> CommonChefs { get; set }

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
            builder.Entity<UserChef>().Property(p => p.Name).IsRequired().HasMaxLength(40);
            builder.Entity<UserChef>().Property(p => p.Lastname).IsRequired().HasMaxLength(50);
            builder.Entity<UserChef>().Property(p => p.Email).IsRequired();
            builder.Entity<UserChef>().Property(p => p.Date).IsRequired();
            builder.Entity<UserChef>().Property(p => p.Password).IsRequired();
            builder.Entity<UserChef>().HasData
                (
                new UserChef { Id = 100, Name = "Aaron", Lastname = "Alva Caffo", Email = "aaron_caffo@hotmail.com", Date = Convert.ToDateTime("31/03/2000"), Password = "12345" }
                );

            //UserCommon Entity 
            builder.Entity<UserCommon>().ToTable("UserCommons");
            builder.Entity<UserCommon>().Property(P => P.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<UserCommon>().Property(p => p.Name).IsRequired().HasMaxLength(40);
            builder.Entity<UserCommon>().Property(p => p.Lastname).IsRequired().HasMaxLength(50);
            builder.Entity<UserCommon>().Property(p => p.Email).IsRequired();
            builder.Entity<UserCommon>().Property(p => p.Date).IsRequired();
            builder.Entity<UserCommon>().Property(p => p.Password).IsRequired();
            builder.Entity<UserCommon>().Property(p => p.Membership).HasDefaultValue(false);
            builder.Entity<UserCommon>().Property(p => p.Connected).HasDefaultValue(true);
            builder.Entity<UserCommon>().HasData
                (
                new UserCommon { Id = 100, Name = "Alison", Lastname = "Sempertegui Tuñoque", Email = "Alichip1999@hotmail.com", Date = Convert.ToDateTime("31/08/2000"), Password = "54321" }
                );

            //CommonChef Entity
            builder.Entity<CommonChef>().ToTable("CommonsChefs");
            builder.Entity<CommonChef>().HasKey(p => new { p.CommonId, p.ChefId });
            builder.Entity<CommonChef>().HasOne(p => p.UserCommon).WithMany(p => p.CommonChefs).HasForeignKey(p=>p.CommonId);
            builder.Entity<CommonChef>().HasOne(P => P.UserChef).WithMany(p => p.CommonChefs).HasForeignKey(p => p.ChefId);


        }

    }
}
