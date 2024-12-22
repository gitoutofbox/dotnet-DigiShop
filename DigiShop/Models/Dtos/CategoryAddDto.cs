using System;
using System.ComponentModel.DataAnnotations;

namespace DigiShop.Models.Dtos;

public class CategoryAddDto
{
    [Required]
    public string Name {get; set;}  = string.Empty;
    public string? Description {get; set;}
}
