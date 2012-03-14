
using System.Collections.Generic;
using System.Linq;

namespace DoItWrong.Services
{
    public class ProductService
    {
        private readonly testEntities _commerceObjectContext;

        public ProductService()
        {
            _commerceObjectContext = new testEntities();
        }

        public IEnumerable<Product> GetFeaturedProducts(bool isCustomerPreferred)
        {
            var discount = isCustomerPreferred ? .95m : 1;
            var products = _commerceObjectContext.Product.Where(p => p.Featured).ToList();
            return products.Select(product => new Product
                                                  {
                                                      ProductId = product.ProductId,
                                                      Description = product.Description,
                                                      Featured = product.Featured,
                                                      Name = product.Name,
                                                      UnitPrice = product.UnitPrice * discount
                                                  });
        }
    }
}