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
        public DbSet<RecipeStep> RecipeSteps { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuRecipe> MenuRecipes { get; set; }

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
            builder.Entity<Ingredient>().Property(p => p.Quantity).IsRequired();
            builder.Entity<Ingredient>().Property(p => p.UnitOfMeasurement).IsRequired();
            builder.Entity<Ingredient>().HasOne(pt => pt.Recipe).WithMany(p => p.Ingredients).HasForeignKey(pt => pt.RecipeId);


            //User Entity
            builder.Entity<User>().ToTable("Users")
                .HasDiscriminator<int>("UserType")
                .HasValue<UserChef>(1)
                .HasValue<UserCommon>(2);
            builder.Entity<User>().HasKey(p => p.Id);


            //UserChef Entity
            builder.Entity<UserChef>().HasBaseType<User>();
            //builder.Entity<UserChef>().HasKey(p => p.Id);
            builder.Entity<UserChef>().Property(P => P.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<UserChef>().Property(p => p.Name).IsRequired().HasMaxLength(40);
            builder.Entity<UserChef>().Property(p => p.Lastname).IsRequired().HasMaxLength(50);
            builder.Entity<UserChef>().Property(p => p.Email).IsRequired();
            builder.Entity<UserChef>().Property(p => p.Date).IsRequired();
            builder.Entity<UserChef>().Property(p => p.Password).IsRequired();
            builder.Entity<UserChef>().HasData
                (
                new UserChef { Id = 100, Name = "Aaron", Lastname = "Alva Caffo", Email = "aaron_caffo@hotmail.com", Date = Convert.ToDateTime("05/03/2000"), Password = "12345", Picture= "https://scontent.flim18-1.fna.fbcdn.net/v/t1.0-9/107697646_1063570910706020_6049356131090790239_o.jpg?_nc_cat=102&ccb=2&_nc_sid=09cbfe&_nc_eui2=AeElQJo0XMR59x1fWdDj4MHVhBRN2sNJSP2EFE3aw0lI_QgZw6_XxVcq_ynfVGuQcPxodxUpVNBNu-4VqBBAXEEW&_nc_ohc=i-oqCeMNN1oAX--4BkU&_nc_ht=scontent.flim18-1.fna&oh=d57aed443b5f97a858f228b8fbf3de64&oe=5FCEF49A" }
                );

            //UserCommon Entity 
            builder.Entity<UserCommon>().HasBaseType<User>();
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
            builder.Entity<Recipe>().Property(p => p.Date).IsRequired();
            builder.Entity<Recipe>().HasOne(pt => pt.Author).WithMany(p => p.Recipes).HasForeignKey(pt => pt.AuthorId);

            //Payment Entity
            builder.Entity<Payment>().ToTable("Payments");
            builder.Entity<Payment>().HasKey(p => p.Id);
            builder.Entity<Payment>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Payment>().Property(p => p.CardNumber).IsRequired();
            builder.Entity<Payment>().Property(p => p.CardName).IsRequired().HasMaxLength(50);
            builder.Entity<Payment>().Property(p => p.Date).IsRequired();
            builder.Entity<Payment>().Property(p => p.Total).IsRequired();
            builder.Entity<Payment>().HasOne(p => p.UserCommon).WithMany(p => p.Payments).HasForeignKey(pt => pt.UserCommonId);

            //RecipeStep Entity
            builder.Entity<RecipeStep>().ToTable("RecipeSteps");
            builder.Entity<RecipeStep>().HasKey(p => p.Id);
            builder.Entity<RecipeStep>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<RecipeStep>().Property(p => p.Instructions).IsRequired().HasMaxLength(200);
            builder.Entity<RecipeStep>().HasOne(p => p.Recipe).WithMany(pt => pt.RecipeSteps).HasForeignKey(p => p.RecipeId);


            //Chats Entity
            builder.Entity<Chat>().ToTable("Chats");
            builder.Entity<Chat>().HasKey(p => p.Id);
            builder.Entity<Chat>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Chat>().HasOne(p => p.User1).WithMany(p => p.ChatsCreados).HasForeignKey(p => p.User1Id);
            builder.Entity<Chat>().HasOne(p => p.User2).WithMany(p => p.ChatsUnidos).HasForeignKey(p => p.User2Id);


            //Messages Entity
            builder.Entity<Message>().ToTable("Messages");
            builder.Entity<Message>().HasKey(p => p.Id);
            builder.Entity<Message>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Message>().Property(p => p.Text).IsRequired().HasMaxLength(200);
            builder.Entity<Message>().Property(p => p.File);
            builder.Entity<Message>().HasOne(p => p.User).WithMany(p => p.Messages).HasForeignKey(p => p.UserId);
            builder.Entity<Message>().HasOne(p => p.Chat).WithMany(p => p.Messages).HasForeignKey(p => p.ChatId);

            //Menu Entity
            builder.Entity<Menu>().ToTable("Menus");
            builder.Entity<Menu>().HasKey(p => p.Id);
            builder.Entity<Menu>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Menu>().Property(p => p.DateOfRecipe).IsRequired();
            builder.Entity<Menu>().HasOne(pt => pt.UserCommon).WithMany(p => p.Menus).HasForeignKey(p => p.UserCommonId);

            //MenuRecipe Entity
            builder.Entity<MenuRecipe>().ToTable("MenuRecipes");
            builder.Entity<MenuRecipe>().HasKey(pt => pt.Id);
            builder.Entity<MenuRecipe>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<MenuRecipe>().HasOne(pt => pt.Menu).WithMany(pt => pt.MenuRecipes).HasForeignKey(pt => pt.MenuId);
            builder.Entity<MenuRecipe>().HasOne(pt => pt.Recipe).WithMany(pt => pt.MenuRecipes).HasForeignKey(pt => pt.RecipeId);
        }

    }
}
