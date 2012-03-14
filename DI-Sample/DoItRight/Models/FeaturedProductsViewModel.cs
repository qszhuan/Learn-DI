using System.Collections.Generic;

namespace DoItRight.Models
{
    public class FeaturedProductsViewModel
    {
        private readonly List<ProductViewModel> _products;

        public FeaturedProductsViewModel()
        {
            _products = new List<ProductViewModel>();
        }
        public List<ProductViewModel> Products
        {
            get { return _products; }
        }
    }
}