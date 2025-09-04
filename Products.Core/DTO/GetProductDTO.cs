using Products.Core.Enums;

namespace Products.Core.DTO;

public class GetProductDto
{
    public int ProductID { get; set; }
    public string ProductName { get; set; }
    public Categories Category { get; set; }
    public decimal UnitPrice { get; set; }
    public int Stock { get; set; }
}