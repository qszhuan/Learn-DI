namespace DoItRight_DbAccess
{
    public partial class Product
    {
         public DoItRight_Domain.Product ToDomainProduct()
         {
             return new DoItRight_Domain.Product {Name = Name, UnitPrice = UnitPrice};
         }
    }
}
