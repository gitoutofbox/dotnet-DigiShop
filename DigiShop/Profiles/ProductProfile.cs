using System;
using AutoMapper;

namespace DigiShop.Profiles;

public class ProductProfile: Profile
{
    public ProductProfile() {
        CreateMap<Models.Product, Models.Dtos.ProductDto>();
        CreateMap<Models.Dtos.ProductAddDto, Models.Product>();
        
        CreateMap<Models.Dtos.ProductUpdateDto, Models.Product>();
        CreateMap<Models.Product, Models.Dtos.ProductUpdateDto>();
    }
}
