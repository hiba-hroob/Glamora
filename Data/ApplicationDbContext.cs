
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Webproject.Models;
namespace Webproject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, FullName = "SaraJamal", Email = "Sara.Jamal11@gmail.com", Password = "11234511" },
            new User { Id = 2, FullName = "lamaHadi", Email = "Lama.Hadi22@gmail.com", Password = "22134522" },
            new User { Id = 3, FullName = "LeenAhmad", Email = "Leen.Ahmad33@gmail.com", Password = "33134533" },
                new User { Id = 4, FullName = "samakareem", Email = "Sama.Kareem44@gmail.com", Password = "44134544" }

               ); 
        }
    }
}
