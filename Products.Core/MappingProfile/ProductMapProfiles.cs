using AutoMapper;
using Products.Core.DTO;
using Products.Core.Entities;

namespace Products.Core.MappingProfile;

public class ProductMapProfiles : Profile
{
    public ProductMapProfiles()
    {
        CreateMap<AddProductDto, Product>().
            ForMember(x =>x.CreateDate, opt => opt.MapFrom(src => src.CreateDate)).
            ForMember(x =>x.ProductName, opt => opt.MapFrom(src => src.ProductName)).
            ForMember(x =>x.Category, opt => opt.MapFrom(src => src.Category)).
            ForMember(x =>x.UnitPrice, opt => opt.MapFrom(src => src.UnitPrice)).
            ForMember(x =>x.Stock, opt => opt.MapFrom(src => src.Stock)).
            ForMember(x =>x.UpdateDate, opt => opt.Ignore()).
            ForMember(x =>x.ProductID, opt => opt.Ignore())
            .ReverseMap();
        CreateMap<UpdateProductDto, Product>().
            ForMember(x =>x.ProductID, opt => opt.MapFrom(src => src.ProductID)).
            ForMember(x =>x.CreateDate, opt => opt.MapFrom(src => src.UpdateDate)).
            ForMember(x =>x.ProductName, opt => opt.MapFrom(src => src.ProductName)).
            ForMember(x =>x.Category, opt => opt.MapFrom(src => src.Category)).
            ForMember(x =>x.UnitPrice, opt => opt.MapFrom(src => src.UnitPrice)).
            ForMember(x =>x.Stock, opt => opt.MapFrom(src => src.Stock)).
            ForMember(x =>x.CreateDate, opt => opt.Ignore())
            .ReverseMap();
        CreateMap<GetProductDto, Product>().
            ForMember(x =>x.ProductID, opt => opt.MapFrom(src => src.ProductID)).
            ForMember(x =>x.ProductName, opt => opt.MapFrom(src => src.ProductName)).
            ForMember(x =>x.Category, opt => opt.MapFrom(src => src.Category)).
            ForMember(x =>x.UnitPrice, opt => opt.MapFrom(src => src.UnitPrice)).
            ForMember(x =>x.Stock, opt => opt.MapFrom(src => src.Stock)).
            ForMember(x =>x.CreateDate, opt => opt.Ignore()).
            ForMember(x =>x.UpdateDate, opt => opt.Ignore())
            .ReverseMap();
        
            
    }
}