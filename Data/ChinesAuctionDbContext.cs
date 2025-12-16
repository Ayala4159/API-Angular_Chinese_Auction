using ChineseAuction.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace StoreApi.Data
{
    public class ChinesActionDbContext : DbContext
    {
        public ChinesActionDbContext(DbContextOptions<ChinesActionDbContext> options) : base(options) { }
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Donor> Donors => Set<Donor>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Gift> Gifts => Set<Gift>();
        public DbSet<Purchase> Purchases => Set<Purchase>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // מפות שמות הטבלאות במסד הנתונים
            modelBuilder.Entity<Category>().ToTable("Categories");
            modelBuilder.Entity<Donor>().ToTable("Donors");
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Gift>().ToTable("Gifts");
            modelBuilder.Entity<Purchase>().ToTable("Purchases");
            base.OnModelCreating(modelBuilder);
        }
    }
}
