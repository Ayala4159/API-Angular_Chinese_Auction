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
        public DbSet<Basket> Basket => Set<Basket>();
        public DbSet<Purchase> Purchase => Set<Purchase>();
        public DbSet<Winner> Winner => Set<Winner>();
        public DbSet<Package> Package => Set<Package>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // מפות שמות הטבלאות במסד הנתונים
            modelBuilder.Entity<Category>().ToTable("Categories");
            modelBuilder.Entity<Donor>().ToTable("Donors").HasIndex(u => u.Email)
                .IsUnique();
            modelBuilder.Entity<User>().ToTable("Users").HasIndex(u => u.Email)
                .IsUnique();
            modelBuilder.Entity<Gift>().ToTable("Gifts");
            modelBuilder.Entity<Purchase>().ToTable("Purchase");
            modelBuilder.Entity<Basket>().ToTable("Basket");
            modelBuilder.Entity<Winner>().ToTable("Winner");
            modelBuilder.Entity<Package>().ToTable("Package");
            base.OnModelCreating(modelBuilder);
        }
    }
}
