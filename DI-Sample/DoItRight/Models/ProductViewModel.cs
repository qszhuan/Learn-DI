using DoItRight_Domain;

namespace DoItRight.Models
{
    public class ProductViewModel
    {
        public ProductViewModel(DiscountedProduct product)
        {
            Name = product.Name;
            UnitPrice = product.UnitPrice;
            SummaryText = string.Format("{0}:({1})",product.Name, product.UnitPrice);
        }

        public string Name { get; set; }
        public string SummaryText { get; set; }
        public decimal UnitPrice { get; set; }
    }
}