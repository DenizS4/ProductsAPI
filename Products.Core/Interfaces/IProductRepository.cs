using Products.Core.DTO;
using Products.Core.Entities;

namespace Products.Core.Interfaces;

public interface IProductRepository
{
    Task<List<Product>> GetAllProducts();
    Task<Product> GetProductsById(int productId);
    Task<List<Product>> GetProductsByCategory(string category);
    Task<List<Product>> GetProductsBySearchString(string searchString);
    Task<GetProductDto> CreateProduct(Product product);
    Task<GetProductDto> UpdateProduct(Product product);
    Task<bool> DeleteProduct(int productId);
}