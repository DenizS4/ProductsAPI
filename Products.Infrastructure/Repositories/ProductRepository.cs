using AutoMapper;
using Dapper;
using Products.Core.DTO;
using Products.Core.Entities;
using Products.Core.Interfaces;
using Products.Infrastructure.DbContexts;

namespace Products.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ProductDbContext _context;
    private readonly IMapper _mapper;

    public ProductRepository(ProductDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<Product>> GetAllProducts()
    {
        string query = "SELECT * FROM public.\"Products\"";
        var products = (await _context.GetConnection.QueryAsync<Product>(query)).ToList();
        return products;
    }

    public async Task<Product> GetProductsById(int productId)
    {
        string query = "SELECT * FROM public.\"Products\" Where \"Id\" = " + productId;
        var product = await _context.GetConnection.QueryFirstOrDefaultAsync<Product>(query);
        if (product == null)
        {
            throw new Exception("Product not found");
        }
        return product;
    }

    public async Task<List<Product>> GetProductsByCategory(string category)
    {
        string query = "SELECT * FROM public.\"Products\" Where \"Category\" = " + category;
        var product = (await _context.GetConnection.QueryAsync<Product>(query)).ToList();
        if (product == null)
        {
            throw new Exception("Product not found");
        }
        return product;
    }

    public async Task<List<Product>> GetProductsBySearchString(string searchString)
    {
        string query = @"
        SELECT * 
        FROM public.""Products""
        WHERE ""ProductName"" ILIKE @SearchPattern
           OR ""Category"" ILIKE @SearchPattern;
    ";

        var products = (await _context.GetConnection
            .QueryAsync<Product>(query, new { SearchPattern = "%" + searchString + "%" })).ToList();
        
        return products;
    }

    public async Task<GetProductDto> CreateProduct(Product product)
    {
        string query = @"
            INSERT INTO public.""Products"" 
                (""CreateDate"", ""ProductName"", ""Category"", ""UnitPrice"", ""Stock"") 
            VALUES (@CreateDate, @ProductName, @Category, @UnitPrice, @Stock)
            RETURNING *;
        ";

        var addedProduct = await _context.GetConnection.QuerySingleAsync<Product>(query, product);
        
        var mappedAddedProduct = _mapper.Map<GetProductDto>(addedProduct);
        return mappedAddedProduct;
    }

    public async Task<GetProductDto> UpdateProduct(Product product)
    {
        string query = @"
        UPDATE public.""Products""
        SET ""ProductName"" = @ProductName,
            ""Category"" = @Category,
            ""UnitPrice"" = @UnitPrice,
            ""Stock"" = @Stock,
            ""CreateDate"" = @CreateDate
        WHERE ""ProductID"" = @ProductID
        RETURNING *;
    ";

        var updatedProduct = await _context.GetConnection
            .QuerySingleOrDefaultAsync<Product>(query, product);
        
        var mappedUpdatedProduct  = _mapper.Map<GetProductDto>(updatedProduct );
        return mappedUpdatedProduct;
    }

    public async Task<bool> DeleteProduct(int productId)
    {
        string query = "DELETE FROM public.\"Products\" Where \"Id\" = " + productId;
        var rowsAffected = await _context.GetConnection.ExecuteAsync(query);

        if (rowsAffected == 0)
        {
            return false;
        }

        return true;
    }
}