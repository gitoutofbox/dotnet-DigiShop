using System;
using AutoMapper;

namespace DigiShop.Profiles;

public class CategoryProfile: Profile
{
    public CategoryProfile(){
        CreateMap<Models.Category, Models.Dtos.CategoryDto>();
        CreateMap<Models.Dtos.CategoryAddDto, Models.Category>();
    }
}
