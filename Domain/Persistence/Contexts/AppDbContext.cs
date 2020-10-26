using Homemade.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace Homemade.Domain.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<UserChef> UserChefs { get; set; }

        public DbSet<UserCommon> UserCommons { get; set; }

        public DbSet<CommonChef> CommonChefs { get; set;  }

        public DbSet<User> Users { get; set; }
        public DbSet<Publication> Publications { get; set; }
        
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Payment> Payments { get; set; }

        public AppDbContext (DbContextOptions<AppDbContext> options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Ingredient Entity
            builder.Entity<Ingredient>().ToTable("Ingredients");
            builder.Entity<Ingredient>().HasKey(p => p.Id);
            builder.Entity<Ingredient>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Ingredient>().Property(p => p.Name).IsRequired().HasMaxLength(40);
            builder.Entity<Ingredient>().Property(p => p.UnitOfMeasurement).IsRequired();
            builder.Entity<Ingredient>().HasData
                (
                new Ingredient { Id = 100, Name = "Sal de Mesa", UnitOfMeasurement = EUnitOfMeasurement.Gram }
                );

            //User Entity
            builder.Entity<User>().ToTable("Users")
                .HasDiscriminator<int>("UserType")
                .HasValue<UserChef>(1)
                .HasValue<UserCommon>(2);
            builder.Entity<User>().HasKey(p => p.Id);


            //UserChef Entity
            builder.Entity<UserChef>().HasBaseType<User>();
            builder.Entity<UserChef>().ToTable("UserChefs");
            //builder.Entity<UserChef>().HasKey(p => p.Id);
            builder.Entity<UserChef>().Property(P => P.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<UserChef>().Property(p => p.Name).IsRequired().HasMaxLength(40);
            builder.Entity<UserChef>().Property(p => p.Lastname).IsRequired().HasMaxLength(50);
            builder.Entity<UserChef>().Property(p => p.Email).IsRequired();
            builder.Entity<UserChef>().Property(p => p.Date).IsRequired();
            builder.Entity<UserChef>().Property(p => p.Password).IsRequired();
            builder.Entity<UserChef>().HasData
                (
                new UserChef { Id = 100, Name = "Aaron", Lastname = "Alva Caffo", Email = "aaron_caffo@hotmail.com", Date = Convert.ToDateTime("05/03/2000"), Password = "12345" }
                );

            //UserCommon Entity 
            builder.Entity<UserCommon>().HasBaseType<User>();
            builder.Entity<UserCommon>().ToTable("UserCommons");
            //builder.Entity<UserCommon>().Property(P => P.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<UserCommon>().Property(p => p.Name).IsRequired().HasMaxLength(40);
            builder.Entity<UserCommon>().Property(p => p.Lastname).IsRequired().HasMaxLength(50);
            builder.Entity<UserCommon>().Property(p => p.Email).IsRequired();
            builder.Entity<UserCommon>().Property(p => p.Date).IsRequired();
            builder.Entity<UserCommon>().Property(p => p.Password).IsRequired();
            builder.Entity<UserCommon>().Property(p => p.Membership).HasDefaultValue(false);
            builder.Entity<UserCommon>().Property(p => p.Connected).HasDefaultValue(true);
            builder.Entity<UserCommon>().HasData
                (
                new UserCommon { Id = 101, Name = "Alison", Lastname = "Sempertegui Tuñoque", Email = "Alichip1999@hotmail.com", Date = Convert.ToDateTime("05/08/2000"), Password = "54321" }
                );

            //CommonChef Entity
            builder.Entity<CommonChef>().ToTable("CommonsChefs");
            builder.Entity<CommonChef>().HasKey(pt => new { pt.CommonId, pt.ChefId });
            builder.Entity<CommonChef>()
                .HasOne(pt => pt.UserChef)
                .WithMany(p => p.CommonChefs)
                .HasForeignKey(pt => pt.CommonId);
            builder.Entity<CommonChef>()
                .HasOne(Pt => Pt.UserChef)
                .WithMany(p => p.CommonChefs)
                .HasForeignKey(pt => pt.ChefId);

            //Publication Entity
            builder.Entity<Publication>().ToTable("Publications");
            builder.Entity<Publication>().HasKey(p => p.Id);
            builder.Entity<Publication>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Publication>().Property(p => p.Publicationdate).IsRequired();
            builder.Entity<Publication>().Property(p => p.Text).IsRequired().HasMaxLength(200);
            builder.Entity<Publication>().Property(p => p.Likes);
            builder.Entity<Publication>().Property(p => p.File);
            builder.Entity<Publication>().HasOne(p => p.User).WithMany(p => p.Publications).HasForeignKey(p => p.UserId);


            // Comments Entity
            builder.Entity<Comment>().ToTable("Comments");
            builder.Entity<Comment>().HasKey(p => p.Id);
            builder.Entity<Comment>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Comment>().Property(p => p.Date).IsRequired();
            builder.Entity<Comment>().Property(p => p.Text).IsRequired().HasMaxLength(200);
            builder.Entity<Comment>().HasOne(pt => pt.User).WithMany(p => p.Comments).HasForeignKey(pt => pt.UserId);
            builder.Entity<Comment>().HasOne(pt => pt.Publication).WithMany(p => p.Comments).HasForeignKey(pt => pt.PublicationId);

            //Recipe Entity
            builder.Entity<Recipe>().ToTable("Recipes");
            builder.Entity<Recipe>().HasKey(p => p.Id);
            builder.Entity<Recipe>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Recipe>().Property(p => p.NameRecipe).IsRequired().HasMaxLength(50);
            builder.Entity<Recipe>().Property(p => p.Qualification).IsRequired();
            builder.Entity<Recipe>().Property(p => p.Date).IsRequired();

            //Payment Entity
            builder.Entity<Payment>().ToTable("Payment");
            builder.Entity<Payment>().HasKey(p => p.Id);
            builder.Entity<Payment>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Payment>().Property(p => p.CardNumber).IsRequired();
            builder.Entity<Payment>().Property(p => p.CardName).IsRequired().HasMaxLength(50);
            builder.Entity<Payment>().Property(p => p.Date).IsRequired();
            builder.Entity<Payment>().Property(p => p.Total).IsRequired();

        }

    }
}
