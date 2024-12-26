using System;
using System.ComponentModel.DataAnnotations;

namespace DigiShop.Models.Dtos;

public class CategoryUpdateDto
{
    [Required(ErrorMessage = "You should provide a valid name")]
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(200)]
    public string? Description { get; set; }
}
