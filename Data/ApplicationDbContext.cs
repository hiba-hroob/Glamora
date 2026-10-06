using Microsoft.EntityFrameworkCore;
using Webproject.Models;

namespace Webproject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users => Set<User>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<OrderDetail> OrderDetails => Set<OrderDetail>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    FullName = "SaraJamal",
                    Email = "Sara.Jamal11@gmail.com",
                    Password = "11234511"
                },
                new User
                {
                    Id = 2,
                    FullName = "lamaHadi",
                    Email = "Lama.Hadi22@gmail.com",
                    Password = "22134522"
                },
                new User
                {
                    Id = 3,
                    FullName = "LeenAhmad",
                    Email = "Leen.Ahmad33@gmail.com",
                    Password = "33134533"
                },
                new User
                {
                    Id = 4,
                    FullName = "samakareem",
                    Email = "Sama.Kareem44@gmail.com",
                    Password = "44134544"
                }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Fit Me Matte Foundation",
                    Brand = "Maybelline",
                    Price = 15.00m,
                    ImageUrl = "/imgs/maybelline_foundation.png",
                    Description = "Matte + Poreless liquid foundation for oily skin"
                },
                new Product
                {
                    Id = 2,
                    Name = "Instant Age Rewind Concealer",
                    Brand = "Maybelline",
                    Price = 10.99m,
                    ImageUrl = "/imgs/maybelline_concealer.png",
                    Description = "Multi-use eraser dark circles treatment concealer"
                },
                new Product
                {
                    Id = 3,
                    Name = "Lash Sensational Mascara",
                    Brand = "Maybelline",
                    Price = 12.50m,
                    ImageUrl = "/imgs/maybelline_mascara.png",
                    Description = "Full fan effect waterproof volume mascara"
                },
                new Product
                {
                    Id = 4,
                    Name = "Fit Me Blush",
                    Brand = "Maybelline",
                    Price = 8.50m,
                    ImageUrl = "/imgs/maybelline_blush.png",
                    Description = "Lightweight powder blush for a natural glow"
                },
                new Product
                {
                    Id = 5,
                    Name = "The Nudes Eyeshadow Palette",
                    Brand = "Maybelline",
                    Price = 13.99m,
                    ImageUrl = "/imgs/maybelline_liquid eyeshadow.png",
                    Description = "12-shade palette with matte and shimmer finishes"
                },
                new Product
                {
                    Id = 6,
                    Name = "SuperStay Matte Ink Lipstick",
                    Brand = "Maybelline",
                    Price = 11.49m,
                    ImageUrl = "/imgs/maybelline_lipstick.png",
                    Description = "Long-lasting saturated liquid matte lipstick"
                },
                new Product
                {
                    Id = 7,
                    Name = "All Hours Foundation",
                    Brand = "YSL",
                    Price = 62.00m,
                    ImageUrl = "/imgs/ysl_foundation.png",
                    Description = "Full coverage matte foundation with 24h wear"
                },
                new Product
                {
                    Id = 8,
                    Name = "Touche Éclat Radiant Concealer",
                    Brand = "YSL",
                    Price = 40.00m,
                    ImageUrl = "/imgs/ysl_concealer.png",
                    Description = "Iconic brightening pen concealer and highlighter"
                },
                new Product
                {
                    Id = 9,
                    Name = "Lash Clash Extreme Volume Mascara",
                    Brand = "YSL",
                    Price = 29.00m,
                    ImageUrl = "/imgs/ysl_mascara.png",
                    Description = "Oversized volumizing mascara with an intense black finish"
                },
                new Product
                {
                    Id = 10,
                    Name = "Nu Lip & Cheek Tint Blush",
                    Brand = "YSL",
                    Price = 28.00m,
                    ImageUrl = "/imgs/ysl_blush.png",
                    Description = "Creamy liquid blush for a flushed, dewy look"
                },
                new Product
                {
                    Id = 11,
                    Name = "Couture Clutch Eyeshadow Palette",
                    Brand = "YSL",
                    Price = 75.00m,
                    ImageUrl = "/imgs/ysl_eyeshadow.png",
                    Description = "Luxury eyeshadow palette with rich couture colors"
                },
                new Product
                {
                    Id = 12,
                    Name = "Rouge Pur Couture Lipstick",
                    Brand = "YSL",
                    Price = 45.00m,
                    ImageUrl = "/imgs/ysl_lipstick.png",
                    Description = "Satin finish hydrating lipstick with rich pigment"
                },
                new Product
                {
                    Id = 13,
                    Name = "FauxFilter Luminous Matte Foundation",
                    Brand = "Huda Beauty",
                    Price = 42.00m,
                    ImageUrl = "/imgs/hudabeauty_foundation.png",
                    Description = "Full coverage transfer-proof liquid foundation"
                },
                new Product
                {
                    Id = 14,
                    Name = "The Overachiever Concealer",
                    Brand = "Huda Beauty",
                    Price = 30.00m,
                    ImageUrl = "/imgs/hudabeauty_concealer.png",
                    Description = "High coverage creamy concealer to disguise dark circles"
                },
                new Product
                {
                    Id = 15,
                    Name = "1 Coat Wow! Mascara",
                    Brand = "Huda Beauty",
                    Price = 23.00m,
                    ImageUrl = "/imgs/hudabeauty_mascara.png",
                    Description = "Instant extra volume and lifted curl mascara"
                },
                new Product
                {
                    Id = 16,
                    Name = "Cheeky Tint Blush Stick",
                    Brand = "Huda Beauty",
                    Price = 27.00m,
                    ImageUrl = "/imgs/hudabeauty_blush.png",
                    Description = "Buildable moisturizing cream blush stick"
                },
                new Product
                {
                    Id = 17,
                    Name = "Empowered Eyeshadow Palette",
                    Brand = "Huda Beauty",
                    Price = 69.00m,
                    ImageUrl = "/imgs/hudabeauty_eyeshadow.png",
                    Description = "Ultimate everyday palette with gold and earthy tones"
                },
                new Product
                {
                    Id = 18,
                    Name = "Liquid Matte Lipstick",
                    Brand = "Huda Beauty",
                    Price = 23.00m,
                    ImageUrl = "/imgs/hudabeauty_lipstick.png",
                    Description = "Comfortable, weightless and flake-free liquid lipstick"
                }
            );
        }
    }
}
