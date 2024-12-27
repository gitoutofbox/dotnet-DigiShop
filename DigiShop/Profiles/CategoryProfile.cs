using System;
using AutoMapper;

namespace DigiShop.Profiles;

public class CategoryProfile: Profile
{
    public CategoryProfile(){
        CreateMap<Models.Category, Models.Dtos.CategoryDto>();
        CreateMap<Models.Category, Models.Dtos.CategoryWithProductsDto>();
        CreateMap<Models.Dtos.CategoryAddDto, Models.Category>();
        
        CreateMap<Models.Category, Models.Dtos.CategoryUpdateDto>();
        CreateMap<Models.Dtos.CategoryUpdateDto, Models.Category>();
    }
}
