using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Verdure.Domain.Entities;
using Verdure.Infrastructure.EFCore;

namespace Verdure.Infrastructure
{
    public class VerdureEfcContext : DbContext
    {
        public VerdureEfcContext(DbContextOptions options) : base(options)
        { }

        public VerdureEfcContext() : base()
        { }

        public DbSet<VerdureUser> Users { get; set; }

        public DbSet<EfcFoodItem> FoodItems { get; set; }

        public DbSet<EfcMeal> Meals { get; set; }

        public DbSet<EfcMealFoodItem> MealFoodItems { get; set; }

        public DbSet<EfcSnack> Snacks { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VerdureUser>().HasKey(x => x.Id);
            modelBuilder.Entity<VerdureUser>().Property(x => x.Name);
            modelBuilder.Entity<VerdureUser>().Property(x => x.ModifiedDate);
            modelBuilder.Entity<VerdureUser>().Property(x => x.CreatedDate);
            modelBuilder.Entity<VerdureUser>().Property(x => x.Deleted);

            modelBuilder.Entity<EfcFoodItem>().HasKey(x => x.Id);
            modelBuilder.Entity<EfcFoodItem>().Property(x => x.Name);
            modelBuilder.Entity<EfcFoodItem>().Property(x => x.Calories)
                .HasDefaultValue(0)
                .IsRequired();
            modelBuilder.Entity<EfcFoodItem>().Property(x => x.ModifiedDate);
            modelBuilder.Entity<EfcFoodItem>().Property(x => x.Deleted);
            modelBuilder.Entity<EfcFoodItem>().Property(x => x.CreatedDate);

            modelBuilder.Entity<EfcMeal>().HasKey(x => x.Id);
            modelBuilder.Entity<EfcMeal>().Ignore(x => x.Food);
            modelBuilder.Entity<EfcMeal>().Property(x => x.Name);
            modelBuilder.Entity<EfcMeal>().HasOne(x => x.User)
                .WithMany(); 
            modelBuilder.Entity<EfcMeal>().Property(x => x.ModifiedDate);
            modelBuilder.Entity<EfcMeal>().Property(x => x.CreatedDate);
            modelBuilder.Entity<EfcMeal>().Ignore(x => x.Calories);

            modelBuilder.Entity<EfcMealFoodItem>().HasKey(x => new { x.FoodItemId, x.MealId });
            modelBuilder.Entity<EfcMealFoodItem>().HasOne(x => x.FoodItem)
                .WithMany()
                .HasForeignKey(x => x.FoodItemId);
            modelBuilder.Entity<EfcMealFoodItem>().HasOne(x => x.Meal)
                .WithMany(x => x.MealFoodItemIds)
                .HasForeignKey(x => x.MealId);

            modelBuilder.Entity<EfcSnack>().HasKey(x => x.Id);
            modelBuilder.Entity<EfcSnack>().HasOne(x => x.User)
                .WithMany();
            modelBuilder.Entity<EfcSnack>().HasOne(x => x.Food)
                .WithMany().Metadata.DependentToPrincipal.SetField("_fooditem"); 
            modelBuilder.Entity<EfcSnack>().Property(x => x.ModifiedDate);
            modelBuilder.Entity<EfcSnack>().Property(x => x.CreatedDate);
            modelBuilder.Entity<EfcSnack>().Ignore(x => x.Name);
            modelBuilder.Entity<EfcSnack>().Ignore(x => x.Calories);


        }
    }
}
