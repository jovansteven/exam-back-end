using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ExamGripFoodBackEnd.Entities
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {          

            var user1 = new User
            {
                Id = Ulid.NewUlid().ToString(),
                Name = "Muhammad Martin Antonus",
                Email = "martin@email.com",
                Password = "martin123",
                CreatedAt = DateTimeOffset.UtcNow,
            };

            var user2 = new User
            {
                Id = Ulid.NewUlid().ToString(),
                Name = "Udin Jalia",
                Email = "udin@email.com",
                Password = "udin123",
                CreatedAt = DateTimeOffset.UtcNow,
            };

            var user3 = new User
            {
                Id = Ulid.NewUlid().ToString(),
                Name = "Budi Antono",
                Email = "budi@email.com",
                Password = "budi123",
                CreatedAt = DateTimeOffset.UtcNow,
            };

            var restaurant1 = new Restaurant
            {
                Id = "Pagi Sore",
                Name = "Pagi Sore",
                CreatedAt = DateTimeOffset.UtcNow,
            };

            var restaurant2 = new Restaurant
            {
                Id = "Rumah Kayu",
                Name = "Rumah Kayu",
                CreatedAt = DateTimeOffset.UtcNow,
            };

            var restaurant3 = new Restaurant
            {
                Id = "Kanchin",
                Name = "Kanchin",
                CreatedAt = DateTimeOffset.UtcNow,
            };

            var food1 = new FoodItem
            {
                Id = Ulid.NewUlid().ToString(),
                Name = "Ayam Gulai",
                Price = 25000,
                RestaurantId = restaurant1.Id,
                CreatedAt = DateTimeOffset.UtcNow,
            };

            var food2 = new FoodItem
            {
                Id = Ulid.NewUlid().ToString(),
                Name = "Rendang Batokok",
                Price = 28000,
                RestaurantId = restaurant1.Id,
                CreatedAt = DateTimeOffset.UtcNow,
            };

            var food3 = new FoodItem
            {
                Id = Ulid.NewUlid().ToString(),
                Name = "Ayam Bakar Rumah Kayu",
                Price = 108000,
                RestaurantId = restaurant2.Id,
                CreatedAt = DateTimeOffset.UtcNow,
            };

            var food4 = new FoodItem
            {
                Id = Ulid.NewUlid().ToString(),
                Name = "Kangkung Sapi Hotplate",
                Price = 58000,
                RestaurantId = restaurant2.Id,
                CreatedAt = DateTimeOffset.UtcNow,
            };

            var food5 = new FoodItem
            {
                Id = Ulid.NewUlid().ToString(),
                Name = "Nasi Goreng Ayam",
                Price = 61000,
                RestaurantId = restaurant3.Id,
                CreatedAt = DateTimeOffset.UtcNow,
            };

            var food6 = new FoodItem
            {
                Id = Ulid.NewUlid().ToString(),
                Name = "Bistik Babi",
                Price = 68000,
                RestaurantId = restaurant3.Id,
                CreatedAt = DateTimeOffset.UtcNow,
            };

            modelBuilder.Entity<User>().HasData(user1, user2, user3);
            modelBuilder.Entity<Restaurant>().HasData(restaurant1, restaurant2, restaurant3);
            modelBuilder.Entity<FoodItem>().HasData(food1, food2, food3, food4, food5, food6);

            modelBuilder.Entity<FoodItem>()
               .HasOne(fi => fi.Restaurant)
               .WithMany(r => r.FoodItems)
               .HasForeignKey(fi => fi.RestaurantId);
        }

        public DbSet<Cart> Carts => Set<Cart>();

        public DbSet<CartDetail> CartDetails => Set<CartDetail>();

        public DbSet<FoodItem> FoodItems => Set<FoodItem>();

        public DbSet<Restaurant> Restaurants => Set<Restaurant>();

        public DbSet<User> Users => Set<User>();

        public DbSet<DataProtectionKey> DataProtectionKeys => Set<DataProtectionKey>();
    }
}
