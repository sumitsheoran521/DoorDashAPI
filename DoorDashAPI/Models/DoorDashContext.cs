﻿using Microsoft.EntityFrameworkCore;

namespace DoorDashAPI.Models
{
    public class DoorDashContext : DbContext
    {
        public DbSet<Restaurant> Restaurant { get; set; }
        public DbSet<Cuisine> Cuisine { get; set; }
        public DbSet<Dish> Dish { get; set; }
        public DbSet<Users> Users { get; set; }


        public DoorDashContext(DbContextOptions<DoorDashContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Restaurant>()
                .HasMany(r => r.Dishes)
                .WithOne(d => d.Restaurant)
                .HasForeignKey(d => d.RestaurantId);
        }
    }
}
