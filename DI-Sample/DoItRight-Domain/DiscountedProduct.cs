namespace DoItRight_Domain
{
    public class DiscountedProduct
    {
        public DiscountedProduct(string name, decimal unitPrice)
        {
            Name = name;
            UnitPrice = unitPrice;
        }

        public string Name { get; private set; }

        public decimal UnitPrice { get; private set; }
    }
}