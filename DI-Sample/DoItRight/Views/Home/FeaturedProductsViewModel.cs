using System.Collections;
using System.Collections.Generic;

namespace System.Web.Mvc
{
    public class FeaturedProductsViewModel
    {
        public IEnumerable<ProductViewModel> Products { get; private set; }
    }

    public class ProductViewModel
    {
        public string Name { get; set; }
        public string SummaryText { get; set; }
        public string UnitPrice { get; set; }
    }
}