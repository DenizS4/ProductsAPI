using Products.Core.DTO;

namespace Products.Core.Interfaces;

public interface IProductService
{
    Task<List<GetProductDto>> GetAllProducts();
    Task<GetProductDto> GetProductsById(int productId);
    Task<List<GetProductDto>> GetProductsByCategory(string category);
    Task<List<GetProductDto>> GetProductsBySearchString(string searchString);
    Task<GetProductDto> CreateProduct(AddProductDto product);
    Task<GetProductDto> UpdateProduct(UpdateProductDto product);
    Task<bool> DeleteProduct(int productId);
}