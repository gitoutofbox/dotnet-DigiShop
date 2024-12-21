using System;

namespace DigiShop.Models.Dtos;

public class CategoryAddDto
{
    public string Name {get; set;}  = string.Empty;
    public string? Description {get; set;}
}
