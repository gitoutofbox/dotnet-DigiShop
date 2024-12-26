using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigiShop.Models;

public class Product
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; } 
    public string? Description { get; set; }

    [ForeignKey("CategoryId")]
    public Category? Category { get; set; }
    public int CategoryId { get; set; }

    public Product(string name)
    {
        Name = name;
    }
}
