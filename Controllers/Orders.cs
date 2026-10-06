using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Webproject.Data;
using Webproject.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Webproject.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult ConfirmOrder()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToAction("SignIn", "Account");
            }

            var cartJson = HttpContext.Session.GetString("Cart");

            if (string.IsNullOrEmpty(cartJson))
            {
                return RedirectToAction("Index", "Cart");
            }

            var cart = JsonSerializer.Deserialize<List<CartItem>>(cartJson);

            if (cart == null || cart.Count == 0)
            {
                return RedirectToAction("Index", "Cart");
            }

            var productIds = cart.Select(x => x.ProductId).ToList();

            var products = _context.Products
                .Where(p => productIds.Contains(p.Id))
                .ToList();

            var order = new Order
            {
                UserId = userId.Value,
                OrderDate = DateTime.UtcNow,
                TotalPrice = cart.Sum(x => x.Price * x.Quantity)
            };

            _context.Orders.Add(order);
            _context.SaveChanges();

            foreach (var item in cart)
            {
                var product = products.FirstOrDefault(p => p.Id == item.ProductId);

                if (product != null)
                {
                    _context.OrderDetails.Add(new OrderDetail
                    {
                        OrderId = order.Id,
                        ProductId = product.Id,
                        Price = product.Price,
                        Quantity = item.Quantity
                    });
                }
            }

            _context.SaveChanges();

            HttpContext.Session.Remove("Cart");

            return RedirectToAction("Success", new { id = order.Id });
        }


        public IActionResult MyOrders()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToAction("SignIn", "Account");
            }

            var orders = _context.Orders
                .Where(o => o.UserId == userId.Value)
                .OrderByDescending(o => o.OrderDate)
                .ToList();

            return View(orders);
        }

        public IActionResult Success(int id)
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToAction("SignIn", "Account");
            }

            var order = _context.Orders
                .FirstOrDefault(o => o.Id == id && o.UserId == userId.Value);

            if (order == null)
            {
                return NotFound();
            }

            var orderDetails = _context.OrderDetails
                .Include(od => od.Product)
                .Where(od => od.OrderId == id)
                .ToList();

            ViewBag.Products = orderDetails
                .Where(od => od.Product != null)
                .Select(od => od.Product)
                .ToList();

            ViewBag.Total = orderDetails
                .Sum(od => od.Price * od.Quantity);

            ViewBag.OrderDetails = orderDetails;

            return View();
        }


public IActionResult Details(int id)
{
    var userId = HttpContext.Session.GetInt32("UserId");

    if (userId == null)
    {
        return RedirectToAction("SignIn", "Account");
    }

    var order = _context.Orders
        .FirstOrDefault(o => o.Id == id && o.UserId == userId.Value);

    if (order == null)
    {
        return RedirectToAction("MyOrders");
    }

    var orderDetails = _context.OrderDetails
        .Include(od => od.Product)
        .Where(od => od.OrderId == id)
        .ToList();

    return View(orderDetails);
}



[HttpPost]
public IActionResult DeleteOrder(int id)
{
    var userId = HttpContext.Session.GetInt32("UserId");

    if (userId == null)
    {
        return RedirectToAction("SignIn", "Account");
    }

    var order = _context.Orders
        .FirstOrDefault(o => o.Id == id && o.UserId == userId.Value);

    if (order == null)
    {
        return RedirectToAction("MyOrders");
    }

    var orderDetails = _context.OrderDetails
        .Where(od => od.OrderId == id)
        .ToList();

    _context.OrderDetails.RemoveRange(orderDetails);
    _context.Orders.Remove(order);

    _context.SaveChanges();

    return RedirectToAction("MyOrders");
}



    }
       
       
}
