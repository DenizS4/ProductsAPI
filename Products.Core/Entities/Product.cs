using Products.Core.Enums;

namespace Products.Core.Entities;

public class Product
{
    public int ProductID { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime UpdateDate { get; set; }
    public string ProductName { get; set; }
    public Categories Category { get; set; }
    public decimal UnitPrice { get; set; }
    public int Stock { get; set; }
}
