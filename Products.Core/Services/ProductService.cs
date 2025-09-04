using AutoMapper;
using Products.Core.DTO;
using Products.Core.Entities;
using Products.Core.Interfaces;

namespace Products.Core.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }
    public async Task<List<GetProductDto>> GetAllProducts()
    {
        var products = await _productRepository.GetAllProducts();
        
        if(products == null)
            throw new ApplicationException("No products found");
        var productsMapped = _mapper.Map<List<GetProductDto>>(products);
        return productsMapped;
    }

    public async Task<GetProductDto> GetProductsById(int productId)
    {
        var products = await _productRepository.GetProductsById(productId);
        
        if(products == null)
            throw new ApplicationException("No products found");
        var productsMapped = _mapper.Map<GetProductDto>(products);
        return productsMapped;
    }

    public async Task<List<GetProductDto>> GetProductsByCategory(string category)
    {
        var products = await _productRepository.GetProductsByCategory(category);
        
        if(products == null)
            throw new ApplicationException("No products found");
        var productsMapped = _mapper.Map<List<GetProductDto>>(products);
        return productsMapped;
    }

    public async Task<List<GetProductDto>> GetProductsBySearchString(string searchString)
    {
        var products = await _productRepository.GetProductsBySearchString(searchString);
        
        if(products == null)
            throw new ApplicationException("No products found");
        var productsMapped = _mapper.Map<List<GetProductDto>>(products);
        return productsMapped;
    }

    public async Task<GetProductDto> CreateProduct(AddProductDto product)
    {
        product.CreateDate = DateTime.Now;
        var productsMapped = _mapper.Map<Product>(product);
        var products = await _productRepository.CreateProduct(productsMapped);
        
        if(products == null)
            throw new ApplicationException("No products found");
        return products;
    }

    public async Task<GetProductDto> UpdateProduct(UpdateProductDto product)
    {
        product.UpdateDate = DateTime.Now;
        var productsMapped = _mapper.Map<Product>(product);
        var products = await _productRepository.UpdateProduct(productsMapped);
        
        if(products == null)
            throw new ApplicationException("No products found");
        return products;
    }

    public async Task<bool> DeleteProduct(int productId)
    {
        var products = await _productRepository.DeleteProduct(productId);
        
        if(products == false)
            throw new ApplicationException("No products found");
        return products;
    }
}