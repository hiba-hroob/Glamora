using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Webproject.Migrations
{
    public partial class InjectFinalStoreProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Brand", "Price", "ImageUrl", "Description" },
                values: new object[,]
                {
            { 1, "Fit Me Matte Foundation", "Maybelline", 15.00m, "/imgs/maybelline_foundation.png", "Matte + Poreless liquid foundation for oily skin" },
            { 2, "Instant Age Rewind Concealer", "Maybelline", 10.99m, "/imgs/maybelline_concealer.png", "Multi-use eraser dark circles treatment concealer" },
            { 3, "Lash Sensational Mascara", "Maybelline", 12.50m, "/imgs/maybelline_mascara.png", "Full fan effect waterproof volume mascara" },
            { 4, "Fit Me Blush", "Maybelline", 8.50m, "/imgs/maybelline_blush.png", "Lightweight powder blush for a natural glow" },
            { 5, "The Nudes Eyeshadow Palette", "Maybelline", 13.99m, "/imgs/maybelline_liquid eyeshadow.png", "12-shade palette with matte and shimmer finishes" },
            { 6, "SuperStay Matte Ink Lipstick", "Maybelline", 11.49m, "/imgs/maybelline_lipstick.png", "Long-lasting saturated liquid matte lipstick" },

            { 7, "All Hours Foundation", "YSL", 62.00m, "/imgs/ysl_foundation.png", "Full coverage matte foundation with 24h wear" },
            { 8, "Touche Éclat Radiant Concealer", "YSL", 40.00m, "/imgs/ysl_concealer.png", "Iconic brightening pen concealer and highlighter" },
            { 9, "Lash Clash Extreme Volume Mascara", "YSL", 29.00m, "/imgs/ysl_mascara.png", "Oversized volumizing mascara with an intense black finish" },
            { 10, "Nu Lip & Cheek Tint Blush", "YSL", 28.00m, "/imgs/ysl_blush.png", "Creamy liquid blush for a flushed, dewy look" },
            { 11, "Couture Clutch Eyeshadow Palette", "YSL", 75.00m, "/imgs/ysl_eyeshadow.png", "Luxury eyeshadow palette with rich couture colors" },
            { 12, "Rouge Pur Couture Lipstick", "YSL", 45.00m, "/imgs/ysl_lipstick.png", "Satin finish hydrating lipstick with rich pigment" },

            { 13, "FauxFilter Luminous Matte Foundation", "Huda Beauty", 42.00m, "/imgs/hudabeauty_foundation.png", "Full coverage transfer-proof liquid foundation" },
            { 14, "The Overachiever Concealer", "Huda Beauty", 30.00m, "/imgs/hudabeauty_concealer.png", "High coverage creamy concealer to disguise dark circles" },
            { 15, "1 Coat Wow! Mascara", "Huda Beauty", 23.00m, "/imgs/hudabeauty_mascara.png", "Instant extra volume and lifted curl mascara" },
            { 16, "Cheeky Tint Blush Stick", "Huda Beauty", 27.00m, "/imgs/hudabeauty_blush.png", "Buildable moisturizing cream blush stick" },
            { 17, "Empowered Eyeshadow Palette", "Huda Beauty", 69.00m, "/imgs/hudabeauty_eyeshadow.png", "Ultimate everyday palette with gold and earthy tones" },
            { 18, "Liquid Matte Lipstick", "Huda Beauty", 23.00m, "/imgs/hudabeauty_lipstick.png", "Comfortable, weightless and flake-free liquid lipstick" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
