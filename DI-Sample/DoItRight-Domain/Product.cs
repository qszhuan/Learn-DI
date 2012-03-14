using System.Security.Principal;

namespace DoItRight_Domain
{
    public class Product
    {
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }

        public DiscountedProduct ApplyDiscountFor(IPrincipal user)
        {
            var discount = user.IsInRole("PreferredCustomer") ? 0.95m:1;
            return new DiscountedProduct(Name, UnitPrice*discount);
        }
    }
}