
using System.Text.Json.Serialization;
using FluentValidation.AspNetCore;
using Products.Core;
using Products.Core.MappingProfile;
using Products.Infrastructure;
using ProductsAPI.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCore();
builder.Services.AddInfrastructure();
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AllowNullCollections = true;
    cfg.AllowNullDestinationValues = true;
}, typeof(ProductMapProfiles).Assembly);

builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(cors =>
{
    cors.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("*");
    });
});

var app = builder.Build();

app.UseExceptionHandlingMiddleware();

app.UseRouting();
app.UseSwagger();
app.UseSwaggerUI();

app.UseCors();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();
app.Run();