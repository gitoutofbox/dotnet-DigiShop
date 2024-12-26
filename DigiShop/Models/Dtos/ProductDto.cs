using System;
using System.ComponentModel.DataAnnotations;

namespace DigiShop.Models.Dtos;

public class ProductDto
{
    public int Id { get; set; }
    
    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }
}
