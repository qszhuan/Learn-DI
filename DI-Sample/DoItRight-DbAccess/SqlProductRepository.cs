using System.Collections.Generic;
using System.Linq;
using DoItRight_Domain;

namespace DoItRight_DbAccess
{
    public class SqlProductRepository:ProductRepository
    {
        private readonly CommerceEntities _commerceEntities;

        public SqlProductRepository(string connectstring)
        {
            _commerceEntities = new CommerceEntities(connectstring);
        }

        public override IEnumerable<DoItRight_Domain.Product> GetFeaturedProducts()
        {
            var products = _commerceEntities.Product.Where(p => p.Featured).ToList();
            return products.Select(p=> p.ToDomainProduct());
        }
    }
}