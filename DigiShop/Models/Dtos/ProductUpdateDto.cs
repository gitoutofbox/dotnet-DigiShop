using System;
using System.ComponentModel.DataAnnotations;

namespace DigiShop.Models.Dtos;

public class ProductUpdateDto
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(200)]
    public string? Description { get; set; }
}
