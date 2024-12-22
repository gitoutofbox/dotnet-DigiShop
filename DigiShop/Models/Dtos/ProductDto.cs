using System;
using System.ComponentModel.DataAnnotations;

namespace DigiShop.Models.Dtos;

public class ProductDto
{
    [Required]
    public int Id { get; set; }

    [Required]
    public int CategoryId { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }
}
