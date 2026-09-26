using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webproject.Data;
using Webproject.Models; 
namespace Webproject.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string searchString) /*حطيت تاسك لاني استخدمت (غير متزامن:يعني الاكشن بقدر يستنى لبين ما اجيب الداتا من الداتابيس بدون ما يوقف الثريد اثناء الانتظار) والتاسك زي وعد انه رح يرجع الريزالت بس يخلص*/
        {

            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                return RedirectToAction("SignIn", "Account");
            }

            var productsQuery = _context.Products.AsQueryable(); //تجهيز استعلام عشان اضيف عليه شروط

            if (!string.IsNullOrEmpty(searchString))
            {
                productsQuery = productsQuery.Where(p => p.Name.Contains(searchString)
                                                      || p.Brand.Contains(searchString));
            }

            var productsList = await productsQuery.ToListAsync();

            var grouped = productsList
                .GroupBy(p => p.Brand ?? "Unknown Brand")
                .ToDictionary(g => g.Key, g => g.ToList());

            var viewModel = new ProductIndexViewModel
            {
                SearchString = searchString,
                GroupedProducts = grouped
            };

            return View(viewModel);
        }
    }
}