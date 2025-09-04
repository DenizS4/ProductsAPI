using System.Data;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Products.Infrastructure.DbContexts;

public class ProductDbContext
{
    private readonly IConfiguration _configuration;
    private readonly IDbConnection _connection;
    
    public ProductDbContext(IConfiguration configuration)
    {
        _configuration = configuration ?? throw new System.ArgumentNullException(nameof(configuration));
        string? connectionString = _configuration.GetConnectionString("PostgreCon");
        
        _connection = new NpgsqlConnection(connectionString);
    }

    public IDbConnection GetConnection => _connection;
}