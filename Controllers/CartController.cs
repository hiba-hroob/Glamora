using Microsoft.AspNetCore.Mvc;
using Webproject.Data;
using Webproject.Models;
using System.Text.Json;

namespace Webproject.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }

        private List<CartItem> GetCart()
        {
            var cartJson = HttpContext.Session.GetString("Cart");

            if (string.IsNullOrEmpty(cartJson))
            {
                return new List<CartItem>();
            }

            return JsonSerializer.Deserialize<List<CartItem>>(cartJson)
                   ?? new List<CartItem>();
        }

        private void SaveCart(List<CartItem> cart)
        {
            var cartJson = JsonSerializer.Serialize(cart);

            HttpContext.Session.SetString("Cart", cartJson);
        }

        [HttpPost]
        public IActionResult AddToCart(int productId)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == productId);

            if (product == null)
            {
                return NotFound();
            }

            var cart = GetCart();

            var existingItem = cart.FirstOrDefault(x => x.ProductId == productId);

            if (existingItem != null)
            {
                existingItem.Quantity++;
            }
            else
            {
                cart.Add(new CartItem
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    Brand = product.Brand,
                    Price = product.Price,
                    ImageUrl = product.ImageUrl,
                    Quantity = 1
                });
            }

            SaveCart(cart);

            TempData["AddedProductId"] = productId;

            return RedirectToAction("Index", "Cart");
        }


        [HttpPost]
        public IActionResult IncreaseQuantity(int productId)
        {
            var cart = GetCart();

            var item = cart.FirstOrDefault(x => x.ProductId == productId);

            if (item != null)
            {
                item.Quantity++;
            }

            SaveCart(cart);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DecreaseQuantity(int productId)
        {
            var cart = GetCart();

            var item = cart.FirstOrDefault(x => x.ProductId == productId);

            if (item != null)
            {
                item.Quantity--;

                if (item.Quantity <= 0)
                {
                    cart.Remove(item);
                }
            }

            SaveCart(cart);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RemoveFromCart(int productId)
        {
            var cart = GetCart();

            var item = cart.FirstOrDefault(x => x.ProductId == productId);

            if (item != null)
            {
                cart.Remove(item);
            }

            SaveCart(cart);

            return RedirectToAction("Index");
        }


        public IActionResult Index()
        {
            var cart = GetCart();

            return View(cart);
        }
    }
}