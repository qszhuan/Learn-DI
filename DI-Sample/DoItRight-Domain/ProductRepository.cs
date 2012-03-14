using System.Collections.Generic;

namespace DoItRight_Domain
{
    public abstract class ProductRepository
    {
        public abstract IEnumerable<Product> GetFeaturedProducts();
    }

}