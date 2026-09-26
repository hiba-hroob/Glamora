using System.Collections.Generic;

namespace Webproject.Models
{
    public class ProductIndexViewModel
    {
        public string SearchString { get; set; }

        public Dictionary<string, List<Product>> GroupedProducts { get; set; }
    }
}