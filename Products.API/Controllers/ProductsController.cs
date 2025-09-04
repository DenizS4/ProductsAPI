using Microsoft.AspNetCore.Mvc;
using Products.Core.DTO;
using Products.Core.Entities;
using Products.Core.Interfaces;

namespace ECommerce.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductsController :Controller
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }
    [HttpGet("GetAllProducts")]
    public async Task<IActionResult> GetAllProducts()
    {
        var products = await _productService.GetAllProducts();
        
        return Ok(products);
    }
    [HttpGet("GetProductByProductId")]
    public async Task<IActionResult> GetProductByProductId(int productId)
    {
        var product = await _productService.GetProductsById(productId);

        return Ok(product);
        
    }
    [HttpGet("GetProductsByCategoryId")]
    public async Task<IActionResult> GetProductsByCategoryId(string category)
    {
        var products = await _productService.GetProductsByCategory(category);
        
        return Ok(products);
        
    }
    [HttpGet("GetProductsBySearchString")]
    public async Task<IActionResult> GetProductsBySearchString(string searchString)
    {
        var products = await _productService.GetProductsBySearchString(searchString);
        
        return Ok(products);
    }
    [HttpPut("UpdateProducts")]
    public async Task<IActionResult> UpdateProducts(UpdateProductDto product)
    {
        if (product == null)
        {
            throw new Exception("Product cannot be null");
        }
        var updatedProduct = await _productService.UpdateProduct(product);
        
        return Ok(updatedProduct);
    }
    [HttpPost("AddProducts")]
    public async Task<IActionResult> AddProducts(AddProductDto product)
    {
        if (product == null)
        {
            throw new Exception("Product cannot be null");
        }

        var addedProduct = await _productService.CreateProduct(product);
        
        return Ok(addedProduct);
    }
    [HttpDelete("DeleteProducts")]
    public async Task<IActionResult> DeleteProducts(int productId)
    {
        if (productId == 0)
        {
            throw new Exception("ProductId cannot be zero");
        }
        var isDeleted = await _productService.DeleteProduct(productId);
        
        return Ok(isDeleted);
    }
    
}