using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;

namespace DoItRight_Domain
{
    public class ProductService
    {
        private readonly ProductRepository _repository;

        public ProductService(ProductRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<DiscountedProduct> GetFeaturedProducts(IPrincipal user)
        {
            if(user == null)
            {
                throw new ArgumentNullException("user");
            }
            var results = _repository.GetFeaturedProducts().Select(p=>p.ApplyDiscountFor(user));
            return results;
        }
    }
}